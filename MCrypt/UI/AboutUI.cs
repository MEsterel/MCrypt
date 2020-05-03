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

namespace MCrypt.UI
{
    public partial class AboutUI : Form
    {
        public AboutUI()
        {
            InitializeComponent();
            
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);

            this.lblVersion.Text = "Version: " + versionInfo.ProductVersion;
            this.lblAuthor.Text = "Author: " + versionInfo.CompanyName;
            this.lblCopyright.Text = versionInfo.LegalCopyright;

            Assembly assembly = Assembly.GetExecutingAssembly();
            var descriptionAttribute = assembly
                .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)
                .OfType<AssemblyDescriptionAttribute>()
                .FirstOrDefault();
            if (descriptionAttribute != null)
                this.lblDescription.Text = descriptionAttribute.Description;

        }

        private void AboutUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter || e.KeyData == Keys.Escape)
                this.Close();
        }
    }
}
