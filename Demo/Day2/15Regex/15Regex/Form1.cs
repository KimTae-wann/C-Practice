using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _15Regex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Trim();
            string pattern = @"^010-\d{4}-\d{4}$";
            if (Regex.IsMatch(input, pattern))
                MessageBox.Show("휴대폰 번호 형식");
            else
                MessageBox.Show("휴대폰 번호 형식이 아닙니다");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = textBox2.Text.Trim();
            string pattern = @"^[\w\.]+@[\w]+\.[\w]+$";
            if (Regex.IsMatch(input, pattern))
                MessageBox.Show("이메일 형식");
            else
                MessageBox.Show("이메일 형식이 아닙니다");
        }
    }
}
