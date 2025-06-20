using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Views
{
    public partial class MainForm : Form
    {
        private UnicomTICManagementSystem.Models.User _currentUser;
        public MainForm(UnicomTICManagementSystem.Models.User user) // Constructor that receives the logged-in user object
        {
            InitializeComponent(); // Initializes the UI components designed in the designer
            _currentUser = user;   // Store the logged-in user

            lblLoggedInUser.Text = $"Logged in as: {user.Username} ({user.Role})";
            lblWelcome.Text = $"Welcome, {_currentUser.Username} ({_currentUser.Role})!";

            ApplyRoleBasedAccess(); // Call method to adjust UI based on user role
        }
        // Inside the MainForm class (e.g., after the constructor)
        private void ApplyRoleBasedAccess()
        {
            // First, hide all relevant module buttons by default
            // Ensure the button names below match exactly what you designed in Step 1
            // (If you did NOT add btnUserManagement, you can remove/comment out that line here)
            btnUserManagement.Visible = false; // For User Management
            btnCourses.Visible = false;        // For Courses & Subjects
            btnStudents.Visible = false;       // For Student Management
            btnExamsMarks.Visible = false;     // For Exams & Marks
            btnTimetable.Visible = false;      // For Timetable Hub

            // Now, enable visibility based on the user's role, as per our permissions matrix
            switch (_currentUser.Role)
            {
                case "Admin":
                    // Admin can see and manage ALL modules
                    // If you added btnUserManagement, uncomment the line below:
                    btnUserManagement.Visible = true; // Admin manages users
                    btnCourses.Visible = true;
                    btnStudents.Visible = true;
                    btnExamsMarks.Visible = true;
                    btnTimetable.Visible = true;
                    break;

                case "Staff":
                    // Staff permissions:
                    // - User Management: No Access
                    // - Course & Subject Management: View Only (Button visible, granular control inside form)
                    // - Student Management: Full CRUD (Button visible)
                    // - Exam & Marks Management: Full CRUD (Button visible)
                    // - Timetable Management: Full CRUD (Button visible)
                    btnUserManagement.Visible = false; // Staff cannot manage users
                    btnCourses.Visible = true;         // Staff can view Courses & Subjects
                    btnStudents.Visible = true;        // Staff can manage Students
                    btnExamsMarks.Visible = true;      // Staff can manage Exams & Marks
                    btnTimetable.Visible = true;       // Staff can manage Timetables
                    break;

                case "Lecturer":
                    // Lecturer permissions:
                    // - User Management: No Access
                    // - Course & Subject Management: View Only (Button visible, granular control inside form)
                    // - Student Management: View Only (Button visible, granular control inside form)
                    // - Exam & Marks Management: Full CRUD for their subjects (Button visible)
                    // - Timetable Management: Full CRUD for their subjects (Button visible)
                    btnUserManagement.Visible = false;
                    btnCourses.Visible = true;         // Lecturers can view Courses & Subjects
                    btnStudents.Visible = true;        // Lecturers can view Students
                    btnExamsMarks.Visible = true;      // Lecturers manage Exams & Marks (for their subjects)
                    btnTimetable.Visible = true;       // Lecturers manage Timetable Entries (for their subjects)
                    break;

                case "Student":
                    // Student permissions:
                    // - User Management: No Access
                    // - Course & Subject Management: View Only (Button visible, granular control inside form)
                    // - Student Management: No Access (as they only view their OWN data, not general student list)
                    // - Exam & Marks Management: View Own Marks Only (Button visible)
                    // - Timetable Management: View Own Timetable Only (Button visible)
                    btnUserManagement.Visible = false;
                    btnCourses.Visible = true;         // Students can view Courses & Subjects
                    btnStudents.Visible = false;       // Students do NOT see the general student management button
                    btnExamsMarks.Visible = true;      // Students view their own Marks
                    btnTimetable.Visible = true;       // Students view their own Timetable
                    break;

                default:
                    // For any undefined role, ensure all buttons are hidden for security
                    btnUserManagement.Visible = false;
                    btnCourses.Visible = false;
                    btnStudents.Visible = false;
                    btnExamsMarks.Visible = false;
                    btnTimetable.Visible = false;
                    MessageBox.Show("Unknown user role. Access denied.", "Security Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit(); // Exit the application for unknown roles
                    break;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            CoursesSubjectsHubForm coursesSubjectsForm = new CoursesSubjectsHubForm(_currentUser); // <--- PASS _currentUser HERE
            coursesSubjectsForm.ShowDialog();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("This will open the Student Management form.", "Module Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            StudentForm studentsForm = new StudentForm(_currentUser); // <--- PASS _currentUser HERE
            studentsForm.ShowDialog();
        }

        private void btnExamsMarks_Click(object sender, EventArgs e)
        {
            ExamMarksHubForm examsMarksHubForm = new ExamMarksHubForm(_currentUser); // <--- PASS _currentUser HERE
            examsMarksHubForm.ShowDialog();
        }

        private void btnTimetable_Click(object sender, EventArgs e)
        {
            TimetableHubForm timetableHubForm = new TimetableHubForm(_currentUser); // <--- PASS _currentUser HERE
            timetableHubForm.ShowDialog();
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            UserManagementForm userManagementForm = new UserManagementForm(_currentUser); // <--- PASS _currentUser HERE
            userManagementForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // 1. Clear any session-specific data if you had any (e.g., in static classes or variables)
            // For this application, simply closing the form effectively "logs out" the user.

            // 2. Hide the current MainForm
            this.Hide();

            // 3. Create a new instance of the LoginForm
            LoginForm loginForm = new LoginForm();

            // 4. Show the LoginForm as a dialog
            // When LoginForm is closed, execution returns here.
            loginForm.ShowDialog();

            // 5. After LoginForm is closed (either by successful login or app exit),
            //    we close the MainForm to ensure it's properly disposed and the application flow
            //    returns to the login (or exits if login form was closed).
            this.Close();
        }
    }
}
