using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5Class
{ // internal
    class Program
    {
        static void Main(string[] args)
        {
            // Property 를 가지고 get, set을 모두 제공한다.
            Console.ForegroundColor = ConsoleColor.Yellow;

            Account.SetInterest(0.3);

            Account a = new Account(); // Heap에 생성, 생성자가 호출
            // a.SetInterest(0.1);
            a.Balance++;
            // a.name = "이순신";
            a.Name = "이순신";
            a.Deposit(1000);
            a.Withdraw(500);
            a.Print();

            Account b = new Account(1, "홍길동");
            // b.SetInterest(0.2);
            b.Deposit(2000);
            if (!b.Withdraw(10000))
            {
                Console.WriteLine("잔액부족: " + b.Name);
            }
            
            b.Print();

            Account c = new Account(2, "김연아", 10000);
            c.Print();
            

            Account d = new Account(2, "김연아", 10000);
            if (c == d)
                Console.WriteLine("같다");
            else
                Console.WriteLine("다르다");
        }
    }
}
