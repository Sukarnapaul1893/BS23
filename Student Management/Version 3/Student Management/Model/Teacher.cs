using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management.Model
{
    public class Teacher
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public ICollection<TeacherCourse> TeacherCourses { get; set; }

        public Teacher()
        {
            TeacherCourses = new List<TeacherCourse>();
        }

    }

}
