namespace recipe
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panLogin = new Panel();
            lblDontHaveAcc = new Label();
            lblRegister = new Label();
            lblForgottenPassword = new Label();
            btnLogin = new Button();
            btnClear = new Button();
            tbPassword = new TextBox();
            lblPassword = new Label();
            tbUsername = new TextBox();
            lblUsername = new Label();
            lblLoginHeading = new Label();
            panLogin.SuspendLayout();
            SuspendLayout();
            // 
            // panLogin
            // 
            panLogin.BackColor = Color.FromArgb(217, 217, 217);
            panLogin.Controls.Add(lblDontHaveAcc);
            panLogin.Controls.Add(lblRegister);
            panLogin.Controls.Add(lblForgottenPassword);
            panLogin.Controls.Add(btnLogin);
            panLogin.Controls.Add(btnClear);
            panLogin.Controls.Add(tbPassword);
            panLogin.Controls.Add(lblPassword);
            panLogin.Controls.Add(tbUsername);
            panLogin.Controls.Add(lblUsername);
            panLogin.Controls.Add(lblLoginHeading);
            panLogin.Location = new Point(280, 58);
            panLogin.Name = "panLogin";
            panLogin.Size = new Size(461, 611);
            panLogin.TabIndex = 0;
            // 
            // lblDontHaveAcc
            // 
            lblDontHaveAcc.AutoSize = true;
            lblDontHaveAcc.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDontHaveAcc.ForeColor = Color.FromArgb(95, 95, 95);
            lblDontHaveAcc.Location = new Point(116, 511);
            lblDontHaveAcc.Name = "lblDontHaveAcc";
            lblDontHaveAcc.Size = new Size(214, 25);
            lblDontHaveAcc.TabIndex = 9;
            lblDontHaveAcc.Text = "You don’t have an acc?";
            // 
            // lblRegister
            // 
            lblRegister.AutoSize = true;
            lblRegister.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRegister.ForeColor = Color.FromArgb(255, 41, 107);
            lblRegister.Location = new Point(189, 536);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(84, 25);
            lblRegister.TabIndex = 8;
            lblRegister.Text = "Register";
            lblRegister.Click += lblRegister_Click;
            lblRegister.MouseLeave += lblRegister_MouseLeave;
            lblRegister.MouseHover += lblRegister_MouseHover;
            // 
            // lblForgottenPassword
            // 
            lblForgottenPassword.AutoSize = true;
            lblForgottenPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblForgottenPassword.ForeColor = Color.FromArgb(255, 41, 107);
            lblForgottenPassword.Location = new Point(227, 370);
            lblForgottenPassword.Name = "lblForgottenPassword";
            lblForgottenPassword.Size = new Size(189, 25);
            lblForgottenPassword.TabIndex = 7;
            lblForgottenPassword.Text = "forgotten password";
            lblForgottenPassword.Click += lblForgottenPassword_Click;
            lblForgottenPassword.MouseLeave += lblForgottenPassword_MouseLeave;
            lblForgottenPassword.MouseHover += lblForgottenPassword_MouseHover;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(255, 130, 169);
            btnLogin.FlatAppearance.BorderColor = Color.FromArgb(255, 41, 107);
            btnLogin.FlatAppearance.BorderSize = 2;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 41, 107);
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 41, 107);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(49, 459);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(360, 38);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(255, 192, 190);
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(255, 114, 109);
            btnClear.FlatAppearance.BorderSize = 2;
            btnClear.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 114, 109);
            btnClear.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 114, 109);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(49, 415);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(360, 38);
            btnClear.TabIndex = 5;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 12F);
            tbPassword.Location = new Point(49, 333);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(360, 34);
            tbPassword.TabIndex = 4;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(255, 130, 169);
            lblPassword.Location = new Point(46, 300);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(112, 30);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // tbUsername
            // 
            tbUsername.Font = new Font("Segoe UI", 12F);
            tbUsername.Location = new Point(49, 247);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(360, 34);
            tbUsername.TabIndex = 2;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(255, 130, 169);
            lblUsername.Location = new Point(46, 214);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(117, 30);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username";
            // 
            // lblLoginHeading
            // 
            lblLoginHeading.AutoSize = true;
            lblLoginHeading.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblLoginHeading.ForeColor = Color.FromArgb(255, 41, 107);
            lblLoginHeading.Location = new Point(46, 69);
            lblLoginHeading.Name = "lblLoginHeading";
            lblLoginHeading.Size = new Size(363, 114);
            lblLoginHeading.TabIndex = 0;
            lblLoginHeading.Text = "Student Recipe \nSharing Platform";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(127, 149, 209);
            ClientSize = new Size(1006, 721);
            Controls.Add(panLogin);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panLogin.ResumeLayout(false);
            panLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panLogin;
        private Label lblLoginHeading;
        private TextBox tbUsername;
        private Label lblUsername;
        private TextBox tbPassword;
        private Label lblPassword;
        private Button btnClear;
        private Button btnLogin;
        private Label lblForgottenPassword;
        private Label lblDontHaveAcc;
        private Label lblRegister;
    }
}
