package b31_l06_basic_collection;

import java.util.Collection;
import java.util.Iterator;

import collection.BasicCollection;

public class MyBasicList<E>
{
  public MyBasicList()
  {
    super();
  }

  /**
   * Count the number of occurrences of each item in a collection and return
   * a collection of the counts
   * @param c A collection of items - some of which may be duplicated
   * @return A collection of Integers. Each integer represents the number of occurrences
   * of each of the corresponding item in the c Collection.
   */
  public Collection<Integer> countOccurrences(Collection<E> c)
  {
    Collection<Integer> counts = new BasicCollection<Integer>();
    Iterator iter1 = c.iterator();
    while (iter1.hasNext())
    {
    	String string1 = (String) iter1.next();
    	int count = 0;
    	Iterator iter2 = c.iterator();
    	while (iter2.hasNext())
    	{
    		if (string1.equals(iter2.next()))
    			count++;
    	}
    	counts.add(count);
    }
    return counts;
  }
}
