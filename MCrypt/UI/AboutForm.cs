using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Globalization;
using MCrypt.Resources;
using MCrypt.Tools;

namespace MCrypt.UI
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            if (Thread.CurrentThread.CurrentCulture.Name.Contains("fr"))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");
                Output.Print("- Set UI culture to: fr");
            }

            InitializeComponent();
            
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);

            this.lblVersion.Text = lang.Version + " " + versionInfo.ProductVersion;
            this.lblAuthor.Text = lang.Author + " " + versionInfo.CompanyName;
            this.lblCopyright.Text = versionInfo.LegalCopyright;

            Assembly assembly = Assembly.GetExecutingAssembly();
            var descriptionAttribute = assembly
                .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)
                .OfType<AssemblyDescriptionAttribute>()
                .FirstOrDefault();
            if (descriptionAttribute != null)
                this.lblDescription.Text = lang.AboutMessage;

        }

        private void AboutUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Escape)
                this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Program.checkUpdatesSync();
        }
    }
}
