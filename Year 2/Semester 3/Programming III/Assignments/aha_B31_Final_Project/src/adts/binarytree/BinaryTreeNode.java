package adts.binarytree;

/**
 * The interface common to all Binary Tree Nodes.
 */
public interface BinaryTreeNode<E> {

  /**
   * Set this <tt>BinaryTreeNode</tt>'s element
   * to store the argument.
   * @param newElement the new element.
   */
  public void setElement( E newElement );

  /**
   * Return the element stored in this <tt>BinaryTreeNode</tt>.
   * @return the element stored in this node.
   */
  public E element();

  /**
   * Return the parent of this <tt>BinaryTreeNode</tt>.
   * @return the parent of this node, null if there is no parent.
   */
  public BinaryTreeNode<E> parent();

  /**
   * Return the left child of this <tt>BinaryTreeNode</tt>.
   * @return the left child of this node, null if there is
   * no left child.
   */
  public BinaryTreeNode<E> leftChild();

  /**
   * Return the right child of this <tt>BinaryTreeNode</tt>.
   * @return the right child of this node, null if there is
   * no right child.
   */
  public BinaryTreeNode<E> rightChild();

  /**
   * Determine if this node is an internal node (has a child).
   * By inverting the test, this method can be used to determine
   * if this node is an external node (leaf).
   * @return  true if node is an internal node, false otherwise
   */
  public boolean isInternal();
}
