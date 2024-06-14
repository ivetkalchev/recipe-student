namespace recipe_desktop
{
    partial class SingleRecipeUC
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
            picRecipe = new PictureBox();
            lblTitle = new Label();
            lblUser = new Label();
            btnDelete = new Button();
            btnEdit = new Button();
            ((System.ComponentModel.ISupportInitialize)picRecipe).BeginInit();
            SuspendLayout();
            // 
            // picRecipe
            // 
            picRecipe.Image = Properties.Resources.image_missing_icon_2048x2048_9it6buq7;
            picRecipe.Location = new Point(25, 19);
            picRecipe.Name = "picRecipe";
            picRecipe.Size = new Size(83, 81);
            picRecipe.SizeMode = PictureBoxSizeMode.StretchImage;
            picRecipe.TabIndex = 0;
            picRecipe.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(136, 50);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(75, 30);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "{Title}";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblUser.ForeColor = Color.White;
            lblUser.Location = new Point(968, 50);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(76, 30);
            lblUser.TabIndex = 4;
            lblUser.Text = "{User}";
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
            btnDelete.Location = new Point(1450, 39);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(122, 49);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
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
            btnEdit.Location = new Point(1356, 39);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(88, 49);
            btnEdit.TabIndex = 12;
            btnEdit.Text = "EDIT";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // SingleRecipeUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(127, 149, 209);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(lblUser);
            Controls.Add(lblTitle);
            Controls.Add(picRecipe);
            Margin = new Padding(5);
            Name = "SingleRecipeUC";
            Padding = new Padding(1);
            Size = new Size(1640, 120);
            ((System.ComponentModel.ISupportInitialize)picRecipe).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picRecipe;
        private Label lblTitle;
        private Label lblLastName;
        private Label lblUser;
        private Button btnDelete;
        private Button btnEdit;
    }
}
