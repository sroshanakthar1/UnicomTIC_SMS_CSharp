namespace UnicomTICManagementSystem.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; } // e.g., "Lab 1", "Lecture Hall A"
        public string RoomType { get; set; } // e.g., "Lab", "Lecture Hall"
        public int Capacity { get; set; }    
        public Room()
        {
            RoomName = string.Empty;
            RoomType = string.Empty;
        }
    }
}