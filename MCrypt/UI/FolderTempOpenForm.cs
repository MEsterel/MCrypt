using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCrypt.UI
{
    public partial class FolderTempOpenForm : Form
    {
        private string FolderPath;

        public FolderTempOpenForm(string folderPath)
        {
            InitializeComponent();

            FolderPath = folderPath;

            TopLevel = true;

            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width - 15, Screen.PrimaryScreen.WorkingArea.Height - Height - 15);
        }
        private void closeFolderBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void accessFolderlnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo(FolderPath);
            Process fileProc = new Process
            {
                StartInfo = procStartInfo
            };
            fileProc.Start();
        }
    }
}
