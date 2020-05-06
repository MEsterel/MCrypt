using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

namespace MCrypt.UI
{
    public partial class SaveDirectoryUC : UserControl
    {
        public SaveDirectoryUC()
        {
            InitializeComponent();
        }

        public string InitialDirectory { get; set; }

        public bool DeleteOriginal { get { return !ckboxKeepOriginal.Checked; } }

        public bool SaveIsSource { get { return rdobtnSaveIsSource.Checked; } }

        public string OtherDirectory { get { return txtSaveDirectory.Text; } }

        public bool UserInputEnabled {
            set
            {
                rdobtnSaveIsSource.Enabled = value;
                rdobtnSaveIsOther.Enabled = value;
                ckboxKeepOriginal.Enabled = value;


                if (rdobtnSaveIsOther.Checked && value)
                {
                    txtSaveDirectory.Enabled = true;
                    btnBrowseFile.Enabled = true;
                }
                else
                {
                    txtSaveDirectory.Enabled = false;
                    btnBrowseFile.Enabled = false;
                }
            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog
            {
                EnsurePathExists = true,
                Title = "Choose save location",
                IsFolderPicker = true
            };

            if (!string.IsNullOrEmpty(InitialDirectory))
                fileDialog.InitialDirectory = InitialDirectory;

            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtSaveDirectory.Text = fileDialog.FileName;
                txtSaveDirectory.SelectionStart = txtSaveDirectory.TextLength;
            }
        }

        private void rdobtnSaveIsOther_CheckedChanged(object sender, EventArgs e)
        {
            if (rdobtnSaveIsOther.Checked && string.IsNullOrEmpty(txtSaveDirectory.Text))
            {
                txtSaveDirectory.Enabled = true;
                btnBrowseFile.Enabled = true;

                if (string.IsNullOrEmpty(txtSaveDirectory.Text))
                    btnBrowseFile_Click(sender, e);
            }
            else //(rdobtnSaveIsSource.Checked == true)
            {
                txtSaveDirectory.Enabled = false;
                btnBrowseFile.Enabled = false;
            }
        }

        internal bool ValidateOtherDirectory()
        {
            if (OtherDirectory == "") // If no path is indicated
            {
                Output.Print("No output path indicated.", Level.Warning);
                MessageBox.Show(this, "Please specify the location of the output file.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Directory.Exists(Path.GetDirectoryName(OtherDirectory))) // If output directory does not exist.
            {
                Output.Print("The specified directory does not exist.", Level.Warning);
                MessageBox.Show(this, "The specified directory does not exist.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
