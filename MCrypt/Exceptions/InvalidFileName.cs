using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCrypt.Exceptions
{
    public class InvalidFileNameException : System.Exception
    {
        public InvalidFileNameException() : base() { }
        public InvalidFileNameException(string message) : base(message) { }
        public InvalidFileNameException(string message, System.Exception inner) : base(message, inner) { }
    }
}
