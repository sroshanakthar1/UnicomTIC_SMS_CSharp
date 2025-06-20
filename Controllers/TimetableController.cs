using System.Collections.Generic;
using UnicomTICManagementSystem.Models;     
using UnicomTICManagementSystem.Repositories; 

namespace UnicomTICManagementSystem.Controllers
{
    public class TimetableController
    {
        private readonly DatabaseManager _dbManager;

        public TimetableController()
        {
            _dbManager = new DatabaseManager(); 
        }

        // Synchronous method to add a new timetable entry
        public void AddTimetableEntry(TimetableEntry entry)
        {
            _dbManager.AddTimetableEntry(entry);
        }

        // Synchronous method to get all timetable entries
        public List<TimetableEntry> GetAllTimetableEntries()
        {
            return _dbManager.GetAllTimetableEntries();
        }

        // Synchronous method to update an existing timetable entry
        public void UpdateTimetableEntry(TimetableEntry entry)
        {
            _dbManager.UpdateTimetableEntry(entry);
        }

        // Synchronous method to delete a timetable entry by ID
        public void DeleteTimetableEntry(int entryID)
        {
            _dbManager.DeleteTimetableEntry(entryID);
        }

        // --- Helper methods to get data for dropdowns in the form ---

        // Synchronous method to get all subjects (for linking to timetable entries)
        public List<Subject> GetAllSubjects()
        {
            return _dbManager.GetAllSubjects();
        }

        // Synchronous method to get all rooms (for linking to timetable entries)
        public List<Room> GetAllRooms()
        {
            return _dbManager.GetAllRooms();
        }
    }
}