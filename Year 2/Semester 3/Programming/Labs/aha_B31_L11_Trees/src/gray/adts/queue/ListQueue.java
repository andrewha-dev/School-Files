package gray.adts.queue;

import java.util.LinkedList;
import java.util.List;
import java.lang.IllegalArgumentException;

/**
 *  Queue ADT implemented using the Adapter design pattern and
 *  java.util.LinkedList as the storage data structure. This
 *  version of Queue assumes an upper bound on the number of
 *  elements that can be stored in the queue.
 */
public class ListQueue<E> implements Queue<E> {
  private List<E> queue;
  private int capacity;

  /**
   * Default constructor. Create an empty queue with the
   * default capacity.
   */
  public ListQueue() {
    this( DEFAULT_CAPACITY );
  }

  /**
   * Create a queue with a capacity of <tt>maxElements</tt>.
   * @param maxElements int must be greater than 0.
   * @throws IllegalArgumentException if <tt>maxElement</tt>
   * is less than or equal to 0.
   */
  public ListQueue( int maxElements ) {
    this.queue = new LinkedList<E> ();
    if ( maxElements <= 0 ) {
      throw new IllegalArgumentException();
    }
    this.capacity = maxElements;
  }

  /**
   * Return the upper bound on the number of elements this
   * Queue can store.
   * @return the capacity of this queue.
   */
  public int capacity() {
    return this.capacity;
  }

  /**
   *  Empty the queue of all elements.
   */
  public void clear() {
    this.queue.clear();
  }

  /**
   * Remove and return the element at the front of the queue.
   * @return this queue's front element
   * @throws EmptyQueueException if the queue is empty
   */
  public E dequeue() {
    if ( this.queue.isEmpty() ) {
      throw new EmptyQueueException( "The queue is empty" );
    }
    return this.queue.remove( 0 );
  }

  /**
   * Add <tt>element</tt> to the end of the queue.
   * @throws FullQueueException if the queue is full
   */
  public void enqueue( E element ) {
    if ( this.isFull() ) {
      throw new FullQueueException( "The queue is full" );
    }
    this.queue.add( this.queue.size(), element );
  }

  /**
   * Return the element at the front of this queue. This
   * operation does not change the state of this queue.
   * @return the element at the front of this queue
   * @throws EmptyQueueException if the queue is empty
   */
  public E peek() {
    if ( this.queue.isEmpty() ) {
      throw new EmptyQueueException( "The queue is empty" );
    }
    return this.queue.get( 0 );
  }

  /**
   * Determine if this queue has any elements.
   * @return <tt>true</tt> if this queue has  no elements
   *     (<tt>size() == 0</tt>); <tt>false</tt> otherwise.
   */
  public boolean isEmpty() {
    return this.queue.isEmpty();
  }

  /**
   * Determine if this queue has room for more elements.
   * @return <tt>true</tt> if this queue has room for more elements
   * (<tt>size() == capacity()</tt>); <tt>false</tt> otherwise.
   */
  public boolean isFull() {
    return this.queue.size() == this.capacity;
  }

  /**
   * Determine the number of elements stored in this queue.
   * @return the number of elements in this queue
   */
  public int size() {
    return this.queue.size();
  }
}
