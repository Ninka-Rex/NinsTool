using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NinsTool
{
    
    internal class gumroad
    
    {
        public static string responseContent;
        public static void main(string[] args)
        {

        }
        public static async Task<string> verif(string key)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                { "product_id", "LJTd8JkAxCqKIO3ITKrFwA==" },
                { "license_key", key }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://api.gumroad.com/v2/licenses/verify", content);
            var responseString = await response.Content.ReadAsStringAsync();
            //MessageBox.Show(responseString, responseString);
            return responseString;
        }

        
        
    }
}
