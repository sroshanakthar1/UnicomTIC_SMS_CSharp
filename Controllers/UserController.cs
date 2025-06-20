using System;
using System.Collections.Generic;
using UnicomTICManagementSystem.Models; 
using UnicomTICManagementSystem.Repositories; 

namespace UnicomTICManagementSystem.Controllers
{
    public class UserController
    {
        private DatabaseManager _dbManager; 

        public UserController()
        {
            _dbManager = new DatabaseManager(); 
        }

        public List<User> GetAllUsers()
        {
            return _dbManager.GetUsers(); 
        }

        public void AddUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.Role))
            {
                throw new ArgumentException("Username, Password, and Role cannot be empty.");
            }

            _dbManager.AddUser(user); 
        }

        public void UpdateUser(User user)
        {
            if (user.UserID == 0 || string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.Role))
            {
                throw new ArgumentException("User ID, Username, Password, and Role are required for update.");
            }
            _dbManager.UpdateUser(user); // Calls the method in DatabaseManager
        }

        public void DeleteUser(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("Invalid User ID for deletion.");
            }
            _dbManager.DeleteUser(userId); 
        }
        public User? GetUserByUsernameAndPassword(string username, string password)
        {
            return _dbManager.GetUserByUsernameAndPassword(username, password);
        }
    }
}