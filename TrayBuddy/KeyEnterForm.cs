using Newtonsoft.Json.Linq;
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
using TrayBuddy;

namespace NinsTool
{
    public partial class KeyEnterForm : Form
    {
        public KeyEnterForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://ninka.gumroad.com/l/NinsTool");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void btnReg_Click(object sender, EventArgs e)
        {
            try
            {
                btnReg.Enabled = false;
                string hello = "Woah! No need to crack my software. If price is an issue, please hit me up for a discount: nin@nin.wtf also Hi Ben!";
                hello = hello + "";
                string lic = txtKey.Text;
                // Create a new instance of the Program class
                // Invoke the Main method with the key you want to check
                string response = await NinsTool.gumroad.verif(lic);
                JObject joResponse = JObject.Parse(response);
                string email = (string)joResponse["purchase"]["email"];
                int price = (int)joResponse["purchase"]["price"];
                string variant = (string)joResponse["purchase"]["variants"];
                bool refunded = (bool)joResponse["purchase"]["refunded"];
                bool disputed = (bool)joResponse["purchase"]["dispute_won"];
                //MessageBox.Show(variant, "");
                if (variant != "(Supporter Edition)")
                {
                    MessageBox.Show("That license is for the free version!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnReg.Enabled = true;
                    return;
                }
                if (refunded || disputed)
                {
                    MessageBox.Show("That license is disabled!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnReg.Enabled = true;
                    return;
                }
                //Console.WriteLine($"Email: {email}");
                //Console.WriteLine($"Price: {price}");
                txtKey.Enabled = false;

                MessageBox.Show("Thanks you!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string preferredName = (string)joResponse["purchase"]["Preferred name or alias"];
                if (preferredName != null)
                {
                    email = preferredName;
                }


                NinsTool.Properties.Settings.Default.Email = email;
                NinsTool.Properties.Settings.Default.Key = lic;
                NinsTool.Properties.Settings.Default.Enable = true;
                NinsTool.Properties.Settings.Default.PricePaid = price;
                NinsTool.Properties.Settings.Default.Save();
                System.Threading.Thread.Sleep(500);
                btnReg.Enabled = true;  
                Process.Start(Application.ExecutablePath);
                Process.GetCurrentProcess().Kill();

            }
            catch
            {
                MessageBox.Show("License invalid or couldn't reach Gumroad!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnReg.Enabled = true;
            }
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            btnReg.Enabled = txtKey.TextLength > 24;
        }
    }
}
