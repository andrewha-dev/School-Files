package b31_l03_exceptions;

public class ArrayTester
{
  public static void main(String[] args)
  {
    MiscFunctions fn = new MiscFunctions();
    String myCars[] = new String[5];
    myCars[0] = "Honda Civic";
    myCars[1] = "Skoda";
    myCars[2] = "TR 6";
    myCars[3] = "Toyota Tercel";
//    myCars[4] = "Volkswagen Beetle";
    System.out.println("Testing myCars");
    fn.checkSorted(myCars, 5);

    String myPets[] = new String[5];
    myPets[0] = "Jasper";
    myPets[1] = "Shaboo";
    myPets[2] = "Tess";
    myPets[3] = "Lucifer";
    System.out.println("Testing myPets");
    fn.checkSorted(myPets, 5);
  }
}
