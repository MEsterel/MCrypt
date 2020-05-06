using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MCrypt
{
    public static class Output
    {
        /// <summary>
        /// Output a string
        /// </summary>
        /// <param name="s">String to output</param>
        ///  <param name="l">Level of the output</param>
        public static void Print(string s, Level l = Level.Info)
        {
            switch (l)
            {
                case Level.Info:
                    Console.WriteLine(DateTime.UtcNow.ToLongTimeString() + " [INFO]: " + s);
                    break;

                case Level.Warning:
                    Console.WriteLine(DateTime.UtcNow.ToLongTimeString() + " [WARNING]: " + s);
                    break;

                case Level.Error:
                    Console.WriteLine(DateTime.UtcNow.ToLongTimeString() + " [CRITICAL ERROR]: " + s);
                    break;
            }
        }

    }

    public enum Level
    {
        Info = 0,
        Warning = 1,
        Error = 2
    }
}
