using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management.Model
{
    public class Course: BaseModel
    {
      
        public string Title { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<TeacherCourse> TeacherCourses { get; set; }

        public Course()
        {
            StudentCourses = new List<StudentCourse>();
            TeacherCourses = new List<TeacherCourse>();
        }

    }

}