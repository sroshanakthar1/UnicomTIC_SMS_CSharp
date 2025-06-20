using System;
using System.Windows.Forms;
using System.Collections.Generic; // For List<T>
using UnicomTICManagementSystem.Controllers; // To use the MarkController
using UnicomTICManagementSystem.Models;     // To use the Mark, Student, and Exam models

namespace UnicomTICManagementSystem.Views
{
    public partial class MarksForm : Form
    {
        private readonly MarkController _markController;
        private List<Student> _students; // To hold the list of students for the ComboBox
        private List<Exam> _exams;     // To hold the list of exams for the ComboBox
        private int _selectedMarkId = -1; // To store the ID of the selected mark for update/delete
        private User _currentUser;
        public MarksForm(User currentUser)
        {
            InitializeComponent();
            _markController = new MarkController();

            // Setup DataGridView
            SetupDataGridView();

            // Load students and exams into ComboBoxes and marks into DataGridView when the form starts
            LoadStudentsIntoComboBox();
            LoadExamsIntoComboBox();
            LoadMarks();
            ClearForm(); // Initialize buttons and fields
            _currentUser = currentUser;
        }

        private void SetupDataGridView()
        {
            dgvMarks.AutoGenerateColumns = false; // We'll define columns manually
            dgvMarks.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Select full row
            dgvMarks.ReadOnly = true; // Make it read-only
            dgvMarks.AllowUserToAddRows = false; // Prevent adding rows directly in the grid
            dgvMarks.MultiSelect = false; // Only one row can be selected at a time

            // Define columns
            dgvMarks.Columns.Add("MarkID", "ID");
            dgvMarks.Columns["MarkID"].DataPropertyName = "MarkID";
            dgvMarks.Columns["MarkID"].Visible = true;

            // These columns will be populated via CellFormatting based on StudentID/ExamID
            DataGridViewTextBoxColumn studentNameColumn = new DataGridViewTextBoxColumn();
            studentNameColumn.Name = "StudentNameColumn";
            studentNameColumn.HeaderText = "Student";
            studentNameColumn.DataPropertyName = "StudentID"; // Use StudentID to get the student name
            studentNameColumn.ValueType = typeof(string);
            dgvMarks.Columns.Add(studentNameColumn);

            DataGridViewTextBoxColumn examNameColumn = new DataGridViewTextBoxColumn();
            examNameColumn.Name = "ExamNameColumn";
            examNameColumn.HeaderText = "Exam";
            examNameColumn.DataPropertyName = "ExamID"; // Use ExamID to get the exam name
            examNameColumn.ValueType = typeof(string);
            dgvMarks.Columns.Add(examNameColumn);


            dgvMarks.Columns.Add("Score", "Score");
            dgvMarks.Columns["Score"].DataPropertyName = "Score";
            dgvMarks.Columns["Score"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvMarks.Columns.Add("StudentID", "StudentID");
            dgvMarks.Columns["StudentID"].DataPropertyName = "StudentID";
            dgvMarks.Columns["StudentID"].Visible = false; // Hide StudentID (used internally)

            dgvMarks.Columns.Add("ExamID", "ExamID");
            dgvMarks.Columns["ExamID"].DataPropertyName = "ExamID";
            dgvMarks.Columns["ExamID"].Visible = false; // Hide ExamID (used internally)

            // Event handler for populating StudentName and ExamName display
            dgvMarks.CellFormatting += dgvMarks_CellFormatting;

            // Event handler for selecting a row
            dgvMarks.CellClick += dgvMarks_CellClick;
        }

        private void dgvMarks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMarks.Columns[e.ColumnIndex].Name == "StudentNameColumn" && e.Value != null)
            {
                int studentId = (int)e.Value;
                Student selectedStudent = _students.Find(s => s.StudentID == studentId);
                if (selectedStudent != null)
                {
                    e.Value = selectedStudent.Name;
                    e.FormattingApplied = true;
                }
            }
            else if (dgvMarks.Columns[e.ColumnIndex].Name == "ExamNameColumn" && e.Value != null)
            {
                int examId = (int)e.Value;
                Exam selectedExam = _exams.Find(ex => ex.ExamID == examId);
                if (selectedExam != null)
                {
                    e.Value = selectedExam.ExamName;
                    e.FormattingApplied = true;
                }
            }
        }

        private void LoadStudentsIntoComboBox()
        {
            try
            {
                _students = _markController.GetAllStudents();
                cmbStudents.DataSource = _students;
                cmbStudents.DisplayMember = "Name"; // Display the Student Name
                cmbStudents.ValueMember = "StudentID";   // Use the StudentID as the actual value
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students for dropdown: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadExamsIntoComboBox()
        {
            try
            {
                _exams = _markController.GetAllExams();
                cmbExams.DataSource = _exams;
                cmbExams.DisplayMember = "ExamName"; // Display the Exam Name
                cmbExams.ValueMember = "ExamID";      // Use the ExamID as the actual value
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading exams for dropdown: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMarks()
        {
            try
            {
                List<Mark> marks = _markController.GetAllMarks();
                dgvMarks.DataSource = marks;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading marks: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            cmbStudents.SelectedIndex = -1; // Deselect any student
            cmbExams.SelectedIndex = -1;    // Deselect any exam
            txtScore.Text = string.Empty;
            _selectedMarkId = -1; // Reset selected ID
            btnAddMark.Enabled = true; // Enable Add button
            btnUpdateMark.Enabled = false; // Disable Update button
            btnDeleteMark.Enabled = false; // Disable Delete button
        }

        // Event handler for when a cell in the DataGridView is clicked
        private void dgvMarks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                DataGridViewRow row = dgvMarks.Rows[e.RowIndex];
                _selectedMarkId = (int)row.Cells["MarkID"].Value;

                // Select the corresponding student and exam in the ComboBoxes
                cmbStudents.SelectedValue = (int)row.Cells["StudentID"].Value;
                cmbExams.SelectedValue = (int)row.Cells["ExamID"].Value;

                txtScore.Text = row.Cells["Score"].Value.ToString();

                // Enable update/delete buttons when a row is selected
                btnAddMark.Enabled = false;
                btnUpdateMark.Enabled = true;
                btnDeleteMark.Enabled = true;
            }
        }

        private void btnAddMark_Click(object sender, EventArgs e)
        {
            if (cmbStudents.SelectedValue == null)
            {
                MessageBox.Show("Please select a student.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbExams.SelectedValue == null)
            {
                MessageBox.Show("Please select an exam.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtScore.Text.Trim(), out int score) || score < 0 || score > 100) // Example validation
            {
                MessageBox.Show("Please enter a valid score (0-100).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Mark newMark = new Mark
                {
                    StudentID = (int)cmbStudents.SelectedValue,
                    ExamID = (int)cmbExams.SelectedValue,
                    Score = score
                };
                _markController.AddMark(newMark);
                MessageBox.Show("Mark added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadMarks(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding mark: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateMark_Click(object sender, EventArgs e)
        {
            if (_selectedMarkId == -1)
            {
                MessageBox.Show("Please select a mark to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbStudents.SelectedValue == null)
            {
                MessageBox.Show("Please select a student.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbExams.SelectedValue == null)
            {
                MessageBox.Show("Please select an exam.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtScore.Text.Trim(), out int score) || score < 0 || score > 100) // Example validation
            {
                MessageBox.Show("Please enter a valid score (0-100).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Mark updatedMark = new Mark
                {
                    MarkID = _selectedMarkId,
                    StudentID = (int)cmbStudents.SelectedValue,
                    ExamID = (int)cmbExams.SelectedValue,
                    Score = score
                };
                _markController.UpdateMark(updatedMark);
                MessageBox.Show("Mark updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadMarks(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating mark: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteMark_Click(object sender, EventArgs e)
        {
            if (_selectedMarkId == -1)
            {
                MessageBox.Show("Please select a mark to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete mark ID: {_selectedMarkId}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _markController.DeleteMark(_selectedMarkId);
                    MessageBox.Show("Mark deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadMarks(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting mark: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Handle form loading to ensure initial data is loaded
        private void MarksForm_Load(object sender, EventArgs e)
        {
            // Initial loading done in constructor.
        }
    }
}