using System.Collections.Generic;
using UnicomTICManagementSystem.Models;     
using UnicomTICManagementSystem.Repositories; 

namespace UnicomTICManagementSystem.Controllers
{
    public class ExamController
    {
        private readonly DatabaseManager _dbManager; 

        public ExamController()
        {
            _dbManager = new DatabaseManager(); 
        }

        
        public void AddExam(Exam exam)
        {
            _dbManager.AddExam(exam);
        }

        
        public List<Exam> GetAllExams()
        {
            return _dbManager.GetAllExams();
        }

        // Synchronous method to update an existing exam
        public void UpdateExam(Exam exam)
        {
            _dbManager.UpdateExam(exam);
        }

        // Synchronous method to delete an exam by ID
        public void DeleteExam(int examId)
        {
            _dbManager.DeleteExam(examId);
        }

        // Synchronous method to get all subjects (needed for the dropdown in ExamForm)
        public List<Subject> GetAllSubjects()
        {
            return _dbManager.GetAllSubjects();
        }
    }
}