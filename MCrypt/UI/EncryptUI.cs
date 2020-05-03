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
using MCrypt.Utils;
using MCrypt.Core;

namespace MCrypt.UI
{
    public partial class EncryptUI : Form
    {
        /// <summary>
        /// Input file path.
        /// </summary>
        private string inputFilePath;

        private string finalInputFilePath;

        private string tempArchiveLocation;

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

        private bool isInputFileDirectory;

        /// <summary>
        /// Decrypt file with password.
        /// </summary>
        /// <param name="path">Path of the file to decrypt.</param>
        /// <param name="mouseStartLocation">True: start location at mouse position. False: start location at center screen.</param>
        public EncryptUI(string path, bool mouseStartLocation = true)
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

            this.AcceptButton = btnEncrypt;
            this.inputFilePath = path;
            this.isInputFileDirectory = Files.IsPathDirectory(inputFilePath);
            rdobtnSaveIsSource.Checked = true;
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
            if (!File.Exists(inputFilePath) && !Directory.Exists(inputFilePath))
            {
                MessageBox.Show(this, "Original object to crypt has been moved or deleted before encryption.", this.Text + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            // Set last values ////////////////////
            password = tbPassword.Text;


            // Check output file path
            Output.Print("Check output file path.");
            if (rdobtnSaveIsSource.Checked == true) // Take source directory
            {
                Output.Print("Output path = Source directory");
                outputFilePath = inputFilePath + ".mcrypt"; // Get the name of the original file

                if (File.Exists(outputFilePath))
                {
                    Output.Print("Output path already exists.", Level.Warning);
                    if (MessageBox.Show(this,
                        "A file named \"" + Path.GetFileName(outputFilePath) + "\" already exists. Do you want to replace it?",
                        this.Text + " - Warning",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        File.Delete(outputFilePath);
                    else
                        return;
                }               
            }
            else // If specified directory is choosen
            {
                Output.Print("Output path = Prefered directory");
                if (txtSaveDirectory.Text == "") // If no path is indicated
                {
                    Output.Print("No output path indicated.", Level.Warning);
                    MessageBox.Show(this, "Please specify the location of the output file.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                                
                if (!Directory.Exists(Path.GetDirectoryName(txtSaveDirectory.Text))) // If output directory does not exist.
                {
                    Output.Print("The specified directory does not exist.", Level.Warning);
                    MessageBox.Show(this, "The specified directory does not exist.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                if (Path.GetExtension(txtSaveDirectory.Text) != ".mcrypt") // If exstension is not MCrypt
                    outputFilePath = txtSaveDirectory.Text + ".mcrypt";
                else
                    outputFilePath = txtSaveDirectory.Text;

                if (File.Exists(outputFilePath)) // If output file path already exists
                {
                    Output.Print("Deleted already existing output path file.", Level.Warning);
                    File.Delete(outputFilePath);
                }
            }


            // MANAGE DIRECTORY ///////////////////
            if (!isInputFileDirectory) // If it is a file
            {
                finalInputFilePath = inputFilePath;

                // Set backgorund worker
                BackgroundWorker bw = new BackgroundWorker();
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;
                bw.DoWork += bw_DoWork;

                // ENCRYPT !
                UIWorking();
                lblStatus.Text = "Encrypting the file";
                bw.RunWorkerAsync(new CryptArgs(finalInputFilePath, outputFilePath, password));
            }
            else // If it is a directory
            {
                Output.Print("Input path is an archive: zip it.");
                tempArchiveLocation = Files.GetTempFilePath(); // Get temp path

                Tools.DirectoryZipper.ZipDirectory(inputFilePath, tempArchiveLocation, true); // Store zipped directory in temp place

                finalInputFilePath = tempArchiveLocation;
            }


            
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            CryptArgs args = (CryptArgs)e.Argument;
            Crypter.EncryptFile(args.InputFilePath, args.OutputFilePath, args.Password);
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "";

            if (e.Error != null) // If there is an error
            {
                UIReady();

                MessageBox.Show(this, "An error occured during file encryption.\nDetails: " + e.Error.Message, this.Text + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                try { File.Delete(outputFilePath); }
                catch { }

                if (isInputFileDirectory)
                {
                    try { File.Delete(tempArchiveLocation); }
                    catch { }
                }

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

                if (isInputFileDirectory) // If it was a directory, delete temp archive
                {
                    try { File.Delete(tempArchiveLocation); }
                    catch { }
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
            tbRePassword.Enabled = true;
            btnEncrypt.Enabled = true;
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
            
            metroProgressSpinner1.Visible = false;
            metroProgressSpinner1.Spinning = false;
        }

        private void UIWorking()
        {
            cancelClose = true;

            aboutLink.Enabled = false;
            tbPassword.Enabled = false;
            tbRePassword.Enabled = false;            
            rdobtnSaveIsSource.Enabled = false;
            rdobtnSaveIsOther.Enabled = false;
            btnBrowseFile.Enabled = false;
            txtSaveDirectory.Enabled = false;
            ckboxDeleteOriginal.Enabled = false;
            btnEncrypt.Enabled = false;

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
            fileDialog.Title = "MCrypt - Save encrypted file";
            fileDialog.Filter = "MCrypt file (*.mcrypt)|*.mcrypt";
            fileDialog.AddExtension = true;
            fileDialog.DefaultExt = ".mcrypt";
            fileDialog.OverwritePrompt = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtSaveDirectory.Text = fileDialog.FileName;
                txtSaveDirectory.SelectionStart = txtSaveDirectory.TextLength;
            }
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
