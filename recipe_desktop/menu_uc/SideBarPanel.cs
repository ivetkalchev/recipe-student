using System.Drawing.Drawing2D;

namespace recipe_desktop
{
    public class SideBarPanel : Panel
    {
        public Color gradientTop {  get; set; }
        public Color gradientBottom { get; set; }
        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush linear = new LinearGradientBrush(this.ClientRectangle, this.gradientTop, this.gradientBottom, 90F);
            Graphics g = e.Graphics;
            g.FillRectangle(linear, this.ClientRectangle);
            base.OnPaint(e);
        }
    }
}
