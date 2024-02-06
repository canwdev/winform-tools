using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Forms;
// C:\Windows\assembly\GAC_MSIL\System.Management.Automation\1.0.0.0__31bf3856ad364e35
using System.Management.Automation;
using System.IO;
using MyUtilsNamespace;
using SimpleHyperV;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private RunUtils runUtils;
        public Form1()
        {
            InitializeComponent();
            // 实例化 ToolClass 并传递 Form 实例到构造函数
            runUtils = new RunUtils(this);

            progressBar1.Style = ProgressBarStyle.Marquee; // 设置进度条为滚动条样式，表示正在进行中
            progressBar1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // this.Text = "自定义标题";
            buttonVmRefresh.PerformClick();
            isVMLoaded = true;
        }

        private bool isVMLoaded = false;
        private bool isSwitchLoaded = false;
        private bool isNatLoaded = false;
        
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            //TabPage selectedTab = tabControl1.SelectedTab;
            //string selectedTabName = selectedTab.Text;
            int selectedIndex = tabControl1.SelectedIndex;
            if (selectedIndex == 0 && !isVMLoaded)
            {
                buttonVmRefresh_Click_1(this, EventArgs.Empty);
                isVMLoaded = true;
            }
            else if (selectedIndex == 2 && !isSwitchLoaded)
            {
                buttonSwitchRefresh_Click(this, EventArgs.Empty);
                isSwitchLoaded = true;
            }
            else if (selectedIndex == 3 && !isNatLoaded)
            {
                buttonNatRefresh_Click(this, EventArgs.Empty);
                isNatLoaded = true;
            }
        }


        private void buttonMmcHyperV_Click(object sender, EventArgs e)
        {
            /*Process procAD = new Process();
            procAD.StartInfo.FileName = "C:\\Windows\\System32\\mmc.exe";
            procAD.StartInfo.Arguments = "C:\\Windows\\System32\\virtmgmt.msc";
            procAD.Start();*/
            // 以上方式不能启动，可能是权限问题，因此必须使用外部bat脚本启动

            /*MyUtils.WriteToFile("start-virtmgmt.bat", "mmc.exe virtmgmt.msc");
            MyUtils.StartCurDirProgram("start-virtmgmt.bat");*/

            MyUtils.WriteToFile("start-virtmgmt.vbs", MyUtils.GenerateVbsScript("mmc.exe", "virtmgmt.msc"));
            MyUtils.StartCurDirProgram("start-virtmgmt.vbs");
        }

        private void buttonMstsc_Click(object sender, EventArgs e)
        {
            Process.Start("mstsc");
        }
        private void buttonLogs_Click(object sender, EventArgs e)
        {
            textBoxOutput.Visible = !textBoxOutput.Visible;

            if (textBoxOutput.Visible)
            {
                this.Height = this.Height + textBoxOutput.Height;
            }
            else
            {
                this.Height = this.Height - textBoxOutput.Height;
            }
        }
        private void btnCurDir_Click(object sender, EventArgs e)
        {
            string folderPath = Application.StartupPath;
            Process.Start(folderPath);
        }
        private void buttonNetwork_Click(object sender, EventArgs e)
        {
            runUtils.RunCmdCommand("control.exe netconnections");
        }

        /* ============================================================ */

        /* VM START */

        // 声明 PSOutput 为全局变量
        private Collection<PSObject> VMList;
        private int lastSelectedIndex = -1;

        private void buttonVmRefresh_Click_1(object sender, EventArgs e)
        {
            buttonVmRefresh.Enabled = false;
            VMList = runUtils.RunPowerShellScript("Get-VM");

            lastSelectedIndex = listBoxVM.SelectedIndex;
            listBoxVM.Items.Clear(); // 清空 ListBox 中的所有项
            foreach (PSObject outputItem in VMList)
            {
                if (outputItem != null)
                {
                    // 将结果展示在你的 WinForm 控件中
                    // 例如，将结果添加到 ListBox 
                    // listBox1.Items.Add(outputItem.BaseObject.ToString());

                    listBoxVM.Items.Add(outputItem.Properties["Name"].Value + " [" + outputItem.Properties["State"].Value + "]");
                }
            }
            listBoxVM.SelectedIndex = lastSelectedIndex;
            buttonVmRefresh.Enabled = true;

            AutoSetVmButtonsEnabled();

        }

        private void listBoxVM_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoSetVmButtonsEnabled();
        }

        private bool CheckVmIsStarted(PSObject vm)
        {

            if (null != vm)
            {
                string state = "" + vm.Properties["State"].Value;
                return state != "Off";
            }
            return false;
        }

        private void listBoxVM_DoubleClick(object sender, EventArgs e)
        {
            // 在此处添加双击列表框项时要执行的操作
            PSObject vm = getSelectedVM();
            if (null != vm)
            {
                if (CheckVmIsStarted(vm))
                {
                    buttonVmStop_Click(this, EventArgs.Empty);
                }
                else
                {
                    buttonVmStart_Click(this, EventArgs.Empty);
                }
            }
        }

        private PSObject getSelectedVM()
        {
            if (listBoxVM.SelectedIndex != -1)
            {
                // Get the selected virtual machine details using index
                PSObject selectedVmDetails = VMList[listBoxVM.SelectedIndex];
                // Display the details in the textbox
                return selectedVmDetails;
            }

            return null;
        }

        private void SetVmButtonsEnabled(bool isEnabled)
        {
            buttonStart.Enabled = isEnabled;
            buttonStop.Enabled = isEnabled;
            buttonConnect.Enabled = isEnabled;
        }
        private void AutoSetVmButtonsEnabled()
        {
            if (listBoxVM.SelectedIndex != -1)
            {
                SetVmButtonsEnabled(true);
            }
            else
            {
                SetVmButtonsEnabled(false);
            }

            PSObject vm = getSelectedVM();
            if (null != vm)
            {
                if (CheckVmIsStarted(vm))
                {
                    buttonStart.Enabled = false;
                    buttonStop.Enabled = true;
                }
                else
                {
                    buttonStart.Enabled = true;
                    buttonStop.Enabled = false;
                }
            }
        }

        private void buttonVmStart_Click(object sender, EventArgs e)
        {
            PSObject vm = getSelectedVM();
            if (null != vm)
            {
                string script = "Start-VM -Name \"" + vm.Properties["Name"].Value + "\"";
                runUtils.RunPowerShellScript(script);

                buttonVmRefresh.PerformClick();
            }
        }

        private void buttonVmStop_Click(object sender, EventArgs e)
        {
            PSObject vm = getSelectedVM();
            if (null != vm)
            {

                DialogResult result = MessageBox.Show(this, "Shut down selected VM?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    string script = "Stop-VM -Name \"" + vm.Properties["Name"].Value + "\"";
                    runUtils.RunPowerShellScript(script);

                    buttonVmRefresh.PerformClick();
                }
            }
        }

        private void buttonVmConnect_Click(object sender, EventArgs e)
        {
            PSObject vm = getSelectedVM();
            if (null != vm)
            {
                string paramsStr = " localhost \"" + vm.Properties["Name"].Value + "\"";

                // 优先使用程序同目录下的 vmconnect.exe 以避免下面的问题
                string localPath = Path.Combine(Application.StartupPath, "vmconnect.exe");
                if (File.Exists(localPath))
                {
                    MyUtils.StartCurDirProgram("vmconnect.exe", paramsStr);
                    return;
                }
                
                //string commandPath = @"C:\Windows\System32\vmconnect.exe";
                // 只有这条路径可以正常运行，但为了保证兼容性，请手动复制 vmconnect.exe 到程序同目录
                //string commandPath2 = @"C:\Windows\Microsoft.NET\assembly\GAC_64\vmconnect\v4.0_10.0.0.0__31bf3856ad364e35\vmconnect.exe";
                string system32Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "vmconnect.exe");

                /*Console.WriteLine(system32Path);*/
                // 这些代码不能正常运行，提示：An attempt was made to reference a token that does not exist，测试环境：Win11 22631
                // RunCmdCommand(system32Path+" "+paramsStr);

                // 经过测试，即使是vbs脚本，也不能正常运行
                // 注意：这里有两对双引号，是为了适应vbs脚本
                string paramsStrVbs = " localhost \"\"" + vm.Properties["Name"].Value + "\"\"";

                MyUtils.WriteToFile("start-vmconnect.vbs", MyUtils.GenerateVbsScript(system32Path, paramsStrVbs), true);
                MyUtils.StartCurDirProgram("start-vmconnect.vbs");
            }
        }


        /* VM END */

        /* ============================================================ */

        /* NAT START */

        private Collection<PSObject> NatList;
        private PSObject getSelectedNat()
        {
            if (listBoxNat.SelectedIndex != -1)
            {
                return NatList[listBoxNat.SelectedIndex];
            }
            return null;
        }
        private void buttonNatRefresh_Click(object sender, EventArgs e)
        {
            buttonNatRefresh.Enabled = false;
            NatList = runUtils.RunPowerShellScript("Get-NetNat");

            listBoxNat.Items.Clear(); // 清空 ListBox 中的所有项
            foreach (PSObject outputItem in NatList)
            {
                if (outputItem != null)
                {
                    listBoxNat.Items.Add(outputItem.Properties["Name"].Value+"");
                }
            }

            buttonNatRefresh.Enabled = true;
        }

        private void listViewNat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonNatDelete_Click(object sender, EventArgs e)
        {
            PSObject item = getSelectedNat();
            if (null != item)
            {
                DialogResult result = MessageBox.Show(this, "Delete selected NAT?", "Confirm", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    string script = "Remove-NetNat -Name \"" + item.Properties["Name"].Value + "\" -Confirm:$false";
                    runUtils.RunPowerShellScript(script);

                    buttonNatRefresh.PerformClick();
                }
            }
        }

        private void buttonNatCreate_Click(object sender, EventArgs e)
        {
            PopupNetworkCreateForm popup = new PopupNetworkCreateForm();
            popup.Text = "Create NetNat";
            if (popup.ShowDialog() == DialogResult.OK)
            {
                string name = popup.textBoxName.Text;
                string ipAddress = popup.textBoxIP.Text;

                string script = "New-NetNat -Name \"" + name + "\" -InternalIPInterfaceAddressPrefix " + ipAddress;
                runUtils.RunPowerShellScript(script);

                buttonNatRefresh.PerformClick();
            }
        }
        /* NAT END */

        /* ============================================================ */

        /* SWITCH START */

        private Collection<PSObject> SwitchList;
        private PSObject getSelectedSwitch()
        {
            if (listBoxSwitch.SelectedIndex != -1)
            {
                return SwitchList[listBoxSwitch.SelectedIndex];
            }
            return null;
        }
        private void buttonSwitchRefresh_Click(object sender, EventArgs e)
        {

            buttonSwitchRefresh.Enabled = false;
            SwitchList = runUtils.RunPowerShellScript("Get-VMSwitch");

            listBoxSwitch.Items.Clear(); // 清空 ListBox 中的所有项
            foreach (PSObject outputItem in SwitchList)
            {
                if (outputItem != null)
                {
                    listBoxSwitch.Items.Add(outputItem.Properties["Name"].Value + "");
                }
            }

            buttonSwitchRefresh.Enabled = true;
        }

        private void listBoxSwitch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSwitchDelete_Click(object sender, EventArgs e)
        {
            PSObject item = getSelectedSwitch();
            if (null != item)
            {
                DialogResult result = MessageBox.Show(this, "Delete selected Switch?", "Confirm", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    string script = "Remove-VMSwitch -Name \"" + item.Properties["Name"].Value + "\" -Force";
                    runUtils.RunPowerShellScript(script);

                    buttonSwitchRefresh.PerformClick();
                }
            }
        }

        private void buttonSwitchCreate_Click(object sender, EventArgs e)
        {
            PopupNetworkCreateForm popup = new PopupNetworkCreateForm();
            popup.Text = "Create Internal Switch With Static IP";
            if (popup.ShowDialog() == DialogResult.OK)
            {
                string name = popup.textBoxName.Text;
                string ipAddressWithPrefix = popup.textBoxIP.Text;
                string[] parts = ipAddressWithPrefix.Split('/');
                string ipAddress = parts[0]; // "192.168.56.1"
                string subnet = parts[1]; // "24"

                runUtils.RunPowerShellScript("New-VMSwitch -SwitchName \"" + name + "\" -SwitchType Internal");
                string ifindex = runUtils.RunPowerShellScript("Get-NetAdapter -Name \"vEthernet (" + name + ")\" | Select-Object -ExpandProperty 'ifIndex'")[0].ToString();
                runUtils.RunPowerShellScript("New-NetIPAddress -IPAddress "+ ipAddress + " -PrefixLength "+ subnet + " -InterfaceIndex "+ ifindex);

                buttonSwitchRefresh.PerformClick();
            }
        }

        /* SWITCH END */
    }
}
