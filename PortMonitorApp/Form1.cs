using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortMonitorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Continue = true;
        }

        public bool Continue { get; set; }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] connections;

            var index = 1;


            while (Continue)
            {
                label3.Text = index.ToString();

                connections = ipGlobalProperties
                    .GetActiveTcpConnections()
                    .Where(c => c.RemoteEndPoint.Port == 443)
                    .Where(c => c.RemoteEndPoint.Address.ToString() == "185.116.160.100")
                    .ToArray();
                foreach (var item in connections)
                {
                    listBox1.Items.Add($"Local Port : {item.LocalEndPoint.Port} ->  {item.RemoteEndPoint.Address.ToString()} | state : {item.State}");
                }
                var count = connections.Where(c => c.State == TcpState.TimeWait).Count();
                label2.Text = count.ToString();
                await Task.Delay(1000);
                listBox1.Items.Clear();
                index++;


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Continue = false;
        }
    }
}
