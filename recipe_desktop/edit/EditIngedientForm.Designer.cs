﻿namespace recipe_desktop
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
            cbTypeIngredient = new ComboBox();
            lblType = new Label();
            panel1.SuspendLayout();
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
            label1.Location = new Point(145, 8);
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
            btnSave.Location = new Point(313, 220);
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
            btnEdit.Location = new Point(77, 220);
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
            panel1.Controls.Add(cbTypeIngredient);
            panel1.Controls.Add(lblType);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(lblName);
            panel1.Controls.Add(tbName);
            panel1.Location = new Point(5, 56);
            panel1.Name = "panel1";
            panel1.Size = new Size(618, 283);
            panel1.TabIndex = 0;
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
            ClientSize = new Size(628, 345);
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
        private Label lblType;
        private ComboBox cbTypeIngredient;
    }
}