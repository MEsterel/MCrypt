namespace MCrypt.UI
{
    partial class EncryptForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncryptForm));
            this.lblMcrypt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRePassword = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.lblEncrypt = new System.Windows.Forms.Label();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.aboutLink = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.pbKey = new System.Windows.Forms.PictureBox();
            this.saveDirectoryUC = new MCrypt.UI.SaveDirectoryUC();
            ((System.ComponentModel.ISupportInitialize)(this.pbKey)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMcrypt
            // 
            resources.ApplyResources(this.lblMcrypt, "lblMcrypt");
            this.lblMcrypt.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblMcrypt.Name = "lblMcrypt";
            this.toolTip1.SetToolTip(this.lblMcrypt, resources.GetString("lblMcrypt.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.toolTip1.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // tbPassword
            // 
            resources.ApplyResources(this.tbPassword, "tbPassword");
            this.tbPassword.Name = "tbPassword";
            this.toolTip1.SetToolTip(this.tbPassword, resources.GetString("tbPassword.ToolTip"));
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.toolTip1.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // tbRePassword
            // 
            resources.ApplyResources(this.tbRePassword, "tbRePassword");
            this.tbRePassword.Name = "tbRePassword";
            this.toolTip1.SetToolTip(this.tbRePassword, resources.GetString("tbRePassword.ToolTip"));
            this.tbRePassword.UseSystemPasswordChar = true;
            // 
            // btnEncrypt
            // 
            resources.ApplyResources(this.btnEncrypt, "btnEncrypt");
            this.btnEncrypt.Name = "btnEncrypt";
            this.toolTip1.SetToolTip(this.btnEncrypt, resources.GetString("btnEncrypt.ToolTip"));
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // lblEncrypt
            // 
            resources.ApplyResources(this.lblEncrypt, "lblEncrypt");
            this.lblEncrypt.Name = "lblEncrypt";
            this.toolTip1.SetToolTip(this.lblEncrypt, resources.GetString("lblEncrypt.ToolTip"));
            // 
            // metroProgressSpinner1
            // 
            resources.ApplyResources(this.metroProgressSpinner1, "metroProgressSpinner1");
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Speed = 4F;
            this.toolTip1.SetToolTip(this.metroProgressSpinner1, resources.GetString("metroProgressSpinner1.ToolTip"));
            this.metroProgressSpinner1.UseSelectable = true;
            this.metroProgressSpinner1.Value = 33;
            // 
            // aboutLink
            // 
            resources.ApplyResources(this.aboutLink, "aboutLink");
            this.aboutLink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.aboutLink.LinkColor = System.Drawing.Color.RoyalBlue;
            this.aboutLink.Name = "aboutLink";
            this.aboutLink.TabStop = true;
            this.toolTip1.SetToolTip(this.aboutLink, resources.GetString("aboutLink.ToolTip"));
            this.aboutLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aboutLink_LinkClicked);
            // 
            // lblStatus
            // 
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblStatus.Name = "lblStatus";
            this.toolTip1.SetToolTip(this.lblStatus, resources.GetString("lblStatus.ToolTip"));
            // 
            // pbKey
            // 
            resources.ApplyResources(this.pbKey, "pbKey");
            this.pbKey.Image = global::MCrypt.Properties.Resources.key20;
            this.pbKey.Name = "pbKey";
            this.pbKey.TabStop = false;
            this.toolTip1.SetToolTip(this.pbKey, resources.GetString("pbKey.ToolTip"));
            // 
            // saveDirectoryUC
            // 
            resources.ApplyResources(this.saveDirectoryUC, "saveDirectoryUC");
            this.saveDirectoryUC.BackColor = System.Drawing.Color.White;
            this.saveDirectoryUC.InitialDirectory = null;
            this.saveDirectoryUC.Name = "saveDirectoryUC";
            this.toolTip1.SetToolTip(this.saveDirectoryUC, resources.GetString("saveDirectoryUC.ToolTip"));
            // 
            // EncryptForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.saveDirectoryUC);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.aboutLink);
            this.Controls.Add(this.metroProgressSpinner1);
            this.Controls.Add(this.lblEncrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.tbRePassword);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbKey);
            this.Controls.Add(this.lblMcrypt);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EncryptForm";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EncryptUI_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbKey)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMcrypt;
        private System.Windows.Forms.PictureBox pbKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRePassword;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label lblEncrypt;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private System.Windows.Forms.LinkLabel aboutLink;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblStatus;
        private SaveDirectoryUC saveDirectoryUC;
    }
}