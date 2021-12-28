using System;
using System.Collections.Generic;



public class Program
{

    public static void Main()
    {
        DisplayMessage("Enter Course Info:\n");
        //Console.WriteLine("\x1b[36mTEST\x1b[0m");

        CourseInput();
        CourseOutput();

        StudentInput();
        StudentOutput();

        StudentCourseInput();
        StudentCourseOutput();

        TeacherInput();
        TeacherOutput();

        TeacherCourseInput();
        TeacherCourseOutput();

    }

    public static void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    public static string Input()
    {
        return Console.ReadLine();
    }
    public static bool CheckValidStudentCourse(string studentId, string courseId)
    {
        try
        {
            StudentService.StudentService studentService = new StudentService.StudentService();
            var x = studentService.GetStudentById(studentId);

            CourseService.CourseService courseService = new CourseService.CourseService();
            var y = courseService.GetCourseById(courseId);
        }
        catch (Exception ex)
        {
            return false;
        }
        
        return true;
    }
    
    public static bool CheckValidTeacherCourse(string teacherId, string courseId)
    {
        try
        {
            TeacherService.TeacherService teacherService = new TeacherService.TeacherService();
            var x = teacherService.GetTeacherById(teacherId);

            CourseService.CourseService courseService = new CourseService.CourseService();
            var y = courseService.GetCourseById(courseId);
        }
        
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }
    public static void CourseInput()
    {
        int courseCounter = 0;

        while (true)
        {
            if (courseCounter > 0)
            {
                DisplayMessage("Do you want to enter more course : 1 for YES ; 2 for NO?");
                if (Input() == "2") break;
            }

            DisplayMessage("Enter the Course ID:");
            string id = Input();
            DisplayMessage("Enter the Course Title:");
            string title = Input();

            var course = new Course()
            {
                Id = id,
                Title = title,
            };

            CourseService.CourseService _course = new CourseService.CourseService();
            _course.Create(course);

            courseCounter++;

     
        }

    }

    public static void StudentInput()
    {
        int studentCounter = 0;

        while (true)
        {
            if (studentCounter > 0)
            {
                DisplayMessage("Do you want to enter more course : 1 for YES or 2 for NO?");
                string ss = Input();
                if (ss == "2") break;
            }

            DisplayMessage("Enter the Student ID:");
            string id = Input();
            DisplayMessage("Enter the Student Name:");
            string name = Input();

            Student student = new Student()
            {
                Id = id,
                Name = name,
            };

            StudentService.StudentService _student = new StudentService.StudentService();
            _student.Create(student);

            studentCounter++;
        }

    }

    public static void TeacherInput()
    {
        int teacherCounter = 0;

        while (true)
        {
            if (teacherCounter > 0)
            {
                DisplayMessage("Do you want to enter more course : 1 for YES or 2 for NO?");
                if (Input() == "2") break;
            }

            DisplayMessage("Enter the Teacher ID:");
            string id = Input();
            DisplayMessage("Enter the Teacher Name:");
            string name = Input();

            Teacher teacher = new Teacher()
            {
                Id = id,
                Name = name,
            };

            TeacherService.TeacherService _teacher = new TeacherService.TeacherService();
            _teacher.Create(teacher);

            teacherCounter++;
        }

    }

    

    public static void CourseOutput()
    {
        int counter = 1;

        CourseService.CourseService _course = new CourseService.CourseService();
        var courseList = _course.GetAllCourses();


        foreach (var course in courseList)
        {
            Console.WriteLine(counter++);
            Console.WriteLine("ID = {0} \t Title = {1}", course.Id, course.Title);
        }
    }

    public static void StudentOutput()
    {
        int counter = 1;

        StudentService.StudentService _student = new StudentService.StudentService();
        var studentList = _student.GetAllStudents();

        foreach (var student in studentList)
        {
            Console.WriteLine(counter++);
            Console.WriteLine("ID = {0} \t Name = {1}", student.Id, student.Name);
        }
    }
    
    public static void TeacherOutput()
    {
        int counter = 1;

        TeacherService.TeacherService _teacher = new TeacherService.TeacherService();
        var teacherList = _teacher.GetAllTeachers();

        foreach (var teacher in teacherList)
        {
            Console.WriteLine("{0}",counter++);
            Console.WriteLine("ID = {0} \t Name = {1}", teacher.Id, teacher.Name);
        }
    }

    

    public static void StudentCourseInput()
    {
        DisplayMessage("This is student-course assignment");

        int studentCourseCounter = 0;

        while (true)
        {
            if (studentCourseCounter > 0)
            {
                DisplayMessage("Do you want to enter more student-course : 1 for YES or 2 for NO?");
                
                if (Input() == "2") break;
            }

            DisplayMessage("Enter Course ID:");
            string courseID = Input();
            DisplayMessage("Enter Student ID:");
            string studentID = Input();

            if (!CheckValidStudentCourse(studentID, courseID))
            {
                DisplayMessage("Sorry! This is not valid. Please try again");
                continue;
            };

            StudentCourse studentCourse = new StudentCourse()
            {
                StudentId = studentID,
                CourseId = courseID
            };

            studentCourseCounter++;
            StudentCourseService.StudentCourseService _studentCourse = new StudentCourseService.StudentCourseService();
            _studentCourse.Create(studentCourse);
        }
    }
    
    public static void TeacherCourseInput()
    {
        DisplayMessage("This is teacher-course assignment");

        int teacherCourseCounter = 0;

        while (true)
        {
            if (teacherCourseCounter > 0)
            {
                DisplayMessage("Do you want to enter more teacher-course : 1 for YES or 2 for NO?");
                
                if (Input() == "2") break;
            }

            DisplayMessage("Enter Course ID:");
            string courseID = Input();
            DisplayMessage("Enter Student ID:");
            string teacherID = Input();

            if (!CheckValidTeacherCourse(teacherID, courseID))
            {
                DisplayMessage("Sorry! This is not valid. Please try again");
                continue;
            };

            TeacherCourse teacherCourse = new TeacherCourse()
            {
                TeacherId = teacherID,
                CourseId = courseID
            };

            teacherCourseCounter++;
            TeacherCourseService.TeacherCourseService _teacherCourse = new TeacherCourseService.TeacherCourseService();
            _teacherCourse.Create(teacherCourse);
        }
    }

    public static void StudentCourseOutput()
    {
        int counter = 1;

        StudentService.StudentService student = new StudentService.StudentService();
        var studentList = student.GetAllStudents();

        StudentCourseService.StudentCourseService studentCourse = new StudentCourseService.StudentCourseService();
        var studentCourseList = studentCourse.GetAllStudentCourses();

        var res = from _student in studentList
                  join _studentCourse in studentCourseList
                   on _student.Id equals _studentCourse.StudentId
                  select new
                  {
                      studentId = _student.Id,
                      courseId = _studentCourse.CourseId,
                      studentName = _student.Name
                  };

        string previousStudentId = "";
        DisplayMessage("");

        

        Course _course;

        foreach (var _element in res)
        {
            if (_element.studentId != previousStudentId)
            {
                Console.WriteLine("\x1b[36mStudent ID = {0}\x1b[0m", _element?.studentId);
                Console.WriteLine("\x1b[36mStudent Name = {0}\x1b[0m", _element?.studentName);
                DisplayMessage("");
            }

            Console.WriteLine("Course ID = {0}", _element?.courseId);
            
            CourseService.CourseService courseService = new CourseService.CourseService();
            var courseList = courseService.GetAllCourses();
            
            
            _course = courseList.FirstOrDefault(_course => _course?.Id == _element?.courseId);
            Console.WriteLine("Course Title = {0}\n", _course?.Title);


            previousStudentId = _element?.studentId;
        }


        /*foreach (var sc in StudentCourses)
        {
            student = studentList.FirstOrDefault(sid => sid.Id == sc.studentId);
            course = courseList.FirstOrDefault(cid => cid.Id == sc.courseId);

            Console.WriteLine(counter++);
            Console.WriteLine("studentID = {0} \t studentName = {1} \t courseID = {2} \t courseTitle = {3}", student?.Id, student?.Name, course?.Id, course?.Title);
        }*/
    }
    
    public static void TeacherCourseOutput()
    {
        int counter = 1;

        TeacherService.TeacherService teacher = new TeacherService.TeacherService();
        var teacherList = teacher.GetAllTeachers();

        TeacherCourseService.TeacherCourseService teacherCourse = new TeacherCourseService.TeacherCourseService();
        var teacherCourseList = teacherCourse.GetAllTeacherCourses();

        var res = from _teacher in teacherList
                  join _teacherCourse in teacherCourseList
                   on _teacher.Id equals _teacherCourse.TeacherId
                  select new
                  {
                      teacherId = _teacher.Id,
                      courseId = _teacherCourse.CourseId,
                      teacherName = _teacher.Name
                  };

        string previousTeacherId = "";
        DisplayMessage("");

        

        Course _course;

        foreach (var _element in res)
        {
            if (_element.teacherId != previousTeacherId)
            {
                Console.WriteLine("\x1b[36mStudent ID = {0}\x1b[0m", _element?.teacherId);
                Console.WriteLine("\x1b[36mStudent Name = {0}\x1b[0m", _element?.teacherName);
                DisplayMessage("");
            }

            Console.WriteLine("Course ID = {0}", _element?.courseId);
            
            CourseService.CourseService courseService = new CourseService.CourseService();
            var courseList = courseService.GetAllCourses();
            
            
            _course = courseList.FirstOrDefault(_course => _course?.Id == _element?.courseId);
            Console.WriteLine("Course Title = {0}\n", _course?.Title);


            previousTeacherId = _element?.teacherId;
        }


        /*foreach (var sc in StudentCourses)
        {
            student = studentList.FirstOrDefault(sid => sid.Id == sc.studentId);
            course = courseList.FirstOrDefault(cid => cid.Id == sc.courseId);

            Console.WriteLine(counter++);
            Console.WriteLine("studentID = {0} \t studentName = {1} \t courseID = {2} \t courseTitle = {3}", student?.Id, student?.Name, course?.Id, course?.Title);
        }*/
    }
    
    
}

