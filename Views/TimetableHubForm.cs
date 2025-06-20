using System;
using System.Windows.Forms;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Views
{
    public partial class TimetableHubForm : Form
    {
        private User _currentUser;
        public TimetableHubForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser; // Store the user object
            ApplyTimetableHubPermissions();
        }
        private void ApplyTimetableHubPermissions()
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
                    MessageBox.Show("You do not have permission to access Timetable.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
            }
        }
        private void btnManageRooms_Click(object sender, EventArgs e)
        {
            // Open the RoomsForm
            RoomsForm roomsForm = new RoomsForm(_currentUser);
            roomsForm.ShowDialog();
        }

        private void btnManageTimetable_Click(object sender, EventArgs e)
        {
            TimetableForm timetableForm = new TimetableForm(_currentUser); // Create an instance of the TimetableForm
            timetableForm.ShowDialog();
        }

        private void TimetableHubForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}