using System;
using System.Collections.Generic;

namespace CourseService
{
    public class CourseService : ICourseService
    {
        private static List<Course> courses = new List<Course>();

        public void Create(Course course)
        {
            courses.Add(course);
        }

        public void Update(Course course)
        {
            var existingStudent = courses.Find(x => x.Id == course.Id);
            existingStudent.Title = course.Title;
        }

        public void Delete(Course course)
        {
            courses.Remove(course);
        }

        public IList<Course> GetAllCourses()
        {
            return courses;
        }

        public Course GetCourseById(string Id)
        {
            return courses.Find(x => x.Id == Id);
        }
    }
}