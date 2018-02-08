package adts.binarytree;

/**
 * A <tt>BinaryTreeNode</tt> is a node in a binary tree.
 * Each node stores a single object and may have 0 to 2
 * children and 1 parent.
 */

public class LinkedBinaryTreeNode<E> implements BinaryTreeNode<E> {
  private E element;
  protected LinkedBinaryTreeNode<E> parent;
  protected LinkedBinaryTreeNode<E> leftChild;
  protected LinkedBinaryTreeNode<E> rightChild;

  /**
   * Creates an empty <tt>BinaryTreeNode</tt>.
   */
  public LinkedBinaryTreeNode() {
    this( null );
  }

  /**
   * Creates a <tt>BinaryTreeNode</tt> storing
   * <tt>theElement</tt>.
   * @param theElement the element to store in this node when
   *  it is created
   */
  public LinkedBinaryTreeNode( E theElement ) {
    this.parent = null;
    this.leftChild = null;
    this.rightChild = null;
    this.element = theElement;
  }

  // ******************* ACCESSOR METHODS
  /**
   * Return the parent of this node.
   * @return a reference to the parent node, null if this node
   * has no parent
   */
  public BinaryTreeNode<E> parent() {
    return this.parent;
  }

  /**
   * Return a reference to the left child of this node.
   * @return the left child of this node, null if there is
   * no left child
   */
  public BinaryTreeNode<E> leftChild() {
    return this.leftChild;
  }

  /**
   * Return a reference to the right child of this node.
   * @return the right child of this node, null if there is
   * no right child
   */
  public BinaryTreeNode<E> rightChild() {
    return this.rightChild;
  }

  /**
   * Return the element stored in this node.
   * @return the element stored in this node
   */
  public E element() {
    return this.element;
  }

  // *******************  MUTATOR METHODS
  /**
   * Replaces the element stored in this node with the
   * specified element.
   * @param theElement the new element to be stored by this node.
   */
  public void setElement( E theElement ) {
    this.element = theElement;
  }

  /**
   * Determine if this node is an internal node (has a child)
   * @return true if node is an internal node, false otherwise
   */
  public boolean isInternal() {
    return ( this.leftChild != null ) ||
        ( this.rightChild != null );
  }
}
