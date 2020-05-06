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
        public static void Zip(string sourcePath, string outputPath)
        {
            if (File.Exists(outputPath)) // If output path already exists, delete it or error
            {
                File.Delete(outputPath);
            }

            ZipFile.CreateFromDirectory(sourcePath, outputPath, CompressionLevel.NoCompression, false); // No compression to be as fast as possible (first goal of MCrypt).
        }

        public static void Unzip(string archivePath, string outputPath)
        {
            ZipFile.ExtractToDirectory(archivePath, outputPath);
        }
    }
}
