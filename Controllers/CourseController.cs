using System.Collections.Generic;
using UnicomTICManagementSystem.Models;     
using UnicomTICManagementSystem.Repositories; 

namespace UnicomTICManagementSystem.Controllers
{
    public class CourseController
    {
        private readonly DatabaseManager _dbManager; 

        public CourseController()
        {
            _dbManager = new DatabaseManager(); 
        }

        // Synchronous method to add a new course
        public void AddCourse(Course course)
        {
            _dbManager.AddCourse(course);
        }

        // Synchronous method to get all courses
        public List<Course> GetAllCourses()
        {
            return _dbManager.GetAllCourses();
        }

        // Synchronous method to update an existing course
        public void UpdateCourse(Course course)
        {
            _dbManager.UpdateCourse(course);
        }

        // Synchronous method to delete a course by ID
        public void DeleteCourse(int courseId)
        {
            _dbManager.DeleteCourse(courseId);
        }
    }
}