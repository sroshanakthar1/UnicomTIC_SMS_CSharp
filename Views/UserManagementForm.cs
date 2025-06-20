using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UnicomTICManagementSystem.Models; 
using UnicomTICManagementSystem.Controllers; 

namespace UnicomTICManagementSystem.Views
{
    public partial class UserManagementForm : Form
    {
        private User _currentUser; 
        private UserController _userController; 

        
        public UserManagementForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _userController = new UserController(); 

            // Populate the Role ComboBox
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Staff");
            cmbRole.Items.Add("Lecturer");
            cmbRole.Items.Add("Student");
            cmbRole.SelectedIndex = 0; // Set a default selection

            ApplyUserManagementPermissions(); // Apply permissions based on _currentUser's role
            LoadUsers(); // Load users into the DataGridView
        }

        // --- Permissions Logic ---
        private void ApplyUserManagementPermissions()
        {
            // By default, assume no access (hide/disable everything)
            btnAdd.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnClear.Visible = false; // Even clear should be restricted if no access

            txtUserID.ReadOnly = true;
            txtUsername.ReadOnly = true;
            txtPassword.ReadOnly = true;
            cmbRole.Enabled = false;
            lblRole.Visible = false; // Hide label for Role
            cmbRole.Visible = false; // Hide ComboBox for Role

            dgvUsers.ReadOnly = true;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;

            // Only Admin has full access to User Management
            if (_currentUser.Role == "Admin")
            {
                btnAdd.Visible = true;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnClear.Visible = true;

                txtUsername.ReadOnly = false;
                txtPassword.ReadOnly = false;
                cmbRole.Enabled = true;
                lblRole.Visible = true;
                cmbRole.Visible = true;

                dgvUsers.ReadOnly = false; // Admin can edit directly in DGV if allowed by column settings
                dgvUsers.AllowUserToAddRows = true;
                dgvUsers.AllowUserToDeleteRows = true;
            }
            else
            {
                // For Staff, Lecturer, Student, deny access and close the form.
                MessageBox.Show("You do not have permission to manage user accounts.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close(); // Close the form immediately
            }
        }

        // --- Data Loading ---
        private void LoadUsers()
        {
            try
            {
                // Retrieve all users from the controller
                List<User> users = _userController.GetAllUsers();
                // Bind the list of users to the DataGridView
                dgvUsers.DataSource = users;

                // Optional: Hide password column for security in UI, unless strictly needed for admin
                if (dgvUsers.Columns.Contains("Password"))
                {
                    dgvUsers.Columns["Password"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Clear Fields ---
        private void ClearFields()
        {
            txtUserID.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            cmbRole.SelectedIndex = 0; // Reset to first role
            btnAdd.Enabled = true;    // Enable Add button after clearing
            btnUpdate.Enabled = false; // Disable Update
            btnDelete.Enabled = false; // Disable Delete
        }

        // --- Event Handlers ---

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields (Username, Password, Role).", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User newUser = new User
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text, 
                Role = cmbRole.SelectedItem.ToString()
            };

            try
            {
                _userController.AddUser(newUser);
                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(txtUserID.Text) || string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please select a user and fill in all fields to update.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User updatedUser = new User
            {
                UserID = int.Parse(txtUserID.Text),
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text, 
                Role = cmbRole.SelectedItem.ToString()
            };

            try
            {
                _userController.UpdateUser(updatedUser);
                MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserID.Text))
            {
                MessageBox.Show("Please select a user to delete.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int userIdToDelete = int.Parse(txtUserID.Text);
                    _userController.DeleteUser(userIdToDelete);
                    MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                txtUserID.Text = row.Cells["UserID"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString(); 
                cmbRole.SelectedItem = row.Cells["Role"].Value.ToString();

                btnAdd.Enabled = false; 
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {

        }
    }
}