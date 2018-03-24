using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacketDotNet;
using SharpPcap;

namespace FirewallMan
{
    public partial class Pcap : Form
    {
        public Pcap()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            var devices = CaptureDeviceList.Instance;

            comboBox1.Items.Clear();
            foreach (var dev in devices)
                comboBox1.Items.Add(dev.Description);

            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var devices = CaptureDeviceList.Instance;
            var dev = devices[comboBox1.SelectedIndex];
            dev.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);
            int readTimeoutMilliseconds = 1000;
            dev.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
            dev.StartCapture();
        }

        private void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            var time = e.Packet.Timeval.Date;
            var len = e.Packet.Data.Length;

            var packet = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
            if (packet == null)
                return;

            var eth = ((PacketDotNet.EthernetPacket)packet);
            richTextBox1.Text += (eth.ToString() + "\n");
            //PrintHex(packet.Header);
        }

        private void PrintHex(byte[] hexArr)
        {
            //Console.Write("WOL Packet detected for: ");
            for (int i = 0; i < hexArr.Length; i++)
            {
                // display the physical address in hexadecimal
                richTextBox1.Text += hexArr[i].ToString("X2");

                //Console.Write("{0}", hexArr[i].ToString("X2"));
                // trim the last hyphen from the MAC
                if (i != hexArr.Length - 1)
                {
                    richTextBox1.Text += "-";
                }
            }
            richTextBox1.Text += "\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var devices = CaptureDeviceList.Instance;
            foreach (var dev in devices)
            {
                try
                {
                    dev.StopCapture();
                }
                catch { }
                
            }
        }
    }
}
