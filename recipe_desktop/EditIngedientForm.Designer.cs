namespace recipe_desktop
{
    partial class EditIngredientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditIngredientForm));
            btnClose = new Button();
            label1 = new Label();
            tbName = new TextBox();
            lblName = new Label();
            btnSave = new Button();
            btnEdit = new Button();
            panel1 = new Panel();
            nudPrice = new NumericUpDown();
            label2 = new Label();
            cbTypeIngredient = new ComboBox();
            lblPrice = new Label();
            lblType = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            SuspendLayout();
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
            btnClose.Location = new Point(581, 8);
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
            label1.Location = new Point(149, 8);
            label1.Name = "label1";
            label1.Size = new Size(310, 40);
            label1.TabIndex = 40;
            label1.Text = "EDIT AN INGREDIENT";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbName
            // 
            tbName.Font = new Font("Segoe UI", 18F);
            tbName.ForeColor = Color.Black;
            tbName.Location = new Point(77, 55);
            tbName.MaxLength = 100;
            tbName.Name = "tbName";
            tbName.Size = new Size(456, 47);
            tbName.TabIndex = 24;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(98, 14, 80);
            lblName.Location = new Point(71, 12);
            lblName.Name = "lblName";
            lblName.Size = new Size(99, 40);
            lblName.TabIndex = 25;
            lblName.Text = "Name";
            lblName.TextAlign = ContentAlignment.TopCenter;
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
            btnSave.Location = new Point(313, 316);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(220, 49);
            btnSave.TabIndex = 40;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
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
            btnEdit.Location = new Point(77, 316);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(220, 49);
            btnEdit.TabIndex = 43;
            btnEdit.Text = "EDIT";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(182, 113, 169);
            panel1.Controls.Add(nudPrice);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbTypeIngredient);
            panel1.Controls.Add(lblPrice);
            panel1.Controls.Add(lblType);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(lblName);
            panel1.Controls.Add(tbName);
            panel1.Location = new Point(5, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(618, 386);
            panel1.TabIndex = 0;
            // 
            // nudPrice
            // 
            nudPrice.DecimalPlaces = 2;
            nudPrice.Font = new Font("Segoe UI", 19F);
            nudPrice.ForeColor = Color.Black;
            nudPrice.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
            nudPrice.Location = new Point(77, 241);
            nudPrice.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(261, 50);
            nudPrice.TabIndex = 41;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(98, 14, 80);
            label2.Location = new Point(344, 245);
            label2.Name = "label2";
            label2.Size = new Size(202, 46);
            label2.TabIndex = 49;
            label2.Text = "€ (per kg/l)";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // cbTypeIngredient
            // 
            cbTypeIngredient.Font = new Font("Segoe UI", 18F);
            cbTypeIngredient.ForeColor = Color.Black;
            cbTypeIngredient.FormattingEnabled = true;
            cbTypeIngredient.Location = new Point(77, 148);
            cbTypeIngredient.Name = "cbTypeIngredient";
            cbTypeIngredient.Size = new Size(456, 49);
            cbTypeIngredient.TabIndex = 48;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(98, 14, 80);
            lblPrice.Location = new Point(71, 198);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(85, 40);
            lblPrice.TabIndex = 45;
            lblPrice.Text = "Price";
            lblPrice.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblType.ForeColor = Color.FromArgb(98, 14, 80);
            lblType.Location = new Point(71, 105);
            lblType.Name = "lblType";
            lblType.Size = new Size(83, 40);
            lblType.TabIndex = 44;
            lblType.Text = "Type";
            lblType.TextAlign = ContentAlignment.TopCenter;
            // 
            // EditIngredientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(98, 14, 80);
            ClientSize = new Size(628, 448);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditIngredientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Ingredient";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnClose;
        private Label label1;
        private TextBox tbName;
        private Label lblName;
        private Button btnSave;
        private Button btnEdit;
        private Panel panel1;
        private Label lblPrice;
        private Label lblType;
        private ComboBox cbTypeIngredient;
        private Label label2;
        private NumericUpDown nudPrice;
    }
}