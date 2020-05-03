using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCrypt.Exceptions
{
    public class EncryptException : System.Exception
    {
        public EncryptException() : base() { }
        public EncryptException(string message) : base(message) { }
        public EncryptException(string message, System.Exception inner) : base(message, inner) { }
    }
}
