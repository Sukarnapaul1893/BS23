using System;
using System.Collections.Generic;

namespace StudentService
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new List<Student>();
        
        public void Create(Student student)
        {
            students.Add(student);
        }

        public void Update(Student student)
        {
            var existingStudent = students.Find(x => x.Id == student.Id);
            existingStudent.Name = student.Name;
        }

        public void Delete(Student student)
        {
            students.Remove(student);
        }

        public IList<Student> GetAllStudents()
        {
            return students;
        }

        public Student GetStudentById(string Id)
        {
            return students.Find(x => x.Id == Id);
        }
    }
}