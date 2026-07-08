using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19Event
{
    delegate void EventHandler(object sender, MyEventArgs e); // 1. Delegate 선언
    class MyEventArgs : System.EventArgs
    {
        // 이벤트 정보
        public string Message {get; set;}
        // ...
    }
    class Button
    {
        public event EventHandler Click; // 2. 이벤트 정의
        public void FireEvent()
        {
            if (Click != null)
            {
                MyEventArgs e = new MyEventArgs { Message = "Button1-Hello" };
                Click(this, e); // invocation list에 있는 메서드를 호출 // 3. 이벤트 발생
            }
        }
    }

    class Form
    {
        public void ButtonClick1(object sender, MyEventArgs e)
        {
            Console.WriteLine("ButtonClick1:" + e.Message);
        }
        public void ButtonClick2(object sender, MyEventArgs e)
        {
            Console.WriteLine("ButtonClick2:" + e.Message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Form form1 = new Form();
            Button button1 = new Button();

            button1.Click += new EventHandler(form1.ButtonClick1);
            button1.Click += new EventHandler(form1.ButtonClick2);
            button1.FireEvent();
        }
    }
}
