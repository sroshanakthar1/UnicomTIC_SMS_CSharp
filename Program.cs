using System;
using System.Windows.Forms;
using UnicomTICManagementSystem.Repositories; // Make sure this is correct for your project
using UnicomTICManagementSystem.Views;       // Make sure this is correct for your project

namespace UnicomTICManagementSystem // This MUST match your main project's namespace
{
    static class Program // The class containing Main must be static
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread] // Essential for Windows Forms applications
        static void Main() // Changed to static void Main() as you suggested
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize the database
            var dbManager = new DatabaseManager();
            try
            {
                // Calling the async method synchronously using .Wait()
                // This will block the UI thread until initialization is complete,
                // but directly addresses the requirement for static void Main().
                dbManager.InitializeDatabase();
                Console.WriteLine("Database initialization complete.");
            }
            catch (Exception ex)
            {
                // Display a message if database initialization fails
                MessageBox.Show($"Database initialization failed: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the application if database cannot be initialized
            }

            // This line tells the application to start by running your LoginForm
            Application.Run(new LoginForm());
        }
    }
}