using System;
using System.Windows.Forms;
using System.Collections.Generic; // For List<T>
using UnicomTICManagementSystem.Controllers; // To use the StudentController
using UnicomTICManagementSystem.Models;     // To use the Student and Course models

namespace UnicomTICManagementSystem.Views
{
    public partial class StudentForm : Form
    {
        private readonly StudentController _studentController;
        private List<Course> _courses; // To hold the list of courses for the ComboBox
        private int _selectedStudentId = -1; // To store the ID of the selected student for update/delete
        private User _currentUser;
        public StudentForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            ApplyStudentPermissions();
            _studentController = new StudentController();

            // Setup DataGridView
            SetupDataGridView();

            // Load courses into ComboBox and students into DataGridView when the form starts
            LoadCoursesIntoComboBox();
            LoadStudents();
            ClearForm(); // Initialize buttons and fields
            
        }
        // Inside the StudentsForm class
        private void ApplyStudentPermissions()
        {
            // By default, assume view-only mode
            btnAddStudent.Visible = false;
            btnUpdateStudent.Visible = false;
            btnDeleteStudent.Visible = false;

            // Make input fields read-only
            // Adjust these to your actual text box names (e.g., txtStudentName, txtStudentID, cmbCourse)
            txtStudentName.ReadOnly = true;
            // Often StudentID is not editable anyway
            cmbCourses.Enabled = false; // Example ComboBox for course selection
                                       // ... any other input fields for students ...

            // Make the DataGridView read-only for restricted roles
            dgvStudents.ReadOnly = true; // Assuming your DataGridView for students is named dgvStudents
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;

            switch (_currentUser.Role)
            {
                case "Admin":
                case "Staff":
                    // Admin and Staff have full CRUD access
                    btnAddStudent.Visible = true;
                    btnUpdateStudent.Visible = true;
                    btnDeleteStudent.Visible = true;
                    txtStudentName.ReadOnly = false;
                    cmbCourses.Enabled = true;
                    dgvStudents.ReadOnly = false;
                    dgvStudents.AllowUserToAddRows = true;
                    dgvStudents.AllowUserToDeleteRows = true;
                    break;

                case "Lecturer":
                    // Lecturers have "View Only" access
                    // Defaults apply, no extra code needed here.
                    break;

                case "Student":
                    // Students should not access this form (they view their own data elsewhere).
                    // Hide everything and deny access.
                    btnAddStudent.Visible = false;
                    btnUpdateStudent.Visible = false;
                    btnDeleteStudent.Visible = false;
                    txtStudentName.ReadOnly = true;
                    cmbCourses.Enabled = false;
                    dgvStudents.Visible = false; // Hide the entire DataGridView
                    MessageBox.Show("You do not have permission to view other student records.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close(); // Close the form
                    break;

                default:
                    // Unknown role - deny access
                    btnAddStudent.Visible = false;
                    btnUpdateStudent.Visible = false;
                    btnDeleteStudent.Visible = false;
                    txtStudentName.ReadOnly = true;
                    cmbCourses.Enabled = false;
                    dgvStudents.Visible = false;
                    MessageBox.Show("You do not have permission to access student management.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    break;
            }
        }

        // IMPORTANT FOR STUDENTS:
        // If a student logs in, this form should not be accessible at all. The MainForm button for Students
        // is already hidden for them. If they somehow try to open it (e.g., via direct code), this logic
        // will close it. For actual student "view own data", you'd need a separate form like "MyProfileForm"
        // that fetches data specifically for _currentUser.UserID.
        private void SetupDataGridView()
        {
            dgvStudents.AutoGenerateColumns = false; // We'll define columns manually
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Select full row
            dgvStudents.ReadOnly = true; // Make it read-only
            dgvStudents.AllowUserToAddRows = false; // Prevent adding rows directly in the grid
            dgvStudents.MultiSelect = false; // Only one row can be selected at a time

            // Define columns
            dgvStudents.Columns.Add("StudentID", "ID");
            dgvStudents.Columns["StudentID"].DataPropertyName = "StudentID";
            dgvStudents.Columns["StudentID"].Visible = true;

            dgvStudents.Columns.Add("Name", "Student Name");
            dgvStudents.Columns["Name"].DataPropertyName = "Name";
            dgvStudents.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvStudents.Columns.Add("CourseID", "Course ID");
            dgvStudents.Columns["CourseID"].DataPropertyName = "CourseID";
            dgvStudents.Columns["CourseID"].Visible = false; // Hide Course ID, we'll show Course Name

            // Add a column to display Course Name (requires joining in GetAllStudents if not already done)
            // Or create a ViewModel for richer display data if needed for more complex scenarios
            // For now, we'll manually get the CourseName based on CourseID for display.
            DataGridViewTextBoxColumn courseNameColumn = new DataGridViewTextBoxColumn();
            courseNameColumn.Name = "CourseNameColumn";
            courseNameColumn.HeaderText = "Course";
            courseNameColumn.DataPropertyName = "CourseID"; // Use CourseID to get the course name
            courseNameColumn.ValueType = typeof(string); // The displayed value will be a string
            dgvStudents.Columns.Add(courseNameColumn);


            // Event handler for populating CourseName display
            dgvStudents.CellFormatting += dgvStudents_CellFormatting;

            // Event handler for selecting a row
            dgvStudents.CellClick += dgvStudents_CellClick;
        }

        private void dgvStudents_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvStudents.Columns[e.ColumnIndex].Name == "CourseNameColumn" && e.Value != null)
            {
                // Assuming e.Value is CourseID, find the CourseName
                int courseId = (int)e.Value;
                Course selectedCourse = _courses.Find(c => c.CourseID == courseId);
                if (selectedCourse != null)
                {
                    e.Value = selectedCourse.CourseName;
                    e.FormattingApplied = true;
                }
            }
        }


        private void LoadCoursesIntoComboBox()
        {
            try
            {
                _courses = _studentController.GetAllCourses();
                cmbCourses.DataSource = _courses;
                cmbCourses.DisplayMember = "CourseName"; // Display the CourseName property
                cmbCourses.ValueMember = "CourseID";     // Use the CourseID property as the actual value
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses for dropdown: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStudents()
        {
            try
            {
                List<Student> students = _studentController.GetAllStudents();
                dgvStudents.DataSource = students;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtStudentName.Text = string.Empty;
            cmbCourses.SelectedIndex = -1; // Deselect any course
            _selectedStudentId = -1; // Reset selected ID
            btnAddStudent.Enabled = true; // Enable Add button
            btnUpdateStudent.Enabled = false; // Disable Update button
            btnDeleteStudent.Enabled = false; // Disable Delete button
        }

        // Event handler for when a cell in the DataGridView is clicked
        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];
                _selectedStudentId = (int)row.Cells["StudentID"].Value;
                txtStudentName.Text = row.Cells["Name"].Value.ToString(); // Use "Name" from DGV column

                int courseId = (int)row.Cells["CourseID"].Value;
                // Find the course in the ComboBox and select it
                cmbCourses.SelectedValue = courseId;

                // Enable update/delete buttons when a row is selected
                btnAddStudent.Enabled = false;
                btnUpdateStudent.Enabled = true;
                btnDeleteStudent.Enabled = true;
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string studentName = txtStudentName.Text.Trim();
            if (string.IsNullOrWhiteSpace(studentName))
            {
                MessageBox.Show("Please enter a student name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCourses.SelectedValue == null)
            {
                MessageBox.Show("Please select a course for the student.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int courseId = (int)cmbCourses.SelectedValue;

            try
            {
                Student newStudent = new Student { Name = studentName, CourseID = courseId };
                _studentController.AddStudent(newStudent);
                MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadStudents(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            if (_selectedStudentId == -1)
            {
                MessageBox.Show("Please select a student to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string studentName = txtStudentName.Text.Trim();
            if (string.IsNullOrWhiteSpace(studentName))
            {
                MessageBox.Show("Student name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCourses.SelectedValue == null)
            {
                MessageBox.Show("Please select a course for the student.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int courseId = (int)cmbCourses.SelectedValue;

            try
            {
                Student updatedStudent = new Student { StudentID = _selectedStudentId, Name = studentName, CourseID = courseId };
                _studentController.UpdateStudent(updatedStudent);
                MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadStudents(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (_selectedStudentId == -1)
            {
                MessageBox.Show("Please select a student to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete student ID: {_selectedStudentId}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _studentController.DeleteStudent(_selectedStudentId);
                    MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadStudents(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Handle form loading to ensure initial data is loaded
        private void StudentForm_Load(object sender, EventArgs e)
        {
            // Initial loading done in constructor.
        }
    }
}