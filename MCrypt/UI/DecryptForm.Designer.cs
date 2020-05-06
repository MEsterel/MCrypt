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
            this.saveDirectoryUC = new MCrypt.UI.SaveDirectoryUC();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            this.btnDecrypt.Location = new System.Drawing.Point(184, 272);
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
            this.tbPassword.Size = new System.Drawing.Size(218, 22);
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
            this.aboutLink.Location = new System.Drawing.Point(247, 9);
            this.aboutLink.Name = "aboutLink";
            this.aboutLink.Size = new System.Drawing.Size(12, 13);
            this.aboutLink.TabIndex = 7;
            this.aboutLink.TabStop = true;
            this.aboutLink.Text = "?";
            this.toolTip1.SetToolTip(this.aboutLink, "About MCrypt");
            this.aboutLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aboutLink_LinkClicked);
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
            this.panelMode.Size = new System.Drawing.Size(247, 53);
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
            // pbKey
            // 
            this.pbKey.Image = global::MCrypt.Properties.Resources.key20;
            this.pbKey.Location = new System.Drawing.Point(12, 58);
            this.pbKey.Name = "pbKey";
            this.pbKey.Size = new System.Drawing.Size(20, 20);
            this.pbKey.TabIndex = 11;
            this.pbKey.TabStop = false;
            // 
            // saveDirectoryUC
            // 
            this.saveDirectoryUC.BackColor = System.Drawing.Color.White;
            this.saveDirectoryUC.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveDirectoryUC.InitialDirectory = null;
            this.saveDirectoryUC.Location = new System.Drawing.Point(12, 172);
            this.saveDirectoryUC.Name = "saveDirectoryUC";
            this.saveDirectoryUC.Size = new System.Drawing.Size(247, 85);
            this.saveDirectoryUC.TabIndex = 27;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblStatus.Location = new System.Drawing.Point(40, 271);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(138, 25);
            this.lblStatus.TabIndex = 28;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DecryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(271, 307);
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
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DecryptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MCrypt Decrypt";
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