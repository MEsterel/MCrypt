namespace MCrypt.UI
{
    partial class DecryptUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DecryptUI));
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.lblDecrypt = new System.Windows.Forms.Label();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMcrypt = new System.Windows.Forms.Label();
            this.aboutLink = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.rdobtnSaveIsOther = new System.Windows.Forms.RadioButton();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.ckboxDeleteOriginal = new System.Windows.Forms.CheckBox();
            this.txtSaveDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdobtnSaveIsSource = new System.Windows.Forms.RadioButton();
            this.panelMode = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.rdobtnDecryptAndSave = new System.Windows.Forms.RadioButton();
            this.rdobtnOpenTemp = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panelSave = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pbKey = new System.Windows.Forms.PictureBox();
            this.panelMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKey)).BeginInit();
            this.SuspendLayout();
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroProgressSpinner1.Location = new System.Drawing.Point(12, 272);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(23, 23);
            this.metroProgressSpinner1.Speed = 4F;
            this.metroProgressSpinner1.TabIndex = 15;
            this.metroProgressSpinner1.UseSelectable = true;
            this.metroProgressSpinner1.Value = 33;
            // 
            // lblDecrypt
            // 
            this.lblDecrypt.AutoSize = true;
            this.lblDecrypt.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDecrypt.Location = new System.Drawing.Point(94, 13);
            this.lblDecrypt.Name = "lblDecrypt";
            this.lblDecrypt.Size = new System.Drawing.Size(85, 30);
            this.lblDecrypt.TabIndex = 14;
            this.lblDecrypt.Text = "Decrypt";
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDecrypt.Location = new System.Drawing.Point(192, 272);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 6;
            this.btnDecrypt.Text = "&Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPassword.Location = new System.Drawing.Point(41, 74);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(226, 22);
            this.tbPassword.TabIndex = 0;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Password: ";
            // 
            // lblMcrypt
            // 
            this.lblMcrypt.AutoSize = true;
            this.lblMcrypt.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMcrypt.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblMcrypt.Location = new System.Drawing.Point(8, 11);
            this.lblMcrypt.Name = "lblMcrypt";
            this.lblMcrypt.Size = new System.Drawing.Size(94, 32);
            this.lblMcrypt.TabIndex = 9;
            this.lblMcrypt.Text = "MCrypt";
            // 
            // aboutLink
            // 
            this.aboutLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutLink.AutoSize = true;
            this.aboutLink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.aboutLink.LinkColor = System.Drawing.Color.RoyalBlue;
            this.aboutLink.Location = new System.Drawing.Point(255, 9);
            this.aboutLink.Name = "aboutLink";
            this.aboutLink.Size = new System.Drawing.Size(12, 13);
            this.aboutLink.TabIndex = 7;
            this.aboutLink.TabStop = true;
            this.aboutLink.Text = "?";
            this.toolTip1.SetToolTip(this.aboutLink, "About MCrypt");
            this.aboutLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aboutLink_LinkClicked);
            // 
            // rdobtnSaveIsOther
            // 
            this.rdobtnSaveIsOther.AutoSize = true;
            this.rdobtnSaveIsOther.Location = new System.Drawing.Point(29, 40);
            this.rdobtnSaveIsOther.Name = "rdobtnSaveIsOther";
            this.rdobtnSaveIsOther.Size = new System.Drawing.Size(14, 13);
            this.rdobtnSaveIsOther.TabIndex = 2;
            this.toolTip1.SetToolTip(this.rdobtnSaveIsOther, "Save file to another directory");
            this.rdobtnSaveIsOther.UseVisualStyleBackColor = true;
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseFile.Image = global::MCrypt.Properties.Resources.search20;
            this.btnBrowseFile.Location = new System.Drawing.Point(231, 35);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(24, 24);
            this.btnBrowseFile.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnBrowseFile, "Browse a file...");
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // ckboxDeleteOriginal
            // 
            this.ckboxDeleteOriginal.AutoSize = true;
            this.ckboxDeleteOriginal.Location = new System.Drawing.Point(29, 61);
            this.ckboxDeleteOriginal.Name = "ckboxDeleteOriginal";
            this.ckboxDeleteOriginal.Size = new System.Drawing.Size(121, 17);
            this.ckboxDeleteOriginal.TabIndex = 5;
            this.ckboxDeleteOriginal.Text = "Delete original file";
            this.ckboxDeleteOriginal.UseVisualStyleBackColor = true;
            // 
            // txtSaveDirectory
            // 
            this.txtSaveDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaveDirectory.Location = new System.Drawing.Point(49, 36);
            this.txtSaveDirectory.Name = "txtSaveDirectory";
            this.txtSaveDirectory.Size = new System.Drawing.Size(176, 22);
            this.txtSaveDirectory.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Save:";
            // 
            // rdobtnSaveIsSource
            // 
            this.rdobtnSaveIsSource.AutoSize = true;
            this.rdobtnSaveIsSource.Location = new System.Drawing.Point(29, 16);
            this.rdobtnSaveIsSource.Name = "rdobtnSaveIsSource";
            this.rdobtnSaveIsSource.Size = new System.Drawing.Size(208, 17);
            this.rdobtnSaveIsSource.TabIndex = 1;
            this.rdobtnSaveIsSource.TabStop = true;
            this.rdobtnSaveIsSource.Text = "Output directory = Source directory";
            this.rdobtnSaveIsSource.UseVisualStyleBackColor = true;
            this.rdobtnSaveIsSource.CheckedChanged += new System.EventHandler(this.rdobtnSaveIsSource_CheckedChanged);
            // 
            // panelMode
            // 
            this.panelMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMode.Controls.Add(this.pictureBox2);
            this.panelMode.Controls.Add(this.rdobtnDecryptAndSave);
            this.panelMode.Controls.Add(this.rdobtnOpenTemp);
            this.panelMode.Controls.Add(this.label3);
            this.panelMode.Location = new System.Drawing.Point(12, 108);
            this.panelMode.Name = "panelMode";
            this.panelMode.Size = new System.Drawing.Size(255, 53);
            this.panelMode.TabIndex = 24;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // rdobtnDecryptAndSave
            // 
            this.rdobtnDecryptAndSave.AutoSize = true;
            this.rdobtnDecryptAndSave.Location = new System.Drawing.Point(29, 35);
            this.rdobtnDecryptAndSave.Name = "rdobtnDecryptAndSave";
            this.rdobtnDecryptAndSave.Size = new System.Drawing.Size(151, 17);
            this.rdobtnDecryptAndSave.TabIndex = 0;
            this.rdobtnDecryptAndSave.TabStop = true;
            this.rdobtnDecryptAndSave.Text = "Decrypt and save the file";
            this.rdobtnDecryptAndSave.UseVisualStyleBackColor = true;
            // 
            // rdobtnOpenTemp
            // 
            this.rdobtnOpenTemp.AutoSize = true;
            this.rdobtnOpenTemp.Location = new System.Drawing.Point(29, 16);
            this.rdobtnOpenTemp.Name = "rdobtnOpenTemp";
            this.rdobtnOpenTemp.Size = new System.Drawing.Size(154, 17);
            this.rdobtnOpenTemp.TabIndex = 0;
            this.rdobtnOpenTemp.TabStop = true;
            this.rdobtnOpenTemp.Text = "Open the file temporarily";
            this.rdobtnOpenTemp.UseVisualStyleBackColor = true;
            this.rdobtnOpenTemp.CheckedChanged += new System.EventHandler(this.rdobtnOpenTemp_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Mode:";
            // 
            // panelSave
            // 
            this.panelSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSave.Controls.Add(this.pictureBox1);
            this.panelSave.Controls.Add(this.rdobtnSaveIsSource);
            this.panelSave.Controls.Add(this.ckboxDeleteOriginal);
            this.panelSave.Controls.Add(this.rdobtnSaveIsOther);
            this.panelSave.Controls.Add(this.btnBrowseFile);
            this.panelSave.Controls.Add(this.label1);
            this.panelSave.Controls.Add(this.txtSaveDirectory);
            this.panelSave.Location = new System.Drawing.Point(12, 176);
            this.panelSave.Name = "panelSave";
            this.panelSave.Size = new System.Drawing.Size(255, 77);
            this.panelSave.TabIndex = 25;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MCrypt.Properties.Resources.folder20;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblStatus.Location = new System.Drawing.Point(38, 277);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 13);
            this.lblStatus.TabIndex = 26;
            this.lblStatus.Text = "Status";
            // 
            // pbKey
            // 
            this.pbKey.Image = global::MCrypt.Properties.Resources.key20;
            this.pbKey.Location = new System.Drawing.Point(12, 58);
            this.pbKey.Name = "pbKey";
            this.pbKey.Size = new System.Drawing.Size(20, 20);
            this.pbKey.TabIndex = 11;
            this.pbKey.TabStop = false;
            // 
            // DecryptUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(279, 307);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panelSave);
            this.Controls.Add(this.panelMode);
            this.Controls.Add(this.aboutLink);
            this.Controls.Add(this.metroProgressSpinner1);
            this.Controls.Add(this.lblDecrypt);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbKey);
            this.Controls.Add(this.lblMcrypt);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DecryptUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MCrypt Decrypt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DecryptUI_FormClosing);
            this.Load += new System.EventHandler(this.DecryptUI_Load);
            this.panelMode.ResumeLayout(false);
            this.panelMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelSave.ResumeLayout(false);
            this.panelSave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.CheckBox ckboxDeleteOriginal;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.TextBox txtSaveDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdobtnSaveIsOther;
        private System.Windows.Forms.RadioButton rdobtnSaveIsSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelMode;
        private System.Windows.Forms.RadioButton rdobtnOpenTemp;
        private System.Windows.Forms.RadioButton rdobtnDecryptAndSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelSave;
        private System.Windows.Forms.Label lblStatus;
    }
}