
using Microsoft.Win32;
using NinsTool;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TrayBuddy 
{
    public partial class Form1 : Form
    {
        RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Oculus\\RemoteHeadset", true);
        RegistryKey startupKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        public int Bitrate = 0;
        public static string aswState;
        public bool localDimmingState;
        public bool slicedEncodingState;
        public static bool check_for_exit = false;
        // Version
        public static string version = "r1.2.3";
        public static double shortVersion = 1.23;

        public static bool notifs = false;
        public static bool activated = false;
        public bool dontCloseMenu = false;
        public string headsetModel;
        public string ping;
        public bool ConnectedViaWifi;

        public Form1()
        {
            InitializeComponent();

        }

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
        private void ChangeSubMenuColor(ToolStripMenuItem parentMenuItem, Color color)
        {
            foreach (ToolStripItem menuItem in parentMenuItem.DropDownItems)
            {
                if (menuItem is ToolStripMenuItem)
                {
                    ToolStripMenuItem subMenuItem = (ToolStripMenuItem)menuItem;
                    subMenuItem.ForeColor = color;

                    // Recursively change the color of the submenu's submenus
                    ChangeSubMenuColor(subMenuItem, color);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Stop(); //Stopping main timer
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                notifyIcon1.ShowBalloonTip(2000, "Nin's Tool", "Nin's Tool is already running", ToolTipIcon.Info);
                Environment.Exit(0);
            }
            var myRenderer = new MyRenderer();

            foreach (ToolStripItem menuItem in trayMenu1.Items)
            {
                if (menuItem is ToolStripMenuItem)
                {
                    ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)menuItem;
                    toolStripMenuItem.ForeColor = Color.White;

                    // Change the color of the submenus recursively
                    ChangeSubMenuColor(toolStripMenuItem, Color.White);
                }
            }


            // Set the Renderer property of the ToolStrip to the new MyRenderer
            trayMenu1.Renderer = myRenderer;
            //When the app starts from windows autimatically starting it, its working diretcory will be
            // C:/Windows/System32 so we need to change that.
            try
            {
                startupKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", false);
                string Path = startupKey.GetValue("Nin's Tool").ToString();
                Path = Path.Replace(@"\Nin's Tool.exe", ""); // Now it's a valid directory.
                Directory.SetCurrentDirectory(Path);
            }
            catch { } //must be no startup entry then.

            //SfSkinManager.SetTheme(this, new Theme("Windows11Light"));


            activated = NinsTool.Properties.Settings.Default.Enable;
            if (activated)
            {
                string hello = "Woah! No need to crack my software. If price is an issue, please hit me up for a discount: nin@nin.wtf also Hi Ben!";
                hello = hello + "";
                activationUnlock();
            }

            //TimerCallback callback = CheckForLink;
            //System.Threading.Timer timer = new System.Threading.Timer(callback, null, 0, 60000); // create a timer that fires every second
            //Thread timerThread = new Thread(() => timer.Change(0, 60000)); // start the timer on a new thread
            //timerThread.Start();

            if (NinsTool.Properties.Settings.Default.FirstLaunch == true) //First start tutorial
            {
                firstTimeCheckSystem();
                notifyIcon1.ShowBalloonTip(2000, "Nin's Tool", "Welcome! Thanks for trying Nin's Tool. I live here in the tray.", ToolTipIcon.Info);
                notifyIcon1.ShowBalloonTip(2000, "Nin's Tool", "Whenever you need me, just right click on me to access my settings.", ToolTipIcon.Info);
                notifyIcon1.ShowBalloonTip(2000, "Nin's Tool", "Click 'about' to see some more settings and put in your key from Gumroad. Now, give me a moment to initialize!", ToolTipIcon.Info);
            }


            try { GetCurrentValues(); }
            catch
            {
                NinsTool.Properties.Settings.Default.FirstLaunch = false;
                NinsTool.Properties.Settings.Default.Save();
            }
            //notifyIcon1.Visible = true;
            //notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "Tool loaded!", ToolTipIcon.Info);
            aboutVersion.Text = "Nin's Tool | Version " + version;
            applySettings();
            setToolTip();
            if (NinsTool.Properties.Settings.Default.FirstLaunch == true)
            {
                notifyIcon1.ShowBalloonTip(2000, "Nin's Tool", "Bitrate: " + Convert.ToString(Bitrate) + " Mbps | ASW: " + Convert.ToString(aswState) + " | Sliced Encoding: " + Convert.ToString(slicedEncodingState), ToolTipIcon.Info);
                NinsTool.Properties.Settings.Default.FirstLaunch = false;
                NinsTool.Properties.Settings.Default.Save();
            }

            //check for updates
            if (NinsTool.Properties.Settings.Default.CheckForUpdates == true)
            {
                if (CheckForUpdates())
                {
                    updateSeparator.Visible = true;
                    updateNotifMenuItem.Visible = true;
                    aboutBtnUpdateCheck.Checked = true;
                }
                aboutBtnUpdateCheck.Checked = true;
            }

            if (Process.GetProcessesByName("OculusDash").Length > 0)
            {
                // connectQuestWirelessly(); CRASH
                BeginInvoke(new Action(startTimer));
                startExitWatcher();
                notifyIcon1.ShowBalloonTip(2000, "Nin's Tool", "Oculus Link already running", ToolTipIcon.Info);
            }


            //Look for a quest on LAN if there's no direct wired connecton
            if (headsetModel == "No Headset")
            {
                connectQuestWirelessly();
            }



        }

        private void firstTimeCheckSystem()
        {
            if (Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Oculus\\RemoteHeadset") == null)
            {
                MessageBox.Show("Could not find Oculus in the registry! Nin's Tool may not work right.", "Couldn't find Oculus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void connectQuestWirelessly()
        {
            if (headsetModel != "No Headset")
            {
                return;
            }

            string questIP = NinsTool.ArpLookup.findQuestDevice();

            if (questIP != null)
            {
                // ADB TCPIP
                ProcessStartInfo startInfo = new ProcessStartInfo("adb.exe", "tcpip 5555");
                startInfo.RedirectStandardOutput = true;
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardOutput = true;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();

                ProcessStartInfo startInfo2 = new ProcessStartInfo("adb.exe", "connect " + questIP + ":5555");
                startInfo2.RedirectStandardOutput = true;
                startInfo2.CreateNoWindow = true;
                startInfo2.UseShellExecute = false;
                startInfo2.RedirectStandardInput = true;
                Process process2 = new Process();
                process2.StartInfo = startInfo2;
                process2.Start();
                StreamReader reader = process2.StandardOutput;
                string output = reader.ReadToEnd();
                process2.WaitForExit();
                if (output != null & output.Contains("connected to") || output.Contains("already connected"))
                {

                    ping = Convert.ToString(PingHost(questIP));
                    if (notifs == true)
                    {

                        //notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Connected to a Quest on your network!\nIP: " + questIP + "\nLatency: " + ping + " ms", ToolTipIcon.Info); //FIX ME
                        System.Threading.Thread.Sleep(200); // weird bug if I don't wait 160ms. Probably because another ADB is being executed too soon after the one above is.

                    }
                    ConnectedViaWifi = true;
                    setToolTip();
                }
                else if (output != null & output.Contains("No connection could be made because the target machine actively refused it."))
                {
                    ConnectedViaWifi = false;
                    setToolTip();
                    txtHeadset.Text = "WiFi (Unauthorized)";
                    mnuGuardian.Enabled = false;
                    proxMenu.Enabled = false;
                    mnuScreenBrightness.Enabled = false;
                    txtHeadset.Image = NinsTool.Properties.Resources._lock;
                    btnBattery.Text = "Click to retry";

                }

            }

        }

        private void setToolTip()
        {
            headsetModel = productModel();
            if (headsetModel != "Quest Pro" & headsetModel != null)
            {
                localDimmingToolStripMenuItem.Enabled = false; // disable local dimming if user isn't using quest pro
            }
            else if (activated)
            {
                localDimmingToolStripMenuItem.Enabled = true;
            }
            if (headsetModel == null)
            {
                headsetModel = "No Headset";
                txtHeadset.Image = NinsTool.Properties.Resources.qmark;
                txtHeadset.ForeColor = Color.White;
            }
            else if (ConnectedViaWifi)
            {
                notifyIcon1.Text = "Nin's tool \n" + headsetModel + " (WiFi)\n" + Convert.ToString(Bitrate) + " mbps";
                txtHeadset.Text = headsetModel + " (WiFi) (" + ping + "ms)";
                txtHeadset.Image = NinsTool.Properties.Resources.game;
                if (activated)
                {
                    mnuGuardian.Enabled = true;
                    proxMenu.Enabled = true;
                    mnuScreenBrightness.Enabled = true;
                }
                btnStartWiredLink.Enabled = false;
                txtHeadset.ForeColor = Color.Gold;
            }
            else
            {
                notifyIcon1.Text = "Nin's tool \n" + headsetModel + "\n" + Convert.ToString(Bitrate) + " mbps";
                txtHeadset.Text = headsetModel + " (Wired)";
                txtHeadset.Image = NinsTool.Properties.Resources.game;
                txtHeadset.ForeColor = Color.Aqua;
                if (activated)
                {
                    mnuGuardian.Enabled = true;
                    proxMenu.Enabled = true;
                }
                btnStartWiredLink.Enabled = true;
            }
            if (headsetModel != "No Headset")
            {
                ControllerStatus controllers = new ControllerStatus();

                string bat = getBatteryLevel();
                btnCtrlBattery.Text = controllers.GetControllerBattery(this);
                btnBattery.Text = "Battery: " + bat + "%";
                if (Convert.ToInt32(bat) >= 50)
                {
                    btnBattery.ForeColor = Color.Lime;
                    btnCtrlBattery.ForeColor = Color.Lime;
                }
                else if (Convert.ToInt32(bat) >= 30)
                {
                    btnBattery.ForeColor = Color.Orange;
                    btnCtrlBattery.ForeColor = Color.Orange;
                }
                else
                {
                    btnBattery.ForeColor = Color.Red;
                    btnCtrlBattery.ForeColor = Color.Red;
                }
                
            }
            try
            {
                brightnessComboBox.Text = brightPercent.GetbrightPercentage(this).ToString();
            }
            catch
            {

            }

        }

        private string getBatteryLevel()
        {
            Process adbProcess = new Process();
            adbProcess.StartInfo.FileName = "adb";
            adbProcess.StartInfo.Arguments = "shell dumpsys battery";
            adbProcess.StartInfo.UseShellExecute = false;
            adbProcess.StartInfo.RedirectStandardOutput = true;
            adbProcess.StartInfo.CreateNoWindow = true;

            // Start the process and read the output
            adbProcess.Start();
            string output = adbProcess.StandardOutput.ReadToEnd();

            // Wait for the process to exit
            adbProcess.WaitForExit();

            // Parse the output to get the battery level
            string[] lines = output.Split('\n');
            foreach (string line in lines)
            {
                if (line.Contains("level:"))
                {
                    string level = line.Split(':')[1].Trim();
                    Console.WriteLine("Battery level: " + level + "%");
                    return level;
                    break;
                }
            }
            return "";
        }

        private string productModel()
        {
            // Get Product.model via wired ADB
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("adb.exe", "shell getprop ro.product.model");
                startInfo.RedirectStandardOutput = true;
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardOutput = true;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                StreamWriter writer = process.StandardInput;
                StreamReader reader = process.StandardOutput;
                string output = reader.ReadLine();
                writer.Close();
                process.WaitForExit();
                return output;
            }
            catch
            {

                return "";
            }

        }

        private void bitrateAuto_Click(object sender, EventArgs e)
        {
            SetBitrate(0);
            if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Set encode bitrate to automatic.", ToolTipIcon.Info); }
        }
        private void bitrate500_Click(object sender, EventArgs e)
        {
            SetBitrate(500);
            if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Set encode bitrate to 500 mbps", ToolTipIcon.Info); }
        }

        private void bitrate450_Click(object sender, EventArgs e)
        {
            SetBitrate(450);
            if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Set encode bitrate to 450 mbps", ToolTipIcon.Info); }
        }
        private void bitrate400_Click(object sender, EventArgs e)
        {
            SetBitrate(400);
            if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Set encode bitrate to 400 mbps", ToolTipIcon.Info); }
        }

        private void bitrate350_Click(object sender, EventArgs e)
        {
            SetBitrate(350);
            if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Set encode bitrate to 350 mbps", ToolTipIcon.Info); }
        }

        private void bitrate300_Click(object sender, EventArgs e)
        {
            SetBitrate(300);
            if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Set encode bitrate to 300 mbps", ToolTipIcon.Info); }
        }

        private void bitrate250_Click(object sender, EventArgs e)
        {
            SetBitrate(250);
            if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Set encode bitrate to 250 mbps", ToolTipIcon.Info); }
        }

        private void bitrate200_Click(object sender, EventArgs e)
        {
            SetBitrate(200);
            if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Set encode bitrate to 200 mbps", ToolTipIcon.Info); }
        }

        private void bitrate150_Click(object sender, EventArgs e)
        {
            SetBitrate(150);
            if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Set encode bitrate to 150 mbps", ToolTipIcon.Info); }
        }

        private void bitrate100_Click(object sender, EventArgs e)
        {
            SetBitrate(100);
            if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Set encode bitrate to 100 mbps", ToolTipIcon.Info); }
        }

        private void bitrate960_Click(object sender, EventArgs e)
        {
            SetBitrate(960);
            if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Set encode bitrate to 960 mbps", ToolTipIcon.Info); }
        }
        public void SetBitrate(int mbps)
        {
            Bitrate = mbps;
            try
            {
                if (Bitrate == 0)
                {
                    registryKey.DeleteValue("BitrateMbps");
                    bitrateDisplayBox.Text = ("Current: Auto");
                    NinsTool.Properties.Settings.Default.bitrateMbps = mbps;
                    NinsTool.Properties.Settings.Default.Save();
                    return;
                }
                registryKey.SetValue("BitrateMbps", mbps, RegistryValueKind.DWord);
            }
            catch
            {
                //notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "There was an error setting registry values!", ToolTipIcon.Error);
                return;
            }
            bitrateDisplayBox.Text = ("Current: " + Convert.ToString(Bitrate) + " mbps");
            NinsTool.Properties.Settings.Default.bitrateMbps = mbps;
            NinsTool.Properties.Settings.Default.Save();
            if (mbps >= 201 && ConnectedViaWifi) { if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool | Warning", "Bitrates over 200mbps on Airlink may cause lag", ToolTipIcon.Error); } }
            if (mbps >= 201 && btnForceHEVC.Checked) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool | Warning", "Bitrates over 200mbps using HEVC will cause lag!", ToolTipIcon.Error); }
        }


        private void GetCurrentValues()
        {
            btnAutoLaunchSteamVR.Checked = NinsTool.Properties.Settings.Default.autoLaunchSteamVR;
            try
            {
                if (NinsTool.Properties.Settings.Default.Notifications == true)
                {
                    notifs = true;
                    rdNotifOn.Checked = true;
                    rdNotifOff.Checked = false;
                    aboutBtnNotifications.Checked = true;
                }
                else
                {
                    notifs = false;
                    rdNotifOn.Checked = false;
                    rdNotifOff.Checked = true;
                }
                chkCheckForUpdates.Checked = NinsTool.Properties.Settings.Default.CheckForUpdates;
            }
            catch
            {
                notifs = true;
                rdNotifOn.Checked = true;
                rdNotifOff.Checked = false;
                NinsTool.Properties.Settings.Default.Notifications = true;
            } // Apply notification settings from app settings
            // Getting oculus link bitrate
            Bitrate = Convert.ToInt32(registryKey.GetValue("BitrateMbps", null));
            if (Bitrate == null | Bitrate == 0)
            {
                bitrateDisplayBox.Text = ("Current: Auto");
            }
            else
            {
                bitrateDisplayBox.Text = ("Current: " + Convert.ToString(Bitrate));
            }
            
            // MessageBox.Show("Bitrate:" + Convert.ToString(Bitrate), "");

            // Getting ASW state


            // Check local dimming state
            try
            {
                if (Convert.ToString(registryKey.GetValue("LocalDimming", null)) == "1")
                {
                    localDimmingState = true;
                    btnDimOn.Checked = true;
                }
                else
                {
                    localDimmingState = false;
                    btnDimOff.Checked = true;
                }
            }
            catch (Exception ex)
            {

            }

            // Check Sliced Encoding state
            try
            {
                if (registryKey.GetValue("numSlices", null) == null)
                {
                    slicedEncodingState = true;
                    btnSliceOn.Checked = true;
                }
                else
                {
                    slicedEncodingState = false;
                    btnSliceOff.Checked = true;
                }
            }
            catch
            {

            }

            // Check Notification Settings


            // Check startup status
            if (startupKey.GetValue("Nin's Tool", null) == null)
            {
                btnAutoLaunchDisable.Checked = true;
            }
            else
            {
                btnAutoLaunchEnable.Checked = true;
            }

            // Check force h264 status
            string hevcValue = Convert.ToString(registryKey?.GetValue("HEVC"));
            if (hevcValue != null)
            {
                switch (hevcValue)
                {
                    case "0":
                        btnForce264.Checked = true;
                        btnCodecAuto.Checked = false;
                        btnForceHEVC.Checked = false;
                        break;
                    case "1":
                        btnForce264.Checked = false;
                        btnCodecAuto.Checked = false;
                        btnForceHEVC.Checked = true;
                        break;
                    default:
                        btnForce264.Checked = false;
                        btnCodecAuto.Checked = true;
                        btnForceHEVC.Checked = false;
                        break;
                }
            }
            else
            {
                // Handle the case when the registry value is null
                btnForce264.Checked = false;
                btnCodecAuto.Checked = true;
                btnForceHEVC.Checked = false;
            }

            //get proximity sensor state
            ProxSensorHandler prox = new ProxSensorHandler();
            if (NinsTool.Properties.Settings.Default.proxSensor)
            {
                prox.sensorOn();
                proxDisable.Checked = false;
                proxEnable.Checked = true;
            }
            else
            {
                prox.sensorOff();
                proxDisable.Checked = true;
                proxEnable.Checked = false;
            }

            NinsTool.Properties.Settings.Default.Save();
        }

        private void btnASWAuto_Click(object sender, EventArgs e)
        {
            setASW(true);
            if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Set ASW to Auto.", ToolTipIcon.Info); }
        }

        private void btnASWOff_Click(object sender, EventArgs e)
        {
            setASW(false);
            if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Set ASW to Disabled.", ToolTipIcon.Info); }
        }

        private void btnDimOn_Click(object sender, EventArgs e)
        {

            btnDimOn.Checked = true;
            btnDimOff.Checked = false;
            try
            {
                SetLocalDimming(true);
            }
            catch
            {
                MessageBox.Show("Error", "There was an error setting registry values");
                return;
            }
        }

        private void btnDimOff_Click(object sender, EventArgs e)
        {
            try
            {
                SetLocalDimming(false);
            }
            catch
            {
                MessageBox.Show("Error", "There was an error setting registry values");
                return;
            }
            btnDimOn.Checked = false;
            btnDimOff.Checked = true;
        }

        public void setASW(bool state)
        {
            if (state == true)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("OculusDebugToolCLI.exe", "-f aswAuto.txt");
                startInfo.CreateNoWindow = true;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                //process.WaitForExit();
                Form1.aswState = "auto";
                btnASWAuto.Checked = true;
                btnASWOff.Checked = false;
                System.Threading.Thread.Sleep(300);
                try { process.Kill(); } catch { }
            }
            else
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("OculusDebugToolCLI.exe", "-f aswOff.txt");
                startInfo.CreateNoWindow = true;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                //process.WaitForExit();
                btnASWAuto.Checked = false;
                btnASWOff.Checked = true;
                Form1.aswState = "off";
                System.Threading.Thread.Sleep(300);
                try { process.Kill(); } catch { }
            }
            NinsTool.Properties.Settings.Default.aswMode = state;

            NinsTool.Properties.Settings.Default.Save();

        }

        public void SetLocalDimming(bool state)
        {
            if (state == true)
            {
                registryKey.SetValue("LocalDimming", "1", RegistryValueKind.DWord);
                if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Enabled Local Dimming.", ToolTipIcon.Info); }
            }
            else
            {
                if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Disabled Local Dimming.", ToolTipIcon.Info); }
                registryKey.SetValue("LocalDimming", "0", RegistryValueKind.DWord);
            }
        }

        private void btnSliceOn_Click(object sender, EventArgs e)
        {
            setSlicedEncoding(true);
            btnSliceOn.Checked = true;
            btnSliceOff.Checked = false;
        }

        private void btnSliceOff_Click(object sender, EventArgs e)
        {
            setSlicedEncoding(false);
            btnSliceOn.Checked = false;
            btnSliceOff.Checked = true;
        }

        public void setSlicedEncoding(bool state)
        {
            if (state == true)
            {
                registryKey.DeleteValue("numSlices");
                if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Enabled sliced encoding.", ToolTipIcon.Info); }
                slicedEncodingState = false;
            }
            else
            {
                if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Disabled sliced encoding.", ToolTipIcon.Info); }
                registryKey.SetValue("numSlices", "1", RegistryValueKind.DWord);
                slicedEncodingState = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want exit?\nNin's Tool needs to be running to work!", "Nin's Tool", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                killADBServer();
                Environment.Exit(0);
            }

        }

        private void btnAutoLaunchEnable_Click(object sender, EventArgs e)
        {

            createStartupEntry();

        }

        private void CheckForLink(object state)
        {

            applySettings();

        }
        public void applySettings()
        {
            notifyIcon1.Visible = true;
            //notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "Oculus Link started. Applying saved settings...", ToolTipIcon.Info);
            try
            {
                bool state = NinsTool.Properties.Settings.Default.aswMode;
                setASW(state);
            }
            catch
            {
                
            }
            try
            {
                brightPercent.setBrightness(this);
                setOVRPriority(NinsTool.Properties.Settings.Default.ProcessPriority, true);
                SetBitrate(NinsTool.Properties.Settings.Default.bitrateMbps);
                setGuardian(NinsTool.Properties.Settings.Default.Guardian, true);
                setLinkSharpening(NinsTool.Properties.Settings.Default.sharpening, true);
                ProxSensorHandler prox = new ProxSensorHandler();
                if (NinsTool.Properties.Settings.Default.proxSensor)
                {
                    prox.sensorOn();
                }
                else
                {
                    prox.sensorOff();
                }
            }
            catch
            {

            }
        }
        public string GetBrightnessComboBoxText()
        {
            return brightnessComboBox.Text;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            applySettings();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            //this.Visible = true;
            //this.Opacity = 100;
            //this.Show();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void createStartupEntry()
        {
            string appName = "Nin's Tool";
            string appPath = Assembly.GetExecutingAssembly().Location;

            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue(appName, appPath);
            notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "Tool will now launch and apply settings at startup.", ToolTipIcon.Info);
            btnAutoLaunchEnable.Checked = true;
            btnAutoLaunchDisable.Checked = false;
        }

        private void btnAutoLaunchDisable_Click(object sender, EventArgs e)
        {
            string appName = "Nin's Tool";

            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.DeleteValue(appName, false);
            notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "Tool will no longer launch at startup.", ToolTipIcon.Info);
            btnAutoLaunchEnable.Checked = false;
            btnAutoLaunchDisable.Checked = true;
        }

        private void rdNotifOn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNotifOn.Checked == true)
            {
                notifs = true;
                NinsTool.Properties.Settings.Default.Notifications = true;
            }
            else
            {
                notifs = false;
                NinsTool.Properties.Settings.Default.Notifications = false;
            }
            NinsTool.Properties.Settings.Default.Save();
        }

        private void setGuardianOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setGuardian(true, false);
        }

        private void setGuardianOffToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            setGuardian(false, false);
        }

        private void setGuardian(bool state, bool silent)
        {
            ProcessStartInfo startInfo = null;
            if (state == true)
            {
                startInfo = new ProcessStartInfo("adb.exe", "shell setprop debug.oculus.guardian_pause 0");
            }
            else
            {
                startInfo = new ProcessStartInfo("adb.exe", "shell setprop debug.oculus.guardian_pause 1");

            }

            startInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            StreamWriter writer = process.StandardInput;
            StreamReader reader = process.StandardOutput;
            writer.Close();
            process.WaitForExit();

            if (!silent & Form1.notifs)
            {
                if (state == true)
                {
                    notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "Sent adb command to enable guardian.", ToolTipIcon.Info);
                }
                else
                {
                    notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "Sent adb command to disable guardian.", ToolTipIcon.Info);
                }

            }
            NinsTool.Properties.Settings.Default.Guardian = state;
            NinsTool.Properties.Settings.Default.Save();

        }



        public void activationUnlock()
        {
            enterGumroadKeyToolStripMenuItem.Visible = false;
            startWatcher();
            txtRegTo.Text = "Registered To:  " + NinsTool.Properties.Settings.Default.Email;
            txtEdition.Text = "Edition:  " + getEdition(NinsTool.Properties.Settings.Default.PricePaid);
            txtLicKey.Text = "Key:  " + hideLicense(NinsTool.Properties.Settings.Default.Key);

            aboutRegTo.Text = "Registered To:  " + NinsTool.Properties.Settings.Default.Email;
            aboutEdition.Text = "Edition:  " + getEdition(NinsTool.Properties.Settings.Default.PricePaid);
            aboutLicKey.Text = "Key:  " + hideLicense(NinsTool.Properties.Settings.Default.Key);

            localDimmingToolStripMenuItem.Enabled = true;
            slicedEncodingToolStripMenuItem.Enabled = true;
            mnuGuardian.Enabled = true;
            autoLaunchToolStripMenu.Enabled = true;
            serverPriorityMenu.Enabled = true;
            mnuScreenBrightness.Enabled = true;
            btnOculusRestart.Enabled = true;
            button1.Enabled = false; //Enter key button on about page
            mnuCodec.Enabled = true;
            mnuSharpening.Enabled = true;
            proxMenu.Enabled = true;
            btnAutoLaunchSteamVR.Enabled = true;
        }

        private string getEdition(int price)
        {
            if (price == 0)
            {
                return "Giveaway";
            }
            else
            {
                return "Supporter";
            }
        }
        private string hideLicense(string key)
        {
            string[] quartets = key.Split('-');
            string newLicenseKey = quartets[0] + "-" + quartets[1] + "-********-********";
            return newLicenseKey;
        }

        private void startWatcher()
        {
            // Create a new management scope object with the root namespace
            var scope = new ManagementScope(@"\\.\root\cimv2");
            // Create a new object query for process creation events
            var query = new ObjectQuery("SELECT * FROM __InstanceCreationEvent WITHIN 10 WHERE TargetInstance ISA 'Win32_Process' AND TargetInstance.Name = 'OculusDash.exe'");
            // Create a new management object searcher with the scope and query
            var searcher = new ManagementObjectSearcher(scope, query);
            // Subscribe to the event using the callback method
            var watcher = new ManagementEventWatcher();
            watcher.EventArrived += OnProcessStart;
            // Start watching for the event
            watcher.Query = new EventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 10 WHERE TargetInstance ISA 'Win32_Process' AND TargetInstance.Name = 'OculusDash.exe'");
            watcher.Start();
            // Define a callback method that runs when the event occurs
            void OnProcessStart(object sender, EventArrivedEventArgs e)
            {
                // Get the process object from the event arguments
                var process = (ManagementBaseObject)e.NewEvent["TargetInstance"];
                // Print some information about the process
                //Console.WriteLine("Process {0} started at {1}", process["Name"], process["CreationDate"]);
                // Run your code here
                if (notifs) { notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "Oculus Link started. Applying settings...", ToolTipIcon.Info); }
                System.Threading.Thread.Sleep(5000);
                applySettings();
                connectQuestWirelessly();
                setToolTip();
                
                startExitWatcher();
                //startCustomApps();
                if (NinsTool.Properties.Settings.Default.autoLaunchSteamVR && activated)
                {
                    Process.Start("steam://rungameid/250820");
                }
                BeginInvoke(new Action(startTimer));
            }
        }

        private void startTimer()
        {
            BeginInvoke(new Action(timer1.Start));
        }

        private void startCustomApps()
        {
            CustomAppStarter cas = new CustomAppStarter();
            cas.startCustomApps();

        }

        private void startExitWatcher()
        {
            // Create a new management scope object with the root namespace
            var scope = new ManagementScope(@"\\.\root\cimv2");

            // Create a new object query for process deletion events
            var query = new ObjectQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 10 WHERE TargetInstance ISA 'Win32_Process' AND TargetInstance.Name = 'OculusDash.exe'");

            // Create a new management object searcher with the scope and query
            var searcher = new ManagementObjectSearcher(scope, query);

            // Subscribe to the event using the callback method
            var exitwatcher = new ManagementEventWatcher();
            exitwatcher.EventArrived += OnProcessStop;

            // Start watching for the event
            exitwatcher.Query = new EventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 10 WHERE TargetInstance ISA 'Win32_Process' AND TargetInstance.Name = 'OculusDash.exe'");
            exitwatcher.Start();

            // Define a callback method that runs when the event occurs
            void OnProcessStop(object sender, EventArrivedEventArgs e)
            {
                // Get the process object from the event arguments
                var process = (ManagementBaseObject)e.NewEvent["TargetInstance"];
                // Print some information about the process
                //Console.WriteLine("Process {0} stopped at {1}", process["Name"], process["CreationDate"]);
                // Run your code here
                if (notifs) { notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "Oculus Link has stopped.", ToolTipIcon.None); }
                timer1.Enabled = false;
                exitwatcher.Stop();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            e.Cancel = true;
            this.Visible = false;
        }
        private void trayMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (dontCloseMenu)
            {
                e.Cancel = true;
            }
        }
        private void btnOculusRestart_Click(object sender, EventArgs e)
        {
            dontCloseMenu = false;
            if (btnOculusRestart.Text == "Are you sure?")
            {

                btnOculusRestart.Text = "Restart Oculus Service";
                restartOculusService();
                return;
            }
            btnOculusRestart.Text = "Are you sure?";

        }

        private void restartOculusService()
        {
            Process stopProcess = new Process();
            stopProcess.StartInfo.FileName = "net";
            stopProcess.StartInfo.Arguments = "stop OVRService";
            stopProcess.StartInfo.UseShellExecute = false;
            stopProcess.StartInfo.CreateNoWindow = true;

            // Start the process and wait for it to exit
            stopProcess.Start();
            stopProcess.WaitForExit();

            // Create a process to start the Oculus Service
            Process startProcess = new Process();
            startProcess.StartInfo.FileName = "net";
            startProcess.StartInfo.Arguments = "start OVRService";
            startProcess.StartInfo.UseShellExecute = false;
            startProcess.StartInfo.CreateNoWindow = true;

            // Start the process and wait for it to exit
            startProcess.Start();
            startProcess.WaitForExit();

            // Create a process to kill OculusClient.exe
            Process killClientProcess = new Process();
            killClientProcess.StartInfo.FileName = "taskkill";
            killClientProcess.StartInfo.Arguments = "/F /IM OculusClient.exe";
            killClientProcess.StartInfo.UseShellExecute = false;
            killClientProcess.StartInfo.CreateNoWindow = true;

            // Start the process and wait for it to exit
            killClientProcess.Start();
            killClientProcess.WaitForExit();

            // Create a process to kill OVRServer_x64.exe
            Process killServerProcess = new Process();
            killServerProcess.StartInfo.FileName = "taskkill";
            killServerProcess.StartInfo.Arguments = "/F /IM OVRServer_x64.exe";
            killServerProcess.StartInfo.UseShellExecute = false;
            killServerProcess.StartInfo.CreateNoWindow = true;

            // Start the process and wait for it to exit
            killServerProcess.Start();
            killServerProcess.WaitForExit();

            // Print a message to indicate success
            if (notifs) { notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "Restarted Oculus Serice", ToolTipIcon.Info); }


        }

        private void btnOculusRestart_MouseDown(object sender, MouseEventArgs e)
        {
            dontCloseMenu = true;
        }

        private void highToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setOVRPriority("high", false);
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setOVRPriority("normal", false);
        }

        private void setOVRPriority(string prio, bool silent)
        {
            Process[] processes = Process.GetProcessesByName("OVRServer_x64");

            if (processes.Length > 0)
            {
                Process process = processes[0];

                switch (prio)
                {
                    case "high":
                        process.PriorityClass = ProcessPriorityClass.High;
                        highToolStripMenuItem.Checked = true;
                        normalToolStripMenuItem.Checked = false;
                        break;
                    case "normal":
                        process.PriorityClass = ProcessPriorityClass.Normal;
                        highToolStripMenuItem.Checked = false;
                        normalToolStripMenuItem.Checked = true;
                        break;
                    default:
                        if (!silent) MessageBox.Show("Invalid priority level specified.");
                        break;
                }
            }
            if (!silent)
            {
                if (notifs) { notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "Set OVR process priority to " + prio, ToolTipIcon.Info); }
            }
            NinsTool.Properties.Settings.Default.ProcessPriority = prio;
            NinsTool.Properties.Settings.Default.Save();
        }
        public static long PingHost(string nameOrAddress)
        {
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                if (reply.Status == IPStatus.Success)
                {
                    return reply.RoundtripTime;
                }
            }
            catch (PingException)
            {
                // Discard PingExceptions and return null
            }
            return -1;
        }

        private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://ninka.gumroad.com/l/NinsTool");
        }

        private void btnAboutPageClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void enterGumroadKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form KeyForm = new KeyEnterForm();
            KeyForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form KeyForm = new KeyEnterForm();
            KeyForm.Show();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                System.Reflection.MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                mi.Invoke(notifyIcon1, null);
            }
        }




        private void updateNotifMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://nin.wtf/NinsTool/Nins_Tool_Installer.exe");
        }

        public bool CheckForUpdates()
        {
            bool isUpdateAvailable = false;
            string versionUrl = "https://nin.wtf/NinsTool.txt";
            string latestVersionStr = "";

            try
            {
                using (WebClient client = new WebClient())
                {
                    // Download the version number from the URL
                    latestVersionStr = client.DownloadString(versionUrl);
                }

                // Convert the latest version string to a double
                double latestVersion = Convert.ToDouble(latestVersionStr.Trim());

                // Compare the latest version to the shortVersion boolean
                if (latestVersion > shortVersion)
                {
                    isUpdateAvailable = true;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the version check
                // Console.WriteLine("Error checking for updates: " + ex.Message);
            }

            return isUpdateAvailable;
        }

        private void chkCheckForUpdates_CheckedChanged(object sender, EventArgs e)
        {
            NinsTool.Properties.Settings.Default.CheckForUpdates = chkCheckForUpdates.Checked;
            NinsTool.Properties.Settings.Default.Save();
        }

        private void watcher_Tick(object sender, EventArgs e)
        {
            setToolTip(); 
            applySettings();
        }

        private void btnForce264_Click(object sender, EventArgs e)
        {
            try
            {
                registryKey.SetValue("HEVC", "0", RegistryValueKind.DWord);
            }
            catch
            {
                return;
            }
            btnForce264.Checked = true;
            btnForceHEVC.Checked = false;
            btnCodecAuto.Checked = false;


            if (notifs) { notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "H.264 is now forced.", ToolTipIcon.Info); }

        }

        private void btnForceHEVC_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("HEVC at bitrates over 200mbps can cause latency problems.\nAre you sure you want to proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.No)
            {
                return;
            }
            else if (result == DialogResult.Yes)
            {
                try
                {
                    registryKey.SetValue("HEVC", "1", RegistryValueKind.DWord);
                }
                catch
                {
                    return;
                }
                btnForceHEVC.Checked = true;
                btnCodecAuto.Checked = false;
                btnForce264.Checked = false;


                if (notifs) { notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "HEVC is now forced.", ToolTipIcon.Info); }
            }

        }

        private void btnCodecAuto_Click(object sender, EventArgs e)
        {
            try
            {
                registryKey.DeleteValue("HEVC");
            }
            catch
            {
                return;
            }
            btnCodecAuto.Checked = true;
            btnForce264.Checked = false;
            btnForceHEVC.Checked = false;



            if (notifs) { notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "Codec set to auto.", ToolTipIcon.Info); }
        }

        private void btnAbout264_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Oculus Link encodes video in H.264 \n" +
                "AirLink encodes video in H.265 (aka HEVC) \n" +
                "\n" +
                "H.265 uses a lot of resources to decode on quest \n" +
                "so forcing H.264 for airlink will allow you to \n" +
                "stream at bitrates much greater than 200 mbps.\n" +
                "\n" +
                "Running at over 200 mbps on H.265 will cause latency\n" +
                "issues because of the time it takes to decode the video.", "About H.264", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnModMenu_Click(object sender, EventArgs e)
        {
            Form Mod = new ModsForm();
            Mod.Show();
        }

        private void btnBattery_Click(object sender, EventArgs e)
        {
            killADBServer();
            if (headsetModel == "No Headset")
            {
                connectQuestWirelessly();
            }
            setToolTip();
        }
        private void killADBServer()
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("adb.exe", "disconnect");
                startInfo.RedirectStandardOutput = true;
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardOutput = true;
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
            }
            catch
            {
                Process[] processes = Process.GetProcessesByName("adb");

                foreach (Process process in processes)
                {
                    if (!process.HasExited)
                    {
                        process.Kill();
                        process.WaitForExit();
                        //Console.WriteLine("adb.exe process killed.");
                    }
                }
            }
        }

        private void btnSharpeningOn_Click(object sender, EventArgs e)
        {
            // Normal
            setLinkSharpening("normal", false);
        }

        private void btnSharpeningOff_Click(object sender, EventArgs e)
        {
            // Disabled
            setLinkSharpening("disabled", false);
        }

        private void btnSharpeningQuality_Click(object sender, EventArgs e)
        {
            // Quality
            setLinkSharpening("quality", false);
        }

        private void setLinkSharpening(string state, bool silent)
        {
            // Auto = no reg key
            // Disabled = 1
            // Enabled = 2
            //

            // Normal = 2
            // Disabled = 1
            // Quality = 3

            // LinkSharpeningEnabled

            try
            {
                if (state == "normal")
                {
                    registryKey.SetValue("LinkSharpeningEnabled", "2", RegistryValueKind.DWord);
                    btnSharpeningQuality.Checked = false;
                    btnSharpeningOff.Checked = false;
                    btnSharpeningOn.Checked = true;
                    if (!silent & notifs)
                    {
                        notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "Set Link Sharpening to Normal.", ToolTipIcon.Info);
                    }
                }
                else if (state == "disabled")
                {
                    registryKey.SetValue("LinkSharpeningEnabled", "1", RegistryValueKind.DWord);
                    btnSharpeningQuality.Checked = false;
                    btnSharpeningOff.Checked = true;
                    btnSharpeningOn.Checked = false;
                    if (!silent & notifs)
                    {
                        notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "Disabled link sharpening.", ToolTipIcon.Info);
                    }
                }
                else if (state == "quality")
                {
                    registryKey.SetValue("LinkSharpeningEnabled", "3", RegistryValueKind.DWord);
                    btnSharpeningQuality.Checked = true;
                    btnSharpeningOff.Checked = false;
                    btnSharpeningOn.Checked = false;
                    if (!silent & notifs)
                    {
                        notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "Set Link Sharpening to Quality.", ToolTipIcon.Info);
                    }
                }
                else
                {
                    registryKey.SetValue("LinkSharpeningEnabled", "1", RegistryValueKind.DWord);
                    btnSharpeningQuality.Checked = false;
                    btnSharpeningOff.Checked = true;
                    btnSharpeningOn.Checked = false;
                }

                NinsTool.Properties.Settings.Default.sharpening = state;
                NinsTool.Properties.Settings.Default.Save();
            }
            catch
            {
                notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "There was an error setting registry values!", ToolTipIcon.Error);
                NinsTool.Properties.Settings.Default.sharpening = state;
                NinsTool.Properties.Settings.Default.Save();
                return;
            }


        }

        private void aboutLicKey_MouseDown(object sender, MouseEventArgs e)
        {
            aboutLicKey.Text = "Key: " + NinsTool.Properties.Settings.Default.Key;
        }

        private void aboutLicKey_MouseUp(object sender, MouseEventArgs e)
        {
            aboutLicKey.Text = "Key: " + hideLicense(NinsTool.Properties.Settings.Default.Key);
        }

        private void aboutBtnNotifications_Click(object sender, EventArgs e)
        {
            aboutBtnNotifications.Checked = !aboutBtnNotifications.Checked;
            if (notifs)
            {
                notifs = false;
                NinsTool.Properties.Settings.Default.Notifications = false;
            }
            else
            {
                notifs = true;
                NinsTool.Properties.Settings.Default.Notifications = true;
            }
            NinsTool.Properties.Settings.Default.Save();
        }

        private void aboutBtnUpdateCheck_Click(object sender, EventArgs e)
        {
            NinsTool.Properties.Settings.Default.CheckForUpdates = !aboutBtnUpdateCheck.Checked;
            NinsTool.Properties.Settings.Default.Save();
            aboutBtnUpdateCheck.Checked = !aboutBtnUpdateCheck.Checked;
        }

        private void btnAutoLaunchSteamVR_Click(object sender, EventArgs e)
        {
            NinsTool.Properties.Settings.Default.autoLaunchSteamVR = !btnAutoLaunchSteamVR.Checked;
            btnAutoLaunchSteamVR.Checked = !btnAutoLaunchSteamVR.Checked;
            NinsTool.Properties.Settings.Default.Save();
            //Process.Start("steam://rungameid/250820");
        }

        private void aboutRegTo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to remove your license data?\nYou can re-activate any time.", "Delete license data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                NinsTool.Properties.Settings.Default.Email = "";
                NinsTool.Properties.Settings.Default.Key = "";
                NinsTool.Properties.Settings.Default.Enable = false;
                NinsTool.Properties.Settings.Default.PricePaid = 0;
                NinsTool.Properties.Settings.Default.Save();
                System.Threading.Thread.Sleep(500);
                //btnReg.Enabled = true;
                Process.Start(Application.ExecutablePath);
                Process.GetCurrentProcess().Kill();
            }
        }

        private void proxEnable_Click(object sender, EventArgs e)
        {
            ProxSensorHandler prox = new ProxSensorHandler();
            prox.sensorOn();
            NinsTool.Properties.Settings.Default.proxSensor = true;
            NinsTool.Properties.Settings.Default.Save();
            proxEnable.Checked = true;
            proxDisable.Checked = false;
            if (notifs == true)
            {
                notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "Enabled proximity sensor.", ToolTipIcon.Info);
            }
        }

        private void proxDisable_Click(object sender, EventArgs e)
        {
            ProxSensorHandler prox = new ProxSensorHandler();
            prox.sensorOff();
            NinsTool.Properties.Settings.Default.proxSensor = false;
            NinsTool.Properties.Settings.Default.Save();
            proxEnable.Checked = false;
            proxDisable.Checked = true;
            if (notifs == true)
            {
                notifyIcon1.ShowBalloonTip(3000, "Nin's Tool", "Disabled proximity sensor.", ToolTipIcon.Info);
            }
        }

        private void btnOpenCustomApps_Click(object sender, EventArgs e)
        {
            string folderPath = @".\AutoLaunchApps";
            System.Diagnostics.Process.Start("explorer.exe", folderPath);
            MessageBox.Show("Put shortcuts to apps in this folder that you want to auto-start.\nWhen Link starts, Nin's Tool will automatically launch each app you created a shortcut to.", "Auto Launch Apps");
        }

        private void btnHud1_Click(object sender, EventArgs e)
        {
            perfHud(1);
        }

        private void btnHud2_Click(object sender, EventArgs e)
        {
            perfHud(2);
        }

        private void btnHud3_Click(object sender, EventArgs e)
        {
            perfHud(3);
        }

        private void btnHud4_Click(object sender, EventArgs e)
        {
            perfHud(4);
        }

        private void btnHud7_Click(object sender, EventArgs e)
        {
            perfHud(7);
        }

        private void btnHud8_Click(object sender, EventArgs e)
        {
            perfHud(8);
        }

        private void btnHud0_Click(object sender, EventArgs e)
        {
            perfHud(0);
        }

        private void perfHud(int num)
        {
            ToolStripMenuItem[] btnHudButtons = new ToolStripMenuItem[] { btnHud0, btnHud1, btnHud2, btnHud3, btnHud4, null, null, btnHud7, btnHud8 };

            // Clear all buttons' Checked state
            foreach (ToolStripMenuItem button in btnHudButtons)
            {
                if (button != null)
                {
                    button.Checked = false;
                }
            }
            if (num >= 0 && num < btnHudButtons.Length && btnHudButtons[num] != null)
            {
                btnHudButtons[num].Checked = true;
            }

            performanceHud performanceHud = new performanceHud();
            performanceHud.setHud(num);
        }

      

        private void btnStartWiredLink_Click(object sender, EventArgs e)
        {
            sendADBcommand("shell am broadcast -a 'com.oculus.systemux.action.TOGGLE_AIRLINK' --ez enable_airlink 0");
            System.Threading.Thread.Sleep(300);
            startLink();
            if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Sent command to start Link...", ToolTipIcon.Info); }
        }

        private void btnStartAirlink_Click(object sender, EventArgs e)
        {
            sendADBcommand("shell am broadcast -a 'com.oculus.systemux.action.TOGGLE_AIRLINK' --ez enable_airlink 1");
            System.Threading.Thread.Sleep(300);
            startLink();
            if (notifs == true) { notifyIcon1.ShowBalloonTip(1500, "Nin's Tool", "Sent command to start AirLink...", ToolTipIcon.Info); }
        }

        private void startLink()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("adb.exe", "shell am start -S com.oculus.xrstreamingclient/.MainActivity");
            startInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

        public static void sendADBcommand(string command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("adb.exe", command);
            startInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
        


        private async void brightnessComboBox_DropDownClosed_1(object sender, EventArgs e)
        {
            await Task.Delay(100);
            brightPercent.setBrightness(this);
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            BeginInvoke(new Action(applySettings));
            await Task.Delay(300);
            BeginInvoke(new Action(setToolTip));
        }
    }
}
