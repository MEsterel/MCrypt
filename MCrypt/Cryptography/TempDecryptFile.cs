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
using MCrypt.Resources;

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
        private string InputFilePath;

        private string Password;

        /// <summary>
        /// Path of the tempoary file.
        /// </summary>
        private string TempPath;

        /// <summary>
        /// Indicate a background worker if you want to know the progress of the manager's work.
        /// </summary>
        private BgwProgressUpdater Bgw;

        private CrypterInfo DecryptedInfo;

        private Form Owner;

        /// <summary>
        /// Initialize a temporarily decrypted file manager.
        /// </summary>
        /// <param name="path">Path of the file to decrypt and manage.</param>
        /// <param name="password">Password of the file.</param>
        /// <param name="bgWorker">Optional. Indicate a background worker if you want to know the progress of the manager's work.</param>
        public TempDecryptFile(string inputFilePath, string password, BgwProgressUpdater bgw, Form owner)
        {
            InputFilePath = inputFilePath;
            Password = password;
            Owner = owner;

            if (!File.Exists(inputFilePath))
            {
                throw new FileNotFoundException();
            }

            Bgw = bgw;
        }

        public void Run()
        {
            try
            {
                //// 1. PREPARE TEMP DIRECTORY
                Bgw.ProgressChanged(0, lang.Preparing);

                // Get temp working directory
                TempPath = Files.GetTempDirectoryPath();


                //// 2. DECRYPT FILE in tempFilePath
                DecryptedInfo = FileCrypter.DecryptFile(InputFilePath, TempPath, Password, Bgw);


                //// 3. LAUNCH DECRYPTED FILE 
                Bgw.ProgressChanged(100, lang.Opening);
                ProcessStartInfo procStartInfo = new ProcessStartInfo(DecryptedInfo.OutputPath);

                Process fileProc = new Process
                {
                    StartInfo = procStartInfo
                };
                fileProc.Start();


                if (!DecryptedInfo.IsDirectory)
                {
                    Bgw.ProgressChanged(-1, lang.WaitingForTheFileToExit);
                    try // Try to watch for the process()
                    {
                        fileProc.WaitForExit(); // Wait for the process to exit
                    }
                    catch // Let the error down (? good idea ?)
                    {

                    }
                    finally // If process watching failed  OR  process finished: look if the file is still in use.
                    {
                        while (Files.IsFileUsed(DecryptedInfo.OutputPath))
                        {
                            System.Threading.Thread.Sleep(1000);
                        }
                    }
                }
                else // If it is a folder
                {
                    ShowCloseDialog(Owner, DecryptedInfo.OutputPath);
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
                        if (processType.Equals("explorer") && locationPath == DecryptedInfo.OutputPath)
                        {
                            ie.Quit();
                        }
                    }
                }



                //// 4. ENCRYPT EDITED TEMP FILE in tempCryptedPath 
                CrypterInfo encryptedInfo = FileCrypter.EncryptFile(DecryptedInfo.OutputPath, Path.GetDirectoryName(DecryptedInfo.OutputPath), Password, DecryptedInfo.IsDirectory, DecryptedInfo.CompressionMode, Bgw); // Use same password and encrypt in same temp folder


                //// 5. REPLACE ORIGINAL (inputFilePath) BY NEW (tempCryptedFile) 
                Bgw.ProgressChanged(100, lang.Finalizing);
                File.Delete(InputFilePath);
                File.Copy(encryptedInfo.OutputPath, InputFilePath);
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
                    Files.OptimalDirectoryDelete(TempPath);
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
