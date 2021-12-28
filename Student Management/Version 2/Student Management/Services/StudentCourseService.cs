using System;
using System.Collections.Generic;

namespace StudentCourseService
{
    public class StudentCourseService : IStudentCourseService
    {
        private static List<StudentCourse> studentCourses = new List<StudentCourse>();

        public void Create(StudentCourse studentCourse)
        {
            studentCourses.Add(studentCourse);
        }

        public void Delete(StudentCourse studentCourse)
        {
            studentCourses.Remove(studentCourse);
        }

        public IList<StudentCourse> GetAllStudentCourses()
        {
            return studentCourses;
        }      

    }
}