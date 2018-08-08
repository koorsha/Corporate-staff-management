using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMPS.classes
{
    class SSS
    {
        private string sSSSalaryBracetNo;
        private decimal[] salaryRangeFrom;
        private decimal[] salaryRangeTo;
        private decimal[] salaryBase;
        private decimal[] socialSecurityEmployeeShare;
        private decimal[] socialSecurityEmployerShare;
        private decimal[] socialSecurityTotal;
        private decimal[] employerShare;
        private decimal[] totalContributionEmployeeShare;
        private decimal[] totalContributionEmployerShare;
        private decimal[] totalContribution;
        private decimal[] totalContributionForSEVMOFW;
        public string SSSSalaryBracetNo
        {
            get { return sSSSalaryBracetNo; }
            set { sSSSalaryBracetNo = value; }
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
        public decimal[] SocialSecurityEmployeeShare
        {
            get { return socialSecurityEmployeeShare; }
            set { socialSecurityEmployeeShare = value; }
        }
        public decimal[] SocialSecurityEmployerShare
        {
            get { return socialSecurityEmployerShare; }
            set { socialSecurityEmployerShare = value; }
        }
        public decimal[] SocialSecurityTotal
        {
            get { return socialSecurityTotal; }
            set { socialSecurityTotal = value; }
        }
        public decimal[] EmployerShare
        {
            get { return employerShare; }
            set { employerShare = value; }
        }

        public decimal[] TotalContributionEmployeeShare
        {
            get { return totalContributionEmployeeShare; }
            set { totalContributionEmployeeShare = value; }
        }
        public decimal[] TotalContributionEmployerShare
        {
            get { return totalContributionEmployerShare; }
            set { totalContributionEmployerShare = value; }
        }
        public decimal[] TotalContribution
        {
            get { return totalContribution; }
            set { totalContribution = value; }
        }
        public decimal[] TotalContributionForSEVMOFW
        {
            get { return totalContributionForSEVMOFW; }
            set { totalContributionForSEVMOFW = value; }
        }
    }
}
