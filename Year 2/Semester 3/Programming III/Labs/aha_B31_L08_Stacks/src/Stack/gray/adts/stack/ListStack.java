package gray.adts.stack;

import java.util.LinkedList;
import java.util.List;
import java.util.EmptyStackException;

/**
 * An implementation of the Stack interface using a List as the
 *  underlying data structure.
 */
public class ListStack<E> implements Stack<E> {
  private java.util.List<E> stack;
  // the top of stack is represented by position
  //   s.size() - 1 in the list.

  /**
   * Create an empty stack.
   */
  public ListStack() {
    stack = new LinkedList();
  }

  /**
   * Determine if the stack is empty.
   * @return <tt>true</tt> if the stack is empty,
   * otherwise return false
   */
  public boolean isEmpty() {
    return stack.isEmpty();
  }

  /**
   * Return the top element of the stack without removing it.
   * This operation does not modify the stack.
   * @return topmost element of the stack
   * @throws StackEmptyException if the stack is empty
   */
  public E peek() {
    if ( stack.isEmpty() ) {
      throw new EmptyStackException();
    }
    return stack.get( stack.size() - 1 );
  }

  /**
   * Pop the top element from the stack and return it.
   * @return topmost element of the stack
   * @throws StackEmptyException if the stack is empty
   */
  public E pop() {
    if ( stack.isEmpty() ) {
      throw new EmptyStackException();
    }
    return stack.remove( stack.size() - 1 );
  }

  /**
   * Push <tt>element</tt> on top of the stack.
   * @param element the element to be pushed on the stack.
   */
  public void push( E element ) {
    stack.add( stack.size(), element );
  }

  /**
   * Return the number of elements currently stored in the stack.
   * @return topmost element of the stack
   */
  public int size() {
    return stack.size();
  }
}
