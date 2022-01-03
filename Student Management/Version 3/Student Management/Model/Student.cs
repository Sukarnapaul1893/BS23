﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Student_Management.Model
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }

        public Student()
        {
            StudentCourses = new List<StudentCourse>();
        }

    }

}

