using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11ExtensionMethod
{
    static class A
    {
        public static int ToInt32(this string s)
        {
            return int.Parse(s);
        }

        public static int Power(this int k, int r)
        {
            return (int) Math.Pow(3, 4);
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            string s = "123";
            int n = s.ToInt32();

            int k = 3;
            int r = k.Power(4); // 3*3*3*3
        }
    }
}
