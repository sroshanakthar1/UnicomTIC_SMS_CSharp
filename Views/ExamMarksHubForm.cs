using System;
using System.Windows.Forms;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Views
{
    public partial class ExamMarksHubForm : Form
    {
        private User _currentUser;
        public ExamMarksHubForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser; // Store the user object
            ApplyExamsMarksHubPermissions();
        }

        private void btnManageExams_Click(object sender, EventArgs e)
        {
            // Open the ExamForm
            ExamForm examForm = new ExamForm(_currentUser); // Pass _currentUser!
            examForm.ShowDialog();
        }
        // Inside the ExamsMarksHubForm class
        private void ApplyExamsMarksHubPermissions()
        {
            // Assuming you have buttons like btnManageExams and btnManageMarks
            // The visibility of these hub buttons might stay consistent across most roles,
            // as the actual restrictions happen in the 'ExamForm' and 'MarkForm'.
            // However, we still need to pass _currentUser down.

            // Example: If students should only see "My Marks" button and not "Exam Schedule"
            // Adjust button names to match your design
            // btnManageExams.Visible = true;
            // btnManageMarks.Visible = true;

            switch (_currentUser.Role)
            {
                case "Admin":
                case "Staff":
                case "Lecturer": // Lecturers need to manage exams/marks for their subjects
                                 // All navigation buttons visible. Granular control is in ExamForm/MarkForm.
                                 // If you have specific buttons for 'Manage Exams' and 'Manage Marks':
                                 // btnManageExams.Visible = true;
                                 // btnManageMarks.Visible = true;
                    break;
                case "Student":
                    // Students should only see their own marks, not manage exams generally.
                    // If you have a 'View My Marks' button and 'Manage Exams' button:
                    // btnManageExams.Visible = false; // Hide if this button leads to general exam management
                    // btnViewMyMarks.Visible = true; // Show only the button for their own marks
                    break;
                default:
                    // Unknown role - deny access
                    MessageBox.Show("You do not have permission to access Exams & Marks.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
            }
        }

        // IMPORTANT: When you open ExamForm or MarkForm from this hub, remember to pass _currentUser:

        private void btnManageMarks_Click(object sender, EventArgs e)
        {
            MarksForm markForm = new MarksForm(_currentUser); // Pass _currentUser!
            markForm.ShowDialog();
        }
        private void ExamMarksHubForm_Load(object sender, EventArgs e)
        {
            // Any initial setup for the hub form can go here
        }
    }
}