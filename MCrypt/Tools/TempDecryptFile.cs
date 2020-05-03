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
using MCrypt.Utils;

namespace MCrypt.Tools
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
        private string tempFilePath;

        /// <summary>
        /// Path of the temporary encrypted temp file.
        /// </summary>
        private string tempCryptedPath;

        /// <summary>
        /// Indicate a background worker if you want to know the progress of the manager's work.
        /// </summary>
        private BgwProgressUpdater bgw;

        /// <summary>
        /// Initialize a temporarily decrypted file manager.
        /// </summary>
        /// <param name="path">Path of the file to decrypt and manage.</param>
        /// <param name="password">Password of the file.</param>
        /// <param name="bgWorker">Optional. Indicate a background worker if you want to know the progress of the manager's work.</param>
        public TempDecryptFile(string inputFilePath, string password, BackgroundWorker bgWorker = null)
        {
            this.password = password;
            this.inputFilePath = inputFilePath;
            if (!File.Exists(inputFilePath))
            {
                throw new FileNotFoundException();
            }

            if (bgWorker != null)
            {
                this.bgw = new BgwProgressUpdater(bgWorker);
            }
        }

        public void Run()
        {
            try
            {
                //// 1. PREPARE FILES
                bgw.ProgressChanged(0, "Preparing");
                // Get temp file paths
                tempFilePath = Files.GetTempFilePath();
                tempCryptedPath = Files.GetTempFilePath();

                // Rename tempFilePath to give it extension of original file
                string originalExtension = Path.GetExtension(Path.GetFileNameWithoutExtension(inputFilePath)); // Retrieve extension of original file
                File.Move(tempFilePath, tempFilePath + originalExtension); // Rename

                tempFilePath += originalExtension; // Add extension to stored tempFilePath value


                //// 2. DECRYPT FILE in tempFilePath 
                bgw.ProgressChanged(10, "Decrypting the file");
                Crypter.DecryptFile(inputFilePath, tempFilePath, password);


                //// 3. LAUNCH DECRYPTED FILE 
                bgw.ProgressChanged(40, "Starting the file");
                ProcessStartInfo procStartInfo = new ProcessStartInfo(tempFilePath);

                Process fileProc = new Process();
                fileProc.StartInfo = procStartInfo;
                fileProc.Start();

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
                    do
                    {
                        System.Threading.Thread.Sleep(1000);
                    } while (Files.IsFileUsed(tempFilePath));
                }


                //// 4. ENCRYPT EDITED TEMP FILE in tempCryptedPath 
                bgw.ProgressChanged(80, "Encrypting the new file");
                Crypter.EncryptFile(tempFilePath, tempCryptedPath, password); // Use same password


                //// 5. REPLACE ORIGINAL (inputFilePath) BY NEW (tempCryptedFile) 
                bgw.ProgressChanged(100, "Finalizing");
                File.Delete(inputFilePath);
                File.Copy(tempCryptedPath, inputFilePath);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                //// 6. DELETE TEMP FILES 
                try { File.Delete(tempFilePath); }
                catch { }
                try { File.Delete(tempCryptedPath); }
                catch { }
            }
        }
    }
}
