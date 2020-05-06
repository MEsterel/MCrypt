namespace MCrypt.UI
{
    partial class SaveDirectoryUC
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rdobtnSaveIsSource = new System.Windows.Forms.RadioButton();
            this.ckboxKeepOriginal = new System.Windows.Forms.CheckBox();
            this.rdobtnSaveIsOther = new System.Windows.Forms.RadioButton();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSaveDirectory = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            // rdobtnSaveIsSource
            // 
            this.rdobtnSaveIsSource.AutoSize = true;
            this.rdobtnSaveIsSource.Checked = true;
            this.rdobtnSaveIsSource.Location = new System.Drawing.Point(29, 16);
            this.rdobtnSaveIsSource.Name = "rdobtnSaveIsSource";
            this.rdobtnSaveIsSource.Size = new System.Drawing.Size(208, 19);
            this.rdobtnSaveIsSource.TabIndex = 1;
            this.rdobtnSaveIsSource.TabStop = true;
            this.rdobtnSaveIsSource.Text = "Output directory = Source directory";
            this.rdobtnSaveIsSource.UseVisualStyleBackColor = true;
            // 
            // ckboxKeepOriginal
            // 
            this.ckboxKeepOriginal.AutoSize = true;
            this.ckboxKeepOriginal.Location = new System.Drawing.Point(29, 64);
            this.ckboxKeepOriginal.Name = "ckboxKeepOriginal";
            this.ckboxKeepOriginal.Size = new System.Drawing.Size(164, 19);
            this.ckboxKeepOriginal.TabIndex = 5;
            this.ckboxKeepOriginal.Text = "Keep a copy of the original";
            this.ckboxKeepOriginal.UseVisualStyleBackColor = true;
            // 
            // rdobtnSaveIsOther
            // 
            this.rdobtnSaveIsOther.AutoSize = true;
            this.rdobtnSaveIsOther.Location = new System.Drawing.Point(29, 40);
            this.rdobtnSaveIsOther.Name = "rdobtnSaveIsOther";
            this.rdobtnSaveIsOther.Size = new System.Drawing.Size(14, 13);
            this.rdobtnSaveIsOther.TabIndex = 2;
            this.rdobtnSaveIsOther.UseVisualStyleBackColor = true;
            this.rdobtnSaveIsOther.CheckedChanged += new System.EventHandler(this.rdobtnSaveIsOther_CheckedChanged);
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseFile.Image = global::MCrypt.Properties.Resources.search20;
            this.btnBrowseFile.Location = new System.Drawing.Point(235, 35);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(24, 24);
            this.btnBrowseFile.TabIndex = 4;
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "Save:";
            // 
            // txtSaveDirectory
            // 
            this.txtSaveDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaveDirectory.Location = new System.Drawing.Point(49, 36);
            this.txtSaveDirectory.Name = "txtSaveDirectory";
            this.txtSaveDirectory.Size = new System.Drawing.Size(180, 22);
            this.txtSaveDirectory.TabIndex = 3;
            // 
            // SaveDirectoryUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rdobtnSaveIsSource);
            this.Controls.Add(this.txtSaveDirectory);
            this.Controls.Add(this.ckboxKeepOriginal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdobtnSaveIsOther);
            this.Controls.Add(this.btnBrowseFile);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SaveDirectoryUC";
            this.Size = new System.Drawing.Size(262, 85);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rdobtnSaveIsSource;
        private System.Windows.Forms.CheckBox ckboxKeepOriginal;
        private System.Windows.Forms.RadioButton rdobtnSaveIsOther;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSaveDirectory;
    }
}
