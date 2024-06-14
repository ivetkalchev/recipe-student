namespace recipe_desktop
{
    partial class EditEmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditEmployeeForm));
            panel1 = new Panel();
            dtpBirthdate = new DateTimePicker();
            cbGenders = new ComboBox();
            btnEdit = new Button();
            btnSave = new Button();
            lblGender = new Label();
            tbRole = new TextBox();
            lblRole = new Label();
            lblBsn = new Label();
            tbBSN = new TextBox();
            lblBirthdate = new Label();
            lblEmail = new Label();
            tbEmail = new TextBox();
            tbLastName = new TextBox();
            lblLastName = new Label();
            lblFirstName = new Label();
            tbFirstName = new TextBox();
            lblUsername = new Label();
            tbUsername = new TextBox();
            btnClose = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(182, 113, 169);
            panel1.Controls.Add(dtpBirthdate);
            panel1.Controls.Add(cbGenders);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(lblGender);
            panel1.Controls.Add(tbRole);
            panel1.Controls.Add(lblRole);
            panel1.Controls.Add(lblBsn);
            panel1.Controls.Add(tbBSN);
            panel1.Controls.Add(lblBirthdate);
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(tbEmail);
            panel1.Controls.Add(tbLastName);
            panel1.Controls.Add(lblLastName);
            panel1.Controls.Add(lblFirstName);
            panel1.Controls.Add(tbFirstName);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(tbUsername);
            panel1.Location = new Point(8, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(944, 487);
            panel1.TabIndex = 0;
            // 
            // dtpBirthdate
            // 
            dtpBirthdate.CalendarForeColor = Color.FromArgb(182, 113, 169);
            dtpBirthdate.CalendarMonthBackground = Color.FromArgb(182, 113, 169);
            dtpBirthdate.CalendarTitleBackColor = Color.FromArgb(182, 113, 169);
            dtpBirthdate.CalendarTitleForeColor = Color.FromArgb(182, 113, 169);
            dtpBirthdate.CalendarTrailingForeColor = Color.FromArgb(182, 113, 169);
            dtpBirthdate.Font = new Font("Segoe UI", 18F);
            dtpBirthdate.Format = DateTimePickerFormat.Short;
            dtpBirthdate.Location = new Point(36, 248);
            dtpBirthdate.Name = "dtpBirthdate";
            dtpBirthdate.Size = new Size(416, 47);
            dtpBirthdate.TabIndex = 45;
            dtpBirthdate.Value = new DateTime(2024, 5, 4, 0, 0, 0, 0);
            // 
            // cbGenders
            // 
            cbGenders.Font = new Font("Segoe UI", 18F);
            cbGenders.ForeColor = Color.Black;
            cbGenders.FormattingEnabled = true;
            cbGenders.Location = new Point(36, 341);
            cbGenders.Name = "cbGenders";
            cbGenders.Size = new Size(416, 49);
            cbGenders.TabIndex = 44;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.White;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderColor = Color.FromArgb(98, 14, 80);
            btnEdit.FlatAppearance.BorderSize = 2;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnEdit.ForeColor = Color.FromArgb(98, 14, 80);
            btnEdit.Location = new Point(36, 414);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(416, 49);
            btnEdit.TabIndex = 43;
            btnEdit.Text = "EDIT";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(98, 14, 80);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderColor = Color.FromArgb(63, 8, 51);
            btnSave.FlatAppearance.BorderSize = 2;
            btnSave.FlatAppearance.MouseDownBackColor = Color.FromArgb(63, 8, 51);
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 8, 51);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(492, 414);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(416, 49);
            btnSave.TabIndex = 40;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(98, 14, 80);
            lblGender.Location = new Point(36, 298);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(118, 40);
            lblGender.TabIndex = 38;
            lblGender.Text = "Gender";
            lblGender.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbRole
            // 
            tbRole.Font = new Font("Segoe UI", 18F);
            tbRole.ForeColor = Color.Black;
            tbRole.Location = new Point(492, 343);
            tbRole.Name = "tbRole";
            tbRole.Size = new Size(415, 47);
            tbRole.TabIndex = 35;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(98, 14, 80);
            lblRole.Location = new Point(490, 298);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(77, 40);
            lblRole.TabIndex = 34;
            lblRole.Text = "Role";
            lblRole.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblBsn
            // 
            lblBsn.AutoSize = true;
            lblBsn.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblBsn.ForeColor = Color.FromArgb(98, 14, 80);
            lblBsn.Location = new Point(492, 205);
            lblBsn.Name = "lblBsn";
            lblBsn.Size = new Size(75, 40);
            lblBsn.TabIndex = 33;
            lblBsn.Text = "BSN";
            lblBsn.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbBSN
            // 
            tbBSN.Font = new Font("Segoe UI", 18F);
            tbBSN.ForeColor = Color.Black;
            tbBSN.Location = new Point(492, 248);
            tbBSN.MaxLength = 10;
            tbBSN.Name = "tbBSN";
            tbBSN.Size = new Size(415, 47);
            tbBSN.TabIndex = 32;
            tbBSN.KeyPress += tbBSN_KeyPress;
            // 
            // lblBirthdate
            // 
            lblBirthdate.AutoSize = true;
            lblBirthdate.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblBirthdate.ForeColor = Color.FromArgb(98, 14, 80);
            lblBirthdate.Location = new Point(36, 205);
            lblBirthdate.Name = "lblBirthdate";
            lblBirthdate.Size = new Size(146, 40);
            lblBirthdate.TabIndex = 31;
            lblBirthdate.Text = "Birthdate";
            lblBirthdate.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(98, 14, 80);
            lblEmail.Location = new Point(492, 112);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(91, 40);
            lblEmail.TabIndex = 29;
            lblEmail.Text = "Email";
            lblEmail.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 18F);
            tbEmail.ForeColor = Color.Black;
            tbEmail.Location = new Point(492, 155);
            tbEmail.MaxLength = 100;
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(415, 47);
            tbEmail.TabIndex = 28;
            // 
            // tbLastName
            // 
            tbLastName.Font = new Font("Segoe UI", 18F);
            tbLastName.ForeColor = Color.Black;
            tbLastName.Location = new Point(36, 155);
            tbLastName.MaxLength = 100;
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(416, 47);
            tbLastName.TabIndex = 27;
            tbLastName.KeyPress += tbLastName_KeyPress;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblLastName.ForeColor = Color.FromArgb(98, 14, 80);
            lblLastName.Location = new Point(36, 112);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(162, 40);
            lblLastName.TabIndex = 26;
            lblLastName.Text = "Last Name";
            lblLastName.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.FromArgb(98, 14, 80);
            lblFirstName.Location = new Point(36, 19);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(166, 40);
            lblFirstName.TabIndex = 25;
            lblFirstName.Text = "First Name";
            lblFirstName.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbFirstName
            // 
            tbFirstName.Font = new Font("Segoe UI", 18F);
            tbFirstName.ForeColor = Color.Black;
            tbFirstName.Location = new Point(36, 62);
            tbFirstName.MaxLength = 100;
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(416, 47);
            tbFirstName.TabIndex = 24;
            tbFirstName.KeyPress += tbFirstName_KeyPress;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(98, 14, 80);
            lblUsername.Location = new Point(483, 19);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(156, 40);
            lblUsername.TabIndex = 23;
            lblUsername.Text = "Username";
            lblUsername.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbUsername
            // 
            tbUsername.Font = new Font("Segoe UI", 18F);
            tbUsername.ForeColor = Color.Black;
            tbUsername.Location = new Point(492, 62);
            tbUsername.MaxLength = 100;
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(415, 47);
            tbUsername.TabIndex = 22;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.White;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnClose.FlatAppearance.BorderSize = 2;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(98, 14, 80);
            btnClose.Location = new Point(910, 4);
            btnClose.Margin = new Padding(0);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(0, 0, 0, 2);
            btnClose.Size = new Size(42, 45);
            btnClose.TabIndex = 13;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(335, 5);
            label1.Name = "label1";
            label1.Size = new Size(282, 40);
            label1.TabIndex = 40;
            label1.Text = "EDIT AN EMPLOYEE";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EditEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(98, 14, 80);
            ClientSize = new Size(960, 549);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditEmployeeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Employee";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnClose;
        private TextBox tbRole;
        private Label lblRole;
        private Label lblBsn;
        private TextBox tbBSN;
        private Label lblBirthdate;
        private Label lblEmail;
        private TextBox tbEmail;
        private TextBox tbLastName;
        private Label lblLastName;
        private Label lblFirstName;
        private TextBox tbFirstName;
        private Label lblUsername;
        private TextBox tbUsername;
        private Label lblGender;
        private Label label1;
        private Button btnSave;
        private Button btnEdit;
        private ComboBox cbGenders;
        private DateTimePicker dtpBirthdate;
    }
}