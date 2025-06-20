namespace UnicomTICManagementSystem.Models
{
    public class Mark
    {
        public int MarkID { get; set; }
        public int StudentID { get; set; } // Foreign key to link to Student
        public int ExamID { get; set; }    // Foreign key to link to Exam
        public int Score { get; set; }     // The mark/score (e.g., 0-100)
    }
}