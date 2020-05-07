using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MCrypt.Exceptions;
using System.Reflection;
using System.ComponentModel;
using System.Diagnostics;
using MCrypt.Tools;
using MCrypt.Cryptography;
using MCrypt.UI;
using System.Web;
using SHDocVw;
using System.Windows.Forms;
using System.Drawing;

namespace MCrypt.Cryptography
{
    /// <summary>
    /// Temporarily decrypted file manager.
    /// </summary>
    public class TempDecryptFile
    {
        /// <summary>
        /// Path of the file to manage.
        /// </summary>
        private string inputFilePath;

        private string password;

        /// <summary>
        /// Path of the tempoary file.
        /// </summary>
        private string tempPath;

        /// <summary>
        /// Indicate a background worker if you want to know the progress of the manager's work.
        /// </summary>
        private BgwProgressUpdater bgw;

        private CrypterInfo decryptedInfo;

        private Form owner;

        /// <summary>
        /// Initialize a temporarily decrypted file manager.
        /// </summary>
        /// <param name="path">Path of the file to decrypt and manage.</param>
        /// <param name="password">Password of the file.</param>
        /// <param name="bgWorker">Optional. Indicate a background worker if you want to know the progress of the manager's work.</param>
        public TempDecryptFile(string inputFilePath, string password, BackgroundWorker bgWorker = null, Form owner = null)
        {
            this.inputFilePath = inputFilePath;
            this.password = password;
            this.owner = owner;

            if (!File.Exists(inputFilePath))
            {
                throw new FileNotFoundException();
            }

            if (bgWorker != null)
            {
                bgw = new BgwProgressUpdater(bgWorker);
            }
        }

        public void Run()
        {
            try
            {
                //// 1. PREPARE TEMP DIRECTORY
                bgw.ProgressChanged(0, "Preparing");

                // Get temp working directory
                tempPath = Files.GetTempDirectoryPath();


                //// 2. DECRYPT FILE in tempFilePath 
                bgw.ProgressChanged(1, "Decrypting");
                decryptedInfo = FileCrypter.DecryptFile(inputFilePath, tempPath, password);


                //// 3. LAUNCH DECRYPTED FILE 
                bgw.ProgressChanged(40, "Opening");
                ProcessStartInfo procStartInfo = new ProcessStartInfo(decryptedInfo.OutputPath);

                Process fileProc = new Process
                {
                    StartInfo = procStartInfo
                };
                fileProc.Start();


                if (!decryptedInfo.IsDirectory)
                {
                    bgw.ProgressChanged(50, "Waiting for the file to exit");
                    try // Try to watch for the process()
                    {
                        fileProc.WaitForExit(); // Wait for the process to exit
                    }
                    catch // Let the error down (? good idea ?)
                    {

                    }
                    finally // If process watching failed  OR  process finished: look if the file is still in use.
                    {
                        while (Files.IsFileUsed(decryptedInfo.OutputPath))
                        {
                            System.Threading.Thread.Sleep(1000);
                        }
                    }
                }
                else // If it is a folder
                {
                    ShowCloseDialog(owner, decryptedInfo.OutputPath);
                    // When it closes, the user wants to close the folder back.

                    ShellWindows _shellWindows = new ShellWindows();
                    string processType;
                    string locationPath;

                    foreach (InternetExplorer ie in _shellWindows)
                    {
                        //this parses the name of the process
                        processType = Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
                        //Output.Print("Process type: " + processType);
                        locationPath = (new Uri(ie.LocationURL)).LocalPath;
                        //Output.Print("ie Location URL: " + locationPath);

                        //this could also be used for IE windows with processType of "iexplore"
                        if (processType.Equals("explorer") && locationPath == decryptedInfo.OutputPath)
                        {
                            ie.Quit();
                        }
                    }
                }



                //// 4. ENCRYPT EDITED TEMP FILE in tempCryptedPath 
                bgw.ProgressChanged(60, "Encrypting back the " + (decryptedInfo.IsDirectory? "directory" : "file"));
                CrypterInfo encryptedInfo = FileCrypter.EncryptFile(decryptedInfo.OutputPath, Path.GetDirectoryName(decryptedInfo.OutputPath), password, decryptedInfo.IsDirectory); // Use same password and encrypt in same temp folder


                //// 5. REPLACE ORIGINAL (inputFilePath) BY NEW (tempCryptedFile) 
                bgw.ProgressChanged(100, "Finalizing");
                File.Delete(inputFilePath);
                File.Copy(encryptedInfo.OutputPath, inputFilePath);
            }
            catch (WrongPasswordException ex)
            {
                throw new WrongPasswordException(ex.Message, ex.InnerException);
            }
            catch (DecryptException ex)
            {
                throw new DecryptException(ex.Message, ex.InnerException);
            }
            catch (EncryptException ex)
            {
                throw new EncryptException(ex.Message, ex.InnerException);
            }
            catch (NotMCryptFileException ex)
            {
                throw new NotMCryptFileException(ex.Message, ex.InnerException);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                //// 6. DELETE TEMP DIRECTORY 
                try
                {
                    Files.OptimalDirectoryDelete(tempPath);
                    Output.Print("Deleted temp folder.");
                }
                catch { }
            }
        }

        private delegate void InvokeDelegate(Form owner, string path);
        public void ShowCloseDialog(Form owner, string path)
        {
            if (owner.InvokeRequired)
                owner.Invoke(new InvokeDelegate(ShowCloseDialog), owner, path);
            else
            {
                FolderTempOpenForm folderTempOpenForm = new FolderTempOpenForm(path);

                owner.Visible = false;

                owner.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - folderTempOpenForm.Width / 2 - owner.Width / 2 - 10, Screen.PrimaryScreen.WorkingArea.Height - owner.Height - 10);
                folderTempOpenForm.ShowDialog();

                owner.Visible = true;
            }
        }
    }
}
