using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Nodes;

namespace ThingWorxDeploymentUtility
{
    public partial class DeploymentUtility : Form
    {
        private BindingList<string> blst_Environment1Items;
        private BindingList<string> blst_Environment2Items;

        private string str_EnvironmentURL1;
        private string str_EnvironmentURL2;
        private string str_AppKey1;
        private string str_AppKey2;
        private decimal dec_Port1;
        private decimal dec_Port2;
        private string str_FileRepository1;
        private string str_FileRepository2;
        private string str_FileRepositoryPackagingPath1;
        private string str_FileRepositoryPackagingPath2;
        private string str_FileRepositoryReceivingPath1;
        private string str_FileRepositoryReceivingPath2;
        private JsonArray jsonArray_Files1;
        private JsonArray jsonArray_Files2;
        private JsonArray json_Projects1;
        private JsonArray json_Projects2;

        public DeploymentUtility()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadEnvironmentsList();
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            Settings frm_Settings = new Settings();
            frm_Settings.ShowDialog();
            frm_Settings.FormClosed += (s, e) => { loadEnvironmentsList(); };
        }



        private void loadEnvironmentsList()
        {

            if (Properties.Settings.Default.EnvironmentList == null)
            {
                StringCollection sc = new StringCollection();
                sc.Add(getDefaultEntry());
                Properties.Settings.Default.EnvironmentList = sc;
            }

            List<string> lst_Environments1 = Properties.Settings.Default.EnvironmentList.Cast<string>().ToList();
            List<string> lst_Environments2 = Properties.Settings.Default.EnvironmentList.Cast<string>().ToList();
            blst_Environment1Items = getEnvironmentNames(lst_Environments1);
            blst_Environment2Items = getEnvironmentNames(lst_Environments2);
            this.cb_Environment1.DataSource = blst_Environment1Items;
            this.cb_Environment2.DataSource = blst_Environment2Items;


        }

        private string getDefaultEntry()
        {

            JsonObject json_Environment = new JsonObject();
            json_Environment.Add("EnvironmentURL", "https://NO_URL_PRESENT");
            json_Environment.Add("Port", "8443");
            json_Environment.Add("AppKey", "xxxxx-xxxx-xxxx-xxxx");
            json_Environment.Add("FileRepository", "NoRepository");
            json_Environment.Add("FileRepositoryPath", "NoRepositoryPath");
            json_Environment.Add("FileRepositoryReceivingPath", "NoRepositoryReceivingPath");
            return json_Environment.ToJsonString();
        }

        private BindingList<string> getEnvironmentNames(List<string> environments)
        {
            int int_EnvironmentsCount = environments.Count();
            for (int i = 0; i < int_EnvironmentsCount; i++)
            {
                JsonNode environment = convertStringToJson(environments[i].ToString());
                // JsonObject objEnvironment = environment!.AsObject();
                environments[i] = environment["EnvironmentURL"].ToString();
            }

            return new BindingList<string>(environments);
        }






        private void cb_Environment1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_CurrentEnvironmentURL = this.cb_Environment1.SelectedItem.ToString();

            List<string> lst_Environments = Properties.Settings.Default.EnvironmentList.Cast<string>().ToList();

            string str_CurrentEnvironment = lst_Environments.FirstOrDefault(environment =>
            {
                JsonNode json_Environment = convertStringToJson(environment);
                return json_Environment["EnvironmentURL"].ToString() == str_CurrentEnvironmentURL;
            });

            JsonNode json_CurrentEnvironment = convertStringToJson(str_CurrentEnvironment);
            str_EnvironmentURL1 = json_CurrentEnvironment["EnvironmentURL"].ToString();
            dec_Port1 = (decimal)Decimal.Parse(json_CurrentEnvironment["Port"].ToString());
            str_AppKey1 = json_CurrentEnvironment["AppKey"].ToString();
            str_FileRepository1 = json_CurrentEnvironment["FileRepository"].ToString();
            str_FileRepositoryPackagingPath1 = json_CurrentEnvironment["FileRepositoryPath"].ToString();
            str_FileRepositoryReceivingPath1 = json_CurrentEnvironment["FileRepositoryReceivingPath"].ToString();

            lb_ApplicationLogEnvironment1.Links.Clear();
            lb_ApplicationLogEnvironment1.Links.Add(0, lb_ApplicationLogEnvironment1.Text.Length, str_EnvironmentURL1 + ":" + dec_Port1 + "/Thingworx/Composer/?continue#/modeler/monitoring/ApplicationLog");


            jsonArray_Files1 = getEnvironmentFiles(str_EnvironmentURL1, dec_Port1, str_AppKey1, str_FileRepository1, str_FileRepositoryPackagingPath1)["rows"].AsArray();
            assignFilesToGrid(this.dgv_EnvironmentFiles1, jsonArray_Files1);

            cb_Projects1.Enabled = false;
            json_Projects1 = getProjects(str_EnvironmentURL1, dec_Port1, str_AppKey1)["rows"].AsArray();
            cb_Projects1.DataSource = new BindingList<string>(convertArrayProjectsToList(json_Projects1));
            cb_Projects1.Enabled = true;
        }


        private JsonNode convertStringToJson(string str_JSON)
        {
            return JsonObject.Parse(str_JSON);


        }

        private List<string> convertArrayProjectsToList(JsonArray jsonarr_Projects)
        {

            List<string> names = new List<string>();
            int int_ProjectsCount = jsonarr_Projects.Count;
            for (int i = 0; i < int_ProjectsCount; i++)
            {


                names.Add(jsonarr_Projects[i]["name"].ToString());
            }

            return names;

        }


        private JsonNode getEnvironmentFiles(string str_Environment, decimal dec_Port, string str_AppKey, string str_FileRepository, string str_FileRepositoryPath)
        {
            string json_ServiceInput = $$"""{"path":"{{str_FileRepositoryPath}}"}""";
            return JsonNode.Parse(ExecuteHTTPRequest(str_Environment, dec_Port, str_AppKey, "Things/" + str_FileRepository + "/Services/GetFileListingWithLinks", json_ServiceInput));
        }

        private void assignFilesToGrid(DataGridView dg, JsonArray jsonArray_Files)
        {
            dg.Enabled = false;
            dg.Rows.Clear();
            foreach (JsonNode jsonFile in jsonArray_Files.ToList())
            {
                dg.Rows.Add(jsonFile["name"].ToString(), DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(jsonFile["lastModifiedDate"].ToString())).ToLocalTime(), jsonFile["size"].ToString().Split(".")[0], jsonFile["path"].ToString());

            }
            dg.Enabled = true;
            dg.Sort(dg.Columns[1],ListSortDirection.Descending);
        }

        private JsonNode getProjects(string str_Environment, decimal dec_Port, string str_AppKey)
        {
            var json_ServiceInput =
"""
{
  "searchExpression": "**",
  "withPermissions": true,
  "sortBy": "lastModifiedDate",
  "isAscending": false,
  "searchDescriptions": true,
  "includeInheritedThingShapes": true,
  "aspects": {
    "isSystemObject": false
  },
  "types": {
    "items": [ "Project" ]
  },
  "excludeFilters": [ "scope" ],
  "context": "searchFilter",
  "projectName": "",
  "searchText": "",
  "tags": [],
  "thingShapes": {},
  "thingTemplates": {},
  "suppressEntityContext": true,
  "excludedAspects": {
    "deprecated": {}
  }
}
""";



            return JsonNode.Parse(ExecuteHTTPRequest(str_Environment, dec_Port, str_AppKey, "Resources/SearchFunctions/Services/SpotlightSearchV2", json_ServiceInput));
        }

        private string ExecuteHTTPRequest(string str_EnvironmentURL, Decimal dec_Port, string str_AppKey, string str_ServicePart, string json_ServiceInput)
        {
            string str_BaseURL = str_EnvironmentURL + ":" + dec_Port + "/Thingworx/";


            using var http = new HttpClient(new SocketsHttpHandler
            {
                SslOptions = new System.Net.Security.SslClientAuthenticationOptions
                {
                    RemoteCertificateValidationCallback = (_, _, _, _) => true
                }
            });

            http.BaseAddress = new Uri(str_BaseURL);

            // Required headers
            http.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            http.DefaultRequestHeaders.Add("AppKey", str_AppKey);



            using var req = new HttpRequestMessage(HttpMethod.Post, str_ServicePart);
            req.Content = new StringContent(json_ServiceInput, Encoding.UTF8, MediaTypeNames.Application.Json);


            using var resp = http.Send(req, HttpCompletionOption.ResponseContentRead);

            //resp.EnsureSuccessStatusCode();
            return resp.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        }

        private string ExecuteHTTPRequestGetFile(string str_EnvironmentURL, Decimal dec_Port, string str_AppKey, string str_ServicePart, string str_FileName)
        {
            string str_BaseURL = str_EnvironmentURL + ":" + dec_Port + "/Thingworx/";


            using var http = new HttpClient(new SocketsHttpHandler
            {
                SslOptions = new System.Net.Security.SslClientAuthenticationOptions
                {
                    RemoteCertificateValidationCallback = (_, _, _, _) => true
                }
            });

            http.BaseAddress = new Uri(str_BaseURL);

            // Required headers
            http.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            http.DefaultRequestHeaders.Add("AppKey", str_AppKey);



            using var req = new HttpRequestMessage(HttpMethod.Get, str_ServicePart);
            using var resp = http.Send(req, HttpCompletionOption.ResponseContentRead);

            resp.EnsureSuccessStatusCode();


            string str_LocalPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/" + str_FileName;
            using var stream = resp.Content.ReadAsStream();
            using var file = File.Create(str_LocalPath);
            stream.CopyTo(file);
            return str_LocalPath;


        }

        private string ExecuteHTTPRequestSendFile(string str_EnvironmentURL, Decimal dec_Port, string str_AppKey, string str_ServicePart, string str_FileName, string str_LocalFileName, string str_FileRepository, string str_RepositoryFilePath)
        {
            string str_BaseURL = str_EnvironmentURL + ":" + dec_Port + "/Thingworx/";


            using var http = new HttpClient(new SocketsHttpHandler
            {
                SslOptions = new System.Net.Security.SslClientAuthenticationOptions
                {
                    RemoteCertificateValidationCallback = (_, _, _, _) => true
                }
            });

            http.BaseAddress = new Uri(str_BaseURL);

            // Required headers
            http.DefaultRequestHeaders.Add("AppKey", str_AppKey);
            http.DefaultRequestHeaders.Add("X-XSRF-TOKEN", "TWX-XSRF-TOKEN-VALUE");
            using var req = new HttpRequestMessage(HttpMethod.Post, str_ServicePart);
            var multipart = new MultipartFormDataContent();

            multipart.Add(new StringContent(str_FileRepository, Encoding.UTF8), "upload-repository");
            multipart.Add(new StringContent(str_RepositoryFilePath.Replace(str_FileName, ""), Encoding.UTF8), "upload-path");
            multipart.Add(new StringContent("Upload", Encoding.UTF8), "upload-submit");

            var fileStream = File.OpenRead(str_LocalFileName);
            var fileContent = new StreamContent(fileStream);
            multipart.Add(fileContent, "file", str_RepositoryFilePath + str_FileName);
            req.Content = multipart;
            using var resp = http.Send(req, HttpCompletionOption.ResponseContentRead);

            resp.EnsureSuccessStatusCode();
            return "200";





        }

        private JsonNode generateSCEPackage(string str_Environment, decimal dec_Port, string str_AppKey, string str_FileRepository, string str_FileRepositoryPath, string str_ProjectName)
        {
            string str_PackageName = str_ProjectName + "-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
            var json_ServiceInput = $$"""{ "projectName":"{{str_ProjectName}}","repositoryName":"{{str_FileRepository}}","path":"{{str_FileRepositoryPath}}","includeDependents":false,"name":"{{str_PackageName}}"}""";



            return JsonNode.Parse(ExecuteHTTPRequest(str_Environment, dec_Port, str_AppKey, "Resources/SourceControlFunctions/Services/ExportSourceControlledEntitiesToZipFile", json_ServiceInput));
        }
        private void btn_RefreshFileList_Click(object sender, EventArgs e)
        {

            assignFilesToGrid(this.dgv_EnvironmentFiles1, jsonArray_Files1);
        }

        private void btn_GeneratePackageEnvironment1_Click(object sender, EventArgs e)
        {
            string str_GeneratedSCEFile = generateSCEPackage(str_EnvironmentURL1, dec_Port1, str_AppKey1, str_FileRepository1, str_FileRepositoryPackagingPath1, cb_Projects1.SelectedItem.ToString())["rows"].AsArray()[0]["result"].ToString();
            DialogResult result = MessageBox.Show(
                "Generated Source Controlled Entities archive " + str_GeneratedSCEFile,
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information

            );
            jsonArray_Files1 = getEnvironmentFiles(str_EnvironmentURL1, dec_Port1, str_AppKey1, str_FileRepository1, str_FileRepositoryPackagingPath1)["rows"].AsArray();
            assignFilesToGrid(this.dgv_EnvironmentFiles1, jsonArray_Files1);
        }


        private void cb_Environment2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_CurrentEnvironmentURL = this.cb_Environment2.SelectedItem.ToString();

            List<string> lst_Environments = Properties.Settings.Default.EnvironmentList.Cast<string>().ToList();

            string str_CurrentEnvironment = lst_Environments.FirstOrDefault(environment =>
            {
                JsonNode json_Environment = convertStringToJson(environment);
                return json_Environment["EnvironmentURL"].ToString() == str_CurrentEnvironmentURL;
            });

            JsonNode json_CurrentEnvironment = convertStringToJson(str_CurrentEnvironment);
            str_EnvironmentURL2 = json_CurrentEnvironment["EnvironmentURL"].ToString();
            dec_Port2 = (decimal)Decimal.Parse(json_CurrentEnvironment["Port"].ToString());
            str_AppKey2 = json_CurrentEnvironment["AppKey"].ToString();
            str_FileRepository2 = json_CurrentEnvironment["FileRepository"].ToString();
            str_FileRepositoryPackagingPath2 = json_CurrentEnvironment["FileRepositoryPath"].ToString();
            str_FileRepositoryReceivingPath2 = json_CurrentEnvironment["FileRepositoryReceivingPath"].ToString();




            lb_ApplicationLogEnvironment2.Links.Clear();
            lb_ApplicationLogEnvironment2.Links.Add(0, lb_ApplicationLogEnvironment2.Text.Length, str_EnvironmentURL2 + ":" + dec_Port2 + "/Thingworx/Composer/?continue#/modeler/monitoring/ApplicationLog");


            jsonArray_Files2 = getEnvironmentFiles(str_EnvironmentURL2, dec_Port2, str_AppKey2, str_FileRepository2, str_FileRepositoryReceivingPath2)["rows"].AsArray();
            assignFilesToGrid(this.dgv_EnvironmentFiles2, jsonArray_Files2);
        }
        //returns the path of the locally downloaded file
        private string getFile(string str_Environment, decimal dec_Port, string str_AppKey, string str_FileRepository, string str_FileRepositoryPath, string str_FileName)
        {
            return ExecuteHTTPRequestGetFile(str_Environment, dec_Port, str_AppKey, "FileRepositoryDownloader?download-repository=" + str_FileRepository + "&download-path=" + str_FileRepositoryPath, str_FileName);
        }




        private void btn_TransferFile_Click(object sender, EventArgs e)
        {

            string str_DownloadedFile = getFile(str_EnvironmentURL1, dec_Port1, str_AppKey1, str_FileRepository1, dgv_EnvironmentFiles1.SelectedRows[0].Cells[3].Value.ToString(), dgv_EnvironmentFiles1.SelectedRows[0].Cells[0].Value.ToString());

            ExecuteHTTPRequestSendFile(str_EnvironmentURL2, dec_Port2, str_AppKey2, "FileRepositoryUploader", dgv_EnvironmentFiles1.SelectedRows[0].Cells[0].Value.ToString(), str_DownloadedFile, str_FileRepository2, str_FileRepositoryReceivingPath2);
            DialogResult result = MessageBox.Show(
               "Transferred Source Controlled Entities archive " + str_DownloadedFile + " to Environment 2.",
               "Information",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information
           );
            jsonArray_Files2 = getEnvironmentFiles(str_EnvironmentURL2, dec_Port2, str_AppKey2, str_FileRepository2, str_FileRepositoryReceivingPath2)["rows"].AsArray();
            assignFilesToGrid(this.dgv_EnvironmentFiles2, jsonArray_Files2);
            System.IO.File.Delete(str_DownloadedFile);

        }

        private void btn_CompareSelectedArchives_Click(object sender, EventArgs e)
        {
            string str_DownloadedFile1 = getFile(str_EnvironmentURL1, dec_Port1, str_AppKey1, str_FileRepository1, dgv_EnvironmentFiles1.SelectedRows[0].Cells[3].Value.ToString(), dgv_EnvironmentFiles1.SelectedRows[0].Cells[0].Value.ToString());
            string str_DownloadedFile2 = getFile(str_EnvironmentURL1, dec_Port1, str_AppKey1, str_FileRepository1, dgv_EnvironmentFiles1.SelectedRows[1].Cells[3].Value.ToString(), dgv_EnvironmentFiles1.SelectedRows[1].Cells[0].Value.ToString());
            ZipDiff.DiffResult meta = ZipDiff.Compare(str_DownloadedFile1, str_DownloadedFile2, hashContent: true);
            MessageBox.Show(
               "Difference between selected archives: " + Print("METADATA DIFF", meta),
               "Information",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information

           );
            System.IO.File.Delete(str_DownloadedFile1);
            System.IO.File.Delete(str_DownloadedFile2);

        }



        static string Print(string title, ZipDiff.DiffResult diff)
        {
            string str_Output = "";
            str_Output += $"=== {title} ===";
            str_Output += $"HasChanges: {diff.HasChanges}";
            str_Output += "\n";

            str_Output += "Added:";
            foreach (var e in diff.Added)
                str_Output += $"  + {e.Path}  ({e.UncompressedSize} bytes)";

            str_Output += "\nRemoved:";
            foreach (var e in diff.Removed)
                str_Output += "\n" + $"  - {e.Path}  ({e.UncompressedSize} bytes)";

            str_Output += "\nModified:";
            foreach (var m in diff.Modified)
                str_Output += "\n" + $"  * {m.Left.Path}  reason={m.Reason}";

            //str_Output += "\nUnchanged:";
            //foreach (var e in diff.Unchanged)
            //    str_Output += "\n"+$"    {e.Path}";
            str_Output += "\n";
            return str_Output;
        }

        private void btn_ImportSCEPackage_Click(object sender, EventArgs e)
        {
            string str_FileName = dgv_EnvironmentFiles1.SelectedRows[0].Cells[0].Value.ToString();//does not contain path
            DialogResult result = MessageBox.Show("The selected SCE package " + str_FileName + " will be imported in environment " + cb_Environment2.SelectedItem.ToString() + ". Are you sure you want to continue?", "WARNING: IMPORTING AN SCE PACKAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                //we create the folder where we will unzip the archive
                createFolder(str_EnvironmentURL2, dec_Port2, str_AppKey2, str_FileRepository2, str_FileRepositoryReceivingPath2, str_FileName.Replace(".zip", ""));
                extractArchive(str_EnvironmentURL2, dec_Port2, str_AppKey2, str_FileRepository2, str_FileRepositoryReceivingPath2, str_FileName);

                string str_ImportServiceResult = importSCEArchive(str_EnvironmentURL2, dec_Port2, str_AppKey2, str_FileRepository2, str_FileRepositoryReceivingPath2 + str_FileName.Replace(".zip", ""));

                deleteFolder(str_EnvironmentURL2, dec_Port2, str_AppKey2, str_FileRepository2, str_FileRepositoryReceivingPath2, str_FileName.Replace(".zip", ""));

                MessageBox.Show("Import service response: " + str_ImportServiceResult + ". Please check ApplicationLog for any issues.");
            }
        }

        private string extractArchive(string str_Environment, decimal dec_Port, string str_AppKey, string str_FileRepository, string str_FileRepositoryPath, string str_FileName)
        {
            string str_FileRepositoryEndPath = str_FileName.Replace(".zip", "");
            string str_ServiceInput = $$"""{"path":"{{str_FileRepositoryPath + str_FileRepositoryEndPath + "/"}}","zipFileName":"{{str_FileRepositoryPath + str_FileName}}"}""";
            return ExecuteHTTPRequest(str_Environment, dec_Port, str_AppKey, "Things/" + str_FileRepository + "/Services/ExtractZipArchive", str_ServiceInput);
        }

        private string createFolder(string str_Environment, decimal dec_Port, string str_AppKey, string str_FileRepository, string str_FileRepositoryPath, string str_FolderName)
        {
            string str_ServiceInput = $$"""{"path":"{{str_FileRepositoryPath + str_FolderName}}"}""";
            return ExecuteHTTPRequest(str_Environment, dec_Port, str_AppKey, "Things/" + str_FileRepository + "/Services/CreateFolder", str_ServiceInput);
        }

        private string deleteFolder(string str_Environment, decimal dec_Port, string str_AppKey, string str_FileRepository, string str_FileRepositoryPath, string str_FolderName)
        {
            string str_ServiceInput = $$"""{"path":"{{str_FileRepositoryPath + str_FolderName}}"}""";
            return ExecuteHTTPRequest(str_Environment, dec_Port, str_AppKey, "Things/" + str_FileRepository + "/Services/DeleteFolder", str_ServiceInput);
        }

        private string deleteFile(string str_Environment, decimal dec_Port, string str_AppKey, string str_FileRepository, string str_FileNameWithPath)
        {
            string str_ServiceInput = $$"""{"path":"{{str_FileNameWithPath}}"}""";
            return ExecuteHTTPRequest(str_Environment, dec_Port, str_AppKey, "Things/" + str_FileRepository + "/Services/DeleteFile", str_ServiceInput);
        }

        private string importSCEArchive(string str_Environment, decimal dec_Port, string str_AppKey, string str_FileRepository, string str_FileRepositoryPath)
        {
            string str_ServiceInput = $$"""{ "path":"{{str_FileRepositoryPath}}","repositoryName":"{{str_FileRepository}}","useDefaultDataProvider":false,"withSubsystems":false,"overwritePropertyValues":false,"overwriteConfigurationTableValues":false}""";
            return ExecuteHTTPRequest(str_Environment, dec_Port, str_AppKey, "Resources/SourceControlFunctions/Services/ImportSourceControlledEntities", str_ServiceInput);
        }

        private void lb_ApplicationLogEnvironment2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            var psi = new ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            };
            Process.Start(psi);

        }

        private void lb_ApplicationLogEnvironment1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = e.Link.LinkData.ToString(),
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void btn_DeleteFileEnvironment1_Click(object sender, EventArgs e)
        {
            string str_PackageToDelete = dgv_EnvironmentFiles1.SelectedRows[0].Cells[0].Value.ToString();
            DialogResult result = MessageBox.Show("Are you sure you want to delete package " + str_PackageToDelete + " ?", " WARNING: DELETING AN SCE PACKAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {

                string str_FileToDeleteWithPath = dgv_EnvironmentFiles1.SelectedRows[0].Cells[3].Value.ToString();
                deleteFile(str_EnvironmentURL1, dec_Port1, str_AppKey1, str_FileRepository1, str_FileToDeleteWithPath);
                jsonArray_Files1 = getEnvironmentFiles(str_EnvironmentURL1, dec_Port1, str_AppKey1, str_FileRepository1, str_FileRepositoryPackagingPath1)["rows"].AsArray();
                assignFilesToGrid(this.dgv_EnvironmentFiles1, jsonArray_Files1);
            }
        }

        private void btn_DeleteFileEnvironment2_Click(object sender, EventArgs e)
        {
            string str_PackageToDelete = dgv_EnvironmentFiles2.SelectedRows[0].Cells[0].Value.ToString();
            DialogResult result = MessageBox.Show("Are you sure you want to delete package " + str_PackageToDelete + " ?", " WARNING: DELETING AN SCE PACKAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {

                string str_FileToDeleteWithPath = dgv_EnvironmentFiles2.SelectedRows[0].Cells[3].Value.ToString();
                deleteFile(str_EnvironmentURL2, dec_Port2, str_AppKey2, str_FileRepository2, str_FileToDeleteWithPath);
                jsonArray_Files2 = getEnvironmentFiles(str_EnvironmentURL2, dec_Port2, str_AppKey2, str_FileRepository2, str_FileRepositoryReceivingPath2)["rows"].AsArray();
                assignFilesToGrid(this.dgv_EnvironmentFiles2, jsonArray_Files2);
            }
        }

        private void btn_DownloadEnvironment1_Click(object sender, EventArgs e)
        {
            string str_DownloadedFile1 = getFile(str_EnvironmentURL1, dec_Port1, str_AppKey1, str_FileRepository1, dgv_EnvironmentFiles1.SelectedRows[0].Cells[3].Value.ToString(), dgv_EnvironmentFiles1.SelectedRows[0].Cells[0].Value.ToString());
            Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(Application.ExecutablePath));
        }

        private void btn_SaveAsExtension_Click(object sender, EventArgs e)
        {
            string str_FileName = dgv_EnvironmentFiles1.SelectedRows[0].Cells[0].Value.ToString();
            string str_DownloadedFile1 = getFile(str_EnvironmentURL1, dec_Port1, str_AppKey1, str_FileRepository1, dgv_EnvironmentFiles1.SelectedRows[0].Cells[3].Value.ToString(), str_FileName);
            CreateExtensionPopup frm_CreateExtensionPopup = new CreateExtensionPopup(str_FileName);
            frm_CreateExtensionPopup.ShowDialog();
        }

       
    }
}
