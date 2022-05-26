using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BorderHopping
{
  abstract class Sprite
  {
    //##############################################################################################
    //# Instance variables
    /// <summary>
    /// The current x coordinate of the center of the sprite.
    /// </summary>
    private double _x;
    /// <summary>
    /// The current y coordinate of the center of the sprite.
    /// </summary>
    private double _y;
    /// <summary>
    /// The width of the sprite in pixels.
    /// </summary>
    private double _width;
    /// <summary>
    /// The height of the sprite in pixels.
    /// </summary>
    private double _height;

    //##############################################################################################
    //# Constructor
    public Sprite(double x, double y, int width, int height)
    {
      _x = x;
      _y = y;
      _width = width;
      _height = height;
    }
    //##############################################################################################
    //# Abstract Methods

    public abstract void Move();
    public abstract void Draw(Graphics graphics);
    /// <summary>
    /// Checks whether this sprite has a collision with another sprite.
    /// This method compares the rectangular regions of two sprites to
    /// check for an overlap.
    /// </summary>
    /// <param name="other">The other sprite to check for collision with.</param>
    /// <returns>true if the two sprites overlap, false otherwise.</returns>
    public bool CollidedWith(Sprite other)
    {
      Rectangle bbox1 = Bounds;
      Rectangle bbox2 = other.Bounds;
      return bbox1.IntersectsWith(bbox2);
    }
    //##############################################################################################
    //# Properties
    // <summary>
    // The x coordinate of the sprite's centre.
    // <summary>
    public double CentreX
    {
      get { return _x; }
      set { _x = value; }
    }
    // <summary>
    // The y coordinate of the sprite's centre.
    // <summary>
    public double CentreY
    {
      get { return _y; }
      set { _y = value; }
    }
    // <summary>
    // The width of the sprite in pixels.
    // <summary>
    public double Width
    {
      get { return _width; }
    }
    // <summary>
    // The height of the sprite in pixels.
    // <summary>
    public double Height
    {
      get { return _height; }
    }
    // <summary>
    // The x coordinate of the left edge - rounded to nearest integer.
    // <summary>
    public int LeftX
    {
      get { return (int)Math.Round(_x - 0.5 * _width); }
      set { _x = value + 0.5 * _width; }
    }
    // <summary>
    // The x coordinate of the right edge - rounded to nearest integer.
    // <summary>
    public int RightX
    {
      get { return (int)Math.Round(_x + 0.5 * _width); }
      set { _x = value - 0.5 * _width; }
    }
    // <summary>
    // The y coordinate of the top edge - rounded to nearest integer.
    // <summary>
    public int TopY
    {
      get { return (int)Math.Round(_y - 0.5 * _height); }
      set { _y = value + 0.5 * _height; }
    }
    // <summary>
    // The y coordinate of the bottom edge - rounded to nearest integer.
    // <summary>
    public int BottomY
    {
      get { return (int)Math.Round(_y + 0.5 * _height); }
      set { _y = value - 0.5 * _height; }
    }
    // <summary>
    // The rectangular bounds of the sprite, both in space and size.
    // <summary>
    public Rectangle Bounds
    {
      get { return new Rectangle(LeftX, TopY, RightX - LeftX, BottomY - TopY); }
    }
  }
}
