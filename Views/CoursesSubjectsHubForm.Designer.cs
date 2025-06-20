namespace UnicomTICManagementSystem.Views
{
    partial class CoursesSubjectsHubForm
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
            btnManageCourses = new Button();
            btnManageSubjects = new Button();
            SuspendLayout();
            // 
            // btnManageCourses
            // 
            btnManageCourses.BackColor = SystemColors.ActiveCaption;
            btnManageCourses.Location = new Point(108, 136);
            btnManageCourses.Name = "btnManageCourses";
            btnManageCourses.Size = new Size(238, 65);
            btnManageCourses.TabIndex = 0;
            btnManageCourses.Text = "Manage Courses";
            btnManageCourses.UseVisualStyleBackColor = false;
            btnManageCourses.Click += btnManageCourses_Click;
            // 
            // btnManageSubjects
            // 
            btnManageSubjects.BackColor = SystemColors.ActiveCaption;
            btnManageSubjects.Location = new Point(393, 136);
            btnManageSubjects.Name = "btnManageSubjects";
            btnManageSubjects.Size = new Size(238, 65);
            btnManageSubjects.TabIndex = 1;
            btnManageSubjects.Text = "Manage Subjects";
            btnManageSubjects.UseVisualStyleBackColor = false;
            btnManageSubjects.Click += btnManageSubjects_Click;
            // 
            // CoursesSubjectsHubForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnManageSubjects);
            Controls.Add(btnManageCourses);
            Name = "CoursesSubjectsHubForm";
            Text = "CoursesSubjectsHubForm";
            Load += CoursesSubjectsHubForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnManageCourses;
        private Button btnManageSubjects;
    }
}