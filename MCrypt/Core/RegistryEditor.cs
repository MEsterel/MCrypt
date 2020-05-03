using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Reflection;

namespace MCrypt.Core
{
    public static class RegistryEditor
    {
        // /!\ NOT USED
         
        public static void installMCryptInRegistry()
        {
            Output.Print("Installing MCrypt in Registry...");

            string appPath = Assembly.GetExecutingAssembly().Location;

            // Create a subkey named MCrypt under HKEY_CLASSES_ROOT\*\shell.
            RegistryKey allFilesSubKey = Registry.ClassesRoot.CreateSubKey("*\\shell\\MCrypt");
            allFilesSubKey.SetValue("", "Open with MCrypt");
            allFilesSubKey.SetValue("Icon", appPath);

            // Create a subkey named command under HKEY_CLASSES_ROOT\*\shell\MCrypt.
            RegistryKey allFilesCommandSubKey = allFilesSubKey.CreateSubKey("command");
            allFilesCommandSubKey.SetValue("", appPath + "\"%1\"");

            // Create a subkey named MCrypt under HKEY_CLASSES_ROOT
            RegistryKey MCryptSubKey = Registry.ClassesRoot.CreateSubKey("MCrypt\\shell\\open\\command");
            MCryptSubKey.SetValue("", appPath + "\"%1\"");

            // Create a subkey named .mcrypt under HKEY_CLASSES_ROOT
            RegistryKey MCryptExtensionSubKey = Registry.ClassesRoot.CreateSubKey(".mcrypt");
            MCryptExtensionSubKey.SetValue("", "MCrypt");

            Output.Print("MCrypt successfully installed in registry!");
        }

        public static void uninstallMCryptInRegistry()
        {
            Output.Print("Unistalling MCrypt in Registry...");

            string appPath = Assembly.GetExecutingAssembly().Location;

            // Create a subkey named MCrypt under HKEY_CLASSES_ROOT\*\shell.
            RegistryKey allFilesShellSubKey = Registry.ClassesRoot.CreateSubKey("*\\shell");
            allFilesShellSubKey.DeleteSubKeyTree("MCrypt");

            RegistryKey MCryptSubKey = Registry.ClassesRoot.CreateSubKey("MCrypt\\shell\\open\\command");
            MCryptSubKey.SetValue("", appPath + "\"%1\"");

            Output.Print("MCrypt successfully uninstalled in registry!");
        }
    }
}
