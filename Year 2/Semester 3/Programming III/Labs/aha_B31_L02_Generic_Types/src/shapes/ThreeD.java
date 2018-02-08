package shapes;

public interface ThreeD
{
  /**
   * Get the depth of this <tt>ThreeD</tt> object.
   * @return the depth of this <tt>ThreeD</tt> object
   */
  double getDepth();

  /**
   * Set the depth of this <tt>ThreeD</tt> object.
   * If the argument <tt>theDepth</tt> is <= 0.0, it is ignored and the
   * <tt>ThreeD</tt> object is unchanged.
   * @param theDepth the new depth of this <tt>ThreeD</tt> object; must be > 0.0
   */
  void setDepth(double theDepth);

  /**
   * Get the volume of this <tt>ThreeD</tt> object.
   * @return the volume of this <tt>ThreeD</tt> object
   */
  double getVolume();
} // ThreeD Interface
