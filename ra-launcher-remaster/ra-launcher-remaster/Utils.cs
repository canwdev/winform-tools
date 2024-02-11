using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUtilsNamespace
{
    // 静态工具函数
    public static class MyUtils
    {
        // 写入文件到程序所在目录
        public static void WriteToFile(string fileName, string content, bool isOverride = false)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            if (!File.Exists(filePath) || isOverride)
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

        // 启动程序目录下的程序
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

        // 结束进程
        public static void KillProcess(string processname)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";   // 启动命令提示符
            startInfo.Arguments = "/c taskkill /f /im " + processname;   // 执行 taskkill 命令，/c 参数表示执行完命令后关闭命令提示符
            startInfo.CreateNoWindow = true;  // 不创建进程窗口
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;  // 隐藏窗口样式
            Process.Start(startInfo);
        }

        // 生成vbs脚本
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

        // 提取资源如果不存在
        public static string ExtractResource(string resName, bool isOverride = false, string newName = "")
        {
            // 获取要提取的资源文件路径
            // 必须和项目中的命名空间一致！
            string localNameSpace = Assembly.GetEntryAssembly().GetName().Name;
            string resFilePath = localNameSpace + ".Resources." + resName;
            Console.WriteLine(resFilePath);

            // 获取提取后dll文件的目标路径
            newName = newName == "" ? resName : newName;
            string targetFilePath = Path.Combine(Application.StartupPath, newName);

            if (!File.Exists(targetFilePath) || isOverride)
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
}
