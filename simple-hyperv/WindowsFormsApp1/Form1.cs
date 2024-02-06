using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Forms;
// C:\Windows\assembly\GAC_MSIL\System.Management.Automation\1.0.0.0__31bf3856ad364e35
using System.Management.Automation;
using System.IO;
using MyUtils;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            progressBar1.Style = ProgressBarStyle.Marquee; // 设置进度条为滚动条样式，表示正在进行中
            progressBar1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            // this.Close();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // this.Text = "自定义标题";
            buttonRefresh_Click_1(this, EventArgs.Empty);
        }

        private void btnCurDir_Click(object sender, EventArgs e)
        {
            string folderPath = Application.StartupPath;
            Process.Start(folderPath);
        }

        // 将运行结果日志显示在 textBoxOutput 控件中
        private void AppendLog(string log)
        {
            if (textBoxOutput.Text.Length + log.Length > textBoxOutput.MaxLength)
            {
                int excessLength = (textBoxOutput.Text.Length + log.Length) - textBoxOutput.MaxLength;
                textBoxOutput.Text = textBoxOutput.Text.Remove(0, excessLength);
            }
            textBoxOutput.AppendText(log + Environment.NewLine);
            textBoxOutput.SelectionStart = textBoxOutput.Text.Length;
            textBoxOutput.ScrollToCaret();
        }

        // 声明 PSOutput 为全局变量
        private Collection<PSObject> VMList;

        private Collection<PSObject> RunPowerShellScript(string script)
        {
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                progressBar1.Visible = true;
                AppendLog(">>> " + script);


                PowerShellInstance.AddScript(script);
                Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                foreach (var result in PSOutput)
                {
                    AppendLog(result.ToString());
                }


                // 执行完成后隐藏进度条
                progressBar1.Visible = false;

                return PSOutput;
            }
        }

        private string RunCmdCommand(string command)
        {
            progressBar1.Visible = true;
            AppendLog(">>> " + command);

            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C " + command,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = processStartInfo;
                process.Start();

                string result = process.StandardOutput.ReadToEnd();

                AppendLog(result);
                progressBar1.Visible = false;
                return result;
            }
        }


        private void buttonRefresh_Click_1(object sender, EventArgs e)
        {
            buttonRefresh.Enabled = false;
            VMList = RunPowerShellScript("Get-VM");

            listBox1.Items.Clear(); // 清空 ListBox 中的所有项
            foreach (PSObject outputItem in VMList)
            {
                if (outputItem != null)
                {
                    // 将结果展示在你的 WinForm 控件中
                    // 例如，将结果添加到 ListBox 
                    // listBox1.Items.Add(outputItem.BaseObject.ToString());

                    listBox1.Items.Add(outputItem.Properties["Name"].Value + " - " + outputItem.Properties["State"].Value);
                }
            }

            buttonRefresh.Enabled = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                // Get the selected virtual machine details using index
                PSObject selectedVmDetails = VMList[listBox1.SelectedIndex];
                // Display the details in the textbox
                textBoxCommand.Text = selectedVmDetails.BaseObject.ToString();

            }
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            // 在此处添加双击列表框项时要执行的操作
            PSObject vm = getSelectedVM();
            if (null != vm)
            {

                /*foreach (var result in VMList)
                {
                    AppendLog("?" + result.Properties["State"].Value);
                }*/
                string state = "" + vm.Properties["State"].Value;
                if (state == "Off")
                {
                    buttonStart_Click(this, EventArgs.Empty);
                }
                else
                {
                    buttonStop_Click(this, EventArgs.Empty);
                }

            }
        }

        private PSObject getSelectedVM()
        {
            if (listBox1.SelectedIndex != -1)
            {
                // Get the selected virtual machine details using index
                PSObject selectedVmDetails = VMList[listBox1.SelectedIndex];
                // Display the details in the textbox
                return selectedVmDetails;
            }

            return null;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            PSObject vm = getSelectedVM();
            if (null != vm)
            {
                string script = "Start-VM -Name \"" + vm.Properties["Name"].Value + "\"";
                RunPowerShellScript(script);

                buttonRefresh_Click_1(this, EventArgs.Empty);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            PSObject vm = getSelectedVM();
            if (null != vm)
            {

                DialogResult result = MessageBox.Show("Shut down selected VM?", "Confirm", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    string script = "Stop-VM -Name \"" + vm.Properties["Name"].Value + "\"";
                    RunPowerShellScript(script);

                    buttonRefresh_Click_1(this, EventArgs.Empty);
                }

            }
        }


        static string GenerateVbsScript(string programName, string paramsText)
        {
            /*
            objShell.ShellExecute 是 VBScript 中用于执行外部程序的方法。它接受四个参数，分别是：
            1.要执行的程序的路径或者文件名
            2.要传递给程序的参数
            3.工作目录（可选）
            4.运行程序的方式（比如以最大化窗口运行，隐藏窗口运行等）
            Set objShell = CreateObject("Shell.Application")
            objShell.ShellExecute "C:\Windows\System32\vmconnect.exe", "localhost ""Win7Mini""", "", "runas", 1
             */
            return $@"Set objShell = CreateObject(""Shell.Application"")
objShell.ShellExecute ""{programName}"", ""{paramsText}"", """", ""runas"", 1";
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            PSObject vm = getSelectedVM();
            if (null != vm)
            {
                string commandPath = @"C:\Windows\System32\vmconnect.exe";
                /*string system32Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "vmconnect.exe");

                Console.WriteLine(system32Path);
                RunCmdCommand(system32Path);*/

                // 注意：这里有两对双引号，是为了适应vbs脚本
                string str = " localhost \"\"" + vm.Properties["Name"].Value + "\"\"";

                FileHelper.WriteToFile("start-vmconnect.vbs", GenerateVbsScript(commandPath, str), true);
                FileHelper.StartCurDirProgram("start-vmconnect.vbs");
            }
        }

        private void buttonMmcHyperV_Click(object sender, EventArgs e)
        {
            /*Process procAD = new Process();
            procAD.StartInfo.FileName = "C:\\Windows\\System32\\mmc.exe";
            procAD.StartInfo.Arguments = "C:\\Windows\\System32\\virtmgmt.msc";
            procAD.Start();*/
            // 以上方式不能启动，可能是权限问题，因此必须使用外部bat脚本启动

            FileHelper.WriteToFile("start-virtmgmt.bat", "mmc.exe virtmgmt.msc");
            FileHelper.StartCurDirProgram("start-virtmgmt.bat");
        }

        private void buttonMstsc_Click(object sender, EventArgs e)
        {
            RunCmdCommand("mstsc");
        }
    }
}
