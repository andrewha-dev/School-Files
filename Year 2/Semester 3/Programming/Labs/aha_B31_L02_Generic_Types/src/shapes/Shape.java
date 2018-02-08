package shapes;

public abstract class Shape
{
  /**
   * The default size used in constructing a shape.
   */
  protected static final double DEFAULT_SIZE = (double) 1.0;
  protected static final String DEFAULT_NAME = "Unknown";
  private String shapeName;

  /**
   * Construct a generic instance of unknown shape type.
   */
  public Shape()
  {
    this.shapeName = DEFAULT_NAME;
  } // Shape()

  /**
   * Construct a <tt>Shape</tt> whose type is specified in
   * the argument.
   * @param name the name of this kind of shape
   */
  public Shape(String name)
  {
    setShapeName(name);
  } // Shape(String name)

  /**
   * Reset the shape name for this <tt>Shape</tt>.
   * @param name the name of this kind of shape
   */
  protected void setShapeName(String name)
  {
    if (name.trim().length() == 0)
    {
      shapeName = DEFAULT_NAME;
    }
    else
    {
      shapeName = new String(name);
    }
  } // setShapeName(String name)

  /**
   * Get the name of this kind of shape.
   * @return the name of this shape
   */
  public String getShapeName()
  {
    return shapeName;
  } // getShapeName()

  /**
   * Get the surface area of this <tt>Shape</tt>.
   * @return the surface area of this <tt>Shape</tt>
   */
  public abstract double getSurfaceArea();

  /**
   * Get the perimeter of this <tt>Shape</tt>.
   * @return the perimeter of this <tt>Shape</tt>
   */
  public abstract double getPerimeter();
} // Shape class
