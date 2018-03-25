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
            //richTextBox1.Text += (eth.ToString() + "\n\n\n");
            addPacket(ParseEthInfo(eth.ToString()));
            //PrintHex(packet.Header);
        }

        private void addPacket(Dictionary<string, string> packetData)
        {
            ListViewItem item = new ListViewItem();
            if (packetData.ContainsKey("SourceHwAddr"))
                item.Text = packetData["SourceHwAddr"];
            else
                item.Text = "";

            if (packetData.ContainsKey("DestinationHwAddr"))
                item.SubItems.Add(packetData["DestinationHwAddr"]);
            else
                item.SubItems.Add("");

            if (packetData.ContainsKey("SourceAddr"))
                item.SubItems.Add(packetData["SourceAddr"]);
            else
                item.SubItems.Add("");

            if (packetData.ContainsKey("DestinationAddr"))
                item.SubItems.Add(packetData["DestinationAddr"]);
            else
                item.SubItems.Add("");

            if (packetData.ContainsKey("Protocol"))
                item.SubItems.Add(packetData["Protocol"]);
            else
                item.SubItems.Add("");

            if (packetData.ContainsKey("TimeToLive"))
                item.SubItems.Add(packetData["TimeToLive"]);
            else
                item.SubItems.Add("");

            if (packetData.ContainsKey("SourcePort"))
                item.SubItems.Add(packetData["SourcePort"]);
            else
                item.SubItems.Add("");

            if (packetData.ContainsKey("DestinationPort"))
                item.SubItems.Add(packetData["DestinationPort"]);
            else
                item.SubItems.Add("");

            listView1.Items.Add(item);
            listView1.Items[listView1.Items.Count - 1].EnsureVisible();
        }

        private Dictionary<string, string> ParseEthInfo(string eth)
        {
            Dictionary<string, string> Data = new Dictionary<string, string>();

            foreach (string str in eth.Split())
            {
                if (str.Contains("SourceHwAddr"))
                    Data["SourceHwAddr"] = str.Split('=')[1].ToString().TrimEnd(',');
                if (str.Contains("DestinationHwAddr"))
                    Data["DestinationHwAddr"] = str.Split('=')[1].ToString().TrimEnd(',');
                if (str.Contains("SourceAddr"))
                    Data["SourceAddr"] = str.Split('=')[1].ToString().TrimEnd(',');
                if (str.Contains("DestinationAddr"))
                    Data["DestinationAddr"] = str.Split('=')[1].ToString().TrimEnd(',');
                if (str.Contains("Protocol"))
                    Data["Protocol"] = str.Split('=')[1].ToString().TrimEnd(',');
                if (str.Contains("TimeToLive"))
                    Data["TimeToLive"] = str.Split('=')[1].ToString().Substring(0,3).TrimEnd(']');
                if (str.Contains("SourcePort"))
                    Data["SourcePort"] = str.Split('=')[1].ToString().TrimEnd(',');
                if (str.Contains("DestinationPort"))
                    Data["DestinationPort"] = str.Split('=')[1].ToString().TrimEnd(',');
            }

            //foreach (string str in Data.Keys)
            //{
            //    Console.Out.WriteLine(Data[str]);
            //}

            //Console.Out.WriteLine(eth);
            return Data;
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
