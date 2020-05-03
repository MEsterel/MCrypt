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
using MCrypt.Exceptions;
using MCrypt.Tools;
using MCrypt.Cryptography;

namespace MCrypt.UI
{
    public partial class DecryptUI : Form
    {
        /// <summary>
        /// Input file path.
        /// </summary>
        private string inputFilePath;

        /// <summary>
        /// Input file extension.
        /// </summary>
        private string inputFileExtension;

        /// <summary>
        /// Output file path.
        /// </summary>
        private string outputFilePath;

        /// <summary>
        /// Password.
        /// </summary>
        private string password;

        /// <summary>
        /// Indicates if the UI allows the user to close the window.
        /// </summary>
        private bool cancelClose = false;

        /// <summary>
        /// Decrypt file with password.
        /// </summary>
        /// <param name="path">Path of the file to decrypt.</param>
        /// <param name="mouseStartLocation">True: start location at mouse position. False: start location at center screen.</param>
        public DecryptUI(string path, bool mouseStartLocation = true)
        {
            InitializeComponent();
            UIReady();

            if (mouseStartLocation == true)
                this.Location = new Point(MousePosition.X, MousePosition.Y);
            else
                this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            this.AcceptButton = btnDecrypt;
            this.inputFilePath = path;
            this.inputFileExtension = Path.GetExtension(Path.GetFileNameWithoutExtension(inputFilePath));
            rdobtnSaveIsSource.Checked = true;
            rdobtnOpenTemp.Checked = true;
            lblStatus.Text = "";
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {

            // Check password
            if (tbPassword.Text == "")
            {
                MessageBox.Show(this, "Please enter your password.", this.Text + " - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check input file path for the last time
            if (!File.Exists(inputFilePath))
            {
                MessageBox.Show(this, "Original file has been moved or deleted before decryption.", this.Text + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            // Set last values
            password = tbPassword.Text;

            //Run threw parameters
            if (rdobtnDecryptAndSave.Checked)
            {
                //// DECRYPT AND SAVE /////////////////////////////////////////////////
                if (rdobtnSaveIsSource.Checked)
                {
                    outputFilePath = Path.GetDirectoryName(inputFilePath) + "\\" + Path.GetFileNameWithoutExtension(inputFilePath);

                    // Check output file path
                    if (File.Exists(outputFilePath))
                    {
                        if (MessageBox.Show(this,
                            "A file named \"" + Path.GetFileName(outputFilePath) + "\" already exists. Do you want to replace it?",
                            this.Text + " - Warning",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            File.Delete(outputFilePath);
                        else
                            return;
                    }
                }
                else
                {
                    if (txtSaveDirectory.Text == "")
                    {
                        MessageBox.Show(this, "Please specify the location of the output file.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!Directory.Exists(Path.GetDirectoryName(txtSaveDirectory.Text)))
                    {
                        MessageBox.Show(this, "The specified directory does not exist.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    outputFilePath = txtSaveDirectory.Text;

                    if (File.Exists(outputFilePath))
                    {
                        File.Delete(outputFilePath);
                    }
                }

                // Set backgorund worker
                BackgroundWorker bwSave = new BackgroundWorker();
                bwSave.RunWorkerCompleted += bwSave_RunWorkerCompleted;
                bwSave.DoWork += bwSave_DoWork;

                // Decrypt !
                UIWorking();
                lblStatus.Text = "Decrypting the file";
                bwSave.RunWorkerAsync(new CryptArgs(inputFilePath, outputFilePath, password));
            }
            else
            {
                //// OPEN TEMPORARILY /////////////////////////////////////////////////////////////////////////
                UIWorking();
                this.TopMost = false;

                BackgroundWorker bwOpenTemp = new BackgroundWorker();
                bwOpenTemp.WorkerReportsProgress = true;
                bwOpenTemp.DoWork += bwOpenTemp_DoWork;
                bwOpenTemp.RunWorkerCompleted += bwOpenTemp_RunWorkerCompleted;
                bwOpenTemp.ProgressChanged += bwOpenTemp_ProgressChanged;
                bwOpenTemp.RunWorkerAsync(new TempCryptArgs(inputFilePath, password));
            }

        }

        /// <summary>
        /// Work of the OPEN TEMP background worker.
        /// </summary>
        void bwOpenTemp_DoWork(object sender, DoWorkEventArgs e)
        {
            TempCryptArgs args = (TempCryptArgs)e.Argument;
            TempDecryptFile tDecryptFile = new TempDecryptFile(args.InputFilePath, args.Password, (BackgroundWorker)sender);
            tDecryptFile.Run();
        }

        /// <summary>
        /// Result of the OPEN TEMP background worker.
        /// </summary>
        void bwOpenTemp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UIReady();
            lblStatus.Text = "";
            this.TopMost = true;
            this.SetTopLevel(true);

            if (e.Error != null) // If there is an error
            {
                if (e.Error is WrongPasswordException)
                    MessageBox.Show(this, "Wrong password.", this.Text + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(this, "An error occured during file decryption.\nDetails: " + e.Error.Message, this.Text + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                tbPassword.Clear();
                tbPassword.Select();
                return;
            }
            else // No error
            {
                // Delete original file ? //////////////////
                if (ckboxDeleteOriginal.Checked == true)
                {
                    File.Delete(inputFilePath);
                }

                // Exit application when all is done!
                Application.Exit();
            }
        }

        void bwOpenTemp_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Text = (string)e.UserState;
            if (e.ProgressPercentage == 50)
            {
                metroProgressSpinner1.Speed = 1;
            }
            else
            {
                metroProgressSpinner1.Speed = 4;
            }
        }

        /// <summary>
        /// Work of the DECRYPT AND SAVE backgorund worker.
        /// </summary>
        void bwSave_DoWork(object sender, DoWorkEventArgs e)
        {
            CryptArgs args = (CryptArgs)e.Argument;
            Crypter.DecryptFile(args.InputFilePath, args.OutputFilePath, args.Password);
        }

        /// <summary>
        /// Result of the DECRYPT AND SAVE background worker.
        /// </summary>
        void bwSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "";

            if (e.Error != null) // If there is an error
            {
                UIReady();
                if (e.Error is WrongPasswordException)
                    MessageBox.Show(this, "Wrong password.", this.Text + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(this, "An error occured during file decryption.", this.Text + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                try { File.Delete(outputFilePath);  }
                catch { }

                tbPassword.Clear();
                tbPassword.Select();
                return;
            }
            else
            {
                cancelClose = false;

                // Delete original file ? //////////////////
                if (ckboxDeleteOriginal.Checked == true)
                {
                    File.Delete(inputFilePath);
                }

                // Exit application when all is done!
                Application.Exit();
            }
        }

        private void UIReady()
        {
            cancelClose = false;

            aboutLink.Enabled = true;
            tbPassword.Enabled = true;
            btnDecrypt.Enabled = true;
            if (rdobtnSaveIsSource.Checked)
            {
                txtSaveDirectory.Enabled = false;
                btnBrowseFile.Enabled = false;
            }
            else
            {
                txtSaveDirectory.Enabled = true;
                btnBrowseFile.Enabled = true;
            }

            rdobtnSaveIsOther.Enabled = true;
            ckboxDeleteOriginal.Enabled = true;
            rdobtnDecryptAndSave.Enabled = true;
            rdobtnOpenTemp.Enabled = true;
            if (rdobtnDecryptAndSave.Checked)
            {
                panelSave.Enabled = true;
            }
            else
            {
                panelSave.Enabled = false;
            }

            metroProgressSpinner1.Visible = false;
            metroProgressSpinner1.Spinning = false;
        }

        private void UIWorking()
        {
            cancelClose = true;

            aboutLink.Enabled = false;
            tbPassword.Enabled = false;
            btnDecrypt.Enabled = false;
            rdobtnSaveIsSource.Enabled = false;
            rdobtnSaveIsOther.Enabled = false;
            btnBrowseFile.Enabled = false;
            ckboxDeleteOriginal.Enabled = false;
            btnDecrypt.Enabled = false;
            rdobtnOpenTemp.Enabled = false;
            rdobtnDecryptAndSave.Enabled = false;

            metroProgressSpinner1.Visible = true;
            metroProgressSpinner1.Spinning = true;
        }

        private void aboutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutUI aboutUi = new AboutUI();
            aboutUi.ShowDialog(this);
        }

        private void rdobtnSaveIsSource_CheckedChanged(object sender, EventArgs e)
        {
            if (rdobtnSaveIsSource.Checked == true)
            {
                txtSaveDirectory.Enabled = false;
                btnBrowseFile.Enabled = false;
            }
            else
            {
                txtSaveDirectory.Enabled = true;
                btnBrowseFile.Enabled = true;
            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.CheckPathExists = true;
            fileDialog.Title = "MCrypt - Save decrypted file";
            fileDialog.Filter = "Original file extension (*" + inputFileExtension + ")|*" + inputFileExtension + "|All files (*.*)|*.*";
            fileDialog.OverwritePrompt = true;
            fileDialog.AddExtension = true;
            fileDialog.DefaultExt = inputFileExtension;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtSaveDirectory.Text = fileDialog.FileName;
                txtSaveDirectory.SelectionStart = txtSaveDirectory.TextLength;
            }
        }

        /// <summary>
        /// When the rdobtn Open temporarily state changes.
        /// </summary>
        private void rdobtnOpenTemp_CheckedChanged(object sender, EventArgs e)
        {
            if (rdobtnOpenTemp.Checked)
            {
                panelSave.Visible = false;
                panelSave.Enabled = false;
                this.Size = new Size(295, 249);
            }
            else
            {
                panelSave.Visible = true;
                panelSave.Enabled = true;
                this.Size = new Size(295, 346);
            }
        }
        
        /// <summary>
        /// When the user wants to close the window.
        /// </summary>
        private void DecryptUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cancelClose)
            {
                if (MessageBox.Show(this, "MCrypt is hard working: closing it could result in a loss of data.\nDo you REALLY want to exit?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void DecryptUI_Load(object sender, EventArgs e)
        {

        }
    }
}
