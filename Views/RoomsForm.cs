using System;
using System.Windows.Forms;
using System.Collections.Generic; // For List<T>
using UnicomTICManagementSystem.Controllers; // To use the RoomController
using UnicomTICManagementSystem.Models;     // To use the Room model

namespace UnicomTICManagementSystem.Views
{
    public partial class RoomsForm : Form
    {
        private readonly RoomController _roomController;
        private int _selectedRoomId = -1; // To store the ID of the selected room for update/delete
        private User _currentUser;
        public RoomsForm(User currentUser)
        {
            InitializeComponent();
            _roomController = new RoomController();

            // Setup DataGridView
            SetupDataGridView();

            // Populate Room Type ComboBox
            PopulateRoomTypeComboBox();

            // Load rooms into DataGridView when the form starts
            LoadRooms();
            ClearForm(); // Initialize buttons and fields
            _currentUser = currentUser;
        }

        private void SetupDataGridView()
        {
            dgvRooms.AutoGenerateColumns = false; // We'll define columns manually
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Select full row
            dgvRooms.ReadOnly = true; // Make it read-only
            dgvRooms.AllowUserToAddRows = false; // Prevent adding rows directly in the grid
            dgvRooms.MultiSelect = false; // Only one row can be selected at a time

            // Define columns
            dgvRooms.Columns.Add("RoomID", "ID");
            dgvRooms.Columns["RoomID"].DataPropertyName = "RoomID";
            dgvRooms.Columns["RoomID"].Visible = true; // Keep ID visible for easier debugging

            dgvRooms.Columns.Add("RoomName", "Room Name");
            dgvRooms.Columns["RoomName"].DataPropertyName = "RoomName";
            dgvRooms.Columns["RoomName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvRooms.Columns.Add("RoomType", "Type");
            dgvRooms.Columns["RoomType"].DataPropertyName = "RoomType";
            dgvRooms.Columns["RoomType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvRooms.Columns.Add("Capacity", "Capacity");
            dgvRooms.Columns["Capacity"].DataPropertyName = "Capacity";
            dgvRooms.Columns["Capacity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Event handler for selecting a row
            dgvRooms.CellClick += dgvRooms_CellClick;
        }

        private void PopulateRoomTypeComboBox()
        {
            // Add predefined room types
            cmbRoomType.Items.Add("Lab");
            cmbRoomType.Items.Add("Lecture Hall");
            cmbRoomType.SelectedIndex = -1; // No item selected initially
        }

        private void LoadRooms()
        {
            try
            {
                List<Room> rooms = _roomController.GetAllRooms();
                dgvRooms.DataSource = rooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading rooms: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtRoomName.Text = string.Empty;
            cmbRoomType.SelectedIndex = -1; // Deselect room type
            txtCapacity.Text = string.Empty;
            _selectedRoomId = -1; // Reset selected ID

            btnAddRoom.Enabled = true; // Enable Add button
            btnUpdateRoom.Enabled = false; // Disable Update button
            btnDeleteRoom.Enabled = false; // Disable Delete button
        }

        // Event handler for when a cell in the DataGridView is clicked
        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                DataGridViewRow row = dgvRooms.Rows[e.RowIndex];
                _selectedRoomId = (int)row.Cells["RoomID"].Value;

                txtRoomName.Text = row.Cells["RoomName"].Value.ToString();
                cmbRoomType.SelectedItem = row.Cells["RoomType"].Value.ToString(); // Set selected type
                txtCapacity.Text = row.Cells["Capacity"].Value.ToString();

                // Enable update/delete buttons when a row is selected
                btnAddRoom.Enabled = false;
                btnUpdateRoom.Enabled = true;
                btnDeleteRoom.Enabled = true;
            }
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoomName.Text) || cmbRoomType.SelectedItem == null || !int.TryParse(txtCapacity.Text.Trim(), out int capacity) || capacity <= 0)
            {
                MessageBox.Show("Please fill all fields correctly. Capacity must be a positive number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Room newRoom = new Room
                {
                    RoomName = txtRoomName.Text.Trim(),
                    RoomType = cmbRoomType.SelectedItem.ToString(),
                    Capacity = capacity
                };
                _roomController.AddRoom(newRoom);
                MessageBox.Show("Room added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadRooms(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            if (_selectedRoomId == -1)
            {
                MessageBox.Show("Please select a room to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRoomName.Text) || cmbRoomType.SelectedItem == null || !int.TryParse(txtCapacity.Text.Trim(), out int capacity) || capacity <= 0)
            {
                MessageBox.Show("Please fill all fields correctly. Capacity must be a positive number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Room updatedRoom = new Room
                {
                    RoomID = _selectedRoomId,
                    RoomName = txtRoomName.Text.Trim(),
                    RoomType = cmbRoomType.SelectedItem.ToString(),
                    Capacity = capacity
                };
                _roomController.UpdateRoom(updatedRoom);
                MessageBox.Show("Room updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadRooms(); // Refresh the DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (_selectedRoomId == -1)
            {
                MessageBox.Show("Please select a room to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete room '{txtRoomName.Text}' (ID: {_selectedRoomId})?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _roomController.DeleteRoom(_selectedRoomId);
                    MessageBox.Show("Room deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadRooms(); // Refresh the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void RoomsForm_Load(object sender, EventArgs e)
        {
            // Initial loading done in constructor.
        }
    }
}