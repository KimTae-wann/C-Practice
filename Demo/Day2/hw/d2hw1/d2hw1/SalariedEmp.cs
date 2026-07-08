/*using System;
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
}
*/