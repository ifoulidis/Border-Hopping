using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BorderHopping
{
  class Benefit : Sprite
  {
    //##############################################################################################
    //# Instance Variables

    static Bitmap BITMAP = Properties.Resources.Money;
    /// <summary>
    /// The speed that the benefit is approaching at.
    /// </summary>
    private const double _approachVelocity = 30;
    //##############################################################################################
    //# Static method
    public static Benefit CreateBenefit(Rectangle area)
    {
      double x = area.Right - 0.5 * BITMAP.Width;
      double y = area.Bottom - (0.5 * BITMAP.Height);
      return new Benefit(x, y);
    }
    //##############################################################################################
    //# Constructor
    private Benefit(double x, double y) : base(x, y, BITMAP.Width, BITMAP.Height)
    {
    }
    //##############################################################################################
    //# Abstract Methods
    public override void Move()
    {
      CentreX -= _approachVelocity;
    }
    public override void Draw(Graphics graphics)
    {
      graphics.DrawImage(BITMAP, LeftX, TopY);
    }
  }
}
