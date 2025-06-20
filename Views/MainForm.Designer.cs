namespace UnicomTICManagementSystem.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCourses = new Button();
            btnStudents = new Button();
            btnExamsMarks = new Button();
            btnTimetable = new Button();
            lblWelcome = new Label();
            btnUserManagement = new Button();
            lblLoggedInUser = new Label();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // btnCourses
            // 
            btnCourses.BackColor = SystemColors.ActiveCaption;
            btnCourses.ForeColor = Color.Black;
            btnCourses.Location = new Point(111, 96);
            btnCourses.Name = "btnCourses";
            btnCourses.Size = new Size(244, 99);
            btnCourses.TabIndex = 0;
            btnCourses.Text = "Manage Courses";
            btnCourses.UseVisualStyleBackColor = false;
            btnCourses.Click += btnCourses_Click;
            // 
            // btnStudents
            // 
            btnStudents.BackColor = SystemColors.ActiveCaption;
            btnStudents.Location = new Point(418, 96);
            btnStudents.Name = "btnStudents";
            btnStudents.Size = new Size(244, 99);
            btnStudents.TabIndex = 1;
            btnStudents.Text = "Manage Students";
            btnStudents.UseVisualStyleBackColor = false;
            btnStudents.Click += btnStudents_Click;
            // 
            // btnExamsMarks
            // 
            btnExamsMarks.BackColor = SystemColors.ActiveCaption;
            btnExamsMarks.Location = new Point(111, 217);
            btnExamsMarks.Name = "btnExamsMarks";
            btnExamsMarks.Size = new Size(244, 99);
            btnExamsMarks.TabIndex = 2;
            btnExamsMarks.Text = "Manage Exams and Marks";
            btnExamsMarks.UseVisualStyleBackColor = false;
            btnExamsMarks.Click += btnExamsMarks_Click;
            // 
            // btnTimetable
            // 
            btnTimetable.BackColor = SystemColors.ActiveCaption;
            btnTimetable.Location = new Point(418, 217);
            btnTimetable.Name = "btnTimetable";
            btnTimetable.Size = new Size(244, 99);
            btnTimetable.TabIndex = 3;
            btnTimetable.Text = "Manage Timetable";
            btnTimetable.UseVisualStyleBackColor = false;
            btnTimetable.Click += btnTimetable_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Stencil", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(216, 41);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(158, 33);
            lblWelcome.TabIndex = 4;
            lblWelcome.Text = "Welcome!";
            // 
            // btnUserManagement
            // 
            btnUserManagement.BackColor = SystemColors.Info;
            btnUserManagement.Location = new Point(553, 398);
            btnUserManagement.Name = "btnUserManagement";
            btnUserManagement.Size = new Size(220, 72);
            btnUserManagement.TabIndex = 5;
            btnUserManagement.Text = "Manage User";
            btnUserManagement.UseVisualStyleBackColor = false;
            btnUserManagement.Click += btnUserManagement_Click;
            // 
            // lblLoggedInUser
            // 
            lblLoggedInUser.AutoSize = true;
            lblLoggedInUser.Location = new Point(53, 409);
            lblLoggedInUser.Name = "lblLoggedInUser";
            lblLoggedInUser.Size = new Size(38, 20);
            lblLoggedInUser.TabIndex = 6;
            lblLoggedInUser.Text = "User";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = SystemColors.AppWorkspace;
            btnLogout.Location = new Point(53, 441);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 490);
            Controls.Add(btnLogout);
            Controls.Add(lblLoggedInUser);
            Controls.Add(btnUserManagement);
            Controls.Add(lblWelcome);
            Controls.Add(btnTimetable);
            Controls.Add(btnExamsMarks);
            Controls.Add(btnStudents);
            Controls.Add(btnCourses);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCourses;
        private Button btnStudents;
        private Button btnExamsMarks;
        private Button btnTimetable;
        private Label lblWelcome;
        private Button btnUserManagement;
        private Label lblLoggedInUser;
        private Button btnLogout;
    }
}