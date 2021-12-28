using System;
using System.Collections.Generic;

namespace TeacherCourseService
{
    public interface ITeacherCourseService
    {
        void Create(TeacherCourse teacherCourse);
        void Delete(TeacherCourse teacherCourse);

        IList<TeacherCourse> GetAllTeacherCourses();
    }
}