using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

public class MyRenderer : ToolStripProfessionalRenderer
{

    public MyRenderer()
        : base(new MyColorTable())
    {

    }
    protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        var r = new Rectangle(e.ArrowRectangle.Location, e.ArrowRectangle.Size);
        r.Inflate(-2, -6);
        e.Graphics.DrawLines(Pens.Gray, new Point[]{
        new Point(r.Left, r.Top),
        new Point(r.Right, r.Top + r.Height /2),
        new Point(r.Left, r.Top+ r.Height)});
    }

    protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
    {
        Color _colorCheckMark = Color.FromArgb(3, 117, 193);

        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        var rectImage = new Rectangle(e.ImageRectangle.Location, e.ImageRectangle.Size);
        rectImage.Inflate(-1, -1);

        using (var p = new Pen(_colorCheckMark, 1))
        {
            g.DrawRectangle(p, rectImage);
        }

        var rectCheck = rectImage;
        rectCheck.Width = rectImage.Width - 6;
        rectCheck.Height = rectImage.Height - 8;
        rectCheck.X += 3;
        rectCheck.Y += 4;

        using (var p = new Pen(_colorCheckMark, 2))
        {
            g.DrawLines(p, new[] { new Point(rectCheck.Left, rectCheck.Bottom - (int)(rectCheck.Height / 2)), new Point(rectCheck.Left + (int)(rectCheck.Width / 3), rectCheck.Bottom), new Point(rectCheck.Right, rectCheck.Top) });
        }
    }
}