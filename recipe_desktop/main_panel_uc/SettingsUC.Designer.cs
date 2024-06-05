namespace recipe_desktop
{
    partial class SettingsUC
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
            lblUsername = new Label();
            tbUsername = new TextBox();
            lblFirstName = new Label();
            tbFirstName = new TextBox();
            lblLastName = new Label();
            tbLastName = new TextBox();
            lblEmail = new Label();
            tbEmail = new TextBox();
            lblBirthdate = new Label();
            lblBsn = new Label();
            tbBSN = new TextBox();
            lblRole = new Label();
            tbRole = new TextBox();
            picProfile = new PictureBox();
            btnEdit = new Button();
            btnSave = new Button();
            cbGenders = new ComboBox();
            label1 = new Label();
            dtpBirthdate = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)picProfile).BeginInit();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(61, 83, 143);
            lblUsername.Location = new Point(441, 406);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(156, 40);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Username";
            lblUsername.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbUsername
            // 
            tbUsername.Font = new Font("Segoe UI", 18F);
            tbUsername.ForeColor = Color.Black;
            tbUsername.Location = new Point(639, 399);
            tbUsername.MaxLength = 100;
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(474, 47);
            tbUsername.TabIndex = 3;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.FromArgb(61, 83, 143);
            lblFirstName.Location = new Point(441, 298);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(166, 40);
            lblFirstName.TabIndex = 6;
            lblFirstName.Text = "First Name";
            lblFirstName.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbFirstName
            // 
            tbFirstName.Font = new Font("Segoe UI", 18F);
            tbFirstName.ForeColor = Color.Black;
            tbFirstName.Location = new Point(639, 293);
            tbFirstName.MaxLength = 100;
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(474, 47);
            tbFirstName.TabIndex = 5;
            tbFirstName.KeyPress += tbFirstName_KeyPress;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblLastName.ForeColor = Color.FromArgb(61, 83, 143);
            lblLastName.Location = new Point(441, 351);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(162, 40);
            lblLastName.TabIndex = 7;
            lblLastName.Text = "Last Name";
            lblLastName.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbLastName
            // 
            tbLastName.Font = new Font("Segoe UI", 18F);
            tbLastName.ForeColor = Color.Black;
            tbLastName.Location = new Point(639, 346);
            tbLastName.MaxLength = 100;
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(474, 47);
            tbLastName.TabIndex = 8;
            tbLastName.KeyPress += tbLastName_KeyPress;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(61, 83, 143);
            lblEmail.Location = new Point(443, 457);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(91, 40);
            lblEmail.TabIndex = 12;
            lblEmail.Text = "Email";
            lblEmail.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 18F);
            tbEmail.ForeColor = Color.Black;
            tbEmail.Location = new Point(639, 452);
            tbEmail.MaxLength = 100;
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(474, 47);
            tbEmail.TabIndex = 11;
            // 
            // lblBirthdate
            // 
            lblBirthdate.AutoSize = true;
            lblBirthdate.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblBirthdate.ForeColor = Color.FromArgb(61, 83, 143);
            lblBirthdate.Location = new Point(441, 510);
            lblBirthdate.Name = "lblBirthdate";
            lblBirthdate.Size = new Size(146, 40);
            lblBirthdate.TabIndex = 14;
            lblBirthdate.Text = "Birthdate";
            lblBirthdate.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblBsn
            // 
            lblBsn.AutoSize = true;
            lblBsn.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblBsn.ForeColor = Color.FromArgb(61, 83, 143);
            lblBsn.Location = new Point(441, 563);
            lblBsn.Name = "lblBsn";
            lblBsn.Size = new Size(75, 40);
            lblBsn.TabIndex = 16;
            lblBsn.Text = "BSN";
            lblBsn.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbBSN
            // 
            tbBSN.Font = new Font("Segoe UI", 18F);
            tbBSN.ForeColor = Color.Black;
            tbBSN.Location = new Point(639, 558);
            tbBSN.MaxLength = 10;
            tbBSN.Name = "tbBSN";
            tbBSN.Size = new Size(474, 47);
            tbBSN.TabIndex = 15;
            tbBSN.KeyPress += tbBsn_KeyPress;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(61, 83, 143);
            lblRole.Location = new Point(441, 616);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(77, 40);
            lblRole.TabIndex = 19;
            lblRole.Text = "Role";
            lblRole.TextAlign = ContentAlignment.TopCenter;
            // 
            // tbRole
            // 
            tbRole.Font = new Font("Segoe UI", 18F);
            tbRole.ForeColor = Color.Black;
            tbRole.Location = new Point(639, 611);
            tbRole.Name = "tbRole";
            tbRole.Size = new Size(474, 47);
            tbRole.TabIndex = 20;
            // 
            // picProfile
            // 
            picProfile.Image = Properties.Resources.Profile_PNG_Clipart;
            picProfile.Location = new Point(757, 47);
            picProfile.Name = "picProfile";
            picProfile.Size = new Size(214, 210);
            picProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            picProfile.TabIndex = 21;
            picProfile.TabStop = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(61, 83, 143);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnEdit.FlatAppearance.BorderSize = 2;
            btnEdit.FlatAppearance.MouseDownBackColor = Color.FromArgb(46, 76, 157);
            btnEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 76, 157);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(639, 736);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(474, 49);
            btnEdit.TabIndex = 22;
            btnEdit.Text = "EDIT";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.White;
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnSave.FlatAppearance.BorderSize = 2;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnSave.ForeColor = Color.FromArgb(46, 76, 157);
            btnSave.Location = new Point(639, 791);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(474, 49);
            btnSave.TabIndex = 23;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // cbGenders
            // 
            cbGenders.Font = new Font("Segoe UI", 18F);
            cbGenders.ForeColor = Color.Black;
            cbGenders.FormattingEnabled = true;
            cbGenders.Location = new Point(639, 664);
            cbGenders.Name = "cbGenders";
            cbGenders.Size = new Size(474, 49);
            cbGenders.TabIndex = 45;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(61, 83, 143);
            label1.Location = new Point(441, 669);
            label1.Name = "label1";
            label1.Size = new Size(118, 40);
            label1.TabIndex = 46;
            label1.Text = "Gender";
            label1.TextAlign = ContentAlignment.TopCenter;
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
            dtpBirthdate.Location = new Point(639, 505);
            dtpBirthdate.Name = "dtpBirthdate";
            dtpBirthdate.Size = new Size(474, 47);
            dtpBirthdate.TabIndex = 47;
            dtpBirthdate.Value = new DateTime(2024, 5, 4, 0, 0, 0, 0);
            // 
            // SettingsUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dtpBirthdate);
            Controls.Add(label1);
            Controls.Add(cbGenders);
            Controls.Add(btnSave);
            Controls.Add(btnEdit);
            Controls.Add(picProfile);
            Controls.Add(tbRole);
            Controls.Add(lblRole);
            Controls.Add(lblBsn);
            Controls.Add(tbBSN);
            Controls.Add(lblBirthdate);
            Controls.Add(lblEmail);
            Controls.Add(tbEmail);
            Controls.Add(tbLastName);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Controls.Add(tbFirstName);
            Controls.Add(lblUsername);
            Controls.Add(tbUsername);
            Name = "SettingsUC";
            Size = new Size(1677, 870);
            ((System.ComponentModel.ISupportInitialize)picProfile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private TextBox tbUsername;
        private Label lblFirstName;
        private TextBox tbFirstName;
        private Label lblLastName;
        private TextBox tbLastName;
        private Label lblEmail;
        private TextBox tbEmail;
        private Label lblBirthdate;
        private Label lblBsn;
        private TextBox tbBSN;
        private Label lblRole;
        private TextBox tbRole;
        private PictureBox picProfile;
        private Button btnEdit;
        private Button btnSave;
        private ComboBox cbGenders;
        private Label label1;
        private DateTimePicker dtpBirthdate;
    }
}
