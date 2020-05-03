﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MCrypt.Tools;
using MCrypt.Exceptions;

namespace MCrypt.Utils
{
    static class Files
    {
        /// <summary>
        /// Return true if the extension of the file path provided corresponds to MCrypt's.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        public static CryptMode GetCryptModeByExt(string path)
        {
            if (Path.GetExtension(path)==".mcrypt" || Path.GetExtension(path)==".MCRYPT")
            {
                return CryptMode.Decrypt;
            }
            else
            {
                return CryptMode.Encrypt;
            }
        }

        /// <summary>
        /// Get a path to a one-use uniquely named temporary file.
        /// </summary>
        /// <returns></returns>
        public static string GetTempFilePath()
        {
            return Path.GetTempFileName();
        }

        /// <summary>
        /// Check the path for invalid file name chars.
        /// </summary>
        /// <param name="path">File name to check.</param>
        public static void IsFileNameValid(string path)
        {
            // Check for invalid chars
            string invalidChars = "";
            foreach (char c in path.ToCharArray())
            {
                if (Path.GetInvalidFileNameChars().Contains(c) &! invalidChars.Contains(c) && c != Char.Parse("\\") && c != Char.Parse(":"))
                {
                    invalidChars += " " + c.ToString();
                }
            }
            if (invalidChars != "")
            {
                throw new InvalidFileNameException("Invalid file name chars were found in the specified path:" + invalidChars);
            }
        }

        /// <summary>
        /// Returns true if the file is used by another process.
        /// </summary>
        /// <param name="path">Path of the file to compute.</param>
        public static bool IsFileUsed(string path)
        {
            FileStream fs = null;

            try
            {
                fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }

            catch (IOException) // Failed to access file
            {
                return true;
            }

            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }

            return false; // No errors happened.
        }

        public static bool IsPathDirectory(string path)
        {
            return (File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory;
        }
    }
}
