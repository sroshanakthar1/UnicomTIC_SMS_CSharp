namespace UnicomTICManagementSystem.Views
{
    partial class SubjectForm
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
            txtSubjectName = new TextBox();
            label2 = new Label();
            cmbCourses = new ComboBox();
            btnAddSubject = new Button();
            btnUpdateSubject = new Button();
            btnDeleteSubject = new Button();
            dgvSubjects = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 51);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 0;
            label1.Text = "Subject Name";
            // 
            // txtSubjectName
            // 
            txtSubjectName.Location = new Point(174, 48);
            txtSubjectName.Name = "txtSubjectName";
            txtSubjectName.Size = new Size(151, 27);
            txtSubjectName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 95);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 2;
            label2.Text = "Course";
            // 
            // cmbCourses
            // 
            cmbCourses.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourses.FormattingEnabled = true;
            cmbCourses.Location = new Point(174, 92);
            cmbCourses.Name = "cmbCourses";
            cmbCourses.Size = new Size(151, 28);
            cmbCourses.TabIndex = 3;
            // 
            // btnAddSubject
            // 
            btnAddSubject.Location = new Point(353, 47);
            btnAddSubject.Name = "btnAddSubject";
            btnAddSubject.Size = new Size(119, 29);
            btnAddSubject.TabIndex = 4;
            btnAddSubject.Text = "Add Subjects";
            btnAddSubject.UseVisualStyleBackColor = true;
            btnAddSubject.Click += btnAddSubject_Click;
            // 
            // btnUpdateSubject
            // 
            btnUpdateSubject.Location = new Point(486, 47);
            btnUpdateSubject.Name = "btnUpdateSubject";
            btnUpdateSubject.Size = new Size(120, 29);
            btnUpdateSubject.TabIndex = 5;
            btnUpdateSubject.Text = "Update Subject";
            btnUpdateSubject.UseVisualStyleBackColor = true;
            btnUpdateSubject.Click += btnUpdateSubject_Click;
            // 
            // btnDeleteSubject
            // 
            btnDeleteSubject.Location = new Point(623, 47);
            btnDeleteSubject.Name = "btnDeleteSubject";
            btnDeleteSubject.Size = new Size(127, 29);
            btnDeleteSubject.TabIndex = 6;
            btnDeleteSubject.Text = "Delete Subject";
            btnDeleteSubject.UseVisualStyleBackColor = true;
            btnDeleteSubject.Click += btnDeleteSubject_Click;
            // 
            // dgvSubjects
            // 
            dgvSubjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubjects.Location = new Point(46, 147);
            dgvSubjects.Name = "dgvSubjects";
            dgvSubjects.RowHeadersWidth = 51;
            dgvSubjects.Size = new Size(704, 272);
            dgvSubjects.TabIndex = 7;
            dgvSubjects.CellClick += dgvSubjects_CellClick;
            // 
            // SubjectForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvSubjects);
            Controls.Add(btnDeleteSubject);
            Controls.Add(btnUpdateSubject);
            Controls.Add(btnAddSubject);
            Controls.Add(cmbCourses);
            Controls.Add(label2);
            Controls.Add(txtSubjectName);
            Controls.Add(label1);
            Name = "SubjectForm";
            Text = "SubjectForm";
            Load += SubjectForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSubjectName;
        private Label label2;
        private ComboBox cmbCourses;
        private Button btnAddSubject;
        private Button btnUpdateSubject;
        private Button btnDeleteSubject;
        private DataGridView dgvSubjects;
    }
}