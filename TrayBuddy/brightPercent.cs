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
    public static class brightPercent
    {
        public static void setBrightness(Form1 form1)
        {
            System.Threading.Thread.Sleep(100);
            if (IsNumeric(form1.brightnessComboBox.Text))
            {
                double brightPercent = Convert.ToInt16(form1.brightnessComboBox.Text);
                brightPercent = brightPercent / 100;
                brightPercent = brightPercent * 255;
                int roundedBrightness = (int)Math.Round(brightPercent);
                Form1.sendADBcommand("shell settings put system screen_brightness " + roundedBrightness);
            }
        }
        public static int GetbrightPercentage(Form1 form1)
        {
            int brightness = GetScreenBrightness();
            int percentage = ConvertBrightnessToPercentage(brightness);
            form1.brightnessComboBox.Text = percentage.ToString();
            return percentage;
        }
        static bool IsNumeric(string input)
        {
            Regex regex = new Regex("^[0-9]+$");
            return regex.IsMatch(input);
        }
        public static int GetScreenBrightness()
        {
            // Run ADB Command 'shell settings get system screen_brightness'
            // Use ProcessStartInfo to execute the ADB command and capture the output
            ProcessStartInfo adbStartInfo = new ProcessStartInfo
            {
                FileName = "adb",
                Arguments = "shell settings get system screen_brightness",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process adbProcess = Process.Start(adbStartInfo))
            {
                adbProcess.WaitForExit();
                string output = adbProcess.StandardOutput.ReadToEnd();
                int brightness;
                if (int.TryParse(output, out brightness))
                {
                    return brightness;
                }
                else
                {
                    throw new Exception("Failed to retrieve screen brightness.");
                }
            }
        }

        public static int ConvertBrightnessToPercentage(int brightness)
        {
            int percentage = (int)Math.Round(brightness / 255.0 * 100);
            return percentage;
        }
    }
}
