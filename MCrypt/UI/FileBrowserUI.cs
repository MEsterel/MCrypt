using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MCrypt.Tools;
using MCrypt.Utils;

namespace MCrypt.UI
{
    public partial class FileBrowserUI : Form
    {
        public string path;
        public CryptMode mode;

        public FileBrowserUI()
        {
            InitializeComponent();

            comboBoxMode.SelectedItem = "Auto";
            AcceptButton = btnStart;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text == "")
            {
                MessageBox.Show(this, "Please select a file to compute.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Save path
            path = txtFileName.Text;

            // Check if path valid
            try
            {
                Files.IsFileNameValid(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // If object does not exist
            if (!File.Exists(path) && !Directory.Exists(path))
            {
                MessageBox.Show(this, "The specified object does not exists.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // If decrypt directory => ERROR
            if (Files.IsPathDirectory(path) && comboBoxMode.SelectedItem.ToString() == "Decrypt")
            {
                MessageBox.Show(this, "It is impossible to decrypt a directory.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Save mode
            if (comboBoxMode.SelectedItem.ToString() == "Encrypt")
            {
                mode = CryptMode.Encrypt;
            }
            else if (comboBoxMode.SelectedItem.ToString() == "Decrypt")
            {
                mode = CryptMode.Decrypt;
            }
            else
            {
                mode = Files.GetCryptModeByExt(path);
            }

            // By closing, Program.cs will run the end of the program.
            this.Close();
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;
            fileDialog.Multiselect = false;
            fileDialog.Title = "MCrypt - Choose a file to compute";
            fileDialog.Filter = "All files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = fileDialog.FileName;
                txtFileName.SelectionStart = txtFileName.TextLength;
            }
        }

        private void btnBrowseDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Choose a folder to crypt with MCrypt.";
            fbd.ShowNewFolderButton = true;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = fbd.SelectedPath;
                txtFileName.SelectionStart = txtFileName.TextLength;
            }
        }

        private void FileBrowserUI_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void FileBrowserUI_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop); // Get selected file

            if (files.Length > 1)
            {
                MessageBox.Show(this, "Please drop only one file.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else // If one file dropped
            {
                txtFileName.Text = files[0];
                txtFileName.SelectionStart = txtFileName.TextLength;
            }
        }

        private void txtFileName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtFileName.SelectionStart = 1;
            txtFileName.SelectionLength = txtFileName.TextLength;
        }

        private void aboutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutUI aboutUi = new AboutUI();
            aboutUi.ShowDialog(this);
        }
    }
}
