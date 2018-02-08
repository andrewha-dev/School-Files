package shapes;

public class Cylinder extends Circle implements ThreeD
{
	double depth;
	public Cylinder(){
		super();
		setDepth(super.DEFAULT_SIZE);
	}
	
	public Cylinder(double theRadius, double theDepth){
		super(theRadius);
		setShapeName("Cylinder");
		
		if (theDepth <= 0.0)
		{
			setDepth(Shape.DEFAULT_SIZE);
		}
		else
		{
			setDepth(theDepth);
		}
		
	}
	public Cylinder(Circle theCircle, double theDepth)
	{
		setShapeName("Cylinder");

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
	

	@Override
	public double getSurfaceArea()
	{
		// TODO Auto-generated method stub
		return 2 * super.getSurfaceArea() + 2 * Math.PI * super.getRadius() * getDepth();
	}

	@Override
	public double getPerimeter()
	{
		return super.getPerimeter();
	}

	@Override
	public double getDepth()
	{
	// TODO Auto-generated method stub
		return depth;
	}

	@Override
	public void setDepth(double theDepth)
	{
		depth = theDepth;
		
	}

	@Override
	public double getVolume()
	{
		return super.getSurfaceArea() * getDepth();
	}
	
	public String toString()
  {
    return super.getShapeName() + ": depth = " + this.depth;
  } // toString()

	@Override
	public boolean equals(Object o)
	{
		// TODO Auto-generated method stub
		return super.equals(o) && ((Cylinder)o).getDepth() == this.getDepth();
	}
	
	
	

}
