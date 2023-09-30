using System.Drawing;
using System.Windows.Forms;

public class MyColorTable : ProfessionalColorTable
{
    public override Color MenuItemBorder
    {
        get { return Color.FromArgb(20, 20, 20); }
    }
    public override Color MenuItemSelected
    {
        get { return Color.FromArgb(76, 76, 76); }
    }
    public override Color ToolStripDropDownBackground
    {
        get { return Color.FromArgb(20, 20, 20); }
    }
    public override Color ImageMarginGradientBegin
    {
        get { return Color.FromArgb(20, 20, 20); }
    }
    public override Color ImageMarginGradientMiddle
    {
        get { return Color.FromArgb(20, 20, 20); }
    }
    public override Color ImageMarginGradientEnd
    {
        get { return Color.FromArgb(20, 20, 20); }
    }


    public override Color MenuItemPressedGradientBegin
    {
        get { return Color.FromArgb(76, 76, 76); }
    }
    public override Color MenuItemPressedGradientMiddle
    {
        get { return Color.FromArgb(76, 76, 76); }
    }
    public override Color MenuItemPressedGradientEnd
    {
        get { return Color.FromArgb(76, 76, 76); }
    }
    public override Color MenuBorder
    {
        get { return Color.FromArgb(20, 20, 20); }
    }
    public override Color SeparatorDark
    {
        get { return Color.FromArgb(76, 76, 76); }
    }
}