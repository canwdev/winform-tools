using System;
using System.Windows.Forms;
using System.Security.Principal;
using System.Threading;
using System.Linq;
using System.IO.Pipes;
using System.IO;
using MyUtilsNamespace;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SimpleHyperVForm1
{
    internal static class Program
    {
        static Mutex mutex = new Mutex(true, "MyWinFormAppMutex");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            if (mutex.WaitOne(TimeSpan.Zero, true))
            {

                // 检查当前用户是否拥有管理员权限
                if (IsAdministrator())
                {

                    // 如果有管理员权限，则以管理员身份启动应用程序
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    Form1 mainForm = new Form1(args);
                    Application.Run(mainForm);

                    mutex.ReleaseMutex();
                }
                else
                {
                    // 如果没有管理员权限，则重新以管理员权限启动应用程序
                    var processInfo = new System.Diagnostics.ProcessStartInfo(Application.ExecutablePath);
                    processInfo.Verb = "runas";
                    //传递args
                    processInfo.Arguments = String.Join(" ", args);
                    System.Diagnostics.Process.Start(processInfo);
                }
            }
            else
            {
                // Another instance is already running
                // MessageBox.Show("Application already started!", "", MessageBoxButtons.OK);
                SingleInstanceNamedPipeServer.StartClient();
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
