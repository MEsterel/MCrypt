using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCrypt.Cryptography
{
    public class CrypterInfo
    {
        public string OutputPath { get; }

        public bool IsDirectory { get; }

        public CrypterInfo(string outputPath, bool isDirectory)
        {
            OutputPath = outputPath;
            IsDirectory = isDirectory;
        }
    }
}
