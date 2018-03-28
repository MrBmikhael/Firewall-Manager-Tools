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


namespace FirewallMan
{
    public partial class ARPScanner : Form
    {
        public ARPScanner()
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

        }
    }
}
