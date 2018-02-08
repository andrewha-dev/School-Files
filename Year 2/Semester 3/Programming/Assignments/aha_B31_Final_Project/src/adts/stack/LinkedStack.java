package adts.stack;

import java.util.EmptyStackException;

/**
 * An implementation of the Stack ADT based on a singly-linked list.
 */
public class LinkedStack<E> implements Stack<E> {
  private int size;
  private SLNode<E> top;

  public LinkedStack() {
    size = 0;
    top = new SLNode<E> ();
  }

  public void push( E element ) {
    SLNode<E> newTop = new SLNode<E> ( element, top.getSuccessor() );
    top.setSuccessor( newTop );
    size++;
  }

  public E peek() {
    if ( isEmpty() ) {
      throw new EmptyStackException();
    }
    return top.getSuccessor().getElement();
  }

  public E pop() {
    if ( isEmpty() ) {
      throw new EmptyStackException();
    }
    SLNode<E> temp = top.getSuccessor();
    top.setSuccessor( temp.getSuccessor() );
    size--;
    return temp.getElement();
  }

  public int size() {
    return size;
  }

  public boolean isEmpty() {
    return size == 0;
  }

  private class SLNode<E> {
    E element; // the data field
    SLNode<E> successor; // the link to next (successor) SLNode

    /**
     * Constructor. Set both fields of the node to null.
     */
    public SLNode() {
      this.element = null;
      this.successor = null;
    }

    /**
     * Constructor. Initialize the node's data fields to the values provided.
     * @param list_element - the value to be stored in this node.
     * @param successor_node - a reference to the node's new successor.
     */
    public SLNode( E list_element, SLNode<E> successor_node ) {
      this.element = list_element;
      this.successor = successor_node;
    }

    /**
     * Set the element field for this node.
     * @param list_element - the new value to be stored in this node.
     */
    public void setElement( E list_element ) {
      this.element = list_element;
    }

    /**
     * Return the element field of this node.
     */
    public E getElement() {
      return this.element;
    }

    /**
     * Return a reference to the next node in the list.
     */
    public SLNode<E> getSuccessor() {
      return this.successor;
    }

    /**
     * Set the successor to this node in the list.
     * @param successor_node - a reference to the node's new successor.
     */
    public void setSuccessor( SLNode<E> successor_node ) {
      this.successor = successor_node;
    }
  }
}
