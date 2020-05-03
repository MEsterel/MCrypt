using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace MCrypt.Tools
{
    public static class DirectoryZipper
    {
        public static void ZipDirectory(string sourcePath, string outputPath, bool addMCryptSignature = true)
        {
            if (File.Exists(outputPath)) // If output path already exists, delete it or error
            {
                File.Delete(outputPath);
            }

            ZipFile.CreateFromDirectory(sourcePath, outputPath, CompressionLevel.Fastest, true);

            if (addMCryptSignature) // add MCrypt Signature
            {
                using (ZipArchive archive = ZipFile.Open(outputPath, ZipArchiveMode.Update))
                {
                    archive.CreateEntry("_MCrypt.signature", CompressionLevel.Fastest);
                }
            }
        }

        public static bool IsArchiveFromMCrpyt(string archivePath)
        {
            using (ZipArchive archive = ZipFile.Open(archivePath, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.Name == "_MCrypt.signature")
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static void UnzipMCryptArchive(string archivePath, string outputPath)
        {
            // Delete MCrypt Signature
            using (ZipArchive archive = ZipFile.Open(archivePath, ZipArchiveMode.Update))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.Name == "_MCrypt.signature")
                    {
                        entry.Delete();
                    }
                }
            }

            ZipFile.ExtractToDirectory(archivePath, outputPath);
        }
    }
}
