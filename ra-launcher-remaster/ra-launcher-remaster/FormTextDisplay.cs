using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RaLauncher
{
    public partial class FormTextDisplay : Form
    {
        public FormTextDisplay(string inputText = "", string title = "Dialog")
        {
            InitializeComponent();
            this.Text = title;
            richTextBox1.Text = inputText; // 将传递过来的文本显示在多行文本框中
            richTextBox1.ContextMenu = new ContextMenu();
        }

        private void FormTextDisplay_Load(object sender, EventArgs e)
        {
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(richTextBox1.Text);
            btnCopy.Text = "Copied!";
        }
    }
}
