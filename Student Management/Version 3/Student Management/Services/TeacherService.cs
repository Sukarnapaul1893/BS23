using Student_Management.Model;

namespace Student_Management.Services
{
    public class TeacherService : ITeacherService
    {
        private static List<Teacher> teachers = new List<Teacher>();
        private readonly UtilityService _utilityService;

        public TeacherService()
        {
            _utilityService = new();
        }
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

        public void TeacherInput()
        {
            int teacherCounter = 0;

            while (true)
            {
                if (teacherCounter > 0)
                {
                    _utilityService.DisplayMessage("Do you want to enter more teacher entry : 1 for YES or 2 for NO?");
                    if (_utilityService.Input() == "2") break;
                }

                _utilityService.DisplayMessage("Enter the Teacher's ID:");
                string id = _utilityService.Input();
                _utilityService.DisplayMessage("Enter the Teacher's Name:");
                string name = _utilityService.Input();
                _utilityService.DisplayMessage("Enter the Teacher's Phone:");
                string phone = _utilityService.Input();
                _utilityService.DisplayMessage("Enter the Teacher's Address:");
                string address = _utilityService.Input();
                _utilityService.DisplayMessage("Enter the Teacher's Password:");
                string password = _utilityService.Input();

                Teacher teacher = new Teacher()
                {
                    Id = id,
                    Name = name,
                    Phone = phone,
                    Address = address,
                    Password = password
                };

                var teacherService = new TeacherService(); //can be improve 
                teacherService.Create(teacher);

                teacherCounter++;
            }
        }
        
        
        
    }
}