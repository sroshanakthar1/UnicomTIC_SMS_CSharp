namespace UnicomTICManagementSystem.Views
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            lblUsername = new Label();
            lblPassword = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            UnicomTICLogo = new PictureBox();
            Cover = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)UnicomTICLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Cover).BeginInit();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(115, 220);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(82, 20);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username :";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(115, 273);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(77, 20);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password :";
            // 
            // txtUsername
            // 
            txtUsername.ForeColor = Color.Black;
            txtUsername.Location = new Point(216, 213);
            txtUsername.Name = "txtUsername";
            txtUsername.RightToLeft = RightToLeft.No;
            txtUsername.Size = new Size(247, 27);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(216, 270);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(247, 27);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(216, 335);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // UnicomTICLogo
            // 
            UnicomTICLogo.Image = (Image)resources.GetObject("UnicomTICLogo.Image");
            UnicomTICLogo.Location = new Point(4, 4);
            UnicomTICLogo.Name = "UnicomTICLogo";
            UnicomTICLogo.Size = new Size(186, 180);
            UnicomTICLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            UnicomTICLogo.TabIndex = 5;
            UnicomTICLogo.TabStop = false;
            // 
            // Cover
            // 
            Cover.Image = (Image)resources.GetObject("Cover.Image");
            Cover.Location = new Point(188, 4);
            Cover.Name = "Cover";
            Cover.Size = new Size(574, 180);
            Cover.SizeMode = PictureBoxSizeMode.StretchImage;
            Cover.TabIndex = 6;
            Cover.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(767, 553);
            Controls.Add(Cover);
            Controls.Add(UnicomTICLogo);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            MaximumSize = new Size(785, 600);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)UnicomTICLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)Cover).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private PictureBox UnicomTICLogo;
        private PictureBox Cover;
    }
}