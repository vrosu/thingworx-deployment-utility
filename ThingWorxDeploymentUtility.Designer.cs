namespace ThingWorxDeploymentUtility
{
    partial class DeploymentUtility
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            btn_Settings = new Button();
            cb_Environment1 = new ComboBox();
            lb_Environment1 = new Label();
            lb_Env1ProjectList = new Label();
            cb_Projects1 = new ComboBox();
            dgv_EnvironmentFiles1 = new DataGridView();
            FileName = new DataGridViewTextBoxColumn();
            LastModifiedTimestamp = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            FilePath = new DataGridViewTextBoxColumn();
            lb_Environment1Files = new Label();
            btn_GeneratePackageEnvironment1 = new Button();
            lb_Environment2 = new Label();
            cb_Environment2 = new ComboBox();
            panel1 = new Panel();
            btn_SaveAsExtension = new Button();
            btn_DownloadEnvironment1 = new Button();
            btn_DeleteFileEnvironment1 = new Button();
            lb_ApplicationLogEnvironment1 = new LinkLabel();
            btn_CompareSelectedArchives = new Button();
            panel2 = new Panel();
            btn_ImportSCEPackage = new Button();
            btn_DeleteFileEnvironment2 = new Button();
            lb_ApplicationLogEnvironment2 = new LinkLabel();
            lb_Environment2Files = new Label();
            dgv_EnvironmentFiles2 = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            btn_TransferFile = new Button();
            tooltip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dgv_EnvironmentFiles1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_EnvironmentFiles2).BeginInit();
            SuspendLayout();
            // 
            // btn_Settings
            // 
            btn_Settings.Location = new Point(906, 12);
            btn_Settings.Name = "btn_Settings";
            btn_Settings.Size = new Size(75, 23);
            btn_Settings.TabIndex = 0;
            btn_Settings.Text = "Settings";
            btn_Settings.UseVisualStyleBackColor = true;
            btn_Settings.Click += btn_Settings_Click;
            // 
            // cb_Environment1
            // 
            cb_Environment1.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Environment1.FormattingEnabled = true;
            cb_Environment1.Location = new Point(13, 31);
            cb_Environment1.Name = "cb_Environment1";
            cb_Environment1.Size = new Size(202, 23);
            cb_Environment1.TabIndex = 1;
            cb_Environment1.SelectedIndexChanged += cb_Environment1_SelectedIndexChanged;
            // 
            // lb_Environment1
            // 
            lb_Environment1.AutoSize = true;
            lb_Environment1.Location = new Point(13, 13);
            lb_Environment1.Name = "lb_Environment1";
            lb_Environment1.Size = new Size(121, 15);
            lb_Environment1.TabIndex = 2;
            lb_Environment1.Text = "Select environment 1:";
            // 
            // lb_Env1ProjectList
            // 
            lb_Env1ProjectList.AutoSize = true;
            lb_Env1ProjectList.Location = new Point(13, 79);
            lb_Env1ProjectList.Name = "lb_Env1ProjectList";
            lb_Env1ProjectList.Size = new Size(143, 15);
            lb_Env1ProjectList.TabIndex = 3;
            lb_Env1ProjectList.Text = "Environment 1 - Projects::";
            // 
            // cb_Projects1
            // 
            cb_Projects1.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Projects1.FormattingEnabled = true;
            cb_Projects1.Location = new Point(13, 97);
            cb_Projects1.Name = "cb_Projects1";
            cb_Projects1.Size = new Size(202, 23);
            cb_Projects1.TabIndex = 5;
            // 
            // dgv_EnvironmentFiles1
            // 
            dgv_EnvironmentFiles1.AllowUserToAddRows = false;
            dgv_EnvironmentFiles1.AllowUserToDeleteRows = false;
            dgv_EnvironmentFiles1.AllowUserToOrderColumns = true;
            dgv_EnvironmentFiles1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_EnvironmentFiles1.Columns.AddRange(new DataGridViewColumn[] { FileName, LastModifiedTimestamp, Size, FilePath });
            dgv_EnvironmentFiles1.Location = new Point(13, 149);
            dgv_EnvironmentFiles1.Margin = new Padding(3, 2, 3, 2);
            dgv_EnvironmentFiles1.Name = "dgv_EnvironmentFiles1";
            dgv_EnvironmentFiles1.ReadOnly = true;
            dgv_EnvironmentFiles1.RowHeadersVisible = false;
            dgv_EnvironmentFiles1.RowHeadersWidth = 51;
            dgv_EnvironmentFiles1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_EnvironmentFiles1.Size = new Size(445, 254);
            dgv_EnvironmentFiles1.TabIndex = 6;
            // 
            // FileName
            // 
            FileName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            FileName.DefaultCellStyle = dataGridViewCellStyle7;
            FileName.HeaderText = "File name:";
            FileName.MinimumWidth = 6;
            FileName.Name = "FileName";
            FileName.ReadOnly = true;
            // 
            // LastModifiedTimestamp
            // 
            dataGridViewCellStyle8.Format = "dd-MM-yyyy HH:mm:ss";
            dataGridViewCellStyle8.NullValue = null;
            LastModifiedTimestamp.DefaultCellStyle = dataGridViewCellStyle8;
            LastModifiedTimestamp.HeaderText = "Last modified:";
            LastModifiedTimestamp.MinimumWidth = 6;
            LastModifiedTimestamp.Name = "LastModifiedTimestamp";
            LastModifiedTimestamp.ReadOnly = true;
            LastModifiedTimestamp.Width = 125;
            // 
            // Size
            // 
            Size.HeaderText = "Size:";
            Size.MinimumWidth = 6;
            Size.Name = "Size";
            Size.ReadOnly = true;
            Size.Width = 125;
            // 
            // FilePath
            // 
            FilePath.HeaderText = "File Path";
            FilePath.MinimumWidth = 6;
            FilePath.Name = "FilePath";
            FilePath.ReadOnly = true;
            FilePath.Visible = false;
            FilePath.Width = 125;
            // 
            // lb_Environment1Files
            // 
            lb_Environment1Files.AutoSize = true;
            lb_Environment1Files.Location = new Point(13, 132);
            lb_Environment1Files.Name = "lb_Environment1Files";
            lb_Environment1Files.Size = new Size(212, 15);
            lb_Environment1Files.TabIndex = 8;
            lb_Environment1Files.Text = "Environment 1 - SCE Packaging Folder:";
            // 
            // btn_GeneratePackageEnvironment1
            // 
            btn_GeneratePackageEnvironment1.Location = new Point(219, 407);
            btn_GeneratePackageEnvironment1.Margin = new Padding(3, 2, 3, 2);
            btn_GeneratePackageEnvironment1.Name = "btn_GeneratePackageEnvironment1";
            btn_GeneratePackageEnvironment1.Size = new Size(239, 40);
            btn_GeneratePackageEnvironment1.TabIndex = 9;
            btn_GeneratePackageEnvironment1.Text = "1. Generate SCE Package in Environment 1";
            btn_GeneratePackageEnvironment1.UseVisualStyleBackColor = true;
            btn_GeneratePackageEnvironment1.Click += btn_GeneratePackageEnvironment1_Click;
            // 
            // lb_Environment2
            // 
            lb_Environment2.AutoSize = true;
            lb_Environment2.Location = new Point(13, 13);
            lb_Environment2.Name = "lb_Environment2";
            lb_Environment2.Size = new Size(121, 15);
            lb_Environment2.TabIndex = 11;
            lb_Environment2.Text = "Select environment 2:";
            // 
            // cb_Environment2
            // 
            cb_Environment2.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Environment2.FormattingEnabled = true;
            cb_Environment2.Location = new Point(13, 31);
            cb_Environment2.Name = "cb_Environment2";
            cb_Environment2.Size = new Size(202, 23);
            cb_Environment2.TabIndex = 10;
            cb_Environment2.SelectedIndexChanged += cb_Environment2_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(192, 255, 192);
            panel1.Controls.Add(btn_SaveAsExtension);
            panel1.Controls.Add(btn_DownloadEnvironment1);
            panel1.Controls.Add(btn_DeleteFileEnvironment1);
            panel1.Controls.Add(lb_ApplicationLogEnvironment1);
            panel1.Controls.Add(btn_CompareSelectedArchives);
            panel1.Controls.Add(lb_Environment1);
            panel1.Controls.Add(cb_Environment1);
            panel1.Controls.Add(lb_Env1ProjectList);
            panel1.Controls.Add(btn_GeneratePackageEnvironment1);
            panel1.Controls.Add(lb_Environment1Files);
            panel1.Controls.Add(cb_Projects1);
            panel1.Controls.Add(dgv_EnvironmentFiles1);
            panel1.Location = new Point(13, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(476, 454);
            panel1.TabIndex = 12;
            // 
            // btn_SaveAsExtension
            // 
            btn_SaveAsExtension.BackgroundImage = Properties.Resources.SaveAsExtension_Transparent;
            btn_SaveAsExtension.BackgroundImageLayout = ImageLayout.Stretch;
            btn_SaveAsExtension.Location = new Point(341, 112);
            btn_SaveAsExtension.Name = "btn_SaveAsExtension";
            btn_SaveAsExtension.Size = new Size(35, 35);
            btn_SaveAsExtension.TabIndex = 18;
            tooltip.SetToolTip(btn_SaveAsExtension, "Save locally as Extension");
            btn_SaveAsExtension.UseVisualStyleBackColor = true;
            btn_SaveAsExtension.Click += btn_SaveAsExtension_Click;
            // 
            // btn_DownloadEnvironment1
            // 
            btn_DownloadEnvironment1.BackgroundImage = Properties.Resources.DownloadIcon;
            btn_DownloadEnvironment1.BackgroundImageLayout = ImageLayout.Stretch;
            btn_DownloadEnvironment1.Location = new Point(382, 112);
            btn_DownloadEnvironment1.Name = "btn_DownloadEnvironment1";
            btn_DownloadEnvironment1.Size = new Size(35, 35);
            btn_DownloadEnvironment1.TabIndex = 17;
            tooltip.SetToolTip(btn_DownloadEnvironment1, "Save locally only SCE");
            btn_DownloadEnvironment1.UseVisualStyleBackColor = true;
            btn_DownloadEnvironment1.Click += btn_DownloadEnvironment1_Click;
            // 
            // btn_DeleteFileEnvironment1
            // 
            btn_DeleteFileEnvironment1.BackgroundImage = Properties.Resources.DeleteIcon;
            btn_DeleteFileEnvironment1.BackgroundImageLayout = ImageLayout.Stretch;
            btn_DeleteFileEnvironment1.Location = new Point(423, 112);
            btn_DeleteFileEnvironment1.Name = "btn_DeleteFileEnvironment1";
            btn_DeleteFileEnvironment1.Size = new Size(35, 35);
            btn_DeleteFileEnvironment1.TabIndex = 16;
            tooltip.SetToolTip(btn_DeleteFileEnvironment1, "Delete the selected file from environment 1");
            btn_DeleteFileEnvironment1.UseVisualStyleBackColor = true;
            btn_DeleteFileEnvironment1.Click += btn_DeleteFileEnvironment1_Click;
            // 
            // lb_ApplicationLogEnvironment1
            // 
            lb_ApplicationLogEnvironment1.AutoSize = true;
            lb_ApplicationLogEnvironment1.Location = new Point(361, 33);
            lb_ApplicationLogEnvironment1.Name = "lb_ApplicationLogEnvironment1";
            lb_ApplicationLogEnvironment1.Size = new Size(88, 15);
            lb_ApplicationLogEnvironment1.TabIndex = 15;
            lb_ApplicationLogEnvironment1.TabStop = true;
            lb_ApplicationLogEnvironment1.Text = "ApplicationLog";
            lb_ApplicationLogEnvironment1.LinkClicked += lb_ApplicationLogEnvironment1_LinkClicked;
            // 
            // btn_CompareSelectedArchives
            // 
            btn_CompareSelectedArchives.Location = new Point(13, 407);
            btn_CompareSelectedArchives.Margin = new Padding(3, 2, 3, 2);
            btn_CompareSelectedArchives.Name = "btn_CompareSelectedArchives";
            btn_CompareSelectedArchives.Size = new Size(187, 40);
            btn_CompareSelectedArchives.TabIndex = 14;
            btn_CompareSelectedArchives.Text = "Display selected SCE Package differences";
            btn_CompareSelectedArchives.UseVisualStyleBackColor = true;
            btn_CompareSelectedArchives.Click += btn_CompareSelectedArchives_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 255, 192);
            panel2.Controls.Add(btn_ImportSCEPackage);
            panel2.Controls.Add(btn_DeleteFileEnvironment2);
            panel2.Controls.Add(lb_ApplicationLogEnvironment2);
            panel2.Controls.Add(lb_Environment2Files);
            panel2.Controls.Add(dgv_EnvironmentFiles2);
            panel2.Controls.Add(cb_Environment2);
            panel2.Controls.Add(lb_Environment2);
            panel2.Location = new Point(505, 43);
            panel2.Name = "panel2";
            panel2.Size = new Size(476, 454);
            panel2.TabIndex = 13;
            // 
            // btn_ImportSCEPackage
            // 
            btn_ImportSCEPackage.Location = new Point(13, 407);
            btn_ImportSCEPackage.Margin = new Padding(3, 2, 3, 2);
            btn_ImportSCEPackage.Name = "btn_ImportSCEPackage";
            btn_ImportSCEPackage.Size = new Size(239, 40);
            btn_ImportSCEPackage.TabIndex = 14;
            btn_ImportSCEPackage.Text = "3. Import selected SCE Package in Environment 2";
            btn_ImportSCEPackage.UseVisualStyleBackColor = true;
            btn_ImportSCEPackage.Click += btn_ImportSCEPackage_Click;
            // 
            // btn_DeleteFileEnvironment2
            // 
            btn_DeleteFileEnvironment2.BackgroundImage = Properties.Resources.DeleteIcon;
            btn_DeleteFileEnvironment2.BackgroundImageLayout = ImageLayout.Stretch;
            btn_DeleteFileEnvironment2.Location = new Point(423, 109);
            btn_DeleteFileEnvironment2.Name = "btn_DeleteFileEnvironment2";
            btn_DeleteFileEnvironment2.Size = new Size(35, 35);
            btn_DeleteFileEnvironment2.TabIndex = 17;
            tooltip.SetToolTip(btn_DeleteFileEnvironment2, "Delete the selected file from environment 2");
            btn_DeleteFileEnvironment2.UseVisualStyleBackColor = true;
            btn_DeleteFileEnvironment2.Click += btn_DeleteFileEnvironment2_Click;
            // 
            // lb_ApplicationLogEnvironment2
            // 
            lb_ApplicationLogEnvironment2.AutoSize = true;
            lb_ApplicationLogEnvironment2.Location = new Point(361, 33);
            lb_ApplicationLogEnvironment2.Name = "lb_ApplicationLogEnvironment2";
            lb_ApplicationLogEnvironment2.Size = new Size(88, 15);
            lb_ApplicationLogEnvironment2.TabIndex = 16;
            lb_ApplicationLogEnvironment2.TabStop = true;
            lb_ApplicationLogEnvironment2.Text = "ApplicationLog";
            lb_ApplicationLogEnvironment2.LinkClicked += lb_ApplicationLogEnvironment2_LinkClicked;
            // 
            // lb_Environment2Files
            // 
            lb_Environment2Files.AutoSize = true;
            lb_Environment2Files.Location = new Point(13, 132);
            lb_Environment2Files.Name = "lb_Environment2Files";
            lb_Environment2Files.Size = new Size(208, 15);
            lb_Environment2Files.TabIndex = 10;
            lb_Environment2Files.Text = "Environment 2 - SCE Receiving Folder:";
            // 
            // dgv_EnvironmentFiles2
            // 
            dgv_EnvironmentFiles2.AllowUserToAddRows = false;
            dgv_EnvironmentFiles2.AllowUserToDeleteRows = false;
            dgv_EnvironmentFiles2.AllowUserToOrderColumns = true;
            dgv_EnvironmentFiles2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_EnvironmentFiles2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dgv_EnvironmentFiles2.Location = new Point(13, 149);
            dgv_EnvironmentFiles2.Margin = new Padding(3, 2, 3, 2);
            dgv_EnvironmentFiles2.MultiSelect = false;
            dgv_EnvironmentFiles2.Name = "dgv_EnvironmentFiles2";
            dgv_EnvironmentFiles2.ReadOnly = true;
            dgv_EnvironmentFiles2.RowHeadersVisible = false;
            dgv_EnvironmentFiles2.RowHeadersWidth = 51;
            dgv_EnvironmentFiles2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_EnvironmentFiles2.Size = new Size(445, 254);
            dgv_EnvironmentFiles2.TabIndex = 12;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewTextBoxColumn1.HeaderText = "File name:";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Last modified:";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Size:";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "File Path";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Visible = false;
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // btn_TransferFile
            // 
            btn_TransferFile.Location = new Point(374, 502);
            btn_TransferFile.Margin = new Padding(3, 2, 3, 2);
            btn_TransferFile.Name = "btn_TransferFile";
            btn_TransferFile.Size = new Size(239, 40);
            btn_TransferFile.TabIndex = 10;
            btn_TransferFile.Text = "2. Copy SCE Package to Environment 2";
            btn_TransferFile.UseVisualStyleBackColor = true;
            btn_TransferFile.Click += btn_TransferFile_Click;
            // 
            // tooltip
            // 
            tooltip.AutoPopDelay = 5000;
            tooltip.InitialDelay = 100;
            tooltip.ReshowDelay = 100;
            tooltip.ToolTipTitle = "Action:";
            // 
            // DeploymentUtility
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(995, 553);
            Controls.Add(btn_TransferFile);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btn_Settings);
            Name = "DeploymentUtility";
            Text = "ThingWorx Deployment Utility";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_EnvironmentFiles1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_EnvironmentFiles2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Settings;
        private ComboBox cb_Environment1;
        private Label lb_Environment1;
        private Label lb_Env1ProjectList;
        private ComboBox cb_Projects1;
        private DataGridView dgv_EnvironmentFiles1;
        private Label lb_Environment1Files;
        private Button btn_GeneratePackageEnvironment1;
        private DataGridViewTextBoxColumn FileName;
        private DataGridViewTextBoxColumn LastModifiedTimestamp;
        private DataGridViewTextBoxColumn Size;
        private DataGridViewTextBoxColumn FilePath;
        private Label lb_Environment2;
        private ComboBox cb_Environment2;
        private Panel panel1;
        private Panel panel2;
        private Label lb_Environment2Files;
        private DataGridView dgv_EnvironmentFiles2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Button btn_TransferFile;
        private Button btn_CompareSelectedArchives;
        private Button btn_ImportSCEPackage;
        private LinkLabel lb_ApplicationLogEnvironment1;
        private LinkLabel lb_ApplicationLogEnvironment2;
        private Button btn_DeleteFileEnvironment1;
        private Button btn_DeleteFileEnvironment2;
        private Button btn_DownloadEnvironment1;
        private Button btn_SaveAsExtension;
        private ToolTip tooltip;
    }
}
