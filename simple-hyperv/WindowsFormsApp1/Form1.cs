using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Forms;
// C:\Windows\assembly\GAC_MSIL\System.Management.Automation\1.0.0.0__31bf3856ad364e35
using System.Management.Automation;
using System.Management.Automation.Runspaces;

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
        }

        private void btnCurDir_Click(object sender, EventArgs e)
        {
            string folderPath = Application.StartupPath;
            Process.Start(folderPath);
        }


        // 声明 PSOutput 为全局变量
        private Collection<PSObject> VMList;

        private Collection<PSObject> RunPowerShellScript(string script)
        {
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                progressBar1.Visible = true;
                textBoxCommand.Text = script;
                

                PowerShellInstance.AddScript(script);
                Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                textBoxOutput.Text = "";
                // 将运行结果日志显示在 textBoxOutput 控件中
                foreach (var result in PSOutput)
                {
                    textBoxOutput.Text += result.ToString() + Environment.NewLine;
                }


                // 执行完成后隐藏进度条
                progressBar1.Visible = false;

                return PSOutput;
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
                string script = "Start-VM -Name " + vm.Properties["Name"].Value;
                RunPowerShellScript(script);

                buttonRefresh_Click_1(this, EventArgs.Empty);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            PSObject vm = getSelectedVM();
            if (null != vm)
            {
                string script = "Stop-VM -Name " + vm.Properties["Name"].Value;
                RunPowerShellScript(script);

                buttonRefresh_Click_1(this, EventArgs.Empty);
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {

            PSObject vm = getSelectedVM();
            if (null != vm)
            {
                string script = "vmconnect.exe localhost " + vm.Properties["Name"].Value;
                RunPowerShellScript(script);
            }
        }
    }
}
