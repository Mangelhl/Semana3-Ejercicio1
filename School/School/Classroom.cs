using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Classroom
    {
        private List<Student> students = new List<Student>();

        public List<Student> Students
        {
            get {return students;}
        }

        public void RegisterStudent(Student student)
        {
            students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(student);
        }

        public int CountApproved()
        {
            return students.Count(a => a.CalculateAverageTLS() >= 11.0);
        }

        public int CountDisapproved()
        {
            return students.Count(a => a.CalculateAverageTLS() < 11.0);
        }

        public List<Student> GetApproved()
        {
            return students.Where(a => a.CalculateAverageTLS() >= 11.0).ToList();
        }

        public List<Student> GetDisapproved()
        {
            return students.Where(a => a.CalculateAverageTLS() < 11.0).ToList();
        }

        public double CalculateGeneralAverage()
        {
            return students.Average(a => a.CalculateAverageTLS());
        }
    }
}
