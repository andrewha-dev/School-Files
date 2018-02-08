package adts.queue;

import java.lang.IllegalArgumentException;

/**
 * Implement the Queue ADT as a circular queue using an array.
 */
public class ArrayQueue<E> implements Queue<E> {
  protected E[] queue;
  protected int capacity;
  protected int size;
  protected int front;
  protected int rear;

  public ArrayQueue() {
    this( DEFAULT_CAPACITY );
  }

  public ArrayQueue( int maxElements ) {
    if ( maxElements <= 0 ) {
      throw new IllegalArgumentException();
    }
    this.queue = ( E[] )new Object[maxElements];
    this.capacity = maxElements;
    this.size = 0;
    this.front = 0;
    this.rear = 0;
  }

  public int capacity() {
    return this.capacity;
  }

  public void clear() {
    // empty the queue, making all the array cells null
    while ( this.size != 0 ) {
      dequeue();
    }
    this.front = 0;
    this.rear = 0;
  }

  public E dequeue() {
    if ( this.isEmpty() ) {
      throw new EmptyQueueException( "The queue is empty" );
    }
    E element = this.queue[front];
    this.queue[this.front] = null;
    this.front = ( this.front + 1 ) % this.capacity;
    this.size--;
    return element;
  }

  public void enqueue( E element ) {
    if ( this.isFull() ) {
      throw new FullQueueException( "The queue is full" );
    }
    this.queue[this.rear] = element;
    this.rear = ( this.rear + 1 ) % this.capacity;
    this.size++;
  }

  public E peek() {
    if ( this.isEmpty() ) {
      throw new EmptyQueueException( "The queue is empty" );
    }
    return this.queue[this.front];
  }

  public boolean isEmpty() {
    return this.size == 0;
  }

  public boolean isFull() {
    return this.size == this.capacity;
  }

  public int size() {
    return this.size;
  }
}
