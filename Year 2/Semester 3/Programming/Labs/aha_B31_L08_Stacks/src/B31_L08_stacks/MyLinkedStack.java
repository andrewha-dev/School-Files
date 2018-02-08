package B31_L08_stacks;

import java.util.*;

/**
 * An implementation of the Stack ADT based on a singly-linked list.
 */
public class MyLinkedStack<E>
  implements MyStack<E>
{
  private int size;
  private SLNode<E> top;

  public MyLinkedStack()
  {
    size = 0;
    top = new SLNode<E>();
  } // MyLinkedStack()

  public MyLinkedStack(Collection c)
  {

  } // MyLinkedStack(Collection c)

  public void push(E element)
  {
    SLNode<E> newTop = new SLNode<E>(element, top.getSuccessor());
    top.setSuccessor(newTop);
    size++;
  }

  public E peek()
  {
    if (isEmpty())
    {
      throw new EmptyStackException();
    }
    return top.getSuccessor().getElement();
  }

  public E pop()
  {
    if (isEmpty())
    {
      throw new EmptyStackException();
    }
    SLNode<E> temp = top.getSuccessor();
    top.setSuccessor(temp.getSuccessor());
    size--;
    return temp.getElement();
  }

  public int size()
  {
    return size;
  }

  public boolean isEmpty()
  {
    return size == 0;
  }

  public void clear()
  {
  } // clear()

  private class SLNode<E>
  {
    E element; // the data field
    SLNode<E> successor; // the link to next (successor) SLNode

    /**
     * Constructor. Set both fields of the node to null.
     */
    public SLNode()
    {
      this.element = null;
      this.successor = null;
    } // SLNode()

    /**
     * Constructor. Initialize the node's data fields to the values provided.
     * @param list_element - the value to be stored in this node.
     * @param successor_node - a reference to the node's new successor.
     */
    public SLNode(E list_element, SLNode<E> successor_node)
    {
      this.element = list_element;
      this.successor = successor_node;
    } // SLNode(E, SLNode<E>)

    /**
     * Set the element field for this node.
     * @param list_element - the new value to be stored in this node.
     */
    public void setElement(E list_element)
    {
      this.element = list_element;
    } // setElement(E) 

    /**
     * Return the element field of this node.
     */
    public E getElement()
    {
      return this.element;
    } // getElement()

    /**
     * Return a reference to the next node in the list.
     */
    public SLNode<E> getSuccessor()
    {
      return this.successor;
    } // SLNode<E> getSuccessor()

    /**
     * Set the successor to this node in the list.
     * @param successor_node - a reference to the node's new successor.
     */
    public void setSuccessor(SLNode<E> successor_node)
    {
      this.successor = successor_node;
    } // setSuccessor(SLNode<E> )

  } // class SLNode<E>
} // MyLinkedStack<E>
