using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Culture
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            int n = 1000, k = 200;

            Console.WriteLine("n ={ 0:c} k ={ 1:d5}", n, k); // currency digit

            // 보간법
            Console.WriteLine("$n ={ n} k ={ k}");
            Console.WriteLine("$n ={ n:c} k ={ k:d5}"); // Format 지정까지

            float pi = 3.1415921231f;
            Console.WriteLine(pi);
            double d = 3.1415921231;
            Console.WriteLine(d);

            Console.WriteLine("d={0:f4}", d);
            Console.WriteLine("$d={d:f4}");

            // Culture 통화량, 날짜 형식
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine(DateTime.Now.ToString("f")); //f F
            Console.WriteLine(DateTime.Now.ToString("yy-MM-dd")); // f
            Console.WriteLine(DateTime.Now.ToShortDateString());
            Console.WriteLine(DateTime.Now.ToLongDateString());
        }
    }
}
