using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
// C:\Windows\assembly\GAC_MSIL\System.Management.Automation\1.0.0.0__31bf3856ad364e35
using System.Management.Automation;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

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
            if (textBoxOutput.Text.Length + log.Length > textBoxOutput.MaxLength)
            {
                int excessLength = (textBoxOutput.Text.Length + log.Length) - textBoxOutput.MaxLength;
                textBoxOutput.Text = textBoxOutput.Text.Remove(0, excessLength);
            }
            textBoxOutput.AppendText(log + Environment.NewLine);
            textBoxOutput.SelectionStart = textBoxOutput.Text.Length;
            textBoxOutput.ScrollToCaret();
        }

        public async Task<Collection<PSObject>> RunPowerShellScriptAsync(string script, bool isDetailLog = false)
        {
            try
            {
                using (PowerShell PowerShellInstance = PowerShell.Create())
                {
                    _form.UseWaitCursor = true;
                    _form.progressBar1.Visible = true;
                    AppendLog(">>> " + script);


                    PowerShellInstance.AddScript(script);


                    // 捕获Powershell的错误信息
                    PowerShellInstance.Streams.Error.DataAdded += (sender, eventArgs) =>
                    {
                        foreach (var errorRecord in PowerShellInstance.Streams.Error)
                        {
                            _form.Invoke((MethodInvoker)delegate {
                                AppendLog("PowerShell Error: " + errorRecord.ToString());
                            });
                        }
                    };

                    Collection<PSObject> PSOutput = await Task.Run(() =>
                    {
                        return PowerShellInstance.Invoke();
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

                                foreach (FieldInfo field in result.BaseObject.GetType().GetFields())
                                {
                                    AppendLog(field.Name + ": " + field.GetValue(result.BaseObject));
                                }
                                AppendLog("===========================");
                            }
                            else
                            {
                                AppendLog(result.BaseObject.ToString());
                            }
                        }
                    }


                    // 执行完成后隐藏进度条
                    _form.progressBar1.Visible = false;
                    _form.UseWaitCursor = false;

                    return PSOutput;
                }
            }
            catch (Exception ex)
            {
                // 捕获错误并记录日志或者进行其他处理
                AppendLog("Error occurred: " + ex.Message);
                _form.progressBar1.Visible = false;
                _form.UseWaitCursor = false;
                return null;
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

    }
}
