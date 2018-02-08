package adts.binarytree;

/**
 * The interface for a binary tree. Nodes in a binary tree
 * may have 0, 1 or 2 children.  The children are distinguished
 * as the left child and the right child.
 */

public interface BinaryTree<E> {

  /**
   * Create a node to store <tt>element</tt> and make it
   * the root of the tree. The tree must be empty to be able
   * to create a new root for it.
   * @param element The element to add to the tree; cannot be
   *     <tt>null</tt>.
   * @return The root of this tree.
   * @throws TreeException If the tree is not empty.
   * @throws IllegalArgumentException If <tt>element</tt>
   *     is <tt>null</tt>.
   */
  public BinaryTreeNode makeRoot( E element );

  /**
   * Create a node in the tree to store <tt>element</tt> and
   * make it the left child of <tt>parent</tt>.
   * @param parent The parent of the node to be added;
   *    cannot be <tt>null</tt>.
   * @param element The element to be stored in the new node;
   *    cannot be <tt>null</tt>.
   * @return The new left child.
   * @throws TreeException If <tt>parent</tt> is <tt>null</tt>
   * or has a left child, or if <tt>element</tt>
   * is <tt>null</tt>.
   */
  public BinaryTreeNode<E> makeLeftChild(
      BinaryTreeNode<E> parent, E element );

  /**
   * Create a node in the tree to store <tt>element</tt>
   * make it the right child of <tt>parent</tt>.
   * @param parent The parent of the node to be added;
   *    cannot be <tt>null</tt>.
   * @param element The element to be stored in the new node;
   *    cannot be <tt>null</tt>.
   * @return The new right child.
   * @throws TreeException If <tt>parent</tt> is <tt>null</tt>
   * or has a right child, or if <tt>element</tt>
   * is <tt>null</tt>.
   */
  public BinaryTreeNode<E> makeRightChild(
      BinaryTreeNode<E> parent, E element );

  /**
   * Remove the specified node from the tree. The target's
   * position is replaced by a leaf descendant.
   * @param target The node to remove; cannot be <tt>null</tt>.
   * @throws TreeException If <tt>target</tt> is <tt>null</tt>.
   */
  public void remove( BinaryTreeNode<E> target );

  /**
   * Return the root of this tree.
   * @return The root of this tree or <tt>null</tt> if the tree
   * is empty.
   */
  public BinaryTreeNode<E> root();

  /**
   * Look for <tt>target</tt> in this tree. If it is found,
   * return the <tt>BinaryTreeNode</tt> that contains it,
   * else return <tt>null</tt>. Uses <tt>equals()</tt> to
   * compare the target against the object stored in this tree.
   * @param target The object we wish to find.
   * @return <tt>true</tt> if <tt>target</tt> if found in this
   *   tree, <tt>false</tt> otherwise.
   */
  public boolean contains( E target );

  /**
   * Perform a pre order traversal of this tree applying the
   * <tt>Visitor</tt> to each node.
   * @param visit The <tt>Visitor</tt> to apply during the
   * traversal.
   */
  public void preOrderTraversal( Visitor<E> visit );

  /**
   * Perform an in order traversal of this tree applying the
   * <tt>Visitor</tt> to each node.
   * @param visit The <tt>Visitor</tt> to apply during the
   * traversal.
   */
  public void inOrderTraversal( Visitor<E> visit );

  /**
   * Perform a post order traversal of this tree applying the
   * <tt>Visitor</tt> to each node.
   * @param visit The <tt>Visitor</tt> to apply during the
   * traversal.
   */
  public void postOrderTraversal( Visitor<E> visit );

  /**
   * Perform a level order traversal of this tree applying the
   * <tt>Visitor</tt> to each node.
   * @param visit The <tt>Visitor</tt> to apply during the
   * traversal.
   */
  public void levelOrderTraversal( Visitor<E> visit );

  /**
   * Return the number of nodes in this <tt>BinaryTree</tt>.
   * @return The number of nodes in this tree.
   */
  public int size();
}
