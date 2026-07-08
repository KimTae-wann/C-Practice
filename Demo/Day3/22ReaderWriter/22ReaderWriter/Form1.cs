using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO; 

namespace _22ReaderWriter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 인코딩 지정 안할 시 "UTF-8" 이 디폴트 / dafault로 지정하면 ANSI가 디폴트
            // StreamWriter 는 덮어쓰기 해버림 true 하면 append
            StreamWriter w = new StreamWriter("test.txt", true, Encoding.UTF8);
            w.Write("Hello");
            w.WriteLine("안녕");
            w.WriteLine($"i={1000:c} j={2000:c}");

            w.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader r = new StreamReader("test.txt"); // UTF-8
            // 한글자
            // 한단어
            // 한줄
            while (!r.EndOfStream)
            {
                listBox1.Items.Add(r.ReadLine());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("test.bin", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs); // 이진파일 쓰기는 FileStream 이 매개변수로 들어가야됨 

            bw.Write(100); // int - 4byte
            bw.Write("Hello"); // string
            bw.Write(3.14); // double - 8bytes
            bw.Close(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("test.bin", FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            listBox1.Items.Add(br.ReadInt32());
            listBox1.Items.Add(br.ReadString());
            listBox1.Items.Add(br.ReadDouble());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string str = "hello 안녕";
            FileStream fs = new FileStream("fs.txt", FileMode.Create);
            // string --> byte[]
            byte[] b = Encoding.UTF8.GetBytes(str);
            fs.Write(b, 0, b.Length);
            fs.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("fs.txt", FileMode.Open);
            // byte[] --> string
            byte[] b = new byte[6];
            int n = fs.Read(b, 0, b.Length); // 실제 읽어 들은 바이트 수
            string s = "";
            while (n > 0)
            {
                s+= Encoding.UTF8.GetString(b);
                n = fs.Read(b, 0, b.Length);
            }
            listBox1.Items.Add(s);
            fs.Close();
        }
    }
}
