using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Windows.Forms;
using UnicomTICManagementSystem.Controllers; // To use the LoginController
using UnicomTICManagementSystem.Models;
using UnicomTICManagementSystem.Repositories;// To use the User model

namespace UnicomTICManagementSystem.Views
{
    public partial class LoginForm : Form
    {
        private DatabaseManager _dbManager;
        private readonly LoginController _loginController;

        public LoginForm()
        {
            InitializeComponent(); // Initializes the UI components defined in the designer
            _dbManager = new DatabaseManager();
            _loginController = new LoginController(); // Creates an instance of our LoginController
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // <--- Call DatabaseManager directly, and handle nullable User?
            UnicomTICManagementSystem.Models.User? authenticatedUser = _dbManager.GetUserByUsernameAndPassword(username, password);

            if (authenticatedUser != null)
            {
                // Successfully logged in
                //MessageBox.Show($"Welcome, {authenticatedUser.Username} ({authenticatedUser.Role})!", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Pass the authenticated User object to the MainForm
                MainForm mainForm = new MainForm(authenticatedUser);
                this.Hide(); // Hide the login form
                mainForm.ShowDialog(); // Show the main form
                this.Close(); // Close the login form when MainForm closes
            }
            else
            {
                // Login failed
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}