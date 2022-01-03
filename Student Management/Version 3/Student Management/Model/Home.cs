using Student_Management.Services;

namespace Student_Management.Model
{
    public class Home
    {
        private readonly HelperService _helperService;
        private readonly UtilityService _utilityService;
        private readonly CourseService _courseService;
        private readonly StudentService _studentService;
        private readonly TeacherService _teacherService;

        public Home()
        {
            _helperService = new();
            _utilityService = new();
            _courseService = new();
            _studentService = new();
            _teacherService = new();
        }

        public void Show()
        {
            _input:
            _utilityService.DisplayMessage("\t\t\t\tThis is HOME!!!");
            this.EndRefreshMessage();

            _helperService.HomeDisplay();

            switch (_utilityService.Input())
            {
                case "r":
                    Console.Clear();
                    this.Show();
                    _helperService.HomeDisplay();
                    break;
                case "e":
                    break;
                case "1":
                    _courseService.CourseInput();
                    Console.Clear();
                    goto _input;
                    break;
                case "2":
                    _studentService.StudentInput();
                    Console.Clear();
                    goto _input;
                    break;
                case "3":
                    _teacherService.TeacherInput();
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
                    _utilityService.DisplayMessage("Insert an valid input");
                    goto _input;
            }
        }


        private void EndRefreshMessage()
        {
            _utilityService.DisplayMessage("Enter e to end the program");
            _utilityService.DisplayMessage("Enter r to refresh the program");
        }

        public void CourseOutput()
        {
            int counter = 1;

            var courseService = new CourseService();
            var courseList = courseService.GetAllCourses();


            foreach (var course in courseList)
            {
                _utilityService.DisplayMessage(counter++);
                _utilityService.DisplayMessage("ID: ", course.Id, "Title: ", course.Title);
            }
        }

        public void StudentOutput()
        {
            int counter = 1;

            var studentService = new StudentService();
            var studentList = studentService.GetAllStudents();

            foreach (var student in studentList)
            {
                _utilityService.DisplayMessage(counter++);
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
                _utilityService.DisplayMessage(counter++);
                MyDetails(teacher);
            }
        }

        public void StudentCourseInput()
        {
            _utilityService.DisplayMessage("This is student-course assignment");

            int studentCourseCounter = 0;

            while (true)
            {
                if (studentCourseCounter > 0)
                {
                    _utilityService.DisplayMessage("Do you want to enter more student-course : 1 for YES or 2 for NO?");

                    if (_utilityService.Input() == "2") break;
                }

                InputIsHere:
                _utilityService.DisplayMessage("Enter Course ID:");
                string courseID = _utilityService.Input(); //naming convention is not okay.
                _utilityService.DisplayMessage("Enter Student ID:");
                string studentID = _utilityService.Input(); //naming convention is not okay.

                if (!(CheckValidStudent(studentID) && CheckValidCourse(courseID)))
                {
                    _utilityService.DisplayMessage("Enter valid input");
                    goto InputIsHere;
                }

                StudentCourse studentCourse = new StudentCourse()
                {
                    StudentId = studentID,
                    CourseId = courseID
                };

                studentCourseCounter++;

                var student = GetStudentById(studentID);

                _utilityService.DisplayMessage(student.Id);
                student.StudentCourses.Add(studentCourse);
            }
        }

        public void TeacherCourseInput()
        {
            _utilityService.DisplayMessage("This is teacher-course assignment");

            int teacherCourseCounter = 0;

            while (true)
            {
                if (teacherCourseCounter > 0)
                {
                    _utilityService.DisplayMessage("Do you want to enter more teacher-course : 1 for YES or 2 for NO?");

                    if (_utilityService.Input() == "2") break;
                }

                InputIsHere:
                _utilityService.DisplayMessage("Enter Course ID:");
                string courseID = _utilityService.Input();
                _utilityService.DisplayMessage("Enter Teacher ID:");
                string teacherID = _utilityService.Input();

                if (!(CheckValidTeacher(teacherID) && CheckValidCourse(courseID)))
                {
                    _utilityService.DisplayMessage("Enter valid input");
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

                _utilityService.DisplayMessage(teacher.Id);
                teacher.TeacherCourses.Add(teacherCourse);
            }
        }

        public void StudentCourseOutput()
        {
            Console.Clear();
            _utilityService.DisplayMessage("1.   Know about a particular student");
            _utilityService.DisplayMessage("2.   Know about a particular course");


            if (_utilityService.Input() == "1")
            {
                _utilityService.DisplayMessage("Enter the student id");
                string studentId = _utilityService.Input();

                StudentService studentService = new StudentService();

                var student = studentService.GetStudentById(studentId);

                var courseList = student.StudentCourses;

                _utilityService.DisplayMessage("Taken courses are:");

                foreach (var li in courseList)
                {
                    _utilityService.DisplayMessage(li.CourseId);
                }
            }
            else
            {
                _utilityService.DisplayMessage("Enter the course id");
                string courseId = _utilityService.Input();

                CourseService courseService = new CourseService();

                var course = courseService.GetCourseById(courseId);

                var studentList = course.StudentCourses;

                _utilityService.DisplayMessage("Students under this course are:");

                foreach (var li in studentList)
                {
                    _utilityService.DisplayMessage(li.CourseId);
                }
            }
        }

        public void TeacherCourseOutput()
        {
            Console.Clear();
            _utilityService.DisplayMessage("1.   Know about a particular teacher");
            _utilityService.DisplayMessage("2.   Know about a particular course");


            if (_utilityService.Input() == "1")
            {
                _utilityService.DisplayMessage("Enter the teacher id");
                string teacherId = _utilityService.Input();

                var teacher = GetTeacherById(teacherId);

                var courseList = teacher.TeacherCourses;

                _utilityService.DisplayMessage("Taken courses are:");

                foreach (var li in courseList)
                {
                    _utilityService.DisplayMessage(li.CourseId);
                }
            }
            else
            {
                _utilityService.DisplayMessage("Enter the course id");
                string courseId = _utilityService.Input();

                var course = GetCourseById(courseId);

                var teacherList = course.TeacherCourses;

                _utilityService.DisplayMessage("Teachers taking this course are:");

                foreach (var li in teacherList)
                {
                    _utilityService.DisplayMessage(li.TeacherId);
                }
            }
        }

        public static bool CheckValidStudent(string studentId) // why this method is public.
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
                var x = GetCourseById(courseId);
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
            else return false; // what is this ??
        }

        public static bool CheckPassword(Teacher teacher, string inputPassword)
        {
            if (teacher.Password == inputPassword) return true;
            else return false;
        }

        public void LogIn()
        {
            InputAgain:

            _utilityService.DisplayMessage("Enter 1 if you are a teacher");
            _utilityService.DisplayMessage("Enter 2 if you are a student");

            string status = _utilityService.Input();
            Console.Clear();


            _utilityService.DisplayMessage("Enter your id");
            string logInId = _utilityService.Input();

            _utilityService.DisplayMessage("Enter your password");
            string logInPassword = _utilityService.Input();

            if (status == "1")
            {
                if (!CheckValidTeacher(logInId))
                {
                    _utilityService.DisplayMessage("Invalid Id. Try again!");
                    goto InputAgain;
                }


                var teacherService = new TeacherService();
                var teacherList = teacherService.GetAllTeachers();

                var teacher = teacherList.FirstOrDefault(x => x.Id == logInId);

                if (!CheckPassword(teacher, logInPassword))
                {
                    _utilityService.DisplayMessage("Invalid Password. Try again!");
                    goto InputAgain;
                }

                MyDetails(teacher);
                MyCourseList(teacher);
            }
            else if (status == "2")
            {
                if (!CheckValidStudent(logInId))
                {
                    _utilityService.DisplayMessage("Invalid Id. Try again!");
                    goto InputAgain;
                }

                var studentService = new StudentService();
                var studentList = studentService.GetAllStudents();

                var student = studentList.FirstOrDefault(x => x.Id == logInId);

                if (!CheckPassword(student, logInPassword))
                {
                    _utilityService.DisplayMessage("Invalid Password. Try again!");
                    goto InputAgain;
                }

                MyDetails(student);
                MyCourseList(student);
            }
            else
            {
                _utilityService.DisplayMessage("Invalid _utilityService.Input. Try again!");
                goto InputAgain;
            }
        }

        private void MyDetails(Teacher teacher)
        {
            _utilityService.DisplayMessage("Personal Information:");
            _utilityService.DisplayMessage("Id: " + teacher.Id);
            _utilityService.DisplayMessage("Name: " + teacher.Name);
            _utilityService.DisplayMessage("Phone: " + teacher.Phone);
            _utilityService.DisplayMessage("Address: " + teacher.Address);
        }

        public void MyDetails(Student student)
        {
            _utilityService.DisplayMessage("Personal Information:");
            _utilityService.DisplayMessage("Id: " + student.Id);
            _utilityService.DisplayMessage("Name: " + student.Name);
        }

        public void MyCourseList(Teacher teacher)
        {
            var courseList = teacher.TeacherCourses;

            _utilityService.DisplayMessage("Courses you take are:");

            foreach (var li in courseList)
            {
                _utilityService.DisplayMessage(li.CourseId);
            }
        }

        public void MyCourseList(Student student)
        {
            var courseList = student.StudentCourses;

            _utilityService.DisplayMessage("Taken courses are:");

            foreach (var li in courseList)
            {
                _utilityService.DisplayMessage(li.CourseId);
            }
        }

        public static Student GetStudentById(string studentId) // don't understand what is the point of this 
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