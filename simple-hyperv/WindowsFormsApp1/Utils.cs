using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        public Collection<PSObject> RunPowerShellScript(string script)
        {
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                _form.progressBar1.Visible = true;
                AppendLog(">>> " + script);


                PowerShellInstance.AddScript(script);
                Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                foreach (var result in PSOutput)
                {
                    AppendLog(result.ToString());
                }


                // 执行完成后隐藏进度条
                _form.progressBar1.Visible = false;

                return PSOutput;
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
