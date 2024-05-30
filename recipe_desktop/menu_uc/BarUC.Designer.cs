namespace recipe_desktop
{
    partial class BarUC
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
            lblClose = new Label();
            SuspendLayout();
            // 
            // lblClose
            // 
            lblClose.AutoSize = true;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Dock = DockStyle.Right;
            lblClose.Font = new Font("Snap ITC", 25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClose.ForeColor = Color.White;
            lblClose.Location = new Point(1908, 0);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(60, 54);
            lblClose.TabIndex = 0;
            lblClose.Text = "X";
            lblClose.Click += lblClose_Click;
            lblClose.MouseLeave += lblClose_MouseLeave;
            lblClose.MouseHover += lblClose_MouseHover;
            // 
            // BarUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(61, 83, 143);
            Controls.Add(lblClose);
            Name = "BarUC";
            Size = new Size(1968, 51);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblClose;
    }
}
