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
 * @param <E>
 */
public class MyArrayList<E> implements List<E> {
	protected E[] list;
	int size = 0;
	
	
	public MyArrayList()
	{
		list = (E[]) new Object[0];
	}
	
	public MyArrayList(int n)
	{
		if ( n <= 0 ) {
		      throw new IllegalArgumentException();
		    }
		list = (E[]) new Object[n];
	}
	
	@Override
	public boolean add(E e) {
		// TODO Auto-generated method stub
		
		if (list.length <= 0)
			list = (E[]) new Object[1];

		if (list[list.length - 1] != null)
		{			
			this.resize(true);
		}
		boolean foundIndex = false;
		int index = 0;
		int counter = 0;
		while (foundIndex == false)
		{
			if (list[counter] != null)
			counter++;
			else
			{
				
				index = counter;
				foundIndex = true;
				list[index] = e;
				size++;
				return true;
			}
		}
		
		return false;
	}

	@Override
	public void add(int index, E element) {
		// TODO Auto-generated method stub
		if (list.length <= 0)
		{
			list = (E[]) new Object[1];
			size = 1;
		}
			
		
		if (index > size )
			return;
		
		if (list[list.length - 1] != null)
		{
			resize(true);
		}
		E temp = list[index];
//		for(int i = index + 1; i < list.length; i++)
//		{
//			E otherTemp = list[index + 1];
//			list[index + 1] = temp;
//		}
		
		E[] tempArray = (E[]) list.clone();
		list[index] = element;	
		size++;
		for(int i = index + 1; i < size - 1; i++)
		{
			list[i] = tempArray[i - 1];
		}
		if (list[list.length - 1] != null)
		{
			resize(true);
		}
		
	}
	
	public void resize(boolean _resizeBig)
	{
		if (_resizeBig)
		{
			E[] temp = (E[]) new Object[list.length * 2];
			
			for(int i = 0; i < size - 1; i++)
			{
				temp[i] = this.list[i];
			}
			list = temp;
		}
		else
		{
			//Figuring out which one is the last used element
			int lastIndex = 0;
			for(int i = 1; i < list.length - 1; i++)
			{
				if (list[i] == null)
				{
					//System.out.println(list.length);
					if (list[i-1] != null)
					{

						lastIndex = i-1;
					}
				}
			}
			int quarterIndex = (int) ((list.length - 1) * 0.25);
			if (quarterIndex == 0)
				quarterIndex = 1;
			if (lastIndex <= quarterIndex)
			{
				E[] temp = (E[]) new Object[list.length/2];	
				
				for(int i = 0; i < temp.length - 1; i++)
				{
					if (list[i] != null)
					temp[i] = list[i];
					else
					list[i] = null;
				}
				
				list = temp;
			}

		}
	}
	
	public void shiftArray()
	{
		for (int j=0; j < list.length; j++){
            if (list[j]==null){
                for (int k=j+1; k<list.length; k++){
                    list[k-1] = list[k];
                }
                list[list.length-1] = null;
                break;
            }
        }
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
		list = (E[]) new Object[0];		
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
		int counter = 0; 
		boolean found = false;
		while (found == false && counter <= size - 1)
		{
			if (list[counter] != null)
			if (list[counter].equals(o))
			{
				found = true;
				list[counter] = null;
			}
			counter++;
		}
		if (found == true)
		{
			resize(false);
			shiftArray();
			size--;
			return true;
		}
		else
			return false;
	}

	@Override
	public E remove(int index) {
		E temp = null;
		if (list.length != 0)
		{
			if (index > size)
			throw new ArrayIndexOutOfBoundsException();
		temp = list[index];
		list[index] = null;

		if (temp != null)
		size--;
		resize(false);
		shiftArray();
		}
		
		
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
		// TODO Auto-generated method stub
		return size;
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
		StringBuilder s = new StringBuilder("[");
		for(int i = 0; i < size;i++)
		{
			if (i < list.length - 1)
			s.append(list[i] + ", ");
			else 
				s.append(list[i]);

		}
		s.append("]");
		return s.toString();
	}

}
