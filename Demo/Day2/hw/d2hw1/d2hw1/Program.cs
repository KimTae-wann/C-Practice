using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d2hw1
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] em = new Employee[3];
            em[0] = new SalariedEmp(1, "박찬호", 1000000);
            em[1] = new HourlyEmp(2, "홍길동", 40, 5000); //일한시간수, 시간당 받는 수당
            em[2] = new SalesPerson(3, "이순신", 1000000, 10, 20000); //월급  판매량 영업수당  //<==
            foreach (Employee e in em)
                e.Print(); 

        }
    }
}
