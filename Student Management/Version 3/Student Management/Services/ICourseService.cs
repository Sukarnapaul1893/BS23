using Student_Management.Model;
using System;
using System.Collections.Generic;

namespace Student_Management.Services
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