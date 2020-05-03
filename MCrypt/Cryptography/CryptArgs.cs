namespace MCrypt.Exceptions
{
    public class CryptArgs
    {
        public string InputFilePath { get; private set; }
        
        public string OutputFilePath { get; private set; }
        
        public string Password { get; private set; }

        //public bool IsArchive { get; private set; }

        public CryptArgs(string inputFilePath, string outputFilePath, string password)
        {
            this.InputFilePath = inputFilePath;
            this.OutputFilePath = outputFilePath;
            this.Password = password;
        }
    }
}
