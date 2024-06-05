namespace recipe_desktop
{
    partial class SingleIngredientUC
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
            lblName = new Label();
            lblType = new Label();
            lblPrice = new Label();
            btnDelete = new Button();
            pictureBox1 = new PictureBox();
            btnEdit = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(209, 48);
            lblName.Name = "lblName";
            lblName.Size = new Size(90, 30);
            lblName.TabIndex = 2;
            lblName.Text = "{Name}";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblType.ForeColor = Color.White;
            lblType.Location = new Point(452, 48);
            lblType.Name = "lblType";
            lblType.Size = new Size(79, 30);
            lblType.TabIndex = 3;
            lblType.Text = "{Type}";
            lblType.Click += lblType_Click;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblPrice.ForeColor = Color.White;
            lblPrice.Location = new Point(694, 48);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(100, 30);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "{€ Price}";
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
            btnDelete.Location = new Point(1375, 37);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(122, 49);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._2770013;
            pictureBox1.Location = new Point(66, 18);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(83, 81);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.White;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderColor = Color.FromArgb(46, 76, 157);
            btnEdit.FlatAppearance.BorderSize = 2;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnEdit.ForeColor = Color.FromArgb(46, 76, 157);
            btnEdit.Location = new Point(1229, 37);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(125, 49);
            btnEdit.TabIndex = 10;
            btnEdit.Text = "EDIT";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // SingleIngredientUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(127, 149, 209);
            Controls.Add(btnEdit);
            Controls.Add(pictureBox1);
            Controls.Add(btnDelete);
            Controls.Add(lblPrice);
            Controls.Add(lblType);
            Controls.Add(lblName);
            Margin = new Padding(5);
            Name = "SingleIngredientUC";
            Padding = new Padding(1);
            Size = new Size(1640, 120);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblName;
        private Label lblType;
        private Label lblPrice;
        private Button btnDelete;
        private PictureBox pictureBox1;
        private Button btnEdit;
    }
}
