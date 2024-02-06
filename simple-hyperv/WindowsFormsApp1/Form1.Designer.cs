namespace WindowsFormsApp1
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
            this.btnCurDir = new System.Windows.Forms.Button();
            this.buttonVmRefresh = new System.Windows.Forms.Button();
            this.listBoxVM = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.buttonMstsc = new System.Windows.Forms.Button();
            this.buttonMmcHyperV = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonNetwork = new System.Windows.Forms.Button();
            this.buttonLogs = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCurDir
            // 
            this.btnCurDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCurDir.Location = new System.Drawing.Point(667, 414);
            this.btnCurDir.Margin = new System.Windows.Forms.Padding(5);
            this.btnCurDir.Name = "btnCurDir";
            this.btnCurDir.Size = new System.Drawing.Size(41, 48);
            this.btnCurDir.TabIndex = 3;
            this.btnCurDir.Text = "&.";
            this.btnCurDir.UseVisualStyleBackColor = true;
            this.btnCurDir.Click += new System.EventHandler(this.btnCurDir_Click);
            // 
            // buttonVmRefresh
            // 
            this.buttonVmRefresh.Location = new System.Drawing.Point(6, 253);
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
            this.listBoxVM.Size = new System.Drawing.Size(678, 244);
            this.listBoxVM.TabIndex = 6;
            this.listBoxVM.SelectedIndexChanged += new System.EventHandler(this.listBoxVM_SelectedIndexChanged);
            this.listBoxVM.DoubleClick += new System.EventHandler(this.listBoxVM_DoubleClick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(101, 429);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(102, 16);
            this.progressBar1.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(8, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(700, 398);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonConnect);
            this.tabPage1.Controls.Add(this.buttonStop);
            this.tabPage1.Controls.Add(this.buttonStart);
            this.tabPage1.Controls.Add(this.listBoxVM);
            this.tabPage1.Controls.Add(this.buttonVmRefresh);
            this.tabPage1.ImageKey = "icon-hyperv.ico";
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(692, 361);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "VM";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConnect.Cursor = System.Windows.Forms.Cursors.Help;
            this.buttonConnect.ForeColor = System.Drawing.SystemColors.Highlight;
            this.buttonConnect.Location = new System.Drawing.Point(562, 254);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(122, 44);
            this.buttonConnect.TabIndex = 12;
            this.buttonConnect.Text = "&Connect";
            this.toolTip1.SetToolTip(this.buttonConnect, "为了保证兼容性，请手动复制 C:\\Windows\\System32\\vmconnect.exe 到程序同目录，否则可能无法正常运行");
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonVmConnect_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.Location = new System.Drawing.Point(434, 254);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(122, 44);
            this.buttonStop.TabIndex = 11;
            this.buttonStop.Text = "St&op";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonVmStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(306, 254);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(122, 44);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "&Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonVmStart_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.ImageKey = "shell32.dll(19).ico";
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(692, 361);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Network";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.tabPage3.Size = new System.Drawing.Size(692, 361);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Switch";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonSwitchCreate
            // 
            this.buttonSwitchCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSwitchCreate.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonSwitchCreate.Location = new System.Drawing.Point(520, 253);
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
            this.buttonSwitchDelete.Location = new System.Drawing.Point(402, 253);
            this.buttonSwitchDelete.Name = "buttonSwitchDelete";
            this.buttonSwitchDelete.Size = new System.Drawing.Size(112, 45);
            this.buttonSwitchDelete.TabIndex = 19;
            this.buttonSwitchDelete.Text = "&Delete";
            this.buttonSwitchDelete.UseVisualStyleBackColor = true;
            this.buttonSwitchDelete.Click += new System.EventHandler(this.buttonSwitchDelete_Click);
            // 
            // buttonSwitchRefresh
            // 
            this.buttonSwitchRefresh.Location = new System.Drawing.Point(6, 253);
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
            this.listBoxSwitch.Size = new System.Drawing.Size(678, 244);
            this.listBoxSwitch.TabIndex = 16;
            this.listBoxSwitch.SelectedIndexChanged += new System.EventHandler(this.listBoxSwitch_SelectedIndexChanged);
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
            this.tabPage4.Size = new System.Drawing.Size(692, 361);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "NetNat";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // buttonNatCreate
            // 
            this.buttonNatCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNatCreate.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonNatCreate.Location = new System.Drawing.Point(520, 253);
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
            this.listBoxNat.Size = new System.Drawing.Size(678, 244);
            this.listBoxNat.TabIndex = 15;
            // 
            // buttonNatDelete
            // 
            this.buttonNatDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNatDelete.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonNatDelete.Location = new System.Drawing.Point(402, 253);
            this.buttonNatDelete.Name = "buttonNatDelete";
            this.buttonNatDelete.Size = new System.Drawing.Size(112, 45);
            this.buttonNatDelete.TabIndex = 14;
            this.buttonNatDelete.Text = "&Delete";
            this.buttonNatDelete.UseVisualStyleBackColor = true;
            this.buttonNatDelete.Click += new System.EventHandler(this.buttonNatDelete_Click);
            // 
            // buttonNatRefresh
            // 
            this.buttonNatRefresh.Location = new System.Drawing.Point(6, 253);
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
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(692, 361);
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
            this.richTextBox1.Location = new System.Drawing.Point(6, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(680, 386);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.WordWrap = false;
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
            // buttonMstsc
            // 
            this.buttonMstsc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMstsc.Location = new System.Drawing.Point(404, 414);
            this.buttonMstsc.Margin = new System.Windows.Forms.Padding(5);
            this.buttonMstsc.Name = "buttonMstsc";
            this.buttonMstsc.Size = new System.Drawing.Size(85, 48);
            this.buttonMstsc.TabIndex = 14;
            this.buttonMstsc.Text = "&mstsc";
            this.buttonMstsc.UseVisualStyleBackColor = true;
            this.buttonMstsc.Click += new System.EventHandler(this.buttonMstsc_Click);
            // 
            // buttonMmcHyperV
            // 
            this.buttonMmcHyperV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMmcHyperV.Location = new System.Drawing.Point(499, 414);
            this.buttonMmcHyperV.Margin = new System.Windows.Forms.Padding(5);
            this.buttonMmcHyperV.Name = "buttonMmcHyperV";
            this.buttonMmcHyperV.Size = new System.Drawing.Size(158, 48);
            this.buttonMmcHyperV.TabIndex = 13;
            this.buttonMmcHyperV.Text = "&virtmgmt.msc";
            this.buttonMmcHyperV.UseVisualStyleBackColor = true;
            this.buttonMmcHyperV.Click += new System.EventHandler(this.buttonMmcHyperV_Click);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOutput.Location = new System.Drawing.Point(16, 470);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutput.Size = new System.Drawing.Size(692, 257);
            this.textBoxOutput.TabIndex = 10;
            this.textBoxOutput.Visible = false;
            this.textBoxOutput.WordWrap = false;
            // 
            // buttonNetwork
            // 
            this.buttonNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNetwork.Location = new System.Drawing.Point(275, 414);
            this.buttonNetwork.Margin = new System.Windows.Forms.Padding(5);
            this.buttonNetwork.Name = "buttonNetwork";
            this.buttonNetwork.Size = new System.Drawing.Size(119, 48);
            this.buttonNetwork.TabIndex = 17;
            this.buttonNetwork.Text = "&Network";
            this.buttonNetwork.UseVisualStyleBackColor = true;
            this.buttonNetwork.Click += new System.EventHandler(this.buttonNetwork_Click);
            // 
            // buttonLogs
            // 
            this.buttonLogs.Location = new System.Drawing.Point(16, 414);
            this.buttonLogs.Margin = new System.Windows.Forms.Padding(5);
            this.buttonLogs.Name = "buttonLogs";
            this.buttonLogs.Size = new System.Drawing.Size(77, 48);
            this.buttonLogs.TabIndex = 18;
            this.buttonLogs.Text = "&Logs";
            this.buttonLogs.UseVisualStyleBackColor = true;
            this.buttonLogs.Click += new System.EventHandler(this.buttonLogs_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 474);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonLogs);
            this.Controls.Add(this.buttonNetwork);
            this.Controls.Add(this.buttonMmcHyperV);
            this.Controls.Add(this.btnCurDir);
            this.Controls.Add(this.buttonMstsc);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Simple Hyper-V";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCurDir;
        private System.Windows.Forms.Button buttonVmRefresh;
        private System.Windows.Forms.ListBox listBoxVM;
        public System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        public System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonMmcHyperV;
        private System.Windows.Forms.Button buttonMstsc;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonNatDelete;
        private System.Windows.Forms.Button buttonNatRefresh;
        private System.Windows.Forms.ListBox listBoxNat;
        private System.Windows.Forms.Button buttonNatCreate;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button buttonNetwork;
        private System.Windows.Forms.Button buttonSwitchCreate;
        private System.Windows.Forms.Button buttonSwitchDelete;
        private System.Windows.Forms.Button buttonSwitchRefresh;
        private System.Windows.Forms.ListBox listBoxSwitch;
        private System.Windows.Forms.Button buttonLogs;
    }
}

