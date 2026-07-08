using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5Class
{
    // internal
    class Account
    { // attribute - data
        private readonly int accNo;
        // private string name;
        private long balance; // 잔액

        // Auto-Property 자동 구현 속성
        public string Name
        {
            get;
            set;
        }
        
        // Property 속성
        /*public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value; // value 는 키워드임.
            }
        }*/

        public long Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }

        // public int AccNo => accNo;
        public int AccNo
        {
            get { return accNo; }
            // set { accNo = value; } // readonly 는 set 못쓴다.
        }

        // ** 디폴트 생성자는 생성자를 안썼을 때만 제공한다 **
        public Account ()
        {
            accNo = 0;
            Name = "";
            balance = 0;
        }
 
        public Account(int accNo, string name)
        {
            this.accNo = accNo;
            this.Name = name;
        }

        public Account(int accNo, string name, long balance)
        {
            this.accNo = accNo;
            this.Name = name;
            this.balance = balance;
        }

        // behavior
        public void Deposit(long balance)
        {
            this.balance += balance;
        }

        public bool Withdraw(long a)
        {
            if (a <= balance)
            {
                balance -= a;
                return true;
            }
            return false;
        }
        public void Print()
        {
            Console.WriteLine($"계좌번호:{accNo}\t이름:{name}\t잔액:{balance}");
        }
    }
}
