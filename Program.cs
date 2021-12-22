using System;
using System.Collections.Generic;
public class Program
{

    public static List<Course>courseList = new List<Course>();
    public static List<Student>studentList = new List<Student>();
    public static List<Exam>examList = new List<Exam>();
    public static List<StudentCourse> StudentCourses = new List<StudentCourse>();

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

        //ExamInput();
        //ExamOutput();
    }

    public static void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
    
    public static string Input()
    {
        return Console.ReadLine();
    }
    public static bool CheckValid(string studentId, string courseId)
    {
        if (!studentList.Any(w => w.Id == studentId))
            return false;
        
        if (!courseList.Any(w => w.Id == courseId))
            return false;
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
                string ss = Input();
                if (ss == "2") break;
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

            courseList.Add(course);

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

            studentList.Add(student);

            studentCounter++;
        }
        
    }
    
    public static void ExamInput()
    {
        int ExamCounter = 0;

        while (true)
        {
            if (ExamCounter > 0)
            {
                DisplayMessage("Do you want to enter more Exam : YES or NO?");
                string ss = Input();
                if (ss == "NO") break;
            }

            DisplayMessage("Enter the Exam ID:");
            string id = Input();
            DisplayMessage("Enter the Exam Date:");
            string date = Input();
            DisplayMessage("Enter the Exam Marks:");
            string marks = Input();

            Exam exam = new Exam()
            {
                Id = id,
                Date = date,
                Marks = marks 
            };

            examList.Add(exam);

            ExamCounter++;
        }
        
    }

    public static void CourseOutput()
    {
        int counter = 1;
        
        foreach(var course in courseList)
        {
            Console.WriteLine(counter++);
            Console.WriteLine("ID = {0} \t Title = {1}", course.Id, course.Title);
        }
    }
    
    public static void StudentOutput()
    {
        int counter = 1;
        
        foreach(var student in studentList)
        {
            Console.WriteLine(counter++);
            Console.WriteLine("ID = {0} \t Name = {1}", student.Id, student.Name);
        }
    }
    
    public static void ExamOutput()
    {
        int counter = 1;
        
        foreach(var exam in examList)
        {
            Console.WriteLine(counter++);
            Console.WriteLine("ID = {0} \t Name = {1} \t", exam.Id, exam.Date);
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
                string ss = Input();
                if (ss == "2") break;
            }

            DisplayMessage("Enter Course ID:");
            string courseID = Input();
            DisplayMessage("Enter Student ID:");
            string studentID = Input();

            if(!CheckValid(studentID, courseID))
            {
                DisplayMessage("Sorry! This is not valid. Please try again");
                continue;
            };

            StudentCourse studentCourse = new StudentCourse()
            {
                studentId = studentID,
                courseId = courseID
            };

            studentCourseCounter++;
            StudentCourses.Add(studentCourse);
        }
    }

    public static void StudentCourseOutput()
    {
        int counter = 1;


        var res = from _student in studentList
                  join _studentCourse in StudentCourses
                   on _student.Id equals _studentCourse.studentId
                  select new
                  {
                      studentId = _student.Id,
                      courseId = _studentCourse.courseId,
                      studentName = _student.Name
                  };

        string previousStudentId = "";
        Console.WriteLine();

        foreach(var _element in res)
        {
            if (_element.studentId != previousStudentId)
            {
                Console.WriteLine("\x1b[36mStudent ID = {0}\x1b[0m", _element?.studentId);
                Console.WriteLine("\x1b[36mStudent Name = {0}\x1b[0m", _element?.studentName);
                Console.WriteLine();
            }
            
            Console.WriteLine("Course ID = {0}", _element?.courseId);
            Console.WriteLine();
            
            previousStudentId = _element?.studentId;
        }
        
    }
}



public class Student
{
    public string Id { get; set; }
    public string Name { get; set; }

    public IList<StudentCourse> StudentCourses { get; set; }
}

public class Exam
{
    public string Id { get; set; }
    public string Date { get; set; }
    public string Marks { get; set; }

    
}
public class StudentCourse
{
    public string studentId { get; set; }
    public string courseId { get; set; }
}