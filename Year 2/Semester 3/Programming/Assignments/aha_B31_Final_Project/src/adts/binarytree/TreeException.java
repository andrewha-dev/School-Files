package adts.binarytree;

/**
 * The exception that is thrown whenever an operation on a tree is
 * in violation of a method precondition.
 */
public class TreeException extends RuntimeException {

  public TreeException() {
    super();
  }

  public TreeException( String errMsg ) {
    super( " " + errMsg );
  }
}
