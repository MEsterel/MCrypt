using MCrypt.Cryptography;
using MCrypt.Tools;
using MCrypt.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCrypt
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        static UpdateManager updateManager;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                AttachConsole(ATTACH_PARENT_PROCESS);

                Output.Print("MCrypt v" + Application.ProductVersion.ToString());
                Output.Print("Core load");
                Output.Print("- Changed thread culture to en-US");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

                Output.Print("- Load UI styles");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Output.Print("- Resolve emebedded dlls");
                AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(FindDLL);


                Output.Print("- Initiate core variables");
                string path;
                CryptMode mode;

                Output.Print("Successful core load");

                // Check for updates ///////////////////////////
                Output.Print("Checking for updates asynchronously");
                checkUpdates();

                // Check for args //////////////////////////////
                Output.Print("Checking launch args...");
                if (args.Length == 0)
                {
                    Output.Print("No args > launching file browser interface.");

                    FileBrowserForm fBUI = new FileBrowserForm();
                    Application.Run(fBUI);

                    if (fBUI.Mode == CryptMode.Encrypt)
                    {
                        Output.Print("Running encrypt UI to file \"" + fBUI.Path + "\"");
                        Application.Run(new EncryptForm(fBUI.Path, false));
                    }
                    else if (fBUI.Mode == CryptMode.Decrypt)
                    {
                        Output.Print("Running decrypt UI to file \"" + fBUI.Path + "\"");
                        Application.Run(new DecryptForm(fBUI.Path, false));
                    }

                    return;
                }
                else if (args.Length >= 2)
                {
                    if (args[1] == "/E")
                        mode = CryptMode.Encrypt;
                    else if (args[1] == "/D")
                        mode = CryptMode.Decrypt;
                    else
                        mode = CryptMode.Auto;
                }
                else
                {
                    mode = CryptMode.Auto;
                }

                path = args[0];
                Output.Print("Set file path to \"" + path + "\"");

                // Check if object exists
                if (!File.Exists(args[0]) && !Directory.Exists(args[0]))
                {
                    Output.Print("Specified file does not exists. Exit program.", Level.Error);
                    return;
                }
                else if (mode == CryptMode.Auto) // if it exists and that no args impose crypt mode, determine it
                {
                    if (Files.IsPathDirectory(path))
                    {
                        Output.Print("Directory detected.");
                        mode = CryptMode.Encrypt;
                    }
                    else
                    {
                        Output.Print("File detected.");
                        mode = Files.GetCryptModeByExt(path);
                    }
                    
                }
                Output.Print("Set crypt mode to \"" + mode.ToString() + "\"");

                // Get if it is for encryption or decryption
                if (mode == CryptMode.Encrypt)
                {
                    Output.Print("Running encrypt UI to object \"" + path + "\"");
                    Application.Run(new EncryptForm(path));
                }
                else if (mode == CryptMode.Decrypt)
                {
                    Output.Print("Running decrypt UI to object \"" + path + "\"");
                    Application.Run(new DecryptForm(path));
                }
            }
            catch (Exception ex)
            {
                runExceptionMessageHandler(ex);
            }
        }

        private static void checkUpdates()
        {
            updateManager = new UpdateManager();
            updateManager.CheckForUpdatesAsync(false);
        }

        private static Assembly FindDLL(object s, ResolveEventArgs a)
        {
            Output.Print("Requesting DLL \"" + a.Name.Substring(0, a.Name.IndexOf(",")) + "\"");

            string resourceName = new AssemblyName(a.Name).Name + ".dll";
            string resource = Array.Find(Assembly.GetExecutingAssembly().GetManifestResourceNames(), element => element.EndsWith(resourceName));

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
            {
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }

        private static void runExceptionMessageHandler(Exception ex)
        {
            MExceptionReporter.ReportException reportException = new MExceptionReporter.ReportException(Application.ProductName, ex);
            reportException.ShowDialog();
            return;
        }
    }
}
