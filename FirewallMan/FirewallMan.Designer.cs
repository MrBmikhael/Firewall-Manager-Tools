namespace FirewallMan
{
    partial class FirewallMan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ruleName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDirection = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rulePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleDirectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exportRulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importRulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.glasswireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGlasswireRulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertGlasswireRulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.networkMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packetCaptureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewContextMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(947, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Rule";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ruleName,
            this.columnStatus,
            this.columnDirection,
            this.rulePath});
            this.listView1.ContextMenuStrip = this.listViewContextMenu;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 91);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1028, 459);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ruleName
            // 
            this.ruleName.Text = "Rule Name";
            this.ruleName.Width = 95;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.Width = 56;
            // 
            // columnDirection
            // 
            this.columnDirection.Text = "Direction";
            this.columnDirection.Width = 75;
            // 
            // rulePath
            // 
            this.rulePath.Text = "Path";
            this.rulePath.Width = 793;
            // 
            // listViewContextMenu
            // 
            this.listViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem6,
            this.toggleDirectionToolStripMenuItem});
            this.listViewContextMenu.Name = "contextMenuStrip1";
            this.listViewContextMenu.Size = new System.Drawing.Size(162, 70);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem1.Text = "Delete";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem6.Text = "Toggle Action";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toggleDirectionToolStripMenuItem
            // 
            this.toggleDirectionToolStripMenuItem.Name = "toggleDirectionToolStripMenuItem";
            this.toggleDirectionToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.toggleDirectionToolStripMenuItem.Text = "Toggle Direction";
            this.toggleDirectionToolStripMenuItem.Click += new System.EventHandler(this.toggleDirectionToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1028, 58);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Rule";
            // 
            // comboBox3
            // 
            this.comboBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox3.DisplayMember = "0";
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Inbound",
            "Outbound"});
            this.comboBox3.Location = new System.Drawing.Point(100, 19);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(88, 21);
            this.comboBox3.TabIndex = 5;
            this.comboBox3.ValueMember = "0";
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox1.DisplayMember = "0";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "BLOCK",
            "ALLOW"});
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(88, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.ValueMember = "0";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(866, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.Location = new System.Drawing.Point(194, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(666, 20);
            this.textBox1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.glasswireToolStripMenuItem,
            this.toolStripMenuItem5});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1052, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripSeparator3,
            this.exportRulesToolStripMenuItem,
            this.importRulesToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItem3,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem2.Text = "File";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem4.Text = "Refresh";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(152, 6);
            // 
            // exportRulesToolStripMenuItem
            // 
            this.exportRulesToolStripMenuItem.Name = "exportRulesToolStripMenuItem";
            this.exportRulesToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exportRulesToolStripMenuItem.Text = "Export Rules";
            this.exportRulesToolStripMenuItem.Click += new System.EventHandler(this.exportRulesToolStripMenuItem_Click);
            // 
            // importRulesToolStripMenuItem
            // 
            this.importRulesToolStripMenuItem.Name = "importRulesToolStripMenuItem";
            this.importRulesToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.importRulesToolStripMenuItem.Text = "Import Rules";
            this.importRulesToolStripMenuItem.Click += new System.EventHandler(this.importRulesToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem3.Text = "Delete All Rules";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // glasswireToolStripMenuItem
            // 
            this.glasswireToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadGlasswireRulesToolStripMenuItem,
            this.convertGlasswireRulesToolStripMenuItem});
            this.glasswireToolStripMenuItem.Name = "glasswireToolStripMenuItem";
            this.glasswireToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.glasswireToolStripMenuItem.Text = "GlassWire";
            // 
            // loadGlasswireRulesToolStripMenuItem
            // 
            this.loadGlasswireRulesToolStripMenuItem.Name = "loadGlasswireRulesToolStripMenuItem";
            this.loadGlasswireRulesToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.loadGlasswireRulesToolStripMenuItem.Text = "Load Rules";
            this.loadGlasswireRulesToolStripMenuItem.Click += new System.EventHandler(this.loadGlasswireRulesToolStripMenuItem_Click);
            // 
            // convertGlasswireRulesToolStripMenuItem
            // 
            this.convertGlasswireRulesToolStripMenuItem.Name = "convertGlasswireRulesToolStripMenuItem";
            this.convertGlasswireRulesToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.convertGlasswireRulesToolStripMenuItem.Text = "Import Rules";
            this.convertGlasswireRulesToolStripMenuItem.Click += new System.EventHandler(this.convertGlasswireRulesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.networkMonitorToolStripMenuItem,
            this.packetCaptureToolStripMenuItem});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(47, 20);
            this.toolStripMenuItem5.Text = "Tools";
            // 
            // networkMonitorToolStripMenuItem
            // 
            this.networkMonitorToolStripMenuItem.Name = "networkMonitorToolStripMenuItem";
            this.networkMonitorToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.networkMonitorToolStripMenuItem.Text = "ARP Scanner";
            this.networkMonitorToolStripMenuItem.Click += new System.EventHandler(this.networkMonitorToolStripMenuItem_Click);
            // 
            // packetCaptureToolStripMenuItem
            // 
            this.packetCaptureToolStripMenuItem.Name = "packetCaptureToolStripMenuItem";
            this.packetCaptureToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.packetCaptureToolStripMenuItem.Text = "Packet Capture";
            this.packetCaptureToolStripMenuItem.Click += new System.EventHandler(this.packetCaptureToolStripMenuItem_Click);
            // 
            // FirewallMan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 562);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FirewallMan";
            this.Text = "Firewall Manager";
            this.listViewContextMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ruleName;
        private System.Windows.Forms.ColumnHeader rulePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip listViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportRulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importRulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem glasswireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGlasswireRulesToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem convertGlasswireRulesToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ColumnHeader columnDirection;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem networkMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toggleDirectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packetCaptureToolStripMenuItem;
    }
}

