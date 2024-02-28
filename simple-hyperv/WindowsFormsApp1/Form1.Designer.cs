namespace SimpleHyperVForm1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonVmRefresh = new System.Windows.Forms.Button();
            this.listBoxVM = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.menuStripVmActions = new System.Windows.Forms.MenuStrip();
            this.moreActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printVMInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vMSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableNestedVMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteVMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonSwitchCreate = new System.Windows.Forms.Button();
            this.buttonSwitchDelete = new System.Windows.Forms.Button();
            this.buttonSwitchRefresh = new System.Windows.Forms.Button();
            this.listBoxSwitch = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.buttonNatCreate = new System.Windows.Forms.Button();
            this.listBoxNat = new System.Windows.Forms.ListBox();
            this.buttonNatDelete = new System.Windows.Forms.Button();
            this.buttonNatRefresh = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hyperVManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hyperVSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createVMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.virtualSwitchManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optimizeVHDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.networkConnectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskschdmscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStripVmActions.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonVmRefresh
            // 
            this.buttonVmRefresh.Location = new System.Drawing.Point(6, 232);
            this.buttonVmRefresh.Name = "buttonVmRefresh";
            this.buttonVmRefresh.Size = new System.Drawing.Size(134, 45);
            this.buttonVmRefresh.TabIndex = 5;
            this.buttonVmRefresh.Text = "&Refresh";
            this.buttonVmRefresh.UseVisualStyleBackColor = true;
            this.buttonVmRefresh.Click += new System.EventHandler(this.buttonVmRefresh_Click_1);
            // 
            // listBoxVM
            // 
            this.listBoxVM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxVM.FormattingEnabled = true;
            this.listBoxVM.ItemHeight = 24;
            this.listBoxVM.Location = new System.Drawing.Point(6, 3);
            this.listBoxVM.Name = "listBoxVM";
            this.listBoxVM.Size = new System.Drawing.Size(678, 172);
            this.listBoxVM.TabIndex = 6;
            this.listBoxVM.SelectedIndexChanged += new System.EventHandler(this.listBoxVM_SelectedIndexChanged);
            this.listBoxVM.DoubleClick += new System.EventHandler(this.listBoxVM_DoubleClick);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(606, 453);
            this.progressBar1.MarqueeAnimationSpeed = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(102, 16);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 7;
            this.progressBar1.UseWaitCursor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(12, 36);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(8, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(700, 411);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.menuStripVmActions);
            this.tabPage1.Controls.Add(this.buttonConnect);
            this.tabPage1.Controls.Add(this.buttonStop);
            this.tabPage1.Controls.Add(this.buttonStart);
            this.tabPage1.Controls.Add(this.buttonVmRefresh);
            this.tabPage1.Controls.Add(this.listBoxVM);
            this.tabPage1.ImageKey = "icon-hyperv.ico";
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(692, 374);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "VM";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // menuStripVmActions
            // 
            this.menuStripVmActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStripVmActions.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStripVmActions.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripVmActions.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStripVmActions.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripVmActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moreActionsToolStripMenuItem});
            this.menuStripVmActions.Location = new System.Drawing.Point(535, 290);
            this.menuStripVmActions.Name = "menuStripVmActions";
            this.menuStripVmActions.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.menuStripVmActions.Size = new System.Drawing.Size(149, 32);
            this.menuStripVmActions.TabIndex = 18;
            this.menuStripVmActions.Text = "menuStripVmActions";
            // 
            // moreActionsToolStripMenuItem
            // 
            this.moreActionsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.moreActionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printVMInfoToolStripMenuItem,
            this.vMSettingsToolStripMenuItem,
            this.enableNestedVMToolStripMenuItem,
            this.deleteVMToolStripMenuItem});
            this.moreActionsToolStripMenuItem.Name = "moreActionsToolStripMenuItem";
            this.moreActionsToolStripMenuItem.Size = new System.Drawing.Size(141, 28);
            this.moreActionsToolStripMenuItem.Text = "More Actions";
            // 
            // printVMInfoToolStripMenuItem
            // 
            this.printVMInfoToolStripMenuItem.Name = "printVMInfoToolStripMenuItem";
            this.printVMInfoToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.printVMInfoToolStripMenuItem.Text = "Print VM Info";
            this.printVMInfoToolStripMenuItem.Click += new System.EventHandler(this.printVMInfoToolStripMenuItem_Click);
            // 
            // vMSettingsToolStripMenuItem
            // 
            this.vMSettingsToolStripMenuItem.Image = global::SimpleHyperV.Properties.Resources.icon_hyperv;
            this.vMSettingsToolStripMenuItem.Name = "vMSettingsToolStripMenuItem";
            this.vMSettingsToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.vMSettingsToolStripMenuItem.Text = "VM Settings";
            this.vMSettingsToolStripMenuItem.Click += new System.EventHandler(this.vMSettingsToolStripMenuItem_Click);
            // 
            // enableNestedVMToolStripMenuItem
            // 
            this.enableNestedVMToolStripMenuItem.Name = "enableNestedVMToolStripMenuItem";
            this.enableNestedVMToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.enableNestedVMToolStripMenuItem.Text = "Enable Nested VM";
            this.enableNestedVMToolStripMenuItem.Click += new System.EventHandler(this.enableNestedVMToolStripMenuItem_Click);
            // 
            // deleteVMToolStripMenuItem
            // 
            this.deleteVMToolStripMenuItem.Name = "deleteVMToolStripMenuItem";
            this.deleteVMToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.deleteVMToolStripMenuItem.Text = "Delete VM...";
            this.deleteVMToolStripMenuItem.Click += new System.EventHandler(this.deleteVMToolStripMenuItem_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConnect.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonConnect.ForeColor = System.Drawing.SystemColors.Highlight;
            this.buttonConnect.Location = new System.Drawing.Point(562, 234);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(122, 44);
            this.buttonConnect.TabIndex = 12;
            this.buttonConnect.Text = "&Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonVmConnect_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.Cursor = System.Windows.Forms.Cursors.Help;
            this.buttonStop.Location = new System.Drawing.Point(434, 234);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(122, 44);
            this.buttonStop.TabIndex = 11;
            this.buttonStop.Text = "St&op";
            this.toolTip1.SetToolTip(this.buttonStop, "Press Shift simultaneously to force shut down the virtual machine.\r\n同时按下Shift以强制关" +
        "闭虚拟机。");
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonVmStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(306, 234);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(122, 44);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "&Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonVmStart_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonSwitchCreate);
            this.tabPage3.Controls.Add(this.buttonSwitchDelete);
            this.tabPage3.Controls.Add(this.buttonSwitchRefresh);
            this.tabPage3.Controls.Add(this.listBoxSwitch);
            this.tabPage3.ImageKey = "shell32.dll(176).ico";
            this.tabPage3.Location = new System.Drawing.Point(4, 33);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(692, 374);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Switch";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonSwitchCreate
            // 
            this.buttonSwitchCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSwitchCreate.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonSwitchCreate.Location = new System.Drawing.Point(520, 232);
            this.buttonSwitchCreate.Name = "buttonSwitchCreate";
            this.buttonSwitchCreate.Size = new System.Drawing.Size(164, 45);
            this.buttonSwitchCreate.TabIndex = 20;
            this.buttonSwitchCreate.Text = "&New Switch";
            this.buttonSwitchCreate.UseVisualStyleBackColor = true;
            this.buttonSwitchCreate.Click += new System.EventHandler(this.buttonSwitchCreate_Click);
            // 
            // buttonSwitchDelete
            // 
            this.buttonSwitchDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSwitchDelete.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonSwitchDelete.Location = new System.Drawing.Point(402, 232);
            this.buttonSwitchDelete.Name = "buttonSwitchDelete";
            this.buttonSwitchDelete.Size = new System.Drawing.Size(112, 45);
            this.buttonSwitchDelete.TabIndex = 19;
            this.buttonSwitchDelete.Text = "&Delete";
            this.buttonSwitchDelete.UseVisualStyleBackColor = true;
            this.buttonSwitchDelete.Click += new System.EventHandler(this.buttonSwitchDelete_Click);
            // 
            // buttonSwitchRefresh
            // 
            this.buttonSwitchRefresh.Location = new System.Drawing.Point(6, 232);
            this.buttonSwitchRefresh.Name = "buttonSwitchRefresh";
            this.buttonSwitchRefresh.Size = new System.Drawing.Size(134, 45);
            this.buttonSwitchRefresh.TabIndex = 18;
            this.buttonSwitchRefresh.Text = "&Refresh";
            this.buttonSwitchRefresh.UseVisualStyleBackColor = true;
            this.buttonSwitchRefresh.Click += new System.EventHandler(this.buttonSwitchRefresh_Click);
            // 
            // listBoxSwitch
            // 
            this.listBoxSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxSwitch.FormattingEnabled = true;
            this.listBoxSwitch.ItemHeight = 24;
            this.listBoxSwitch.Location = new System.Drawing.Point(6, 3);
            this.listBoxSwitch.Name = "listBoxSwitch";
            this.listBoxSwitch.Size = new System.Drawing.Size(678, 172);
            this.listBoxSwitch.TabIndex = 16;
            this.listBoxSwitch.SelectedIndexChanged += new System.EventHandler(this.listBoxSwitch_SelectedIndexChanged);
            this.listBoxSwitch.DoubleClick += new System.EventHandler(this.listBoxSwitch_DoubleClick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.buttonNatCreate);
            this.tabPage4.Controls.Add(this.listBoxNat);
            this.tabPage4.Controls.Add(this.buttonNatDelete);
            this.tabPage4.Controls.Add(this.buttonNatRefresh);
            this.tabPage4.ImageKey = "shell32.dll(244).ico";
            this.tabPage4.Location = new System.Drawing.Point(4, 33);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(692, 374);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "NetNat";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // buttonNatCreate
            // 
            this.buttonNatCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNatCreate.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonNatCreate.Location = new System.Drawing.Point(520, 232);
            this.buttonNatCreate.Name = "buttonNatCreate";
            this.buttonNatCreate.Size = new System.Drawing.Size(164, 45);
            this.buttonNatCreate.TabIndex = 16;
            this.buttonNatCreate.Text = "&New NetNat";
            this.buttonNatCreate.UseVisualStyleBackColor = true;
            this.buttonNatCreate.Click += new System.EventHandler(this.buttonNatCreate_Click);
            // 
            // listBoxNat
            // 
            this.listBoxNat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxNat.FormattingEnabled = true;
            this.listBoxNat.ItemHeight = 24;
            this.listBoxNat.Location = new System.Drawing.Point(6, 3);
            this.listBoxNat.Name = "listBoxNat";
            this.listBoxNat.Size = new System.Drawing.Size(678, 172);
            this.listBoxNat.TabIndex = 15;
            this.listBoxNat.DoubleClick += new System.EventHandler(this.listBoxNat_DoubleClick);
            // 
            // buttonNatDelete
            // 
            this.buttonNatDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNatDelete.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonNatDelete.Location = new System.Drawing.Point(402, 232);
            this.buttonNatDelete.Name = "buttonNatDelete";
            this.buttonNatDelete.Size = new System.Drawing.Size(112, 45);
            this.buttonNatDelete.TabIndex = 14;
            this.buttonNatDelete.Text = "&Delete";
            this.buttonNatDelete.UseVisualStyleBackColor = true;
            this.buttonNatDelete.Click += new System.EventHandler(this.buttonNatDelete_Click);
            // 
            // buttonNatRefresh
            // 
            this.buttonNatRefresh.Location = new System.Drawing.Point(6, 232);
            this.buttonNatRefresh.Name = "buttonNatRefresh";
            this.buttonNatRefresh.Size = new System.Drawing.Size(134, 45);
            this.buttonNatRefresh.TabIndex = 6;
            this.buttonNatRefresh.Text = "&Refresh";
            this.buttonNatRefresh.UseVisualStyleBackColor = true;
            this.buttonNatRefresh.Click += new System.EventHandler(this.buttonNatRefresh_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.richTextBox1);
            this.tabPage5.ImageKey = "shell32.dll(16782).ico";
            this.tabPage5.Location = new System.Drawing.Point(4, 33);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage5.Size = new System.Drawing.Size(692, 374);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "About";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.AutoWordSelection = true;
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(6, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(680, 362);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icon.ico");
            this.imageList1.Images.SetKeyName(1, "icon-hyperv.ico");
            this.imageList1.Images.SetKeyName(2, "shell32.dll(19).ico");
            this.imageList1.Images.SetKeyName(3, "shell32.dll(176).ico");
            this.imageList1.Images.SetKeyName(4, "shell32.dll(244).ico");
            this.imageList1.Images.SetKeyName(5, "shell32.dll(16782).ico");
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOutput.Location = new System.Drawing.Point(16, 453);
            this.textBoxOutput.MinimumSize = new System.Drawing.Size(500, 100);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutput.Size = new System.Drawing.Size(692, 274);
            this.textBoxOutput.TabIndex = 10;
            this.textBoxOutput.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Tips";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(724, 32);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hyperVManagerToolStripMenuItem,
            this.hyperVSettingsToolStripMenuItem,
            this.createVMToolStripMenuItem,
            this.virtualSwitchManagerToolStripMenuItem,
            this.editDiskToolStripMenuItem,
            this.optimizeVHDToolStripMenuItem,
            this.toolStripSeparator1,
            this.networkConnectionsToolStripMenuItem,
            this.remoteDesktopToolStripMenuItem,
            this.taskschdmscToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(71, 28);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // hyperVManagerToolStripMenuItem
            // 
            this.hyperVManagerToolStripMenuItem.Image = global::SimpleHyperV.Properties.Resources.icon_hyperv;
            this.hyperVManagerToolStripMenuItem.Name = "hyperVManagerToolStripMenuItem";
            this.hyperVManagerToolStripMenuItem.Size = new System.Drawing.Size(311, 34);
            this.hyperVManagerToolStripMenuItem.Text = "Hyper-V &Manager";
            this.hyperVManagerToolStripMenuItem.Click += new System.EventHandler(this.hyperVManagerToolStripMenuItem_Click);
            // 
            // hyperVSettingsToolStripMenuItem
            // 
            this.hyperVSettingsToolStripMenuItem.Name = "hyperVSettingsToolStripMenuItem";
            this.hyperVSettingsToolStripMenuItem.Size = new System.Drawing.Size(311, 34);
            this.hyperVSettingsToolStripMenuItem.Text = "Hyper-V &Settings";
            this.hyperVSettingsToolStripMenuItem.Click += new System.EventHandler(this.hyperVSettingsToolStripMenuItem_Click);
            // 
            // createVMToolStripMenuItem
            // 
            this.createVMToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.createVMToolStripMenuItem.Name = "createVMToolStripMenuItem";
            this.createVMToolStripMenuItem.Size = new System.Drawing.Size(311, 34);
            this.createVMToolStripMenuItem.Text = "&Create VM";
            this.createVMToolStripMenuItem.Click += new System.EventHandler(this.createVMToolStripMenuItem_Click);
            // 
            // virtualSwitchManagerToolStripMenuItem
            // 
            this.virtualSwitchManagerToolStripMenuItem.Name = "virtualSwitchManagerToolStripMenuItem";
            this.virtualSwitchManagerToolStripMenuItem.Size = new System.Drawing.Size(311, 34);
            this.virtualSwitchManagerToolStripMenuItem.Text = "Virtual Switch Manager";
            this.virtualSwitchManagerToolStripMenuItem.Click += new System.EventHandler(this.virtualSwitchManagerToolStripMenuItem_Click);
            // 
            // editDiskToolStripMenuItem
            // 
            this.editDiskToolStripMenuItem.Name = "editDiskToolStripMenuItem";
            this.editDiskToolStripMenuItem.Size = new System.Drawing.Size(311, 34);
            this.editDiskToolStripMenuItem.Text = "Edit Disk";
            this.editDiskToolStripMenuItem.Click += new System.EventHandler(this.editDiskToolStripMenuItem_Click);
            // 
            // optimizeVHDToolStripMenuItem
            // 
            this.optimizeVHDToolStripMenuItem.Name = "optimizeVHDToolStripMenuItem";
            this.optimizeVHDToolStripMenuItem.Size = new System.Drawing.Size(311, 34);
            this.optimizeVHDToolStripMenuItem.Text = "Optimize VHD...";
            this.optimizeVHDToolStripMenuItem.Click += new System.EventHandler(this.optimizeVHDToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(308, 6);
            // 
            // networkConnectionsToolStripMenuItem
            // 
            this.networkConnectionsToolStripMenuItem.Name = "networkConnectionsToolStripMenuItem";
            this.networkConnectionsToolStripMenuItem.Size = new System.Drawing.Size(311, 34);
            this.networkConnectionsToolStripMenuItem.Text = "&Network Connections";
            this.networkConnectionsToolStripMenuItem.Click += new System.EventHandler(this.networkConnectionsToolStripMenuItem_Click);
            // 
            // remoteDesktopToolStripMenuItem
            // 
            this.remoteDesktopToolStripMenuItem.Name = "remoteDesktopToolStripMenuItem";
            this.remoteDesktopToolStripMenuItem.Size = new System.Drawing.Size(320, 34);
            this.remoteDesktopToolStripMenuItem.Text = "&Remote Desktop (mstsc)";
            this.remoteDesktopToolStripMenuItem.Click += new System.EventHandler(this.remoteDesktopToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(311, 34);
            this.openToolStripMenuItem.Text = "&Open ./";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitStripMenuItem
            // 
            this.exitStripMenuItem.Name = "exitStripMenuItem";
            this.exitStripMenuItem.Size = new System.Drawing.Size(311, 34);
            this.exitStripMenuItem.Text = "&Exit";
            this.exitStripMenuItem.Click += new System.EventHandler(this.exitStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLogsToolStripMenuItem,
            this.closeToTrayToolStripMenuItem,
            this.autoStartupToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(95, 28);
            this.optionsToolStripMenuItem.Text = "O&ptions";
            // 
            // showLogsToolStripMenuItem
            // 
            this.showLogsToolStripMenuItem.CheckOnClick = true;
            this.showLogsToolStripMenuItem.Name = "showLogsToolStripMenuItem";
            this.showLogsToolStripMenuItem.Size = new System.Drawing.Size(221, 34);
            this.showLogsToolStripMenuItem.Text = "Show &Logs";
            this.showLogsToolStripMenuItem.Click += new System.EventHandler(this.showLogsToolStripMenuItem_Click);
            // 
            // closeToTrayToolStripMenuItem
            // 
            this.closeToTrayToolStripMenuItem.CheckOnClick = true;
            this.closeToTrayToolStripMenuItem.Name = "closeToTrayToolStripMenuItem";
            this.closeToTrayToolStripMenuItem.Size = new System.Drawing.Size(221, 34);
            this.closeToTrayToolStripMenuItem.Text = "&Close to Tray";
            this.closeToTrayToolStripMenuItem.Click += new System.EventHandler(this.closeToTrayToolStripMenuItem_Click);
            // 
            // autoStartupToolStripMenuItem
            // 
            this.autoStartupToolStripMenuItem.CheckOnClick = true;
            this.autoStartupToolStripMenuItem.Name = "autoStartupToolStripMenuItem";
            this.autoStartupToolStripMenuItem.Size = new System.Drawing.Size(221, 34);
            this.autoStartupToolStripMenuItem.Text = "&Auto Startup";
            this.autoStartupToolStripMenuItem.Click += new System.EventHandler(this.autoStartupToolStripMenuItem_Click);
            // 
            // taskschdmscToolStripMenuItem
            // 
            this.taskschdmscToolStripMenuItem.Name = "taskschdmscToolStripMenuItem";
            this.taskschdmscToolStripMenuItem.Size = new System.Drawing.Size(320, 34);
            this.taskschdmscToolStripMenuItem.Text = "&taskschd.msc";
            this.taskschdmscToolStripMenuItem.Click += new System.EventHandler(this.taskschdmscToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(724, 744);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(594, 383);
            this.Name = "Form1";
            this.Text = "Simple Hyper-V";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.menuStripVmActions.ResumeLayout(false);
            this.menuStripVmActions.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonVmRefresh;
        private System.Windows.Forms.ListBox listBoxVM;
        public System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        public System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button buttonNatDelete;
        private System.Windows.Forms.Button buttonNatRefresh;
        private System.Windows.Forms.ListBox listBoxNat;
        private System.Windows.Forms.Button buttonNatCreate;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button buttonSwitchCreate;
        private System.Windows.Forms.Button buttonSwitchDelete;
        private System.Windows.Forms.Button buttonSwitchRefresh;
        private System.Windows.Forms.ListBox listBoxSwitch;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hyperVManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hyperVSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem virtualSwitchManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDiskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optimizeVHDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createVMToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem networkConnectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteDesktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToTrayToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStripVmActions;
        private System.Windows.Forms.ToolStripMenuItem moreActionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printVMInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vMSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableNestedVMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteVMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoStartupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskschdmscToolStripMenuItem;
    }
}

