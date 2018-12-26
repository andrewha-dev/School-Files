/**
 * 
 */
package aha_A2;

import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

/**
 * @author Andrew
 *
 */
public class MyLinkedList<E> implements List<E>{
	private DLNode head;
    private DLNode tail;
    private int size;
    
	public MyLinkedList()
	{
		tail = new <E>DLNode();
		head = new <E>DLNode(null, null, tail);
		tail.setPredecessor(head);
		size = 0;
	}
	
	
	
	@Override
	public boolean add(E e) {
		//Means its an empty list
		if (head.getSuccessor().getElement() == null)
		{
			head.setSuccessor(new <E>DLNode(e, head, tail));
			tail.setPredecessor(head.getSuccessor());
			
		}
		else
		{
			DLNode<E> newEntry = new <E>DLNode(e, tail.getPredecessor(), tail);
			//tail.setPredecessor(newEntry);
			tail.getPredecessor().setSuccessor(newEntry);
			tail.setPredecessor(newEntry);
		}
		size++;
		return true;
	}

	@Override
	public void add(int index, E element) {
		if (index > size)
		{
			throw new IndexOutOfBoundsException();
		}
		int counter = 0;
		
		DLNode<E> newEntry = new <E>DLNode(element, null, null);
		DLNode<E> current = head;
		 while(current.getSuccessor().getElement() != null && counter < index){
	            current = current.getSuccessor();
	            counter++;
	            
		 }
		 newEntry.setSuccessor(current.getSuccessor());
		 current.getSuccessor().setPredecessor(newEntry);
		 current.setSuccessor(newEntry);
		size++;
	}

	@Override
	public boolean addAll(Collection<? extends E> c) {
		throw new UnsupportedOperationException();
	}

	@Override
	public boolean addAll(int index, Collection<? extends E> c) {
		throw new UnsupportedOperationException();		
	}

	@Override
	public void clear() {
		head.setSuccessor(tail);
		tail.setPredecessor(head);	
		size = 0;
	}

	@Override
	public boolean contains(Object o) {
		throw new UnsupportedOperationException();
	}

	@Override
	public boolean containsAll(Collection<?> c) {
		throw new UnsupportedOperationException();
	}

	@Override
	public E get(int index) {
		throw new UnsupportedOperationException();
	}

	@Override
	public int indexOf(Object o) {
		throw new UnsupportedOperationException();
	}

	@Override
	public boolean isEmpty() {
		throw new UnsupportedOperationException();
	}

	@Override
	public Iterator<E> iterator() {
		throw new UnsupportedOperationException();
	}

	@Override
	public int lastIndexOf(Object o) {
		throw new UnsupportedOperationException();
	}

	@Override
	public ListIterator<E> listIterator() {
		throw new UnsupportedOperationException();

	}

	@Override
	public ListIterator<E> listIterator(int index) {
		throw new UnsupportedOperationException();

	}

	@Override
	public boolean remove(Object o) {
		DLNode<E> current = head;
        while(current.getSuccessor().getElement() != null){
            current = current.getSuccessor();
            if (current.getSuccessor().getElement() != null)
            if (current.getSuccessor().getElement().equals(o))
            {
            	current.getSuccessor().getSuccessor().setPredecessor(current);
            	current.setSuccessor(current.getSuccessor().getSuccessor());
            	size--;
            	return true;
            }
        }
		return false;
	}

	@Override
	public E remove(int index) {
		if (index > size)
		{
			throw new IndexOutOfBoundsException();
		}
		DLNode<E> current = head;
		int counter = 0;
		E temp = null;
		while(current.getSuccessor().getElement() != null && counter < index){

            current = current.getSuccessor();
            temp = current.getElement();
            counter++;
	 }
		//Means its the tail
		if (current.getSuccessor().getElement() == null)
			tail.setPredecessor(current);
		else
		{
			current.getSuccessor().getSuccessor().setPredecessor(current);
			current.setSuccessor(current.getSuccessor().getSuccessor());
		}

		if (temp != null)
		size--;
		return temp;
	}

	@Override
	public boolean removeAll(Collection<?> c) {
		throw new UnsupportedOperationException();
	}

	@Override
	public boolean retainAll(Collection<?> c) {
		throw new UnsupportedOperationException();
	}

	@Override
	public E set(int index, E element) {
		throw new UnsupportedOperationException();
	}

	@Override
	public int size() {
		return this.size;
	}

	@Override
	public List<E> subList(int fromIndex, int toIndex) {
		throw new UnsupportedOperationException();
	}

	@Override
	public Object[] toArray() {
		throw new UnsupportedOperationException();
	}

	@Override
	public <T> T[] toArray(T[] a) {
		throw new UnsupportedOperationException();
	}
	
	@Override
	public String toString()
	{
		StringBuilder result = new StringBuilder("");
        DLNode<E> current = head;
        while(current.getSuccessor().getElement() != null){
            current = current.getSuccessor();
            result.append(current.getElement());
            if (current.getSuccessor().getElement() != null)
            	result.append(" <-> ");
        }
        if (!result.equals(""))
        return "Head <-> " + result + " <-> Tail";
        else
        	return "Head <-> Tail";
	}

}
