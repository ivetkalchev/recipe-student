﻿namespace recipe_desktop
{
    partial class AddMainCourseUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMainCourseUC));
            lbAddedIngredients = new ListBox();
            btnDelete = new Button();
            btnUpload = new Button();
            btnUploadPic = new Button();
            tbServings = new TextBox();
            label14 = new Label();
            label13 = new Label();
            pbSearch = new PictureBox();
            tbSearchIng = new TextBox();
            label12 = new Label();
            label6 = new Label();
            label11 = new Label();
            label5 = new Label();
            panelLoadIngredients = new Panel();
            cbDifficulty = new ComboBox();
            cbDietRestriction = new ComboBox();
            tbPrepTime = new TextBox();
            tbCookingTime = new TextBox();
            lblMaxInstr = new Label();
            lblMaxDescr = new Label();
            rtbInstructions = new RichTextBox();
            rtbDescription = new RichTextBox();
            tbTitle = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            cbSpicy = new CheckBox();
            lblNoResults = new Label();
            ((System.ComponentModel.ISupportInitialize)pbSearch).BeginInit();
            SuspendLayout();
            // 
            // lbAddedIngredients
            // 
            lbAddedIngredients.BackColor = Color.FromArgb(98, 14, 80);
            lbAddedIngredients.BorderStyle = BorderStyle.None;
            lbAddedIngredients.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbAddedIngredients.ForeColor = Color.White;
            lbAddedIngredients.FormattingEnabled = true;
            lbAddedIngredients.ItemHeight = 23;
            lbAddedIngredients.Location = new Point(673, 510);
            lbAddedIngredients.Name = "lbAddedIngredients";
            lbAddedIngredients.Size = new Size(236, 276);
            lbAddedIngredients.TabIndex = 116;
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
            btnDelete.Location = new Point(673, 792);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(236, 43);
            btnDelete.TabIndex = 115;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpload
            // 
            btnUpload.BackColor = Color.FromArgb(98, 14, 80);
            btnUpload.Cursor = Cursors.Hand;
            btnUpload.FlatAppearance.BorderColor = Color.FromArgb(63, 8, 51);
            btnUpload.FlatAppearance.BorderSize = 2;
            btnUpload.FlatAppearance.MouseDownBackColor = Color.FromArgb(63, 8, 51);
            btnUpload.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 8, 51);
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnUpload.ForeColor = Color.White;
            btnUpload.Location = new Point(250, 845);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(416, 49);
            btnUpload.TabIndex = 109;
            btnUpload.Text = "UPLOAD";
            btnUpload.UseVisualStyleBackColor = false;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnUploadPic
            // 
            btnUploadPic.BackColor = Color.FromArgb(98, 14, 80);
            btnUploadPic.BackgroundImage = Properties.Resources.paper_clip_48;
            btnUploadPic.BackgroundImageLayout = ImageLayout.Stretch;
            btnUploadPic.FlatAppearance.BorderColor = Color.FromArgb(63, 8, 51);
            btnUploadPic.FlatAppearance.BorderSize = 2;
            btnUploadPic.FlatAppearance.MouseDownBackColor = Color.FromArgb(63, 8, 51);
            btnUploadPic.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 8, 51);
            btnUploadPic.FlatStyle = FlatStyle.Flat;
            btnUploadPic.Location = new Point(867, 468);
            btnUploadPic.Margin = new Padding(6, 3, 3, 3);
            btnUploadPic.Name = "btnUploadPic";
            btnUploadPic.Padding = new Padding(2, 0, 0, 0);
            btnUploadPic.Size = new Size(42, 36);
            btnUploadPic.TabIndex = 114;
            btnUploadPic.UseVisualStyleBackColor = false;
            btnUploadPic.Click += btnUploadPic_Click;
            // 
            // tbServings
            // 
            tbServings.Font = new Font("Segoe UI", 13F);
            tbServings.ForeColor = Color.Black;
            tbServings.Location = new Point(851, 414);
            tbServings.MaxLength = 100;
            tbServings.Name = "tbServings";
            tbServings.Size = new Size(56, 36);
            tbServings.TabIndex = 108;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label14.ForeColor = Color.FromArgb(98, 14, 80);
            label14.Location = new Point(671, 471);
            label14.Name = "label14";
            label14.Size = new Size(161, 30);
            label14.TabIndex = 113;
            label14.Text = "Recipe Picture";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label13.ForeColor = Color.FromArgb(98, 14, 80);
            label13.Location = new Point(673, 418);
            label13.Name = "label13";
            label13.Size = new Size(102, 30);
            label13.TabIndex = 107;
            label13.Text = "Servings";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbSearch
            // 
            pbSearch.Image = (Image)resources.GetObject("pbSearch.Image");
            pbSearch.Location = new Point(462, 468);
            pbSearch.Name = "pbSearch";
            pbSearch.Size = new Size(37, 36);
            pbSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSearch.TabIndex = 110;
            pbSearch.TabStop = false;
            pbSearch.Click += pbSearch_Click;
            // 
            // tbSearchIng
            // 
            tbSearchIng.Font = new Font("Segoe UI", 13F);
            tbSearchIng.ForeColor = Color.Black;
            tbSearchIng.Location = new Point(161, 468);
            tbSearchIng.MaxLength = 100;
            tbSearchIng.Name = "tbSearchIng";
            tbSearchIng.Size = new Size(300, 36);
            tbSearchIng.TabIndex = 112;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label12.ForeColor = Color.FromArgb(98, 14, 80);
            label12.Location = new Point(21, 418);
            label12.Name = "label12";
            label12.Size = new Size(68, 30);
            label12.TabIndex = 105;
            label12.Text = "More";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(98, 14, 80);
            label6.Location = new Point(23, 471);
            label6.Name = "label6";
            label6.Size = new Size(132, 30);
            label6.TabIndex = 111;
            label6.Text = "Ingredients";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label11.ForeColor = Color.FromArgb(98, 14, 80);
            label11.Location = new Point(844, 216);
            label11.Name = "label11";
            label11.Size = new Size(63, 30);
            label11.TabIndex = 104;
            label11.Text = "Mins";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(98, 14, 80);
            label5.Location = new Point(844, 172);
            label5.Name = "label5";
            label5.Size = new Size(63, 30);
            label5.TabIndex = 103;
            label5.Text = "Mins";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelLoadIngredients
            // 
            panelLoadIngredients.BackColor = Color.FromArgb(98, 14, 80);
            panelLoadIngredients.Location = new Point(23, 510);
            panelLoadIngredients.Name = "panelLoadIngredients";
            panelLoadIngredients.Size = new Size(644, 325);
            panelLoadIngredients.TabIndex = 102;
            // 
            // cbDifficulty
            // 
            cbDifficulty.Font = new Font("Segoe UI", 13F);
            cbDifficulty.ForeColor = Color.Black;
            cbDifficulty.FormattingEnabled = true;
            cbDifficulty.Location = new Point(512, 118);
            cbDifficulty.Name = "cbDifficulty";
            cbDifficulty.Size = new Size(388, 38);
            cbDifficulty.TabIndex = 101;
            // 
            // cbDietRestriction
            // 
            cbDietRestriction.Font = new Font("Segoe UI", 13F);
            cbDietRestriction.ForeColor = Color.Black;
            cbDietRestriction.FormattingEnabled = true;
            cbDietRestriction.Location = new Point(512, 46);
            cbDietRestriction.Name = "cbDietRestriction";
            cbDietRestriction.Size = new Size(388, 38);
            cbDietRestriction.TabIndex = 100;
            // 
            // tbPrepTime
            // 
            tbPrepTime.Font = new Font("Segoe UI", 13F);
            tbPrepTime.ForeColor = Color.Black;
            tbPrepTime.Location = new Point(711, 166);
            tbPrepTime.MaxLength = 100;
            tbPrepTime.Name = "tbPrepTime";
            tbPrepTime.Size = new Size(127, 36);
            tbPrepTime.TabIndex = 99;
            // 
            // tbCookingTime
            // 
            tbCookingTime.Font = new Font("Segoe UI", 13F);
            tbCookingTime.ForeColor = Color.Black;
            tbCookingTime.Location = new Point(711, 210);
            tbCookingTime.MaxLength = 100;
            tbCookingTime.Name = "tbCookingTime";
            tbCookingTime.Size = new Size(127, 36);
            tbCookingTime.TabIndex = 98;
            // 
            // lblMaxInstr
            // 
            lblMaxInstr.AutoSize = true;
            lblMaxInstr.Font = new Font("Segoe UI", 12F);
            lblMaxInstr.ForeColor = Color.White;
            lblMaxInstr.ImageAlign = ContentAlignment.MiddleRight;
            lblMaxInstr.Location = new Point(691, 249);
            lblMaxInstr.Name = "lblMaxInstr";
            lblMaxInstr.Size = new Size(218, 28);
            lblMaxInstr.TabIndex = 97;
            lblMaxInstr.Text = "Instructions: 4000/4000";
            lblMaxInstr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblMaxDescr
            // 
            lblMaxDescr.AutoSize = true;
            lblMaxDescr.Font = new Font("Segoe UI", 12F);
            lblMaxDescr.ForeColor = Color.White;
            lblMaxDescr.ImageAlign = ContentAlignment.MiddleRight;
            lblMaxDescr.Location = new Point(278, 89);
            lblMaxDescr.Name = "lblMaxDescr";
            lblMaxDescr.Size = new Size(195, 28);
            lblMaxDescr.TabIndex = 96;
            lblMaxDescr.Text = "Description: 400/400";
            lblMaxDescr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // rtbInstructions
            // 
            rtbInstructions.Location = new Point(23, 276);
            rtbInstructions.MaxLength = 4000;
            rtbInstructions.Name = "rtbInstructions";
            rtbInstructions.Size = new Size(884, 132);
            rtbInstructions.TabIndex = 95;
            rtbInstructions.Text = "";
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(23, 120);
            rtbDescription.MaxLength = 400;
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(450, 120);
            rtbDescription.TabIndex = 94;
            rtbDescription.Text = "";
            // 
            // tbTitle
            // 
            tbTitle.Font = new Font("Segoe UI", 13F);
            tbTitle.ForeColor = Color.Black;
            tbTitle.Location = new Point(27, 48);
            tbTitle.MaxLength = 100;
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(446, 36);
            tbTitle.TabIndex = 93;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label10.ForeColor = Color.FromArgb(98, 14, 80);
            label10.Location = new Point(512, 87);
            label10.Name = "label10";
            label10.RightToLeft = RightToLeft.Yes;
            label10.Size = new Size(108, 30);
            label10.TabIndex = 92;
            label10.Text = "Difficulty";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(98, 14, 80);
            label9.Location = new Point(512, 13);
            label9.Name = "label9";
            label9.Size = new Size(207, 30);
            label9.TabIndex = 91;
            label9.Text = "Dietary Restriction";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(98, 14, 80);
            label8.Location = new Point(512, 213);
            label8.Name = "label8";
            label8.Size = new Size(155, 30);
            label8.TabIndex = 90;
            label8.Text = "Cooking Time";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(98, 14, 80);
            label7.Location = new Point(512, 169);
            label7.Name = "label7";
            label7.Size = new Size(193, 30);
            label7.TabIndex = 89;
            label7.Text = "Preparation Time";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(98, 14, 80);
            label4.Location = new Point(23, 243);
            label4.Name = "label4";
            label4.Size = new Size(136, 30);
            label4.TabIndex = 88;
            label4.Text = "Instructions";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(98, 14, 80);
            label3.Location = new Point(23, 87);
            label3.Name = "label3";
            label3.Size = new Size(132, 30);
            label3.TabIndex = 87;
            label3.Text = "Description";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(98, 14, 80);
            label2.Location = new Point(23, 18);
            label2.Name = "label2";
            label2.Size = new Size(59, 30);
            label2.TabIndex = 86;
            label2.Text = "Title";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbSpicy
            // 
            cbSpicy.AutoSize = true;
            cbSpicy.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            cbSpicy.Location = new Point(161, 423);
            cbSpicy.Name = "cbSpicy";
            cbSpicy.Size = new Size(77, 29);
            cbSpicy.TabIndex = 121;
            cbSpicy.Text = "Spicy";
            cbSpicy.UseVisualStyleBackColor = true;
            // 
            // lblNoResults
            // 
            lblNoResults.AutoSize = true;
            lblNoResults.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNoResults.ForeColor = Color.White;
            lblNoResults.Location = new Point(505, 479);
            lblNoResults.Name = "lblNoResults";
            lblNoResults.Size = new Size(162, 25);
            lblNoResults.TabIndex = 122;
            lblNoResults.Text = "No Results Found";
            // 
            // AddMainCourseUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(182, 113, 169);
            Controls.Add(lblNoResults);
            Controls.Add(cbSpicy);
            Controls.Add(lbAddedIngredients);
            Controls.Add(btnDelete);
            Controls.Add(btnUpload);
            Controls.Add(btnUploadPic);
            Controls.Add(tbServings);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(pbSearch);
            Controls.Add(tbSearchIng);
            Controls.Add(label12);
            Controls.Add(label6);
            Controls.Add(label11);
            Controls.Add(label5);
            Controls.Add(panelLoadIngredients);
            Controls.Add(cbDifficulty);
            Controls.Add(cbDietRestriction);
            Controls.Add(tbPrepTime);
            Controls.Add(tbCookingTime);
            Controls.Add(lblMaxInstr);
            Controls.Add(rtbInstructions);
            Controls.Add(rtbDescription);
            Controls.Add(tbTitle);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblMaxDescr);
            Name = "AddMainCourseUC";
            Size = new Size(930, 903);
            ((System.ComponentModel.ISupportInitialize)pbSearch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbAddedIngredients;
        private Button btnDelete;
        private Button btnUpload;
        private Button btnUploadPic;
        private TextBox tbServings;
        private Label label14;
        private Label label13;
        private PictureBox pbSearch;
        private TextBox tbSearchIng;
        private Label label12;
        private Label label6;
        private Label label11;
        private Label label5;
        private Panel panelLoadIngredients;
        private ComboBox cbDifficulty;
        private ComboBox cbDietRestriction;
        private TextBox tbPrepTime;
        private TextBox tbCookingTime;
        private Label lblMaxInstr;
        private Label lblMaxDescr;
        private RichTextBox rtbInstructions;
        private RichTextBox rtbDescription;
        private TextBox tbTitle;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label4;
        private Label label3;
        private Label label2;
        private CheckBox cbSpicy;
        private Label lblNoResults;
    }
}
