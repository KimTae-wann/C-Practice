using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d1hw4
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee();
            Employee e2 = new Employee(1,"홍길동", "사장", 1000000);
            Employee e3 = new Employee(2,"박찬호");
            e1.Name = "이순신";
            e1.Display();
            e2.Display();
            e3.Display();
        }
    }
}
