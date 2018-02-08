package shapes;

public class Rectangle
  extends Shape
{
  private double length;
  private double height;

  /**
   * Construct a <tt>Rectangle</tt> object using the default size
   * for its dimensions.
   */
  public Rectangle()
  {
    super("Rectangle");
    setLength(super.DEFAULT_SIZE);
    setHeight(Shape.DEFAULT_SIZE);
  } // Rectangle()

  /**
   * Construct a <tt>Rectangle</tt> object using the arguments.
   * If an argument is <= 0, the default size specified in
   * <tt>Shape</tt> is used instead.
   * @param theLength the length of this <tt>Rectangle</tt>;
   *        must be > 0
   * @param theHeight the height of this <tt>Rectangle</tt>;
   *        must be > 0
   */
  public Rectangle(double theLength, double theHeight)
  {
    super("Rectangle");
    if (theLength <= 0)
    {
      setLength(Shape.DEFAULT_SIZE);
    }
    else
    {
      setLength(theLength);
    }

    if (theHeight <= 0)
    {
      setHeight(Shape.DEFAULT_SIZE);
    }
    else
    {
      setHeight(theHeight);
    }
  } // Rectangle( double theLength, double theHeight )

  /**
   * Get the surface area of this <tt>Rectangle</tt>.
   * @return the surface area of this <tt>Rectangle</tt>
   */
  public double getSurfaceArea()
  {
    return this.length * this.height;
  } // getSurfaceArea()

  /**
   * Get the perimeter of this <tt>Rectangle</tt>.
   * @return the perimeter of this <tt>Rectangle</tt>
   */
  public double getPerimeter()
  {
    return 2 * this.length + 2 * this.height;
  } // getPerimeter()

  /**
   * Get the length dimension of this <tt>Rectangle</tt>.
   * @return the length of this <tt>Rectangle</tt>
   */
  public double getLength()
  {
    return this.length;
  } // getLength()

  /**
   * Get the height dimension of this <tt>Rectangle</tt>.
   * @return the height of this <tt>Rectangle</tt>
   */
  public double getHeight()
  {
    return this.height;
  } // getHeight()

  /**
   * Set the length dimension of this <tt>Rectangle</tt>.
   * If <tt>theLength</tt> is <= 0, the dimension is unchanged.
   * @param theLength new length of this <tt>Rectangle</tt>;
   *       must be > 0
   */
  public void setLength(double theLength)
  {
    if (theLength <= 0)
    {
      return;
    }
    this.length = theLength;
  } // setLength(double theLength)

   /**
   * Set the height dimension of this <tt>Rectangle</tt>.
   * If <tt>theHeight</tt> is <= 0, the dimension is unchanged.
   * @param theHeight the new height of this <tt>Rectangle</tt>;
   *   must be > 0
   */
  public void setHeight(double theHeight)
  {
    if (theHeight <= 0)
    {
      return;
    }
    this.height = theHeight;
  } // setHeight(double theHeight)

  /**
   * Returns a <tt>String</tt> object representing this
   * <tt>Rectangle</tt>'s value. Overridden from <tt>Object</tt>.
   * @return a string representation of this object
   */
  public String toString()
  {
    return this.getShapeName() + ": length = " + this.length +
      ", height = " + this.height;
  } // toString()

  /**
   * Returns <tt>true</tt> if and only if the argument is not
   * <tt>null</tt> and is a <tt>Rectangle</tt> object that
   * represents the same rectangle value as this object. The
   * comparison is done based on the dimension's length and
   * height.
   * @param o the object to compare with
   * @return <tt>true</tt> if the <tt>Rectangle</tt> objects
   * represent the same value; <tt>false</tt> otherwise.
   */
  public boolean equals(Object o)
  {
    if ((o == null) || (!(o instanceof Rectangle)))
    {
      return false;
    }
    return ((((Rectangle) o).getLength() == getLength()) &&
            (((Rectangle) o).getHeight() == getHeight()));
  } // equals(Object o)

  /**
   * Make a clone of this <tt>Rectangle</tt>. Overridden from <tt>Object</tt>.
   * @return Object a copy of this <tt>Rectangle</tt> if cloning is
   * supported; <tt>null</tt> otherwise.
   */
  public Object clone()
  {
    try
    {
      return super.clone();
    }
    catch (CloneNotSupportedException e)
    {
      return null;
    }
  } // Object clone()
} // Rectangle class
