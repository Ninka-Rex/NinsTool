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
using System.Text.RegularExpressions;
using TrayBuddy;

namespace NinsTool
{
    internal class ControllerStatus
    {
        public string GetControllerBattery(Form1 form1)
        {
            
            try
            {
                string adbCommand = "shell dumpsys OVRRemoteService";
                string output = RunAdbCommand(adbCommand);

                string leftBattery = ExtractBatteryPercentage(output, "Type:   Left");
                string rightBattery = ExtractBatteryPercentage(output, "Type:  Right");

                if (output.Contains("BrightnessLevel: VERY_DARK"))
                {
                    form1.warningRoomDark.Visible = true;
                    form1.warningRoomDark.ForeColor = Color.Orange;
                }
                else
                {
                    form1.warningRoomDark.Visible = false;
                }

                return $"L: {leftBattery}% R: {rightBattery}%";
            }
            catch
            {
                return "L: ? R: ?";
            }
        }

        private string RunAdbCommand(string command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "adb",
                Arguments = command,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                return output;
            }
        }

        private string ExtractBatteryPercentage(string output, string controllerType)
        {
            string pattern = $@"{controllerType}.*?Battery:\s*(\d+)%";
            Match match = Regex.Match(output, pattern);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return "?";
        }
    }
}
