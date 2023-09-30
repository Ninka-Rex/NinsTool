using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using NinsTool;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using TrayBuddy;

namespace NinsTool
{
    internal class performanceHud
    {
        public void setHud(int num)
        {
            string textfile = "hud" + num + ".txt";

            ProcessStartInfo startInfo = new ProcessStartInfo("OculusDebugToolCLI.exe", "-f " + textfile);
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            System.Threading.Thread.Sleep(300);
            try { process.Kill(); } catch { }


        }
    }
}
