using System;
using System.Collections.Generic;

namespace TeacherService
{
    public interface ITeacherService
    {
        void Create(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(Teacher teacher);

        Teacher GetTeacherById(string Id);

        IList<Teacher> GetAllTeachers();
    }
}