package adts.queue;

/**
 * Thrown when there is an attempt to add an element to the
 * a full queue.
 */
public class FullQueueException extends RuntimeException {

  public FullQueueException() {
    super();
  }

  public FullQueueException( String errMsg ) {
    super( " " + errMsg );
  }
}
