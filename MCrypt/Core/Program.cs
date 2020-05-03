using MCrypt.Tools;
using MCrypt.UI;
using MCrypt.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCrypt.Core
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

                    FileBrowserUI fBUI = new FileBrowserUI();
                    Application.Run(fBUI);

                    if (fBUI.mode == CryptMode.Encrypt)
                    {
                        Output.Print("Running encrypt UI to file \"" + fBUI.path + "\"");
                        Application.Run(new EncryptUI(fBUI.path, false));
                    }
                    else if (fBUI.mode == CryptMode.Decrypt)
                    {
                        Output.Print("Running decrypt UI to file \"" + fBUI.path + "\"");
                        Application.Run(new DecryptUI(fBUI.path, false));
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
                    mode = Files.GetCryptModeByExt(path);
                }
                Output.Print("Set crypt mode to \"" + mode.ToString() + "\"");

                // Get if it is for encryption or decryption
                if (mode == CryptMode.Encrypt)
                {
                    Output.Print("Running encrypt UI to object \"" + path + "\"");
                    Application.Run(new EncryptUI(path));
                }
                else if (mode == CryptMode.Decrypt)
                {
                    Output.Print("Running decrypt UI to object \"" + path + "\"");
                    Application.Run(new DecryptUI(path));
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

            if (a.Name.Substring(0, a.Name.IndexOf(",")) == "MetroFramework")
            {
                return Assembly.Load(Properties.Resources.MetroFramework);
            }

            if (a.Name.Substring(0, a.Name.IndexOf(",")) == "MetroFramework.Fonts")
            {
                return Assembly.Load(Properties.Resources.MetroFramework_Fonts);
            }

            if (a.Name.Substring(0, a.Name.IndexOf(",")) == "MetroFramework.Design")
            {
                return Assembly.Load(Properties.Resources.MetroFramework_Design);
            }

            if (a.Name.Substring(0, a.Name.IndexOf(",")) == "MUpdate")
            {
                return Assembly.Load(Properties.Resources.MUpdate);
            }

            if (a.Name.Substring(0, a.Name.IndexOf(",")) == "MExceptionReporter")
            {
                return Assembly.Load(Properties.Resources.MUpdate);
            }

            return null;
        }

        private static void runExceptionMessageHandler(Exception ex)
        {
            MExceptionReporter.ReportException reportException = new MExceptionReporter.ReportException(Application.ProductName, ex);
            reportException.ShowDialog();
            return;
        }
    }
}
