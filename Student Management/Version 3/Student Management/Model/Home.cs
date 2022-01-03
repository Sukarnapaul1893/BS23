using Student_Management.Services;
using System;
using System.Collections.Generic;

namespace Student_Management.Model
{
    
    public class Home
    {
        public void Show()
        {

        _input:
            DisplayMessage("\t\t\t\tThis is HOME!!!");
            this.EndRefreshMessage();

            this.HomeDisplay();

            switch (Input())
            {
                case "r":
                    Console.Clear();
                    this.Show();
                    this.HomeDisplay();
                    break;
                case "e":
                    break;
                case "1":
                    this.CourseInput();
                    Console.Clear();
                    goto _input;
                    break;
                case "2":
                    this.StudentInput();
                    Console.Clear();
                    goto _input;
                    break;
                case "3":
                    this.TeacherInput();
                    Console.Clear();
                    goto _input;
                    break;
                case "4":
                    this.CourseOutput();
                    this.Show();
                    break;
                case "5":
                    this.StudentOutput();
                    this.Show();
                    break;
                case "6":
                    this.TeacherOutput();
                    this.Show();
                    break;
                case "7":
                    this.StudentCourseInput();
                    Console.Clear();
                    goto _input;
                    break;
                case "8":
                    this.StudentCourseOutput();
                    this.Show();
                    break;
                case "9":
                    this.TeacherCourseInput();
                    Console.Clear();
                    goto _input;
                    break;
                case "10":
                    this.TeacherCourseOutput();
                    this.Show();
                    break;
                case "11":
                    this.LogIn();
                    break;
                default:
                    Console.Clear();
                    DisplayMessage("Insert an valid input");
                    goto _input;
            }
        }

        public void HomeDisplay()
        {
            DisplayMessage("Enter corresponding integer of what you want to do!!!");

            DisplayMessage("1.  Insert Course" , "2.  Insert Student", "3.  Insert Teacher");
            DisplayMessage("4.  See Course List" , "5.  See Student List" , "6.  See Teacher List");
            DisplayMessage("7.  Insert Student-Course" , "8.  Student-Course Output");
            DisplayMessage("9.  Insert Teacher-Course" , "10. Teacher-Course Output");
            DisplayMessage("11. Account LogIn");
        }

        public void EndRefreshMessage()
        {
            DisplayMessage("Enter e to end the program");
            DisplayMessage("Enter r to refresh the program");
        }

        public void CourseInput()
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

                var _course = new CourseService();
                _course.Create(course);

                courseCounter++;
            }

        }

        public void StudentInput()
        {
            int studentCounter = 0;

            while (true)
            {
                if (studentCounter > 0)
                {
                    DisplayMessage("Do you want to enter more student entry : 1 for YES or 2 for NO?");
                    string ss = Input();
                    if (ss == "2") break;
                }

                DisplayMessage("Enter the Student's ID:");
                string id = Input();
                DisplayMessage("Enter the Student's Name:");
                string name = Input();
                DisplayMessage("Enter the Student's Password:");
                string password = Input();

                Student student = new Student()
                {
                    Id = id,
                    Name = name,
                    Password = password
                };

                var studentService = new StudentService();
                studentService.Create(student);

                studentCounter++;
            }

        }

        public void TeacherInput()
        {
            int teacherCounter = 0;

            while (true)
            {
                if (teacherCounter > 0)
                {
                    DisplayMessage("Do you want to enter more teacher entry : 1 for YES or 2 for NO?");
                    if (Input() == "2") break;
                }

                DisplayMessage("Enter the Teacher's ID:");
                string id = Input();
                DisplayMessage("Enter the Teacher's Name:");
                string name = Input();
                DisplayMessage("Enter the Teacher's Phone:");
                string phone = Input();
                DisplayMessage("Enter the Teacher's Address:");
                string address = Input();
                DisplayMessage("Enter the Teacher's Password:");
                string password = Input();

                Teacher teacher = new Teacher()
                {
                    Id = id,
                    Name = name,
                    Phone = phone,
                    Address = address,
                    Password = password
                };

                var teacherService = new TeacherService();
                teacherService.Create(teacher);

                teacherCounter++;
            }

        }

        public void CourseOutput()
        {
            int counter = 1;

            var courseService  = new CourseService();
            var courseList = courseService.GetAllCourses();


            foreach (var course in courseList)
            {
                DisplayMessage(counter++);
                DisplayMessage("ID: ",course.Id, "Title: ", course.Title);
            }
        }

        public void StudentOutput()
        {
            int counter = 1;

            var studentService  = new StudentService();
            var studentList = studentService.GetAllStudents();

            foreach (var student in studentList) 
            {
                DisplayMessage(counter++);
                MyDetails(student);
            }
        }

        public void TeacherOutput()
        {
            int counter = 1;

            var teacherService = new TeacherService();
            var teacherList = teacherService.GetAllTeachers();

            foreach (var teacher in teacherList)
            {
                DisplayMessage(counter++);
                MyDetails(teacher);
            }
        }

        public void StudentCourseInput()
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

                InputIsHere:
                DisplayMessage("Enter Course ID:");
                string courseID = Input();
                DisplayMessage("Enter Student ID:");
                string studentID = Input();

                if(!(CheckValidStudent(studentID) && CheckValidCourse(courseID)))
                {
                    DisplayMessage("Enter valid input");
                    goto InputIsHere;
                }
                
                StudentCourse studentCourse = new StudentCourse()
                {
                    StudentId = studentID,
                    CourseId = courseID
                };

                studentCourseCounter++;
                
                var student = GetStudentById(studentID);
                                
                DisplayMessage(student.Id);
                student.StudentCourses.Add(studentCourse);


            }
        }
        
        public void TeacherCourseInput()
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

            InputIsHere:
                DisplayMessage("Enter Course ID:");
                string courseID = Input();
                DisplayMessage("Enter Teacher ID:");
                string teacherID = Input();

                if (!(CheckValidTeacher(teacherID) && CheckValidCourse(courseID)))
                {
                    DisplayMessage("Enter valid input");
                    goto InputIsHere;
                }

                TeacherCourse teacherCourse = new TeacherCourse()
                {
                    TeacherId = teacherID,
                    CourseId = courseID
                };

                teacherCourseCounter++;
                var _teacherService = new TeacherService();
                var _courseService = new CourseService();

                var teacher = _teacherService.GetTeacherById(teacherID);

                DisplayMessage(teacher.Id);
                teacher.TeacherCourses.Add(teacherCourse);


            }
        }

        public void StudentCourseOutput()
        {
            Console.Clear();
            DisplayMessage("1.   Know about a particular student");
            DisplayMessage("2.   Know about a particular course");


            if (Input() == "1")
            {
                DisplayMessage("Enter the student id");
                string studentId = Input();

                StudentService studentService = new StudentService();

                var student = studentService.GetStudentById(studentId);

                var courseList = student.StudentCourses;

                DisplayMessage("Taken courses are:");

                foreach (var li in courseList)
                {
                    DisplayMessage(li.CourseId);
                }

            }
            else
            {
                DisplayMessage("Enter the course id");
                string courseId = Input();

                CourseService courseService = new CourseService();

                var course = courseService.GetCourseById(courseId);

                var studentList = course.StudentCourses;

                DisplayMessage("Students under this course are:");

                foreach (var li in studentList)
                {
                    DisplayMessage(li.CourseId);
                }
            }



        }
        
        public void TeacherCourseOutput()
        {
            Console.Clear();
            DisplayMessage("1.   Know about a particular teacher");
            DisplayMessage("2.   Know about a particular course");


            if (Input() == "1")
            {
                DisplayMessage("Enter the teacher id");
                string teacherId = Input();

                TeacherService teacherService = new TeacherService();

                var teacher = teacherService.GetTeacherById(teacherId);

                var courseList = teacher.TeacherCourses;

                DisplayMessage("Taken courses are:");

                foreach (var li in courseList)
                {
                    DisplayMessage(li.CourseId);
                }

            }
            else
            {
                DisplayMessage("Enter the course id");
                string courseId = Input();

                CourseService courseService = new CourseService();

                var course = courseService.GetCourseById(courseId);

                var teacherList = course.TeacherCourses;

                DisplayMessage("Teachers taking this course are:");

                foreach (var li in teacherList)
                {
                    DisplayMessage(li.TeacherId);
                }
            }



        }
        
        public static bool CheckValidStudent(string studentId)
        {
            try
            {
                var x = GetStudentById(studentId);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        public static bool CheckValidTeacher(string teacherId)
        {
            try
            {
                var x = GetTeacherById(teacherId);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        public static bool CheckValidCourse(string courseId)
        {
            try
            {
                var courseService = new CourseService();
                var x = courseService.GetCourseById(courseId);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        

        public static bool CheckPassword(Student student, string inputPassword)
        {
            if (student.Password == inputPassword) return true;
            else                                   return false;   
        }
        
        public static bool CheckPassword(Teacher teacher, string inputPassword)
        {
            if (teacher.Password == inputPassword) return true;
            else                                   return false;   
        }
        public void LogIn()
        {
        InputAgain:

            DisplayMessage("Enter 1 if you are a teacher");
            DisplayMessage("Enter 2 if you are a student");
            
            string status = Input();
            Console.Clear();

            
            DisplayMessage("Enter your id");
            string logInId = Input();

            DisplayMessage("Enter your password");
            string logInPassword = Input();

            if(status == "1")
            {
                if (!CheckValidTeacher(logInId))
                {
                    DisplayMessage("Invalid Id. Try again!");
                    goto InputAgain;
                }



                var teacherService = new TeacherService();
                var teacherList = teacherService.GetAllTeachers();

                var teacher = teacherList.FirstOrDefault(x => x.Id == logInId);
                
                if(!CheckPassword(teacher, logInPassword))
                {
                    DisplayMessage("Invalid Password. Try again!");
                    goto InputAgain;
                }

                MyDetails(teacher);
                MyCourseList(teacher);
            }
            else if(status == "2")
            {
                if (!CheckValidStudent(logInId))
                {
                    DisplayMessage("Invalid Id. Try again!");
                    goto InputAgain;
                }

                var studentService = new StudentService();
                var studentList = studentService.GetAllStudents();

                var student = studentList.FirstOrDefault(x => x.Id == logInId);

                if (!CheckPassword(student, logInPassword))
                {
                    DisplayMessage("Invalid Password. Try again!");
                    goto InputAgain;
                }

                MyDetails(student);
                MyCourseList(student);
            }
            else
            {
                DisplayMessage("Invalid Input. Try again!");
                goto InputAgain;
            }
            
        }

        public void MyDetails(Teacher teacher)
        {
            DisplayMessage("Personal Information:");
            DisplayMessage("Id: " + teacher.Id);
            DisplayMessage("Name: " + teacher.Name);
            DisplayMessage("Phone: " + teacher.Phone);
            DisplayMessage("Address: " + teacher.Address);
        }
        public void MyDetails(Student student)
        {
            DisplayMessage("Personal Information:");
            DisplayMessage("Id: " + student.Id);
            DisplayMessage("Name: " + student.Name);
        }

        public void MyCourseList(Teacher teacher)
        {
            var courseList = teacher.TeacherCourses;

            DisplayMessage("Courses you take are:");

            foreach (var li in courseList)
            {
                DisplayMessage(li.CourseId);
            }
        }
        public void MyCourseList(Student student)
        {
            var courseList = student.StudentCourses;

            DisplayMessage("Taken courses are:");

            foreach (var li in courseList)
            {
                DisplayMessage(li.CourseId);
            }
        }
    
        public string Input()
        {
            return Console.ReadLine();
        }
        
        public void DisplayMessage(params string[] message)
        {
            foreach(var str in message)Console.WriteLine(str);
        }
        public void DisplayMessage(int message)
        {
            Console.WriteLine("{0}",message);
        }
    
        public static Student GetStudentById(string studentId)
        {
            var studentService = new StudentService();
            var x = studentService.GetStudentById(studentId);
            return x;
        }
        
        public static Teacher GetTeacherById(string teacherId)
        {
            var teacherService = new TeacherService();
            var x = teacherService.GetTeacherById(teacherId);
            return x;
        }
        
        public static Course GetCourseById(string courseId)
        {
            var courseService = new CourseService();
            var x = courseService.GetCourseById(courseId);
            return x;
        }
    }
}
