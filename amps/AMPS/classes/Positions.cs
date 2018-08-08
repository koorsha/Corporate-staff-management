using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMPS.classes
{
    class Positions
    {
        private string positionID;
        private string positionName;
        private int salary;
        private Departments departments;
        public Positions()
        {
            departments = new Departments();
        }
        public Departments Department
        {
            get { return departments; }
            set { departments = value; }
        }
        public string PositionID
        {
            get { return positionID; }
            set { positionID = value; }
        }

        public string PositionName
        {
            get { return positionName; }
            set { positionName = value; }
        }
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }
    }
}
