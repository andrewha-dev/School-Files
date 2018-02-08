package adts.queue;

import java.io.IOException;
import junit.framework.Test;
import junit.framework.TestCase;
import junit.framework.TestSuite;

/**
 * JUnit test cases for implementations of Queue.
 */

public class QueueTester extends TestCase {

  private Queue<String> queue;

  /**
   * Constructs a <code>QueueTester</code> with
   * the specified name.
   *
   * @param name Test case name.
   */
  public QueueTester( String name ) {
    super( name );
  }

  /**
   * Sets up the text fixture.
   * Called before every test case method.
   */
  protected void setUp() {
//        queue = new CircularQueue<String>(3);
    queue = new ListQueue<String> ( 3 );
  }

  /**
   * Tears down the text fixture.
   * Called after every test case method.
   */
  protected void tearDown() {
    queue = null;
  }

  public void testInstantiation() {
    assertEquals( 0, queue.size() );
    assertTrue( queue.isEmpty() );
  }

  public void testDequeueEmpty() {
    try {
      queue.dequeue();
    }
    catch ( EmptyQueueException ex ) {
      return;
    }
    fail( "Should have raised an EmptyQueueException here" );
  }

  public void testPeekEmpty() {
    try {
      queue.peek();
    }
    catch ( EmptyQueueException ex ) {
      return;
    }
    fail( "Should have raised an EmptyQueueException here" );
  }

  public void testEnqueueDequeueOne() {
    String aString = "www.nps.gov";
    queue.enqueue( aString );
    assertEquals( 1, queue.size() );
    assertTrue( !queue.isEmpty() );
    assertEquals( aString, queue.peek() );
    String poppedString = queue.dequeue();
    assertEquals( aString, poppedString );
    assertEquals( 0, queue.size() );
    assertTrue( queue.isEmpty() );
  }

  public void testWraparound() {
    String aString1 = "A";
    String aString2 = "B";
    String aString3 = "C";
    String aString4 = "D";

    assertEquals( "Capacity should be 3 for this test\n", 3, queue.capacity() );
    queue.enqueue( aString1 );
    queue.enqueue( aString2 );
    queue.enqueue( aString3 );
    assertTrue( queue.isFull() );
    assertEquals( 3, queue.size() );

    assertEquals( aString1, queue.dequeue() );
    queue.enqueue( aString4 ); // this should wraparound on capacity = 3
    assertTrue( queue.isFull() );
    assertEquals( queue.size(), 3 );
    assertEquals( aString2, queue.dequeue() );
    assertEquals( aString3, queue.dequeue() );
    assertEquals( aString4, queue.dequeue() );
    assertEquals( 0, queue.size() );
    assertTrue( queue.isEmpty() );
  }

  /**
   * Assembles and returns a test suite for
   * all the test methods of this test case.
   *
   * @return A non-null test suite.
   */
  public static Test suite() {
    TestSuite suite = new TestSuite( QueueTester.class );
    return suite;
  }

  public static void main( String args[] ) {
    String[] testCaseName = {
        QueueTester.class.getName()};
    
  }
}
