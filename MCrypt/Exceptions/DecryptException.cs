using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCrypt.Exceptions
{
    public class DecryptException : System.Exception
    {
        public DecryptException() : base() { }
        public DecryptException(string message) : base(message) { }
        public DecryptException(string message, System.Exception inner) : base(message, inner) { }
    }
}
