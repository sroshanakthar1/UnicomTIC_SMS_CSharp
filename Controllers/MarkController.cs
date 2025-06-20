using System.Collections.Generic;
using UnicomTICManagementSystem.Models;     
using UnicomTICManagementSystem.Repositories; // To access the DatabaseManager

namespace UnicomTICManagementSystem.Controllers
{
    public class MarkController
    {
        private readonly DatabaseManager _dbManager; // Instance of the DatabaseManager

        public MarkController()
        {
            _dbManager = new DatabaseManager(); 
        }

        
        public void AddMark(Mark mark)
        {
            _dbManager.AddMark(mark);
        }

        
        public List<Mark> GetAllMarks()
        {
            return _dbManager.GetAllMarks();
        }

        
        public void UpdateMark(Mark mark)
        {
            _dbManager.UpdateMark(mark);
        }

        
        public void DeleteMark(int markId)
        {
            _dbManager.DeleteMark(markId);
        }

        
        public List<Student> GetAllStudents()
        {
            return _dbManager.GetAllStudents();
        }

        
        public List<Exam> GetAllExams()
        {
            return _dbManager.GetAllExams();
        }
    }
}