/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d2hw1
{
    class SalesPerson : SalariedEmp
    {
        private int sales; // 판매량
        private int incentive; // 영업수당

        public SalesPerson (int id, string name, int salary, int sales, int incentive) : base(id, name, salary)
        {
            this.sales = sales;
            this.incentive = incentive;
        }

        public override int CalculatePay()
        {
            return Salary + (sales * incentive);
        }
    }
}
*/