using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTICManagementSystem.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // Storing plain text as per assignment for simplicity
        public string Role { get; set; }

        public User()
        {
            Username = string.Empty;
            Password = string.Empty;
            Role = "User"; // Default role can be 'User' or 'Staff'
        }
        // 'Admin', 'Staff', 'Student', 'Lecturer'
    }
}