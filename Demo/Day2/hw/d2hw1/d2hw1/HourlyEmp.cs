/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d2hw1
{
    class HourlyEmp : Employee
    {
        private int payPerHour; // 시간당 수당
        private int hours; // 시간수
        public HourlyEmp(int id, string name, int payPerHour, int hours) : base(id, name) {
            this.payPerHour = payPerHour;
            this.hours = hours;
        }

        public override int CalculatePay()
        {
            return payPerHour * hours;
        }

    }
}
*/