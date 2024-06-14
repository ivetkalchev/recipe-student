﻿namespace recipe_desktop
{
    partial class EditDessertForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditDessertForm));
            btnClose = new Button();
            label1 = new Label();
            mainPanel = new Panel();
            btnEdit = new Button();
            lblNoResults = new Label();
            cbFreezing = new CheckBox();
            cbSugarFree = new CheckBox();
            lbAddedIngredients = new ListBox();
            btnDelete = new Button();
            panelLoadIngredients = new Panel();
            btnSave = new Button();
            pbSearch = new PictureBox();
            label12 = new Label();
            label11 = new Label();
            label5 = new Label();
            tbSearchIng = new TextBox();
            cbDifficulty = new ComboBox();
            cbDietRestriction = new ComboBox();
            tbPrepTime = new TextBox();
            tbCookingTime = new TextBox();
            rtbInstructions = new RichTextBox();
            rtbDescription = new RichTextBox();
            tbTitle = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            lblHeaderText = new Label();
            sideBarPanel1 = new SideBarPanel();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbSearch).BeginInit();
            sideBarPanel1.SuspendLayout();
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
            btnClose.Location = new Point(900, 8);
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
            label1.Location = new Point(367, -57);
            label1.Name = "label1";
            label1.Size = new Size(197, 40);
            label1.TabIndex = 40;
            label1.Text = "ADD RECIPES";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(182, 113, 169);
            mainPanel.Controls.Add(btnEdit);
            mainPanel.Controls.Add(lblNoResults);
            mainPanel.Controls.Add(cbFreezing);
            mainPanel.Controls.Add(cbSugarFree);
            mainPanel.Controls.Add(lbAddedIngredients);
            mainPanel.Controls.Add(btnDelete);
            mainPanel.Controls.Add(panelLoadIngredients);
            mainPanel.Controls.Add(btnSave);
            mainPanel.Controls.Add(pbSearch);
            mainPanel.Controls.Add(label12);
            mainPanel.Controls.Add(label11);
            mainPanel.Controls.Add(label5);
            mainPanel.Controls.Add(tbSearchIng);
            mainPanel.Controls.Add(cbDifficulty);
            mainPanel.Controls.Add(cbDietRestriction);
            mainPanel.Controls.Add(tbPrepTime);
            mainPanel.Controls.Add(tbCookingTime);
            mainPanel.Controls.Add(rtbInstructions);
            mainPanel.Controls.Add(rtbDescription);
            mainPanel.Controls.Add(tbTitle);
            mainPanel.Controls.Add(label10);
            mainPanel.Controls.Add(label9);
            mainPanel.Controls.Add(label8);
            mainPanel.Controls.Add(label7);
            mainPanel.Controls.Add(label6);
            mainPanel.Controls.Add(label4);
            mainPanel.Controls.Add(label3);
            mainPanel.Controls.Add(label2);
            mainPanel.Location = new Point(13, 56);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(930, 906);
            mainPanel.TabIndex = 0;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.White;
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderColor = Color.FromArgb(63, 8, 51);
            btnEdit.FlatAppearance.BorderSize = 2;
            btnEdit.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            btnEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnEdit.ForeColor = Color.FromArgb(98, 14, 80);
            btnEdit.Location = new Point(190, 845);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(235, 49);
            btnEdit.TabIndex = 156;
            btnEdit.Text = "EDIT";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // lblNoResults
            // 
            lblNoResults.AutoSize = true;
            lblNoResults.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNoResults.ForeColor = Color.White;
            lblNoResults.Location = new Point(672, 479);
            lblNoResults.Name = "lblNoResults";
            lblNoResults.Size = new Size(162, 25);
            lblNoResults.TabIndex = 154;
            lblNoResults.Text = "No Results Found";
            // 
            // cbFreezing
            // 
            cbFreezing.AutoSize = true;
            cbFreezing.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            cbFreezing.Location = new Point(299, 421);
            cbFreezing.Name = "cbFreezing";
            cbFreezing.Size = new Size(183, 29);
            cbFreezing.TabIndex = 153;
            cbFreezing.Text = "Requires Freezing";
            cbFreezing.UseVisualStyleBackColor = true;
            // 
            // cbSugarFree
            // 
            cbSugarFree.AutoSize = true;
            cbSugarFree.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            cbSugarFree.Location = new Point(160, 421);
            cbSugarFree.Name = "cbSugarFree";
            cbSugarFree.Size = new Size(123, 29);
            cbSugarFree.TabIndex = 152;
            cbSugarFree.Text = "Sugar Free";
            cbSugarFree.UseVisualStyleBackColor = true;
            // 
            // lbAddedIngredients
            // 
            lbAddedIngredients.BackColor = Color.FromArgb(98, 14, 80);
            lbAddedIngredients.BorderStyle = BorderStyle.None;
            lbAddedIngredients.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbAddedIngredients.ForeColor = Color.White;
            lbAddedIngredients.FormattingEnabled = true;
            lbAddedIngredients.ItemHeight = 23;
            lbAddedIngredients.Location = new Point(672, 510);
            lbAddedIngredients.Name = "lbAddedIngredients";
            lbAddedIngredients.Size = new Size(236, 276);
            lbAddedIngredients.TabIndex = 151;
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
            btnDelete.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(672, 792);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(236, 43);
            btnDelete.TabIndex = 150;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // panelLoadIngredients
            // 
            panelLoadIngredients.BackColor = Color.FromArgb(98, 14, 80);
            panelLoadIngredients.Location = new Point(22, 510);
            panelLoadIngredients.Name = "panelLoadIngredients";
            panelLoadIngredients.Size = new Size(644, 325);
            panelLoadIngredients.TabIndex = 149;
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
            btnSave.Location = new Point(431, 845);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(235, 49);
            btnSave.TabIndex = 148;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // pbSearch
            // 
            pbSearch.Image = (Image)resources.GetObject("pbSearch.Image");
            pbSearch.Location = new Point(629, 468);
            pbSearch.Name = "pbSearch";
            pbSearch.Size = new Size(37, 36);
            pbSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSearch.TabIndex = 125;
            pbSearch.TabStop = false;
            pbSearch.Click += pbSearch_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label12.ForeColor = Color.FromArgb(98, 14, 80);
            label12.Location = new Point(22, 418);
            label12.Name = "label12";
            label12.Size = new Size(68, 30);
            label12.TabIndex = 145;
            label12.Text = "More";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label11.ForeColor = Color.FromArgb(98, 14, 80);
            label11.Location = new Point(845, 216);
            label11.Name = "label11";
            label11.Size = new Size(63, 30);
            label11.TabIndex = 144;
            label11.Text = "Mins";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(98, 14, 80);
            label5.Location = new Point(845, 172);
            label5.Name = "label5";
            label5.Size = new Size(63, 30);
            label5.TabIndex = 143;
            label5.Text = "Mins";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbSearchIng
            // 
            tbSearchIng.Font = new Font("Segoe UI", 13F);
            tbSearchIng.ForeColor = Color.Black;
            tbSearchIng.Location = new Point(160, 468);
            tbSearchIng.MaxLength = 100;
            tbSearchIng.Name = "tbSearchIng";
            tbSearchIng.Size = new Size(463, 36);
            tbSearchIng.TabIndex = 142;
            // 
            // cbDifficulty
            // 
            cbDifficulty.Font = new Font("Segoe UI", 13F);
            cbDifficulty.ForeColor = Color.Black;
            cbDifficulty.FormattingEnabled = true;
            cbDifficulty.Location = new Point(513, 118);
            cbDifficulty.Name = "cbDifficulty";
            cbDifficulty.Size = new Size(388, 38);
            cbDifficulty.TabIndex = 141;
            // 
            // cbDietRestriction
            // 
            cbDietRestriction.Font = new Font("Segoe UI", 13F);
            cbDietRestriction.ForeColor = Color.Black;
            cbDietRestriction.FormattingEnabled = true;
            cbDietRestriction.Location = new Point(513, 46);
            cbDietRestriction.Name = "cbDietRestriction";
            cbDietRestriction.Size = new Size(388, 38);
            cbDietRestriction.TabIndex = 140;
            // 
            // tbPrepTime
            // 
            tbPrepTime.Font = new Font("Segoe UI", 13F);
            tbPrepTime.ForeColor = Color.Black;
            tbPrepTime.Location = new Point(712, 166);
            tbPrepTime.MaxLength = 100;
            tbPrepTime.Name = "tbPrepTime";
            tbPrepTime.Size = new Size(127, 36);
            tbPrepTime.TabIndex = 139;
            // 
            // tbCookingTime
            // 
            tbCookingTime.Font = new Font("Segoe UI", 13F);
            tbCookingTime.ForeColor = Color.Black;
            tbCookingTime.Location = new Point(712, 210);
            tbCookingTime.MaxLength = 100;
            tbCookingTime.Name = "tbCookingTime";
            tbCookingTime.Size = new Size(127, 36);
            tbCookingTime.TabIndex = 138;
            // 
            // rtbInstructions
            // 
            rtbInstructions.Location = new Point(24, 276);
            rtbInstructions.MaxLength = 4000;
            rtbInstructions.Name = "rtbInstructions";
            rtbInstructions.Size = new Size(884, 132);
            rtbInstructions.TabIndex = 135;
            rtbInstructions.Text = "";
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(24, 120);
            rtbDescription.MaxLength = 400;
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(450, 120);
            rtbDescription.TabIndex = 134;
            rtbDescription.Text = "";
            // 
            // tbTitle
            // 
            tbTitle.Font = new Font("Segoe UI", 13F);
            tbTitle.ForeColor = Color.Black;
            tbTitle.Location = new Point(28, 48);
            tbTitle.MaxLength = 100;
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(446, 36);
            tbTitle.TabIndex = 133;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label10.ForeColor = Color.FromArgb(98, 14, 80);
            label10.Location = new Point(513, 87);
            label10.Name = "label10";
            label10.RightToLeft = RightToLeft.Yes;
            label10.Size = new Size(108, 30);
            label10.TabIndex = 132;
            label10.Text = "Difficulty";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(98, 14, 80);
            label9.Location = new Point(513, 13);
            label9.Name = "label9";
            label9.Size = new Size(207, 30);
            label9.TabIndex = 131;
            label9.Text = "Dietary Restriction";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(98, 14, 80);
            label8.Location = new Point(513, 213);
            label8.Name = "label8";
            label8.Size = new Size(155, 30);
            label8.TabIndex = 130;
            label8.Text = "Cooking Time";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(98, 14, 80);
            label7.Location = new Point(513, 169);
            label7.Name = "label7";
            label7.Size = new Size(193, 30);
            label7.TabIndex = 129;
            label7.Text = "Preparation Time";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(98, 14, 80);
            label6.Location = new Point(22, 471);
            label6.Name = "label6";
            label6.Size = new Size(132, 30);
            label6.TabIndex = 128;
            label6.Text = "Ingredients";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(98, 14, 80);
            label4.Location = new Point(24, 243);
            label4.Name = "label4";
            label4.Size = new Size(136, 30);
            label4.TabIndex = 127;
            label4.Text = "Instructions";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(98, 14, 80);
            label3.Location = new Point(24, 87);
            label3.Name = "label3";
            label3.Size = new Size(132, 30);
            label3.TabIndex = 126;
            label3.Text = "Description";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(98, 14, 80);
            label2.Location = new Point(24, 18);
            label2.Name = "label2";
            label2.Size = new Size(59, 30);
            label2.TabIndex = 124;
            label2.Text = "Title";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHeaderText
            // 
            lblHeaderText.AutoSize = true;
            lblHeaderText.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeaderText.ForeColor = Color.White;
            lblHeaderText.Location = new Point(304, 11);
            lblHeaderText.Name = "lblHeaderText";
            lblHeaderText.Size = new Size(323, 38);
            lblHeaderText.TabIndex = 44;
            lblHeaderText.Text = "Edit The Dessert Recipe";
            // 
            // sideBarPanel1
            // 
            sideBarPanel1.Controls.Add(lblHeaderText);
            sideBarPanel1.Controls.Add(btnClose);
            sideBarPanel1.Controls.Add(mainPanel);
            sideBarPanel1.gradientBottom = Color.FromArgb(65, 11, 54);
            sideBarPanel1.gradientTop = Color.FromArgb(98, 14, 80);
            sideBarPanel1.Location = new Point(-4, -2);
            sideBarPanel1.Name = "sideBarPanel1";
            sideBarPanel1.Size = new Size(954, 981);
            sideBarPanel1.TabIndex = 0;
            // 
            // EditDessertForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(98, 14, 80);
            ClientSize = new Size(951, 974);
            Controls.Add(label1);
            Controls.Add(sideBarPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditDessertForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Recipes";
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbSearch).EndInit();
            sideBarPanel1.ResumeLayout(false);
            sideBarPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnClose;
        private Label label1;
        private Panel mainPanel;
        private Label lblHeaderText;
        private SideBarPanel sideBarPanel1;
        private Label lblNoResults;
        private CheckBox cbFreezing;
        private CheckBox cbSugarFree;
        private ListBox lbAddedIngredients;
        private Button btnDelete;
        private Panel panelLoadIngredients;
        private Button btnSave;
        private PictureBox pbSearch;
        private Label label12;
        private Label label11;
        private Label label5;
        private TextBox tbSearchIng;
        private ComboBox cbDifficulty;
        private ComboBox cbDietRestriction;
        private TextBox tbPrepTime;
        private TextBox tbCookingTime;
        private RichTextBox rtbInstructions;
        private RichTextBox rtbDescription;
        private TextBox tbTitle;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnEdit;
    }
}