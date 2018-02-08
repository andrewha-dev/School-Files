package b31_l06_basic_collection;

import java.util.Collection;

import java.util.Iterator;

import collection.BasicCollection;

import junit.framework.TestCase;

public class MyBasicListTest
  extends TestCase
{
  public MyBasicListTest(String sTestName)
  {
    super(sTestName);
  }

  /**
   * @see MyBasicList#countOccurrences(Collection)
   */
  public void testCase1()
  {
    Collection<String> coll = new BasicCollection<String>();
    coll.add("first thing");
    coll.add("second thing");
    coll.add("third thing");
    coll.add("fourth thing");
    coll.add("fifth thing");
    coll.add("sixth thing");
    coll.add("seventh thing");
    MyBasicList<String> testList = new MyBasicList<String>();
    Collection<Integer> counts =
      testList.countOccurrences(coll);
    Iterator iter = counts.iterator();
    while (iter.hasNext())
      assertEquals("No duplicates", new Integer(1),
                   (Integer) (iter.next()));
  }

  public void testCase2()
  {
    Collection<String> coll = new BasicCollection<String>();
    coll.add("first thing");
    coll.add("second thing");
    coll.add("third thing");
    coll.add("first thing");
    coll.add("fifth thing");
    coll.add("sixth thing");
    coll.add("seventh thing");
    MyBasicList<String> testList = new MyBasicList<String>();
    Collection<Integer> counts =
      testList.countOccurrences(coll);
    Iterator iter = counts.iterator();
    Iterator collIter = coll.iterator();
    while (iter.hasNext())
    {
      String str = (String) collIter.next();
      if (str.equals("first thing"))
        assertEquals("Duplicate ", new Integer(2),
                     (Integer) (iter.next()));
      else
        assertEquals("No duplicates", new Integer(1),
                     (Integer) (iter.next()));
    }
  } // TestCase2()


  public void testCase3()
  {
    Collection<String> coll = new BasicCollection<String>();
    coll.add("first thing");
    coll.add("first thing");
    coll.add("first thing");
    coll.add("first thing");
    coll.add("first thing");
    coll.add("first thing");
    coll.add("first thing");
    MyBasicList<String> testList = new MyBasicList<String>();
    Collection<Integer> counts =
      testList.countOccurrences(coll);
    Iterator iter = counts.iterator();

    while (iter.hasNext())
    {
      assertEquals("Duplicate ", new Integer(7), (Integer) (iter.next()));

    } // TestCase3()
  }
}// MyBasiListTest
