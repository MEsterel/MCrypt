using MCrypt.Tools;

namespace MCrypt.Cryptography
{
    public class CryptArgs
    {
        public string InputPath { get; private set; }
        
        public string OutputPath { get; private set; }
        
        public string Password { get; private set; }

        public bool IsDirectory { get; private set; }

        public CompressionMode CompressionMode { get; private set; }

        public CryptArgs(string inputPath, string outputPath, string password, bool isDirectory = false, CompressionMode compressionMode = CompressionMode.N_A)
        {
            this.InputPath = inputPath;
            this.OutputPath = outputPath;
            this.Password = password;
            this.IsDirectory = isDirectory;
            this.CompressionMode = compressionMode;
        }
    }
}
