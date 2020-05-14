using MCrypt.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MCrypt.Tools;
using MCrypt.Cryptography;
using System.Threading;
using System.Globalization;
using MCrypt.Resources;

namespace MCrypt.UI
{
    public partial class EncryptForm : Form
    {
        private string inputPath;

        private string simulatedOutputFilePath;

        private string outputDirectory;

        private string password;

        private bool isInputPathDirectory;

        /// <summary>
        /// Indicates if the UI allows the user to close the window.
        /// </summary>
        private bool cancelClose = false;

        public EncryptForm(string path, bool mouseStartLocation = true)
        {
            if (Thread.CurrentThread.CurrentCulture.Name.Contains("fr"))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");
                Output.Print("- Set UI culture to: fr");
            }

            Output.Print("Initializing Encrypt window components.");
            InitializeComponent();

            UIReady();
            if (mouseStartLocation == true)
            {
                this.Location = new Point(MousePosition.X, MousePosition.Y);
                Output.Print("Locate encrypt window at current mouse position.");
            }
            else
            {
                this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
                Output.Print("Locate encrypt window at the center of the screen.");
            }

            AcceptButton = encryptBtn;
            inputPath = path;
            isInputPathDirectory = Files.IsPathDirectory(inputPath);
            statusLbl.Text = "";

            compressionCmb.SelectedIndex = 0; // Fastest mode is generally no compression
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            Output.Print("Encrypt button clicked.");


            // Check passwords
            Output.Print("Checking passwords.");
            if (passwordTxt.Text == "")
            {
                MessageBox.Show(this, lang.PleaseEnterAPassword, this.Text + " - " + lang.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Output.Print("No password entered", Level.Warning);
                return;
            }
            else if (rePasswordTxt.Text == "")
            {
                MessageBox.Show(this, lang.PleaseConfirmPassword, this.Text + " - " + lang.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Output.Print("No confirm password entered.", Level.Warning);
                return;
            }
            else if (passwordTxt.Text != rePasswordTxt.Text)
            {
                MessageBox.Show(this, lang.PasswordsDoNotMatch, this.Text + " - " + lang.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Output.Print("Passwords do not match.", Level.Warning);
                return;
            }

            // Check input file path for the last time
            if (!File.Exists(inputPath) && !Directory.Exists(inputPath))
            {
                MessageBox.Show(this, lang.OriginalObjectToEnryptMoved, this.Text + " - " + lang.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            // Set last values ////////////////////
            password = passwordTxt.Text;


            // Output Directory
            Output.Print("Check output file path.");
            if (saveDirectoryUC.SaveIsSource) // Take source directory
            {
                Output.Print("Output path = Source directory");
                outputDirectory = Path.GetDirectoryName(inputPath);
            }
            else
            {
                Output.Print("Output path = Other directory");

                if (!saveDirectoryUC.ValidateOtherDirectory())
                    return;

                outputDirectory = saveDirectoryUC.OtherDirectory;
            }

            simulatedOutputFilePath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + (isInputPathDirectory ? ".mcryptfolder" : ".mcryptfile")); // Simulate final output path to target problems

            if (File.Exists(simulatedOutputFilePath))
            {
                Output.Print("Output path already exists.", Level.Warning);
                if (MessageBox.Show(this,
                    lang.AFileNamed + " \"" + Path.GetFileName(simulatedOutputFilePath) + "\" " + lang.alreadyExistsReplaceIt,
                    this.Text + " - " + lang.Warning,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    File.Delete(simulatedOutputFilePath);
                else
                    return;
            }


            UIWorking();
            BackgroundWorker bw = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += Bw_ProgressChanged;

            bw.RunWorkerAsync(new CryptArgs(inputPath, Path.GetDirectoryName(simulatedOutputFilePath), password, isInputPathDirectory, (CompressionMode)compressionCmb.SelectedIndex));
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statusLbl.Text = (string)e.UserState;
            if (e.ProgressPercentage == -1)
            {
                metroProgressSpinner1.Speed = 1;
            }
            else
            {
                metroProgressSpinner1.Speed = 4;
            }
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            CryptArgs args = (CryptArgs)e.Argument;

            BgwProgressUpdater bgw = new BgwProgressUpdater((BackgroundWorker)sender);

            FileCrypter.EncryptFile(args.InputPath, args.OutputPath, args.Password, args.IsDirectory, args.CompressionMode, bgw);
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statusLbl.Text = "";

            if (e.Error != null) // If there is an error
            {
                UIReady();

                MessageBox.Show(this, lang.AnErrorOccuredDuringEncryption + "\n" + lang.Details + " " + e.Error.Message, this.Text + " - " + lang.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                try { File.Delete(simulatedOutputFilePath); }
                catch { }
                return;
            }
            else
            {
                cancelClose = false;

                // Delete original file ? //////////////////
                if (saveDirectoryUC.DeleteOriginal)
                {
                    if (isInputPathDirectory)
                        Files.OptimalDirectoryDelete(inputPath);
                    else
                        Files.OptimalFileDelete(inputPath);

                    Output.Print("Deleted initial path.");
                }

                // Close: everything is done!
                GC.Collect();
                Close();
            }
        }


        private void UIReady()
        {
            cancelClose = false;

            passwordTxt.Enabled = true;
            rePasswordTxt.Enabled = true;
            encryptBtn.Enabled = true;
            saveDirectoryUC.UserInputEnabled = true;
            compressionCmb.Enabled = true;

            metroProgressSpinner1.Visible = false;
            metroProgressSpinner1.Spinning = false;
        }

        private void UIWorking()
        {
            cancelClose = true;

            passwordTxt.Enabled = false;
            rePasswordTxt.Enabled = false;
            saveDirectoryUC.UserInputEnabled = false;
            encryptBtn.Enabled = false;
            compressionCmb.Enabled = false;

            metroProgressSpinner1.Visible = true;
            metroProgressSpinner1.Spinning = true;
        }

        private void aboutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutForm aboutUi = new AboutForm();
            aboutUi.ShowDialog(this);
        }

        private void EncryptUI_FormClosing(object sender, FormClosingEventArgs e)
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

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
