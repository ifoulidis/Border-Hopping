using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BorderHopping
{
  class Rocket : Sprite
  {

    //##############################################################################################
    //# Instance Variables
    /// <summary>
    /// The image of the rocket. Our hero uses a sombrero rocket.
    /// </summary>
    static Bitmap BITMAP = Properties.Resources.Sombrero;
    /// <summary>
    /// The speed of the rocket.
    /// </summary>
    private const double _rocketSpeed = 40;

    //##############################################################################################
    //# Static method
    public static Rocket CreateRocket(Player player)
    {
      double x = player.CentreX + player.Width;
      double y = player.CentreY;
      return new Rocket(x, y);
    }
    //##############################################################################################
    //# Constructor
    private Rocket(double x, double y) : base(x, y, BITMAP.Width, BITMAP.Height)
    {
    }
    //##############################################################################################
    //# Abstract Methods
    public override void Move()
    {
        CentreX += _rocketSpeed;
    }
    public override void Draw(Graphics graphics)
    {
      graphics.DrawImage(BITMAP, LeftX, TopY);
    }
  }
}
