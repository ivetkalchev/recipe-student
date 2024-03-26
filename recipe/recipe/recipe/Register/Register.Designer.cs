namespace recipe
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            panRegister = new Panel();
            tbFirstName = new TextBox();
            cbGender = new ComboBox();
            dtpBirthdate = new DateTimePicker();
            lblBirthdate = new Label();
            tbLastName = new TextBox();
            lblLastName = new Label();
            lbFirstName = new Label();
            tbEmail = new TextBox();
            lblEmail = new Label();
            lblGender = new Label();
            tbBSN = new TextBox();
            lblBSN = new Label();
            lblHaveAcc = new Label();
            lblLogin = new Label();
            btnRegister = new Button();
            btnClear = new Button();
            tbPassword = new TextBox();
            lblPassword = new Label();
            tbUsername = new TextBox();
            lblUsername = new Label();
            lblRegisterHeading = new Label();
            panRegister.SuspendLayout();
            SuspendLayout();
            // 
            // panRegister
            // 
            panRegister.BackColor = Color.FromArgb(217, 217, 217);
            panRegister.Controls.Add(tbFirstName);
            panRegister.Controls.Add(cbGender);
            panRegister.Controls.Add(dtpBirthdate);
            panRegister.Controls.Add(lblBirthdate);
            panRegister.Controls.Add(tbLastName);
            panRegister.Controls.Add(lblLastName);
            panRegister.Controls.Add(lbFirstName);
            panRegister.Controls.Add(tbEmail);
            panRegister.Controls.Add(lblEmail);
            panRegister.Controls.Add(lblGender);
            panRegister.Controls.Add(tbBSN);
            panRegister.Controls.Add(lblBSN);
            panRegister.Controls.Add(lblHaveAcc);
            panRegister.Controls.Add(lblLogin);
            panRegister.Controls.Add(btnRegister);
            panRegister.Controls.Add(btnClear);
            panRegister.Controls.Add(tbPassword);
            panRegister.Controls.Add(lblPassword);
            panRegister.Controls.Add(tbUsername);
            panRegister.Controls.Add(lblUsername);
            panRegister.Controls.Add(lblRegisterHeading);
            panRegister.Location = new Point(83, 65);
            panRegister.Name = "panRegister";
            panRegister.Size = new Size(839, 595);
            panRegister.TabIndex = 1;
            // 
            // tbFirstName
            // 
            tbFirstName.Font = new Font("Segoe UI", 12F);
            tbFirstName.Location = new Point(437, 225);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(360, 34);
            tbFirstName.TabIndex = 23;
            // 
            // cbGender
            // 
            cbGender.Font = new Font("Segoe UI", 12F);
            cbGender.FormattingEnabled = true;
            cbGender.Location = new Point(48, 391);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(360, 36);
            cbGender.TabIndex = 22;
            // 
            // dtpBirthdate
            // 
            dtpBirthdate.Font = new Font("Segoe UI", 13F);
            dtpBirthdate.Location = new Point(437, 391);
            dtpBirthdate.Name = "dtpBirthdate";
            dtpBirthdate.Size = new Size(360, 36);
            dtpBirthdate.TabIndex = 21;
            // 
            // lblBirthdate
            // 
            lblBirthdate.AutoSize = true;
            lblBirthdate.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblBirthdate.ForeColor = Color.FromArgb(255, 130, 169);
            lblBirthdate.Location = new Point(431, 354);
            lblBirthdate.Name = "lblBirthdate";
            lblBirthdate.Size = new Size(112, 30);
            lblBirthdate.TabIndex = 20;
            lblBirthdate.Text = "Birthdate";
            // 
            // tbLastName
            // 
            tbLastName.Font = new Font("Segoe UI", 12F);
            tbLastName.Location = new Point(437, 304);
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(360, 34);
            tbLastName.TabIndex = 19;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblLastName.ForeColor = Color.FromArgb(255, 130, 169);
            lblLastName.Location = new Point(431, 271);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(122, 30);
            lblLastName.TabIndex = 18;
            lblLastName.Text = "Last Name";
            // 
            // lbFirstName
            // 
            lbFirstName.AutoSize = true;
            lbFirstName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lbFirstName.ForeColor = Color.FromArgb(255, 130, 169);
            lbFirstName.Location = new Point(431, 189);
            lbFirstName.Name = "lbFirstName";
            lbFirstName.Size = new Size(125, 30);
            lbFirstName.TabIndex = 16;
            lbFirstName.Text = "First Name";
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 12F);
            tbEmail.Location = new Point(437, 149);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(360, 34);
            tbEmail.TabIndex = 15;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(255, 130, 169);
            lblEmail.Location = new Point(431, 114);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(69, 30);
            lblEmail.TabIndex = 14;
            lblEmail.Text = "Email";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(255, 130, 169);
            lblGender.Location = new Point(43, 354);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(89, 30);
            lblGender.TabIndex = 12;
            lblGender.Text = "Gender";
            // 
            // tbBSN
            // 
            tbBSN.Font = new Font("Segoe UI", 12F);
            tbBSN.Location = new Point(48, 304);
            tbBSN.MaxLength = 9;
            tbBSN.Name = "tbBSN";
            tbBSN.Size = new Size(360, 34);
            tbBSN.TabIndex = 11;
            tbBSN.KeyPress += tbBSN_KeyPress;
            // 
            // lblBSN
            // 
            lblBSN.AutoSize = true;
            lblBSN.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblBSN.ForeColor = Color.FromArgb(255, 130, 169);
            lblBSN.Location = new Point(43, 271);
            lblBSN.Name = "lblBSN";
            lblBSN.Size = new Size(56, 30);
            lblBSN.TabIndex = 10;
            lblBSN.Text = "BSN";
            // 
            // lblHaveAcc
            // 
            lblHaveAcc.AutoSize = true;
            lblHaveAcc.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblHaveAcc.ForeColor = Color.FromArgb(95, 95, 95);
            lblHaveAcc.Location = new Point(340, 505);
            lblHaveAcc.Name = "lblHaveAcc";
            lblHaveAcc.Size = new Size(160, 25);
            lblHaveAcc.TabIndex = 9;
            lblHaveAcc.Text = "You have an acc?";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLogin.ForeColor = Color.FromArgb(255, 41, 107);
            lblLogin.Location = new Point(392, 530);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(63, 25);
            lblLogin.TabIndex = 8;
            lblLogin.Text = "Login";
            lblLogin.Click += lblLogin_Click;
            lblLogin.MouseLeave += lblLogin_MouseLeave;
            lblLogin.MouseHover += lblLogin_MouseHover;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(255, 130, 169);
            btnRegister.FlatAppearance.BorderColor = Color.FromArgb(255, 41, 107);
            btnRegister.FlatAppearance.BorderSize = 2;
            btnRegister.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 41, 107);
            btnRegister.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 41, 107);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(437, 453);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(360, 38);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "REGISTER";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
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
            btnClear.Location = new Point(48, 453);
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
            tbPassword.Location = new Point(48, 225);
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
            lblPassword.Location = new Point(43, 192);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(112, 30);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // tbUsername
            // 
            tbUsername.Font = new Font("Segoe UI", 12F);
            tbUsername.Location = new Point(48, 149);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(360, 34);
            tbUsername.TabIndex = 2;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(255, 130, 169);
            lblUsername.Location = new Point(43, 114);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(117, 30);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username";
            // 
            // lblRegisterHeading
            // 
            lblRegisterHeading.AutoSize = true;
            lblRegisterHeading.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblRegisterHeading.ForeColor = Color.FromArgb(255, 41, 107);
            lblRegisterHeading.Location = new Point(37, 38);
            lblRegisterHeading.Name = "lblRegisterHeading";
            lblRegisterHeading.Size = new Size(573, 57);
            lblRegisterHeading.TabIndex = 0;
            lblRegisterHeading.Text = "Register as a new employee";
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(127, 149, 209);
            ClientSize = new Size(1006, 721);
            Controls.Add(panRegister);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            panRegister.ResumeLayout(false);
            panRegister.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panRegister;
        private Label lblHaveAcc;
        private Label lblLogin;
        private Button btnRegister;
        private Button btnClear;
        private TextBox tbPassword;
        private Label lblPassword;
        private TextBox tbUsername;
        private Label lblUsername;
        private Label lblRegisterHeading;
        private TextBox tbBSN;
        private Label lblBSN;
        private DateTimePicker dtpBirthdate;
        private Label lblBirthdate;
        private TextBox tbLastName;
        private Label lblLastName;
        private Label lbFirstName;
        private TextBox tbEmail;
        private Label lblEmail;
        private Label lblGender;
        private ComboBox cbGender;
        private TextBox tbFirstName;
    }
}