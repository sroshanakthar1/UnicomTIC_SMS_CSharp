using System;
using System.Windows.Forms;
using System.Collections.Generic; // For List<T>
using System.Linq; // For LINQ operations like .Find()
using UnicomTICManagementSystem.Controllers; // To use the TimetableController
using UnicomTICManagementSystem.Models;     // To use the TimetableEntry, Subject, and Room models

namespace UnicomTICManagementSystem.Views
{
    public partial class TimetableForm : Form
    {
        private readonly TimetableController _timetableController;
        private List<Subject> _subjects; // To hold the list of subjects for the ComboBox
        private List<Room> _rooms;       // To hold the list of rooms for the ComboBox
        private int _selectedEntryId = -1; // To store the ID of the selected timetable entry for update/delete

        private User _currentUser;
        public TimetableForm(User currentUser)
        {
            InitializeComponent();
            _timetableController = new TimetableController();

            // Setup DataGridView
            SetupDataGridView();

            // Load data into ComboBoxes and Timetable Entries into DataGridView
            PopulateComboBoxes();
            LoadTimetableEntries();
            ClearForm(); // Initialize buttons and fields
            _currentUser = currentUser;
        }

        private void SetupDataGridView()
        {
            dgvTimetable.AutoGenerateColumns = false; // We'll define columns manually
            dgvTimetable.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Select full row
            dgvTimetable.ReadOnly = true; // Make it read-only
            dgvTimetable.AllowUserToAddRows = false; // Prevent adding rows directly in the grid
            dgvTimetable.MultiSelect = false; // Only one row can be selected at a time

            // Define columns
            dgvTimetable.Columns.Add("EntryID", "ID");
            dgvTimetable.Columns["EntryID"].DataPropertyName = "EntryID";
            dgvTimetable.Columns["EntryID"].Visible = true; // Keep ID visible for debugging

            // Subject Name column (will be populated via CellFormatting)
            DataGridViewTextBoxColumn subjectNameColumn = new DataGridViewTextBoxColumn();
            subjectNameColumn.Name = "SubjectNameColumn";
            subjectNameColumn.HeaderText = "Subject";
            subjectNameColumn.DataPropertyName = "SubjectID"; // Use SubjectID to get the name
            subjectNameColumn.ValueType = typeof(string);
            subjectNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTimetable.Columns.Add(subjectNameColumn);

            // Room Name column (will be populated via CellFormatting)
            DataGridViewTextBoxColumn roomNameColumn = new DataGridViewTextBoxColumn();
            roomNameColumn.Name = "RoomNameColumn";
            roomNameColumn.HeaderText = "Room";
            roomNameColumn.DataPropertyName = "RoomID"; // Use RoomID to get the name
            roomNameColumn.ValueType = typeof(string);
            roomNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTimetable.Columns.Add(roomNameColumn);

            dgvTimetable.Columns.Add("Day", "Day");
            dgvTimetable.Columns["Day"].DataPropertyName = "Day";
            dgvTimetable.Columns["Day"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvTimetable.Columns.Add("StartTime", "Start Time");
            dgvTimetable.Columns["StartTime"].DataPropertyName = "StartTime";
            dgvTimetable.Columns["StartTime"].DefaultCellStyle.Format = "hh\\:mm"; // Format TimeSpan
            dgvTimetable.Columns["StartTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvTimetable.Columns.Add("EndTime", "End Time");
            dgvTimetable.Columns["EndTime"].DataPropertyName = "EndTime";
            dgvTimetable.Columns["EndTime"].DefaultCellStyle.Format = "hh\\:mm"; // Format TimeSpan
            dgvTimetable.Columns["EndTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Hidden columns for internal use (foreign keys)
            dgvTimetable.Columns.Add("SubjectID", "SubjectID");
            dgvTimetable.Columns["SubjectID"].DataPropertyName = "SubjectID";
            dgvTimetable.Columns["SubjectID"].Visible = false;

            dgvTimetable.Columns.Add("RoomID", "RoomID");
            dgvTimetable.Columns["RoomID"].DataPropertyName = "RoomID";
            dgvTimetable.Columns["RoomID"].Visible = false;

            // Event handlers
            dgvTimetable.CellFormatting += dgvTimetable_CellFormatting;
            dgvTimetable.CellClick += dgvTimetable_CellClick;
        }

        private void PopulateComboBoxes()
        {
            try
            {
                // Populate Subjects ComboBox
                _subjects = _timetableController.GetAllSubjects();
                cmbSubjects.DataSource = _subjects;
                cmbSubjects.DisplayMember = "SubjectName";
                cmbSubjects.ValueMember = "SubjectID";

                // Populate Rooms ComboBox
                _rooms = _timetableController.GetAllRooms();
                cmbRooms.DataSource = _rooms;
                cmbRooms.DisplayMember = "RoomName"; // Display room name
                cmbRooms.ValueMember = "RoomID";     // Use RoomID as value

                // Populate Days ComboBox
                cmbDays.DataSource = Enum.GetValues(typeof(DayOfWeek));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error populating dropdowns: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTimetableEntries()
        {
            try
            {
                List<TimetableEntry> entries = _timetableController.GetAllTimetableEntries();
                dgvTimetable.DataSource = entries;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading timetable entries: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            cmbSubjects.SelectedIndex = -1;
            cmbRooms.SelectedIndex = -1;
            cmbDays.SelectedIndex = -1;
            dtpStartTime.Value = DateTime.Now.Date.AddHours(9); // Default to 9:00 AM
            dtpEndTime.Value = DateTime.Now.Date.AddHours(10);  // Default to 10:00 AM
            _selectedEntryId = -1;

            btnAddEntry.Enabled = true;
            btnUpdateEntry.Enabled = false;
            btnDeleteEntry.Enabled = false;
        }

        // Handles displaying SubjectName and RoomName in the DataGridView
        private void dgvTimetable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (dgvTimetable.Columns[e.ColumnIndex].Name == "SubjectNameColumn")
                {
                    int subjectId = (int)e.Value;
                    Subject subject = _subjects.Find(s => s.SubjectID == subjectId);
                    if (subject != null)
                    {
                        e.Value = subject.SubjectName;
                        e.FormattingApplied = true;
                    }
                }
                else if (dgvTimetable.Columns[e.ColumnIndex].Name == "RoomNameColumn")
                {
                    int roomId = (int)e.Value;
                    Room room = _rooms.Find(r => r.RoomID == roomId);
                    if (room != null)
                    {
                        e.Value = room.RoomName + " (" + room.RoomType + ")"; // Display Name (Type)
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        // Event handler for when a cell in the DataGridView is clicked
        private void dgvTimetable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                DataGridViewRow row = dgvTimetable.Rows[e.RowIndex];
                _selectedEntryId = (int)row.Cells["EntryID"].Value;

                // Select corresponding items in ComboBoxes
                cmbSubjects.SelectedValue = (int)row.Cells["SubjectID"].Value;
                cmbRooms.SelectedValue = (int)row.Cells["RoomID"].Value;
                cmbDays.SelectedItem = (DayOfWeek)row.Cells["Day"].Value;

                // Set DateTimePicker values
                dtpStartTime.Value = DateTime.Today.Add((TimeSpan)row.Cells["StartTime"].Value);
                dtpEndTime.Value = DateTime.Today.Add((TimeSpan)row.Cells["EndTime"].Value);

                // Enable update/delete buttons
                btnAddEntry.Enabled = false;
                btnUpdateEntry.Enabled = true;
                btnDeleteEntry.Enabled = true;
            }
        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            if (cmbSubjects.SelectedValue == null || cmbRooms.SelectedValue == null || cmbDays.SelectedItem == null)
            {
                MessageBox.Show("Please select a Subject, Room, and Day.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimeSpan startTime = dtpStartTime.Value.TimeOfDay;
            TimeSpan endTime = dtpEndTime.Value.TimeOfDay;

            if (startTime >= endTime)
            {
                MessageBox.Show("End Time must be after Start Time.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                TimetableEntry newEntry = new TimetableEntry
                {
                    SubjectID = (int)cmbSubjects.SelectedValue,
                    RoomID = (int)cmbRooms.SelectedValue,
                    Day = (DayOfWeek)cmbDays.SelectedItem,
                    StartTime = startTime,
                    EndTime = endTime
                };
                _timetableController.AddTimetableEntry(newEntry);
                MessageBox.Show("Timetable entry added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadTimetableEntries(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding timetable entry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateEntry_Click(object sender, EventArgs e)
        {
            if (_selectedEntryId == -1)
            {
                MessageBox.Show("Please select a timetable entry to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbSubjects.SelectedValue == null || cmbRooms.SelectedValue == null || cmbDays.SelectedItem == null)
            {
                MessageBox.Show("Please select a Subject, Room, and Day.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimeSpan startTime = dtpStartTime.Value.TimeOfDay;
            TimeSpan endTime = dtpEndTime.Value.TimeOfDay;

            if (startTime >= endTime)
            {
                MessageBox.Show("End Time must be after Start Time.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                TimetableEntry updatedEntry = new TimetableEntry
                {
                    EntryID = _selectedEntryId,
                    SubjectID = (int)cmbSubjects.SelectedValue,
                    RoomID = (int)cmbRooms.SelectedValue,
                    Day = (DayOfWeek)cmbDays.SelectedItem,
                    StartTime = startTime,
                    EndTime = endTime
                };
                _timetableController.UpdateTimetableEntry(updatedEntry);
                MessageBox.Show("Timetable entry updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadTimetableEntries(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating timetable entry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            if (_selectedEntryId == -1)
            {
                MessageBox.Show("Please select a timetable entry to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete this timetable entry (ID: {_selectedEntryId})?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _timetableController.DeleteTimetableEntry(_selectedEntryId);
                    MessageBox.Show("Timetable entry deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadTimetableEntries(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting timetable entry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void TimetableForm_Load(object sender, EventArgs e)
        {
            // Initial loading done in constructor.
        }
    }
}