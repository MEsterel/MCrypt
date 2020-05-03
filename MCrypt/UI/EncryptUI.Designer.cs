namespace MCrypt.UI
{
    partial class EncryptUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncryptUI));
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
            this.rdobtnSaveIsOther = new System.Windows.Forms.RadioButton();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.rdobtnSaveIsSource = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSaveDirectory = new System.Windows.Forms.TextBox();
            this.ckboxDeleteOriginal = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbKey = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKey)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMcrypt
            // 
            this.lblMcrypt.AutoSize = true;
            this.lblMcrypt.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMcrypt.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblMcrypt.Location = new System.Drawing.Point(8, 11);
            this.lblMcrypt.Name = "lblMcrypt";
            this.lblMcrypt.Size = new System.Drawing.Size(94, 32);
            this.lblMcrypt.TabIndex = 1;
            this.lblMcrypt.Text = "MCrypt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password: ";
            // 
            // tbPassword
            // 
            this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPassword.Location = new System.Drawing.Point(41, 74);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(218, 22);
            this.tbPassword.TabIndex = 0;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Re-enter password:";
            // 
            // tbRePassword
            // 
            this.tbRePassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRePassword.Location = new System.Drawing.Point(41, 115);
            this.tbRePassword.Name = "tbRePassword";
            this.tbRePassword.Size = new System.Drawing.Size(218, 22);
            this.tbRePassword.TabIndex = 1;
            this.tbRePassword.UseSystemPasswordChar = true;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEncrypt.Location = new System.Drawing.Point(184, 247);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 7;
            this.btnEncrypt.Text = "&Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // lblEncrypt
            // 
            this.lblEncrypt.AutoSize = true;
            this.lblEncrypt.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncrypt.Location = new System.Drawing.Point(94, 13);
            this.lblEncrypt.Name = "lblEncrypt";
            this.lblEncrypt.Size = new System.Drawing.Size(82, 30);
            this.lblEncrypt.TabIndex = 4;
            this.lblEncrypt.Text = "Encrypt";
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroProgressSpinner1.Location = new System.Drawing.Point(12, 247);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(23, 23);
            this.metroProgressSpinner1.Speed = 4F;
            this.metroProgressSpinner1.TabIndex = 5;
            this.metroProgressSpinner1.UseSelectable = true;
            this.metroProgressSpinner1.Value = 33;
            // 
            // aboutLink
            // 
            this.aboutLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutLink.AutoSize = true;
            this.aboutLink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.aboutLink.LinkColor = System.Drawing.Color.RoyalBlue;
            this.aboutLink.Location = new System.Drawing.Point(247, 9);
            this.aboutLink.Name = "aboutLink";
            this.aboutLink.Size = new System.Drawing.Size(12, 13);
            this.aboutLink.TabIndex = 8;
            this.aboutLink.TabStop = true;
            this.aboutLink.Text = "?";
            this.toolTip1.SetToolTip(this.aboutLink, "About MCrypt");
            this.aboutLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aboutLink_LinkClicked);
            // 
            // rdobtnSaveIsOther
            // 
            this.rdobtnSaveIsOther.AutoSize = true;
            this.rdobtnSaveIsOther.Location = new System.Drawing.Point(41, 191);
            this.rdobtnSaveIsOther.Name = "rdobtnSaveIsOther";
            this.rdobtnSaveIsOther.Size = new System.Drawing.Size(14, 13);
            this.rdobtnSaveIsOther.TabIndex = 3;
            this.rdobtnSaveIsOther.TabStop = true;
            this.toolTip1.SetToolTip(this.rdobtnSaveIsOther, "Save the file in another directory");
            this.rdobtnSaveIsOther.UseVisualStyleBackColor = true;
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseFile.Image = global::MCrypt.Properties.Resources.search20;
            this.btnBrowseFile.Location = new System.Drawing.Point(235, 186);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(24, 24);
            this.btnBrowseFile.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnBrowseFile, "Browse a file...");
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // rdobtnSaveIsSource
            // 
            this.rdobtnSaveIsSource.AutoSize = true;
            this.rdobtnSaveIsSource.Location = new System.Drawing.Point(41, 167);
            this.rdobtnSaveIsSource.Name = "rdobtnSaveIsSource";
            this.rdobtnSaveIsSource.Size = new System.Drawing.Size(208, 17);
            this.rdobtnSaveIsSource.TabIndex = 2;
            this.rdobtnSaveIsSource.TabStop = true;
            this.rdobtnSaveIsSource.Text = "Output directory = Source directory";
            this.rdobtnSaveIsSource.UseVisualStyleBackColor = true;
            this.rdobtnSaveIsSource.CheckedChanged += new System.EventHandler(this.rdobtnSaveIsSource_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Save:";
            // 
            // txtSaveDirectory
            // 
            this.txtSaveDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaveDirectory.Location = new System.Drawing.Point(61, 187);
            this.txtSaveDirectory.Name = "txtSaveDirectory";
            this.txtSaveDirectory.Size = new System.Drawing.Size(168, 22);
            this.txtSaveDirectory.TabIndex = 4;
            // 
            // ckboxDeleteOriginal
            // 
            this.ckboxDeleteOriginal.AutoSize = true;
            this.ckboxDeleteOriginal.Location = new System.Drawing.Point(41, 212);
            this.ckboxDeleteOriginal.Name = "ckboxDeleteOriginal";
            this.ckboxDeleteOriginal.Size = new System.Drawing.Size(121, 17);
            this.ckboxDeleteOriginal.TabIndex = 6;
            this.ckboxDeleteOriginal.Text = "Delete original file";
            this.ckboxDeleteOriginal.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblStatus.Location = new System.Drawing.Point(40, 251);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 13);
            this.lblStatus.TabIndex = 27;
            this.lblStatus.Text = "Status";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MCrypt.Properties.Resources.folder20;
            this.pictureBox1.Location = new System.Drawing.Point(12, 151);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pbKey
            // 
            this.pbKey.Image = global::MCrypt.Properties.Resources.key20;
            this.pbKey.Location = new System.Drawing.Point(12, 58);
            this.pbKey.Name = "pbKey";
            this.pbKey.Size = new System.Drawing.Size(20, 20);
            this.pbKey.TabIndex = 2;
            this.pbKey.TabStop = false;
            // 
            // EncryptUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(271, 282);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.ckboxDeleteOriginal);
            this.Controls.Add(this.btnBrowseFile);
            this.Controls.Add(this.txtSaveDirectory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdobtnSaveIsOther);
            this.Controls.Add(this.rdobtnSaveIsSource);
            this.Controls.Add(this.aboutLink);
            this.Controls.Add(this.metroProgressSpinner1);
            this.Controls.Add(this.lblEncrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.tbRePassword);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbKey);
            this.Controls.Add(this.lblMcrypt);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EncryptUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MCrypt Encrypt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EncryptUI_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.RadioButton rdobtnSaveIsSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdobtnSaveIsOther;
        private System.Windows.Forms.TextBox txtSaveDirectory;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox ckboxDeleteOriginal;
        private System.Windows.Forms.Label lblStatus;
    }
}