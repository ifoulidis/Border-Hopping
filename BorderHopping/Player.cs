using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderHopping
{
  class Player : Sprite
  {
    //##############################################################################################
    //# Instance Variables
    static Bitmap BITMAP = Properties.Resources.Mexican;
    /// <summary>
    /// The speed of the player's jump. This will increase as time goes on.
    /// </summary>
    private int _jumpSpeed;
    private int _jumpTimer;
    private int _fallTimer;
    private bool _jumping;
    private bool _falling;
    //##############################################################################################
    //# Static Methods
    public static Player CreatePlayer(Rectangle area)
    {
      double x = area.Left + 0.5 * area.Width;
      double y = area.Bottom - (0.5 * BITMAP.Height);
      return new Player(x, y);
    }
    //##############################################################################################
    //# Constructor
    private Player(double x, double y) : base(x, y, BITMAP.Width, BITMAP.Height)
    {
      _jumpSpeed = 0;
      _jumpTimer = 8;
      _fallTimer = 8;
    }
    //##############################################################################################
    //# Abstract Methods
    public override void Move()
    {
      if (Jumping == true)
      {
        CentreY += _jumpSpeed;
      }
      else if (Falling == true)
      {
        CentreY -= _jumpSpeed;
      }
    }
    public override void Draw(Graphics graphics)
    {
      graphics.DrawImage(BITMAP, LeftX, TopY);
    }
    //##############################################################################################
    //# Public Properties
    /// <summary>
    /// Checks whether the player is travelling upwards in the jump path or not.
    /// </summary>
    public bool Jumping
    {
      get { return _jumping; }
      set { _jumping = value; }
    }
    public bool Falling
    {
      get { return _falling; }
      set { _falling = value; }
    }
    public int JumpSpeed
    {
      get { return _jumpSpeed; }
      set { _jumpSpeed = value; }
    }
    public int JumpTimer
    {
      get { return _jumpTimer; }
      set { _jumpTimer = value; }
    }
    public int FallTimer
    {
      get { return _fallTimer; }
      set { _fallTimer = value; }
    }
  }
}
