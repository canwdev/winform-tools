using MyUtilsNamespace;
using RaLauncher.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace RaLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int tabIndex;
            if (CheckProgramDirFileExist("ra3.exe") || CheckProgramDirFileExist("ra3ep1.exe"))
            {
                tabIndex = 1;
            }
            else if (CheckProgramDirFileExist("ra2.exe") || CheckProgramDirFileExist("ra2md.exe"))
            {
                tabIndex = 0;
            }
            else
            {
                tabIndex = 2;
            }
            tabControl1.SelectedTab = tabControl1.TabPages[tabIndex];

            InitDPIToolStripMenuItem();

            // 加载设置配置
            LoadSettings();
        }

        private void LoadSettings()
        {
            // 设置RA3分辨率列表
            // Add items to the combo box
            ra3ResComboBox.Items.Add("");
            ra3ResComboBox.Items.Add("Auto");
            ra3ResComboBox.Items.Add("800x600");
            ra3ResComboBox.Items.Add("1024x768");
            ra3ResComboBox.Items.Add("1360x768");
            ra3ResComboBox.Items.Add("1920x1080");
            ra3ResComboBox.Items.Add("2560x1440");

            checkBoxRa3ConsoleEnabled.Checked = Settings.Default.Ra3ConsoleEnabled;

            // MessageBox.Show(Settings.Default.Ra3CustomResolution, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ra3ResComboBox.Text = Settings.Default.Ra3CustomResolution;
        }


        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            // Call Process.Start method to open a browser, with link text as URL
            Process.Start(e.LinkText); // call default browser
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            Process.Start("https://github.com/canwdev/ra-launcher-tools"); // call default browser
        }

        // 定义全局变量
        private string setDpiTempPath = "";
        // 修改之前的屏幕DPI
        private string defaultDpi = "";

        private void InitDPIToolStripMenuItem()
        {
            string[] items = {
                "100",
                "125",
                "150",
                "175",
                "200",
                "225",
                "250",
                "275",
                "300",
                "400",
                "500",
            };

            // 动态添加菜单
            foreach (string item in items)
            {
                ToolStripMenuItem newItem = new ToolStripMenuItem(item);
                newItem.CheckOnClick = true;
                newItem.Click += dPIToolSubMenuItem_Click;
                dPIToolStripMenuItem.DropDownItems.Add(newItem);
            }
        }

        private void dPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 仅在第一次获取系统DPI
            if (!string.IsNullOrEmpty(defaultDpi))
            {
                return;
            }
            defaultDpi = GetDpi();

            // 设置高亮
            foreach (ToolStripMenuItem item in dPIToolStripMenuItem.DropDownItems)
            {
                if (item.Text == defaultDpi)
                {
                    // red
                    item.ForeColor = Color.Red;
                    item.Checked = true;
                }
            }
        }

        // 单击事件处理程序
        private void dPIToolSubMenuItem_Click(object sender, EventArgs e)
        {
            // 获取点击的菜单项的Text
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            string dpi = clickedItem.Text;

            SetDpi(dpi);

            // 设置单选
            foreach (ToolStripMenuItem item in dPIToolStripMenuItem.DropDownItems)
            {
                if (item.Text == dpi)
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }
            }
        }

        void initSetDpi()
        {
            // 获取程序集中的资源流
            // 获取要提取的资源文件路径
            string localNameSpace = this.GetType().Namespace; //获取工作空间
            string resFilePath = localNameSpace + ".Resources." + "SetDpi.exe";
            Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resFilePath);

            // 将资源流写入临时文件
            setDpiTempPath = Path.GetTempFileName();
            using (FileStream fileStream = File.Create(setDpiTempPath))
            {
                resourceStream.CopyTo(fileStream);
            }

            Console.WriteLine(setDpiTempPath);


        }
        string GetDpi()
        {
            if (string.IsNullOrEmpty(setDpiTempPath))
            {
                initSetDpi();
            }

            // 启动临时文件中的程序
            Process process = new Process();
            process.StartInfo.FileName = setDpiTempPath;
            process.StartInfo.Arguments = "value";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;  // 不创建进程窗口
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;  // 隐藏窗口样式

            process.Start();
            string output = process.StandardOutput.ReadToEnd();

            Console.WriteLine("output:" + output);

            return output;

        }

        void SetDpi(string args = "100")
        {
            if (string.IsNullOrEmpty(setDpiTempPath))
            {
                initSetDpi();
            }

            // 启动临时文件中的程序
            Process process = new Process();
            process.StartInfo.FileName = setDpiTempPath;
            process.StartInfo.Arguments = args;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;  // 不创建进程窗口
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;  // 隐藏窗口样式

            process.Start();
            process.StandardOutput.ReadToEnd();
        }

        private void btnOpenResolutionControl_Click(object sender, EventArgs e)
        {
            Process.Start("control.exe", "desk.cpl,@0,3");
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 调用清理方法
            if (!string.IsNullOrEmpty(setDpiTempPath))
            {
                // 删除临时文件
                File.Delete(setDpiTempPath);
            }
        }

        // 打开当前目录
        private void OpenDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string folderPath = Application.StartupPath;
            Process.Start(folderPath);
        }

        // 系统分辨率设置
        private void resToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("control.exe", "desk.cpl,@0,3");
        }



        /* ============================================================ */

        /* RA2 START */

        private void btnRa2Launch_Click(object sender, EventArgs e)
        {
            MyUtils.StartCurDirProgram("ra2.exe", "-speedcontrol");
        }

        private void btnRa2LaunchWin_Click(object sender, EventArgs e)
        {
            MyUtils.StartCurDirProgram("ra2.exe", "-win -speedcontrol");
        }

        private void btnRa2Exit_Click(object sender, EventArgs e)
        {
            MyUtils.KillProcess("ra2.exe");
            MyUtils.KillProcess("game.exe");
        }

        void HandleOptRa2Ini(string iniFileName = "ra2.ini")
        {
            Process.Start("notepad", $".\\{iniFileName}");

            int width = Screen.FromControl(this).Bounds.Width;
            int height = Screen.FromControl(this).Bounds.Height;
            string configString = $@"[Video]
AllowHiResModes=yes
VideoBackBuffer=no
AllowVRAMSidebar=no
ScreenWidth={width}
ScreenHeight={height}
StretchMovies=no
";
            FormTextDisplay form2 = new FormTextDisplay(configString, $"请手动复制并替换 {iniFileName} 中的 [Video] 配置值"); // 创建一个新的窗口对象，并传递参数
            form2.Show(); // 显示新的窗口

        }

        private void btnRa2IniOpt_Click(object sender, EventArgs e)
        {
            HandleOptRa2Ini();
        }

        private void btnRa2YrIniOpt_Click_Click(object sender, EventArgs e)
        {
            HandleOptRa2Ini("ra2md.ini");
        }

        private void btnRa2YrLaunch_Click(object sender, EventArgs e)
        {
            MyUtils.StartCurDirProgram("ra2md.exe", "-speedcontrol");
        }

        private void btnRa2YrLaunchWin_Click(object sender, EventArgs e)
        {
            MyUtils.StartCurDirProgram("ra2md.exe", "-win -speedcontrol");
        }

        private void btnRa2YrExit_Click(object sender, EventArgs e)
        {
            MyUtils.KillProcess("ra2md.exe");
            MyUtils.KillProcess("gamemd.exe");
        }

        private void btnDDrawCompatPatch_Click(object sender, EventArgs e)
        {
            // https://github.com/narzoul/DDrawCompat/releases
            MyUtils.ExtractResource("DDrawCompat.ddraw.dll", true, "ddraw.dll");
            MyUtils.ExtractResource("DDrawCompat.ddraw.ini", true, "ddraw.ini");
            MessageBox.Show($"ddraw.dll, ddraw.ini 补丁已放置在当前目录", "DDrawCompat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void buttonTsDdraw_Click(object sender, EventArgs e)
        {
            // https://github.com/CnCNet/ts-ddraw/releases
            MyUtils.ExtractResource("ts_ddraw.ddraw.dll", true, "ddraw.dll");
            MessageBox.Show($"ddraw.dll 补丁已放置在当前目录", "ts-ddraw", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonCncDdraw_Click(object sender, EventArgs e)
        {
            // https://github.com/FunkyFr3sh/cnc-ddraw/releases
            MyUtils.ExtractResource("cnc-ddraw.zip", true);
            MessageBox.Show($"cnc-ddraw.zip 已放置在当前目录，请自行解压！", "cnc-ddraw", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /* RA2 END */

        /* ============================================================ */

        /* RA3 START */

        string GetRa3StartParams(string para = "")
        {
            if (checkBoxRa3ConsoleEnabled.Checked)
            {
                para += " -ui";
            }
            string resValue = ra3ResComboBox.SelectedItem != null ? (string)ra3ResComboBox.SelectedItem : ra3ResComboBox.Text;
            if (resValue != "")
            {
                if (resValue == "Auto")
                {
                    int width = Screen.FromControl(this).Bounds.Width;
                    int height = Screen.FromControl(this).Bounds.Height;
                    para += $" -xres {width} -yres {height}";
                }
                else if (resValue.Contains("x"))
                {
                    // 字符串包含"x"，执行相关操作
                    string[] parts = resValue.Split('x');
                    int width = int.Parse(parts[0]);
                    int height = int.Parse(parts[1]);
                    para += $" -xres {width} -yres {height}";
                }
                else
                {
                    MessageBox.Show("应该使用类似于 1024x768 的格式！", "错误的输入格式", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return para;
        }

        private void btnRa3Launch_Click(object sender, EventArgs e)
        {
            MyUtils.StartCurDirProgram("ra3.exe", GetRa3StartParams());
        }

        private void btnRa3LaunchWin_Click(object sender, EventArgs e)
        {
            MyUtils.StartCurDirProgram("ra3.exe", GetRa3StartParams("-win"));
        }

        private void btnRa3Exit_Click(object sender, EventArgs e)
        {
            MyUtils.KillProcess("ra3.exe");
            MyUtils.KillProcess("ra3_1.12.game"); // TODO: Auto version
        }

        bool CheckProgramDirFileExist(string filename)
        {
            string filePath = Path.Combine(Application.StartupPath, filename);
            return File.Exists(filePath);

        }

        private void btnRa3Ep1Launch_Click(object sender, EventArgs e)
        {
            MyUtils.StartCurDirProgram("ra3ep1.exe", GetRa3StartParams());
        }

        private void btnRa3Ep1LaunchWin_Click(object sender, EventArgs e)
        {
            MyUtils.StartCurDirProgram("ra3ep1.exe", GetRa3StartParams("-win"));
        }

        private void btnRa3Ep1Exit_Click(object sender, EventArgs e)
        {
            MyUtils.KillProcess("ra3ep1.exe");
            MyUtils.KillProcess("ra3ep1_1.0.game"); // TODO: Auto version
        }

        private void checkBoxIsRa3Ui_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.Ra3ConsoleEnabled = checkBoxRa3ConsoleEnabled.Checked;
            Settings.Default.Save();
        }

        private void ra3ResComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ra3ResComboBox_Leave(object sender, EventArgs e)
        {
            Settings.Default.Ra3CustomResolution = ra3ResComboBox.Text;
            Settings.Default.Save();
        }

        private void labelCustomRa3Res_Click(object sender, EventArgs e)
        {

            int width = Screen.FromControl(this).Bounds.Width;
            int height = Screen.FromControl(this).Bounds.Height;

            ra3ResComboBox.Text = $"{width}x{height}";
            ra3ResComboBox_Leave(null, EventArgs.Empty);
        }

        private void buttonRa3Tool_Click(object sender, EventArgs e)
        {
            MyUtils.ExtractResource("ra3_tool.exe", false);
            MyUtils.StartCurDirProgram("ra3_tool.exe");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenDirToolStripMenuItem_Click(sender, e);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


        /* RA3 END */

    }
}
