namespace UnicomTICManagementSystem.Views
{
    partial class ExamMarksHubForm
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
            btnManageExams = new Button();
            btnManageMarks = new Button();
            SuspendLayout();
            // 
            // btnManageExams
            // 
            btnManageExams.BackColor = SystemColors.ActiveCaption;
            btnManageExams.Location = new Point(106, 155);
            btnManageExams.Name = "btnManageExams";
            btnManageExams.Size = new Size(238, 73);
            btnManageExams.TabIndex = 0;
            btnManageExams.Text = "Manage Exams";
            btnManageExams.UseVisualStyleBackColor = false;
            btnManageExams.Click += btnManageExams_Click;
            // 
            // btnManageMarks
            // 
            btnManageMarks.BackColor = SystemColors.ActiveCaption;
            btnManageMarks.Location = new Point(385, 155);
            btnManageMarks.Name = "btnManageMarks";
            btnManageMarks.Size = new Size(238, 73);
            btnManageMarks.TabIndex = 1;
            btnManageMarks.Text = "Manage Marks";
            btnManageMarks.UseVisualStyleBackColor = false;
            btnManageMarks.Click += btnManageMarks_Click;
            // 
            // ExamMarksHubForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnManageMarks);
            Controls.Add(btnManageExams);
            Name = "ExamMarksHubForm";
            Text = "ExamMarksHubForm";
            Load += ExamMarksHubForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnManageExams;
        private Button btnManageMarks;
    }
}