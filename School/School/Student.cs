using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Student
    {
        public string Name;
        public double Note1;
        public double Note2;
        public double Note3;

        public double CalculateAverageTLS()
        {
            return (Note1 + Note2 + Note3) / 3.0;
        }
    }
}
