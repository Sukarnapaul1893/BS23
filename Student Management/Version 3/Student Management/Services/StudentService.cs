using Student_Management.Model;

namespace Student_Management.Services
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new List<Student>();

        private readonly UtilityService _utilityService;

        public StudentService()
        {
            _utilityService = new();
        }
        public void Create(Student student)
        {
            students.Add(student);
        }

        public void Update(Student student)
        {
            var existingStudent = students.Find(x => x.Id == student.Id);
            existingStudent.Name = student.Name;
            existingStudent.StudentCourses = student.StudentCourses;
        }

        public void Delete(Student student)
        {
            students.Remove(student);
        }

        public IList<Student> GetAllStudents()
        {
            return students;
        }

        public Student GetStudentById(string Id) => students.FirstOrDefault(x => x.Id == Id);
        
        public void StudentInput()
        {
            int studentCounter = 0;
            while (true)
            {
                if (studentCounter > 0)
                {
                    _utilityService.DisplayMessage("Do you want to enter more student entry : 1 for YES or 2 for NO?");
                    string ss = _utilityService.Input();
                    if (ss == "2") break; //variable name must be meaningful. 
                }

                _utilityService.DisplayMessage("Enter the Student's ID:");
                string id = _utilityService.Input();
                _utilityService.DisplayMessage("Enter the Student's Name:");
                string name = _utilityService.Input();
                _utilityService.DisplayMessage("Enter the Student's Password:");
                string password = _utilityService.Input();

                Student student = new Student()
                {
                    Id = id,
                    Name = name,
                    Password = password
                };
                
                Create(student);
                studentCounter++;
            }
        }
        
    }
}