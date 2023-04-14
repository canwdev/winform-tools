namespace ra_launcher_remaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.RA2 = new System.Windows.Forms.TabPage();
            this.RA3 = new System.Windows.Forms.TabPage();
            this.About = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnCurDir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRa2Launch = new System.Windows.Forms.Button();
            this.btnRa2LaunchWin = new System.Windows.Forms.Button();
            this.btnRa2Exit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRa2YrExit = new System.Windows.Forms.Button();
            this.btnRa2YrLaunchWin = new System.Windows.Forms.Button();
            this.btnRa2YrLaunch = new System.Windows.Forms.Button();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRa3Exit = new System.Windows.Forms.Button();
            this.btnRa3LaunchWin = new System.Windows.Forms.Button();
            this.btnRa3Launch = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.RA2.SuspendLayout();
            this.RA3.SuspendLayout();
            this.About.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.RA2);
            this.tabControl1.Controls.Add(this.RA3);
            this.tabControl1.Controls.Add(this.About);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(275, 369);
            this.tabControl1.TabIndex = 0;
            // 
            // RA2
            // 
            this.RA2.Controls.Add(this.groupBox3);
            this.RA2.Controls.Add(this.groupBox2);
            this.RA2.Controls.Add(this.groupBox1);
            this.RA2.Location = new System.Drawing.Point(4, 24);
            this.RA2.Name = "RA2";
            this.RA2.Padding = new System.Windows.Forms.Padding(3);
            this.RA2.Size = new System.Drawing.Size(267, 341);
            this.RA2.TabIndex = 0;
            this.RA2.Text = "RA2";
            this.RA2.UseVisualStyleBackColor = true;
            // 
            // RA3
            // 
            this.RA3.Controls.Add(this.groupBox4);
            this.RA3.Location = new System.Drawing.Point(4, 24);
            this.RA3.Name = "RA3";
            this.RA3.Padding = new System.Windows.Forms.Padding(3);
            this.RA3.Size = new System.Drawing.Size(267, 344);
            this.RA3.TabIndex = 1;
            this.RA3.Text = "RA3";
            this.RA3.UseVisualStyleBackColor = true;
            // 
            // About
            // 
            this.About.Controls.Add(this.labelCopyright);
            this.About.Controls.Add(this.btnCurDir);
            this.About.Controls.Add(this.linkLabel1);
            this.About.Controls.Add(this.richTextBox1);
            this.About.Location = new System.Drawing.Point(4, 24);
            this.About.Name = "About";
            this.About.Padding = new System.Windows.Forms.Padding(3);
            this.About.Size = new System.Drawing.Size(267, 344);
            this.About.TabIndex = 2;
            this.About.Text = "关于";
            this.About.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(271, 315);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "# 红警2/3 启动器\n\n把此程序放在红警2/3文件夹内，即可使用\n\n## 红警 2 说明\n\n- 建议以管理员身份运行此程序\n- 窗口模式(-win)需16位色\n" +
    "- 游戏在任务中可以调速(-speedcontrol)\n\n## 红警 3 说明\n\n- 支持开启控制台和窗口模式(-ui -win)\n- 支持自定义分辨率(-xr" +
    "es 1024 -yres 768)";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(218, 321);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(43, 15);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Github";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnCurDir
            // 
            this.btnCurDir.Location = new System.Drawing.Point(3, 317);
            this.btnCurDir.Name = "btnCurDir";
            this.btnCurDir.Size = new System.Drawing.Size(75, 23);
            this.btnCurDir.TabIndex = 3;
            this.btnCurDir.Text = "当前目录";
            this.btnCurDir.UseVisualStyleBackColor = true;
            this.btnCurDir.Click += new System.EventHandler(this.btnCurDir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnRa2Exit);
            this.groupBox1.Controls.Add(this.btnRa2LaunchWin);
            this.groupBox1.Controls.Add(this.btnRa2Launch);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RA2 (ra2.exe)";
            // 
            // btnRa2Launch
            // 
            this.btnRa2Launch.Location = new System.Drawing.Point(7, 23);
            this.btnRa2Launch.Name = "btnRa2Launch";
            this.btnRa2Launch.Size = new System.Drawing.Size(111, 23);
            this.btnRa2Launch.TabIndex = 0;
            this.btnRa2Launch.Text = "启动 (&Q)";
            this.btnRa2Launch.UseVisualStyleBackColor = true;
            this.btnRa2Launch.Click += new System.EventHandler(this.btnRa2Launch_Click);
            // 
            // btnRa2LaunchWin
            // 
            this.btnRa2LaunchWin.Location = new System.Drawing.Point(133, 23);
            this.btnRa2LaunchWin.Name = "btnRa2LaunchWin";
            this.btnRa2LaunchWin.Size = new System.Drawing.Size(111, 23);
            this.btnRa2LaunchWin.TabIndex = 1;
            this.btnRa2LaunchWin.Text = "窗口模式 (&W)";
            this.btnRa2LaunchWin.UseVisualStyleBackColor = true;
            this.btnRa2LaunchWin.Click += new System.EventHandler(this.btnRa2LaunchWin_Click);
            // 
            // btnRa2Exit
            // 
            this.btnRa2Exit.Location = new System.Drawing.Point(7, 53);
            this.btnRa2Exit.Name = "btnRa2Exit";
            this.btnRa2Exit.Size = new System.Drawing.Size(111, 23);
            this.btnRa2Exit.TabIndex = 2;
            this.btnRa2Exit.Text = "结束进程 (&E)";
            this.btnRa2Exit.UseVisualStyleBackColor = true;
            this.btnRa2Exit.Click += new System.EventHandler(this.btnRa2Exit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.btnRa2YrExit);
            this.groupBox2.Controls.Add(this.btnRa2YrLaunchWin);
            this.groupBox2.Controls.Add(this.btnRa2YrLaunch);
            this.groupBox2.Location = new System.Drawing.Point(8, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "YURI (ra2md.exe)";
            // 
            // btnRa2YrExit
            // 
            this.btnRa2YrExit.Location = new System.Drawing.Point(7, 53);
            this.btnRa2YrExit.Name = "btnRa2YrExit";
            this.btnRa2YrExit.Size = new System.Drawing.Size(111, 23);
            this.btnRa2YrExit.TabIndex = 2;
            this.btnRa2YrExit.Text = "结束进程 (&D)";
            this.btnRa2YrExit.UseVisualStyleBackColor = true;
            this.btnRa2YrExit.Click += new System.EventHandler(this.btnRa2YrExit_Click);
            // 
            // btnRa2YrLaunchWin
            // 
            this.btnRa2YrLaunchWin.Location = new System.Drawing.Point(133, 23);
            this.btnRa2YrLaunchWin.Name = "btnRa2YrLaunchWin";
            this.btnRa2YrLaunchWin.Size = new System.Drawing.Size(111, 23);
            this.btnRa2YrLaunchWin.TabIndex = 1;
            this.btnRa2YrLaunchWin.Text = "窗口模式 (&S)";
            this.btnRa2YrLaunchWin.UseVisualStyleBackColor = true;
            this.btnRa2YrLaunchWin.Click += new System.EventHandler(this.btnRa2YrLaunchWin_Click);
            // 
            // btnRa2YrLaunch
            // 
            this.btnRa2YrLaunch.Location = new System.Drawing.Point(7, 23);
            this.btnRa2YrLaunch.Name = "btnRa2YrLaunch";
            this.btnRa2YrLaunch.Size = new System.Drawing.Size(111, 23);
            this.btnRa2YrLaunch.TabIndex = 0;
            this.btnRa2YrLaunch.Text = "启动 (&A)";
            this.btnRa2YrLaunch.UseVisualStyleBackColor = true;
            this.btnRa2YrLaunch.Click += new System.EventHandler(this.btnRa2YrLaunch_Click);
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Location = new System.Drawing.Point(120, 321);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(94, 15);
            this.labelCopyright.TabIndex = 4;
            this.labelCopyright.Text = "©2023 Canwdev";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(8, 218);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 100);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "高级功能";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(7, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "ddraw.dll 补丁";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(133, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "ra2.ini 优化";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(133, 53);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "ra2md.ini 优化";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnRa3Exit);
            this.groupBox4.Controls.Add(this.btnRa3LaunchWin);
            this.groupBox4.Controls.Add(this.btnRa3Launch);
            this.groupBox4.Location = new System.Drawing.Point(8, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(250, 100);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "RA3 (ra3.exe)";
            // 
            // btnRa3Exit
            // 
            this.btnRa3Exit.Location = new System.Drawing.Point(7, 53);
            this.btnRa3Exit.Name = "btnRa3Exit";
            this.btnRa3Exit.Size = new System.Drawing.Size(111, 23);
            this.btnRa3Exit.TabIndex = 2;
            this.btnRa3Exit.Text = "结束进程 (&E)";
            this.btnRa3Exit.UseVisualStyleBackColor = true;
            this.btnRa3Exit.Click += new System.EventHandler(this.btnRa3Exit_Click);
            // 
            // btnRa3LaunchWin
            // 
            this.btnRa3LaunchWin.Location = new System.Drawing.Point(133, 23);
            this.btnRa3LaunchWin.Name = "btnRa3LaunchWin";
            this.btnRa3LaunchWin.Size = new System.Drawing.Size(111, 23);
            this.btnRa3LaunchWin.TabIndex = 1;
            this.btnRa3LaunchWin.Text = "窗口模式 (&W)";
            this.btnRa3LaunchWin.UseVisualStyleBackColor = true;
            this.btnRa3LaunchWin.Click += new System.EventHandler(this.btnRa3LaunchWin_Click);
            // 
            // btnRa3Launch
            // 
            this.btnRa3Launch.Location = new System.Drawing.Point(7, 23);
            this.btnRa3Launch.Name = "btnRa3Launch";
            this.btnRa3Launch.Size = new System.Drawing.Size(111, 23);
            this.btnRa3Launch.TabIndex = 0;
            this.btnRa3Launch.Text = "启动 (&Q)";
            this.btnRa3Launch.UseVisualStyleBackColor = true;
            this.btnRa3Launch.Click += new System.EventHandler(this.btnRa3Launch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 371);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "RedAlert 2/3 Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.RA2.ResumeLayout(false);
            this.RA3.ResumeLayout(false);
            this.About.ResumeLayout(false);
            this.About.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage RA2;
        private System.Windows.Forms.TabPage RA3;
        private System.Windows.Forms.TabPage About;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnCurDir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRa2Exit;
        private System.Windows.Forms.Button btnRa2LaunchWin;
        private System.Windows.Forms.Button btnRa2Launch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRa2YrExit;
        private System.Windows.Forms.Button btnRa2YrLaunchWin;
        private System.Windows.Forms.Button btnRa2YrLaunch;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnRa3Exit;
        private System.Windows.Forms.Button btnRa3LaunchWin;
        private System.Windows.Forms.Button btnRa3Launch;
    }
}

