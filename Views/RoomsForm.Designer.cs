namespace UnicomTICManagementSystem.Views
{
    partial class RoomsForm
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
            dgvRooms = new DataGridView();
            btnClear = new Button();
            btnDeleteRoom = new Button();
            btnUpdateRoom = new Button();
            btnAddRoom = new Button();
            txtCapacity = new TextBox();
            label3 = new Label();
            cmbRoomType = new ComboBox();
            label2 = new Label();
            txtRoomName = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            SuspendLayout();
            // 
            // dgvRooms
            // 
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRooms.Location = new Point(47, 183);
            dgvRooms.Name = "dgvRooms";
            dgvRooms.RowHeadersWidth = 51;
            dgvRooms.Size = new Size(679, 237);
            dgvRooms.TabIndex = 21;
            dgvRooms.CellClick += dgvRooms_CellClick;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(378, 124);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 20;
            btnClear.Text = "Clear Form";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDeleteRoom
            // 
            btnDeleteRoom.Location = new Point(621, 78);
            btnDeleteRoom.Name = "btnDeleteRoom";
            btnDeleteRoom.Size = new Size(130, 29);
            btnDeleteRoom.TabIndex = 19;
            btnDeleteRoom.Text = "Delete Room";
            btnDeleteRoom.UseVisualStyleBackColor = true;
            btnDeleteRoom.Click += btnDeleteRoom_Click;
            // 
            // btnUpdateRoom
            // 
            btnUpdateRoom.Location = new Point(490, 78);
            btnUpdateRoom.Name = "btnUpdateRoom";
            btnUpdateRoom.Size = new Size(112, 29);
            btnUpdateRoom.TabIndex = 18;
            btnUpdateRoom.Text = "Update Room";
            btnUpdateRoom.UseVisualStyleBackColor = true;
            btnUpdateRoom.Click += btnUpdateRoom_Click;
            // 
            // btnAddRoom
            // 
            btnAddRoom.Location = new Point(378, 78);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(96, 29);
            btnAddRoom.TabIndex = 17;
            btnAddRoom.Text = "Add Room";
            btnAddRoom.UseVisualStyleBackColor = true;
            btnAddRoom.Click += btnAddRoom_Click;
            // 
            // txtCapacity
            // 
            txtCapacity.Location = new Point(157, 126);
            txtCapacity.Name = "txtCapacity";
            txtCapacity.Size = new Size(183, 27);
            txtCapacity.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 129);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 15;
            label3.Text = "Capacity";
            // 
            // cmbRoomType
            // 
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(157, 79);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(183, 28);
            cmbRoomType.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 82);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 13;
            label2.Text = "Room Type";
            // 
            // txtRoomName
            // 
            txtRoomName.Location = new Point(157, 38);
            txtRoomName.Name = "txtRoomName";
            txtRoomName.Size = new Size(183, 27);
            txtRoomName.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 41);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 11;
            label1.Text = "Room Name";
            // 
            // RoomsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvRooms);
            Controls.Add(btnClear);
            Controls.Add(btnDeleteRoom);
            Controls.Add(btnUpdateRoom);
            Controls.Add(btnAddRoom);
            Controls.Add(txtCapacity);
            Controls.Add(label3);
            Controls.Add(cmbRoomType);
            Controls.Add(label2);
            Controls.Add(txtRoomName);
            Controls.Add(label1);
            Name = "RoomsForm";
            Text = "RoomsForm";
            Load += RoomsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRooms;
        private Button btnClear;
        private Button btnDeleteRoom;
        private Button btnUpdateRoom;
        private Button btnAddRoom;
        private TextBox txtCapacity;
        private Label label3;
        private ComboBox cmbRoomType;
        private Label label2;
        private TextBox txtRoomName;
        private Label label1;
    }
}