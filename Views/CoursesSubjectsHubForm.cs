using System;
using System.Windows.Forms;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Views
{
    public partial class CoursesSubjectsHubForm : Form
    {
        private User _currentUser;
        public CoursesSubjectsHubForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser; // Store the current user object
            ApplyCourseSubjectPermissions();
        }

        private void ApplyCourseSubjectPermissions()
        {
           
        }

        private void btnManageCourses_Click(object sender, EventArgs e)
        {
            CourseForm courseForm = new CourseForm(_currentUser); // Pass _currentUser again
            courseForm.ShowDialog(); // Show as dialog to keep focus on it
        }

        private void btnManageSubjects_Click(object sender, EventArgs e)
        {
            SubjectForm subjectForm = new SubjectForm();
            subjectForm.ShowDialog(); // Show as dialog to keep focus on it
        }

        // Optional: Handle form load if needed, but not strictly necessary for this simple hub
        private void CoursesSubjectsHubForm_Load(object sender, EventArgs e)
        {
            // Any initial setup for the hub form can go here
        }
    }
}