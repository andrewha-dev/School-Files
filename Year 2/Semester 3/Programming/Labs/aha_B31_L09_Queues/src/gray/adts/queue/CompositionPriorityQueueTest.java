package gray.adts.queue;

import junit.framework.TestCase;

public class CompositionPriorityQueueTest
  extends TestCase
{
  public CompositionPriorityQueueTest(String sTestName)
  {
    super(sTestName);
  }

  /**
   * @see Palindrome#isPalindrome(String)
   */
  
  public void testIsPalindrome()
  {
    PriorityQueue<String>pq = new CompositionPriorityQueue<String>();
    pq.enqueue("A");
    assertTrue(pq.peek().equals("A"));
    
    pq.enqueue(1, "B");
    assertTrue(pq.peek().equals("B"));
    
    pq.enqueue("C");
    assertTrue(pq.peek().equals("B"));
    
    pq.enqueue(2, "D");
    assertTrue(pq.peek().equals("B"));
    
    assertTrue(pq.size() == 4);
    
    pq.enqueue(1, "E");
    assertTrue(pq.peek().equals("E"));
    
    assertTrue(pq.size() == 5);
    
    assertTrue(pq.dequeue().equals("E"));
    
    assertTrue(pq.size() == 4);
    
    assertTrue(pq.dequeue().equals("B"));
    
    assertTrue(pq.dequeue().equals("D"));
    assertTrue(pq.dequeue().equals("A"));
    
    assertTrue(pq.isEmpty() == false);
    
    assertTrue(pq.dequeue().equals("C"));
    
    assertTrue(pq.isEmpty() == true);
    
  }

}
