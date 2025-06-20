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
            

            switch (_currentUser.Role)
            {
                case "Admin":
                case "Staff":
                case "Lecturer": 
                    break;
                case "Student":
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