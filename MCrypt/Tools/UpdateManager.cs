using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUpdate;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;

namespace MCrypt.Tools
{
    public class UpdateManager : IMUpdatable
    {
        #region "MUpdate"        

        /// <summary>
        /// Returns the executing assembly.
        /// </summary>
        public Assembly ApplicationAssembly
        {
            get { return Assembly.GetExecutingAssembly(); }
        }

        /// <summary>
        /// Returns the Application ID.
        /// </summary>
        public string ApplicationID
        {
            get { return "MCrypt"; }
        }

        /// <summary>
        /// Returns the Application Icon.
        /// </summary>
        public Icon ApplicationIcon
        {
            get { return Properties.Resources.MCryptIcon; }
        }

        /// <summary>
        /// Returns the Application Name.
        /// </summary>
        public string ApplicationName
        {
            get { return Application.ProductName; }
        }

        /// <summary>
        /// Returns the context.
        /// </summary>
        public Form Context
        {
            get { return context; }
        }
        private Form context;

        /// <summary>
        /// Returns Uri location of the update.xml file.
        /// </summary>
        public Uri UpdateXmlLocation
        {
            get { return new Uri("https://dl.dropbox.com/s/l0qv38cxs1t3p3v/update.xml?dl=0"); }
        }

        /// <summary>
        /// Returns language
        /// </summary>
        public string Language
        {
            get { return ""; }
        }
        #endregion


        MUpdater updater;
        public UpdateManager(Form _context = null)
        {
            this.context = _context;

            updater = new MUpdater(this);
        }

        public void CheckForUpdatesAsync()
        {
            updater.DoUpdateAsync();
        }
    }
}
