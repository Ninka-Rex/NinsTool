using System.Windows.Forms;

namespace TrayBuddy
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.watcherTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateNotifMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.txtHeadset = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBattery = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCtrlBattery = new System.Windows.Forms.ToolStripMenuItem();
            this.warningRoomDark = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuStartLink = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStartWiredLink = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStartAirlink = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOculusRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.serverPriorityMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.highToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHud = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHud1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHud2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHud3 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHud4 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHud7 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHud8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.btnHud0 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnModMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuBitrate = new System.Windows.Forms.ToolStripMenuItem();
            this.bitrateDisplayBox = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bitrate500 = new System.Windows.Forms.ToolStripMenuItem();
            this.bitrate450 = new System.Windows.Forms.ToolStripMenuItem();
            this.bitrate400 = new System.Windows.Forms.ToolStripMenuItem();
            this.bitrate350 = new System.Windows.Forms.ToolStripMenuItem();
            this.bitrate300 = new System.Windows.Forms.ToolStripMenuItem();
            this.bitrate250 = new System.Windows.Forms.ToolStripMenuItem();
            this.bitrate200 = new System.Windows.Forms.ToolStripMenuItem();
            this.bitrate150 = new System.Windows.Forms.ToolStripMenuItem();
            this.bitrate100 = new System.Windows.Forms.ToolStripMenuItem();
            this.bitrateAuto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bitrate960 = new System.Windows.Forms.ToolStripMenuItem();
            this.aSWModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnASWAuto = new System.Windows.Forms.ToolStripMenuItem();
            this.btnASWOff = new System.Windows.Forms.ToolStripMenuItem();
            this.localDimmingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDimOn = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDimOff = new System.Windows.Forms.ToolStripMenuItem();
            this.slicedEncodingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSliceOn = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSliceOff = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.wiredLinkOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSharpening = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSharpeningOff = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSharpeningOn = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSharpeningQuality = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGuardian = new System.Windows.Forms.ToolStripMenuItem();
            this.setGuardianOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setGuardianOffToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCodec = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnForce264 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnForceHEVC = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCodecAuto = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAbout264 = new System.Windows.Forms.ToolStripMenuItem();
            this.proxMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.proxEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.proxDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScreenBrightness = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.autoLaunchToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAutoLaunchEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAutoLaunchDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAutoLaunchSteamVR = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenCustomApps = new System.Windows.Forms.ToolStripMenuItem();
            this.enterGumroadKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutRegTo = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutLicKey = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutEdition = new System.Windows.Forms.ToolStripMenuItem();
            this.divide = new System.Windows.Forms.ToolStripSeparator();
            this.aboutVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutAuthor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutBtnNotifications = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutBtnUpdateCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEdition = new System.Windows.Forms.Label();
            this.txtLicKey = new System.Windows.Forms.Label();
            this.txtRegTo = new System.Windows.Forms.Label();
            this.lblLink = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdNotifOn = new System.Windows.Forms.RadioButton();
            this.rdNotifOff = new System.Windows.Forms.RadioButton();
            this.btnAboutPageClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chkCheckForUpdates = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trayMenu1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // watcherTimer
            // 
            this.watcherTimer.Interval = 1000;
            this.watcherTimer.Tick += new System.EventHandler(this.watcher_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.trayMenu1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Nin\'s Tool";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // trayMenu1
            // 
            this.trayMenu1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.trayMenu1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trayMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateNotifMenuItem,
            this.updateSeparator,
            this.txtHeadset,
            this.btnBattery,
            this.btnCtrlBattery,
            this.warningRoomDark,
            this.toolStripSeparator6,
            this.mnuStartLink,
            this.btnOculusRestart,
            this.serverPriorityMenu,
            this.mnuHud,
            this.btnModMenu,
            this.toolStripSeparator5,
            this.menuBitrate,
            this.aSWModeToolStripMenuItem,
            this.localDimmingToolStripMenuItem,
            this.slicedEncodingToolStripMenuItem,
            this.mnuSharpening,
            this.mnuGuardian,
            this.mnuCodec,
            this.proxMenu,
            this.mnuScreenBrightness,
            this.toolStripSeparator3,
            this.autoLaunchToolStripMenu,
            this.enterGumroadKeyToolStripMenuItem,
            this.btnAbout,
            this.btnExit});
            this.trayMenu1.Name = "trayMenu";
            this.trayMenu1.Size = new System.Drawing.Size(206, 556);
            this.trayMenu1.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.trayMenu_Closing);
            // 
            // updateNotifMenuItem
            // 
            this.updateNotifMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateNotifMenuItem.Image = global::NinsTool.Properties.Resources.information_2139_fe0f;
            this.updateNotifMenuItem.Name = "updateNotifMenuItem";
            this.updateNotifMenuItem.Size = new System.Drawing.Size(205, 22);
            this.updateNotifMenuItem.Text = "Update available!";
            this.updateNotifMenuItem.Visible = false;
            this.updateNotifMenuItem.Click += new System.EventHandler(this.updateNotifMenuItem_Click);
            // 
            // updateSeparator
            // 
            this.updateSeparator.Name = "updateSeparator";
            this.updateSeparator.Size = new System.Drawing.Size(202, 6);
            this.updateSeparator.Visible = false;
            // 
            // txtHeadset
            // 
            this.txtHeadset.Name = "txtHeadset";
            this.txtHeadset.Size = new System.Drawing.Size(205, 22);
            this.txtHeadset.Text = "No Headset Found";
            // 
            // btnBattery
            // 
            this.btnBattery.ForeColor = System.Drawing.Color.Lime;
            this.btnBattery.Image = global::NinsTool.Properties.Resources.battery;
            this.btnBattery.Name = "btnBattery";
            this.btnBattery.Size = new System.Drawing.Size(205, 22);
            this.btnBattery.Text = "Battery: ?";
            this.btnBattery.Click += new System.EventHandler(this.btnBattery_Click);
            // 
            // btnCtrlBattery
            // 
            this.btnCtrlBattery.ForeColor = System.Drawing.Color.Lime;
            this.btnCtrlBattery.Name = "btnCtrlBattery";
            this.btnCtrlBattery.Size = new System.Drawing.Size(205, 22);
            this.btnCtrlBattery.Text = "L: ? R: ?";
            // 
            // warningRoomDark
            // 
            this.warningRoomDark.Image = ((System.Drawing.Image)(resources.GetObject("warningRoomDark.Image")));
            this.warningRoomDark.Name = "warningRoomDark";
            this.warningRoomDark.Size = new System.Drawing.Size(205, 22);
            this.warningRoomDark.Text = "Room too dark!";
            this.warningRoomDark.Visible = false;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(202, 6);
            // 
            // mnuStartLink
            // 
            this.mnuStartLink.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartWiredLink,
            this.btnStartAirlink});
            this.mnuStartLink.Image = ((System.Drawing.Image)(resources.GetObject("mnuStartLink.Image")));
            this.mnuStartLink.Name = "mnuStartLink";
            this.mnuStartLink.Size = new System.Drawing.Size(205, 22);
            this.mnuStartLink.Text = "Start Link session...";
            // 
            // btnStartWiredLink
            // 
            this.btnStartWiredLink.Image = ((System.Drawing.Image)(resources.GetObject("btnStartWiredLink.Image")));
            this.btnStartWiredLink.Name = "btnStartWiredLink";
            this.btnStartWiredLink.Size = new System.Drawing.Size(180, 22);
            this.btnStartWiredLink.Text = "Start Link";
            this.btnStartWiredLink.Click += new System.EventHandler(this.btnStartWiredLink_Click);
            // 
            // btnStartAirlink
            // 
            this.btnStartAirlink.Image = ((System.Drawing.Image)(resources.GetObject("btnStartAirlink.Image")));
            this.btnStartAirlink.Name = "btnStartAirlink";
            this.btnStartAirlink.Size = new System.Drawing.Size(180, 22);
            this.btnStartAirlink.Text = "Start Airlink";
            this.btnStartAirlink.Click += new System.EventHandler(this.btnStartAirlink_Click);
            // 
            // btnOculusRestart
            // 
            this.btnOculusRestart.Enabled = false;
            this.btnOculusRestart.Image = global::NinsTool.Properties.Resources.restart;
            this.btnOculusRestart.Name = "btnOculusRestart";
            this.btnOculusRestart.Size = new System.Drawing.Size(205, 22);
            this.btnOculusRestart.Text = "Restart Oculus Service";
            this.btnOculusRestart.Click += new System.EventHandler(this.btnOculusRestart_Click);
            this.btnOculusRestart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOculusRestart_MouseDown);
            // 
            // serverPriorityMenu
            // 
            this.serverPriorityMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highToolStripMenuItem,
            this.normalToolStripMenuItem});
            this.serverPriorityMenu.Enabled = false;
            this.serverPriorityMenu.Image = global::NinsTool.Properties.Resources.fire;
            this.serverPriorityMenu.Name = "serverPriorityMenu";
            this.serverPriorityMenu.Size = new System.Drawing.Size(205, 22);
            this.serverPriorityMenu.Text = "OVR Server Priority";
            // 
            // highToolStripMenuItem
            // 
            this.highToolStripMenuItem.Name = "highToolStripMenuItem";
            this.highToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.highToolStripMenuItem.Text = "High";
            this.highToolStripMenuItem.Click += new System.EventHandler(this.highToolStripMenuItem_Click);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // mnuHud
            // 
            this.mnuHud.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHud1,
            this.btnHud2,
            this.btnHud3,
            this.btnHud4,
            this.btnHud7,
            this.btnHud8,
            this.toolStripSeparator13,
            this.btnHud0});
            this.mnuHud.Image = global::NinsTool.Properties.Resources.chart_increasing_1f4c8;
            this.mnuHud.Name = "mnuHud";
            this.mnuHud.Size = new System.Drawing.Size(205, 22);
            this.mnuHud.Text = "Performance HUD";
            // 
            // btnHud1
            // 
            this.btnHud1.Name = "btnHud1";
            this.btnHud1.Size = new System.Drawing.Size(234, 22);
            this.btnHud1.Text = "Performance Summary";
            this.btnHud1.Click += new System.EventHandler(this.btnHud1_Click);
            // 
            // btnHud2
            // 
            this.btnHud2.Name = "btnHud2";
            this.btnHud2.Size = new System.Drawing.Size(234, 22);
            this.btnHud2.Text = "Latency Timing";
            this.btnHud2.Click += new System.EventHandler(this.btnHud2_Click);
            // 
            // btnHud3
            // 
            this.btnHud3.Name = "btnHud3";
            this.btnHud3.Size = new System.Drawing.Size(234, 22);
            this.btnHud3.Text = "App Render Timing";
            this.btnHud3.Click += new System.EventHandler(this.btnHud3_Click);
            // 
            // btnHud4
            // 
            this.btnHud4.Name = "btnHud4";
            this.btnHud4.Size = new System.Drawing.Size(234, 22);
            this.btnHud4.Text = "Compositor Render Timing";
            this.btnHud4.Click += new System.EventHandler(this.btnHud4_Click);
            // 
            // btnHud7
            // 
            this.btnHud7.Name = "btnHud7";
            this.btnHud7.Size = new System.Drawing.Size(234, 22);
            this.btnHud7.Text = "Oculus Link";
            this.btnHud7.Click += new System.EventHandler(this.btnHud7_Click);
            // 
            // btnHud8
            // 
            this.btnHud8.Name = "btnHud8";
            this.btnHud8.Size = new System.Drawing.Size(234, 22);
            this.btnHud8.Text = "Oculus Link Detail";
            this.btnHud8.Click += new System.EventHandler(this.btnHud8_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(231, 6);
            // 
            // btnHud0
            // 
            this.btnHud0.Checked = true;
            this.btnHud0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnHud0.Name = "btnHud0";
            this.btnHud0.Size = new System.Drawing.Size(234, 22);
            this.btnHud0.Text = "None";
            this.btnHud0.Click += new System.EventHandler(this.btnHud0_Click);
            // 
            // btnModMenu
            // 
            this.btnModMenu.Name = "btnModMenu";
            this.btnModMenu.Size = new System.Drawing.Size(205, 22);
            this.btnModMenu.Text = "Oculus Mod Menu";
            this.btnModMenu.Click += new System.EventHandler(this.btnModMenu_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(202, 6);
            // 
            // menuBitrate
            // 
            this.menuBitrate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bitrateDisplayBox,
            this.toolStripSeparator2,
            this.bitrate500,
            this.bitrate450,
            this.bitrate400,
            this.bitrate350,
            this.bitrate300,
            this.bitrate250,
            this.bitrate200,
            this.bitrate150,
            this.bitrate100,
            this.bitrateAuto,
            this.toolStripSeparator1,
            this.bitrate960});
            this.menuBitrate.Image = global::NinsTool.Properties.Resources.television_1f4fa;
            this.menuBitrate.Name = "menuBitrate";
            this.menuBitrate.Size = new System.Drawing.Size(205, 22);
            this.menuBitrate.Text = "Bitrate";
            // 
            // bitrateDisplayBox
            // 
            this.bitrateDisplayBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bitrateDisplayBox.Image = global::NinsTool.Properties.Resources.information_2139_fe0f;
            this.bitrateDisplayBox.Name = "bitrateDisplayBox";
            this.bitrateDisplayBox.Size = new System.Drawing.Size(180, 22);
            this.bitrateDisplayBox.Text = "Current: ";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // bitrate500
            // 
            this.bitrate500.Name = "bitrate500";
            this.bitrate500.Size = new System.Drawing.Size(180, 22);
            this.bitrate500.Text = "500";
            this.bitrate500.Click += new System.EventHandler(this.bitrate500_Click);
            // 
            // bitrate450
            // 
            this.bitrate450.Name = "bitrate450";
            this.bitrate450.Size = new System.Drawing.Size(180, 22);
            this.bitrate450.Text = "450";
            this.bitrate450.Click += new System.EventHandler(this.bitrate450_Click);
            // 
            // bitrate400
            // 
            this.bitrate400.Name = "bitrate400";
            this.bitrate400.Size = new System.Drawing.Size(180, 22);
            this.bitrate400.Text = "400";
            this.bitrate400.Click += new System.EventHandler(this.bitrate400_Click);
            // 
            // bitrate350
            // 
            this.bitrate350.Name = "bitrate350";
            this.bitrate350.Size = new System.Drawing.Size(180, 22);
            this.bitrate350.Text = "350";
            this.bitrate350.Click += new System.EventHandler(this.bitrate350_Click);
            // 
            // bitrate300
            // 
            this.bitrate300.Name = "bitrate300";
            this.bitrate300.Size = new System.Drawing.Size(180, 22);
            this.bitrate300.Text = "300";
            this.bitrate300.Click += new System.EventHandler(this.bitrate300_Click);
            // 
            // bitrate250
            // 
            this.bitrate250.Name = "bitrate250";
            this.bitrate250.Size = new System.Drawing.Size(180, 22);
            this.bitrate250.Text = "250";
            this.bitrate250.Click += new System.EventHandler(this.bitrate250_Click);
            // 
            // bitrate200
            // 
            this.bitrate200.Name = "bitrate200";
            this.bitrate200.Size = new System.Drawing.Size(180, 22);
            this.bitrate200.Text = "200";
            this.bitrate200.Click += new System.EventHandler(this.bitrate200_Click);
            // 
            // bitrate150
            // 
            this.bitrate150.Name = "bitrate150";
            this.bitrate150.Size = new System.Drawing.Size(180, 22);
            this.bitrate150.Text = "150";
            this.bitrate150.Click += new System.EventHandler(this.bitrate150_Click);
            // 
            // bitrate100
            // 
            this.bitrate100.Name = "bitrate100";
            this.bitrate100.Size = new System.Drawing.Size(180, 22);
            this.bitrate100.Text = "100";
            this.bitrate100.Click += new System.EventHandler(this.bitrate100_Click);
            // 
            // bitrateAuto
            // 
            this.bitrateAuto.Name = "bitrateAuto";
            this.bitrateAuto.Size = new System.Drawing.Size(180, 22);
            this.bitrateAuto.Text = "Auto";
            this.bitrateAuto.Click += new System.EventHandler(this.bitrateAuto_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // bitrate960
            // 
            this.bitrate960.Name = "bitrate960";
            this.bitrate960.Size = new System.Drawing.Size(180, 22);
            this.bitrate960.Text = "960";
            this.bitrate960.Click += new System.EventHandler(this.bitrate960_Click);
            // 
            // aSWModeToolStripMenuItem
            // 
            this.aSWModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnASWAuto,
            this.btnASWOff});
            this.aSWModeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aSWModeToolStripMenuItem.Image")));
            this.aSWModeToolStripMenuItem.Name = "aSWModeToolStripMenuItem";
            this.aSWModeToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.aSWModeToolStripMenuItem.Text = "ASW Mode";
            // 
            // btnASWAuto
            // 
            this.btnASWAuto.Name = "btnASWAuto";
            this.btnASWAuto.Size = new System.Drawing.Size(180, 22);
            this.btnASWAuto.Text = "Auto";
            this.btnASWAuto.Click += new System.EventHandler(this.btnASWAuto_Click);
            // 
            // btnASWOff
            // 
            this.btnASWOff.Name = "btnASWOff";
            this.btnASWOff.Size = new System.Drawing.Size(180, 22);
            this.btnASWOff.Text = "Off";
            this.btnASWOff.Click += new System.EventHandler(this.btnASWOff_Click);
            // 
            // localDimmingToolStripMenuItem
            // 
            this.localDimmingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDimOn,
            this.btnDimOff});
            this.localDimmingToolStripMenuItem.Enabled = false;
            this.localDimmingToolStripMenuItem.Image = global::NinsTool.Properties.Resources.bright_button_1f506;
            this.localDimmingToolStripMenuItem.Name = "localDimmingToolStripMenuItem";
            this.localDimmingToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.localDimmingToolStripMenuItem.Text = "Local Dimming";
            // 
            // btnDimOn
            // 
            this.btnDimOn.Name = "btnDimOn";
            this.btnDimOn.Size = new System.Drawing.Size(180, 22);
            this.btnDimOn.Text = "On";
            this.btnDimOn.Click += new System.EventHandler(this.btnDimOn_Click);
            // 
            // btnDimOff
            // 
            this.btnDimOff.Name = "btnDimOff";
            this.btnDimOff.Size = new System.Drawing.Size(180, 22);
            this.btnDimOff.Text = "Off";
            this.btnDimOff.Click += new System.EventHandler(this.btnDimOff_Click);
            // 
            // slicedEncodingToolStripMenuItem
            // 
            this.slicedEncodingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSliceOn,
            this.btnSliceOff,
            this.toolStripSeparator7,
            this.toolStripMenuItem1,
            this.wiredLinkOnlyToolStripMenuItem,
            this.toolStripSeparator12,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9});
            this.slicedEncodingToolStripMenuItem.Enabled = false;
            this.slicedEncodingToolStripMenuItem.Image = global::NinsTool.Properties.Resources.kitchen_knife_1f52a;
            this.slicedEncodingToolStripMenuItem.Name = "slicedEncodingToolStripMenuItem";
            this.slicedEncodingToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.slicedEncodingToolStripMenuItem.Text = "Sliced Encoding";
            // 
            // btnSliceOn
            // 
            this.btnSliceOn.Name = "btnSliceOn";
            this.btnSliceOn.Size = new System.Drawing.Size(201, 22);
            this.btnSliceOn.Text = "On";
            this.btnSliceOn.Click += new System.EventHandler(this.btnSliceOn_Click);
            // 
            // btnSliceOff
            // 
            this.btnSliceOff.Name = "btnSliceOff";
            this.btnSliceOff.Size = new System.Drawing.Size(201, 22);
            this.btnSliceOff.Text = "Off";
            this.btnSliceOff.Click += new System.EventHandler(this.btnSliceOff_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(198, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(201, 22);
            this.toolStripMenuItem1.Text = "Requires restart";
            // 
            // wiredLinkOnlyToolStripMenuItem
            // 
            this.wiredLinkOnlyToolStripMenuItem.Enabled = false;
            this.wiredLinkOnlyToolStripMenuItem.Name = "wiredLinkOnlyToolStripMenuItem";
            this.wiredLinkOnlyToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.wiredLinkOnlyToolStripMenuItem.Text = "Wired Link only";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(198, 6);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Enabled = false;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(201, 22);
            this.toolStripMenuItem8.Text = "This also fixes the";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Enabled = false;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(201, 22);
            this.toolStripMenuItem9.Text = "\"white bar\" bug if off.";
            // 
            // mnuSharpening
            // 
            this.mnuSharpening.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSharpeningOff,
            this.btnSharpeningOn,
            this.btnSharpeningQuality});
            this.mnuSharpening.Enabled = false;
            this.mnuSharpening.Image = global::NinsTool.Properties.Resources.pushpin;
            this.mnuSharpening.Name = "mnuSharpening";
            this.mnuSharpening.Size = new System.Drawing.Size(205, 22);
            this.mnuSharpening.Text = "Link Sharpening";
            // 
            // btnSharpeningOff
            // 
            this.btnSharpeningOff.Name = "btnSharpeningOff";
            this.btnSharpeningOff.Size = new System.Drawing.Size(127, 22);
            this.btnSharpeningOff.Text = "Disabled";
            this.btnSharpeningOff.Click += new System.EventHandler(this.btnSharpeningOff_Click);
            // 
            // btnSharpeningOn
            // 
            this.btnSharpeningOn.Name = "btnSharpeningOn";
            this.btnSharpeningOn.Size = new System.Drawing.Size(127, 22);
            this.btnSharpeningOn.Text = "Normal";
            this.btnSharpeningOn.Click += new System.EventHandler(this.btnSharpeningOn_Click);
            // 
            // btnSharpeningQuality
            // 
            this.btnSharpeningQuality.Name = "btnSharpeningQuality";
            this.btnSharpeningQuality.Size = new System.Drawing.Size(127, 22);
            this.btnSharpeningQuality.Text = "Quality";
            this.btnSharpeningQuality.Click += new System.EventHandler(this.btnSharpeningQuality_Click);
            // 
            // mnuGuardian
            // 
            this.mnuGuardian.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setGuardianOffToolStripMenuItem,
            this.setGuardianOffToolStripMenuItem1});
            this.mnuGuardian.Enabled = false;
            this.mnuGuardian.Image = global::NinsTool.Properties.Resources.brick_1f9f1;
            this.mnuGuardian.Name = "mnuGuardian";
            this.mnuGuardian.Size = new System.Drawing.Size(205, 22);
            this.mnuGuardian.Text = "Guardian";
            // 
            // setGuardianOffToolStripMenuItem
            // 
            this.setGuardianOffToolStripMenuItem.Name = "setGuardianOffToolStripMenuItem";
            this.setGuardianOffToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.setGuardianOffToolStripMenuItem.Text = "Set Guardian On";
            this.setGuardianOffToolStripMenuItem.Click += new System.EventHandler(this.setGuardianOffToolStripMenuItem_Click);
            // 
            // setGuardianOffToolStripMenuItem1
            // 
            this.setGuardianOffToolStripMenuItem1.Name = "setGuardianOffToolStripMenuItem1";
            this.setGuardianOffToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.setGuardianOffToolStripMenuItem1.Text = "Set Guardian Off";
            this.setGuardianOffToolStripMenuItem1.Click += new System.EventHandler(this.setGuardianOffToolStripMenuItem1_Click);
            // 
            // mnuCodec
            // 
            this.mnuCodec.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripSeparator8,
            this.btnForce264,
            this.btnForceHEVC,
            this.btnCodecAuto,
            this.toolStripSeparator9,
            this.btnAbout264});
            this.mnuCodec.Enabled = false;
            this.mnuCodec.Image = global::NinsTool.Properties.Resources.disk;
            this.mnuCodec.Name = "mnuCodec";
            this.mnuCodec.Size = new System.Drawing.Size(205, 22);
            this.mnuCodec.Text = "Codec";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Enabled = false;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem5.Text = "Requires restart";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(166, 6);
            // 
            // btnForce264
            // 
            this.btnForce264.Name = "btnForce264";
            this.btnForce264.Size = new System.Drawing.Size(169, 22);
            this.btnForce264.Text = "Force H.264";
            this.btnForce264.Click += new System.EventHandler(this.btnForce264_Click);
            // 
            // btnForceHEVC
            // 
            this.btnForceHEVC.Name = "btnForceHEVC";
            this.btnForceHEVC.Size = new System.Drawing.Size(169, 22);
            this.btnForceHEVC.Text = "Force HEVC";
            this.btnForceHEVC.Click += new System.EventHandler(this.btnForceHEVC_Click);
            // 
            // btnCodecAuto
            // 
            this.btnCodecAuto.Name = "btnCodecAuto";
            this.btnCodecAuto.Size = new System.Drawing.Size(169, 22);
            this.btnCodecAuto.Text = "Auto";
            this.btnCodecAuto.Click += new System.EventHandler(this.btnCodecAuto_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(166, 6);
            // 
            // btnAbout264
            // 
            this.btnAbout264.Image = global::NinsTool.Properties.Resources.information_2139_fe0f;
            this.btnAbout264.Name = "btnAbout264";
            this.btnAbout264.Size = new System.Drawing.Size(169, 22);
            this.btnAbout264.Text = "What\'s this?";
            this.btnAbout264.Click += new System.EventHandler(this.btnAbout264_Click);
            // 
            // proxMenu
            // 
            this.proxMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proxEnable,
            this.proxDisable});
            this.proxMenu.Enabled = false;
            this.proxMenu.Image = ((System.Drawing.Image)(resources.GetObject("proxMenu.Image")));
            this.proxMenu.Name = "proxMenu";
            this.proxMenu.Size = new System.Drawing.Size(205, 22);
            this.proxMenu.Text = "Proximity Sensor";
            // 
            // proxEnable
            // 
            this.proxEnable.Name = "proxEnable";
            this.proxEnable.Size = new System.Drawing.Size(119, 22);
            this.proxEnable.Text = "Enable";
            this.proxEnable.Click += new System.EventHandler(this.proxEnable_Click);
            // 
            // proxDisable
            // 
            this.proxDisable.Name = "proxDisable";
            this.proxDisable.Size = new System.Drawing.Size(119, 22);
            this.proxDisable.Text = "Disable";
            this.proxDisable.Click += new System.EventHandler(this.proxDisable_Click);
            // 
            // mnuScreenBrightness
            // 
            this.mnuScreenBrightness.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brightnessComboBox});
            this.mnuScreenBrightness.Enabled = false;
            this.mnuScreenBrightness.Image = ((System.Drawing.Image)(resources.GetObject("mnuScreenBrightness.Image")));
            this.mnuScreenBrightness.Name = "mnuScreenBrightness";
            this.mnuScreenBrightness.Size = new System.Drawing.Size(205, 22);
            this.mnuScreenBrightness.Text = "Screen Brightness";
            // 
            // brightnessComboBox
            // 
            this.brightnessComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.brightnessComboBox.ForeColor = System.Drawing.Color.White;
            this.brightnessComboBox.Items.AddRange(new object[] {
            "100",
            "90",
            "80",
            "70",
            "60",
            "50",
            "40",
            "30",
            "20",
            "10"});
            this.brightnessComboBox.Name = "brightnessComboBox";
            this.brightnessComboBox.Size = new System.Drawing.Size(121, 23);
            this.brightnessComboBox.DropDownClosed += new System.EventHandler(this.brightnessComboBox_DropDownClosed_1);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(202, 6);
            // 
            // autoLaunchToolStripMenu
            // 
            this.autoLaunchToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAutoLaunchEnable,
            this.btnAutoLaunchDisable,
            this.toolStripSeparator4,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripSeparator11,
            this.btnAutoLaunchSteamVR,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.btnOpenCustomApps});
            this.autoLaunchToolStripMenu.Enabled = false;
            this.autoLaunchToolStripMenu.Name = "autoLaunchToolStripMenu";
            this.autoLaunchToolStripMenu.Size = new System.Drawing.Size(205, 22);
            this.autoLaunchToolStripMenu.Text = "Auto Launch";
            // 
            // btnAutoLaunchEnable
            // 
            this.btnAutoLaunchEnable.Name = "btnAutoLaunchEnable";
            this.btnAutoLaunchEnable.Size = new System.Drawing.Size(269, 22);
            this.btnAutoLaunchEnable.Text = "Enabled";
            this.btnAutoLaunchEnable.Click += new System.EventHandler(this.btnAutoLaunchEnable_Click);
            // 
            // btnAutoLaunchDisable
            // 
            this.btnAutoLaunchDisable.Name = "btnAutoLaunchDisable";
            this.btnAutoLaunchDisable.Size = new System.Drawing.Size(269, 22);
            this.btnAutoLaunchDisable.Text = "Disabled";
            this.btnAutoLaunchDisable.Click += new System.EventHandler(this.btnAutoLaunchDisable_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(266, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(269, 22);
            this.toolStripMenuItem2.Text = "Automatically launches Nin\'s Tool";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Enabled = false;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(269, 22);
            this.toolStripMenuItem3.Text = "and applies saved settings when";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Enabled = false;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(269, 22);
            this.toolStripMenuItem4.Text = "Oculus Link starts";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(266, 6);
            // 
            // btnAutoLaunchSteamVR
            // 
            this.btnAutoLaunchSteamVR.Enabled = false;
            this.btnAutoLaunchSteamVR.Name = "btnAutoLaunchSteamVR";
            this.btnAutoLaunchSteamVR.Size = new System.Drawing.Size(269, 22);
            this.btnAutoLaunchSteamVR.Text = "SteamVR";
            this.btnAutoLaunchSteamVR.Click += new System.EventHandler(this.btnAutoLaunchSteamVR_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Enabled = false;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(269, 22);
            this.toolStripMenuItem6.Text = "will automatically launch";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Enabled = false;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(269, 22);
            this.toolStripMenuItem7.Text = "SteamVR when Link starts";
            // 
            // btnOpenCustomApps
            // 
            this.btnOpenCustomApps.Name = "btnOpenCustomApps";
            this.btnOpenCustomApps.Size = new System.Drawing.Size(269, 22);
            this.btnOpenCustomApps.Text = "Custom Apps...";
            this.btnOpenCustomApps.Visible = false;
            this.btnOpenCustomApps.Click += new System.EventHandler(this.btnOpenCustomApps_Click);
            // 
            // enterGumroadKeyToolStripMenuItem
            // 
            this.enterGumroadKeyToolStripMenuItem.Image = global::NinsTool.Properties.Resources.key;
            this.enterGumroadKeyToolStripMenuItem.Name = "enterGumroadKeyToolStripMenuItem";
            this.enterGumroadKeyToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.enterGumroadKeyToolStripMenuItem.Text = "Enter Gumroad Key";
            this.enterGumroadKeyToolStripMenuItem.Click += new System.EventHandler(this.enterGumroadKeyToolStripMenuItem_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutRegTo,
            this.aboutLicKey,
            this.aboutEdition,
            this.divide,
            this.aboutVersion,
            this.aboutAuthor,
            this.toolStripSeparator10,
            this.aboutBtnNotifications,
            this.aboutBtnUpdateCheck});
            this.btnAbout.Image = global::NinsTool.Properties.Resources.information_2139_fe0f;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(205, 22);
            this.btnAbout.Text = "About";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // aboutRegTo
            // 
            this.aboutRegTo.Image = global::NinsTool.Properties.Resources.scroll;
            this.aboutRegTo.Name = "aboutRegTo";
            this.aboutRegTo.Size = new System.Drawing.Size(263, 22);
            this.aboutRegTo.Text = "Registered to: Unregistered";
            this.aboutRegTo.Click += new System.EventHandler(this.aboutRegTo_Click);
            // 
            // aboutLicKey
            // 
            this.aboutLicKey.Name = "aboutLicKey";
            this.aboutLicKey.Size = new System.Drawing.Size(263, 22);
            this.aboutLicKey.Text = "Key: None";
            this.aboutLicKey.MouseDown += new System.Windows.Forms.MouseEventHandler(this.aboutLicKey_MouseDown);
            this.aboutLicKey.MouseUp += new System.Windows.Forms.MouseEventHandler(this.aboutLicKey_MouseUp);
            // 
            // aboutEdition
            // 
            this.aboutEdition.Name = "aboutEdition";
            this.aboutEdition.Size = new System.Drawing.Size(263, 22);
            this.aboutEdition.Text = "Edition: Free";
            // 
            // divide
            // 
            this.divide.Name = "divide";
            this.divide.Size = new System.Drawing.Size(260, 6);
            // 
            // aboutVersion
            // 
            this.aboutVersion.Image = global::NinsTool.Properties.Resources.Ninka_Chin_Transparent;
            this.aboutVersion.Name = "aboutVersion";
            this.aboutVersion.Size = new System.Drawing.Size(263, 22);
            this.aboutVersion.Text = "Nin\'s Tool";
            // 
            // aboutAuthor
            // 
            this.aboutAuthor.Enabled = false;
            this.aboutAuthor.Name = "aboutAuthor";
            this.aboutAuthor.Size = new System.Drawing.Size(263, 22);
            this.aboutAuthor.Text = "by Ninka_ | Support: nin@nin.wtf";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(260, 6);
            // 
            // aboutBtnNotifications
            // 
            this.aboutBtnNotifications.Name = "aboutBtnNotifications";
            this.aboutBtnNotifications.Size = new System.Drawing.Size(263, 22);
            this.aboutBtnNotifications.Text = "Notifications";
            this.aboutBtnNotifications.Click += new System.EventHandler(this.aboutBtnNotifications_Click);
            // 
            // aboutBtnUpdateCheck
            // 
            this.aboutBtnUpdateCheck.Name = "aboutBtnUpdateCheck";
            this.aboutBtnUpdateCheck.Size = new System.Drawing.Size(263, 22);
            this.aboutBtnUpdateCheck.Text = "Check for updates";
            this.aboutBtnUpdateCheck.Click += new System.EventHandler(this.aboutBtnUpdateCheck_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::NinsTool.Properties.Resources.cross_mark_274c;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(205, 22);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEdition);
            this.groupBox1.Controls.Add(this.txtLicKey);
            this.groupBox1.Controls.Add(this.txtRegTo);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 97);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "License";
            // 
            // txtEdition
            // 
            this.txtEdition.AutoSize = true;
            this.txtEdition.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdition.ForeColor = System.Drawing.Color.White;
            this.txtEdition.Location = new System.Drawing.Point(43, 68);
            this.txtEdition.Name = "txtEdition";
            this.txtEdition.Size = new System.Drawing.Size(72, 13);
            this.txtEdition.TabIndex = 2;
            this.txtEdition.Text = "Edition: Free";
            // 
            // txtLicKey
            // 
            this.txtLicKey.AutoSize = true;
            this.txtLicKey.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicKey.ForeColor = System.Drawing.Color.White;
            this.txtLicKey.Location = new System.Drawing.Point(12, 45);
            this.txtLicKey.Name = "txtLicKey";
            this.txtLicKey.Size = new System.Drawing.Size(109, 13);
            this.txtLicKey.TabIndex = 1;
            this.txtLicKey.Text = "Gumroad key: None";
            // 
            // txtRegTo
            // 
            this.txtRegTo.AutoSize = true;
            this.txtRegTo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegTo.ForeColor = System.Drawing.Color.White;
            this.txtRegTo.Location = new System.Drawing.Point(10, 22);
            this.txtRegTo.Name = "txtRegTo";
            this.txtRegTo.Size = new System.Drawing.Size(149, 13);
            this.txtRegTo.TabIndex = 0;
            this.txtRegTo.Text = "Registered to: Unregistered";
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblLink.Location = new System.Drawing.Point(229, 58);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(100, 13);
            this.lblLink.TabIndex = 2;
            this.lblLink.TabStop = true;
            this.lblLink.Text = "nin.wtf/NinsTool";
            this.lblLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLink_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(75, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "By Ninka_";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(72, 19);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(153, 37);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Nin\'s Tool";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Notifications:";
            // 
            // rdNotifOn
            // 
            this.rdNotifOn.AutoSize = true;
            this.rdNotifOn.ForeColor = System.Drawing.Color.White;
            this.rdNotifOn.Location = new System.Drawing.Point(95, 202);
            this.rdNotifOn.Name = "rdNotifOn";
            this.rdNotifOn.Size = new System.Drawing.Size(39, 17);
            this.rdNotifOn.TabIndex = 4;
            this.rdNotifOn.TabStop = true;
            this.rdNotifOn.Text = "On";
            this.rdNotifOn.UseVisualStyleBackColor = true;
            this.rdNotifOn.CheckedChanged += new System.EventHandler(this.rdNotifOn_CheckedChanged);
            // 
            // rdNotifOff
            // 
            this.rdNotifOff.AutoSize = true;
            this.rdNotifOff.ForeColor = System.Drawing.Color.White;
            this.rdNotifOff.Location = new System.Drawing.Point(137, 202);
            this.rdNotifOff.Name = "rdNotifOff";
            this.rdNotifOff.Size = new System.Drawing.Size(39, 17);
            this.rdNotifOff.TabIndex = 5;
            this.rdNotifOff.TabStop = true;
            this.rdNotifOff.Text = "Off";
            this.rdNotifOff.UseVisualStyleBackColor = true;
            // 
            // btnAboutPageClose
            // 
            this.btnAboutPageClose.Location = new System.Drawing.Point(262, 224);
            this.btnAboutPageClose.Name = "btnAboutPageClose";
            this.btnAboutPageClose.Size = new System.Drawing.Size(75, 23);
            this.btnAboutPageClose.TabIndex = 7;
            this.btnAboutPageClose.Text = "Close";
            this.btnAboutPageClose.UseVisualStyleBackColor = true;
            this.btnAboutPageClose.Click += new System.EventHandler(this.btnAboutPageClose_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(182, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Enter Key";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkCheckForUpdates
            // 
            this.chkCheckForUpdates.AutoSize = true;
            this.chkCheckForUpdates.ForeColor = System.Drawing.Color.White;
            this.chkCheckForUpdates.Location = new System.Drawing.Point(218, 202);
            this.chkCheckForUpdates.Name = "chkCheckForUpdates";
            this.chkCheckForUpdates.Size = new System.Drawing.Size(113, 17);
            this.chkCheckForUpdates.TabIndex = 9;
            this.chkCheckForUpdates.Text = "Check for updates";
            this.chkCheckForUpdates.UseVisualStyleBackColor = true;
            this.chkCheckForUpdates.CheckedChanged += new System.EventHandler(this.chkCheckForUpdates_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NinsTool.Properties.Resources.NinsToolIcon;
            this.pictureBox1.Location = new System.Drawing.Point(12, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(351, 253);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkCheckForUpdates);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAboutPageClose);
            this.Controls.Add(this.rdNotifOff);
            this.Controls.Add(this.rdNotifOn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nin\'s Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.trayMenu1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip trayMenu1;
        private System.Windows.Forms.ToolStripMenuItem menuBitrate;
        private System.Windows.Forms.ToolStripMenuItem bitrate960;
        private System.Windows.Forms.ToolStripMenuItem bitrate500;
        private System.Windows.Forms.ToolStripMenuItem bitrate450;
        private System.Windows.Forms.ToolStripMenuItem bitrate400;
        private System.Windows.Forms.ToolStripMenuItem bitrate350;
        private System.Windows.Forms.ToolStripMenuItem bitrate300;
        private System.Windows.Forms.ToolStripMenuItem bitrate250;
        private System.Windows.Forms.ToolStripMenuItem bitrate200;
        private System.Windows.Forms.ToolStripMenuItem bitrate150;
        private System.Windows.Forms.ToolStripMenuItem bitrate100;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem bitrateDisplayBox;
        private System.Windows.Forms.ToolStripMenuItem aSWModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnASWAuto;
        private System.Windows.Forms.ToolStripMenuItem btnASWOff;
        private System.Windows.Forms.ToolStripMenuItem localDimmingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnDimOn;
        private System.Windows.Forms.ToolStripMenuItem btnDimOff;
        private System.Windows.Forms.ToolStripMenuItem slicedEncodingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnSliceOn;
        private System.Windows.Forms.ToolStripMenuItem btnSliceOff;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem autoLaunchToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem btnAutoLaunchEnable;
        private System.Windows.Forms.ToolStripMenuItem btnAutoLaunchDisable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem btnAbout;
        private System.Windows.Forms.Timer watcherTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txtEdition;
        private System.Windows.Forms.Label txtLicKey;
        private System.Windows.Forms.Label txtRegTo;
        private System.Windows.Forms.LinkLabel lblLink;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdNotifOn;
        private System.Windows.Forms.RadioButton rdNotifOff;
        private System.Windows.Forms.ToolStripMenuItem mnuGuardian;
        private System.Windows.Forms.ToolStripMenuItem setGuardianOffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setGuardianOffToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem txtHeadset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem btnOculusRestart;
        private System.Windows.Forms.ToolStripMenuItem serverPriorityMenu;
        private System.Windows.Forms.ToolStripMenuItem highToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem btnBattery;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAboutPageClose;
        private System.Windows.Forms.ToolStripMenuItem enterGumroadKeyToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem updateNotifMenuItem;
        private System.Windows.Forms.ToolStripSeparator updateSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.CheckBox chkCheckForUpdates;
        private System.Windows.Forms.ToolStripMenuItem wiredLinkOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCodec;
        private System.Windows.Forms.ToolStripMenuItem btnForce264;
        private System.Windows.Forms.ToolStripMenuItem btnAbout264;
        private System.Windows.Forms.ToolStripMenuItem btnModMenu;
        private System.Windows.Forms.ToolStripMenuItem btnForceHEVC;
        private System.Windows.Forms.ToolStripMenuItem btnCodecAuto;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem mnuSharpening;
        private System.Windows.Forms.ToolStripMenuItem btnSharpeningOn;
        private System.Windows.Forms.ToolStripMenuItem btnSharpeningOff;
        private System.Windows.Forms.ToolStripMenuItem btnSharpeningQuality;
        private System.Windows.Forms.ToolStripMenuItem aboutVersion;
        private System.Windows.Forms.ToolStripMenuItem aboutAuthor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem aboutRegTo;
        private System.Windows.Forms.ToolStripMenuItem aboutLicKey;
        private System.Windows.Forms.ToolStripMenuItem aboutEdition;
        private System.Windows.Forms.ToolStripSeparator divide;
        private System.Windows.Forms.ToolStripMenuItem aboutBtnNotifications;
        private System.Windows.Forms.ToolStripMenuItem aboutBtnUpdateCheck;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem btnAutoLaunchSteamVR;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem proxMenu;
        private System.Windows.Forms.ToolStripMenuItem proxEnable;
        private System.Windows.Forms.ToolStripMenuItem proxDisable;
        private System.Windows.Forms.ToolStripMenuItem bitrateAuto;
        private System.Windows.Forms.ToolStripMenuItem btnOpenCustomApps;
        private System.Windows.Forms.ToolStripMenuItem mnuHud;
        private System.Windows.Forms.ToolStripMenuItem btnHud1;
        private System.Windows.Forms.ToolStripMenuItem btnHud2;
        private System.Windows.Forms.ToolStripMenuItem btnHud3;
        private System.Windows.Forms.ToolStripMenuItem btnHud4;
        private System.Windows.Forms.ToolStripMenuItem btnHud7;
        private System.Windows.Forms.ToolStripMenuItem btnHud8;
        private System.Windows.Forms.ToolStripMenuItem btnHud0;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem mnuStartLink;
        private System.Windows.Forms.ToolStripMenuItem btnStartWiredLink;
        private System.Windows.Forms.ToolStripMenuItem btnStartAirlink;
        private System.Windows.Forms.ToolStripMenuItem btnCtrlBattery;
        public System.Windows.Forms.ToolStripMenuItem warningRoomDark;
        private System.Windows.Forms.ToolStripMenuItem mnuScreenBrightness;
        public static System.Windows.Forms.ToolStripComboBox brightnessComboBox2;
        public System.Windows.Forms.ToolStripComboBox brightnessComboBox;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;
        private Timer timer1;
    }
}

