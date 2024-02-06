using System;
using System.Windows.Forms;
using System.Security.Principal;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 检查当前用户是否拥有管理员权限
            if (IsAdministrator())
            {
                // 如果有管理员权限，则以管理员身份启动应用程序
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                // 如果没有管理员权限，则重新以管理员权限启动应用程序
                var processInfo = new System.Diagnostics.ProcessStartInfo(Application.ExecutablePath);
                processInfo.Verb = "runas";
                System.Diagnostics.Process.Start(processInfo);
            }
        }

        // 检查当前用户是否拥有管理员权限
        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
