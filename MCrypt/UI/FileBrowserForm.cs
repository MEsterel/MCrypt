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
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Runtime.Remoting.Contexts;
using MCrypt.Cryptography;
using System.Threading;
using System.Globalization;
using MCrypt.Resources;

namespace MCrypt.UI
{
    public partial class FileBrowserForm : Form
    {
        public string Path { get; set; }
        public CryptMode Mode { get; set; }

        public FileBrowserForm()
        {
            if (Thread.CurrentThread.CurrentCulture.Name.Contains("fr"))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");
                Output.Print("- Set UI culture to: fr");
            }

            InitializeComponent();
            

            comboBoxMode.SelectedIndex = 0;
            AcceptButton = btnStart;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text == "")
            {
                MessageBox.Show(this, lang.PleaseSelectFile, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Save path
            Path = txtFileName.Text;

            // Check if path valid
            try
            {
                Files.IsFileNameValid(Path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // If object does not exist
            if (!File.Exists(Path) && !Directory.Exists(Path))
            {
                MessageBox.Show(this, lang.SpecifiedObjectNotFound, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // If decrypt directory => ERROR
            if (Files.IsPathDirectory(Path) && comboBoxMode.SelectedItem.ToString() == lang.Decrypt)
            {
                MessageBox.Show(this, lang.SpecifiedObjectNotFound, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Save mode
            if (comboBoxMode.SelectedIndex == 1)
            {
                Mode = CryptMode.Encrypt;
            }
            else if (comboBoxMode.SelectedIndex == 2)
            {
                Mode = CryptMode.Decrypt;
            }
            else
            {
                Mode = Files.GetCryptModeByExt(Path);
            }

            // By closing, Program.cs will run the end of the program.
            this.Close();
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog
            {
                EnsureFileExists = true,
                EnsurePathExists = true,
                Multiselect = false,
                Title = lang.ChooseFileToOpen
            };
            fileDialog.Filters.Add(new CommonFileDialogFilter(lang.AllFiles, "*.*"));
            //fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtFileName.Text = fileDialog.FileName;
                txtFileName.SelectionStart = txtFileName.TextLength;
            }

            btnStart_Click(sender, e);
        }

        private void btnBrowseDirectory_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog
            {
                Title = lang.ChooseFolderToEncrypt,
                IsFolderPicker = true,
                EnsurePathExists = true
            };
            //fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtFileName.Text = fileDialog.FileName;
                txtFileName.SelectionStart = txtFileName.TextLength;
            }

            btnStart_Click(sender, e);
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
                MessageBox.Show(this, lang.PleaseOnlyDropOneFile, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            AboutForm aboutUi = new AboutForm();
            aboutUi.ShowDialog(this);
        }
    }
}
