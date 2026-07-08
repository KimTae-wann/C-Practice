using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d1hw3
{
    class Program
    {
        public static int CountEven(ref int num1, ref int num2) 
        {
            // Swap
            if (num1 > num2)
            {
                int temp;
                temp = num1;
                num1 = num2;
                num2 = temp;
            }
            
            // Count
            int count = 0;
            for (int i = num1; i <= num2; i++)
            {
                if (i % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            int num1, num2;
            Console.Write("첫번째 정수 입력? ");
            num1 = int.Parse(Console.ReadLine());
            Console.Write("두번째 정수 입력? ");
            num2 = int.Parse(Console.ReadLine());

            int res = CountEven(ref num1, ref num2);
            Console.WriteLine($"{num1}와 {num2}사이의 짝수의 개수는 {res}개입니다.");

        }
    }
}
