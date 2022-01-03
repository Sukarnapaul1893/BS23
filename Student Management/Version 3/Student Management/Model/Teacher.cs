namespace Student_Management.Model
{
    public class Teacher : PersonBaseModel
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public ICollection<TeacherCourse> TeacherCourses { get; set; }

        public Teacher()
        {
            TeacherCourses = new List<TeacherCourse>();
        }
    }
}