package adts.binarytree;

import adts.queue.Queue;
import adts.queue.CircularQueue;

/**
 * A Linked Structure implementaton of the <tt>BinaryTree</tt>
 * interface.
 */
public class LinkedBinaryTree<E> implements BinaryTree<E> {
  private int size;
  private LinkedBinaryTreeNode<E> root;

  /**
   * Create an empty <tt>BinaryTree</tt>.
   */
  public LinkedBinaryTree() {
    this.root = null;
    this.size = 0;
  }

  /**
   * Create a <tt>BinaryTree</tt> with <tt>element</tt> stored
   * in its root. The tree must be empty to be able to make a
   * root for it.
   * @param element the element to store in the root of this tree
   * @throws TreeException if the tree is not empty
   */
  public LinkedBinaryTree( E element ) {
    if ( root != null ) {
      throw new TreeException( "Tree is not empty" );
    }
    root = new LinkedBinaryTreeNode<E> ( element );
    size = 1;
  }

  /**
   * Create a <tt>BinaryTree</tt> with <tt>node</tt> at
   * the root.
   * @throws TreeException if the tree is not empty
   */
  public LinkedBinaryTree( BinaryTreeNode<E> node ) {
    root = ( LinkedBinaryTreeNode<E> ) node;
    NodeCountVisitor<E> counter = new NodeCountVisitor<E> ();
    this.inOrderTraversal( counter );
    size = counter.count();
  }

  /**
   * Create a <tt>BinaryTree</tt> with <tt>element</tt> stored
   * in the root and <tt>leftTree</tt> and <tt>rightTree</tt>
   * as its left and right children.
   * @param leftTree the root of the new tree's left subtree
   * @param element the element to store in the root of the new tree
   * @param rightTree the root of the new tree's right subtree
   * @throws NullPointerException if the precondition is not met.
   */
  public LinkedBinaryTree( BinaryTree<E> leftTree, E element,
                           BinaryTree<E> rightTree ) {
    if ( element == null ) {
      throw new NullPointerException();
    }

    this.root = new LinkedBinaryTreeNode<E> ( element );
    this.size = 1;

    if ( leftTree != null ) {
      this.size += ( ( LinkedBinaryTree<E> ) leftTree ).size();
      this.root.leftChild = ( LinkedBinaryTreeNode<E> )
          ( ( LinkedBinaryTree<E> ) leftTree ).root();
      this.root.leftChild.parent = root;
    }
    else {
      root.leftChild = null;
    }

    if ( rightTree != null ) {
      this.size += ( ( LinkedBinaryTree<E> ) rightTree ).size();
      this.root.rightChild = ( LinkedBinaryTreeNode<E> )
          ( ( LinkedBinaryTree<E> ) rightTree ).root();
      this.root.rightChild.parent = root;
    }
    else {
      this.root.rightChild = null;
    }
  }

  // *******************  MUTATOR METHODS
  /**
   * Create a node to store <tt>element</tt> and make it the
   * root of the tree
   * @param element the element to store in the root of this tree
   * @return the root of this tree
   * @throws TreeException if the tree is not empty.
   */
  public BinaryTreeNode<E> makeRoot( E element ) {
    if ( root != null ) {
      throw new TreeException( "Tree is not empty" );
    }
    root = new LinkedBinaryTreeNode<E> ( element );
    size = 1;
    return root;
  }

  /**
   * Create a node in the tree to store <tt>element</tt> and
   * make it the left child of <tt>parent</tt>.
   * The parent must not be null and may not already have
   * a left child.
   * @param parent the parent of the node to be added
   * @param element the element to be stored in the new node
   * @return The new left child.
   * @throws TreeException if <tt>parent</tt> is null or has
   * a left child.
   */
  public BinaryTreeNode<E> makeLeftChild(
      BinaryTreeNode<E> parent, E element ) {
    if ( ( parent == null ) || (
        ( ( LinkedBinaryTreeNode<E> ) parent ).leftChild != null ) ) {
      throw new TreeException();
    }
    LinkedBinaryTreeNode<E> lchild =
        new LinkedBinaryTreeNode<E> ( element );
    ( ( LinkedBinaryTreeNode<E> ) parent ).leftChild = lchild;
    lchild.parent = ( LinkedBinaryTreeNode<E> ) parent;
    size++;
    return lchild;
  }

  /**
   * Create a node in the tree to store <tt>element</tt> and
   * make it the right child of <tt>parent</tt>. The parent must
   * not be null and may not already have a right child.
   * @param parent the parent of the node to be added
   * @param element the element to be stored in the new node
   * @return The new right child.
   * @throws TreeException if <tt>parent</tt> is null or has a
   * right child.
   */
  public BinaryTreeNode<E> makeRightChild(
      BinaryTreeNode<E> parent, E element ) {
    if ( ( parent == null ) ||
         ( ( LinkedBinaryTreeNode<E> ) parent ).rightChild != null ) {
      throw new TreeException();
    }
    LinkedBinaryTreeNode<E> rchild =
        new LinkedBinaryTreeNode<E> ( element );
    ( ( LinkedBinaryTreeNode<E> ) parent ).rightChild = rchild;
    rchild.parent = ( LinkedBinaryTreeNode<E> ) parent;
    size++;
    return rchild;
  }

  /**
   * Remove the specified node from the tree. In this
   * implementation, the node is replaced by a leaf descendant.
   * @param target the node to be removed from the tree
   */
  public void remove( BinaryTreeNode<E> target ) {
    if ( target == null ) { // if null, nothing to remove
      return;
    }

    LinkedBinaryTreeNode<E> node =
        ( LinkedBinaryTreeNode<E> ) target;
    // If this is an internal node, we need to get another
    // node (a leaf descendant) to put in its place.
    if ( node.isInternal() ) {
      LinkedBinaryTreeNode<E> leaf = getaLeafDescendant( node );
      node.setElement( leaf.element() );
    }
    else {
      detachFromParent( node );
    }
    size--;
  }

  /**
   * Get a descendant of node that is a leaf. Preference is for
   *  the rightmost child, but we'll go left if we have to.
   * @param node node for which we want a leaf descendant
   * @return the leaf
   */
  private LinkedBinaryTreeNode<E> getaLeafDescendant(
      LinkedBinaryTreeNode<E> node ) {
    // if there is a right child, go that direction
    if ( node.rightChild != null ) {
      return getaLeafDescendant( node.rightChild );
    }

    // if there is no right child, try going left
    else if ( node.leftChild != null ) {
      return getaLeafDescendant( node.leftChild );
    }

    // no right or left children, so this is the node we want.
    // Detach it from its parent and return it.
    else {
      detachFromParent( node );
      return node;
    }
  }

  /**
   * Detach this leaf node from the tree.
   * @param node to detach; must be a leaf (not checked)
   */
  private void detachFromParent( LinkedBinaryTreeNode<E> node ) {
    if ( node.parent == null ) { // if node is root of the tree
      return; // nothing to do
    }

    LinkedBinaryTreeNode<E> parent = node.parent;
    node.parent = null;
    if ( parent.leftChild == node ) {
      parent.leftChild = null;
    }
    else {
      parent.rightChild = null;
    }
  }

  // *******************  ACCESSOR METHODS
  /**
   * Return the root of this tree or null if it is empty.
   * @return the root of this tree or null if the tree is empty
   */
  public BinaryTreeNode<E> root() {
    return root;
  }

  /**
   * Look for <tt>target</tt> in this tree. If it is found,
   * return the <tt>BinaryTreeNode</tt> that contains it, else
   * return <tt>null</tt>. Uses <tt>equals()</tt> to compare the
   * target against object stored in this tree.
   * @param target the element we wish to find.
   * @return <tt>true</tt> if <tt>target</tt> if found in this
   *   tree, <tt>false</tt> otherwise.
   */
  public boolean contains( E target ) {
    if ( target == null ) {
      return false;
    }

    FindVisitor<E> findVisitor = new FindVisitor<E> ( target );
    this.doInOrderTraversal( this.root, findVisitor );
    return findVisitor.targetNode() != null;
  }

  /**
   * Return the number of nodes in this <tt>BinaryTree</tt>.
   * If this tree contains more than <tt>Integer.MAX_VALUE</tt>
   *  nodes, returns <tt>Integer.MAX_VALUE</tt>.
   * @return the number of nodes in this tree.
   */
  public int size() {
    return this.size;
  }

  // *******************  TRAVERSAL METHODS
  /**
   * Perform a pre order traversal of this tree applying the
   * Visitor to each node.
   * @param visitor the <tt>Visitor</tt> object to apply during
   *  the traversal
   */
  public void preOrderTraversal( Visitor<E> visitor ) {
    doPreOrderTraversal( this.root(), visitor );
  }

  /**
   * Perform an in order traversal of this tree applying the
   * Visitor to each node.
   * @param visitor the <tt>Visitor</tt> object to apply during
   *  the traversal
   */
  public void inOrderTraversal( Visitor<E> visitor ) {
    doInOrderTraversal( this.root(), visitor );
  }

  /**
   * Perform a post order traversal of this tree applying the
   * Visitor to each node.
   * @param visitor the <tt>Visitor</tt> object to apply during
   *  the traversal
   */
  public void postOrderTraversal( Visitor<E> visitor ) {
    doPostOrderTraversal( this.root(), visitor );
  }

  /**
   * Perform a level order traversal of this tree applying the
   * Visitor to each node.
   * @param visitor the <tt>Visitor</tt> object to apply during
   *  the traversal
   */
  public void levelOrderTraversal( Visitor<E> visitor ) {
    if ( this.root() == null ) {
      return;
    }

    BinaryTreeNode<E> nodeToVisit;
    BinaryTreeNode<E> child;
    Queue<BinaryTreeNode<E>> nodeQueue =
        new CircularQueue<BinaryTreeNode<E>> ();
    nodeQueue.enqueue( this.root() );
    while ( !nodeQueue.isEmpty() ) {
      nodeToVisit = nodeQueue.dequeue();
      visitor.visit( nodeToVisit );
      if ( ( child = nodeToVisit.leftChild() ) != null ) {
        nodeQueue.enqueue( child );
      }
      if ( ( child = nodeToVisit.rightChild() ) != null ) {
        nodeQueue.enqueue( child );
      }
    }
  }

  // PROTECTED UTILITY METHODS
  /**
   * The recursive method for doing a preorder traversal of the
   * tree rooted at node, applying visitor to each node of the
   * tree.
   * @param node is not null (no check done)
   * @param visitor is not null (no check done)
   */
  protected void doPreOrderTraversal( BinaryTreeNode<E> node,
                                      Visitor<E> visitor ) {
    if ( node == null ) {
      return;
    }
    BinaryTreeNode<E> thenode = node;

    visitor.visit( thenode );
    doPreOrderTraversal( thenode.leftChild(), visitor );
    doPreOrderTraversal( thenode.rightChild(), visitor );
  }

  /**
   * The recursive method for doing an inorder traversal of the
   * tree rooted at node, applying visitor to each node of the
   * tree.
   * @param node is not null (no check done)
   * @param visitor is not null (no check done)
   */
  protected void doInOrderTraversal( BinaryTreeNode<E> node,
                                     Visitor<E> visitor ) {
    if ( node != null ) {
      doInOrderTraversal( node.leftChild(), visitor );
      visitor.visit( node );
      doInOrderTraversal(
          ( ( LinkedBinaryTreeNode<E> ) node ).rightChild, visitor );
    }
  }

  /**
   * The recursive method for doing a postorder traversal of
   * the tree rooted at node, applying visitor to each node
   * of the tree.
   * @param node is not null (no check done)
   * @param visitor is not null (no check done)
   */
  protected void doPostOrderTraversal( BinaryTreeNode<E> node,
                                       Visitor<E> visitor ) {
    if ( node != null ) {
      doPostOrderTraversal(
          ( ( LinkedBinaryTreeNode<E> ) node ).leftChild, visitor );
      doPostOrderTraversal(
          ( ( LinkedBinaryTreeNode<E> ) node ).rightChild, visitor );
      visitor.visit( node );
    }
  }

  class FindVisitor<E> implements Visitor<E> {
    private LinkedBinaryTreeNode<E> targetNode;
    private E targetObject;

    /**
     * Identify the node we are looking for.
     */
    public FindVisitor( E element ) {
      targetObject = element;
      targetNode = null;
    }

    /**
     * Return the node.
     * @return A LinkedBinaryTreeNode.
     */
    public LinkedBinaryTreeNode<E> targetNode() {
      return this.targetNode;
    }

    /**
     * Appends the specified node to the end of the list.
     */
    public void visit( BinaryTreeNode<E> node ) {
      if ( node.element().equals( targetObject ) ) {
        targetNode = ( LinkedBinaryTreeNode<E> ) node;
      }
    }
  }
}
