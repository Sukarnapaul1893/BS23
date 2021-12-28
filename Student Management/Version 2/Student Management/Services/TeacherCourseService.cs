using System;
using System.Collections.Generic;

namespace TeacherCourseService
{
    public class TeacherCourseService : ITeacherCourseService
    {
        private static List<TeacherCourse> teacherCourses = new List<TeacherCourse>();

        public void Create(TeacherCourse teacherCourse)
        {
            teacherCourses.Add(teacherCourse);
        }

        public void Delete(TeacherCourse teacherCourse)
        {
            teacherCourses.Remove(teacherCourse);
        }

        public IList<TeacherCourse> GetAllTeacherCourses()
        {
            return teacherCourses;
        }

    }
}