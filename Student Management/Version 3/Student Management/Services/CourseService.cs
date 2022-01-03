using Student_Management.Model;
using System;
using System.Collections.Generic;

namespace Student_Management.Services
{
    public class CourseService : ICourseService
    {
        private static List<Course> courses = new List<Course>();
        private readonly UtilityService _utilityService;

        public CourseService()
        {
            _utilityService = new();
        }
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
        
        public void CourseInput()
        {
            int courseCounter = 0;

            while (true)
            {
                if (courseCounter > 0)
                {
                    _utilityService.DisplayMessage("Do you want to enter more course : 1 for YES ; 2 for NO?");
                    if (_utilityService.Input() == "2") break;
                }

                _utilityService.DisplayMessage("Enter the Course ID:");
                string id = _utilityService.Input();
                _utilityService.DisplayMessage("Enter the Course Title:");
                string title = _utilityService.Input();

                var course = new Course()
                {
                    Id = id,
                    Title = title,
                };
                Create(course);
                courseCounter++;
            }
        }
        
    }
}