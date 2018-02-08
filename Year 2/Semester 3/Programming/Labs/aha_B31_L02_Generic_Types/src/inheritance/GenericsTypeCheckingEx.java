package inheritance;
import shapes.Rectangle;

public class GenericsTypeCheckingEx
{
  public static void main(String[] args)
  {
       Pair<String> sPair = new Pair<String>(new String("brother"),"sister");
       Pair<Animal> animalPair = new Pair<Animal>(new Dog('M', "Rover"), new Cat('F',"Meowth"));
     
       
       Pair<Rectangle> twoRectangles = new Pair<Rectangle>(new Rectangle(5,5), new Rectangle(1,1));
    
        sPair.swapElements();
        System.out.println("String elements are " + sPair.getFirstElement()
                            + ", " + sPair.getSecondElement());
    
        animalPair.setFirstElement(new Dog('M', "Rover"));
        System.out.println("Animal elements are " + animalPair.toString());
        Object o = animalPair.getSecondElement();
        System.out.println(" o is "+ o.toString());
        
        System.out.println(twoRectangles.toString());
  } // main()
  
} // GenericsTypeCheckingEx class
