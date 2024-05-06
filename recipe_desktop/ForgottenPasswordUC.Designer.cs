namespace recipe_desktop
{
    partial class ForgottenPasswordUC : UserControl
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
            lblUsername = new Label();
            tbUsername = new TextBox();
            lblLogin = new Label();
            btnClear = new Button();
            lblRegister = new Label();
            btnSubmit = new Button();
            lblSecQuestion = new Label();
            tbSecurityAnswer = new TextBox();
            label1 = new Label();
            lblNewPassword = new Label();
            tbNewPassword = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(125, 147, 208);
            panel1.Controls.Add(lblNewPassword);
            panel1.Controls.Add(tbNewPassword);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(tbUsername);
            panel1.Controls.Add(lblLogin);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(lblRegister);
            panel1.Controls.Add(btnSubmit);
            panel1.Controls.Add(lblSecQuestion);
            panel1.Controls.Add(tbSecurityAnswer);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(8, 7);
            panel1.Name = "panel1";
            panel1.Size = new Size(640, 709);
            panel1.TabIndex = 0;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(77, 172);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(156, 40);
            lblUsername.TabIndex = 14;
            lblUsername.Text = "Username";
            lblUsername.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbUsername
            // 
            tbUsername.Font = new Font("Segoe UI", 18F);
            tbUsername.Location = new Point(77, 215);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(474, 47);
            tbUsername.TabIndex = 13;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Cursor = Cursors.Hand;
            lblLogin.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblLogin.ForeColor = Color.White;
            lblLogin.Location = new Point(471, 587);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(80, 35);
            lblLogin.TabIndex = 12;
            lblLogin.Text = "Login";
            lblLogin.TextAlign = ContentAlignment.TopCenter;
            lblLogin.Click += lblLogin_Click;
            lblLogin.MouseLeave += lblLogin_MouseLeave;
            lblLogin.MouseHover += lblLogin_MouseHover;
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
            btnClear.Location = new Point(77, 470);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(474, 49);
            btnClear.TabIndex = 11;
            btnClear.Text = "CLEAR";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // lblRegister
            // 
            lblRegister.AutoSize = true;
            lblRegister.Cursor = Cursors.Hand;
            lblRegister.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblRegister.ForeColor = Color.FromArgb(61, 83, 143);
            lblRegister.Location = new Point(72, 587);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(111, 35);
            lblRegister.TabIndex = 8;
            lblRegister.Text = "Register";
            lblRegister.TextAlign = ContentAlignment.TopCenter;
            lblRegister.Click += lblRegister_Click;
            lblRegister.MouseLeave += lblRegister_MouseLeave;
            lblRegister.MouseHover += lblRegister_MouseHover;
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
            btnSubmit.Location = new Point(77, 525);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(474, 49);
            btnSubmit.TabIndex = 6;
            btnSubmit.Text = "SUBMIT";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblSecQuestion
            // 
            lblSecQuestion.AutoSize = true;
            lblSecQuestion.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblSecQuestion.ForeColor = Color.White;
            lblSecQuestion.Location = new Point(72, 265);
            lblSecQuestion.Name = "lblSecQuestion";
            lblSecQuestion.Size = new Size(400, 40);
            lblSecQuestion.TabIndex = 2;
            lblSecQuestion.Text = "What is your favourite film?";
            lblSecQuestion.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbSecurityAnswer
            // 
            tbSecurityAnswer.Font = new Font("Segoe UI", 18F);
            tbSecurityAnswer.Location = new Point(77, 308);
            tbSecurityAnswer.Name = "tbSecurityAnswer";
            tbSecurityAnswer.Size = new Size(474, 47);
            tbSecurityAnswer.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(77, 77);
            label1.Name = "label1";
            label1.Size = new Size(500, 67);
            label1.TabIndex = 0;
            label1.Text = "Forgotten Password";
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblNewPassword.ForeColor = Color.White;
            lblNewPassword.Location = new Point(72, 362);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(217, 40);
            lblNewPassword.TabIndex = 16;
            lblNewPassword.Text = "New Password";
            lblNewPassword.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbNewPassword
            // 
            tbNewPassword.Font = new Font("Segoe UI", 18F);
            tbNewPassword.Location = new Point(77, 405);
            tbNewPassword.Name = "tbNewPassword";
            tbNewPassword.Size = new Size(474, 47);
            tbNewPassword.TabIndex = 15;
            // 
            // ForgottenPasswordUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(61, 83, 143);
            Controls.Add(panel1);
            Name = "ForgottenPasswordUC";
            Size = new Size(654, 721);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox tbSecurityAnswer;
        private Label lblSecQuestion;
        private Button btnSubmit;
        private Label lblRegister;
        private Button btnClear;
        private Label lblLogin;
        private Label lblUsername;
        private TextBox tbUsername;
        private Label lblNewPassword;
        private TextBox tbNewPassword;
    }
}
