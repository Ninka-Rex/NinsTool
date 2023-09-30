using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NinsTool

{
    public partial class ModsForm : Form
    {
        public bool oculusKillerInstalled;
        public bool isAdmin;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;  
        //this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        public ModsForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/LibreQuest/OculusKiller");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/UnusualNorm/OculusKiller");
        }

        private void btnInstallOculusKiller_Click(object sender, EventArgs e)
        {
            
            if (!isAdmin)
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = Assembly.GetEntryAssembly().Location;
                    startInfo.Verb = "runas";
                    Process.Start(startInfo);
                    Environment.Exit(0);
                }
                catch
                {

                }
                

            }

            if (!oculusKillerInstalled) 
            {
                string filePath = @"C:\Program Files\Oculus\Support\oculus-dash\dash\bin\OculusDash.exe";
                string backupFilePath = @"C:\Program Files\Oculus\Support\oculus-dash\dash\bin\OculusDash.exe.BAK";
                string downloadUrl = "https://github.com/UnusualNorm/OculusKiller/releases/download/Anti-Restart-Forgiveness/OculusDash.exe";

                if (!File.Exists(filePath))
                {

                    MessageBox.Show("Oculus EXE not found at default location.");
                    return;
                }

                if (new FileInfo(filePath).Length > 1048576) // 1 MB = 1048576 bytes
                {
                    if (File.Exists(backupFilePath))
                    {
                        File.Delete(backupFilePath);
                    }
                    File.Move(filePath, backupFilePath);
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(downloadUrl, filePath);
                    btnInstallOculusKiller.Text = "Uninstall";
                    oculusKillerInstalled = true;
                    MessageBox.Show("Oculus Killer successfully installed!");
                }
                else
                {
                    MessageBox.Show("Oculus Killer already installed!");
                }
            }
            else
            {
                string filePath = @"C:\Program Files\Oculus\Support\oculus-dash\dash\bin\OculusDash.exe";
                string backupFilePath = @"C:\Program Files\Oculus\Support\oculus-dash\dash\bin\OculusDash.exe.BAK";

                if (File.Exists(filePath) && new FileInfo(filePath).Length > 1048576)
                {
                    MessageBox.Show("Oculus Killer is not installed.");
                }
                else if (File.Exists(backupFilePath))
                {
                    File.Delete(filePath);
                    File.Move(backupFilePath, filePath);
                    btnInstallOculusKiller.Text = "Install";
                    oculusKillerInstalled = false;
                    MessageBox.Show("Oculus Killer successfully uninstalled!");
                }
                else
                {
                    MessageBox.Show("Oculus Killer is not installed.");
                }

            }


        }

        public static string GetOculusInstallPath()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Oculus VR, LLC\Oculus"))
                {
                    if (key != null)
                    {
                        object installPath = key.GetValue("InstallPath");
                        if (installPath != null)
                        {
                            return installPath.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't find the installation path of Oculus.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        private void ModsForm_Load(object sender, EventArgs e)
        {
            isAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
            string filePath2 = @"C:\Program Files\Oculus\Support\oculus-dash\dash\bin\OculusDash.exe";
            if (!File.Exists(filePath2))
            {
                btnInstallOculusKiller.Text = "No .exe found";
                btnInstallOculusKiller.Enabled = false;
                return;
            }

                try
            {
                string filePath = @"C:\Program Files\Oculus\Support\oculus-dash\dash\bin\OculusDash.exe";
                oculusKillerInstalled = new FileInfo(filePath).Length < 1048576;
                if (oculusKillerInstalled) { btnInstallOculusKiller.Text = "Uninstall"; }
            }
            catch
            {
                oculusKillerInstalled = false;
            }
            

            if (!isAdmin)
            {
                btnInstallOculusKiller.Text = "Needs Admin!";
            }
        }
    }
}
