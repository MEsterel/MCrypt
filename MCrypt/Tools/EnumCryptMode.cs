using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MCrypt.Tools
{
    public enum CryptMode
    {
        /// <summary>
        /// Encrypt mode
        /// </summary>
        Encrypt = 1,

        /// <summary>
        /// Decrypt mode
        /// </summary>
        Decrypt = 2,

        /// <summary>
        /// Not recommended. No mode set, to be defined.
        /// </summary>
        Auto = 0,
    }
}