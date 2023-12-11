using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace increment1forms
{
    internal class EducationalPlatform
    {
        private List<User> users;
        private List<Course> courses;
        public EducationalPlatform()
        {
            users = new List<User>();
            courses = new List<Course>();
        }
        public void addCourse(Course course)
        {
            courses.Add(course);
            return;
        }
    }
}
