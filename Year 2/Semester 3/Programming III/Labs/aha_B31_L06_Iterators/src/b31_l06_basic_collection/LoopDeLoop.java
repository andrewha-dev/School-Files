package b31_l06_basic_collection;


import inheritance.*;

import java.util.Collection;

import collection.BasicCollection;

public class LoopDeLoop
{
  public static void main(String[] args)
  {
  // An array of 5 Animals
    Animal[] menagerie = new Animal[5];
    menagerie[0] = new Dog('M', "Jasper");
    menagerie[1] = new Cat('F', "Tess");
    menagerie[2] = new Dog('F', "Kori");
    menagerie[3] = new Lion('M');
    menagerie[4] = new Cat('M', "Tripod");
    for (int i = 0; i < menagerie.length; ++i)
      System.out.println(menagerie[i].toString());
    
  // Display the menagerie using a for-each loop
    for (Animal d: menagerie)
    	System.out.println(d);
  
  // Create a BasicCollection of 5 Animal objects
    Collection <Animal> c = new BasicCollection<Animal>();
    c.add(new Dog('M', "Swaggie"));
    c.add(new Cat('M', "Sylvestor"));
    c.add(new Dog('M', "CoriEEEEE"));
    c.add(new Lion('M'));
    c.add(new Cat('M', "TriPod"));


  
  // Display the collection using a for-each loop
    for (Animal d: c)
    	System.out.println(d);
  
  } // main()
} // LoopDeLoop class
