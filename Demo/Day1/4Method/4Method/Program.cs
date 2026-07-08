using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Method
{
    class Util
    {
        public static void Divide(int a, int b, out int q, out int r)
        {
            q = a / b;
            r = a % b; 
        }
        public static void Swap(ref int a, ref int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
        }
        public static int Max(int a, int b)
        {
            return a > b ? a : b;
        }
        public static double Max(double a, double b)
        {
            return a > b ? a : b;
        }
        /*public static int Add(int a, int b)
        {
            return a + b;
        }
        public static int Add(int a, int b, int c)
        {
            return a + b + c;
        }*/
        
        // Optional Parameter => .NET Fx4 VS2010 부터 지원
        public static int Add(int a, int b, int c = 0, int d = 0)
        {
            return a + b + c + d;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Method Overloading
            double d1 = 3.3, d2 = 4.4;
            Console.WriteLine(Util.Max(d1, d2));

            int r1 = Util.Add(10, 20);
            r1 = Util.Add(10, 20, 30);
            r1 = Util.Add(10, 20, 30, 40);

            r1 = Util.Add(a: 10, b: 20,  d: 40);

            Console.WriteLine(r1);

            Console.Write("숫자 입력?");
            string temp = Console.ReadLine();
            // int k = int.Parse(temp);

            int k;
            if (int.TryParse(temp, out k))
                Console.WriteLine($"입력하신 숫자는 {k} 입니다");
            else
                Console.WriteLine("변환 실패");


            Console.WriteLine($"입력하신 숫자는 {k} 입니다");

            int n;
            /*Util a = new Util();
            a.Max(1, 2);*/

            int x = 10, y = 20;
            int r = Util.Max(x, y);
            Console.WriteLine($"{x} 와 {y} 중에 큰 수는 {r} 입니다");

            Console.WriteLine($"x={x} y={y}");
            // Util.Swap(x, y);
            Util.Swap(ref x, ref y);
            Console.WriteLine($"x={x} y={y}");

            int x1 = 10, y1 = 3;
            int qq, rr;
            Util.Divide(x1, y1, out qq, out rr);
            Console.WriteLine($"몫:{qq} 나머지:{rr}");

        }
    }
}
