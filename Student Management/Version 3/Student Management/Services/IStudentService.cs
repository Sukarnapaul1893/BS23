using Student_Management.Model;
using System;
using System.Collections.Generic;

namespace Student_Management.Services
{
    public interface IStudentService
    {
        void Create(Student student);
        void Update(Student student);
        void Delete(Student student);
        Student GetStudentById(string Id);
        IList<Student> GetAllStudents();
    }
}