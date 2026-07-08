using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _21CallbackThread
{
    class Program
    {
        public static void Test()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(2000);
                Console.WriteLine($"Test:{i}");
            }
        }
        static void Main(string[] args)
        {
            //Test();

            ThreadStart ts = new ThreadStart(Test);
            Thread t = new Thread(ts);
            t.Start(); // ts 호출함 콜백은 직접 호출X

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Main:{i}");
            }

            t.Join(); // t가 끝날때 까지 기다리겠다

            Console.WriteLine("--Program end--");
        }
    }
}
