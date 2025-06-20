using System; // For TimeSpan, DayOfWeek

namespace UnicomTICManagementSystem.Models
{
    public class TimetableEntry
    {
        public int EntryID { get; set; }
        public int SubjectID { get; set; } // Foreign key to link to a Subject
        public int RoomID { get; set; }    // Foreign key to link to a Room (Lab/Lecture Hall)
        public DayOfWeek Day { get; set; } // Day of the week (e.g., Monday, Tuesday)
        public TimeSpan StartTime { get; set; } // Start time of the class
        public TimeSpan EndTime { get; set; }  
        public TimetableEntry()
        {
            Day = DayOfWeek.Monday; // Or any default
            StartTime = TimeSpan.Zero;
            EndTime = TimeSpan.Zero;
        }
    }
}