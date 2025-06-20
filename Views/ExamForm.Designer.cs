namespace UnicomTICManagementSystem.Views
{
    partial class ExamForm
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
            txtExamName = new TextBox();
            label2 = new Label();
            cmbSubjects = new ComboBox();
            btnAddExam = new Button();
            btnUpdateExam = new Button();
            dgvExams = new DataGridView();
            btnDeleteExam = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvExams).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 38);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 0;
            label1.Text = "Exam Name";
            // 
            // txtExamName
            // 
            txtExamName.Location = new Point(147, 35);
            txtExamName.Name = "txtExamName";
            txtExamName.Size = new Size(232, 27);
            txtExamName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 79);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 2;
            label2.Text = "Subject";
            // 
            // cmbSubjects
            // 
            cmbSubjects.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubjects.FormattingEnabled = true;
            cmbSubjects.Location = new Point(147, 76);
            cmbSubjects.Name = "cmbSubjects";
            cmbSubjects.Size = new Size(232, 28);
            cmbSubjects.TabIndex = 3;
            // 
            // btnAddExam
            // 
            btnAddExam.Location = new Point(43, 121);
            btnAddExam.Name = "btnAddExam";
            btnAddExam.Size = new Size(125, 29);
            btnAddExam.TabIndex = 4;
            btnAddExam.Text = "Add Exam";
            btnAddExam.UseVisualStyleBackColor = true;
            btnAddExam.Click += btnAddExam_Click;
            // 
            // btnUpdateExam
            // 
            btnUpdateExam.Location = new Point(194, 121);
            btnUpdateExam.Name = "btnUpdateExam";
            btnUpdateExam.Size = new Size(128, 29);
            btnUpdateExam.TabIndex = 5;
            btnUpdateExam.Text = "Update Exam";
            btnUpdateExam.UseVisualStyleBackColor = true;
            btnUpdateExam.Click += btnUpdateExam_Click;
            // 
            // dgvExams
            // 
            dgvExams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExams.Location = new Point(43, 173);
            dgvExams.Name = "dgvExams";
            dgvExams.RowHeadersWidth = 51;
            dgvExams.Size = new Size(687, 246);
            dgvExams.TabIndex = 7;
            dgvExams.CellClick += dgvExams_CellClick;
            // 
            // btnDeleteExam
            // 
            btnDeleteExam.Location = new Point(365, 121);
            btnDeleteExam.Name = "btnDeleteExam";
            btnDeleteExam.Size = new Size(128, 29);
            btnDeleteExam.TabIndex = 8;
            btnDeleteExam.Text = "Delete Exam";
            btnDeleteExam.UseVisualStyleBackColor = true;
            btnDeleteExam.Click += btnDeleteExam_Click;
            // 
            // ExamForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDeleteExam);
            Controls.Add(dgvExams);
            Controls.Add(btnUpdateExam);
            Controls.Add(btnAddExam);
            Controls.Add(cmbSubjects);
            Controls.Add(label2);
            Controls.Add(txtExamName);
            Controls.Add(label1);
            Name = "ExamForm";
            Text = "ExamForm";
            Load += ExamForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvExams).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtExamName;
        private Label label2;
        private ComboBox cmbSubjects;
        private Button btnAddExam;
        private Button btnUpdateExam;
        private DataGridView dgvExams;
        private Button btnDeleteExam;
    }
}