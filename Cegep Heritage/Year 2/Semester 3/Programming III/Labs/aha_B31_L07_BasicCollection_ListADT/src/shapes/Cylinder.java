package shapes;

public class Cylinder
  extends shapes.Circle
  implements shapes.ThreeD
{
  private double depth;

  /**
   * Construct a <tt>Cylinder</tt> object using the
   * default size for its dimensions.
   */
  public Cylinder()
  {
    this(Shape.DEFAULT_SIZE, Shape.DEFAULT_SIZE);
  }

  /**
   * Construct a <tt>Cylinder</tt> object using the
   * arguments. If an argument is <= 0, the default size
   * specified in <tt>Shape</tt> is used instead.
   * @param theRadius radius of this <tt>Cylinder</tt>;
   *         must be > 0
   * @param theDepth depth of this <tt>Cylinder</tt>;
   *        must be > 0
   */
  public Cylinder(double theRadius, double theDepth)
  {
    setShapeName("Rectangular Prism");
    if (theRadius <= 0.0)
    {
      setRadius(Shape.DEFAULT_SIZE);
    }
    else
    {
      setRadius(theRadius);
    }

    if (theDepth <= 0.0)
    {
      setDepth(Shape.DEFAULT_SIZE);
    }
    else
    {
      setDepth(theDepth);
    }
  }

  /**
   * Construct a <tt>Cylinder</tt> object using the
   * arguments. If an argument is <= 0, the default size
   * specified in <tt>Shape</tt> is used instead.
   * @param theCircle contains length and height; cannot be null
   * @param theDepth double the depth should be > 0.0
   * @throws NullPointerException if <tt>r</tt> is <tt>null</tt>
   */
  public Cylinder(Circle theCircle, double theDepth)
  {
    if (theCircle == null)
    {
      throw new NullPointerException();
    }

    setRadius(theCircle.getRadius());
    if (theDepth <= 0.0)
    {
      setDepth(Shape.DEFAULT_SIZE);
    }
    else
    {
      setDepth(theDepth);
    }
  }

  public String toString()
  {
    return super.toString() + " depth = " + getDepth();
  }

  public boolean equals(Object o)
  {
    return (super.equals(o) &&
            ((Cylinder) o).getDepth() == this.getDepth());
  }

  public double getDepth()
  {
    return depth;
  }

  public void setDepth(double theDepth)
  {
    depth = theDepth;
  }

  /**
   * Get the surface area of this <tt>Cylinder</tt>.
   * Overridden from <tt>Circle</tt>.
   * @return the surface area of this <tt>Cylinder</tt>
   */
  public double getSurfaceArea()
  {
    return 2 * super.getSurfaceArea() +
      2 * Math.PI * getRadius() * getDepth();
  }

  /**
   * Get the perimeter of this <tt>Cylinder</tt>.
   * Overridden from <tt>Circle</tt>.
   * @return the perimeter of this <tt>Cylinder</tt>
   */
  public double getPerimeter()
  {
    return 2 * super.getPerimeter() + 4 * getDepth();
  }

  public double getVolume()
  {
    return super.getSurfaceArea() * depth;
  }

}
