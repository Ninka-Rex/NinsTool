using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;


namespace NinsTool
{
    internal class ArpLookup
    {
        public static string findQuestDevice()
        {
            string headsetMACPrefix = "80-f3-ef";




            ProcessStartInfo startInfo = new ProcessStartInfo("arp", "-a");
            startInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            StreamReader reader = process.StandardOutput;
            string arpTableOutput = reader.ReadToEnd();
            process.WaitForExit();

            process.WaitForExit();
            string[] arpTableLines = arpTableOutput.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string arpEntryLine in arpTableLines)
            {
                string[] arpEntry = arpEntryLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (arpEntry.Length >= 2 && arpEntry[1].StartsWith(headsetMACPrefix))
                {
                    return arpEntry[0];
                }
            }
            return null;

        }


    }
}
