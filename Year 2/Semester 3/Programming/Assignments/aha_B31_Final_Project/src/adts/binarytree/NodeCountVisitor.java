package adts.binarytree;

/**
 * A Visitor class for counting the number of nodes in a tree.
 * This class implements the Visitor Design Pattern.
 */

public class NodeCountVisitor<E> implements Visitor<E> {
  private int count;

  /**
   * Initialize the counter to 0;
   */
  public NodeCountVisitor() {
    count = 0;
  }

  /**
   * Return the count of the number of nodes found.
   * @return the number of nodes found in the tree.
   */
  public int count() {
    return this.count;
  }

  /**
   * Visit the specified node.
   * All the method does is increment the counter if
   * <tt>node</tt> is not null.
   */
  public void visit( BinaryTreeNode<E> node ) {
    if ( node != null ) {
      count++;
    }
  }
}
