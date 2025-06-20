namespace UnicomTICManagementSystem.Views
{
    partial class TimetableHubForm
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
            btnManageRooms = new Button();
            btnManageTimetable = new Button();
            SuspendLayout();
            // 
            // btnManageRooms
            // 
            btnManageRooms.BackColor = SystemColors.ActiveCaption;
            btnManageRooms.Location = new Point(144, 147);
            btnManageRooms.Name = "btnManageRooms";
            btnManageRooms.Size = new Size(225, 69);
            btnManageRooms.TabIndex = 0;
            btnManageRooms.Text = "Manage Rooms";
            btnManageRooms.UseVisualStyleBackColor = false;
            btnManageRooms.Click += btnManageRooms_Click;
            // 
            // btnManageTimetable
            // 
            btnManageTimetable.BackColor = SystemColors.ActiveCaption;
            btnManageTimetable.Location = new Point(417, 147);
            btnManageTimetable.Name = "btnManageTimetable";
            btnManageTimetable.Size = new Size(225, 69);
            btnManageTimetable.TabIndex = 1;
            btnManageTimetable.Text = "Manage Timetable";
            btnManageTimetable.UseVisualStyleBackColor = false;
            btnManageTimetable.Click += btnManageTimetable_Click;
            // 
            // TimetableHubForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnManageTimetable);
            Controls.Add(btnManageRooms);
            Name = "TimetableHubForm";
            Text = "TimetableHubForm";
            Load += TimetableHubForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnManageRooms;
        private Button btnManageTimetable;
    }
}