using Squirrel;
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

namespace Contoso.DesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CheckForUpdate();

            AddVersionNumber();
        }

        private void AddVersionNumber()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            LblVersion.Text = $" Version: {versionInfo.FileVersion}";
        }

        private async Task CheckForUpdate()
        {
            try
            {
                using (var mgr = new UpdateManager("http://127.0.0.1:8081/"))
                {
                    LblStatus.Text = "Status: Checking for updates...";
                    await mgr.UpdateApp();
                    LblStatus.Text = "Status: Update check complete..";
                }
            }
            catch (Exception ex)
            {
                LblStatus.Text = "Error: "+ex.Message;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello from Example Win Forms App!");
        }
    }
}
