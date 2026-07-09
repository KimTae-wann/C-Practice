using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32Lambda
{
    delegate void MyDelegate(string s);
    class Program
    {
        public static void Hello(string s)
        {
            Console.WriteLine("Hello," + s);
        }

        public static void GoodBye(string s)
        {
            Console.WriteLine("Hello," + s);
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            MyDelegate d1 = new MyDelegate(Hello);
            d1("A");

            // Anonymous Method
            MyDelegate d2 = delegate (string s)
            {
                Console.WriteLine("Hello," + s);
            };
            d2("B");

            MyDelegate d3 = (s) => Console.WriteLine("Hello," + s);
            d3("C");

            // 반환값이 없는 메서드를 호출 Action (mscorlib.System.Action)
            Action<string> a1 = new Action<string>(Hello);
            a1("D");

            Action<string> a2 = Hello;
            a2("E");

            Action<string> a3 = (s) => Console.WriteLine("Hello," + s);

            // 반환값이 있는 메서드를 호출
            Func<int, int, int> b1 = new Func<int, int, int>(Add);
            Console.WriteLine(b1(10, 20));

            Func<int, int, int> b2 = Add;
            Console.WriteLine(b2(10, 20));

            Func<int, int, int> b3 = (a, b) => a + b;
            Console.WriteLine(b3(10, 20));

            /*Task t = new Task();
            Task<string> tt = new Task<string>();*/
        }
    }
}
