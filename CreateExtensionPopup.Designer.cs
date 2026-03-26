namespace ThingWorxDeploymentUtility
{
    partial class CreateExtensionPopup
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
            tb_Version = new TextBox();
            tb_VendorName = new TextBox();
            lb_Version = new Label();
            label1 = new Label();
            btn_CreateExtension = new Button();
            btn_Cancel = new Button();
            SuspendLayout();
            // 
            // tb_Version
            // 
            tb_Version.Location = new Point(121, 8);
            tb_Version.Name = "tb_Version";
            tb_Version.Size = new Size(189, 23);
            tb_Version.TabIndex = 0;
            // 
            // tb_VendorName
            // 
            tb_VendorName.Location = new Point(121, 39);
            tb_VendorName.Name = "tb_VendorName";
            tb_VendorName.Size = new Size(189, 23);
            tb_VendorName.TabIndex = 1;
            // 
            // lb_Version
            // 
            lb_Version.AutoSize = true;
            lb_Version.Location = new Point(14, 12);
            lb_Version.Name = "lb_Version";
            lb_Version.Size = new Size(101, 15);
            lb_Version.TabIndex = 2;
            lb_Version.Text = "Extension version:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 43);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 3;
            label1.Text = "Extension vendor:";
            // 
            // btn_CreateExtension
            // 
            btn_CreateExtension.Location = new Point(15, 79);
            btn_CreateExtension.Name = "btn_CreateExtension";
            btn_CreateExtension.Size = new Size(113, 23);
            btn_CreateExtension.TabIndex = 4;
            btn_CreateExtension.Text = "Create Extension";
            btn_CreateExtension.UseVisualStyleBackColor = true;
            btn_CreateExtension.Click += btn_CreateExtension_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(235, 79);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(75, 23);
            btn_Cancel.TabIndex = 5;
            btn_Cancel.Text = "Cancel";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // CreateExtensionPopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 118);
            Controls.Add(btn_Cancel);
            Controls.Add(btn_CreateExtension);
            Controls.Add(label1);
            Controls.Add(lb_Version);
            Controls.Add(tb_VendorName);
            Controls.Add(tb_Version);
            Name = "CreateExtensionPopup";
            Text = "Create Extension";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_Version;
        private TextBox tb_VendorName;
        private Label lb_Version;
        private Label label1;
        private Button btn_CreateExtension;
        private Button btn_Cancel;
    }
}