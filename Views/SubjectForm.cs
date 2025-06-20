using System;
using System.Windows.Forms;
using System.Collections.Generic; // For List<T>
using UnicomTICManagementSystem.Controllers; // To use the SubjectController
using UnicomTICManagementSystem.Models;     // To use the Subject and Course models

namespace UnicomTICManagementSystem.Views
{
    public partial class SubjectForm : Form
    {
        private readonly SubjectController _subjectController;
        private List<Course> _courses; // To hold the list of courses for the ComboBox
        private int _selectedSubjectId = -1; // To store the ID of the selected subject for update/delete

        public SubjectForm()
        {
            InitializeComponent();
            _subjectController = new SubjectController();

            // Setup DataGridView
            SetupDataGridView();

            // Load courses into ComboBox and subjects into DataGridView when the form starts
            LoadCoursesIntoComboBox();
            LoadSubjects();
            ClearForm(); // Initialize buttons and fields
        }

        private void SetupDataGridView()
        {
            dgvSubjects.AutoGenerateColumns = false; // We'll define columns manually
            dgvSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Select full row
            dgvSubjects.ReadOnly = true; // Make it read-only
            dgvSubjects.AllowUserToAddRows = false; // Prevent adding rows directly in the grid
            dgvSubjects.MultiSelect = false; // Only one row can be selected at a time

            // Define columns
            dgvSubjects.Columns.Add("SubjectID", "ID");
            dgvSubjects.Columns["SubjectID"].DataPropertyName = "SubjectID";
            dgvSubjects.Columns["SubjectID"].Visible = true;

            dgvSubjects.Columns.Add("SubjectName", "Subject Name");
            dgvSubjects.Columns["SubjectName"].DataPropertyName = "SubjectName";
            dgvSubjects.Columns["SubjectName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvSubjects.Columns.Add("CourseID", "Course ID");
            dgvSubjects.Columns["CourseID"].DataPropertyName = "CourseID";
            dgvSubjects.Columns["CourseID"].Visible = true; // Show CourseID

            // Event handler for selecting a row
            dgvSubjects.CellClick += dgvSubjects_CellClick;
        }

        private void LoadCoursesIntoComboBox()
        {
            try
            {
                _courses = _subjectController.GetAllCourses();
                cmbCourses.DataSource = _courses;
                cmbCourses.DisplayMember = "CourseName"; // Display the CourseName property
                cmbCourses.ValueMember = "CourseID";     // Use the CourseID property as the actual value
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses for dropdown: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSubjects()
        {
            try
            {
                List<Subject> subjects = _subjectController.GetAllSubjects();
                dgvSubjects.DataSource = subjects;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading subjects: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtSubjectName.Text = string.Empty;
            cmbCourses.SelectedIndex = -1; // Deselect any course
            _selectedSubjectId = -1; // Reset selected ID
            btnAddSubject.Enabled = true; // Enable Add button
            btnUpdateSubject.Enabled = false; // Disable Update button
            btnDeleteSubject.Enabled = false; // Disable Delete button
        }

        // Event handler for when a cell in the DataGridView is clicked
        private void dgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                DataGridViewRow row = dgvSubjects.Rows[e.RowIndex];
                _selectedSubjectId = (int)row.Cells["SubjectID"].Value;
                txtSubjectName.Text = row.Cells["SubjectName"].Value.ToString();

                int courseId = (int)row.Cells["CourseID"].Value;
                // Find the course in the ComboBox and select it
                cmbCourses.SelectedValue = courseId;

                // Enable update/delete buttons when a row is selected
                btnAddSubject.Enabled = false;
                btnUpdateSubject.Enabled = true;
                btnDeleteSubject.Enabled = true;
            }
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            string subjectName = txtSubjectName.Text.Trim();
            if (string.IsNullOrWhiteSpace(subjectName))
            {
                MessageBox.Show("Please enter a subject name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCourses.SelectedValue == null)
            {
                MessageBox.Show("Please select a course for the subject.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int courseId = (int)cmbCourses.SelectedValue;

            try
            {
                Subject newSubject = new Subject { SubjectName = subjectName, CourseID = courseId };
                _subjectController.AddSubject(newSubject);
                MessageBox.Show("Subject added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadSubjects(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding subject: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateSubject_Click(object sender, EventArgs e)
        {
            if (_selectedSubjectId == -1)
            {
                MessageBox.Show("Please select a subject to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string subjectName = txtSubjectName.Text.Trim();
            if (string.IsNullOrWhiteSpace(subjectName))
            {
                MessageBox.Show("Subject name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCourses.SelectedValue == null)
            {
                MessageBox.Show("Please select a course for the subject.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int courseId = (int)cmbCourses.SelectedValue;

            try
            {
                Subject updatedSubject = new Subject { SubjectID = _selectedSubjectId, SubjectName = subjectName, CourseID = courseId };
                _subjectController.UpdateSubject(updatedSubject);
                MessageBox.Show("Subject updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadSubjects(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating subject: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteSubject_Click(object sender, EventArgs e)
        {
            if (_selectedSubjectId == -1)
            {
                MessageBox.Show("Please select a subject to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete subject ID: {_selectedSubjectId}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _subjectController.DeleteSubject(_selectedSubjectId);
                    MessageBox.Show("Subject deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadSubjects(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting subject: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Handle form loading to ensure initial data is loaded
        private void SubjectForm_Load(object sender, EventArgs e)
        {
            // Initial loading done in constructor.
        }
    }
}