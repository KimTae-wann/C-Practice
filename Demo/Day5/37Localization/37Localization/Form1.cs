using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Resources; // ResourceManager
using System.Reflection; // Assembly 클래스

namespace _37Localization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // Culture: 통화량, 날짜형식
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-CN");
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            InitializeComponent(); // 생성자 전에 Culture 코드 설정해줘야 함.
        }

        // Localizaiton 설정안하면 제어판 설정 읽어옴
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("F");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string s = "Hello";
            //MessageBox.Show(s);

            ResourceManager rm = new ResourceManager("_37Localization.Resource1", Assembly.GetExecutingAssembly());
            string s = rm.GetString("String1");
            MessageBox.Show(s);
        }
    }
}
