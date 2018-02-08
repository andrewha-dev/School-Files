/**
 * Linked implementation of the <code>java.util.List</code> interface
 * by extending <code>java.util.AbstractSequentialList</code>.<p>
 */
package adts.list;

import java.util.*;

import java.io.Serializable;

import java.util.AbstractList;

/**
 * Linked implementation of the <code>java.util.List</code> interface
 * by extending <code>java.util.AbstractSequentialList</code>.<p>
 */
public class

LinkedList<E>
  extends AbstractSequentialList<E>
  implements Serializable
{

  private transient int size = 0; // size can never be < 0
  private transient DLNode<E> head;
  private transient DLNode<E> tail;

  public LinkedList()
  {
    size = 0;
    tail = new DLNode<E>(); // the tail dummy node
    head = new DLNode<E>(null, null, tail); // the head dummy node
    tail.setPredecessor(head);
    modCount = 0;
  }

  public void add(int index, E o)
  {
    ListIterator<E> iter = this.listIterator(index);
    iter.add(o);
  }

  public E get(int index)
  {
    ListIterator<E> iter = this.listIterator(index);
    return iter.next();
  } // get (int index)

  public E remove(int index)
  {
    ListIterator<E> iter = this.listIterator(index);
    E o = iter.next();
    iter.remove();
    return o;
  } // remove (int)

  public ListIterator<E> listIterator(int index)
  {
    if ((index < 0) || (index > size))
      throw new IndexOutOfBoundsException("index " + index + 
                                          " is out of range: 0 to " + 
                                          size);
    return new LinkedListIterator<E>(index);
  }

  public int size()
  {
    return this.size;
  }

  //    public void add( int index, E e ) {
  //    // add() and listIterator() have the same requirements with respect to
  //    // index, so let listIterator() do the checking
  //        ListIterator<E> iter = listIterator( index );
  //        iter.add( e );
  //        modCount++;
  //    }

  //    public Object remove( int index ) {
  //        // verify that index is legal
  //        if (( index < 0 ) || ( index >= size ) )
  //            throw new IllegalArgumentException("index " + index
  //                             + " is out of range: 0 to " + (this.size - 1));
  //        ListIterator<E> iter = listIterator( index );
  //        E element = iter.next();
  //        iter.remove( );
  //        modCount++;
  //        return element;
  //    }

  /*
        pre: 0 <= index <= size()
             We DO NOT check that this is true!
    */

  private DLNode<E> getNodeAt(int index)
  {
    // check for empty list and appending at the tail
    if (index == this.size)
      return tail;
    DLNode<E> p = null;

    if ((index < this.size / 2))
    { // start at beginning of the list
      p = head.getSuccessor();
      for (int i = 0; i != index; i++)
        p = p.getSuccessor();
    }
    else
    {
      p = tail.getPredecessor();
      for (int i = this.size - 1; i != index; i--)
        p = p.getPredecessor();
    }
    return p;
  }

  // inner class implementing the list iterator
  /*
        As before, some methods can be implemented in the abstract class using
        other methods defined in the class. A very simple example is
        listIterator() which returns a ListIterator object which will begin
        its iteration with the first element in the list. This is easily
        implemented as return listIterator(0);

        But ASL makes much more use of this ability.
        ASL is written assuming a sequential access structure will be used
        as the backing store. This means that all the indexed ("random access")
        operations are written on top of the list iterator. For example,
        add(index, element) can easily be implemented as
          ListIterator iter = new ListIterator(index);
          iter.add( element );

        Implementations of remove(index), set(index), addAll(index, collection)
        can easily be implemented in a similar fashion.
        But how can there be concrete implementations of the optional methods defined
        in ASL? If these methods are not needed by a List implementation, they
        should throw an UnsupportedExceptionOperation. The answer is rather
        neat. By building the optional methods on top of the ListIterator methods,
        we can defer throwing an exception to ListIterator. If, on the other hand,
        we want to support an optional method, all we need to do is to provide
        the necessary implementation in the ListIterator class! For example, the
        add(index, element) method uses the add(element) method from ListIterator.
        If add() operations are not supported for a particular list implementation,
        all you need to do is
        implement ListIterator.add(element) to throw an UnsupportedExceptionOperation.
        If List.add(index, element) is invoked, it will throw an UnsupportedExceptionOperation
        when it invokes the ListIterator.add(element) method. Alternatively, if
        add() is to be supported, ListIterator.add(element) is implemented
        accordingly (as we will do).

        To support checks for concurrent modification, AL defines a modCount
        data field to keep track of all structural modifications to the list.
        This field is marked as protected in AL, which means that it is not
        available outide of the class, but it is available to subclasses
        of AL. Each time the list is structurally modified, the modCount field
        must be incremented. As before, when an Iterator or a ListIterator
        object is created, it must make a copy of the modCount field. If the
        expectedModCount value is different from modCount when any Iterator
        or ListIterator method is called, a ConcurrentModificationException
        must be thrown. The updating of the modCount field must be done by the
        add() and remove() methods from ListIterator because the add() and remove()
        methods defined in ASL do not do this.

        While having the abstract classes available is a real help, it also
        incurs a responsibility to check the contracts for those classes to
        make sure that the methods we implement in LinkedList meet all the
        obligations laid out by an ancestor class. For example,
    */

  public class LinkedListIterator<E>
    implements ListIterator<E>
  {
    // invariant: cursor should always reference a node from
    //  head's successor to tail. cursor should never reference head.
    private DLNode<E> cursor; // references node to be returned by next(), which
    // is successor to node to be returned by previous()

    private DLNode<E> lastNodeReturned; // last node reterned by next() or previous()
    private int nextIndex; // index of node returned by NEXT call to next()

    /**
         * Provides fail-fast operation of the iterator. For each call to an
         * iterator method, expectedModCount should be equal to the collection's
         * modCount, otherwise an intervening change (concurrent modification)
         * to the collection has been made and we cannot guarantee that the
         * iterator will behave correctly.
         */
    private int expectedModCount;

    /**
         * the contract of remove() says that each call to remove() must have
         * been preceded by a call to next()/previous() (they are paired). So if there has
         * been NO call to next()/previous() prior to a remove() or if there were two
         * remove() calls without an intervening next()/previous() call, it is NOT ok to
         * try to remove an item.
         */
    private boolean okToRemove;

    // pre: 0 <= index <= size()

    public LinkedListIterator(int index)
    {
      if ((index < 0) || (index > size))
        throw new IndexOutOfBoundsException("index " + index + 
                                            " is out of range: 0 to " + 
                                            size);
      // cursor starts out at the target node's predecessor
      //DLNode temp = head;
      if (index == 0)
        cursor = (DLNode<E>) head.getSuccessor();
      else if (index == size)
        cursor = (DLNode<E>) tail;
      else
        cursor = (DLNode<E>) getNodeAt(index);
      nextIndex = index;
      okToRemove = false;
      expectedModCount = modCount;
      lastNodeReturned = null;
    }

    public E next()
    {
      if (!hasNext())
        throw new NoSuchElementException("no next element");

      checkForConcurrentModification();

      okToRemove = true;

      // next() is the inverse of previous():
      //   always get the element field THEN advance the cursor
      nextIndex++;
      E element = cursor.getElement();
      lastNodeReturned = cursor;
      cursor = cursor.getSuccessor();
      return element;
    }

    public E previous()
    {
      checkForConcurrentModification();
      if (!hasPrevious())
        throw new NoSuchElementException("no previous element");

      okToRemove = true;

      // previous() is the inverse of next():
      //   always decrement the cursor THEN get the element field
      nextIndex--;
      cursor = cursor.getPredecessor();
      lastNodeReturned = cursor;
      //System.err.println("previous(): cursor is " + cursor);
      return cursor.getElement();
    }

    // nextIndex is the index of the element to be returned by next(),
    //  so the previous index will be one less than nextIndex

    public int previousIndex()
    {
      checkForConcurrentModification();
      if (hasPrevious())
        return nextIndex - 1;
      else
        return -1;
    }

    public int nextIndex()
    {
      checkForConcurrentModification();
      if (hasNext())
        return nextIndex;
      else
        return size;
    }

    public boolean hasNext()
    {
      checkForConcurrentModification();
      return cursor != tail;
    }

    public boolean hasPrevious()
    {
      checkForConcurrentModification();
      return cursor.getPredecessor() != head;
    }

    public void add(E o)
    {
      checkForConcurrentModification();

      okToRemove = false;

      DLNode<E> newnode = 
        new DLNode<E>(o, cursor.getPredecessor(), cursor);
      newnode.getPredecessor().setSuccessor(newnode);
      cursor.setPredecessor(newnode);

      nextIndex++;
      size++; // update List data field
      modCount++; // update List data field
      expectedModCount = modCount;
    }

    public void remove()
    {
      checkForConcurrentModification();

      // check that there has been a next()/previous() message to provide
      // an element to remove
      if (!okToRemove)
        throw new IllegalStateException();

      okToRemove = false;

      // either the cursor or nextIndex needs to be updated
      if (cursor == 
          lastNodeReturned) // removing item returned by a previous() call
        cursor = cursor.getSuccessor(); // move cursor forward
      else // removing item returned by a next() call
        nextIndex--; // move nextIndex backward

      lastNodeReturned.getPredecessor().setSuccessor(lastNodeReturned.getSuccessor());
      lastNodeReturned.getSuccessor().setPredecessor(lastNodeReturned.getPredecessor());

      // now do cleanup
      lastNodeReturned.setSuccessor(null);
      lastNodeReturned.setPredecessor(null);
      lastNodeReturned.setElement(null);
      lastNodeReturned = null;

      size--; // update LinkedList data field
      modCount++; // update AbstractList data field
      expectedModCount = modCount;
    }

    // change the value stored by the last node returned by next() or
    //   previous()

    public void set(E o)
    {
      checkForConcurrentModification();
      lastNodeReturned.setElement(o);
    }

    private void checkForConcurrentModification()
    {
      if (expectedModCount != modCount)
        throw new java.util.ConcurrentModificationException();
    }

  }

}
