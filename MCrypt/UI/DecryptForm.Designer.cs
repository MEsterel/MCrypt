namespace MCrypt.UI
{
    partial class DecryptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DecryptForm));
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.lblDecrypt = new System.Windows.Forms.Label();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMcrypt = new System.Windows.Forms.Label();
            this.aboutLink = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelMode = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.rdobtnDecryptAndSave = new System.Windows.Forms.RadioButton();
            this.rdobtnOpenTemp = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.pbKey = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.saveDirectoryUC = new MCrypt.UI.SaveDirectoryUC();
            this.panelMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKey)).BeginInit();
            this.SuspendLayout();
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
            // lblDecrypt
            // 
            resources.ApplyResources(this.lblDecrypt, "lblDecrypt");
            this.lblDecrypt.Name = "lblDecrypt";
            this.toolTip1.SetToolTip(this.lblDecrypt, resources.GetString("lblDecrypt.ToolTip"));
            // 
            // btnDecrypt
            // 
            resources.ApplyResources(this.btnDecrypt, "btnDecrypt");
            this.btnDecrypt.Name = "btnDecrypt";
            this.toolTip1.SetToolTip(this.btnDecrypt, resources.GetString("btnDecrypt.ToolTip"));
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // tbPassword
            // 
            resources.ApplyResources(this.tbPassword, "tbPassword");
            this.tbPassword.Name = "tbPassword";
            this.toolTip1.SetToolTip(this.tbPassword, resources.GetString("tbPassword.ToolTip"));
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.toolTip1.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // lblMcrypt
            // 
            resources.ApplyResources(this.lblMcrypt, "lblMcrypt");
            this.lblMcrypt.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblMcrypt.Name = "lblMcrypt";
            this.toolTip1.SetToolTip(this.lblMcrypt, resources.GetString("lblMcrypt.ToolTip"));
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
            // panelMode
            // 
            resources.ApplyResources(this.panelMode, "panelMode");
            this.panelMode.Controls.Add(this.pictureBox2);
            this.panelMode.Controls.Add(this.rdobtnDecryptAndSave);
            this.panelMode.Controls.Add(this.rdobtnOpenTemp);
            this.panelMode.Controls.Add(this.label3);
            this.panelMode.Name = "panelMode";
            this.toolTip1.SetToolTip(this.panelMode, resources.GetString("panelMode.ToolTip"));
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, resources.GetString("pictureBox2.ToolTip"));
            // 
            // rdobtnDecryptAndSave
            // 
            resources.ApplyResources(this.rdobtnDecryptAndSave, "rdobtnDecryptAndSave");
            this.rdobtnDecryptAndSave.Name = "rdobtnDecryptAndSave";
            this.rdobtnDecryptAndSave.TabStop = true;
            this.toolTip1.SetToolTip(this.rdobtnDecryptAndSave, resources.GetString("rdobtnDecryptAndSave.ToolTip"));
            this.rdobtnDecryptAndSave.UseVisualStyleBackColor = true;
            // 
            // rdobtnOpenTemp
            // 
            resources.ApplyResources(this.rdobtnOpenTemp, "rdobtnOpenTemp");
            this.rdobtnOpenTemp.Name = "rdobtnOpenTemp";
            this.rdobtnOpenTemp.TabStop = true;
            this.toolTip1.SetToolTip(this.rdobtnOpenTemp, resources.GetString("rdobtnOpenTemp.ToolTip"));
            this.rdobtnOpenTemp.UseVisualStyleBackColor = true;
            this.rdobtnOpenTemp.CheckedChanged += new System.EventHandler(this.rdobtnOpenTemp_CheckedChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.toolTip1.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // pbKey
            // 
            resources.ApplyResources(this.pbKey, "pbKey");
            this.pbKey.Image = global::MCrypt.Properties.Resources.key20;
            this.pbKey.Name = "pbKey";
            this.pbKey.TabStop = false;
            this.toolTip1.SetToolTip(this.pbKey, resources.GetString("pbKey.ToolTip"));
            // 
            // lblStatus
            // 
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblStatus.Name = "lblStatus";
            this.toolTip1.SetToolTip(this.lblStatus, resources.GetString("lblStatus.ToolTip"));
            // 
            // saveDirectoryUC
            // 
            resources.ApplyResources(this.saveDirectoryUC, "saveDirectoryUC");
            this.saveDirectoryUC.BackColor = System.Drawing.Color.White;
            this.saveDirectoryUC.InitialDirectory = null;
            this.saveDirectoryUC.Name = "saveDirectoryUC";
            this.toolTip1.SetToolTip(this.saveDirectoryUC, resources.GetString("saveDirectoryUC.ToolTip"));
            // 
            // DecryptForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.saveDirectoryUC);
            this.Controls.Add(this.panelMode);
            this.Controls.Add(this.aboutLink);
            this.Controls.Add(this.metroProgressSpinner1);
            this.Controls.Add(this.lblDecrypt);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbKey);
            this.Controls.Add(this.lblMcrypt);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DecryptForm";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DecryptUI_FormClosing);
            this.panelMode.ResumeLayout(false);
            this.panelMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKey)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private System.Windows.Forms.Label lblDecrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbKey;
        private System.Windows.Forms.Label lblMcrypt;
        private System.Windows.Forms.LinkLabel aboutLink;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panelMode;
        private System.Windows.Forms.RadioButton rdobtnOpenTemp;
        private System.Windows.Forms.RadioButton rdobtnDecryptAndSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private SaveDirectoryUC saveDirectoryUC;
        private System.Windows.Forms.Label lblStatus;
    }
}