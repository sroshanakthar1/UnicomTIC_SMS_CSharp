namespace UnicomTICManagementSystem.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public int CourseID { get; set; } 
        public Student()
        {
            Name = string.Empty;
        }
    }
}