using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThingWorxDeploymentUtility
{
    public partial class CreateExtensionPopup : Form
    {

        public string str_FileName;
        public CreateExtensionPopup(string str_FileName)
        {
            InitializeComponent();
            this.str_FileName = str_FileName;
            tb_VendorName.Text = Properties.Settings.Default.Vendor;
            tb_Version.Text = Properties.Settings.Default.Version;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_CreateExtension_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Vendor = tb_VendorName.Text;
            Properties.Settings.Default.Version = tb_Version.Text;
            Properties.Settings.Default.Save();
            CreateExtension(str_FileName, tb_Version.Text, tb_VendorName.Text, "10.0.0");
            Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(Application.ExecutablePath));
            this.Close();
        }

        private void CreateExtension(
   string zipFileName,
   string packageVersion,
   string vendor = "PTC Professional Services",
   string thingWorxVersion = "10.0.0"
)
        {
            if (string.IsNullOrWhiteSpace(zipFileName))
                throw new ArgumentException("zipFileName is required");

            if (string.IsNullOrWhiteSpace(packageVersion))
                throw new ArgumentException("packageVersion is required");

            string cwd = Directory.GetCurrentDirectory();
            string zipPath = Path.Combine(cwd, zipFileName);

            if (!File.Exists(zipPath))
                throw new FileNotFoundException("ZIP file not found", zipPath);

            // Prepare extraction directory
            string baseDir = Path.GetDirectoryName(zipPath)!;
            string entitiesDir = Path.Combine(baseDir, "result", "Entities");

            Directory.CreateDirectory(entitiesDir);

            // Extract ZIP
            ZipFile.ExtractToDirectory(zipPath, entitiesDir);

            // Resolve project name
            string projectsDir = Path.Combine(entitiesDir, "Projects");
            string projectFile = Directory.GetFiles(projectsDir, "*.xml").First();
            string projectName = Path.GetFileNameWithoutExtension(projectFile);

            // Load organizations and groups
            var organizations = Directory.GetFiles(Path.Combine(entitiesDir, "Organizations"))
                                         .Select(f => Path.GetFileNameWithoutExtension(f))
                                         .ToList();

            var userGroups = Directory.GetFiles(Path.Combine(entitiesDir, "Groups"))
                                    .Select(f => Path.GetFileNameWithoutExtension(f))
                                    .ToList();

            // Read project XML
            var lines = File.ReadAllLines(projectFile).ToList();

            // Inject Visibility
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Trim() == "<Visibility></Visibility>")
                {
                    var sb = new StringBuilder();
                    sb.AppendLine(" <Visibility>");

                    foreach (var org in organizations)
                        sb.AppendLine($"  <Principal isPermitted=\"true\" name=\"{org}\" type=\"Organization\"/>");

                    foreach (var ou in userGroups)
                        sb.AppendLine($"  <Principal isPermitted=\"true\" name=\"{ou}\" type=\"OrganizationalUnit\"/>");

                    sb.AppendLine(" </Visibility>");
                    lines[i] = sb.ToString().TrimEnd();
                    break;
                }
            }

            string updatedProjectXml = string.Join(Environment.NewLine, lines);
            File.WriteAllText(projectFile, updatedProjectXml);

            // Create metadata.xml content
            string metadataContent = updatedProjectXml
                .Replace("Projects>", "ExtensionPackages>")
                .Replace("<Project", "<ExtensionPackage")
                .Replace("</Project>", "</ExtensionPackage>");

            var metaLines = metadataContent.Split('\n')
                .Select(l => l.TrimEnd('\r'))
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .ToList();

            for (int i = 0; i < metaLines.Count; i++)
            {
                if (metaLines[i].Contains("dependsOn"))
                {
                    int idx = metaLines[i].IndexOf(",\"projects\"");
                    if (idx > 0)
                    {
                        metaLines[i] = metaLines[i].Substring(0, idx)
                            .Replace("\"", "")
                            .Replace("extensions:", "")
                            .Replace("{", "")
                            .Replace("}", "") + "\"";
                    }
                }
                else if (metaLines[i].Contains("aspect"))
                {
                    metaLines[i] = string.Empty;
                }
                else if (metaLines[i].Contains("minPlatformVersion"))
                {
                    metaLines[i] = $" minimumThingWorxVersion=\"{thingWorxVersion}\"";
                }
                else if (metaLines[i].Contains("state"))
                {
                    metaLines[i] = $" vendor=\"{vendor}\"";
                }
                else if (metaLines[i].Contains("packageVersion"))
                {
                    metaLines[i] = $" packageVersion=\"{packageVersion}\"";
                }
                else if (metaLines[i].Contains("publishResult"))
                {
                    metaLines[i] = $" lastModifiedDate=\"{DateTime.Now:yyyy-MM-ddTHH:mm:ss}\"";
                }
            }

            metaLines = metaLines.Where(l => !string.IsNullOrWhiteSpace(l)).ToList();

            string metadataXmlPath = Path.Combine(baseDir, "result", "metadata.xml");
            File.WriteAllText(metadataXmlPath, string.Join(Environment.NewLine, metaLines));

            // Create extension ZIP
            string timestamp = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
            string outputZip = Path.Combine(
                cwd,
                $"{projectName}_{timestamp}_Version_{packageVersion}_Extension.zip"
            );

            string srcDir = Path.Combine(baseDir, "result");

            using (var zip = ZipFile.Open(outputZip, ZipArchiveMode.Create))
            {
                foreach (string file in Directory.GetFiles(srcDir, "*", SearchOption.AllDirectories))
                {
                    string entryName = Path.GetRelativePath(srcDir, file);
                    zip.CreateEntryFromFile(file, entryName, CompressionLevel.Optimal);
                }
            }

            // Cleanup
            Directory.Delete(srcDir, true);
        }
    }
}
