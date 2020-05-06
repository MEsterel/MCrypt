namespace MCrypt.UI
{
    partial class FileBrowserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileBrowserForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.aboutLink = new System.Windows.Forms.LinkLabel();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.btnBrowseDirectory = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "MCrypt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(92, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "File browser";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mode:";
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Items.AddRange(new object[] {
            "Auto",
            "Encrypt",
            "Decrypt"});
            this.comboBoxMode.Location = new System.Drawing.Point(41, 155);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(89, 21);
            this.comboBoxMode.TabIndex = 2;
            this.toolTip1.SetToolTip(this.comboBoxMode, "Select the crypt mode for the file you want to compute.");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "File / Folder:";
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(41, 71);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(361, 22);
            this.txtFileName.TabIndex = 0;
            this.txtFileName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtFileName_MouseDoubleClick);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(315, 150);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(87, 29);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "&Compute";
            this.toolTip1.SetToolTip(this.btnStart, "Compute the selected file.");
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // aboutLink
            // 
            this.aboutLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutLink.AutoSize = true;
            this.aboutLink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.aboutLink.LinkColor = System.Drawing.Color.RoyalBlue;
            this.aboutLink.Location = new System.Drawing.Point(390, 9);
            this.aboutLink.Name = "aboutLink";
            this.aboutLink.Size = new System.Drawing.Size(12, 13);
            this.aboutLink.TabIndex = 4;
            this.aboutLink.TabStop = true;
            this.aboutLink.Text = "?";
            this.toolTip1.SetToolTip(this.aboutLink, "About MCrypt");
            this.aboutLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aboutLink_LinkClicked);
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Image = global::MCrypt.Properties.Resources.file20;
            this.btnBrowseFile.Location = new System.Drawing.Point(41, 99);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(98, 28);
            this.btnBrowseFile.TabIndex = 1;
            this.btnBrowseFile.Text = " Browse file";
            this.btnBrowseFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowseFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnBrowseFile, "Browse a file...");
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // btnBrowseDirectory
            // 
            this.btnBrowseDirectory.Image = global::MCrypt.Properties.Resources.folder20;
            this.btnBrowseDirectory.Location = new System.Drawing.Point(145, 99);
            this.btnBrowseDirectory.Name = "btnBrowseDirectory";
            this.btnBrowseDirectory.Size = new System.Drawing.Size(117, 28);
            this.btnBrowseDirectory.TabIndex = 11;
            this.btnBrowseDirectory.Text = " Browse folder";
            this.btnBrowseDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowseDirectory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnBrowseDirectory, "Browse a folder...");
            this.btnBrowseDirectory.UseVisualStyleBackColor = true;
            this.btnBrowseDirectory.Click += new System.EventHandler(this.btnBrowseDirectory_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MCrypt.Properties.Resources.search20;
            this.pictureBox1.Location = new System.Drawing.Point(12, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // FileBrowserForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(414, 191);
            this.Controls.Add(this.btnBrowseDirectory);
            this.Controls.Add(this.aboutLink);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnBrowseFile);
            this.Controls.Add(this.comboBoxMode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(9000, 230);
            this.MinimizeBox = false;
            this.Name = "FileBrowserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MCrypt";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileBrowserUI_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileBrowserUI_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel aboutLink;
        private System.Windows.Forms.Button btnBrowseDirectory;
    }
}