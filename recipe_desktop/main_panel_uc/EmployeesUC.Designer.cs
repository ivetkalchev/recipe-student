namespace recipe_desktop
{
    partial class EmployeesUC
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
            panelEmployee = new Panel();
            btnNext = new Button();
            btnPrevious = new Button();
            panel1 = new Panel();
            lblPfp = new Label();
            lblEmail = new Label();
            lblRole = new Label();
            lblUsername = new Label();
            lblLastName = new Label();
            lblFirstName = new Label();
            lblId = new Label();
            btnAdmins = new Button();
            btnEmployees = new Button();
            btnAll = new Button();
            picSearch = new PictureBox();
            tbSearch = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).BeginInit();
            SuspendLayout();
            // 
            // panelEmployee
            // 
            panelEmployee.Location = new Point(13, 139);
            panelEmployee.Margin = new Padding(5);
            panelEmployee.Name = "panelEmployee";
            panelEmployee.Padding = new Padding(4);
            panelEmployee.Size = new Size(1650, 659);
            panelEmployee.TabIndex = 0;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.FromArgb(61, 83, 143);
            btnNext.Cursor = Cursors.Hand;
            btnNext.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnNext.FlatAppearance.BorderSize = 2;
            btnNext.FlatAppearance.MouseDownBackColor = Color.FromArgb(46, 76, 157);
            btnNext.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 76, 157);
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(856, 815);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(161, 49);
            btnNext.TabIndex = 6;
            btnNext.Text = "NEXT";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.BackColor = Color.White;
            btnPrevious.Cursor = Cursors.Hand;
            btnPrevious.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnPrevious.FlatAppearance.BorderSize = 2;
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnPrevious.ForeColor = Color.FromArgb(46, 76, 157);
            btnPrevious.Location = new Point(657, 815);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(161, 49);
            btnPrevious.TabIndex = 8;
            btnPrevious.Text = "PREVIOUS";
            btnPrevious.UseVisualStyleBackColor = false;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(46, 79, 166);
            panel1.Controls.Add(lblPfp);
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(lblRole);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(lblLastName);
            panel1.Controls.Add(lblFirstName);
            panel1.Controls.Add(lblId);
            panel1.Location = new Point(15, 80);
            panel1.Name = "panel1";
            panel1.Size = new Size(1645, 51);
            panel1.TabIndex = 9;
            // 
            // lblPfp
            // 
            lblPfp.AutoSize = true;
            lblPfp.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPfp.ForeColor = Color.White;
            lblPfp.Location = new Point(29, 6);
            lblPfp.Name = "lblPfp";
            lblPfp.Size = new Size(66, 38);
            lblPfp.TabIndex = 16;
            lblPfp.Text = "PFP";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(768, 6);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(89, 38);
            lblEmail.TabIndex = 15;
            lblEmail.Text = "Email";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRole.ForeColor = Color.White;
            lblRole.Location = new Point(1132, 6);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(74, 38);
            lblRole.TabIndex = 14;
            lblRole.Text = "Role";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(553, 6);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(148, 38);
            lblUsername.TabIndex = 13;
            lblUsername.Text = "Username";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLastName.ForeColor = Color.White;
            lblLastName.Location = new Point(357, 6);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(155, 38);
            lblLastName.TabIndex = 12;
            lblLastName.Text = "Last Name";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFirstName.ForeColor = Color.White;
            lblFirstName.Location = new Point(181, 6);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(160, 38);
            lblFirstName.TabIndex = 11;
            lblFirstName.Text = "First Name";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblId.ForeColor = Color.White;
            lblId.Location = new Point(116, 6);
            lblId.Name = "lblId";
            lblId.Size = new Size(47, 38);
            lblId.TabIndex = 10;
            lblId.Text = "ID";
            // 
            // btnAdmins
            // 
            btnAdmins.BackColor = Color.White;
            btnAdmins.Cursor = Cursors.Hand;
            btnAdmins.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnAdmins.FlatAppearance.BorderSize = 2;
            btnAdmins.FlatStyle = FlatStyle.Flat;
            btnAdmins.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnAdmins.ForeColor = Color.FromArgb(46, 76, 157);
            btnAdmins.Location = new Point(17, 15);
            btnAdmins.Name = "btnAdmins";
            btnAdmins.Size = new Size(136, 49);
            btnAdmins.TabIndex = 10;
            btnAdmins.Text = "ADMINS";
            btnAdmins.UseVisualStyleBackColor = false;
            btnAdmins.Click += btnAdmins_Click;
            // 
            // btnEmployees
            // 
            btnEmployees.BackColor = Color.White;
            btnEmployees.Cursor = Cursors.Hand;
            btnEmployees.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnEmployees.FlatAppearance.BorderSize = 2;
            btnEmployees.FlatStyle = FlatStyle.Flat;
            btnEmployees.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnEmployees.ForeColor = Color.FromArgb(46, 76, 157);
            btnEmployees.Location = new Point(150, 15);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Size = new Size(168, 49);
            btnEmployees.TabIndex = 11;
            btnEmployees.Text = "EMPLOYEES";
            btnEmployees.UseVisualStyleBackColor = false;
            btnEmployees.Click += btnEmployees_Click;
            // 
            // btnAll
            // 
            btnAll.BackColor = Color.White;
            btnAll.Cursor = Cursors.Hand;
            btnAll.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnAll.FlatAppearance.BorderSize = 2;
            btnAll.FlatStyle = FlatStyle.Flat;
            btnAll.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnAll.ForeColor = Color.FromArgb(46, 76, 157);
            btnAll.Location = new Point(315, 15);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(85, 49);
            btnAll.TabIndex = 12;
            btnAll.Text = "ALL";
            btnAll.UseVisualStyleBackColor = false;
            btnAll.Click += btnAll_Click;
            // 
            // picSearch
            // 
            picSearch.Image = Properties.Resources.search;
            picSearch.Location = new Point(1613, 15);
            picSearch.Name = "picSearch";
            picSearch.Size = new Size(50, 49);
            picSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            picSearch.TabIndex = 13;
            picSearch.TabStop = false;
            picSearch.Click += picSearch_Click;
            // 
            // tbSearch
            // 
            tbSearch.Font = new Font("Segoe UI", 18F);
            tbSearch.ForeColor = Color.FromArgb(46, 79, 166);
            tbSearch.Location = new Point(1278, 17);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(326, 47);
            tbSearch.TabIndex = 14;
            // 
            // EmployeesUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            Controls.Add(tbSearch);
            Controls.Add(picSearch);
            Controls.Add(btnAll);
            Controls.Add(btnEmployees);
            Controls.Add(btnAdmins);
            Controls.Add(panel1);
            Controls.Add(btnPrevious);
            Controls.Add(btnNext);
            Controls.Add(panelEmployee);
            Name = "EmployeesUC";
            Size = new Size(1698, 877);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelEmployee;
        private Button btnNext;
        private Button btnPrevious;
        private Panel panel1;
        private Label lblEmail;
        private Label lblRole;
        private Label lblUsername;
        private Label lblLastName;
        private Label lblFirstName;
        private Label lblId;
        private Button btnAdmins;
        private Button btnEmployees;
        private Button btnAll;
        private Label lblPfp;
        private PictureBox picSearch;
        private TextBox tbSearch;
    }
}
