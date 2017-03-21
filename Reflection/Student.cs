using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Dictionary<string, int> Grades { get; set; }

        public Student(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
            this.Grades = new Dictionary<string, int>();
        }
        public void AddGrade(string course, int grade)
        {
            this.Grades.Add(course,grade);
        }



    }
}
