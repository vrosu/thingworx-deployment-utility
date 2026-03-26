namespace ThingWorxDeploymentUtility
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lst_Environments = new ListBox();
            btn_Add = new Button();
            btn_Delete = new Button();
            btn_Save = new Button();
            tb_EnvironmentURL = new TextBox();
            tb_AppKey = new TextBox();
            nm_Port = new NumericUpDown();
            lb_EnvironmentURL = new Label();
            lb_Port = new Label();
            lb_AppKey = new Label();
            lb_FileRepository = new Label();
            tb_FileRepository = new TextBox();
            lb_FileRepositoryPackagingPath = new Label();
            tb_FileRepositoryPackagingPath = new TextBox();
            lb_FileRepositoryReceivingPath = new Label();
            tb_FileRepositoryReceivingPath = new TextBox();
            ((System.ComponentModel.ISupportInitialize)nm_Port).BeginInit();
            SuspendLayout();
            // 
            // lst_Environments
            // 
            lst_Environments.FormattingEnabled = true;
            lst_Environments.Location = new Point(14, 61);
            lst_Environments.Margin = new Padding(3, 4, 3, 4);
            lst_Environments.Name = "lst_Environments";
            lst_Environments.Size = new Size(548, 504);
            lst_Environments.TabIndex = 0;
            lst_Environments.SelectedIndexChanged += lst_Environments_SelectedIndexChanged;
            // 
            // btn_Add
            // 
            btn_Add.Location = new Point(14, 23);
            btn_Add.Margin = new Padding(3, 4, 3, 4);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(30, 31);
            btn_Add.TabIndex = 1;
            btn_Add.Text = "+";
            btn_Add.UseVisualStyleBackColor = true;
            btn_Add.Click += btn_Add_Click;
            // 
            // btn_Delete
            // 
            btn_Delete.Location = new Point(846, 23);
            btn_Delete.Margin = new Padding(3, 4, 3, 4);
            btn_Delete.Name = "btn_Delete";
            btn_Delete.Size = new Size(30, 31);
            btn_Delete.TabIndex = 2;
            btn_Delete.Text = "-";
            btn_Delete.UseVisualStyleBackColor = true;
            btn_Delete.Click += btn_Delete_Click;
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(790, 536);
            btn_Save.Margin = new Padding(3, 4, 3, 4);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(86, 31);
            btn_Save.TabIndex = 3;
            btn_Save.Text = "Save";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // tb_EnvironmentURL
            // 
            tb_EnvironmentURL.Location = new Point(584, 85);
            tb_EnvironmentURL.Margin = new Padding(3, 4, 3, 4);
            tb_EnvironmentURL.Name = "tb_EnvironmentURL";
            tb_EnvironmentURL.Size = new Size(292, 27);
            tb_EnvironmentURL.TabIndex = 4;
            // 
            // tb_AppKey
            // 
            tb_AppKey.Location = new Point(584, 226);
            tb_AppKey.Margin = new Padding(3, 4, 3, 4);
            tb_AppKey.Name = "tb_AppKey";
            tb_AppKey.Size = new Size(292, 27);
            tb_AppKey.TabIndex = 5;
            // 
            // nm_Port
            // 
            nm_Port.Location = new Point(739, 156);
            nm_Port.Margin = new Padding(3, 4, 3, 4);
            nm_Port.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nm_Port.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nm_Port.Name = "nm_Port";
            nm_Port.Size = new Size(137, 27);
            nm_Port.TabIndex = 6;
            nm_Port.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lb_EnvironmentURL
            // 
            lb_EnvironmentURL.AutoSize = true;
            lb_EnvironmentURL.Location = new Point(751, 61);
            lb_EnvironmentURL.Name = "lb_EnvironmentURL";
            lb_EnvironmentURL.Size = new Size(125, 20);
            lb_EnvironmentURL.TabIndex = 7;
            lb_EnvironmentURL.Text = "Environment URL:";
            lb_EnvironmentURL.Click += label1_Click;
            // 
            // lb_Port
            // 
            lb_Port.AutoSize = true;
            lb_Port.Location = new Point(838, 132);
            lb_Port.Name = "lb_Port";
            lb_Port.Size = new Size(38, 20);
            lb_Port.TabIndex = 8;
            lb_Port.Text = "Port:";
            // 
            // lb_AppKey
            // 
            lb_AppKey.AutoSize = true;
            lb_AppKey.Location = new Point(812, 202);
            lb_AppKey.Name = "lb_AppKey";
            lb_AppKey.Size = new Size(64, 20);
            lb_AppKey.TabIndex = 9;
            lb_AppKey.Text = "AppKey:";
            // 
            // lb_FileRepository
            // 
            lb_FileRepository.AutoSize = true;
            lb_FileRepository.Location = new Point(766, 275);
            lb_FileRepository.Name = "lb_FileRepository";
            lb_FileRepository.Size = new Size(110, 20);
            lb_FileRepository.TabIndex = 11;
            lb_FileRepository.Text = "File Repository:";
            // 
            // tb_FileRepository
            // 
            tb_FileRepository.Location = new Point(584, 299);
            tb_FileRepository.Margin = new Padding(3, 4, 3, 4);
            tb_FileRepository.Name = "tb_FileRepository";
            tb_FileRepository.Size = new Size(292, 27);
            tb_FileRepository.TabIndex = 10;
            // 
            // lb_FileRepositoryPackagingPath
            // 
            lb_FileRepositoryPackagingPath.AutoSize = true;
            lb_FileRepositoryPackagingPath.Location = new Point(690, 342);
            lb_FileRepositoryPackagingPath.Name = "lb_FileRepositoryPackagingPath";
            lb_FileRepositoryPackagingPath.Size = new Size(186, 20);
            lb_FileRepositoryPackagingPath.TabIndex = 13;
            lb_FileRepositoryPackagingPath.Text = "Repository Packaging Path:";
            // 
            // tb_FileRepositoryPackagingPath
            // 
            tb_FileRepositoryPackagingPath.Location = new Point(584, 366);
            tb_FileRepositoryPackagingPath.Margin = new Padding(3, 4, 3, 4);
            tb_FileRepositoryPackagingPath.Name = "tb_FileRepositoryPackagingPath";
            tb_FileRepositoryPackagingPath.Size = new Size(292, 27);
            tb_FileRepositoryPackagingPath.TabIndex = 12;
            // 
            // lb_FileRepositoryReceivingPath
            // 
            lb_FileRepositoryReceivingPath.AutoSize = true;
            lb_FileRepositoryReceivingPath.Location = new Point(690, 411);
            lb_FileRepositoryReceivingPath.Name = "lb_FileRepositoryReceivingPath";
            lb_FileRepositoryReceivingPath.Size = new Size(183, 20);
            lb_FileRepositoryReceivingPath.TabIndex = 15;
            lb_FileRepositoryReceivingPath.Text = "Repository Receiving Path:";
            // 
            // tb_FileRepositoryReceivingPath
            // 
            tb_FileRepositoryReceivingPath.Location = new Point(584, 435);
            tb_FileRepositoryReceivingPath.Margin = new Padding(3, 4, 3, 4);
            tb_FileRepositoryReceivingPath.Name = "tb_FileRepositoryReceivingPath";
            tb_FileRepositoryReceivingPath.Size = new Size(292, 27);
            tb_FileRepositoryReceivingPath.TabIndex = 14;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 597);
            Controls.Add(lb_FileRepositoryReceivingPath);
            Controls.Add(tb_FileRepositoryReceivingPath);
            Controls.Add(lb_FileRepositoryPackagingPath);
            Controls.Add(tb_FileRepositoryPackagingPath);
            Controls.Add(lb_FileRepository);
            Controls.Add(tb_FileRepository);
            Controls.Add(lb_AppKey);
            Controls.Add(lb_Port);
            Controls.Add(lb_EnvironmentURL);
            Controls.Add(nm_Port);
            Controls.Add(tb_AppKey);
            Controls.Add(tb_EnvironmentURL);
            Controls.Add(btn_Save);
            Controls.Add(btn_Delete);
            Controls.Add(btn_Add);
            Controls.Add(lst_Environments);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Settings";
            Text = "Settings";
            FormClosed += Settings_FormClosed;
            Load += Settings_Load;
            ((System.ComponentModel.ISupportInitialize)nm_Port).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lst_Environments;
        private Button btn_Add;
        private Button btn_Delete;
        private Button btn_Save;
        private TextBox tb_EnvironmentURL;
        private TextBox tb_AppKey;
        private NumericUpDown nm_Port;
        private Label lb_EnvironmentURL;
        private Label lb_Port;
        private Label lb_AppKey;
        private Label lb_FileRepository;
        private TextBox tb_FileRepository;
        private Label lb_FileRepositoryPackagingPath;
        private TextBox tb_FileRepositoryPackagingPath;
        private Label lb_FileRepositoryReceivingPath;
        private TextBox tb_FileRepositoryReceivingPath;
    }
}