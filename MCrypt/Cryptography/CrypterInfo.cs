using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCrypt.Tools;

namespace MCrypt.Cryptography
{
    public class CrypterInfo
    {
        public string OutputPath { get; }

        public bool IsDirectory { get; }

        public CompressionMode CompressionMode { get; }

        public CrypterInfo(string outputPath, bool isDirectory, CompressionMode compressionMode)
        {
            OutputPath = outputPath;
            IsDirectory = isDirectory;
            CompressionMode = compressionMode;
        }
    }
}
