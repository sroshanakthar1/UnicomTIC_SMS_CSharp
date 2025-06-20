using System;
using System.Windows.Forms;
using System.Collections.Generic; // For List<T>
using UnicomTICManagementSystem.Controllers; // To use the ExamController
using UnicomTICManagementSystem.Models;     // To use the Exam and Subject models

namespace UnicomTICManagementSystem.Views
{
    public partial class ExamForm : Form
    {
        private readonly ExamController _examController;
        private List<Subject> _subjects; // To hold the list of subjects for the ComboBox
        private int _selectedExamId = -1; // To store the ID of the selected exam for update/delete
        private User _currentUser;
        public ExamForm(User currentUser)
        {
            InitializeComponent();
            _examController = new ExamController();

            // Setup DataGridView
            SetupDataGridView();

            // Load subjects into ComboBox and exams into DataGridView when the form starts
            LoadSubjectsIntoComboBox();
            LoadExams();
            ClearForm(); // Initialize buttons and fields
            _currentUser = currentUser;
        }

        private void SetupDataGridView()
        {
            dgvExams.AutoGenerateColumns = false; // We'll define columns manually
            dgvExams.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Select full row
            dgvExams.ReadOnly = true; // Make it read-only
            dgvExams.AllowUserToAddRows = false; // Prevent adding rows directly in the grid
            dgvExams.MultiSelect = false; // Only one row can be selected at a time

            // Define columns
            dgvExams.Columns.Add("ExamID", "ID");
            dgvExams.Columns["ExamID"].DataPropertyName = "ExamID";
            dgvExams.Columns["ExamID"].Visible = true;

            dgvExams.Columns.Add("ExamName", "Exam Name");
            dgvExams.Columns["ExamName"].DataPropertyName = "ExamName";
            dgvExams.Columns["ExamName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvExams.Columns.Add("SubjectID", "Subject ID");
            dgvExams.Columns["SubjectID"].DataPropertyName = "SubjectID";
            dgvExams.Columns["SubjectID"].Visible = false; // Hide Subject ID, we'll show Subject Name

            // Add a column to display Subject Name
            DataGridViewTextBoxColumn subjectNameColumn = new DataGridViewTextBoxColumn();
            subjectNameColumn.Name = "SubjectNameColumn";
            subjectNameColumn.HeaderText = "Subject";
            subjectNameColumn.DataPropertyName = "SubjectID"; // Use SubjectID to get the subject name
            subjectNameColumn.ValueType = typeof(string); // The displayed value will be a string
            dgvExams.Columns.Add(subjectNameColumn);

            // Event handler for populating SubjectName display
            dgvExams.CellFormatting += dgvExams_CellFormatting;

            // Event handler for selecting a row
            dgvExams.CellClick += dgvExams_CellClick;
        }

        private void dgvExams_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvExams.Columns[e.ColumnIndex].Name == "SubjectNameColumn" && e.Value != null)
            {
                // Assuming e.Value is SubjectID, find the SubjectName
                int subjectId = (int)e.Value;
                Subject selectedSubject = _subjects.Find(s => s.SubjectID == subjectId);
                if (selectedSubject != null)
                {
                    e.Value = selectedSubject.SubjectName;
                    e.FormattingApplied = true;
                }
            }
        }

        private void LoadSubjectsIntoComboBox()
        {
            try
            {
                _subjects = _examController.GetAllSubjects();
                cmbSubjects.DataSource = _subjects;
                cmbSubjects.DisplayMember = "SubjectName"; // Display the SubjectName property
                cmbSubjects.ValueMember = "SubjectID";     // Use the SubjectID property as the actual value
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading subjects for dropdown: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadExams()
        {
            try
            {
                List<Exam> exams = _examController.GetAllExams();
                dgvExams.DataSource = exams;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading exams: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtExamName.Text = string.Empty;
            cmbSubjects.SelectedIndex = -1; // Deselect any subject
            _selectedExamId = -1; // Reset selected ID
            btnAddExam.Enabled = true; // Enable Add button
            btnUpdateExam.Enabled = false; // Disable Update button
            btnDeleteExam.Enabled = false; // Disable Delete button
        }

        // Event handler for when a cell in the DataGridView is clicked
        private void dgvExams_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                DataGridViewRow row = dgvExams.Rows[e.RowIndex];
                _selectedExamId = (int)row.Cells["ExamID"].Value;
                txtExamName.Text = row.Cells["ExamName"].Value.ToString();

                int subjectId = (int)row.Cells["SubjectID"].Value;
                // Find the subject in the ComboBox and select it
                cmbSubjects.SelectedValue = subjectId;

                // Enable update/delete buttons when a row is selected
                btnAddExam.Enabled = false;
                btnUpdateExam.Enabled = true;
                btnDeleteExam.Enabled = true;
            }
        }

        private void btnAddExam_Click(object sender, EventArgs e)
        {
            string examName = txtExamName.Text.Trim();
            if (string.IsNullOrWhiteSpace(examName))
            {
                MessageBox.Show("Please enter an exam name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbSubjects.SelectedValue == null)
            {
                MessageBox.Show("Please select a subject for the exam.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int subjectId = (int)cmbSubjects.SelectedValue;

            try
            {
                Exam newExam = new Exam { ExamName = examName, SubjectID = subjectId };
                _examController.AddExam(newExam);
                MessageBox.Show("Exam added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadExams(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding exam: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateExam_Click(object sender, EventArgs e)
        {
            if (_selectedExamId == -1)
            {
                MessageBox.Show("Please select an exam to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string examName = txtExamName.Text.Trim();
            if (string.IsNullOrWhiteSpace(examName))
            {
                MessageBox.Show("Exam name cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbSubjects.SelectedValue == null)
            {
                MessageBox.Show("Please select a subject for the exam.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int subjectId = (int)cmbSubjects.SelectedValue;

            try
            {
                Exam updatedExam = new Exam { ExamID = _selectedExamId, ExamName = examName, SubjectID = subjectId };
                _examController.UpdateExam(updatedExam);
                MessageBox.Show("Exam updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadExams(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating exam: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteExam_Click(object sender, EventArgs e)
        {
            if (_selectedExamId == -1)
            {
                MessageBox.Show("Please select an exam to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete exam ID: {_selectedExamId}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _examController.DeleteExam(_selectedExamId);
                    MessageBox.Show("Exam deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadExams(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting exam: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Handle form loading to ensure initial data is loaded
        private void ExamForm_Load(object sender, EventArgs e)
        {
            // Initial loading done in constructor.
        }
    }
}