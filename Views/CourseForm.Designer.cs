namespace UnicomTICManagementSystem.Views
{
    partial class CourseForm
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
            label1 = new Label();
            txtCourseName = new TextBox();
            btnAddCourse = new Button();
            btnUpdateCourse = new Button();
            btnDeleteCourse = new Button();
            dgvCourses = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 52);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 0;
            label1.Text = "Course Name";
            // 
            // txtCourseName
            // 
            txtCourseName.Location = new Point(161, 49);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(277, 27);
            txtCourseName.TabIndex = 1;
            // 
            // btnAddCourse
            // 
            btnAddCourse.Location = new Point(41, 95);
            btnAddCourse.Name = "btnAddCourse";
            btnAddCourse.Size = new Size(166, 29);
            btnAddCourse.TabIndex = 2;
            btnAddCourse.Text = "Add Course";
            btnAddCourse.UseVisualStyleBackColor = true;
            btnAddCourse.Click += btnAddCourse_Click;
            // 
            // btnUpdateCourse
            // 
            btnUpdateCourse.Location = new Point(250, 95);
            btnUpdateCourse.Name = "btnUpdateCourse";
            btnUpdateCourse.Size = new Size(169, 29);
            btnUpdateCourse.TabIndex = 3;
            btnUpdateCourse.Text = "Update Course";
            btnUpdateCourse.UseVisualStyleBackColor = true;
            btnUpdateCourse.Click += btnUpdateCourse_Click;
            // 
            // btnDeleteCourse
            // 
            btnDeleteCourse.Location = new Point(460, 95);
            btnDeleteCourse.Name = "btnDeleteCourse";
            btnDeleteCourse.Size = new Size(156, 29);
            btnDeleteCourse.TabIndex = 4;
            btnDeleteCourse.Text = "Delete Course";
            btnDeleteCourse.UseVisualStyleBackColor = true;
            btnDeleteCourse.Click += btnDeleteCourse_Click;
            // 
            // dgvCourses
            // 
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourses.Location = new Point(41, 145);
            dgvCourses.Name = "dgvCourses";
            dgvCourses.RowHeadersWidth = 51;
            dgvCourses.Size = new Size(668, 281);
            dgvCourses.TabIndex = 5;
            dgvCourses.CellClick += dgvCourses_CellClick;
            // 
            // CourseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(783, 450);
            Controls.Add(dgvCourses);
            Controls.Add(btnDeleteCourse);
            Controls.Add(btnUpdateCourse);
            Controls.Add(btnAddCourse);
            Controls.Add(txtCourseName);
            Controls.Add(label1);
            Name = "CourseForm";
            Text = "CourseForm";
            Load += CourseForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCourseName;
        private Button btnAddCourse;
        private Button btnUpdateCourse;
        private Button btnDeleteCourse;
        private DataGridView dgvCourses;
    }
}