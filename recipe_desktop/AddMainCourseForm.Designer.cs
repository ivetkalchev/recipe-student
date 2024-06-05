namespace recipe_desktop
{
    partial class AddMainCourseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMainCourseForm));
            btnClose = new Button();
            label1 = new Label();
            panel1 = new Panel();
            btnUpload = new Button();
            tbServings = new TextBox();
            label13 = new Label();
            rbSpicy = new RadioButton();
            label12 = new Label();
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
            pictureBox1 = new PictureBox();
            lbAddedIngredients = new ListBox();
            btnDelete = new Button();
            btnUploadPic = new Button();
            label14 = new Label();
            pbSearch = new PictureBox();
            tbSearchIng = new TextBox();
            label6 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSearch).BeginInit();
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
            btnClose.Location = new Point(893, 5);
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
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(54, 10);
            label1.Name = "label1";
            label1.Size = new Size(216, 40);
            label1.TabIndex = 40;
            label1.Text = "MAIN COURSE";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(182, 113, 169);
            panel1.Controls.Add(lbAddedIngredients);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnUpload);
            panel1.Controls.Add(btnUploadPic);
            panel1.Controls.Add(tbServings);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(pbSearch);
            panel1.Controls.Add(rbSpicy);
            panel1.Controls.Add(tbSearchIng);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(panelLoadIngredients);
            panel1.Controls.Add(cbDifficulty);
            panel1.Controls.Add(cbDietRestriction);
            panel1.Controls.Add(tbPrepTime);
            panel1.Controls.Add(tbCookingTime);
            panel1.Controls.Add(lblMaxInstr);
            panel1.Controls.Add(lblMaxDescr);
            panel1.Controls.Add(rtbInstructions);
            panel1.Controls.Add(rtbDescription);
            panel1.Controls.Add(tbTitle);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(7, 59);
            panel1.Name = "panel1";
            panel1.Size = new Size(930, 903);
            panel1.TabIndex = 0;
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
            btnUpload.Location = new Point(248, 843);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(416, 49);
            btnUpload.TabIndex = 72;
            btnUpload.Text = "UPLOAD";
            btnUpload.UseVisualStyleBackColor = false;
            btnUpload.Click += btnUpload_Click;
            // 
            // tbServings
            // 
            tbServings.Font = new Font("Segoe UI", 13F);
            tbServings.ForeColor = Color.Black;
            tbServings.Location = new Point(848, 416);
            tbServings.MaxLength = 100;
            tbServings.Name = "tbServings";
            tbServings.Size = new Size(56, 36);
            tbServings.TabIndex = 69;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label13.ForeColor = Color.FromArgb(98, 14, 80);
            label13.Location = new Point(674, 422);
            label13.Name = "label13";
            label13.Size = new Size(102, 30);
            label13.TabIndex = 68;
            label13.Text = "Servings";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rbSpicy
            // 
            rbSpicy.AutoSize = true;
            rbSpicy.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbSpicy.Location = new Point(156, 421);
            rbSpicy.Name = "rbSpicy";
            rbSpicy.Size = new Size(74, 29);
            rbSpicy.TabIndex = 67;
            rbSpicy.TabStop = true;
            rbSpicy.Text = "spicy";
            rbSpicy.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label12.ForeColor = Color.FromArgb(98, 14, 80);
            label12.Location = new Point(18, 420);
            label12.Name = "label12";
            label12.Size = new Size(68, 30);
            label12.TabIndex = 66;
            label12.Text = "More";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label11.ForeColor = Color.FromArgb(98, 14, 80);
            label11.Location = new Point(841, 218);
            label11.Name = "label11";
            label11.Size = new Size(63, 30);
            label11.TabIndex = 65;
            label11.Text = "Mins";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(98, 14, 80);
            label5.Location = new Point(841, 174);
            label5.Name = "label5";
            label5.Size = new Size(63, 30);
            label5.TabIndex = 64;
            label5.Text = "Mins";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelLoadIngredients
            // 
            panelLoadIngredients.BackColor = Color.FromArgb(98, 14, 80);
            panelLoadIngredients.Location = new Point(20, 512);
            panelLoadIngredients.Name = "panelLoadIngredients";
            panelLoadIngredients.Size = new Size(644, 325);
            panelLoadIngredients.TabIndex = 63;
            // 
            // cbDifficulty
            // 
            cbDifficulty.Font = new Font("Segoe UI", 13F);
            cbDifficulty.ForeColor = Color.Black;
            cbDifficulty.FormattingEnabled = true;
            cbDifficulty.Location = new Point(509, 120);
            cbDifficulty.Name = "cbDifficulty";
            cbDifficulty.Size = new Size(388, 38);
            cbDifficulty.TabIndex = 61;
            // 
            // cbDietRestriction
            // 
            cbDietRestriction.Font = new Font("Segoe UI", 13F);
            cbDietRestriction.ForeColor = Color.Black;
            cbDietRestriction.FormattingEnabled = true;
            cbDietRestriction.Location = new Point(509, 48);
            cbDietRestriction.Name = "cbDietRestriction";
            cbDietRestriction.Size = new Size(388, 38);
            cbDietRestriction.TabIndex = 60;
            // 
            // tbPrepTime
            // 
            tbPrepTime.Font = new Font("Segoe UI", 13F);
            tbPrepTime.ForeColor = Color.Black;
            tbPrepTime.Location = new Point(708, 168);
            tbPrepTime.MaxLength = 100;
            tbPrepTime.Name = "tbPrepTime";
            tbPrepTime.Size = new Size(127, 36);
            tbPrepTime.TabIndex = 59;
            // 
            // tbCookingTime
            // 
            tbCookingTime.Font = new Font("Segoe UI", 13F);
            tbCookingTime.ForeColor = Color.Black;
            tbCookingTime.Location = new Point(708, 212);
            tbCookingTime.MaxLength = 100;
            tbCookingTime.Name = "tbCookingTime";
            tbCookingTime.Size = new Size(127, 36);
            tbCookingTime.TabIndex = 58;
            // 
            // lblMaxInstr
            // 
            lblMaxInstr.AutoSize = true;
            lblMaxInstr.Font = new Font("Segoe UI", 12F);
            lblMaxInstr.ForeColor = Color.White;
            lblMaxInstr.Location = new Point(714, 250);
            lblMaxInstr.Name = "lblMaxInstr";
            lblMaxInstr.Size = new Size(190, 28);
            lblMaxInstr.TabIndex = 54;
            lblMaxInstr.Text = "max 4000 characters";
            lblMaxInstr.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMaxDescr
            // 
            lblMaxDescr.AutoSize = true;
            lblMaxDescr.Font = new Font("Segoe UI", 12F);
            lblMaxDescr.ForeColor = Color.White;
            lblMaxDescr.Location = new Point(295, 96);
            lblMaxDescr.Name = "lblMaxDescr";
            lblMaxDescr.Size = new Size(179, 28);
            lblMaxDescr.TabIndex = 53;
            lblMaxDescr.Text = "max 400 characters";
            lblMaxDescr.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rtbInstructions
            // 
            rtbInstructions.Location = new Point(20, 278);
            rtbInstructions.MaxLength = 4000;
            rtbInstructions.Name = "rtbInstructions";
            rtbInstructions.Size = new Size(884, 132);
            rtbInstructions.TabIndex = 52;
            rtbInstructions.Text = "";
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(20, 122);
            rtbDescription.MaxLength = 400;
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(450, 120);
            rtbDescription.TabIndex = 51;
            rtbDescription.Text = "";
            // 
            // tbTitle
            // 
            tbTitle.Font = new Font("Segoe UI", 13F);
            tbTitle.ForeColor = Color.Black;
            tbTitle.Location = new Point(24, 50);
            tbTitle.MaxLength = 100;
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(446, 36);
            tbTitle.TabIndex = 50;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label10.ForeColor = Color.FromArgb(98, 14, 80);
            label10.Location = new Point(509, 89);
            label10.Name = "label10";
            label10.RightToLeft = RightToLeft.Yes;
            label10.Size = new Size(108, 30);
            label10.TabIndex = 49;
            label10.Text = "Difficulty";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(98, 14, 80);
            label9.Location = new Point(509, 15);
            label9.Name = "label9";
            label9.Size = new Size(207, 30);
            label9.TabIndex = 48;
            label9.Text = "Dietary Restriction";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(98, 14, 80);
            label8.Location = new Point(509, 215);
            label8.Name = "label8";
            label8.Size = new Size(155, 30);
            label8.TabIndex = 47;
            label8.Text = "Cooking Time";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(98, 14, 80);
            label7.Location = new Point(509, 171);
            label7.Name = "label7";
            label7.Size = new Size(193, 30);
            label7.TabIndex = 46;
            label7.Text = "Preparation Time";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(98, 14, 80);
            label4.Location = new Point(20, 245);
            label4.Name = "label4";
            label4.Size = new Size(136, 30);
            label4.TabIndex = 43;
            label4.Text = "Instructions";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(98, 14, 80);
            label3.Location = new Point(20, 89);
            label3.Name = "label3";
            label3.Size = new Size(132, 30);
            label3.TabIndex = 42;
            label3.Text = "Description";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(98, 14, 80);
            label2.Location = new Point(20, 20);
            label2.Name = "label2";
            label2.Size = new Size(59, 30);
            label2.TabIndex = 41;
            label2.Text = "Title";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.restaurant_512_1;
            pictureBox1.Location = new Point(9, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lbAddedIngredients
            // 
            lbAddedIngredients.BackColor = Color.FromArgb(98, 14, 80);
            lbAddedIngredients.BorderStyle = BorderStyle.None;
            lbAddedIngredients.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbAddedIngredients.ForeColor = Color.White;
            lbAddedIngredients.FormattingEnabled = true;
            lbAddedIngredients.ItemHeight = 23;
            lbAddedIngredients.Location = new Point(670, 512);
            lbAddedIngredients.Name = "lbAddedIngredients";
            lbAddedIngredients.Size = new Size(236, 276);
            lbAddedIngredients.TabIndex = 85;
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
            btnDelete.Location = new Point(670, 794);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(236, 43);
            btnDelete.TabIndex = 84;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
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
            btnUploadPic.Location = new Point(864, 470);
            btnUploadPic.Margin = new Padding(6, 3, 3, 3);
            btnUploadPic.Name = "btnUploadPic";
            btnUploadPic.Padding = new Padding(2, 0, 0, 0);
            btnUploadPic.Size = new Size(42, 36);
            btnUploadPic.TabIndex = 83;
            btnUploadPic.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label14.ForeColor = Color.FromArgb(98, 14, 80);
            label14.Location = new Point(668, 473);
            label14.Name = "label14";
            label14.Size = new Size(161, 30);
            label14.TabIndex = 82;
            label14.Text = "Recipe Picture";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbSearch
            // 
            pbSearch.Image = (Image)resources.GetObject("pbSearch.Image");
            pbSearch.Location = new Point(625, 470);
            pbSearch.Name = "pbSearch";
            pbSearch.Size = new Size(37, 36);
            pbSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            pbSearch.TabIndex = 79;
            pbSearch.TabStop = false;
            // 
            // tbSearchIng
            // 
            tbSearchIng.Font = new Font("Segoe UI", 13F);
            tbSearchIng.ForeColor = Color.Black;
            tbSearchIng.Location = new Point(158, 470);
            tbSearchIng.MaxLength = 100;
            tbSearchIng.Name = "tbSearchIng";
            tbSearchIng.Size = new Size(461, 36);
            tbSearchIng.TabIndex = 81;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(98, 14, 80);
            label6.Location = new Point(20, 473);
            label6.Name = "label6";
            label6.Size = new Size(132, 30);
            label6.TabIndex = 80;
            label6.Text = "Ingredients";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AddMainCourseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(98, 14, 80);
            ClientSize = new Size(945, 969);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddMainCourseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Main Course";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSearch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnClose;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label4;
        private Label label3;
        private Label label8;
        private Label label7;
        private Label label9;
        private Label label10;
        private TextBox tbTitle;
        private RichTextBox rtbDescription;
        private RichTextBox rtbInstructions;
        private Label lblMaxInstr;
        private Label lblMaxDescr;
        private TextBox tbCookingTime;
        private TextBox tbPrepTime;
        private DateTimePicker dateTimePicker1;
        private ComboBox cbDifficulty;
        private ComboBox cbDietRestriction;
        private Panel panelLoadIngredients;
        private Label label5;
        private TextBox tbServings;
        private Label label13;
        private RadioButton rbSpicy;
        private Label label12;
        private Label label11;
        private Button btnUpload;
        private ListBox lbAddedIngredients;
        private Button btnDelete;
        private Button btnUploadPic;
        private Label label14;
        private PictureBox pbSearch;
        private TextBox tbSearchIng;
        private Label label6;
    }
}