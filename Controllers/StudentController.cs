using System.Collections.Generic;
using UnicomTICManagementSystem.Models;     
using UnicomTICManagementSystem.Repositories; 

namespace UnicomTICManagementSystem.Controllers
{
    public class StudentController
    {
        private readonly DatabaseManager _dbManager; // Instance of the DatabaseManager

        public StudentController()
        {
            _dbManager = new DatabaseManager(); // Initialize DatabaseManager
        }

        // Synchronous method to add a new student
        public void AddStudent(Student student)
        {
            _dbManager.AddStudent(student);
        }

        // Synchronous method to get all students
        public List<Student> GetAllStudents()
        {
            return _dbManager.GetAllStudents();
        }

        // Synchronous method to update an existing student
        public void UpdateStudent(Student student)
        {
            _dbManager.UpdateStudent(student);
        }

        // Synchronous method to delete a student by ID
        public void DeleteStudent(int studentId)
        {
            _dbManager.DeleteStudent(studentId);
        }

        // Synchronous method to get all courses (needed for the dropdown in StudentForm)
        public List<Course> GetAllCourses()
        {
            return _dbManager.GetAllCourses();
        }
    }
}