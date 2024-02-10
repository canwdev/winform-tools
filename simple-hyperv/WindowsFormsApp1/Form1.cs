using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Forms;
// C:\Windows\assembly\GAC_MSIL\System.Management.Automation\1.0.0.0__31bf3856ad364e35
using System.Management.Automation;
using System.IO;
using MyUtilsNamespace;
using SimpleHyperV;
using SimpleHyperV.Properties;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO.Pipes;

namespace SimpleHyperVForm1
{
    public partial class Form1 : Form
    {
        private RunUtils runUtils;
        private string[] args;

        public Form1(string[] _args)
        {
            args = _args;
            InitializeComponent();

            // 实例化 ToolClass 并传递 Form 实例到构造函数
            runUtils = new RunUtils(this);

            progressBar1.Style = ProgressBarStyle.Marquee; // 设置进度条为滚动条样式，表示正在进行中
            progressBar1.Visible = false;

            Task.Run(() =>
            {
                // 定义回调函数
                SingleInstanceNamedPipeServer.Callback callbackFunction = (string message) =>
                {
                    if (message == "OnSecondInstance")
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            NotifyIconRestore(null, EventArgs.Empty);
                        });
                    }
                };
                SingleInstanceNamedPipeServer.StartServer(callbackFunction);
            });


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // this.Text = "自定义标题";
            buttonVmRefresh.PerformClick();
            isVMLoaded = true;

            // 还原窗口大小和位置
            if (Settings.Default.WindowSize != new System.Drawing.Size(0, 0))
            {
                this.Size = Settings.Default.WindowSize;
            }
            if (Settings.Default.WindowLocation != new System.Drawing.Point(0, 0))
            {
                this.Location = Settings.Default.WindowLocation;
            }

            // 加载设置配置
            LoadSettings();

            // 通知区域图标
            SetupNotifyIcon();

            // 启动参数 静默启动
            if (args.Length > 0 && args[0] == "-m")
            {
                if (closeToTrayToolStripMenuItem.Checked)
                {
                    CloseToTray();
                } else
                {
                    WindowState = FormWindowState.Minimized;
                }
            }
        }

        public void CloseToTray()
        {
            WindowState = FormWindowState.Minimized;
            notifyIcon.Visible = true;
            ShowInTaskbar = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                // 保存窗口大小和位置
                Settings.Default.WindowSize = this.Size;
                Settings.Default.WindowLocation = this.Location;
                Settings.Default.Save();
            }
            if (closeToTrayToolStripMenuItem.Checked && e.CloseReason == CloseReason.UserClosing)
            {
                CloseToTray();
                e.Cancel = true; // Prevent the form from closing
                return;
            }
        }

        // 通知区域图标
        private NotifyIcon notifyIcon;
        private ContextMenuStrip notifyIconContextMenu;
        private ToolStripMenuItem restoreToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private void SetupNotifyIcon()
        {
            // 创建一个 NotifyIcon 控件并设置图标
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Resources.icon;
            // notifyIcon.Visible = true;

            // 设置鼠标悬浮提示
            notifyIcon.Text = "Simple Hyper-V";

            notifyIconContextMenu = new ContextMenuStrip();
            restoreToolStripMenuItem = new ToolStripMenuItem("Restore");
            restoreToolStripMenuItem.Click += NotifyIconRestore;
            notifyIconContextMenu.Items.Add(restoreToolStripMenuItem);

            exitToolStripMenuItem = new ToolStripMenuItem("Exit");
            exitToolStripMenuItem.Click += NotifyIcon_Exit_Click;
            notifyIconContextMenu.Items.Add(exitToolStripMenuItem);

            notifyIcon.MouseClick += NotifyIcon_MouseClick;
            notifyIcon.ContextMenuStrip = notifyIconContextMenu;
        }
        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NotifyIconRestore(this, EventArgs.Empty);
            }
        }
        public void NotifyIconRestore(object sender, EventArgs e)
        {
            // 双击通知区域图标时恢复窗口
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
            ShowInTaskbar = true;
            Activate();
        }
        public void NotifyIcon_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            else if (selectedIndex == 1 && !isSwitchLoaded)
            {
                buttonSwitchRefresh_Click(this, EventArgs.Empty);
                isSwitchLoaded = true;
            }
            else if (selectedIndex == 2 && !isNatLoaded)
            {
                buttonNatRefresh_Click(this, EventArgs.Empty);
                isNatLoaded = true;
            }
        }

        private void LoadSettings()
        {
            showLogsToolStripMenuItem.Checked = Settings.Default.ShowLogs;
            textBoxOutput.Visible = Settings.Default.ShowLogs;

            closeToTrayToolStripMenuItem.Checked = Settings.Default.CloseToTray;
        }
        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            // Call Process.Start method to open a browser, with link text as URL
            System.Diagnostics.Process.Start(e.LinkText); // call default browser
        }

        private async void HandleOptimizeVHD()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "VHDX Files|*.vhdx;*.vhd";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    if (!string.IsNullOrEmpty(selectedFilePath))
                    {
                        await runUtils.RunPowerShellScriptAsync("Optimize-VHD -Path \"" + selectedFilePath + "\" -Mode Full", true);
                    }
                }
            }
        }

        // 运行辅助工具，启动相关功能
        private void RunHvintegrate(string args)
        {
            string HVIntegrateFileName = MyUtils.ExtractResourceIfNotExist("hvintegrate.exe");
            MyUtils.StartCurDirProgram(HVIntegrateFileName, args);
        }

        // Hyper-V Manager (virtmgmt.msc)
        private void hyperVManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hyper-V Manager (virtmgmt.msc)
            /*Process procAD = new Process();
            procAD.StartInfo.FileName = "C:\\Windows\\System32\\mmc.exe";
            procAD.StartInfo.Arguments = "C:\\Windows\\System32\\virtmgmt.msc";
            procAD.Start();*/
            // 以上方式不能启动，可能是权限问题，因此必须使用外部bat脚本启动
            MyUtils.WriteToFile("start-virtmgmt.vbs", MyUtils.GenerateVbsScript("mmc.exe", "virtmgmt.msc"));
            MyUtils.StartCurDirProgram("start-virtmgmt.vbs");
        }

        // Hyper-V Settings
        private void hyperVSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunHvintegrate("hv");
        }

        // Virtual Switch Manager
        private void virtualSwitchManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunHvintegrate("vs");
        }

        // Edit Disk
        private void editDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunHvintegrate("ed");
        }

        // Optimize VHD...
        private void optimizeVHDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HandleOptimizeVHD();
        }

        // Create VM
        private void createVMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunHvintegrate("av");
        }

        // Network Connections
        private void networkConnectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runUtils.RunCmdCommand("control.exe netconnections");
        }

        // Remote Desktop
        private void remoteDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("mstsc");
        }

        // Open Program Dir(./)
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string folderPath = Application.StartupPath;
            Process.Start(folderPath);
        }

        // Exit
        private void exitStripMenuItem_Click(object sender, EventArgs e)
        {
            NotifyIcon_Exit_Click(null, EventArgs.Empty);
        }

        /* ============================================================ */

        /* VM START */

        // 声明 PSOutput 为全局变量
        private Collection<PSObject> VMList;
        private int lastSelectedIndex = -1;

        private async void buttonVmRefresh_Click_1(object sender, EventArgs e)
        {
            buttonVmRefresh.Enabled = false;
            VMList = await runUtils.RunPowerShellScriptAsync("Get-VM");

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
            PSObject item = getSelectedVM();
            if (null != item)
            {
                if (CheckVmIsStarted(item))
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
            menuStripVmActions.Enabled = isEnabled;
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


        private async void buttonVmStart_Click(object sender, EventArgs e)
        {
            PSObject vm = getSelectedVM();
            if (null != vm)
            {
                string script = "Start-VM -Name \"" + vm.Properties["Name"].Value + "\"";
                await runUtils.RunPowerShellScriptAsync(script);

                buttonVmRefresh.PerformClick();
            }
        }

        private async void buttonVmStop_Click(object sender, EventArgs e)
        {
            PSObject vm = getSelectedVM();
            if (null != vm)
            {
                if (Control.ModifierKeys == Keys.Shift)
                {
                    // 如果按下了 Shift 键，强行停止

                    string script = "Stop-VM -Name \"" + vm.Properties["Name"].Value + "\" -Force";
                    await runUtils.RunPowerShellScriptAsync(script);

                    buttonVmRefresh.PerformClick();

                    return;
                }

                DialogResult result = MessageBox.Show(this, "Shut down selected VM?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    string script = "Stop-VM -Name \"" + vm.Properties["Name"].Value + "\"";
                    await runUtils.RunPowerShellScriptAsync(script);

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


                MessageBox.Show(@"To ensure compatibility, please manually copy C:\Windows\System32\vmconnect.exe to the same directory as the program, otherwise it may not run properly.
为了保证兼容性，请手动复制 C:\Windows\System32\vmconnect.exe 到程序同目录，否则可能无法正常运行。", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                //string commandPath = @"C:\Windows\System32\vmconnect.exe";
                // 只有这条路径可以正常运行，但为了保证兼容性，请手动复制 vmconnect.exe 到程序同目录
                //string commandPath2 = @"C:\Windows\Microsoft.NET\assembly\GAC_64\vmconnect\v4.0_10.0.0.0__31bf3856ad364e35\vmconnect.exe";
                string system32Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "vmconnect.exe");

                /*Console.WriteLine(system32Path);*/
                // 这些代码不能正常运行，提示：An attempt was made to reference a token that does not exist，测试环境：Win11 22631
                Process.Start(system32Path + " " + paramsStr);

                // 经过测试，即使是vbs脚本，也不能正常运行
                // 注意：这里有两对双引号，是为了适应vbs脚本
                /*string paramsStrVbs = " localhost \"\"" + vm.Properties["Name"].Value + "\"\"";

                MyUtils.WriteToFile("start-vmconnect.vbs", MyUtils.GenerateVbsScript(system32Path, paramsStrVbs), true);
                MyUtils.StartCurDirProgram("start-vmconnect.vbs");*/
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
        private async void buttonNatRefresh_Click(object sender, EventArgs e)
        {
            buttonNatRefresh.Enabled = false;
            NatList = await runUtils.RunPowerShellScriptAsync("Get-NetNat");

            listBoxNat.Items.Clear(); // 清空 ListBox 中的所有项
            foreach (PSObject outputItem in NatList)
            {
                if (outputItem != null)
                {
                    listBoxNat.Items.Add(outputItem.Properties["Name"].Value + "");
                }
            }

            buttonNatRefresh.Enabled = true;
        }
        private async void listBoxNat_DoubleClick(object sender, EventArgs e)
        {
            PSObject item = getSelectedNat();
            if (null != item)
            {
                await runUtils.RunPowerShellScriptAsync("Get-NetNat -Name \"" + item.Properties["Name"].Value + "\"", true);
            }
        }

        private async void buttonNatDelete_Click(object sender, EventArgs e)
        {
            PSObject item = getSelectedNat();
            if (null != item)
            {
                DialogResult result = MessageBox.Show(this, "Delete selected NAT?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    string script = "Remove-NetNat -Name \"" + item.Properties["Name"].Value + "\" -Confirm:$false";
                    await runUtils.RunPowerShellScriptAsync(script);

                    buttonNatRefresh.PerformClick();
                }
            }
        }

        private async void buttonNatCreate_Click(object sender, EventArgs e)
        {
            PopupNetworkCreateForm popup = new PopupNetworkCreateForm();
            popup.Text = "Create NetNat";
            if (popup.ShowDialog() == DialogResult.OK)
            {
                string name = popup.textBoxName.Text;
                string ipAddress = popup.textBoxIP.Text;

                string script = "New-NetNat -Name \"" + name + "\" -InternalIPInterfaceAddressPrefix " + ipAddress;
                await runUtils.RunPowerShellScriptAsync(script);

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
        private async void buttonSwitchRefresh_Click(object sender, EventArgs e)
        {

            buttonSwitchRefresh.Enabled = false;
            SwitchList = await runUtils.RunPowerShellScriptAsync("Get-VMSwitch");

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
        private async void listBoxSwitch_DoubleClick(object sender, EventArgs e)
        {
            PSObject item = getSelectedSwitch();
            if (null != item)
            {
                await runUtils.RunPowerShellScriptAsync("Get-VMSwitch -Name \"" + item.Properties["Name"].Value + "\"", true);
            }
        }

        private async void buttonSwitchDelete_Click(object sender, EventArgs e)
        {
            PSObject item = getSelectedSwitch();
            if (null != item)
            {
                DialogResult result = MessageBox.Show(this, "Delete selected Switch?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    string script = "Remove-VMSwitch -Name \"" + item.Properties["Name"].Value + "\" -Force";
                    await runUtils.RunPowerShellScriptAsync(script);

                    buttonSwitchRefresh.PerformClick();
                }
            }
        }

        private async void buttonSwitchCreate_Click(object sender, EventArgs e)
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

                await runUtils.RunPowerShellScriptAsync("New-VMSwitch -SwitchName \"" + name + "\" -SwitchType Internal");
                string ifindex = (await runUtils.RunPowerShellScriptAsync("Get-NetAdapter -Name \"vEthernet (" + name + ")\" | Select-Object -ExpandProperty 'ifIndex'"))[0].ToString();
                await runUtils.RunPowerShellScriptAsync("New-NetIPAddress -IPAddress " + ipAddress + " -PrefixLength " + subnet + " -InterfaceIndex " + ifindex);

                buttonSwitchRefresh.PerformClick();
            }
        }

        private void showLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.ShowLogs = showLogsToolStripMenuItem.Checked;
            Settings.Default.Save();
            textBoxOutput.Visible = Settings.Default.ShowLogs;
        }

        private void closeToTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.CloseToTray = closeToTrayToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

        private async void printVMInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PSObject vm = getSelectedVM();
            // 打印详细信息
            await runUtils.RunPowerShellScriptAsync("Get-VM -Name \"" + vm.Properties["Name"].Value + "\"", true);

        }

        private void vMSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PSObject vm = getSelectedVM();
            // VM Settings
            RunHvintegrate("vm " + vm.Properties["Id"].Value);
        }

        private async void enableNestedVMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PSObject vm = getSelectedVM();
            // Enable Nested VM
            await runUtils.RunPowerShellScriptAsync("Set-VMProcessor -VMName \"" + vm.Properties["Name"].Value + "\" -ExposeVirtualizationExtensions $true", true);
        }

        private async void deleteVMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PSObject vm = getSelectedVM();
            // Delete VM
            DialogResult result = MessageBox.Show(this, $"Are you sure you want to delete {vm.Properties["Name"].Value}?" +
            "This can not be undone.", $"Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                await runUtils.RunPowerShellScriptAsync("Remove-VM -VMName \"" + vm.Properties["Name"].Value + "\" -Force");
                buttonVmRefresh.PerformClick();
            }
        }

        /* SWITCH END */

    }
}
