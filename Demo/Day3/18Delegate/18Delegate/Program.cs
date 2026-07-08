using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18Delegate
{
    delegate void MyDelegate(string s); // 접근제어자 생략 시 Internal
    // class MyDelegate : System.MulticastDelegate

    delegate int ArithDelegate(int a, int b);
    class Program
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
        public static int Subtract(int a, int b)
        {
            return a - b;
        }
        public static void Hello(string s)
        {
            System.Console.WriteLine("Hello, " + s);
        }
        public static void GoodBye(string s)
        {
            System.Console.WriteLine("Good Bye, " + s);
        }
        static void Main(string[] args)
        {
            Hello("A");
            GoodBye("B");

            MyDelegate md1 = new MyDelegate(Hello);
            md1 += new MyDelegate(GoodBye); // invocation list 에 추가
            MyDelegate md2 = new MyDelegate(GoodBye);
            //MyDelegate md2 = GoodBye;

            md1("나여");
            md1 -= new MyDelegate(GoodBye);
            md1("나여");

            //ArithDelegate ad1 = new ArithDelegate(Add);
            //ArithDelegate ad2 = new ArithDelegate(Subtract);

            //int res1 = ad1(10, 20);
            //int res2 = ad2(50, 40);

            //Console.WriteLine($"결과: res1 = {res1} , res2 = {res2}");

            // button1.Click += new EventHandler(button1_Click);
            Button button1 = new Button();
            button1.Click += new MyDelegate(Hello);
            //button1.Click += Hello;

        }
    }

    class Button
    {
        public event MyDelegate Click;
    }
}
