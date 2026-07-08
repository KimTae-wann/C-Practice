using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14StringBuilder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "hello";
            DateTime start = DateTime.Now;
            for (int i = 0; i < 50000; i++)
                s = s + i.ToString();
            DateTime end = DateTime.Now;
            MessageBox.Show((end - start).TotalMilliseconds.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder s = new StringBuilder("hello");
            DateTime start = DateTime.Now;
            for (int i = 0; i < 50000; i++)
                s = s.Append(i.ToString());
            DateTime end = DateTime.Now;
            MessageBox.Show((end - start).TotalMilliseconds.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string filePath = "c:\\temp\\test.txt";
            string filePath = @"c:\temp\test.txt";
            //listBox1.Items.Add(filePath);

            int n = filePath.LastIndexOf('\\');
            //listBox1.Items.Add(filePath.Substring(n + 1));

            int m = 1000;
            double pi = Math.PI;

            string s = string.Format($"m = {m} pi = {pi:f3}");
            //listBox1.Items.Add(s);

            var str = "hello world good";
            var word = str.Split(); // 공백을 기준;
            foreach (var a in word)
                listBox1.Items.Add(a);
            listBox1.Items.Add(string.Join(",", word));


        }
    }
}
