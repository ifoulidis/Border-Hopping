using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BorderHopping
{
  class Security : Sprite
  {
    //##############################################################################################
    //# Instance Variables

    static Bitmap BITMAP = Properties.Resources.BorderSecurity;
    /// <summary>
    /// The speed that the border security agent is approaching.
    /// </summary>
    private const double _captureVelocity = 25;
    private static Random _randomNumberGenerator = new Random();
    //##############################################################################################
    //# Static method
    public static Security CreateSecurity(Rectangle area)
    {
      double x = area.Right - 0.5 * BITMAP.Width;
      double y = area.Bottom - (0.5 * BITMAP.Height);
      return new Security(x, y);
    }
    //##############################################################################################
    //# Constructor
    private Security(double x, double y) : base(x, y, BITMAP.Width, BITMAP.Height)
    {
    }
    //##############################################################################################
    //# Abstract Methods
    public override void Move()
    {
      CentreX -= _captureVelocity;
    }
    public override void Draw(Graphics graphics)
    {
      graphics.DrawImage(BITMAP, LeftX, TopY);
    }
    //##############################################################################################
    //# Public Properties
    public bool IsNear(Security other)
    {
      double position1 = CentreX;
      double position2 = other.CentreX;
      if ((position2 - position1) < (BITMAP.Width * 4) && (position1 - position2) > 0)
      {
        return true;
      }
      else return false;
    }
  }
}
