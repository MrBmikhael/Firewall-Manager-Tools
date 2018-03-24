using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FirewallMan
{
    public partial class NetworkMonitor : Form
    {
        public NetworkMonitor()
        {
            InitializeComponent();
            toolNetStatus.Text = string.Format("Sent: 0kbps | Received: 0kbps");
            backgroundWorker1.RunWorkerAsync();
        }

        public void ShowNetworkTraffic()
        {
            PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("Network Interface");
            string instance = performanceCounterCategory.GetInstanceNames()[0];
            PerformanceCounter performanceCounterSent = new PerformanceCounter("Network Interface", "Bytes Sent/sec", instance);
            PerformanceCounter performanceCounterReceived = new PerformanceCounter("Network Interface", "Bytes Received/sec", instance);

            float sent = 0;
            float received = 0;

            for (int i = 0; i < 1000; i++)
            {
                sent = performanceCounterSent.NextValue() / 1024;
                received = performanceCounterReceived.NextValue() / 1024;
            }

            if (sent != 0 || received != 0)
            {
                toolNetStatus.Text = string.Format("Sent: {0}kbps | Received: {1}kbps", sent, received);
                sent = 0;
                received = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowNetworkTraffic();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (;;)
            {
                ShowNetworkTraffic();
                Thread.Sleep(1000);
            }
        }
    }
}
