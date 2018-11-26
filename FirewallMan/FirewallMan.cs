using System;
using System.Windows.Forms;
using FirewallInterface;
using System.IO;

namespace FirewallMan
{
    public partial class FirewallMan : Form
    {
        public Firewall FW;
        public FirewallMan()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;

            FW = new Firewall();

            this.AllowDrop = true;
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);

            loadRules();
        }

        private void deleteRule(string ruleName)
        {
            try
            {
                FW.deleteRule(ruleName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadRules(bool Glasswire = false)
        {
            listView1.Items.Clear();
            try
            {

                foreach (string[] rule in FW.loadRules(Glasswire))
                {
                    listView1.Items.Add(new ListViewItem(rule));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox3.Text == "Inbound")
                    FW.addRule(textBox1.Text, (Firewall.RuleAction)comboBox1.SelectedIndex, Firewall.RuleDirection.Inbound, Firewall.RuleProtocol.ANY);
                else
                    FW.addRule(textBox1.Text, (Firewall.RuleAction)comboBox1.SelectedIndex, Firewall.RuleDirection.Outbound, Firewall.RuleProtocol.ANY);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadRules();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.CheckFileExists = true;
            file.InitialDirectory = @"C:\";
            if (file.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = file.FileName;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                deleteRule(listView1.SelectedItems[0].Text);
                loadRules();
            }
            catch { }
        }

        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            string[] files;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                files = (string[])(e.Data.GetData(DataFormats.FileDrop));
            else if (e.Data.GetDataPresent(typeof(string[])))
                files = (string[])(e.Data.GetData(typeof(string[])));
            else
                return;

            textBox1.Text = files[0];
        }

        private void Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else if (e.Data.GetDataPresent(typeof(string[])))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void exportRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "Export Rules";
            sfd.OverwritePrompt = true;
            sfd.Filter = "Text File (.txt) | *.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filename = sfd.FileName.ToString();
                if (filename != "")
                {
                    using (StreamWriter sw = new StreamWriter(filename, false))
                    {
                        foreach (ListViewItem item in listView1.Items)
                        {
                            sw.WriteLine("{0}{1}{2}{3}{4}{5}{6}", item.SubItems[0].Text, ";", item.SubItems[1].Text, ";", item.SubItems[2].Text, ";", item.SubItems[3].Text);
                        }
                    }
                }
            }
        }

        private void importRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Import Rules";
            ofd.Filter = "Text File (.txt) | *.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filename = ofd.FileName.ToString();
                if (File.Exists(filename))
                {
                    using (StreamReader sr = new StreamReader(filename, true))
                    {
                        string fileContents = sr.ReadToEnd();
                        string[] fileLines = fileContents.Substring(0,fileContents.Length-1).Split('\n');

                        foreach (string lineStr in fileLines)
                        {
                            string[] line = lineStr.Split(';');
                            //Console.Out.WriteLine(line[0]); // Rule Name
                            //Console.Out.WriteLine(line[1]); // Action
                            //Console.Out.WriteLine(line[2]); // Direction
                            //Console.Out.WriteLine(line[3]); // Path

                            Firewall.RuleAction action;
                            if (line[1] == "BLOCK")
                                action = Firewall.RuleAction.BLOCK;
                            else
                                action = Firewall.RuleAction.ALLOW;

                            Firewall.RuleDirection direction;
                            if (line[2] == "INBOUND")
                                direction = Firewall.RuleDirection.Inbound;
                            else
                                direction = Firewall.RuleDirection.Outbound;

                            FW.addRule(line[3], action, direction, Firewall.RuleProtocol.ANY);
                        }
                    }
                }
                loadRules();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadGlasswireRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadRules(true);
        }

        private void convertGlasswireRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            try
            {
                foreach (string[] rule in FW.loadRules(true))
                {
                    //Console.Out.WriteLine("{0}{1}{2}{3}", rule);
                    // rule[0] = Rule Name
                    // rule[1] = Action
                    // rule[2] = Direction
                    // rule[3] = Application Path

                    try
                    {
                        if (!File.Exists(rule[3]))
                            continue;
                    }
                    catch { }

                    if (rule[1] == "BLOCK")
                    {
                        if (rule[2] == "INBOUND")
                            FW.addRule(rule[3], Firewall.RuleAction.BLOCK, Firewall.RuleDirection.Inbound, Firewall.RuleProtocol.ANY);
                        else
                            FW.addRule(rule[3], Firewall.RuleAction.BLOCK, Firewall.RuleDirection.Outbound, Firewall.RuleProtocol.ANY);
                    }
                    else
                    {
                        if (rule[2] == "INBOUND")
                            FW.addRule(rule[3], Firewall.RuleAction.ALLOW, Firewall.RuleDirection.Inbound, Firewall.RuleProtocol.ANY);
                        else
                            FW.addRule(rule[3], Firewall.RuleAction.ALLOW, Firewall.RuleDirection.Outbound, Firewall.RuleProtocol.ANY);
                    }

                    //listView1.Items.Add(new ListViewItem(rule));
                }
                loadRules();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
                deleteRule(item.Text);
            loadRules();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            loadRules();
        }

        private void networkMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ARPScanner NW = new ARPScanner();
            NW.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
                FW.ToggleAction(item.Text);
            loadRules();
        }

        private void toggleDirectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
                FW.ToggleDirection(item.Text);
            loadRules();
        }

        private void packetCaptureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pcap packetCap = new Pcap();
            packetCap.Show();
        }
    }
}
