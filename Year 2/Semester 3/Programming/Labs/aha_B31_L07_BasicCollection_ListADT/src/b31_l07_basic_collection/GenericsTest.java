package b31_l07_basic_collection;

import collection.BasicCollection;

import inheritance.*;

import java.util.Collection;

import shapes.*;

public class GenericsTest
{
  public static void main(String[] argsp)
  {
    Collection<Object> whatever = new BasicCollection();
    whatever.add(new Dog('M', "Horse"));
    whatever.add(new Circle(25.3));
    whatever.add(new Integer(55));
    
    Collection<Animal> menagerie = new BasicCollection();
    menagerie.add(new Dog('M', "Jasper"));
    menagerie.add(new Cat('F', "Tess"));
    menagerie.add(new Dog('F', "Kori"));
    menagerie.add(new Lion('M'));
    menagerie.add(new Cat('M', "Tripod"));

    Collection<Dog> myDogs = new BasicCollection();
    myDogs.add(new Dog('F', "Sparkie"));
    myDogs.add(new Dog('F', "Spottie"));
    myDogs.add(new Dog('F', "Suki"));
    myDogs.add(new Dog('M', "Shaboo"));

    Collection<Shape> myShapes = new BasicCollection();
    myShapes.add(new Rectangle(10, 20));
    myShapes.add(new Circle(20.0));
    myShapes.add(new Cube(15.9));

    B31_L07_Generics generic = new B31_L07_Generics();

//    Use the Object superclass
//    System.out.println("\nwhatAreYou(Collection<Object> coll)");
//    System.out.println("Collection<Object> whatever");
//    generic.whatAreYou(whatever);
//    System.out.println("Collection<Animal> menagerie");
//    generic.whatAreYou(menagerie);
//    System.out.println("Collection<Dog> myDogs ");
//    generic.whatAreYou(myDogs);
//    System.out.println("Collection<Shape> myShapes");
//    generic.whatAreYou(myShapes);

//    Use an unbounded genericcard collection
//    System.out.println("\nshowMe(Collection<?> coll)");
//    System.out.println("Collection<Object> whatever");
//    generic.showMe(whatever);
//    System.out.println("Collection<Animal> menagerie");
//    generic.showMe(menagerie);
//    System.out.println("Collection<Dog> myDogs ");
//    generic.showMe(myDogs);
//    System.out.println("Collection<Shape> myShapes");
//    generic.showMe(myShapes);

//    Use a collection of Animals
//    System.out.println("\ntalkNow(Collection<Animal> coll)");
//    System.out.println("Collection<Object> whatever");
//    generic.talkNow(whatever);
//    System.out.println("Collection<Animal> menagerie");
//    generic.talkNow(menagerie);
//    System.out.println("Collection<Dog> myDogs ");
//    generic.talkNow(myDogs);
//    System.out.println("Collection<Shape> myShapes");
//    generic.talkNow(myShapes);

//    Use a bounded genericcard collection
//    System.out.println("\neverybodySpeak(Collection<? extends Animal> coll)");
//    System.out.println("Collection<Object> whatever");
//    generic.everybodySpeak(whatever);
//    System.out.println("Collection<Animal> menagerie");
//    generic.everybodySpeak(menagerie);
//    System.out.println("Collection<Dog> myDogs ");
//    generic.everybodySpeak(myDogs);
//    System.out.println("Collection<Shape> myShapes");
//    generic.everybodySpeak(myShapes);

//    Use a generic method
    System.out.println("\nwhoAreYou(Collection<E> coll)");
    System.out.println("Collection<Object> whatever");
    generic.whoAreYou(whatever);
    System.out.println("Collection<Animal> menagerie");
    generic.whoAreYou(menagerie);
    System.out.println("Collection<Dog> myDogs ");
    generic.whoAreYou(myDogs);
    System.out.println("Collection<Shape> myShapes");
    generic.whoAreYou(myShapes);
  }
}
