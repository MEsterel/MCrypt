using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCrypt.Exceptions
{
    public class NotMCryptFileException : Exception
    {
        public NotMCryptFileException() : base() { }

        public NotMCryptFileException(string message) : base(message) { }
        public NotMCryptFileException(string message, System.Exception inner) : base(message, inner) { }
    }
}
