using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Text.Json.Nodes;

namespace ThingWorxDeploymentUtility
{
    public partial class Settings : Form
    {
        private BindingList<string> blst_Items;
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            loadEnvironmentsList();
        }


        private void loadEnvironmentsList()
        {

            if (Properties.Settings.Default.EnvironmentList == null)
            {
                StringCollection sc = new StringCollection();
                sc.Add(getDefaultEntry());
                Properties.Settings.Default.EnvironmentList = sc;
            }

            // Wrap setting into a bindable list

            List<String> lst_Environments = Properties.Settings.Default.EnvironmentList.Cast<string>().ToList();
            blst_Items = getEnvironmentNames(lst_Environments);

            this.lst_Environments.DataSource = blst_Items;


        }

        private String getDefaultEntry()
        {

            JsonObject json_Environment = new JsonObject();
            json_Environment.Add("EnvironmentURL", "https://defaulturl");
            json_Environment.Add("Port", "8443");
            json_Environment.Add("AppKey", "xxxxx-xxxx-xxxx-xxxx");
            json_Environment.Add("FileRepository", "NoRepository");
            json_Environment.Add("FileRepositoryPath", "NoRepositoryPackagingPath");//this is the packaging path
            json_Environment.Add("FileRepositoryReceivingPath", "NoRepositoryReceivingPath");

            return json_Environment.ToJsonString();
        }

        private BindingList<string> getEnvironmentNames(List<String> environments)
        {
            int int_EnvironmentsCount = environments.Count();
            for (int i = 0; i < int_EnvironmentsCount; i++)
            {
                JsonNode environment = JsonObject.Parse(environments[i].ToString());
                // JsonObject objEnvironment = environment!.AsObject();
                environments[i] = environment["EnvironmentURL"].ToString();
            }

            return new BindingList<string>(environments);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lst_Environments_SelectedIndexChanged(object sender, EventArgs e)
        {

            String str_CurrentEnvironmentURL = this.lst_Environments.SelectedItem.ToString();

            List<String> lst_Environments = Properties.Settings.Default.EnvironmentList.Cast<string>().ToList();

            String str_CurrentEnvironment = lst_Environments.FirstOrDefault(environment =>
            {
                JsonNode json_Environment = JsonObject.Parse(environment);
                //JsonObject json_objEnvironment = json_Environment!.AsObject();
                return json_Environment["EnvironmentURL"].ToString() == str_CurrentEnvironmentURL;
            });

            JsonNode json_CurrentEnvironment = JsonObject.Parse(str_CurrentEnvironment);
            this.tb_EnvironmentURL.Text = json_CurrentEnvironment["EnvironmentURL"].ToString();
            this.nm_Port.Value = (decimal)Decimal.Parse(json_CurrentEnvironment["Port"].ToString());
            this.tb_AppKey.Text = json_CurrentEnvironment["AppKey"].ToString();
            if (json_CurrentEnvironment["FileRepository"] != null)
                this.tb_FileRepository.Text = json_CurrentEnvironment["FileRepository"].ToString();
            else
                this.tb_FileRepository.Text = "No previous file repository set.";
            if (json_CurrentEnvironment["FileRepositoryPath"] != null)
                this.tb_FileRepositoryPackagingPath.Text = json_CurrentEnvironment["FileRepositoryPath"].ToString();
            else
                this.tb_FileRepositoryPackagingPath.Text = "No previous repository packaging path set.";

            if (json_CurrentEnvironment["FileRepositoryReceivingPath"] != null)
                this.tb_FileRepositoryReceivingPath.Text = json_CurrentEnvironment["FileRepositoryReceivingPath"].ToString();
            else
                this.tb_FileRepositoryReceivingPath.Text = "No previous repository receiving path set.";
            
        }


        public static string Sanitize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            return input
                .Trim()
                // Invisible / problematic Unicode chars
                .Replace("\u00A0", " ")   // non‑breaking space
                .Replace("\u200B", "")    // zero‑width space
                .Replace("\u200C", "")
                .Replace("\u200D", "")
                .Replace("\uFEFF", "")    // BOM / zero‑width no‑break space
                                          // Normalize Unicode (fixes smart quotes, compatibility chars)
                .Normalize(NormalizationForm.FormKC);
        }


        private void btn_Save_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Are you sure you want to save the displayed environment?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {

                String str_EnvironmentURL = Sanitize(tb_EnvironmentURL.Text);
                String str_AppKey = Sanitize(tb_AppKey.Text);
                Decimal dec_Port = nm_Port.Value;
                string str_FileRepository = Sanitize(tb_FileRepository.Text);
                string str_FileRepositoryPath = Sanitize(tb_FileRepositoryPackagingPath.Text);
                string str_FileRepositoryReceivingPath = Sanitize(tb_FileRepositoryReceivingPath.Text);
                StringCollection lst_Environments = Properties.Settings.Default.EnvironmentList;
              
                JsonNode json_CurrentEnvironment = JsonNode.Parse(lst_Environments[this.lst_Environments.SelectedIndex]);
                json_CurrentEnvironment["EnvironmentURL"] = str_EnvironmentURL;
                json_CurrentEnvironment["Port"] = dec_Port;
                json_CurrentEnvironment["AppKey"] = str_AppKey;
                json_CurrentEnvironment["FileRepository"] = str_FileRepository;
                json_CurrentEnvironment["FileRepositoryPath"] = str_FileRepositoryPath;
                json_CurrentEnvironment["FileRepositoryReceivingPath"] = str_FileRepositoryReceivingPath;
                lst_Environments[this.lst_Environments.SelectedIndex] = json_CurrentEnvironment.ToJsonString();
                Properties.Settings.Default.EnvironmentList = lst_Environments;


            }
            loadEnvironmentsList();
           
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            StringCollection lst_Environments = Properties.Settings.Default.EnvironmentList;
            lst_Environments.Add(getDefaultEntry());
            Properties.Settings.Default.EnvironmentList = lst_Environments;

            loadEnvironmentsList();
            this.lst_Environments.SelectedIndex = blst_Items.Count - 1;
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Are you sure you want to DELETE environment "+ this.lst_Environments.SelectedItem.ToString()+"?",
               "Confirmation",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning
           );

            if (result == DialogResult.Yes)
            {
                StringCollection lst_Environments = Properties.Settings.Default.EnvironmentList;
                lst_Environments.RemoveAt(this.lst_Environments.SelectedIndex);
                Properties.Settings.Default.EnvironmentList = lst_Environments;
                loadEnvironmentsList();
            }
            
        }
    }
}
