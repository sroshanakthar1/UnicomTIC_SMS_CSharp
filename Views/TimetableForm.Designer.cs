namespace UnicomTICManagementSystem.Views
{
    partial class TimetableForm
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
            dgvTimetable = new DataGridView();
            btnClear = new Button();
            btnDeleteEntry = new Button();
            btnUpdateEntry = new Button();
            btnAddEntry = new Button();
            label3 = new Label();
            cmbRooms = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            cmbSubjects = new ComboBox();
            cmbDays = new ComboBox();
            label4 = new Label();
            dtpStartTime = new DateTimePicker();
            label5 = new Label();
            dtpEndTime = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvTimetable).BeginInit();
            SuspendLayout();
            // 
            // dgvTimetable
            // 
            dgvTimetable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTimetable.Location = new Point(44, 206);
            dgvTimetable.Name = "dgvTimetable";
            dgvTimetable.RowHeadersWidth = 51;
            dgvTimetable.Size = new Size(744, 241);
            dgvTimetable.TabIndex = 32;
            dgvTimetable.CellClick += dgvTimetable_CellClick;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(694, 150);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 31;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDeleteEntry
            // 
            btnDeleteEntry.Location = new Point(587, 150);
            btnDeleteEntry.Name = "btnDeleteEntry";
            btnDeleteEntry.Size = new Size(94, 29);
            btnDeleteEntry.TabIndex = 30;
            btnDeleteEntry.Text = "Delete";
            btnDeleteEntry.UseVisualStyleBackColor = true;
            btnDeleteEntry.Click += btnDeleteEntry_Click;
            // 
            // btnUpdateEntry
            // 
            btnUpdateEntry.Location = new Point(477, 150);
            btnUpdateEntry.Name = "btnUpdateEntry";
            btnUpdateEntry.Size = new Size(94, 29);
            btnUpdateEntry.TabIndex = 29;
            btnUpdateEntry.Text = "Update";
            btnUpdateEntry.UseVisualStyleBackColor = true;
            btnUpdateEntry.Click += btnUpdateEntry_Click;
            // 
            // btnAddEntry
            // 
            btnAddEntry.Location = new Point(368, 150);
            btnAddEntry.Name = "btnAddEntry";
            btnAddEntry.Size = new Size(94, 29);
            btnAddEntry.TabIndex = 28;
            btnAddEntry.Text = "Add";
            btnAddEntry.UseVisualStyleBackColor = true;
            btnAddEntry.Click += btnAddEntry_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 154);
            label3.Name = "label3";
            label3.Size = new Size(35, 20);
            label3.TabIndex = 26;
            label3.Text = "Day";
            // 
            // cmbRooms
            // 
            cmbRooms.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRooms.FormattingEnabled = true;
            cmbRooms.Location = new Point(127, 98);
            cmbRooms.Name = "cmbRooms";
            cmbRooms.Size = new Size(183, 28);
            cmbRooms.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 101);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 24;
            label2.Text = "Room";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 52);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 22;
            label1.Text = "Subject";
            // 
            // cmbSubjects
            // 
            cmbSubjects.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubjects.FormattingEnabled = true;
            cmbSubjects.Location = new Point(127, 49);
            cmbSubjects.Name = "cmbSubjects";
            cmbSubjects.Size = new Size(183, 28);
            cmbSubjects.TabIndex = 33;
            // 
            // cmbDays
            // 
            cmbDays.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDays.FormattingEnabled = true;
            cmbDays.Location = new Point(127, 151);
            cmbDays.Name = "cmbDays";
            cmbDays.Size = new Size(183, 28);
            cmbDays.TabIndex = 34;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(368, 55);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 35;
            label4.Text = "Start Time";
            // 
            // dtpStartTime
            // 
            dtpStartTime.Format = DateTimePickerFormat.Time;
            dtpStartTime.Location = new Point(477, 50);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(245, 27);
            dtpStartTime.TabIndex = 36;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(368, 104);
            label5.Name = "label5";
            label5.Size = new Size(71, 20);
            label5.TabIndex = 37;
            label5.Text = "End Time";
            // 
            // dtpEndTime
            // 
            dtpEndTime.Format = DateTimePickerFormat.Time;
            dtpEndTime.Location = new Point(477, 99);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(245, 27);
            dtpEndTime.TabIndex = 38;
            // 
            // TimetableForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 477);
            Controls.Add(dtpEndTime);
            Controls.Add(label5);
            Controls.Add(dtpStartTime);
            Controls.Add(label4);
            Controls.Add(cmbDays);
            Controls.Add(cmbSubjects);
            Controls.Add(dgvTimetable);
            Controls.Add(btnClear);
            Controls.Add(btnDeleteEntry);
            Controls.Add(btnUpdateEntry);
            Controls.Add(btnAddEntry);
            Controls.Add(label3);
            Controls.Add(cmbRooms);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TimetableForm";
            Text = "TimetableForm";
            Load += TimetableForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTimetable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTimetable;
        private Button btnClear;
        private Button btnDeleteEntry;
        private Button btnUpdateEntry;
        private Button btnAddEntry;
        private Label label3;
        private ComboBox cmbRooms;
        private Label label2;
        private Label label1;
        private ComboBox cmbSubjects;
        private ComboBox cmbDays;
        private Label label4;
        private DateTimePicker dtpStartTime;
        private Label label5;
        private DateTimePicker dtpEndTime;
    }
}