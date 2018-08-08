using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMPS.classes
{
    class Departments
    {
        private string departmentID;
        private string departmentName;

        public string DepartmentID
        {
            get { return departmentID; }
            set { departmentID = value; }
        }

        public string DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }
    }
}
