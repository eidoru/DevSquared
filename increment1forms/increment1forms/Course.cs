using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace increment1forms
{
    internal class Course
    {
        private String name;
        private String description;
        private List<User> enrolledStudents;
        private List<Lesson> lessons;
        public Course(String name)
        {
            this.name = name;
            enrolledStudents = new List<User>();
            lessons = new List<Lesson>();
        }
        public void addStudent(Student student)
        {
            enrolledStudents.Add(student);
            return;
        }
        public void addLesson(Lesson lesson)
        {
            lessons.Add(lesson);
            return;
        }
    }
}
