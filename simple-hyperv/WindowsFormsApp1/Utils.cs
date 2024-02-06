using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MyUtils
{
    public static class FileHelper
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
    }
}
