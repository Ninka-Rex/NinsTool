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
namespace NinsTool
{
    internal class ProxSensorHandler
    {
        public void sensorOn()
        {
            sendAdb("shell am broadcast -a com.oculus.vrpowermanager.automation_disable");
        }
        public void sensorOff() 
        {
            sendAdb("shell am broadcast -a com.oculus.vrpowermanager.prox_close");
        }

        private void sendAdb(string command)
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
            StreamWriter writer = process.StandardInput;
            StreamReader reader = process.StandardOutput;
            string output = reader.ReadLine();
            writer.Close();
            process.WaitForExit();
        }
    }
}
