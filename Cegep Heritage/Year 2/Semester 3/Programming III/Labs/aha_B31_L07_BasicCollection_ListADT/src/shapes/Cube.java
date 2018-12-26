package shapes;

public class Cube
  extends Rectangle
{
  private double depth;

  public Cube()
  {
    super();
    setDepth(super.DEFAULT_SIZE);
  }

  public Cube(double side)
  {
    super(side, side);
    setDepth(side);
  }

  /**
   * Get the depth dimension of this <tt>Cube</tt>.
   * @param depth the depth of this <tt>Cube</tt>
   */
  public void setDepth(double depth)
  {
    this.depth = depth;
  }

  /**
   * Get the depth dimension of this <tt>Cube</tt>.
   * @return the depth of this <tt>Cube</tt>.
   */
  public double getDepth()
  {
    return depth;
  }

  /**
   * Get the surface area of this <tt>Cube</tt>.
   * @return the surface area of this <tt>Cube</tt>
   */
  public double getSurfaceArea()
  {
    return super.getSurfaceArea() * 6;
  }

  /**
   * Get the perimeter of this <tt>Cube</tt>.
   * @return the perimeter of this <tt>Cube</tt>
   */
  public double getPerimeter()
  {
    return super.getPerimeter() * 3;
  }

}
