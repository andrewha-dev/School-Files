package shapes;

public class TestCylinder
{
  public static void main(String[] args)
  {
    Cylinder cylinder1 = new Cylinder();
    Cylinder cylinder2 = new Cylinder(5.5, 25.0);
    Circle circle = new Circle(5.5);
    Cylinder cylinder3 = new Cylinder(circle, 25.0);

    System.out.println("cylinder1: ");
    System.out.println("\tDimensions: " + cylinder1.toString());
    System.out.println("\tPerimeter: " + cylinder1.getPerimeter());
    System.out.println("\tSurface Area: " + cylinder1.getSurfaceArea());
    System.out.println("\tVolume: " + cylinder1.getVolume());

    System.out.println("cylinder2: ");
    System.out.println("\tDimensions: " + cylinder2.toString());
    System.out.println("\tPerimeter: " + cylinder2.getPerimeter());
    System.out.println("\tSurface Area: " + cylinder2.getSurfaceArea());
    System.out.println("\tVolume: " + cylinder2.getVolume());

    System.out.println("cylinder3: ");
    System.out.println("\tDimensions: " + cylinder3.toString());
    System.out.println("\tPerimeter: " + cylinder3.getPerimeter());
    System.out.println("\tSurface Area: " + cylinder3.getSurfaceArea());
    System.out.println("\tVolume: " + cylinder3.getVolume());

    System.out.println();
    if (cylinder1.equals(cylinder2))
      System.out.println("cylinder1 equals cylinder2");
    else
      System.out.println("cylinder1 is not equal cylinder2");
    if (cylinder2.equals(cylinder3))
      System.out.println("cylinder2 equals cylinder3");
    else
      System.out.println("cylinder2 is not equal cylinder3");

  }
}
