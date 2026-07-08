using System;

namespace _1ConsoleApp
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


            // Culture 통화량, 날짜 형식
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine(DateTime.Now.ToString("f")); //f F
            Console.WriteLine(DateTime.Now.ToString("yy-MM-dd")); // f
            Console.WriteLine(DateTime.Now.ToShortDateString());
            Console.WriteLine(DateTime.Now.ToLongDateString());
        }
    }
}