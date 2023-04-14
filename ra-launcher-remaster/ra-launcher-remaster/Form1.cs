using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ra_launcher_remaster
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;

            string url = "https://github.com/canwdev/RA-Laucher-Tools";

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };

            Process.Start(psi);
        }

        private void btnCurDir_Click(object sender, EventArgs e)
        {
            string folderPath = Application.StartupPath;
            Process.Start(folderPath);
        }

        void fnStartProgram(string exeName, string args="")
        {
            try
            {
                string exePath = Path.Combine(Application.StartupPath, exeName);
                Process.Start(exePath, args);
            }
            catch (Exception ex)
            {
                string errorMessage = $"An error occurred: {ex.Message}";
                Console.WriteLine(errorMessage);
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void KillProcess(string processname)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";   // 启动命令提示符
            startInfo.Arguments = "/c taskkill /f /im "+ processname;   // 执行 taskkill 命令，/c 参数表示执行完命令后关闭命令提示符
            startInfo.CreateNoWindow = true;  // 不创建进程窗口
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;  // 隐藏窗口样式
            Process.Start(startInfo);
        }

        private void btnRa2Launch_Click(object sender, EventArgs e)
        {
            fnStartProgram("ra2.exe", "-speedcontrol");
        }

        private void btnRa2LaunchWin_Click(object sender, EventArgs e)
        {
            fnStartProgram("ra2.exe", "-win -speedcontrol");
        }

        private void btnRa2Exit_Click(object sender, EventArgs e)
        {
            KillProcess("ra2.exe");
            KillProcess("game.exe");
        }

        private void btnRa2YrLaunch_Click(object sender, EventArgs e)
        {
            fnStartProgram("ra2md.exe", "-speedcontrol");
        }

        private void btnRa2YrLaunchWin_Click(object sender, EventArgs e)
        {
            fnStartProgram("ra2md.exe", "-win -speedcontrol");
        }

        private void btnRa2YrExit_Click(object sender, EventArgs e)
        {
            KillProcess("ra2md.exe");
            KillProcess("gamemd.exe");
        }

        private void btnRa3Launch_Click(object sender, EventArgs e)
        {
            fnStartProgram("ra3.exe");
        }

        private void btnRa3LaunchWin_Click(object sender, EventArgs e)
        {
            fnStartProgram("ra3.exe", "-win");
        }

        private void btnRa3Exit_Click(object sender, EventArgs e)
        {
            KillProcess("ra3.exe");
            KillProcess("ra3_1.12.game"); // TODO: Auto
        }

        bool checkExeIsExist(string exeName)
        {
            string filePath = Path.Combine(Application.StartupPath, exeName);

            return File.Exists(filePath);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int tabIndex;
            if (checkExeIsExist("ra3.exe") || checkExeIsExist("ra3ep1.exe"))
            {
                tabIndex = 1;
                // MessageBox.Show("RA3 is detected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (checkExeIsExist("ra2.exe") || checkExeIsExist("ra2md.exe"))
            {
                tabIndex = 0;
            } else
            {
                tabIndex = 2;
                MessageBox.Show("请将此程序放在红警2/3文件夹内！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Set the default tab
            tabControl1.SelectedTab = tabControl1.TabPages[tabIndex];
        }
    }
}
