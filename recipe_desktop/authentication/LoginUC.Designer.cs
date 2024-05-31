namespace recipe_desktop
{
    partial class LoginUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            picPassword = new PictureBox();
            lblText = new Label();
            lblRegister = new Label();
            btnLogin = new Button();
            btnClear = new Button();
            tbPassword = new TextBox();
            lblPassword = new Label();
            lblUsername = new Label();
            tbUsername = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPassword).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(125, 147, 208);
            panel1.Controls.Add(picPassword);
            panel1.Controls.Add(lblText);
            panel1.Controls.Add(lblRegister);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(tbPassword);
            panel1.Controls.Add(lblPassword);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(tbUsername);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(8, 7);
            panel1.Name = "panel1";
            panel1.Size = new Size(640, 709);
            panel1.TabIndex = 0;
            // 
            // picPassword
            // 
            picPassword.Cursor = Cursors.Hand;
            picPassword.Image = Properties.Resources.icons8_eye_30;
            picPassword.Location = new Point(512, 339);
            picPassword.Name = "picPassword";
            picPassword.Size = new Size(37, 28);
            picPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            picPassword.TabIndex = 15;
            picPassword.TabStop = false;
            picPassword.Click += picPassword_Click;
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblText.ForeColor = Color.White;
            lblText.Location = new Point(146, 562);
            lblText.Name = "lblText";
            lblText.Size = new Size(334, 35);
            lblText.TabIndex = 9;
            lblText.Text = "You don’t have an account?";
            lblText.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblRegister
            // 
            lblRegister.AutoSize = true;
            lblRegister.Cursor = Cursors.Hand;
            lblRegister.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblRegister.ForeColor = Color.FromArgb(61, 83, 143);
            lblRegister.Location = new Point(256, 597);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(111, 35);
            lblRegister.TabIndex = 8;
            lblRegister.Text = "Register";
            lblRegister.TextAlign = ContentAlignment.TopCenter;
            lblRegister.Click += lblRegister_Click;
            lblRegister.MouseLeave += lblRegister_MouseLeave;
            lblRegister.MouseHover += lblRegister_MouseHover;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.White;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnLogin.FlatAppearance.BorderSize = 2;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnLogin.ForeColor = Color.FromArgb(46, 76, 157);
            btnLogin.Location = new Point(75, 497);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(474, 49);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(61, 83, 143);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnClear.FlatAppearance.BorderSize = 2;
            btnClear.FlatAppearance.MouseDownBackColor = Color.FromArgb(46, 76, 157);
            btnClear.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 76, 157);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(75, 442);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(474, 49);
            btnClear.TabIndex = 5;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 18F);
            tbPassword.ForeColor = Color.Black;
            tbPassword.Location = new Point(75, 370);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(474, 47);
            tbPassword.TabIndex = 4;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(61, 83, 143);
            lblPassword.Location = new Point(66, 327);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(147, 40);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            lblPassword.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(61, 83, 143);
            lblUsername.Location = new Point(66, 222);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(156, 40);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username";
            lblUsername.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbUsername
            // 
            tbUsername.Font = new Font("Segoe UI", 18F);
            tbUsername.ForeColor = Color.Black;
            tbUsername.Location = new Point(75, 265);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(474, 47);
            tbUsername.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(102, 56);
            label1.Name = "label1";
            label1.Size = new Size(430, 134);
            label1.TabIndex = 0;
            label1.Text = "Student Recipe \nSharing Platform";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(61, 83, 143);
            Controls.Add(panel1);
            Name = "LoginUC";
            Size = new Size(654, 721);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPassword).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox tbUsername;
        private Label lblUsername;
        private TextBox tbPassword;
        private Label lblPassword;
        private Button btnClear;
        private Button btnLogin;
        private Label lblText;
        private Label lblRegister;
        private PictureBox picPassword;
    }
}
