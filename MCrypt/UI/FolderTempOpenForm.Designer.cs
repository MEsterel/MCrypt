namespace MCrypt.UI
{
    partial class FolderTempOpenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderTempOpenForm));
            this.lblMcrypt = new System.Windows.Forms.Label();
            this.closeFolderBtn = new System.Windows.Forms.Button();
            this.lblDecrypt = new System.Windows.Forms.Label();
            this.accessFolderlnk = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMcrypt
            // 
            this.lblMcrypt.AutoSize = true;
            this.lblMcrypt.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMcrypt.ForeColor = System.Drawing.Color.White;
            this.lblMcrypt.Location = new System.Drawing.Point(8, 11);
            this.lblMcrypt.Name = "lblMcrypt";
            this.lblMcrypt.Size = new System.Drawing.Size(94, 32);
            this.lblMcrypt.TabIndex = 10;
            this.lblMcrypt.Text = "MCrypt";
            // 
            // closeFolderBtn
            // 
            this.closeFolderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.closeFolderBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeFolderBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.closeFolderBtn.Image = global::MCrypt.Properties.Resources.lock64;
            this.closeFolderBtn.Location = new System.Drawing.Point(12, 98);
            this.closeFolderBtn.Name = "closeFolderBtn";
            this.closeFolderBtn.Size = new System.Drawing.Size(378, 81);
            this.closeFolderBtn.TabIndex = 0;
            this.closeFolderBtn.Text = " Close the folder";
            this.closeFolderBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeFolderBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.closeFolderBtn.UseVisualStyleBackColor = true;
            this.closeFolderBtn.Click += new System.EventHandler(this.closeFolderBtn_Click);
            // 
            // lblDecrypt
            // 
            this.lblDecrypt.AutoSize = true;
            this.lblDecrypt.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDecrypt.ForeColor = System.Drawing.Color.White;
            this.lblDecrypt.Location = new System.Drawing.Point(94, 13);
            this.lblDecrypt.Name = "lblDecrypt";
            this.lblDecrypt.Size = new System.Drawing.Size(257, 30);
            this.lblDecrypt.TabIndex = 15;
            this.lblDecrypt.Text = "Folder temporarily opened";
            // 
            // accessFolderlnk
            // 
            this.accessFolderlnk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.accessFolderlnk.AutoSize = true;
            this.accessFolderlnk.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accessFolderlnk.LinkColor = System.Drawing.Color.White;
            this.accessFolderlnk.Location = new System.Drawing.Point(138, 53);
            this.accessFolderlnk.Name = "accessFolderlnk";
            this.accessFolderlnk.Size = new System.Drawing.Size(127, 21);
            this.accessFolderlnk.TabIndex = 1;
            this.accessFolderlnk.TabStop = true;
            this.accessFolderlnk.Text = "Access the folder";
            this.accessFolderlnk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.accessFolderlnk_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(191, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 21);
            this.label1.TabIndex = 17;
            this.label1.Text = "or";
            // 
            // FolderTempOpenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(402, 192);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accessFolderlnk);
            this.Controls.Add(this.lblDecrypt);
            this.Controls.Add(this.closeFolderBtn);
            this.Controls.Add(this.lblMcrypt);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FolderTempOpenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MCrypt Temporary Folder Opened";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMcrypt;
        private System.Windows.Forms.Button closeFolderBtn;
        private System.Windows.Forms.Label lblDecrypt;
        private System.Windows.Forms.LinkLabel accessFolderlnk;
        private System.Windows.Forms.Label label1;
    }
}