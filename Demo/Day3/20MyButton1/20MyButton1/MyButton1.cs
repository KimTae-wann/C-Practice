using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20MyButton1
{
    // MyButton1 클래스 정의가 첫번째로 와야한다. 아니면 디자인 winform이 안보임
    public partial class MyButton1 : UserControl
    {
        // Property
        public string TextBoxText
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        // 2. 이벤트 정의
        public event MyEventHandler MyClick;
        public MyButton1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 3. event 발생
            if (MyClick != null)
            {
                MyEventArgs me = new MyEventArgs { Message = textBox1.Text };
                MyClick(this, me);
            }
        }

        private void MyButton1_Click(object sender, EventArgs e)
        {

        }
    }
    
    public class MyEventArgs : System.EventArgs 
    {
        public string Message { get; set; }
    }

    // 1. delegate 선언
    public delegate void MyEventHandler(object sender, MyEventArgs e);

}
