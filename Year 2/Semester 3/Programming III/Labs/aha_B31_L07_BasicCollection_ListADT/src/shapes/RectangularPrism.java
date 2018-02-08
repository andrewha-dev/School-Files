package shapes;

/**
 * A <tt>RectangularPrism</tt> has three dimensions: length,
 * height and depth.
 */
public final class RectangularPrism
  extends Rectangle
  implements Cloneable, ThreeD
{

  private double depth;

  /**
   * Construct a <tt>RectangularPrism</tt> object using the
   * default size for its dimensions.
   */
  public RectangularPrism()
  {
    this(Shape.DEFAULT_SIZE, Shape.DEFAULT_SIZE, Shape.DEFAULT_SIZE);
  }

  /**
   * Construct a <tt>RectangularPrism</tt> object using the
   * arguments. If an argument is <= 0, the default size
   * specified in <tt>Shape</tt> is used instead.
   * @param theLength length of this <tt>RectangularPrism</tt>;
   *         must be > 0
   * @param theHeight height of this <tt>RectangularPrism</tt>;
   *         must be > 0
   * @param theDepth depth of this <tt>RectangularPrism</tt>;
   *        must be > 0
   */
  public RectangularPrism(double theLength, double theHeight,
                          double theDepth)
  {
    setShapeName("Rectangular Prism");
    if (theLength <= 0.0)
    {
      setLength(Shape.DEFAULT_SIZE);
    }
    else
    {
      setLength(theLength);
    }

    if (theHeight <= 0.0)
    {
      setHeight(Shape.DEFAULT_SIZE);
    }
    else
    {
      setHeight(theHeight);
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
   * Construct a <tt>RectangularPrism</tt> object using the
   * arguments. If an argument is <= 0, the default size
   * specified in <tt>Shape</tt> is used instead.
   * Solution to CheckPoint 1.11, Chapter 1.
   * @param theRect contains length and height; cannot be null
   * @param theDepth double the depth should be > 0.0
   * @throws NullPointerException if <tt>r</tt> is <tt>null</tt>
   */
  public RectangularPrism(Rectangle theRect, double theDepth)
  {
    if (theRect == null)
    {
      throw new NullPointerException();
    }

    setLength(theRect.getLength());
    setHeight(theRect.getHeight());
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
   * Get the surface area of this <tt>RectangularPrism</tt>.
   * Overridden method inherited from Rectangle.
   * @return the surface area of this <tt>RectangularPrism</tt>
   */
  public double getSurfaceArea()
  {
    return super.getSurfaceArea() * 2 + // front and back
      this.depth * getHeight() * 2 + // sides
      this.depth * getLength() * 2; // top and bottom
  }

  /**
   * Get the perimeter of this <tt>RectangularPrism</tt>.
   * Overridden method inherited from Rectangle.
   * @return the perimeter of this <tt>RectangularPrism</tt>
   */
  public double getPerimeter()
  {
    return 2 * super.getPerimeter() + 4 * this.depth;
  }

  /* methods unique to RectPrism */

  /**
   * Get the volume of this <tt>RectangularPrism</tt>.
   * @return the volume of this <tt>RectangularPrism</tt>
   */
  public double getVolume()
  {
    return this.depth * getLength() * getHeight();
  }

  /**
   * Get the depth of this <tt>RectangularPrism</tt>.
   * @return the depth of this <tt>RectangularPrism</tt>
   */
  public double getDepth()
  {
    return this.depth;
  }

  /**
   * Reset the depth of this <tt>RectangularPrism</tt>.
   * If <tt>theDepth</tt> is <= 0, the dimension is unchanged.
   * @param theDepth the new depth of this
   *        <tt>RectangularPrism</tt>; must be > 0
   */
  public void setDepth(double theDepth)
  {
    if (theDepth <= 0)
    {
      return;
    }
    this.depth = theDepth;
  }

  /**
   * Determine if this <tt>RectangularPrism</tt> is a cube.
   * @return boolean true if this <tt>RectangularPrism</tt> is a cube.
   */
  public boolean isACube()
  {
    return this.depth == this.getHeight() &&
      this.depth == this.getLength();
  }

  /**
   * Returns a <tt>String</tt> object representing this
   * <tt>RectangularPrism</tt>'s value. Overridden from
   * <tt>Object</tt>.
   * @return a string representation of this object
   */
  public String toString()
  {
    return super.toString() + ", depth = " + getDepth();
  }

  /**
   * Returns <tt>true</tt> if and only if the argument is not
   * <tt>null</tt> and is a <tt>RectangularPrism</tt> object that
   * represents the same rectangular prism value as this object.
   * The comparison is done based on the dimensions length,
   * height and depth.
   * @param o the object to compare with
   * @return <tt>true</tt> if the <tt>RectangularPrism</tt>
   * objects represent the same value; <tt>false</tt> otherwise.
   */
  public boolean equals(Object o)
  {
    if ((o == null) || (!(o instanceof RectangularPrism)))
    {
      return false;
    }
    return super.equals(o) &&
      ((RectangularPrism) o).getDepth() == this.getDepth();
  }

  /**
   * Make a clone of this <tt>RectangularPrism</tt>. Overridden
   * from <tt>Object</tt>.
   * @return Object a copy of this <tt>RectangularPrism</tt>.
   */
  public Object clone()
  {
    return super.clone();
  }
}
