namespace recipe_desktop.main_panel_uc
{
    partial class SingleEmployeeUC
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
            pictureBox1 = new PictureBox();
            lblId = new Label();
            lblFirstName = new Label();
            lblLastName = new Label();
            lblUsername = new Label();
            lblRole = new Label();
            btnPromote = new Button();
            btnDelete = new Button();
            lblEmail = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Profile_PNG_Clipart;
            pictureBox1.Location = new Point(17, 18);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(83, 81);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblId.ForeColor = Color.White;
            lblId.Location = new Point(120, 45);
            lblId.Name = "lblId";
            lblId.Size = new Size(67, 38);
            lblId.TabIndex = 1;
            lblId.Text = "{ID}";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFirstName.ForeColor = Color.White;
            lblFirstName.Location = new Point(190, 45);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(180, 38);
            lblFirstName.TabIndex = 2;
            lblFirstName.Text = "{First Name}";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLastName.ForeColor = Color.White;
            lblLastName.Location = new Point(363, 45);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(175, 38);
            lblLastName.TabIndex = 3;
            lblLastName.Text = "{Last Name}";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(555, 45);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(168, 38);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "{Username}";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRole.ForeColor = Color.White;
            lblRole.Location = new Point(1133, 44);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(94, 38);
            lblRole.TabIndex = 5;
            lblRole.Text = "{Role}";
            // 
            // btnPromote
            // 
            btnPromote.BackColor = Color.White;
            btnPromote.Cursor = Cursors.Hand;
            btnPromote.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnPromote.FlatAppearance.BorderSize = 2;
            btnPromote.FlatStyle = FlatStyle.Flat;
            btnPromote.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnPromote.ForeColor = Color.FromArgb(46, 76, 157);
            btnPromote.Location = new Point(1455, 39);
            btnPromote.Name = "btnPromote";
            btnPromote.Size = new Size(149, 49);
            btnPromote.TabIndex = 7;
            btnPromote.Text = "PROMOTE";
            btnPromote.UseVisualStyleBackColor = false;
            btnPromote.Click += btnPromote_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(204, 51, 60);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderColor = Color.FromArgb(156, 39, 46);
            btnDelete.FlatAppearance.BorderSize = 2;
            btnDelete.FlatAppearance.MouseDownBackColor = Color.FromArgb(156, 39, 46);
            btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(156, 39, 46);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(1327, 39);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(122, 49);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(772, 44);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(109, 38);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "{Email}";
            // 
            // SingleEmployeeUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(127, 149, 209);
            Controls.Add(lblEmail);
            Controls.Add(btnDelete);
            Controls.Add(btnPromote);
            Controls.Add(lblRole);
            Controls.Add(lblUsername);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Controls.Add(lblId);
            Controls.Add(pictureBox1);
            Margin = new Padding(5);
            Name = "SingleEmployeeUC";
            Padding = new Padding(1);
            Size = new Size(1640, 120);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblId;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblUsername;
        private Label lblRole;
        private Button btnPromote;
        private Button btnDelete;
        private Label lblEmail;
    }
}
