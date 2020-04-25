using System;
using System.Windows.Forms;
using SharpPcap;
using SharpPcap.LibPcap;
using System.Net;
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
            IPAddress.TryParse(networkText.Text, out target);

            int retry = 5;
            string hostMacAddress = null;

            while (retry > 1 && hostMacAddress == null)
            {
                try
                {
                    hostMacAddress = req.Resolve(target).ToString();
                }
                catch { }
                retry -= 1;
            }

            try
            {
                Console.Out.WriteLine(hostMacAddress.ToString());
            }
            catch { }
        }
    }
}
