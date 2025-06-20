namespace UnicomTICManagementSystem.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }

        public Course()
        {
            CourseName = string.Empty;
        }
    }
}