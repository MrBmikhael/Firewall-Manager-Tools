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
using SharpPcap;
using SharpPcap.LibPcap;
using System.Net;
using System.Net.NetworkInformation;
using SharpPcap.WinPcap;

namespace FirewallMan
{
    public partial class ARPScanner : Form
    {
        public ARPScanner()
        {
            InitializeComponent();

            var devices = CaptureDeviceList.Instance;
            comboBox1.Items.Clear();
            foreach (var dev in devices)
                comboBox1.Items.Add(dev.Description);

            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WinPcapDevice PcapDevice = WinPcapDeviceList.Instance[comboBox1.SelectedIndex];
            ARP req = new ARP((LibPcapLiveDevice)CaptureDeviceList.Instance[comboBox1.SelectedIndex]);

            Console.Out.WriteLine(PcapDevice.Addresses[1]);

            req.Timeout = new System.TimeSpan(1200000);

            IPAddress target = null;
            IPAddress.TryParse("192.168.1.1", out target);

            var resolvedMacAddress = req.Resolve(target);

            Console.Out.WriteLine(resolvedMacAddress.ToString());
        }
    }
}
