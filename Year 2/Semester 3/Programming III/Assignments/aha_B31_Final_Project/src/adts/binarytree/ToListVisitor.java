package adts.binarytree;

import java.util.List;
import java.util.ArrayList;

/**
 * A Visitor class for converting a tree into a <tt>List</tt>.
 * The order in which the elements of the tree are placed in the
 * list is determined by the tree traversal used. This class
 * implements the Visitor Design Pattern.
 */
public class ToListVisitor<E> implements Visitor<E> {
  private List<E> list;

  /**
   * Create an empty list into which <tt>visit</tt> will
   * append the tree's elements.
   */
  public ToListVisitor() {
    list = new ArrayList<E> ();
  }

  /**
   * Return the list of elements.
   * @return A list of the elements from a tree.
   */
  public List<E> list() {
    return this.list;
  }

  /**
   * Appends the specified node to the end of the list.
   */
  public void visit( BinaryTreeNode<E> node ) {
    list.add( node.element() );
  }
}
