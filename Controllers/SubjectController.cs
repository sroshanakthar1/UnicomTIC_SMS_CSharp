using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Models;    
using UnicomTICManagementSystem.Repositories;

namespace UnicomTICManagementSystem.Controllers
{
    public class SubjectController
    {
        private readonly DatabaseManager _dbManager; // Instance of the DatabaseManager

        public SubjectController()
        {
            _dbManager = new DatabaseManager(); // Initialize DatabaseManager
        }

        // Synchronous method to add a new subject
        public void AddSubject(Subject subject)
        {
            _dbManager.AddSubject(subject);
        }

        // Synchronous method to get all subjects
        public List<Subject> GetAllSubjects()
        {
            return _dbManager.GetAllSubjects();
        }

        // Synchronous method to update an existing subject
        public void UpdateSubject(Subject subject)
        {
            _dbManager.UpdateSubject(subject);
        }

        // Synchronous method to delete a subject by ID
        public void DeleteSubject(int subjectId)
        {
            _dbManager.DeleteSubject(subjectId);
        }

        // Synchronous method to get all courses (needed for the dropdown in SubjectForm)
        public List<Course> GetAllCourses()
        {
            return _dbManager.GetAllCourses();
        }
    }
}