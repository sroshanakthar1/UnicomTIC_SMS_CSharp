using System.Collections.Generic;
using UnicomTICManagementSystem.Models;     
using UnicomTICManagementSystem.Repositories; 

namespace UnicomTICManagementSystem.Controllers
{
    public class RoomController
    {
        private readonly DatabaseManager _dbManager;

        public RoomController()
        {
            _dbManager = new DatabaseManager(); 
        }

        
        public void AddRoom(Room room)
        {
            _dbManager.AddRoom(room);
        }

        
        public List<Room> GetAllRooms()
        {
            return _dbManager.GetAllRooms();
        }

        
        public void UpdateRoom(Room room)
        {
            _dbManager.UpdateRoom(room);
        }

        public void DeleteRoom(int roomID)
        {
            _dbManager.DeleteRoom(roomID);
        }
    }
}