using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23FileDir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(textBox1.Text.Trim());
            if (dir.Exists)
            {
                var dirs = dir.GetDirectories();
                var files = dir.GetFiles();

                foreach (var d in dirs)
                {
                    bool isHidden = (d.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden;
                    if (!isHidden)
                        listBox1.Items.Add(d.Name);
                }

                foreach (var f in files)
                {
                    bool isHidden = (f.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden;
                    if (!isHidden)
                        listBox1.Items.Add(f.Name + "\t" + f.Length + "\t" + f.LastWriteTime.ToString());
                }
            }
            else
            {
                if (MessageBox.Show("해당 디렉토리가 없습니다. 새로 생성하시겠습니까?", "생성", 
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dir.Create();
                    string src = "../../Form1.cs"; // 상대경로 체크
                    string dest = Path.Combine(dir.FullName, "copy.txt");
                    //if(File.Exists(src))
                    //    File.Copy(src, dest);
                    FileInfo f = new FileInfo(src);
                    if (f.Exists)
                        f.CopyTo(dest);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string s = listBox1.SelectedItem.ToString();
                var r = s.Split('\t');
                if (r.Length == 1) // dir
                {
                    string path = Path.Combine(textBox1.Text, r[0]);
                    Directory.Delete(path); // 디렉토리가 비워져있지 않으면 예외뜸. true값 주면됨
                    // 권한 없는 디렉토리는 UnAuthorizedAccessException 일어남
                }
                button1.PerformClick();
            }
            else
                MessageBox.Show("삭제할 항목을 선택하세요");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string s = listBox1.SelectedItem.ToString();
            var r = s.Split('\t');
            if (r.Length == 1) // dir
            {
                DirectoryInfo dir = new DirectoryInfo(Path.Combine(textBox1.Text, r[0]));
                    var dirs = dir.GetDirectories();
                    var files = dir.GetFiles();

                    foreach (var d in dirs)
                    {
                    bool isHidden = (d.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden;
                    if (!isHidden)
                        listBox2.Items.Add(d.Name);
                    }

                    foreach (var f in files)
                    {
                        bool isHidden = (f.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden;
                        if (!isHidden)
                            listBox2.Items.Add(f.Name + "\t" + f.Length + "\t" + f.LastWriteTime.ToString());
                    }
                //string path = Path.Combine(textBox1.Text, r[0]);
            }
        }
    }
}
