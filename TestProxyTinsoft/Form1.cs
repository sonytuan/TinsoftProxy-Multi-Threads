using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinsoftProxy.Dynamic_Multi_Proxies;

namespace TestProxyTinsoft
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DynamicMultiProxies myProxies;
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            string[] apiKeyLines = richTextBox1.Lines;
            

            if (apiKeyLines.Length > 0)
            {
                myProxies = new DynamicMultiProxies();
                myProxies.mySettings.limit_theads_use = 3;
                myProxies.mySettings.min_get_timeout = 180;
                foreach (var key in apiKeyLines)
                {
                    string myApiKey = key;
                    if (key.Contains("|"))
                    {
                        myApiKey = key.Split('|')[0];
                    }
                    myProxies.addProxybyKey(myApiKey, 0);
                }
                myProxies.Start();
               

            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (myProxies != null)
            {
                myProxies.Stop();
            }
            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (myProxies != null)
            {
                string proxy = myProxies.getProxy();
                richTextBox2.Text = proxy + "\n" + richTextBox2.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (myProxies != null)
            {
                string proxy = textBox1.Text;
                myProxies.setThreadStop(proxy);
                richTextBox2.Text = proxy+":Stop 1 thread." + "\n" + richTextBox2.Text;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (myProxies != null)
            {
                string proxy = myProxies.getRandomProxy();
                richTextBox2.Text = proxy + "\n" + richTextBox2.Text;
            }
        }

    }
}
