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
            SuspendLayout();
            // 
            // panelEmployee
            // 
            panelEmployee.Location = new Point(13, 139);
            panelEmployee.Margin = new Padding(5);
            panelEmployee.Name = "panelEmployee";
            panelEmployee.Padding = new Padding(4);
            panelEmployee.Size = new Size(1650, 654);
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
            btnNext.Location = new Point(812, 806);
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
            btnPrevious.Location = new Point(620, 807);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(161, 49);
            btnPrevious.TabIndex = 8;
            btnPrevious.Text = "PREVIOUS";
            btnPrevious.UseVisualStyleBackColor = false;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // EmployeesUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            Controls.Add(btnPrevious);
            Controls.Add(btnNext);
            Controls.Add(panelEmployee);
            Name = "EmployeesUC";
            Size = new Size(1698, 870);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelEmployee;
        private Button btnNext;
        private Button btnPrevious;
    }
}
