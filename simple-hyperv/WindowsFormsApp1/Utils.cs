using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
// .NET 8.0 请安装 NuGet 包：Microsoft.PowerShell.SDK; System.Configuration.ConfigurationManager; System.Management.Automation
// .NET Framework 4.7.2 不支持，请添加 Reference C:\Windows\assembly\GAC_MSIL\System.Management.Automation\1.0.0.0__31bf3856ad364e35\System.Management.Automation.dll
using System.Management.Automation;
using System.Reflection;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleHyperVForm1;
// 需要安装 Nuget 包：TaskScheduler 
using Microsoft.Win32.TaskScheduler;
using System.Security.Principal;
using Action = System.Action;
using Task = System.Threading.Tasks.Task;

namespace MyUtilsNamespace
{
    public class RunUtils
    {
        private Form1 _form; // 保存 Form 实例的成员变量

        public RunUtils(Form1 form)
        {
            _form = form; // 在构造函数中保存 Form 实例
        }

        // 将运行结果日志显示在 textBoxOutput 控件中
        public void AppendLog(string log)
        {
            System.Windows.Forms.TextBox textBoxOutput = _form.textBoxOutput;

            //在UI线程中执行
            textBoxOutput.BeginInvoke(new Action(() =>
            {
                if (textBoxOutput.Text.Length + log.Length > textBoxOutput.MaxLength)
                {
                    int excessLength = (textBoxOutput.Text.Length + log.Length) - textBoxOutput.MaxLength;
                    textBoxOutput.Text = textBoxOutput.Text.Remove(0, excessLength);
                }
                textBoxOutput.AppendText(log + Environment.NewLine);
            }));
            textBoxOutput.SelectionStart = textBoxOutput.Text.Length;
            textBoxOutput.ScrollToCaret();

        }

        public async Task<Collection<PSObject>> RunPowerShellScriptAsync(string script, bool isDetailLog = false)
        {
            try
            {
                using (PowerShell ps = PowerShell.Create())
                {
                    _form.UseWaitCursor = true;
                    _form.progressBar1.Visible = true;
                    AppendLog(">>> " + script);

                    ps.AddScript(script);


                    // 捕获Powershell的错误信息
                    ps.Streams.Error.DataAdded += (sender, eventArgs) =>
                    {
                        // 以下方式可能导致powershell无法退出，故不使用。
                        /*foreach (var errorRecord in ps.Streams.Error)
                        {
                            _form.Invoke((MethodInvoker)delegate {
                                AppendLog("PowerShell Error: " + errorRecord.ToString());
                            });
                        }*/

                        _form.Invoke((MethodInvoker)delegate
                        {
                            AppendLog("PowerShell Error: " + ps.Streams.Error[0].ToString());
                        });
                    };

                    Collection<PSObject> PSOutput = await Task.Run(() =>
                    {
                        return ps.Invoke();
                    });

                    foreach (var result in PSOutput)
                    {

                        if (result != null)
                        {
                            if (isDetailLog)
                            {
                                AppendLog("===========================");
                                foreach (PropertyInfo prop in result.BaseObject.GetType().GetProperties())
                                {
                                    AppendLog(prop.Name + ": " + prop.GetValue(result.BaseObject));
                                }
                                AppendLog("===========================");
                            }
                            else
                            {
                                AppendLog(result.BaseObject.ToString());
                            }
                        }
                    }

                    return PSOutput;
                }
            }
            catch (Exception ex)
            {
                // 捕获错误并记录日志或者进行其他处理
                AppendLog("catch error: " + ex.Message);
                return null;
            }
            finally
            {
                // 执行完成后隐藏进度条
                _form.progressBar1.Visible = false;
                _form.UseWaitCursor = false;
            }
        }

        public string RunCmdCommand(string command)
        {
            _form.progressBar1.Visible = true;
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
                _form.progressBar1.Visible = false;
                return result;
            }
        }

    }
    public static class MyUtils
    {
        public static void WriteToFile(string fileName, string content, bool isForceWrite = false)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            if (!File.Exists(filePath) || isForceWrite)
            {
                try
                {
                    File.WriteAllText(filePath, content);
                    Console.WriteLine("文件成功写入");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("写入文件时出错: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("文件已存在，不进行写入");
            }
        }

        public static void StartCurDirProgram(string exeName, string args = "")
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
                MessageBox.Show(exeName + " " + args + "\n" + ex.Message, "启动失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string GenerateVbsScript(string programName, string paramsText)
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

        public static string ExtractResource(string filename)
        {
            // 获取要提取的资源文件路径
            // 必须和项目中的命名空间一致！
            string localNameSpace = Assembly.GetEntryAssembly().GetName().Name;
            string resFilePath = localNameSpace + ".Resources." + filename;
            Console.WriteLine(resFilePath);

            // 获取提取后dll文件的目标路径
            string targetFilePath = Path.Combine(Application.StartupPath, filename);

            if (!File.Exists(targetFilePath))
            {
                Console.WriteLine(targetFilePath);

                // 从资源文件中读取dll文件并复制
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resFilePath))
                {
                    using (FileStream fileStream = new FileStream(targetFilePath, FileMode.Create))
                    {
                        stream.CopyTo(fileStream);
                    }
                }
            }

            return targetFilePath;
        }

        public static void addAutostartup(string name = "AutoStartupTaskName")
        {
            WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
            string username = currentUser.Name.Split('\\')[1]; // 获取当前用户的用户名

            // 创建一个新的计划任务
            using (TaskService taskService = new TaskService())
            {
                // 创建一个触发器，以便在用户登录时运行任务
                LogonTrigger logonTrigger = new LogonTrigger();
                logonTrigger.UserId = username; // 设置只有指定用户登录时才触发任务
                logonTrigger.Delay = new TimeSpan(0, 0, 5); // 设置延迟时间为5秒

                // 创建一个新的任务
                TaskDefinition taskDefinition = taskService.NewTask();
                taskDefinition.RegistrationInfo.Description = "Auto startup at user login.";

                // 获取当前程序的路径
                string path = System.Reflection.Assembly.GetEntryAssembly().Location;

                // 设置任务的操作，即要运行的程序或脚本以及参数
                taskDefinition.Actions.Add(new ExecAction(path, "-m", null) { WorkingDirectory = Application.StartupPath });

                // 设置任务的权限，以最高权限运行
                taskDefinition.Principal.RunLevel = TaskRunLevel.Highest;

                // 将触发器添加到任务中
                taskDefinition.Triggers.Add(logonTrigger);

                // 不要勾选“只有在计算机使用交流电源时才启动此任务”
                taskDefinition.Settings.DisallowStartIfOnBatteries = false;

                // 将任务注册到Windows任务计划程序中
                taskService.RootFolder.RegisterTaskDefinition(name, taskDefinition);
            }
        }

        public static void delAutostartup(string name = "AutoStartupTaskName")
        {

            // 创建一个新的任务计划服务
            using (TaskService taskService = new TaskService())
            {
                // 从任务计划程序中获取指定的任务
                Microsoft.Win32.TaskScheduler.Task task = taskService.GetTask(name);

                // 如果找到了指定的任务，则删除它
                if (task != null)
                {
                    taskService.RootFolder.DeleteTask(name);
                }
            }
        }

    }

    // 命名管道，进程间通信方式，用于控制第二个实例调起第一个实例显示窗口
    public static class SingleInstanceNamedPipeServer
    {
        private static string pipeName = "SingleInstancePipe";
        public delegate void Callback(string message);
        // 启动命名管道服务器，回调函数用作显示主窗口
        public static void StartServer(Callback callback)
        {
            Debug.WriteLine("[Server] [" + pipeName + "] Start NamedPipe Server");

            // 允许普通权限客户端 可以连接管理员权限的服务器
            PipeSecurity pipeSecurity = new PipeSecurity();
            pipeSecurity.AddAccessRule(new PipeAccessRule("Everyone", PipeAccessRights.ReadWrite, AccessControlType.Allow));

            // 服务器如果正常断开，需要重新启动
            while (true)
            {
                using (NamedPipeServerStream pipeServer =
                new NamedPipeServerStream(pipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous, 1024, 1024, pipeSecurity))
                {
                    Debug.WriteLine("[Server] Waiting for client connection...");
                    pipeServer.WaitForConnection();
                    Debug.WriteLine("[Server] Client connected.");
                    try
                    {
                        // Read data from client
                        StreamReader reader = new StreamReader(pipeServer);
                        string message = reader.ReadLine();
                        Debug.WriteLine("[Server] Received message from client: " + message);
                        callback(message);

                        // Wait for a few seconds before attempting to reconnect
                        Thread.Sleep(2000);
                    }
                    // Catch the IOException that is raised if the pipe is broken
                    // or disconnected.
                    catch (IOException e)
                    {
                        Debug.WriteLine("[Server] ERROR: " + e.Message);

                        Thread.Sleep(2000); // Wait before reconnecting
                    }

                }
            }
        }
        
        // 启动命名管道客户端，第二个实例启动时调用
        public static void StartClient(string message = "OnSecondInstance")
        {
            Debug.WriteLine("[Client] StartClient");
            while (true)
            {
                using (NamedPipeClientStream pipeClient =
                    new NamedPipeClientStream(".", pipeName, PipeDirection.InOut))
                {
                    try
                    {
                        // Connect to the pipe or wait until the pipe is available.
                        Debug.WriteLine("[Client] [" + pipeName + "] Connecting to NamedPipe server...");
                        pipeClient.Connect();

                        Debug.WriteLine("[Client] Connected to server");
                        Console.WriteLine("There are currently {0} pipe server instances open.",
                            pipeClient.NumberOfServerInstances);


                        Debug.WriteLine("[Client] Send message to server: " + message);
                        StreamWriter writer = new StreamWriter(pipeClient);
                        writer.WriteLine(message);
                        writer.Flush();

                        // Wait for a few seconds before attempting to reconnect
                        //Thread.Sleep(2000);

                        // 由于是第二个实例，执行完成后直接退出
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("[Client] Error occurred while connecting to pipe: " + e.Message);
                        pipeClient.Close();
                        Thread.Sleep(2000); // Wait before reconnecting

                        // 由于是第二个实例，执行完成后直接退出
                        break;
                    }
                }
            }

        }
    }

}
