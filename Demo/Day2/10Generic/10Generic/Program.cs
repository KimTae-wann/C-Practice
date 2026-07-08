using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Generic
{
    class Program
    {
        /*public static void Swap (ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static void Swap(ref double a, ref double b)
        {
            double temp = a;
            a = b;
            b = temp;
        }*/

        public static void Swap <T> (ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        static void Main(string[] args)
        {
            int x = 10, y = 20;
            Swap(ref x, ref y);
            //Swap<int>(ref x, ref y);
            //Console.WriteLine($"x = {x} y = {y}");

            double dx = 10, dy = 20;
            Swap(ref dx, ref dy);
            //Console.WriteLine($"dx = {dx} dy = {dy}");

            Stack<int> s1 = new Stack<int>(3);
            s1.Push(10);
            s1.Push(20);
            s1.Push(30);
            Console.WriteLine(s1.Pop()); // 30
            Console.WriteLine(s1.Pop()); // 20
            
            Stack<double> s2 = new Stack<double>(3);
            s2.Push(10.0);
            s2.Push(20.0);
            s2.Push(30.0);
            Console.WriteLine(s2.Pop()); // 30
            Console.WriteLine(s2.Pop()); // 20

            string ss = "hello"; // string은 sealed 인 경우라, extension을 사용한다.
        }
    }
}
