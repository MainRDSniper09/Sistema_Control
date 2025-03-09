using System.Drawing;
using System.Windows.Forms;

namespace SFPresentation.Utilidades
{
    public class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected || e.Item.Pressed)
            {
                Color hoverColor = Color.FromArgb(70, 65, 75);
                using (SolidBrush brush = new SolidBrush(hoverColor))
                {
                    e.Graphics.FillRectangle(brush, new Rectangle(Point.Empty, e.Item.Size));
                }
                e.Item.ForeColor = Color.White;
            }
            else
            {
                Color backgroundColor = Color.FromArgb(58, 49, 69);
                using (SolidBrush brush = new SolidBrush(backgroundColor))
                {
                    e.Graphics.FillRectangle(brush, new Rectangle(Point.Empty, e.Item.Size));
                }
                e.Item.ForeColor = Color.White;
            }
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(45, 40, 50)))
            {
                e.Graphics.FillRectangle(brush, e.AffectedBounds);
            }
        }
    }
}
