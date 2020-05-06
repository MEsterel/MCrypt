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

            AcceptButton = btnEncrypt;
            inputPath = path;
            isInputPathDirectory = Files.IsPathDirectory(inputPath);
            lblStatus.Text = "";
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            Output.Print("Encrypt button clicked.");


            // Check passwords
            Output.Print("Checking passwords.");
            if (tbPassword.Text == "")
            {
                MessageBox.Show(this, "Please enter a password.", this.Text + " - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Output.Print("No passwords entered.", Level.Warning);
                return;
            }
            else if (tbRePassword.Text == "")
            {
                MessageBox.Show(this, "Please re-enter the password.", this.Text + " - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Output.Print("No passwords entered.", Level.Warning);
                return;
            }
            else if (tbPassword.Text != tbRePassword.Text)
            {
                MessageBox.Show(this, "Entered passwords do not match.", this.Text + " - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Output.Print("Passwords do not match.", Level.Warning);
                return;
            }

            // Check input file path for the last time
            if (!File.Exists(inputPath) && !Directory.Exists(inputPath))
            {
                MessageBox.Show(this, "Original object to crypt has been moved or deleted before encryption.", this.Text + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            // Set last values ////////////////////
            password = tbPassword.Text;


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

            simulatedOutputFilePath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + (isInputPathDirectory? " (MCrypted folder)": " (MCrypted file)") + ".mcrypt"); // Simulate final output path to target problems

            if (File.Exists(simulatedOutputFilePath))
            {
                Output.Print("Output path already exists.", Level.Warning);
                if (MessageBox.Show(this,
                    "A file named \"" + Path.GetFileName(simulatedOutputFilePath) + "\" already exists. Do you want to replace it?",
                    this.Text + " - Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    File.Delete(simulatedOutputFilePath);
                else
                    return;
            }

            BackgroundWorker bw = new BackgroundWorker();
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.DoWork += bw_DoWork;

            UIWorking();

            lblStatus.Text = "Encrypting the " + (isInputPathDirectory ? "folder" : "file");

            bw.RunWorkerAsync(new CryptArgs(inputPath, Path.GetDirectoryName(simulatedOutputFilePath), password, isInputPathDirectory));

            //else // If it is a directory
            //{
            //    //Output.Print("Input path is an archive: zip it.");
            //    //tempArchiveLocation = Files.GetTempFilePath(); // Get temp path
            //    //Tools.DirectoryZipper.ZipDirectory(inputFilePath, tempArchiveLocation, true); // Store zipped directory in temp place
            //    //finalInputFilePath = tempArchiveLocation;
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            CryptArgs args = (CryptArgs)e.Argument;
            FileCrypter.EncryptFile(args.InputPath, args.OutputPath, args.Password, args.IsDirectory);
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "";

            if (e.Error != null) // If there is an error
            {
                UIReady();

                MessageBox.Show(this, "An error occured during file encryption.\nDetails: " + e.Error.Message, this.Text + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

            aboutLink.Enabled = true;
            tbPassword.Enabled = true;
            tbRePassword.Enabled = true;
            btnEncrypt.Enabled = true;
            saveDirectoryUC.UserInputEnabled = true;

            metroProgressSpinner1.Visible = false;
            metroProgressSpinner1.Spinning = false;
        }

        private void UIWorking()
        {
            cancelClose = true;

            aboutLink.Enabled = false;
            tbPassword.Enabled = false;
            tbRePassword.Enabled = false;
            saveDirectoryUC.UserInputEnabled = false;
            btnEncrypt.Enabled = false;

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
                if (MessageBox.Show(this, "MCrypt is hard working: closing it could result in a loss of data.\nDo you REALLY want to exit?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
