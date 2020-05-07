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
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Threading;
using System.Globalization;
using MCrypt.Resources;

namespace MCrypt.UI
{
    public partial class DecryptForm : Form
    {
        /// <summary>
        /// Input file path.
        /// </summary>
        private string inputFilePath;

        /// <summary>
        /// Output file path.
        /// </summary>
        private string outputDirectory;

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
        public DecryptForm(string path, bool mouseStartLocation = true)
        {
            if (Thread.CurrentThread.CurrentCulture.Name.Contains("fr"))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");
                Output.Print("- Set UI culture to: fr");
            }

            InitializeComponent();
            UIReady();

            if (mouseStartLocation == true)
                Location = new Point(MousePosition.X, MousePosition.Y);
            else
                Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);

            AcceptButton = btnDecrypt;
            inputFilePath = path;
            saveDirectoryUC.InitialDirectory = Path.GetDirectoryName(inputFilePath);
            rdobtnOpenTemp.Checked = true;
            lblStatus.Text = "";
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {

            // Check password
            if (tbPassword.Text == "")
            {
                MessageBox.Show(this, lang.PleaseEnterYourPassword, this.Text + " - " + lang.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check input file path for the last time
            if (!File.Exists(inputFilePath))
            {
                MessageBox.Show(this, lang.OriginalFileMovedBeforeDecryption, this.Text + " - " + lang.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            // Set last values
            password = tbPassword.Text;

            //Run through parameters
            if (rdobtnDecryptAndSave.Checked)
            {
                //// DECRYPT AND SAVE /////////////////////////////////////////////////
                if (saveDirectoryUC.SaveIsSource)
                {
                    Output.Print("Output path = Source directory");
                    outputDirectory = Path.GetDirectoryName(inputFilePath);

                    // Existing files are not managed here.
                }
                else
                {
                    Output.Print("Output path = Other directory");

                    if (!saveDirectoryUC.ValidateOtherDirectory())
                        return;

                    outputDirectory = saveDirectoryUC.OtherDirectory;

                    // Existing files are not managed here.
                }

                // Set backgorund worker
                BackgroundWorker bwSave = new BackgroundWorker();
                bwSave.RunWorkerCompleted += bwSave_RunWorkerCompleted;
                bwSave.DoWork += bwSave_DoWork;

                // Decrypt !
                UIWorking();
                lblStatus.Text = lang.Decrypting;
                bwSave.RunWorkerAsync(new CryptArgs(inputFilePath, outputDirectory, password));
            }
            else
            {
                //// OPEN TEMPORARILY /////////////////////////////////////////////////////////////////////////
                UIWorking();
                TopMost = false;

                BackgroundWorker bwOpenTemp = new BackgroundWorker
                {
                    WorkerReportsProgress = true
                };
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
            TempDecryptFile tDecryptFile = new TempDecryptFile(args.InputFilePath, args.Password, (BackgroundWorker)sender, this);
            tDecryptFile.Run();
        }

        /// <summary>
        /// Result of the OPEN TEMP background worker.
        /// </summary>
        void bwOpenTemp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UIReady();
            lblStatus.Text = "";
            TopMost = true;
            SetTopLevel(true);

            if (e.Error != null) // If there is an error
            {
                if (e.Error is WrongPasswordException)
                    MessageBox.Show(this, lang.WrongPassword, this.Text + " - " + lang.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (e.Error is NotMCryptFileException)
                    MessageBox.Show(this, lang.TheFileToDecryptIsNotMCryptFile, this.Text + " - " + lang.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(this, lang.AnErrorOccuredDuringDecryption + "\n" + lang.Details + " " + e.Error.Message, this.Text + " - " + lang.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                tbPassword.Clear();
                tbPassword.Select();
                return;
            }
            else
            {
                // Close when all is done!
                Close();
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
            FileCrypter.DecryptFile(args.InputPath, args.OutputPath, args.Password);
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
                    MessageBox.Show(this, lang.WrongPassword, this.Text + " - " + lang.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (e.Error is NotMCryptFileException)
                    MessageBox.Show(this, lang.TheFileToDecryptIsNotMCryptFile, this.Text + " - " + lang.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(this, lang.AnErrorOccuredDuringDecryption + "\n" + lang.Details + " " + e.Error.Message, this.Text + " - " + lang.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                try { File.Delete(outputDirectory);  }
                catch { }

                tbPassword.Clear();
                tbPassword.Select();
                return;
            }
            else
            {
                cancelClose = false;

                // Delete original file ? //////////////////
                if (saveDirectoryUC.DeleteOriginal)
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
            saveDirectoryUC.UserInputEnabled = true;
            rdobtnDecryptAndSave.Enabled = true;
            rdobtnOpenTemp.Enabled = true;
            rdobtnOpenTemp_CheckedChanged(null, null); //simulating to refresh

            metroProgressSpinner1.Visible = false;
            metroProgressSpinner1.Spinning = false;
        }

        private void UIWorking()
        {
            cancelClose = true;

            aboutLink.Enabled = false;
            tbPassword.Enabled = false;
            btnDecrypt.Enabled = false;
            saveDirectoryUC.UserInputEnabled = false;
            btnDecrypt.Enabled = false;
            rdobtnOpenTemp.Enabled = false;
            rdobtnDecryptAndSave.Enabled = false;

            metroProgressSpinner1.Visible = true;
            metroProgressSpinner1.Spinning = true;
        }

        private void aboutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutForm aboutUi = new AboutForm();
            aboutUi.ShowDialog(this);
        }


        private void rdobtnOpenTemp_CheckedChanged(object sender, EventArgs e)
        {
            if (rdobtnOpenTemp.Checked)
            {
                saveDirectoryUC.Visible = false;
                this.Size = new Size(295, 249);
            }
            else
            {
                saveDirectoryUC.Visible = true;
                this.Size = new Size(295, 346);
            }
        }

        private void DecryptUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cancelClose)
            {
                if (MessageBox.Show(this, lang.MCryptHardWorkingPrompt, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
