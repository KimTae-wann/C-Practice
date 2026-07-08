using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d1hw4
{
    class Employee
    {
        private int no; // 사번
        private string name; // 이름
        private string title; // 직급
        private long salary; // 연봉

       public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }

        public Employee()
        {
            this.no = 0;
            this.name = "";
            this.title = "";
            this.salary = 0;
        }

        public Employee(int no, string name)
        {
            this.no = no;
            this.name = name;
            this.title = "";
            this.salary = 0;
        }

        public Employee(int no, string name, string title, long salary)
        {
            this.no = no;
            this.name = name;
            this.title = title;
            this.salary = salary;
        }

        public void Display()
        {
            Console.WriteLine($"사번:{no}\t이름:{name}\t직급:{title, -4}\t연봉:{salary}");
        }

        public long CalculatePay()
        {
            return this.salary;
        }
    }
}
