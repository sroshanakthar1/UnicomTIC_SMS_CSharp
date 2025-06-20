using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic; // For List<T>
using UnicomTICManagementSystem.Controllers; // To use the CourseController
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Views
{
    public partial class CourseForm : Form
    {
        private readonly CourseController _courseController;
        private int _selectedCourseId = -1;
        private User _currentUser;
        public CourseForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _courseController = new CourseController();

            // Setup DataGridView
            SetupDataGridView();

            // Load courses when the form starts
            LoadCourses();
            ApplyCoursePermissions();

        }

        // Inside the CourseForm class
        private void ApplyCoursePermissions()
        {
            // By default, assume view-only mode for safety
            btnAddCourse.Visible = false;      // Assuming you have an 'Add' button
            btnUpdateCourse.Visible = false;   // Assuming you have an 'Update' button
            btnDeleteCourse.Visible = false;   // Assuming you have a 'Delete' button

            // Make input fields read-only
            // Adjust these to your actual text box names (e.g., txtCourseName, txtCourseCode)
            txtCourseName.ReadOnly = true; // Example Course Name textbox
            // Example Course Code textbox
                                           // ... any other input fields for courses ...

            // Make the DataGridView read-only for non-Admins
            dgvCourses.ReadOnly = true; // Assuming your DataGridView for courses is named dgvCourses
            dgvCourses.AllowUserToAddRows = false;
            dgvCourses.AllowUserToDeleteRows = false;

            switch (_currentUser.Role)
            {
                case "Admin":
                    // Admin has full CRUD access
                    btnAddCourse.Visible = true;
                    btnUpdateCourse.Visible = true;
                    btnDeleteCourse.Visible = true;
                    txtCourseName.ReadOnly = false;
                    dgvCourses.ReadOnly = false;
                    dgvCourses.AllowUserToAddRows = true;
                    dgvCourses.AllowUserToDeleteRows = true;
                    break;

                case "Staff":
                case "Lecturer":
                case "Student":
                    // These roles have "View Only" access.
                    // Buttons are already hidden, textboxes are read-only, DGV is read-only.
                    // No additional code needed here as defaults are applied.
                    break;

                default:
                    // Unknown role - ensure everything is hidden/disabled
                    btnAddCourse.Visible = false;
                    btnUpdateCourse.Visible = false;
                    btnDeleteCourse.Visible = false;
                    txtCourseName.ReadOnly = true;
                    dgvCourses.ReadOnly = true;
                    dgvCourses.AllowUserToAddRows = false;
                    dgvCourses.AllowUserToDeleteRows = false;
                    MessageBox.Show("You do not have permission to access course management.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close(); // Close the form if access is denied
                    break;
            }
        }
        private void SetupDataGridView()
        {
            dgvCourses.AutoGenerateColumns = false; // We'll define columns manually
            dgvCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Select full row
            dgvCourses.ReadOnly = true; // Make it read-only
            dgvCourses.AllowUserToAddRows = false; // Prevent adding rows directly in the grid
            dgvCourses.MultiSelect = false; // Only one row can be selected at a time

            // Define columns
            dgvCourses.Columns.Add("CourseID", "ID");
            dgvCourses.Columns["CourseID"].DataPropertyName = "CourseID"; // Link to CourseID property
            dgvCourses.Columns["CourseID"].Visible = true; // Make ID visible for now

            dgvCourses.Columns.Add("CourseName", "Course Name");
            dgvCourses.Columns["CourseName"].DataPropertyName = "CourseName"; // Link to CourseName property
            dgvCourses.Columns["CourseName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Fill available space

            // Event handler for selecting a row
            dgvCourses.CellClick += dgvCourses_CellClick;
        }

        private void LoadCourses()
        {
            try
            {
                List<Course> courses = _courseController.GetAllCourses();
                dgvCourses.DataSource = courses;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtCourseName.Text = string.Empty;
            _selectedCourseId = -1; // Reset selected ID
            btnAddCourse.Enabled = true; // Enable Add button
            btnUpdateCourse.Enabled = false; // Disable Update button
            btnDeleteCourse.Enabled = false; // Disable Delete button
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                DataGridViewRow row = dgvCourses.Rows[e.RowIndex];
                _selectedCourseId = (int)row.Cells["CourseID"].Value;
                txtCourseName.Text = row.Cells["CourseName"].Value.ToString();

                // Enable update/delete buttons when a row is selected
                btnAddCourse.Enabled = false;
                btnUpdateCourse.Enabled = true;
                btnDeleteCourse.Enabled = true;
            }
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            string courseName = txtCourseName.Text.Trim();

            if (string.IsNullOrWhiteSpace(courseName))
            {
                MessageBox.Show("Please enter a course name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Course newCourse = new Course { CourseName = courseName };
                _courseController.AddCourse(newCourse);
                MessageBox.Show("Course added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadCourses(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateCourse_Click(object sender, EventArgs e)
        {
            if (_selectedCourseId == -1)
            {
                MessageBox.Show("Please select a course to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string courseName = txtCourseName.Text.Trim();
            if (string.IsNullOrWhiteSpace(courseName))
            {
                MessageBox.Show("Course name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Course updatedCourse = new Course { CourseID = _selectedCourseId, CourseName = courseName };
                _courseController.UpdateCourse(updatedCourse);
                MessageBox.Show("Course updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadCourses(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            if (_selectedCourseId == -1)
            {
                MessageBox.Show("Please select a course to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete course ID: {_selectedCourseId}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _courseController.DeleteCourse(_selectedCourseId);
                    MessageBox.Show("Course deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadCourses(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
