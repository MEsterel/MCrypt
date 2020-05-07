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
            resources.ApplyResources(this.lblMcrypt, "lblMcrypt");
            this.lblMcrypt.ForeColor = System.Drawing.Color.White;
            this.lblMcrypt.Name = "lblMcrypt";
            // 
            // closeFolderBtn
            // 
            resources.ApplyResources(this.closeFolderBtn, "closeFolderBtn");
            this.closeFolderBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.closeFolderBtn.Image = global::MCrypt.Properties.Resources.lock64;
            this.closeFolderBtn.Name = "closeFolderBtn";
            this.closeFolderBtn.UseVisualStyleBackColor = true;
            this.closeFolderBtn.Click += new System.EventHandler(this.closeFolderBtn_Click);
            // 
            // lblDecrypt
            // 
            resources.ApplyResources(this.lblDecrypt, "lblDecrypt");
            this.lblDecrypt.ForeColor = System.Drawing.Color.White;
            this.lblDecrypt.Name = "lblDecrypt";
            // 
            // accessFolderlnk
            // 
            resources.ApplyResources(this.accessFolderlnk, "accessFolderlnk");
            this.accessFolderlnk.LinkColor = System.Drawing.Color.White;
            this.accessFolderlnk.Name = "accessFolderlnk";
            this.accessFolderlnk.TabStop = true;
            this.accessFolderlnk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.accessFolderlnk_LinkClicked);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // FolderTempOpenForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accessFolderlnk);
            this.Controls.Add(this.lblDecrypt);
            this.Controls.Add(this.closeFolderBtn);
            this.Controls.Add(this.lblMcrypt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FolderTempOpenForm";
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