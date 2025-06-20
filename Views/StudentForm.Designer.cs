namespace UnicomTICManagementSystem.Views
{
    partial class StudentForm
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
            txtStudentName = new TextBox();
            label2 = new Label();
            cmbCourses = new ComboBox();
            btnAddStudent = new Button();
            btnUpdateStudent = new Button();
            btnDeleteStudent = new Button();
            dgvStudents = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 55);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 0;
            label1.Text = "Student Name";
            // 
            // txtStudentName
            // 
            txtStudentName.Location = new Point(158, 53);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.Size = new Size(197, 27);
            txtStudentName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 99);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 2;
            label2.Text = "Course";
            // 
            // cmbCourses
            // 
            cmbCourses.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourses.FormattingEnabled = true;
            cmbCourses.Location = new Point(158, 96);
            cmbCourses.Name = "cmbCourses";
            cmbCourses.Size = new Size(197, 28);
            cmbCourses.TabIndex = 3;
            // 
            // btnAddStudent
            // 
            btnAddStudent.Location = new Point(392, 52);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(112, 29);
            btnAddStudent.TabIndex = 4;
            btnAddStudent.Text = "Add Student";
            btnAddStudent.UseVisualStyleBackColor = true;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // btnUpdateStudent
            // 
            btnUpdateStudent.Location = new Point(510, 51);
            btnUpdateStudent.Name = "btnUpdateStudent";
            btnUpdateStudent.Size = new Size(128, 29);
            btnUpdateStudent.TabIndex = 5;
            btnUpdateStudent.Text = "Update Student";
            btnUpdateStudent.UseVisualStyleBackColor = true;
            btnUpdateStudent.Click += btnUpdateStudent_Click;
            // 
            // btnDeleteStudent
            // 
            btnDeleteStudent.Location = new Point(644, 51);
            btnDeleteStudent.Name = "btnDeleteStudent";
            btnDeleteStudent.Size = new Size(121, 29);
            btnDeleteStudent.TabIndex = 6;
            btnDeleteStudent.Text = "Delete Student";
            btnDeleteStudent.UseVisualStyleBackColor = true;
            btnDeleteStudent.Click += btnDeleteStudent_Click;
            // 
            // dgvStudents
            // 
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(48, 167);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.Size = new Size(717, 251);
            dgvStudents.TabIndex = 7;
            dgvStudents.CellClick += dgvStudents_CellClick;
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvStudents);
            Controls.Add(btnDeleteStudent);
            Controls.Add(btnUpdateStudent);
            Controls.Add(btnAddStudent);
            Controls.Add(cmbCourses);
            Controls.Add(label2);
            Controls.Add(txtStudentName);
            Controls.Add(label1);
            Name = "StudentForm";
            Text = "StudentForm";
            Load += StudentForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtStudentName;
        private Label label2;
        private ComboBox cmbCourses;
        private Button btnAddStudent;
        private Button btnUpdateStudent;
        private Button btnDeleteStudent;
        private DataGridView dgvStudents;
    }
}