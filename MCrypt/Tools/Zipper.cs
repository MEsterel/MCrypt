using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace MCrypt.Tools
{
    public static class Zipper
    {
        public static void ZipDirectory(string sourcePath, string outputPath, CompressionMode compressionMode)
        {
            if (File.Exists(outputPath)) // If output path already exists, delete it or error
            {
                File.Delete(outputPath);
            }

            ZipFile.CreateFromDirectory(sourcePath, outputPath, ParseCompressionLevel(compressionMode), false);
        }


        public static void ZipOneFile(string sourcePath, string outputPath, CompressionMode compressionMode)
        {
            if (File.Exists(outputPath)) // If output path already exists, delete it or error
            {
                File.Delete(outputPath);
            }

            using (ZipArchive archive = ZipFile.Open(outputPath, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(sourcePath, Path.GetFileName(sourcePath), ParseCompressionLevel(compressionMode));
            }
        }


        private static CompressionLevel ParseCompressionLevel(CompressionMode compressionMode)
        {
            if (compressionMode == CompressionMode.N_A)
            {
                throw new Exception("Invalid compression mode!");
            }
            else if (compressionMode == CompressionMode.None)
            {
                return CompressionLevel.NoCompression;
            }
            else if (compressionMode == CompressionMode.Fastest)
            {
                return CompressionLevel.Fastest;
            }
            else if (compressionMode == CompressionMode.Optimal)
            {
                return CompressionLevel.Optimal;
            }

            throw new Exception("Parse Compression Level error: no case!");
        }

        public static void Unzip(string archivePath, string outputPath)
        {
            ZipFile.ExtractToDirectory(archivePath, outputPath);
        }
    }
}
