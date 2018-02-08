package adts.binarytree;

/**
 * Implementation of the Visitor design pattern.
 */
public interface Visitor<E> {

  /**
   * Visit the specified node.
   * The implementation determines what, if anything, will
   * be done with the node.
   */
  public void visit( BinaryTreeNode<E> node );
}
