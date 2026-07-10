using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

namespace _33Task
{
    public partial class Form1 : Form
    {
        private string str;
        public Form1()
        {
            InitializeComponent();
        }
        public void GetTime()
        {
            Thread.Sleep(5000);
            //label1.Text = DateTime.Now.ToString(); // 크로스 스레드 예외 발생
            str = DateTime.Now.ToString();
            MethodInvoker mi = new MethodInvoker(UpdateUI);
            this.BeginInvoke(mi);
        }

        public void UpdateUI()
        {
            label1.Text = str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetTime();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(GetTime));
            t.Start();
            MessageBox.Show("Done");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Task t = new Task(new Action(GetTime)); // 미리 정의된 스레드 풀에서 가져와서 생성
            //t.Start();

            //Task.Run(new Action(GetTime));
            //Task.Run(GetTime);
            Task.Run(() => GetTime()); // Lambda
        }

        // 반환값이 메서드
        public string Hello()
        {
            Thread.Sleep(5000);
            return "Hello";
        }

       
        
        private async void button4_Click(object sender, EventArgs e)
        {
            //Task<string> t = Task.Run<string>(new Func<string>(Hello));
            //Task<string> t = Task.Run<string>(Hello);
            Task<string> t = Task.Run<string>(() => Hello());

            label1.Text = await t; // awiat 는 Task에만 사용할 수 있고, Task.result의 값이 들어간다
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
