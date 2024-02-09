using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
// .NET 8.0 请安装 NuGet 包：Microsoft.PowerShell.SDK; System.Configuration.ConfigurationManager; System.Management.Automation
// .NET Framework 4.7.2 不支持，请添加 Reference C:\Windows\assembly\GAC_MSIL\System.Management.Automation\1.0.0.0__31bf3856ad364e35\System.Management.Automation.dll
using System.Management.Automation;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleHyperVForm1;

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

        public static string ExtractResourceIfNotExist(string filename)
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

    }

    public static class SingleInstanceNamedPipeServer
    {
        public static void StartServer(string name = "SingleInstancePipe", string message = "OnSecondInstance")
        {
            using (NamedPipeServerStream pipeServer =
                new NamedPipeServerStream(name, PipeDirection.Out))
            {
                Console.WriteLine("[{0}] NamedPipeServerStream object created.", name);

                // Wait for a client to connect
                Console.Write("Waiting for client connection...");
                pipeServer.WaitForConnection();

                Console.WriteLine("Client connected.");
                try
                {
                    // Read user input and send that to the client process.
                    using (StreamWriter sw = new StreamWriter(pipeServer))
                    {
                        sw.AutoFlush = true;
                        Console.Write("Send message: {0}", message);
                        sw.WriteLine(message);
                    }
                }
                // Catch the IOException that is raised if the pipe is broken
                // or disconnected.
                catch (IOException e)
                {
                    Console.WriteLine("ERROR: {0}", e.Message);
                }
            }
        }
        public delegate void Callback(string message);
        public static void StartClient(Callback callback, string name = "SingleInstancePipe")
        {
            while (true)
            {
                using (NamedPipeClientStream pipeClient =
                    new NamedPipeClientStream(".", name, PipeDirection.In))
                {
                    try
                    {
                        // Connect to the pipe or wait until the pipe is available.
                        Console.Write("[{0}] Attempting to connect to pipe... ", name);
                        pipeClient.Connect();

                        Console.WriteLine("Connected to pipe.");
                        Console.WriteLine("There are currently {0} pipe server instances open.",
                            pipeClient.NumberOfServerInstances);
                        using (StreamReader sr = new StreamReader(pipeClient))
                        {
                            // Display the read text to the console
                            string message;
                            while ((message = sr.ReadLine()) != null)
                            {
                                Console.WriteLine("Received from server: {0}", message);
                                callback(message);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error occurred while connecting to pipe: {0}", e.Message);
                        // 可添加重连延迟
                    }
                }
            }
        }
    }
    public class NamedPipeServer
    {
        private string pipeName;
        private NamedPipeServerStream serverStream;
        public delegate void Callback(string message);

        public NamedPipeServer(string pipeName)
        {
            this.pipeName = pipeName;
        }

        public void StartServer(Callback callback)
        {
            Console.WriteLine("[{0}] Start NamedPipe Server", pipeName);

            serverStream = new NamedPipeServerStream(pipeName, PipeDirection.InOut, -1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
            serverStream.BeginWaitForConnection(r => WaitForConnectionCallback(r, callback), null);
        }

        private void WaitForConnectionCallback(IAsyncResult result, Callback callback)
        {
            serverStream.EndWaitForConnection(result);
            Console.WriteLine("Client connected");

            // Read data from client
            StreamReader reader = new StreamReader(serverStream);
            string message = reader.ReadLine();
            Console.WriteLine("Received message from client: " + message);

            // Disconnect and start waiting for new connection
            serverStream.Disconnect();
            Console.WriteLine("Client disconnected");
            StartServer(callback);
        }
    }


    public class NamedPipeClient
    {
        private string pipeName;
        private NamedPipeClientStream clientStream;

        public NamedPipeClient(string pipeName)
        {
            this.pipeName = pipeName;
        }

        public void StartClient(string message = "Hello from client")
        {
            while (true)
            {
                /*try
                {*/
                    Console.WriteLine("[{0}] Connecting to NamedPipe server...", pipeName);
                    clientStream = new NamedPipeClientStream(".", pipeName, PipeDirection.InOut, PipeOptions.Asynchronous);
                    clientStream.Connect();
                    Console.WriteLine("Connected to server");

                    Console.WriteLine("Send message to server: " + message);
                    StreamWriter writer = new StreamWriter(clientStream);
                    writer.WriteLine(message);
                    writer.Flush();

                    // Wait for a few seconds before attempting to reconnect
                    Thread.Sleep(2000);
                /*}
                catch (Exception)
                {
                    // Handle connection error and attempt to reconnect
                    Console.WriteLine("Connection error. Attempting to reconnect...");
                    clientStream.Close();
                    Thread.Sleep(2000); // Wait before reconnecting
                }*/
            }
        }
    }


}
