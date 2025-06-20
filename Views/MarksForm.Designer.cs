namespace UnicomTICManagementSystem.Views
{
    partial class MarksForm
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
            cmbStudents = new ComboBox();
            label2 = new Label();
            cmbExams = new ComboBox();
            label3 = new Label();
            txtScore = new TextBox();
            btnAddMark = new Button();
            btnUpdateMark = new Button();
            btnDeleteMark = new Button();
            dgvMarks = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMarks).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 58);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 0;
            label1.Text = "Student Name";
            // 
            // cmbStudents
            // 
            cmbStudents.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStudents.FormattingEnabled = true;
            cmbStudents.Location = new Point(174, 55);
            cmbStudents.Name = "cmbStudents";
            cmbStudents.Size = new Size(231, 28);
            cmbStudents.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 97);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 2;
            label2.Text = "Exam Name";
            // 
            // cmbExams
            // 
            cmbExams.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbExams.FormattingEnabled = true;
            cmbExams.Location = new Point(174, 94);
            cmbExams.Name = "cmbExams";
            cmbExams.Size = new Size(231, 28);
            cmbExams.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 135);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 4;
            label3.Text = "Score";
            // 
            // txtScore
            // 
            txtScore.Location = new Point(174, 132);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(231, 27);
            txtScore.TabIndex = 5;
            // 
            // btnAddMark
            // 
            btnAddMark.Location = new Point(440, 58);
            btnAddMark.Name = "btnAddMark";
            btnAddMark.Size = new Size(94, 29);
            btnAddMark.TabIndex = 6;
            btnAddMark.Text = "Add Mark";
            btnAddMark.UseVisualStyleBackColor = true;
            btnAddMark.Click += btnAddMark_Click;
            // 
            // btnUpdateMark
            // 
            btnUpdateMark.Location = new Point(549, 58);
            btnUpdateMark.Name = "btnUpdateMark";
            btnUpdateMark.Size = new Size(117, 29);
            btnUpdateMark.TabIndex = 7;
            btnUpdateMark.Text = "Update Mark";
            btnUpdateMark.UseVisualStyleBackColor = true;
            btnUpdateMark.Click += btnUpdateMark_Click;
            // 
            // btnDeleteMark
            // 
            btnDeleteMark.Location = new Point(677, 58);
            btnDeleteMark.Name = "btnDeleteMark";
            btnDeleteMark.Size = new Size(111, 29);
            btnDeleteMark.TabIndex = 8;
            btnDeleteMark.Text = "Delete Mark";
            btnDeleteMark.UseVisualStyleBackColor = true;
            btnDeleteMark.Click += btnDeleteMark_Click;
            // 
            // dgvMarks
            // 
            dgvMarks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMarks.Location = new Point(46, 189);
            dgvMarks.Name = "dgvMarks";
            dgvMarks.RowHeadersWidth = 51;
            dgvMarks.Size = new Size(675, 225);
            dgvMarks.TabIndex = 9;
            dgvMarks.CellClick += dgvMarks_CellClick;
            // 
            // MarksForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 450);
            Controls.Add(dgvMarks);
            Controls.Add(btnDeleteMark);
            Controls.Add(btnUpdateMark);
            Controls.Add(btnAddMark);
            Controls.Add(txtScore);
            Controls.Add(label3);
            Controls.Add(cmbExams);
            Controls.Add(label2);
            Controls.Add(cmbStudents);
            Controls.Add(label1);
            Name = "MarksForm";
            Text = "MarksForm";
            Load += MarksForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMarks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbStudents;
        private Label label2;
        private ComboBox cmbExams;
        private Label label3;
        private TextBox txtScore;
        private Button btnAddMark;
        private Button btnUpdateMark;
        private Button btnDeleteMark;
        private DataGridView dgvMarks;
    }
}