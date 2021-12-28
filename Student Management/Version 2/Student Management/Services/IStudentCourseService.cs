using System;
using System.Collections.Generic;

namespace StudentCourseService
{
    public interface IStudentCourseService
    {
        void Create(StudentCourse studentCourse);
        void Delete(StudentCourse studentCourse);
        IList<StudentCourse> GetAllStudentCourses();
    }
}