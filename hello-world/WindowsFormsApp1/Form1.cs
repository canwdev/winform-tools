using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            // this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定执行该操作吗？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // 对话框返回值判断
            if (result == DialogResult.Yes)
            {
                // 如果单击“确定”按钮，执行相应的操作
                MessageBox.Show(this, "你点击了确定！", "标题", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // 如果单击“取消”按钮，不执行任何操作
                // ...
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // this.Text = "自定义标题";

            // 获取启动参数
            string[] args = Environment.GetCommandLineArgs();

            string text = "";
            // 输出所有启动参数
            for (int i = 0; i < args.Length; i++)
            {
                text += i + ". " + args[i] + "\n";
                Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
            }

            // 在需要修改文本时，使用以下代码
            richTextBox1.Text = text;
        }

        private void btnCurDir_Click(object sender, EventArgs e)
        {
            string folderPath = Application.StartupPath;
            Process.Start(folderPath);
        }
    }
}
