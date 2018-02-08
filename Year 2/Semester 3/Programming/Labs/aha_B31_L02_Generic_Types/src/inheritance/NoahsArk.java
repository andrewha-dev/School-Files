package inheritance;

public class NoahsArk
{
  public static void main(String[] args)
  {
  	Pair<String> sexPair = new Pair<String>(("Female"), ("Male"));
  	Pair<Animal>[] animalPair = new Pair[10];
    int numPairs = 0;
    Animal firstAnimal[] = new Animal[10];
    Animal secondAnimal[] = new Animal[10];
   
    firstAnimal[0] = new Dog('F');
    secondAnimal[0] = new Dog('M', "Jasper");
    firstAnimal[1] = new Cat('M', "Tripod");
    secondAnimal[1] = new Cat('F', "Tess");
    firstAnimal[2] = new Lion('F');
    secondAnimal[2] = new Lion('M');
    
    while (firstAnimal[numPairs] != null)
    {
    	animalPair[numPairs] = new Pair<Animal>(firstAnimal[numPairs], secondAnimal[numPairs]);
    	numPairs++;
    }
    System.out.println("Number of pairs that the animals has: " + numPairs);
    
    int x = 0;
    while (animalPair[x] != null)
    {
    	System.out.println(animalPair[x].toString());
    	x++;
    }
    
    x= 0;
    while (animalPair[x] != null)
    {
    	if (animalPair[x].getFirstElement().getSex().equals(sexPair.getFirstElement()))
    	{
    		System.out.println("LOL");
    	}
    	else
    		animalPair[x].swapElements();
    	x++;
    }
    x = 0;
    System.out.println("");
    
    while (animalPair[x] != null)
    {
    	System.out.println(animalPair[x].toString());
    	x++;
    }
    
    x = 0;
    Lion lion3 = new Lion('M');
    while (animalPair[x] != null)
    {
    	animalPair[x].elementEqualTo(lion3);
    	x++;
    }
    System.out.println(x-1);
    
    x = 0;
    
    System.out.println("");
    while (animalPair[x] != null)
    {
    	System.out.println(animalPair[x].getFirstElement().speak());
    	System.out.println(animalPair[x].getSecondElement().speak());
    	x++;
    }
    
    
    
    
    
    
  } // main()
} // NoahsArk class
