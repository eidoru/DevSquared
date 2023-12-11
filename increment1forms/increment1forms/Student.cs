using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace increment1forms
{
    internal class Student : User
    {
        private List<Course> enrolledCourses;
        public Student()
        {
            enrolledCourses = new List<Course>();
        }
    }
}
