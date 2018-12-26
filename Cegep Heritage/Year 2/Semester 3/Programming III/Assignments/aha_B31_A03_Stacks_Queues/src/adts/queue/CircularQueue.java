package adts.queue;

import java.lang.IllegalArgumentException;

/**
 * CircularQueue
 * Implement the Queue as a circular queue using an array.
 */
public class CircularQueue<E> implements Queue<E> {
  protected E[] queue;
  protected int capacity;
  protected int size;
  protected int front;
  protected int rear;

  public CircularQueue() {
    this( Queue.DEFAULT_CAPACITY );
  }

  public CircularQueue( int maxElements ) {
    if ( maxElements <= 0 ) {
      throw new IllegalArgumentException( "constructor argument must be > 0" );
    }
    this.queue = ( E[] )new Object[maxElements];
    this.capacity = maxElements;
    this.clear();
  }

  public int capacity() {
    return this.capacity;
  }

  public void clear() {
    size = 0;
    front = 0;
    rear = 0;
  }

  public E dequeue() {
    if ( this.isEmpty() ) {
      throw new EmptyQueueException( "The queue is empty" );
    }
    E element = queue[front];
    front = ( front + 1 ) % capacity;
    size--;
    return element;
  }

  public void enqueue( E element ) {
    if ( this.isFull() ) {
      throw new FullQueueException( "The queue is full" );
    }
    queue[rear] = element;
    rear = ( rear + 1 ) % capacity;
    size++;
  }

  public E peek() {
    if ( this.isEmpty() ) {
      throw new EmptyQueueException( "The queue is empty" );
    }
    return queue[front];
  }

  public boolean isEmpty() {
    return size == 0;
  }

  public boolean isFull() {
    return size == capacity;
  }

  public int size() {
    return size;
  }
}
