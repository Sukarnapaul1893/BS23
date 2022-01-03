using Student_Management.Model;
using System;
using System.Collections.Generic;

namespace Student_Management.Services
{
    public class TeacherService : ITeacherService
    {
        private static List<Teacher> teachers = new List<Teacher>();

        public void Create(Teacher teacher)
        {
            teachers.Add(teacher);
        }

        public void Update(Teacher teacher)
        {
            var existingTeacher = teachers.Find(x => x.Id == teacher.Id);
            existingTeacher.Name = teacher.Name;
            existingTeacher.TeacherCourses = teacher.TeacherCourses;
        }

        public void Delete(Teacher teacher)
        {
            teachers.Remove(teacher);
        }

        public IList<Teacher> GetAllTeachers()
        {
            return teachers;
        }

        public Teacher GetTeacherById(string Id) => teachers.FirstOrDefault(x => x.Id == Id);

    }
}