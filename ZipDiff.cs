using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingWorxDeploymentUtility
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Security.Cryptography;

    public static class ZipDiff
    {
        public sealed record EntryInfo(
            string Path,
            long UncompressedSize,
            DateTimeOffset LastWriteTime,
            string? Sha256 // populated only when hashContent=true
        );

        public sealed record Difference(
            EntryInfo Left,
            EntryInfo Right,
            string Reason // e.g., "hash", "size", "time", "path"
        );

        public sealed record DiffResult(
            IReadOnlyList<EntryInfo> Added,
            IReadOnlyList<EntryInfo> Removed,
            IReadOnlyList<Difference> Modified,
            IReadOnlyList<EntryInfo> Unchanged
        )
        {
            public bool HasChanges => Added.Count > 0 || Removed.Count > 0 || Modified.Count > 0;
        }

        /// <summary>
        /// Compares two ZIP files and returns added/removed/modified entries.
        /// </summary>
        /// <param name="zipPathA">Baseline ZIP (left)</param>
        /// <param name="zipPathB">Target ZIP (right)</param>
        /// <param name="hashContent">If true, computes SHA-256 for byte-accurate detection</param>
        /// <param name="treatPathsCaseInsensitive">
        /// If true, normalizes keys to case-insensitive (Windows-like behavior).
        /// If false, uses case-sensitive matching (Linux/macOS-like).
        /// </param>
        /// <param name="timeTolerance">Tolerance for LastWriteTime comparisons (e.g., different tooling may shift a few seconds)</param>
        public static DiffResult Compare(
            string zipPathA,
            string zipPathB,
            bool hashContent = false,
            bool treatPathsCaseInsensitive = default,
            TimeSpan? timeTolerance = null)
        {
            if (string.IsNullOrWhiteSpace(zipPathA)) throw new ArgumentNullException(nameof(zipPathA));
            if (string.IsNullOrWhiteSpace(zipPathB)) throw new ArgumentNullException(nameof(zipPathB));
            if (!File.Exists(zipPathA)) throw new FileNotFoundException("ZIP not found", zipPathA);
            if (!File.Exists(zipPathB)) throw new FileNotFoundException("ZIP not found", zipPathB);

            // Default to OS behavior
            if (treatPathsCaseInsensitive == default)
            {
                treatPathsCaseInsensitive = OperatingSystem.IsWindows();
            }

            var comparer = treatPathsCaseInsensitive
                ? StringComparer.OrdinalIgnoreCase
                : StringComparer.Ordinal;

            var tol = timeTolerance ?? TimeSpan.FromSeconds(2);

            using var fsA = File.OpenRead(zipPathA);
            using var fsB = File.OpenRead(zipPathB);
            using var za = new ZipArchive(fsA, ZipArchiveMode.Read, leaveOpen: false);
            using var zb = new ZipArchive(fsB, ZipArchiveMode.Read, leaveOpen: false);

            var mapA = Index(za, hashContent, comparer);
            var mapB = Index(zb, hashContent, comparer);

            var added = new List<EntryInfo>();
            var removed = new List<EntryInfo>();
            var modified = new List<Difference>();
            var unchanged = new List<EntryInfo>();

            // Keys present in A
            foreach (var kvp in mapA)
            {
                if (!mapB.TryGetValue(kvp.Key, out var right))
                {
                    removed.Add(kvp.Value);
                    continue;
                }

                var left = kvp.Value;

                // Compare content or metadata
                if (hashContent)
                {
                    if (!string.Equals(left.Sha256, right.Sha256, StringComparison.Ordinal))
                    {
                        modified.Add(new Difference(left, right, "hash"));
                    }
                    else
                    {
                        unchanged.Add(left);
                    }
                }
                else
                {
                    // Compare uncompressed size first
                    if (left.UncompressedSize != right.UncompressedSize)
                    {
                        modified.Add(new Difference(left, right, "size"));
                    }
                    else
                    {
                        // Compare time within tolerance (ZIP times can vary by tooling)
                        var dtLeft = left.LastWriteTime;
                        var dtRight = right.LastWriteTime;
                        if (Abs(dtLeft - dtRight) > tol)
                        {
                            modified.Add(new Difference(left, right, "time"));
                        }
                        else
                        {
                            unchanged.Add(left);
                        }
                    }
                }
            }

            // Keys present in B but not in A
            foreach (var kvp in mapB)
            {
                if (!mapA.ContainsKey(kvp.Key))
                {
                    added.Add(kvp.Value);
                }
            }

            return new DiffResult(added, removed, modified, unchanged);
        }

        private static TimeSpan Abs(TimeSpan ts) => ts < TimeSpan.Zero ? -ts : ts;

        private static Dictionary<string, EntryInfo> Index(
            ZipArchive zip,
            bool hashContent,
            StringComparer comparer)
        {
            var dict = new Dictionary<string, EntryInfo>(comparer);

            foreach (var e in zip.Entries)
            {
                // Skip directory entries (they usually end with "/")
                if (IsDirectory(e)) continue;

                var normPath = NormalizePath(e.FullName);

                string? sha = null;
                long size = e.Length;
                var time = e.LastWriteTime;

                if (hashContent)
                {
                    sha = ComputeSha256Hex(e);
                }

                dict[normPath] = new EntryInfo(normPath, size, time, sha);
            }

            return dict;
        }

        private static bool IsDirectory(ZipArchiveEntry entry)
            => entry.FullName.EndsWith("/", StringComparison.Ordinal);

        private static string NormalizePath(string p)
        {
            // Standardize to forward slashes, trim redundant slashes/spaces
            var s = p.Replace('\\', '/').Trim();
            // Remove leading "./"
            if (s.StartsWith("./", StringComparison.Ordinal)) s = s[2..];
            // Remove trailing "/" if present (but directories are skipped anyway)
            if (s.EndsWith("/", StringComparison.Ordinal)) s = s.TrimEnd('/');
            return s;
        }

        private static string ComputeSha256Hex(ZipArchiveEntry entry)
        {
            using var sha = SHA256.Create();
            using var s = entry.Open();

            // Efficient streaming hash with reusable buffer
            byte[] buffer = ArrayPool<byte>.Shared.Rent(128 * 1024);
            try
            {
                int read;
                while ((read = s.Read(buffer, 0, buffer.Length)) > 0)
                {
                    sha.TransformBlock(buffer, 0, read, null, 0);
                }
                sha.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
                return Convert.ToHexString(sha.Hash!).ToLowerInvariant();
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }
    }
}
