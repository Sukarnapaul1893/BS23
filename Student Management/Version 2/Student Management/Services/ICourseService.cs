using System;
using System.Collections.Generic;

namespace CourseService
{
    public interface ICourseService
    {
        void Create(Course course);
        void Update(Course course);
        void Delete(Course course);

        Course GetCourseById(string Id);

        IList<Course> GetAllCourses();
    }
}