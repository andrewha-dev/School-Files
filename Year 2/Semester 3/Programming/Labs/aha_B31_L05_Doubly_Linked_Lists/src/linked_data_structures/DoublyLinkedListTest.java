package linked_data_structures;
import junit.framework.TestCase;

public class DoublyLinkedListTest
  extends TestCase
{
  public DoublyLinkedListTest(String sTestName)
  {
    super(sTestName);
  }

  public void testCase1()
  {
    DoublyLinkedList<String> list = new DoublyLinkedList();
    list.add("item 0");
    list.add("item 1");
    list.add("item 2");
    list.add("item 3");
    assertEquals("Test case 1", 1, list.countOccurrences("item 2"));
    assertEquals("Test case 1 delete", "item 2",
                 list.deleteLastOccurrence("item 2"));
    assertEquals("Test case 1 after deleteLast", 0,
                 list.countOccurrences("item 2"));
    assertEquals("Test case 1 - list length", 3, list.getLength());
    assertEquals("Test case 1 - List element 0 ", "item 3",
                 list.getElementAt(0));
    assertEquals("Test case 1 - List element 1 ", "item 1",
                 list.getElementAt(1));
    assertEquals("Test case 1 - List element 2 ", "item 0",
                 list.getElementAt(2));
  }

  public void testCase2()
  {
    DoublyLinkedList<String> list = new DoublyLinkedList();
    list.add("item 0");
    list.add("item 1");
    list.add("item 2");
    list.add("item 3");
    list.add("item 2");
    assertEquals("Test case 2", 2, list.countOccurrences("item 2"));
    assertEquals("Test case 2 delete", "item 2",
                 list.deleteLastOccurrence("item 2"));
    assertEquals("Test case 2 after deleteLast", 1,
                 list.countOccurrences("item 2"));
    assertEquals("Test case 2 - list length", 4, list.getLength());
    assertEquals("Test case 2 - List element 0 ", "item 2",
                 list.getElementAt(0));
    assertEquals("Test case 2 - List element 1 ", "item 3",
                 list.getElementAt(1));
    assertEquals("Test case 2 - List element 2 ", "item 1",
                 list.getElementAt(2));
    assertEquals("Test case 2 - List element 3 ", "item 0",
                 list.getElementAt(3));
  }

  public void testCase3()
  {
    DoublyLinkedList<String> list = new DoublyLinkedList();
    list.add("item 2");
    list.add("item 1");
    list.add("item 2");
    list.add("item 3");
    list.add("item 2");
    assertEquals("Test case 3", 3, list.countOccurrences("item 2"));
    assertEquals("Test case 3 delete", "item 2",
                 list.deleteLastOccurrence("item 2"));
    assertEquals("Test case 3 after deleteLast", 2,
                 list.countOccurrences("item 2"));
    assertEquals("Test case 3 - list length", 4, list.getLength());
    assertEquals("Test case 3 - List element 0 ", "item 2",
                 list.getElementAt(0));
    assertEquals("Test case 3 - List element 1 ", "item 3",
                 list.getElementAt(1));
    assertEquals("Test case 3 - List element 2 ", "item 2",
                 list.getElementAt(2));
    assertEquals("Test case 3 - List element 3 ", "item 1",
                 list.getElementAt(3));
  }

  public void testCase4()
  {
    DoublyLinkedList<String> list = new DoublyLinkedList();
    list.add("item 0");
    list.add("item 1");
    list.add("item 2");
    list.add("item 3");
    list.add("item 2");
    assertEquals("Test case 4", 0, list.countOccurrences("item 4"));
    assertNull("Test case 4 delete", 
                 list.deleteLastOccurrence("item 4"));
    assertEquals("Test case 4 after deleteLast", 0,
                 list.countOccurrences("item 4"));
    assertEquals("Test case 4 - list length", 5, list.getLength());
    assertEquals("Test case 4 - List element 0 ", "item 2",
                 list.getElementAt(0));
    assertEquals("Test case 4 - List element 1 ", "item 3",
                 list.getElementAt(1));
    assertEquals("Test case 4 - List element 2 ", "item 2",
                 list.getElementAt(2));
    assertEquals("Test case 4 - List element 3 ", "item 1",
                 list.getElementAt(3));
    assertEquals("Test case 4 - List element 4 ", "item 0",
                 list.getElementAt(4));
  }
}
