using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _29MyEditor
{
    public partial class Form1 : Form
    {
        private string currentFile = "";
        private bool bModified = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void 끝내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bModified)
            {
                if (MessageBox.Show("저장?", "닫기", MessageBoxButtons.YesNo) == DialogResult.OK)
                {
                    저장ToolStripMenuItem.PerformClick();
                    return;
                }
            }
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            끝내기ToolStripMenuItem.PerformClick();
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(dlg.FileName, RichTextBoxStreamType.PlainText);
                toolStripStatusLabel1.Text = dlg.FileName;
                this.Text = "MyEditor - " + System.IO.Path.GetFileName(dlg.FileName);
                currentFile = dlg.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "MyEditor - 제목 없음";
        }

        private void 새로만들기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            this.Text = "MyEditor - 제목 없음";
            toolStripStatusLabel1.Text = string.Empty;
            currentFile = "제목 없음";
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFile == "제목없음" || currentFile == "")
                다른이름으로저장ToolStripMenuItem.PerformClick();
            else
                richTextBox1.SaveFile(currentFile, RichTextBoxStreamType.PlainText);
        }

        private void 다른이름으로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            bModified = true;
        }
    }
}
