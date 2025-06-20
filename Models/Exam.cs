namespace UnicomTICManagementSystem.Models
{
    public class Exam
    {
        public int ExamID { get; set; }
        public string ExamName { get; set; }
        public int SubjectID { get; set; } 
        public Exam()
        {
            ExamName = string.Empty;
        }
    }
}