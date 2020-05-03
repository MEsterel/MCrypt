using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace MCrypt.Exceptions
{
    public static class Crypter
    {
        // Rfc2898DeriveBytes constants:
        static byte[] salt = new byte[] { 0x45, 0x12, 0x33, 0x89, 0x76, 0x45, 0x24, 0x97 }; // Must be at least eight bytes.  MAKE THIS SALTIER!
        public const int iterations = 1042; // Recommendation is >= 1000.

        public static void EncryptFile(string inputFilePath, string outputFilePath, string password)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            try
            {
                // Set Aes
                AesManaged aes = new AesManaged();
                
                aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
                aes.KeySize = aes.LegalKeySizes[0].MaxSize;

                // Set key, iv and mode
                // NB: Rfc2898DeriveBytes initialization and subsequent calls to   GetBytes   must be eactly the same, including order, on both the encryption and decryption sides.
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, salt, iterations);
                aes.Key = key.GetBytes(aes.KeySize / 8);
                aes.IV = key.GetBytes(aes.BlockSize / 8);
                aes.Mode = CipherMode.CBC;

                // Create encryptor
                ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);
                // Delete possible existing output file
                try { File.Delete(outputFilePath); } catch { }

                // Encrypt
                using (MemoryStream ms = new MemoryStream())
                {
                    using (FileStream source = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                        {
                            source.CopyTo(cryptoStream);
                            cryptoStream.FlushFinalBlock();

                            using (FileStream destination = new FileStream(outputFilePath, FileMode.CreateNew, FileAccess.Write, FileShare.None))
                            {
                                destination.Write(ms.ToArray(), 0, (int)ms.Length);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new EncryptException(e.Message, e.InnerException);
            }
        }


        public static void DecryptFile(string inputFilePath, string outputFilePath, string password)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            try
            {
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

               // Create decryptor
               ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);


                // DECRYPT PROCESS
                using (FileStream source = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                        {
                            source.CopyTo(cryptoStream);
                            cryptoStream.FlushFinalBlock();

                            using (FileStream destination = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                            {
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
