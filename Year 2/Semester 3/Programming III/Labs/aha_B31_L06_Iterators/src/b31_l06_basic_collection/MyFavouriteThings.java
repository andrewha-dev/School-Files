/**
 * 
 */
package b31_l06_basic_collection;

import java.util.Collection;
import java.util.Iterator;

import collection.BasicCollection;

/**
 * @author 1435792
 *
 */
public class MyFavouriteThings
{

	/**
	 * @param args
	 */
	public static void main(String[] args)
	{
		Collection <String> myFavouriteThings = new BasicCollection<String>();
		myFavouriteThings.add("Five Guys");
		myFavouriteThings.add("Mcdonalds");
		myFavouriteThings.add("Burger King");
		myFavouriteThings.add("A&W");
		myFavouriteThings.add("Subway");
		myFavouriteThings.add("Costco");
		myFavouriteThings.add("Manchu Wok");
		
		Iterator<String> iter = myFavouriteThings.iterator();
		
		while (iter.hasNext())
			System.out.println(iter.next());
		
	}

}
