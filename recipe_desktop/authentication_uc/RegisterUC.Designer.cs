﻿namespace recipe_desktop
{
    partial class RegisterUC : UserControl
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
            dtpBirthdate = new DateTimePicker();
            lblBirthdate = new Label();
            cbGenders = new ComboBox();
            lblGender = new Label();
            lblLastName = new Label();
            tbLastName = new TextBox();
            lblFirstName = new Label();
            tbFirstName = new TextBox();
            lblBsn = new Label();
            tbBsn = new TextBox();
            lblEmail = new Label();
            tbEmail = new TextBox();
            picPassword = new PictureBox();
            lblPassword = new Label();
            tbPassword = new TextBox();
            btnClear = new Button();
            label2 = new Label();
            lblText = new Label();
            lblLogin = new Label();
            btnSubmit = new Button();
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
            panel1.Controls.Add(dtpBirthdate);
            panel1.Controls.Add(lblBirthdate);
            panel1.Controls.Add(cbGenders);
            panel1.Controls.Add(lblGender);
            panel1.Controls.Add(lblLastName);
            panel1.Controls.Add(tbLastName);
            panel1.Controls.Add(lblFirstName);
            panel1.Controls.Add(tbFirstName);
            panel1.Controls.Add(lblBsn);
            panel1.Controls.Add(tbBsn);
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(tbEmail);
            panel1.Controls.Add(picPassword);
            panel1.Controls.Add(lblPassword);
            panel1.Controls.Add(tbPassword);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblText);
            panel1.Controls.Add(lblLogin);
            panel1.Controls.Add(btnSubmit);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(tbUsername);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(8, 7);
            panel1.Name = "panel1";
            panel1.Size = new Size(640, 709);
            panel1.TabIndex = 0;
            // 
            // dtpBirthdate
            // 
            dtpBirthdate.CalendarForeColor = Color.FromArgb(46, 79, 166);
            dtpBirthdate.CalendarMonthBackground = Color.FromArgb(46, 79, 166);
            dtpBirthdate.CalendarTitleBackColor = Color.FromArgb(46, 79, 166);
            dtpBirthdate.CalendarTitleForeColor = Color.FromArgb(46, 79, 166);
            dtpBirthdate.CalendarTrailingForeColor = Color.FromArgb(46, 79, 166);
            dtpBirthdate.Font = new Font("Segoe UI", 17F);
            dtpBirthdate.Format = DateTimePickerFormat.Short;
            dtpBirthdate.Location = new Point(329, 427);
            dtpBirthdate.Name = "dtpBirthdate";
            dtpBirthdate.Size = new Size(276, 45);
            dtpBirthdate.TabIndex = 26;
            dtpBirthdate.Value = new DateTime(2024, 5, 4, 0, 0, 0, 0);
            // 
            // lblBirthdate
            // 
            lblBirthdate.AutoSize = true;
            lblBirthdate.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblBirthdate.ForeColor = Color.FromArgb(61, 83, 143);
            lblBirthdate.Location = new Point(322, 384);
            lblBirthdate.Name = "lblBirthdate";
            lblBirthdate.Size = new Size(146, 40);
            lblBirthdate.TabIndex = 25;
            lblBirthdate.Text = "Birthdate";
            lblBirthdate.TextAlign = ContentAlignment.TopCenter;
            // 
            // cbGenders
            // 
            cbGenders.Font = new Font("Segoe UI", 15F);
            cbGenders.ForeColor = Color.Black;
            cbGenders.FormattingEnabled = true;
            cbGenders.Location = new Point(38, 427);
            cbGenders.Name = "cbGenders";
            cbGenders.Size = new Size(276, 43);
            cbGenders.TabIndex = 24;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(61, 83, 143);
            lblGender.Location = new Point(31, 384);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(118, 40);
            lblGender.TabIndex = 23;
            lblGender.Text = "Gender";
            lblGender.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblLastName.ForeColor = Color.FromArgb(61, 83, 143);
            lblLastName.Location = new Point(329, 297);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(162, 40);
            lblLastName.TabIndex = 22;
            lblLastName.Text = "Last Name";
            lblLastName.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbLastName
            // 
            tbLastName.Font = new Font("Segoe UI", 15F);
            tbLastName.ForeColor = Color.Black;
            tbLastName.Location = new Point(329, 340);
            tbLastName.MaxLength = 100;
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(276, 41);
            tbLastName.TabIndex = 21;
            tbLastName.KeyPress += tbLastName_KeyPress;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.FromArgb(61, 83, 143);
            lblFirstName.Location = new Point(31, 297);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(166, 40);
            lblFirstName.TabIndex = 20;
            lblFirstName.Text = "First Name";
            lblFirstName.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbFirstName
            // 
            tbFirstName.Font = new Font("Segoe UI", 15F);
            tbFirstName.ForeColor = Color.Black;
            tbFirstName.Location = new Point(38, 340);
            tbFirstName.MaxLength = 100;
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(276, 41);
            tbFirstName.TabIndex = 19;
            tbFirstName.KeyPress += tbFirstName_KeyPress;
            // 
            // lblBsn
            // 
            lblBsn.AutoSize = true;
            lblBsn.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblBsn.ForeColor = Color.FromArgb(61, 83, 143);
            lblBsn.Location = new Point(322, 210);
            lblBsn.Name = "lblBsn";
            lblBsn.Size = new Size(75, 40);
            lblBsn.TabIndex = 18;
            lblBsn.Text = "BSN";
            lblBsn.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbBsn
            // 
            tbBsn.Font = new Font("Segoe UI", 15F);
            tbBsn.ForeColor = Color.Black;
            tbBsn.Location = new Point(329, 253);
            tbBsn.MaxLength = 10;
            tbBsn.Name = "tbBsn";
            tbBsn.Size = new Size(276, 41);
            tbBsn.TabIndex = 17;
            tbBsn.KeyPress += tbBsn_KeyPress;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(61, 83, 143);
            lblEmail.Location = new Point(31, 210);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(91, 40);
            lblEmail.TabIndex = 16;
            lblEmail.Text = "Email";
            lblEmail.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 15F);
            tbEmail.ForeColor = Color.Black;
            tbEmail.Location = new Point(40, 253);
            tbEmail.MaxLength = 100;
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(276, 41);
            tbEmail.TabIndex = 15;
            // 
            // picPassword
            // 
            picPassword.Cursor = Cursors.Hand;
            picPassword.Image = Properties.Resources.icons8_eye_30;
            picPassword.Location = new Point(576, 133);
            picPassword.Name = "picPassword";
            picPassword.Size = new Size(29, 22);
            picPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            picPassword.TabIndex = 14;
            picPassword.TabStop = false;
            picPassword.Click += picPassword_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(61, 83, 143);
            lblPassword.Location = new Point(322, 123);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(147, 40);
            lblPassword.TabIndex = 13;
            lblPassword.Text = "Password";
            lblPassword.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 15F);
            tbPassword.ForeColor = Color.Black;
            tbPassword.Location = new Point(329, 166);
            tbPassword.MaxLength = 50;
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(276, 41);
            tbPassword.TabIndex = 12;
            tbPassword.UseSystemPasswordChar = true;
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
            btnClear.Location = new Point(38, 504);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(276, 49);
            btnClear.TabIndex = 11;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(196, 568);
            label2.Name = "label2";
            label2.Size = new Size(265, 35);
            label2.TabIndex = 9;
            label2.Text = "You have an account?";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblText.ForeColor = Color.White;
            lblText.Location = new Point(196, 568);
            lblText.Name = "lblText";
            lblText.Size = new Size(265, 35);
            lblText.TabIndex = 9;
            lblText.Text = "You have an account?";
            lblText.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Cursor = Cursors.Hand;
            lblLogin.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblLogin.ForeColor = Color.FromArgb(61, 83, 143);
            lblLogin.Location = new Point(287, 603);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(80, 35);
            lblLogin.TabIndex = 8;
            lblLogin.Text = "Login";
            lblLogin.TextAlign = ContentAlignment.TopCenter;
            lblLogin.Click += lblLogin_Click;
            lblLogin.MouseLeave += lblLogin_MouseLeave;
            lblLogin.MouseHover += lblLogin_MouseHover;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.White;
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnSubmit.FlatAppearance.BorderSize = 2;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.FromArgb(46, 76, 157);
            btnSubmit.Location = new Point(329, 504);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(276, 49);
            btnSubmit.TabIndex = 6;
            btnSubmit.Text = "SUBMIT";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(61, 83, 143);
            lblUsername.Location = new Point(31, 123);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(156, 40);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username";
            lblUsername.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbUsername
            // 
            tbUsername.Font = new Font("Segoe UI", 15F);
            tbUsername.ForeColor = Color.Black;
            tbUsername.Location = new Point(38, 166);
            tbUsername.MaxLength = 100;
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(276, 41);
            tbUsername.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(211, 49);
            label1.Name = "label1";
            label1.Size = new Size(203, 54);
            label1.TabIndex = 0;
            label1.Text = "REGISTER";
            // 
            // RegisterUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(61, 83, 143);
            Controls.Add(panel1);
            Name = "RegisterUC";
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
        private Button btnSubmit;
        private Label lblText;
        private Label lblLogin;
        private Button btnClear;
        private Label lblPassword;
        private TextBox tbPassword;
        private PictureBox picPassword;
        private ComboBox cbGenders;
        private Label lblGender;
        private Label lblLastName;
        private TextBox tbLastName;
        private Label lblFirstName;
        private TextBox tbFirstName;
        private Label lblBsn;
        private TextBox tbBsn;
        private Label lblEmail;
        private TextBox tbEmail;
        private DateTimePicker dtpBirthdate;
        private Label lblBirthdate;
        private Label label2;
    }
}
