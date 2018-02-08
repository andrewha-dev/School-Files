package shapes;

public class Circle
  extends Shape
{
  private double radius;

  /**
   * Construct a <tt>Circle</tt> object using the default size
   * for its radius.
   */
  public Circle()
  {
    super("Circle");
    setRadius(super.DEFAULT_SIZE);
  } // Circle()

  /**
   * Construct a <tt>Circle</tt> object using the argument
   * for the radius. If <tt>r</tt> is <= 0, the default size
   * specified in <tt>Shape</tt> is used for radius instead.
   * @param theRadius the radius of this <tt>Circle</tt>;
   *    must be > 0
   */
  public Circle(double theRadius)
  {
    super("Circle");
    if (theRadius <= 0.0)
    {
      setRadius(Shape.DEFAULT_SIZE);
    }
    else
    {
      setRadius(theRadius);
    }
  } // Circle(double theRadius)

  /**
   * Get the surface area of this <tt>Circle</tt>.
   * @return the surface area of this <tt>Circle</tt>
   */
  public double getSurfaceArea()
  {
    return this.radius * this.radius * Math.PI;
  } // getSurfaceArea()

  /**
   * Get the perimeter of this <tt>Circle</tt>.
   * @return the perimeter of this <tt>Circle</tt>
   */
  public double getPerimeter()
  {
    return 2 * this.radius + Math.PI;
  } // getPerimeter()

  /**
   * Get the radius of this <tt>Circle</tt>.
   * @return the radius of this <tt>Circle</tt>
   */
  public double getRadius()
  {
    return this.radius;
  } // getRadius()

  /**
   * Set the radius of this <tt>Circle</tt>.
   * If <tt>r</tt> is <= 0, the radius is unchanged.
   * @param theRadius the new radius of this <tt>Circle</tt>;
   *    must be > 0
   */
  public void setRadius(double theRadius)
  {
    if (theRadius <= 0)
    {
      return;
    }
    this.radius = theRadius;
  } // setRadius(double theRadius)

  /**
   * Returns a <tt>String</tt> object representing this
   * <tt>Circle</tt>'s value. Overridden from <tt>Object</tt>.
   * @return a string representation of this object
   */
  public String toString()
  {
    return getShapeName() + ": radius = " + this.radius;
  } // toString()

  /**
   * Returns <tt>true</tt> if and only if the argument is not
   * <tt>null</tt> and is a <tt>Circle</tt> object that
   * represents the same circle value as this object. The
   * comparison is done based on radius.
   * @param o the object to compare with
   * @return <tt>true</tt> if the <tt>Circle</tt> objects
   *   represent the same value; <tt>false</tt> otherwise.
   */
  public boolean equals(Object o)
  {
    if ((o == null) || (!(o instanceof Circle)))
    {
      return false;
    }
    return ((Circle) o).getRadius() == this.radius;
  } // equals(Object o)
} // Circle class
