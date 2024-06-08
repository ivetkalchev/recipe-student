namespace recipe_desktop
{
    partial class SingleIngredientRecipeUC
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
            cbUnit = new ComboBox();
            btnAdd = new Button();
            nudPrice = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(98, 14, 80);
            lblName.Location = new Point(19, 32);
            lblName.Name = "lblName";
            lblName.Size = new Size(99, 32);
            lblName.TabIndex = 5;
            lblName.Text = "{Name}";
            // 
            // cbUnit
            // 
            cbUnit.Font = new Font("Segoe UI", 13F);
            cbUnit.ForeColor = Color.Black;
            cbUnit.FormattingEnabled = true;
            cbUnit.Location = new Point(428, 30);
            cbUnit.Name = "cbUnit";
            cbUnit.Size = new Size(80, 38);
            cbUnit.TabIndex = 61;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(98, 14, 80);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderColor = Color.FromArgb(63, 8, 51);
            btnAdd.FlatAppearance.BorderSize = 2;
            btnAdd.FlatAppearance.MouseDownBackColor = Color.FromArgb(63, 8, 51);
            btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 8, 51);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(524, 28);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(79, 41);
            btnAdd.TabIndex = 73;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // nudPrice
            // 
            nudPrice.DecimalPlaces = 3;
            nudPrice.Font = new Font("Segoe UI", 12F);
            nudPrice.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
            nudPrice.Location = new Point(303, 32);
            nudPrice.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            nudPrice.Name = "nudPrice";
            nudPrice.Size = new Size(119, 34);
            nudPrice.TabIndex = 74;
            // 
            // SingleIngredientRecipeUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(232, 170, 219);
            Controls.Add(nudPrice);
            Controls.Add(btnAdd);
            Controls.Add(cbUnit);
            Controls.Add(lblName);
            Name = "SingleIngredientRecipeUC";
            Size = new Size(622, 94);
            ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private ComboBox cbUnit;
        private Button btnAdd;
        private NumericUpDown nudPrice;
    }
}
