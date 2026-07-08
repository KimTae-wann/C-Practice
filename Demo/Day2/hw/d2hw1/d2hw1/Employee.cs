using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d2hw1
{
    class SalariedEmp : Employee
    {
        //private int salary; // 월급

        protected int Salary { get; set; } // 월급

        public SalariedEmp(int id, string name, int salary) : base(id, name)
        {
            Salary = salary;
        }

        public override int CalculatePay()
        {
            return Salary;
        }
    }

    class SalesPerson : SalariedEmp
    {
        private int sales; // 판매량
        private int incentive; // 영업수당

        public SalesPerson(int id, string name, int salary, int sales, int incentive) : base(id, name, salary)
        {
            this.sales = sales;
            this.incentive = incentive;
        }

        public override int CalculatePay()
        {
            return Salary + (sales * incentive);
        }
    }

    class HourlyEmp : Employee
    {
        private int payPerHour; // 시간당 수당
        private int hours; // 시간수
        public HourlyEmp(int id, string name, int payPerHour, int hours) : base(id, name)
        {
            this.payPerHour = payPerHour;
            this.hours = hours;
        }

        public override int CalculatePay()
        {
            return payPerHour * hours;
        }

    }
    class Employee
    {
        private int id; // ID
        private string name; // 이름
        
        public Employee(int i, string n)
        {
            id = i;
            name = n;
        }
        public void Print()
        {
            Console.WriteLine($"ID:{id}\tName:{name}\t급여:{CalculatePay()}");
        }
        public virtual int CalculatePay()
        {
            return 0;
        }
    }
}
