using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMPS.classes
{
    class PhilHealth
    {
        private string philHealthSalaryBracetNo;
        private decimal[] salaryRangeFrom;
        private decimal[] salaryRangeTo;
        private decimal[] salaryBase;
        private decimal[] employeeShare;
        private decimal[] employerShare;
        private decimal[] totalMonthlyPremium;
        public string PhilHealthSalaryBracetNo
        {
            get { return philHealthSalaryBracetNo; }
            set { philHealthSalaryBracetNo = value; }
        }
        public decimal[] SalaryRangeFrom
        {
            get { return salaryRangeFrom; }
            set { salaryRangeFrom = value; }
        }
        public decimal[] SalaryRangeTo
        {
            get { return salaryRangeTo; }
            set { salaryRangeTo = value; }
        }
        public decimal[] SalaryBase
        {
            get { return salaryBase; }
            set { salaryBase = value; }
        }
        public decimal[] EmployeeShare
        {
            get { return employeeShare; }
            set { employeeShare = value; }
        }
        public decimal[] EmployerShare
        {
            get { return employerShare; }
            set { employerShare = value; }
        }
        public decimal[] TotalMonthlyPremium
        {
            get { return totalMonthlyPremium; }
            set { totalMonthlyPremium = value; }
        }
    }
}
