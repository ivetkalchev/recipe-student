using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recipe_desktop
{
    public partial class MenuUC : UserControl
    {
        private string menuTitle = "";
        private Image icon;

        public event EventHandler MenuClick;

        public string MenuTitle
        {
            get { return menuTitle; }
            set
            {
                menuTitle = value;
                this.Invalidate();
            }
        }

        public Image Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                this.Invalidate();
            }
        }

        public MenuUC()
        {
            InitializeComponent();
            // Wire up the Click event of the menu control
            menu.Click += Menu_Click;
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            // When the menu control is clicked, raise the MenuClick event
            MenuClick?.Invoke(this, e);
        }

        private void MenuUC_Paint(object sender, PaintEventArgs e)
        {
            // Set the text and image of the menu control
            menu.Text = menuTitle;
            menu.Image = icon;
        }
    }
}
