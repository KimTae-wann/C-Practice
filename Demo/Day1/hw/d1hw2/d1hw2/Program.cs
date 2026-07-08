using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d1hw2
{
    class Program
    {
        static void Main(string[] args)
        {
            int repeat;
            do
            {
                Console.Write("반복 횟수를 입력하세요:");
                repeat = int.Parse(Console.ReadLine());

                if (repeat <= 0) 
                    Console.WriteLine("0보다 작거나 같은수는 입력할 수 없습니다.");
                Console.WriteLine();
            } while (repeat <= 0 );

            for (int i = 1; i <= repeat; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
