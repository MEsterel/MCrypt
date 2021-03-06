﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MCrypt.Exceptions;
using MCrypt.Resources;
using MCrypt.Tools;

namespace MCrypt.Cryptography
{
    public static class FileCrypter
    {
        // Rfc2898DeriveBytes constants:
        static readonly byte[] _obsolete_salt = new byte[] { 0x45, 0x12, 0x33, 0x89, 0x76, 0x45, 0x24, 0x97 }; // Must be at least eight bytes.  MAKE THIS SALTIER!
        public const int _obsolete_iterations = 1042; // Recommendation is >= 1000.
        public const int _iterations = 10000; // used for password derivation
        public const int _metadataHeaderLength = 30; // "MCryptEncryptedData_" + (10)
        public static readonly int _readBufferSize = 268435456; // Buffer size of 0.25 GB


        ////// METADATA ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        ////// Format du Body : Version de MCrypt, Type[File/Directory], OriginalName, Hash, Salt, Iterations, BatchesLength, CompressionMode

        public static CrypterInfo EncryptFile(string inputPath, string outputDirectory, string password, bool isDirectory, CompressionMode compressionMode, BgwProgressUpdater bgw)
        {
            Output.Print("ENCRYPTING: " + inputPath);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string finalInputPath = ""; // Needed for finally
            string outputFilePath = "";
            try
            {
                // Création de outputFilePath
                outputFilePath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + (isDirectory? ".mcryptfolder": ".mcryptfile"));
                Output.Print("Output file path: " + outputFilePath);

                // MANAGE DIRECTORIES
                bgw.ProgressChanged(0, lang.CompressingData);
                finalInputPath = Files.GetTempFilePath();
                if (!isDirectory)
                {
                    Output.Print("Encrypting a file.");
                    Output.Print(string.Format("Zipping file in temp file. ({0})", finalInputPath));
                    Zipper.ZipOneFile(inputPath, finalInputPath, compressionMode);
                }
                else
                {
                    Output.Print("Encrypting a directory.");
                    Output.Print(string.Format("Zipping directory in temp file. ({0})", finalInputPath));
                    Zipper.ZipDirectory(inputPath, finalInputPath, compressionMode);
                }

                bgw.ProgressChanged(20, lang.PreparingEncryption);

                // Set Aes
                AesManaged aes = new AesManaged();
                
                aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
                aes.KeySize = aes.LegalKeySizes[0].MaxSize;


                // Set key, iv and mode
                // NB: Rfc2898DeriveBytes initialization and subsequent calls to GetBytes must be exactly the same, including order, on both the encryption and decryption sides.

                // Salt can be public. We will use the BCrypt salt generator, and then convert it to bytes.
                string saltString = BCrypt.Net.BCrypt.GenerateSalt();
                byte[] salt = Encoding.Default.GetBytes(saltString);
                Output.Print("Salt: " + saltString);
                Output.Print("Iterations: " + _iterations);


                // Obtention du mot de passe dérivé en clé, utilisée pour le cryptage.
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, _iterations);


                aes.Key = key.GetBytes(aes.KeySize / 8); // Clé de cryptage (obtenue à partir d'une dérivation de mot de passe)
                aes.IV = key.GetBytes(aes.BlockSize / 8); // Vecteur d'initialisation (issu de la clé)
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;


                // Création de l'encrypteur
                ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);


                // Génération du hash BCrypt du mot de passe, que l'on stockera dans le metadata.
                string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(password);
                Output.Print("Password hash: " + passwordHash);

                // Génération du originalName
                string originalName = Path.GetFileName(inputPath);
                Output.Print("Original name: " + originalName);

                

                // Delete possible existing output file
                try { File.Delete(outputDirectory); } catch { }


                //// ENCRYPT
                using (FileStream source = new FileStream(finalInputPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (FileStream destination = new FileStream(outputFilePath, FileMode.CreateNew, FileAccess.Write, FileShare.None))
                    {
                        // Writing encrypted file data
                        // Note : Metadata will be insterted at the end of the file (batches length needed)

                        // Encrypting BufferSize MB batches
                        long readBytes = 0;
                        long totalReadBytes = source.Length;
                        int batchesNumber = (int)Math.Ceiling(totalReadBytes / (double)_readBufferSize);
                        Output.Print("Total bytes to encrypt: " + totalReadBytes);
                        Output.Print("Number of batches: " + batchesNumber);

                        int batches = 0;
                        long encryptedBytes = 0;
                        long[] batchesLength = new long[batchesNumber];

                        Output.Print("Encrypting batches...");
                        while (readBytes < totalReadBytes)
                        {
                            bgw.ProgressChanged(20 + batches * 60 / batchesNumber, string.Format(lang.Encrypting + " (" + lang.step + " {0} / {1})", batches + 1, batchesNumber));

                            using (MemoryStream ms = new MemoryStream())
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(ms, transform, CryptoStreamMode.Write)) // we create a cryptoStream for each batch (because it's of single use)
                                {
                                    int bytesToRead;
                                    if (totalReadBytes - readBytes > _readBufferSize)
                                    {
                                        bytesToRead = _readBufferSize;
                                    }
                                    else
                                    {
                                        bytesToRead = (int)(totalReadBytes - readBytes);
                                    }

                                    byte[] readBuffer = new byte[bytesToRead];
                                    source.Read(readBuffer, 0, bytesToRead);
                                    cryptoStream.Write(readBuffer, 0, bytesToRead);

                                    cryptoStream.FlushFinalBlock();
                                    readBytes += bytesToRead;

                                    destination.Write(ms.ToArray(), 0, (int)ms.Length);
                                    ms.Flush();

                                    batchesLength[batches] = ms.Length;
                                }
                            }

                            GC.Collect();

                            encryptedBytes += batchesLength[batches];

                            batches++;
                            Output.Print(string.Format("Batch number {0} / {1} done. ({2} encrypted bytes)", batches, batchesNumber, batchesLength[batches - 1]));
                        }

                        Output.Print(string.Format("Total encrypted bytes: {0}", encryptedBytes));



                        bgw.ProgressChanged(80, lang.WritingMetadata);
                        Output.Print("Building metadata.");

                        // Building metadataBatchesLength
                        StringBuilder metadataBatchesLengthString = new StringBuilder();
                        for (int i = 0; i < batchesNumber; i++)
                        {
                            metadataBatchesLengthString.Append(batchesLength[i] + "/");
                        }
                        Output.Print("Metadata batches length: " + metadataBatchesLengthString);

                        string metadataString = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|",
                            Application.ProductVersion, isDirectory.ToString(), originalName, passwordHash, saltString, _iterations, metadataBatchesLengthString, (int)compressionMode);

                        byte[] metadata = Encoding.Default.GetBytes(metadataString);

                        metadataString = string.Format("{0}MCryptEncryptedData|{1}", metadataString, metadata.Count().ToString().PadLeft(10, '0'));

                        metadata = Encoding.Default.GetBytes(metadataString);

                        Output.Print(string.Format("METADATA : {0} ({1} bytes)", metadataString, metadata.Length));
                        

                        // Writing metadata
                        destination.Write(metadata, 0, metadata.Length);
                        Output.Print("Metadata written at the end of the file.");
                    }

                }

                bgw.ProgressChanged(100, lang.EncryptionSuccessful);
                Output.Print("Encryption successful!");

            }
            catch (Exception e)
            {
                throw new EncryptException(e.Message, e.InnerException);
            }
            finally
            {
                stopwatch.Stop();
                Output.Print(string.Format("Operation ended in {0} .", stopwatch.Elapsed));

                if (File.Exists(finalInputPath))
                {
                    Files.OptimalFileDelete(finalInputPath);
                    Output.Print("Zipped temp file deleted.");
                }
            }

            return new CrypterInfo(outputFilePath, isDirectory, compressionMode);
        }


        public static CrypterInfo DecryptFile(string inputFilePath, string outputDirectory, string password, BgwProgressUpdater bgw)
        {
            Output.Print("DECRYPTING: " + inputFilePath);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            // Needed for return
            bool isDirectory = false;
            string userOutputPath = "";
            CompressionMode compressionMode;

            try
            {
                
                // DECRYPT PROCESS
                using (FileStream source = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    bgw.ProgressChanged(5, lang.ReadingMetadata);


                    // Récupération du Header
                    byte[] metadataHeader = new byte[_metadataHeaderLength]; // Simplement "MCryptEncryptedData_{taille d'octets à lire}"
                    source.Seek(-_metadataHeaderLength, SeekOrigin.End);
                    source.Read(metadataHeader, 0, _metadataHeaderLength);

                    // Vérification si ce fichier est bien un fichier MCrypt
                    try
                    {
                        string metadataHeaderStringCheck = Encoding.Default.GetString(metadataHeader);
                        //Console.WriteLine(metadataHeaderString);

                        if (metadataHeaderStringCheck.Split('|')[0] != "MCryptEncryptedData")
                        {
                            Output.Print("Metadata header incorrect. This is not a MCrypt file.", Level.Error);
                            throw new Exception();
                        }
                    }
                    catch // Si une erreur survient, c'est que ce n'est pas 
                    {
                        source.Flush();
                        source.Close();
                        throw new NotMCryptFileException();
                    }
                    Output.Print("MCrypt file detected!");

                    // Récupération de la fin du Header pour avoir le nombre de caractères du Body
                    string metadataHeaderString = Encoding.Default.GetString(metadataHeader);

                    int metadataBodyLength = int.Parse(metadataHeaderString.Split('|')[1]);
                    Output.Print("Metadata Body Length: " + metadataBodyLength);

                    byte[] metadataBody = new byte[metadataBodyLength];
                    source.Seek(-metadataBodyLength - _metadataHeaderLength, SeekOrigin.Current);
                    source.Read(metadataBody, 0, metadataBodyLength);

                    string[] metadataBodyStringSplit = Encoding.Default.GetString(metadataBody).Split('|');


                    //Vérification de la version 
                    Version mcryptVersion = new Version(metadataBodyStringSplit[0]);
                    if (mcryptVersion <= Version.Parse("1.2.0.0"))
                    {
                        Output.Print(string.Format("File encrypted with a previous version of MCrypt ({0}). Decrypting with Osbolete_DecryptFile120.", mcryptVersion));

                        source.Flush();
                        source.Close();

                        return Obsolete_DecryptFile120(inputFilePath, outputDirectory, password);
                    }
                    Output.Print("Current MCrypt version!");


                    // Vérification du mot de passe
                    bgw.ProgressChanged(10, lang.CheckingPassword);
                    string passwordHash = metadataBodyStringSplit[3];
                    if (!BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash))
                    {
                        throw new WrongPasswordException();
                    }
                    Output.Print("Correct password!");


                    // Build output path
                    bgw.ProgressChanged(15, lang.PreparingDecryption);

                    // Manage encrypted directories
                    isDirectory = bool.Parse(metadataBodyStringSplit[1]);
                    userOutputPath = Path.Combine(outputDirectory, metadataBodyStringSplit[2]); // The path for user output.
                    Output.Print(string.Format("Built User Output Path: ({0})", userOutputPath));
                    string outputFilePath = Files.GetTempFilePath();

                    if (!isDirectory)
                    {
                        Output.Print("Decrypting a file.");
                    }
                    else
                    {
                        Output.Print("Decrypting a directory.");
                    }
                    Output.Print(string.Format("Decrypting compressed data in temp file. ({0})", outputFilePath));

                    // Récupération du salt
                    byte[] salt = Encoding.Default.GetBytes(metadataBodyStringSplit[4]);

                    // Récupération des itérations
                    int iterations = int.Parse(metadataBodyStringSplit[5]);

                    // Récupération des Batches Length
                    Output.Print("Batches Length: " + metadataBodyStringSplit[6]);
                    string[] metadataReadBufferSizeStringSplit = metadataBodyStringSplit[6].Split('/');
                    long[] readBatchesLength = new long[metadataReadBufferSizeStringSplit.Length - 1];
                    for (int i = 0; i < metadataReadBufferSizeStringSplit.Length - 1; i++) // (- 1 car le dernier est vide)
                    {
                        readBatchesLength[i] = long.Parse(metadataReadBufferSizeStringSplit[i]);
                    }

                    // Récupéartion du compressionMode
                    compressionMode = (CompressionMode)int.Parse(metadataBodyStringSplit[7]);


                    // Set Aes
                    AesManaged aes = new AesManaged();
                    aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
                    aes.KeySize = aes.LegalKeySizes[0].MaxSize;

                    // Set key, iv & mode
                    // NB: Rfc2898DeriveBytes initialization and subsequent calls to   GetBytes   must be eactly the same, including order, on both the encryption and decryption sides.
                    Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, iterations);
                    aes.Key = key.GetBytes(aes.KeySize / 8);
                    aes.IV = key.GetBytes(aes.BlockSize / 8);
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    // Create decryptor
                    ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);


                    // Décryptage
                    using (FileStream destination = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                    {

                        // Remise à zéro du flux !!!
                        source.Seek(0, SeekOrigin.Begin);

                        long readBytes = 0;
                        long totalReadBytes = source.Length - (_metadataHeaderLength + metadataBodyLength);
                        double batchesNumber = readBatchesLength.Length;
                        Output.Print("Total bytes to decrypt: " + totalReadBytes);
                        Output.Print("Number of batches: " + batchesNumber);

                        int batches = 0;
                        long decryptedBytes = 0;

                        Output.Print("Decrypting batches...");

                        for (int i = 0; i < batchesNumber; i++)
                        {
                            bgw.ProgressChanged(20 + (int)(i * 60 / batchesNumber), string.Format(lang.Decrypting + " (" + lang.step + " {0} / {1})", i + 1, batchesNumber));
                            using (MemoryStream ms = new MemoryStream())
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(ms, transform, CryptoStreamMode.Write)) // we create a cryptoStream for each batch (because it's of single use)
                                {
                                    int bytesToRead = (int)readBatchesLength[i];

                                    byte[] readBuffer = new byte[bytesToRead];
                                    source.Read(readBuffer, 0, bytesToRead);
                                    cryptoStream.Write(readBuffer, 0, bytesToRead);

                                    cryptoStream.FlushFinalBlock();
                                    readBytes += bytesToRead;
                                    
                                    decryptedBytes += ms.Length;

                                    destination.Write(ms.ToArray(), 0, (int)ms.Length);
                                    ms.Flush();
                                }
                            }

                            batches++;
                            Output.Print(string.Format("Batch number {0} / {1} done. ({2} bytes)", batches, batchesNumber, readBatchesLength[i]));

                            GC.Collect(); // Nécessaire !!!!!
                        }

                        Output.Print(string.Format("Total decrypted bytes: {0}", decryptedBytes));
                    }

                    bgw.ProgressChanged(80, lang.DecompressingData);
                    Zipper.Unzip(outputFilePath, isDirectory? userOutputPath : Path.GetDirectoryName(userOutputPath)); // If this is a single file, don't create a folder with its name, just decrypt it directly.
                    Files.OptimalFileDelete(outputFilePath);
                    Output.Print("Unzipped and deleted temp file containing compressed data.");

                }

                bgw.ProgressChanged(100, lang.DecryptionSuccessful);
                Output.Print("Decryption successful!");
            }
            catch (WrongPasswordException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new DecryptException(e.Message, e.InnerException);
            }
            finally
            {
                stopwatch.Stop();
                Output.Print(string.Format("Operation ended in {0} .", stopwatch.Elapsed));
            }

            return new CrypterInfo(userOutputPath, isDirectory, compressionMode);
        }


        public static CrypterInfo Obsolete_DecryptFile120(string inputFilePath, string outputDirectory, string password)
        {
            Output.Print("DECRYPTING OBSOLETE 120: " + inputFilePath);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Needed for return
            bool isDirectory = false;
            string userOutputPath = "";

            try
            {

                // DECRYPT PROCESS
                using (FileStream source = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {

                    // Récupération du Header
                    byte[] metadataHeader = new byte[_metadataHeaderLength]; // Simplement "MCryptEncryptedData_{taille d'octets à lire}"
                    source.Seek(-_metadataHeaderLength, SeekOrigin.End);
                    source.Read(metadataHeader, 0, _metadataHeaderLength);

                    // Vérification si ce fichier est bien un fichier MCrypt
                    try
                    {
                        string metadataHeaderStringCheck = Encoding.Default.GetString(metadataHeader);
                        //Console.WriteLine(metadataHeaderString);

                        if (metadataHeaderStringCheck.Split('|')[0] != "MCryptEncryptedData")
                        {
                            Output.Print("Metadata header incorrect. This is not a MCrypt file.", Level.Error);
                            throw new Exception();
                        }
                    }
                    catch // Si une erreur survient, c'est que ce n'est pas 
                    {
                        source.Flush();
                        source.Close();
                        throw new NotMCryptFileException();
                    }
                    Output.Print("MCrypt file detected!");

                    // Récupération de la fin du Header pour avoir le nombre de caractères du Body
                    string metadataHeaderString = Encoding.Default.GetString(metadataHeader);

                    int metadataBodyLength = int.Parse(metadataHeaderString.Split('|')[1]);
                    Output.Print("Metadata Body Length: " + metadataBodyLength);

                    byte[] metadataBody = new byte[metadataBodyLength];
                    source.Seek(-metadataBodyLength - _metadataHeaderLength, SeekOrigin.Current);
                    source.Read(metadataBody, 0, metadataBodyLength);

                    string[] metadataBodyStringSplit = Encoding.Default.GetString(metadataBody).Split('|');


                    // RAPPEL du format de metadataBody de la 120: Version de MCrypt, Type[File/Directory], extension, Hash, Salt, Iterations, BatchesLength


                    // Vérification du mot de passe
                    string passwordHash = metadataBodyStringSplit[3];
                    if (!BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash))
                    {
                        throw new WrongPasswordException();
                    }
                    Output.Print("Correct password!");


                    // Build output path
                    // Manage encrypted directories
                    isDirectory = bool.Parse(metadataBodyStringSplit[1]);
                    userOutputPath = Path.Combine(outputDirectory, metadataBodyStringSplit[2]); // The path for user output.
                    string outputFilePath; // The path for decryption output
                    if (!isDirectory)
                    {
                        Output.Print("Decrypting a file.");
                        outputFilePath = userOutputPath;
                    }
                    else
                    {
                        Output.Print("Decrypting a directory.");
                        outputFilePath = Files.GetTempFilePath();
                        Output.Print(string.Format("Decrypting zipped directory in temp file. ({0})", outputFilePath));
                    }

                    // Récupération du salt
                    byte[] salt = Encoding.Default.GetBytes(metadataBodyStringSplit[4]);

                    // Récupération des itérations
                    int iterations = int.Parse(metadataBodyStringSplit[5]);

                    // Récupération des Bacthes Length
                    Output.Print("Batches Length: " + metadataBodyStringSplit[6]);
                    string[] metadataReadBufferSizeStringSplit = metadataBodyStringSplit[6].Split('/');
                    long[] readBatchesLength = new long[metadataReadBufferSizeStringSplit.Length - 1];
                    for (int i = 0; i < metadataReadBufferSizeStringSplit.Length - 1; i++) // (- 1 car le dernier est vide)
                    {
                        readBatchesLength[i] = long.Parse(metadataReadBufferSizeStringSplit[i]);
                    }


                    // Set Aes
                    AesManaged aes = new AesManaged();
                    aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
                    aes.KeySize = aes.LegalKeySizes[0].MaxSize;

                    // Set key, iv & mode
                    // NB: Rfc2898DeriveBytes initialization and subsequent calls to   GetBytes   must be eactly the same, including order, on both the encryption and decryption sides.
                    Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, iterations);
                    aes.Key = key.GetBytes(aes.KeySize / 8);
                    aes.IV = key.GetBytes(aes.BlockSize / 8);
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    // Create decryptor
                    ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);


                    // Décryptage

                    using (FileStream destination = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                    {

                        // Remise à zéro du flux !!!
                        source.Seek(0, SeekOrigin.Begin);

                        long readBytes = 0;
                        long totalReadBytes = source.Length - (_metadataHeaderLength + metadataBodyLength);
                        double batchesNumber = readBatchesLength.Length;
                        Output.Print("Total bytes to decrypt: " + totalReadBytes);
                        Output.Print("Number of batches: " + batchesNumber);

                        int batches = 0;
                        long decryptedBytes = 0;

                        Output.Print("Decrypting batches...");

                        for (int i = 0; i < batchesNumber; i++)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(ms, transform, CryptoStreamMode.Write)) // we create a cryptoStream for each batch (because it's of single use)
                                {
                                    int bytesToRead = (int)readBatchesLength[i];

                                    byte[] readBuffer = new byte[bytesToRead];
                                    source.Read(readBuffer, 0, bytesToRead);
                                    cryptoStream.Write(readBuffer, 0, bytesToRead);

                                    cryptoStream.FlushFinalBlock();
                                    readBytes += bytesToRead;

                                    decryptedBytes += ms.Length;

                                    destination.Write(ms.ToArray(), 0, (int)ms.Length);
                                    ms.Flush();
                                }
                            }

                            batches++;
                            Output.Print(string.Format("Batch number {0} / {1} done. ({2} bytes)", batches, batchesNumber, readBatchesLength[i]));

                            GC.Collect(); // Nécessaire !!!!!
                        }

                        Output.Print(string.Format("Total decrypted bytes: {0}", decryptedBytes));
                    }


                    if (isDirectory)
                    {
                        Zipper.Unzip(outputFilePath, userOutputPath);
                        Files.OptimalFileDelete(outputFilePath);
                        Output.Print("Unzipped and deleted temp file containing directory.");
                    }


                }

                Output.Print("Decryption successful!");
            }
            catch (WrongPasswordException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new DecryptException(e.Message, e.InnerException);
            }
            finally
            {
                stopwatch.Stop();
                Output.Print(string.Format("Operation ended in {0} .", stopwatch.Elapsed));
            }

            return new CrypterInfo(userOutputPath, isDirectory, CompressionMode.None); // Il n'y avait pas de compression à cette époque
        }


        public static void Obsolete_DecryptFile030(string inputFilePath, string outputFilePath, string password)
        {

            try
            {
                // Set Aes
                AesManaged aes = new AesManaged();
                aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
                aes.KeySize = aes.LegalKeySizes[0].MaxSize;

                // Set key, iv & mode
                // NB: Rfc2898DeriveBytes initialization and subsequent calls to   GetBytes   must be eactly the same, including order, on both the encryption and decryption sides.
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, _obsolete_salt, _iterations);
                aes.Key = key.GetBytes(aes.KeySize / 8);
                aes.IV = key.GetBytes(aes.BlockSize / 8);
                aes.Mode = CipherMode.CBC;

                // Create decryptor
                ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);


                // DECRYPT PROCESS
                using (FileStream source = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (FileStream destination = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                            {
                                source.CopyTo(cryptoStream);
                                cryptoStream.FlushFinalBlock();

                                destination.Write(ms.ToArray(), 0, (int)ms.Length);
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                if (e.Message == "Padding is invalid and cannot be removed.")
                {
                    throw new WrongPasswordException(e.Message, e.InnerException);
                }
                else
                {
                    throw new DecryptException(e.Message, e.InnerException);
                }
            }
        }
    }
}
