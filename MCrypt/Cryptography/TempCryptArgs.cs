using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCrypt.Cryptography
{
    public class TempCryptArgs
    {
        public string InputFilePath { get; private set; }
        
        public string Password { get; private set; }

        public TempCryptArgs(string inputFilePath, string password)
        {
            this.InputFilePath = inputFilePath;
            this.Password = password;
        }
    }
}
