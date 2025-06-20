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
            // Example: If this form has an 'Add Course' button (e.g., btnAddCourse)
            // Or if it leads to another form that has CRUD.
            // For Courses & Subjects: Admin has Full CRUD, others are View Only.
            // If this is a hub, its buttons might always be visible, and actual CRUD is restricted deeper.
            // Let's assume you have a button to 'Manage Courses' and 'Manage Subjects' in this hub form.

            // Example buttons within this form (adjust names to match your design):
            // btnManageCourses, btnManageSubjects
            // You'll likely also pass _currentUser to the forms they open (e.g., CourseForm, SubjectForm).

            // For now, if the hub just navigates, its buttons might stay visible,
            // and the permissions are strictly enforced in the final CRUD forms.
            // So, for simplicity, let's just make sure the _currentUser is received.
            // The actual granular permission logic will go into the forms like CourseForm.cs, SubjectForm.cs etc.
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