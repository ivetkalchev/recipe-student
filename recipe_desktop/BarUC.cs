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
    public partial class BarUC : UserControl
    {
        public BarUC()
        {
            InitializeComponent();
        }
        private void lblClose_Click(object sender, EventArgs e)
        {
            Form form = this.FindForm();

            if (form != null)
            {
                form.Close();
            }
        }
        private void lblClose_MouseHover(object sender, EventArgs e)
        {
            lblClose.ForeColor = Color.FromArgb(210, 210, 210);
        }
        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.ForeColor = Color.FromArgb(255, 255, 255);
        }
    }
}
