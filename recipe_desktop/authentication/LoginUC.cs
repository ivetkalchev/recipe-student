﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using manager_classes;

namespace recipe_desktop
{
    public partial class LoginUC : UserControl
    {
        private IUserManager userManager;
        public LoginUC(IUserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbUsername.Clear();
            tbPassword.Clear();
        }
        private void lblRegister_MouseHover(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.FromArgb(255, 255, 255);
        }
        private void lblRegister_MouseLeave(object sender, EventArgs e)
        {
            lblRegister.ForeColor = Color.FromArgb(61, 83, 143);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
        }
        private void OpenHomePage()
        {
            HomePageForm homePage = new HomePageForm();
            homePage.Show();
        }
        private void lblRegister_Click(object sender, EventArgs e)
        {
            AuthenticationForm parentForm = this.ParentForm as AuthenticationForm;
            parentForm.ClearPanel();
            parentForm.LoadRegister();
        }
        private void picPassword_Click(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = !tbPassword.UseSystemPasswordChar;
        }
    }
}
