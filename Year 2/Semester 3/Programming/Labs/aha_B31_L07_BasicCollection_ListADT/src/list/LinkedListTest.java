package list;

import static org.junit.Assert.*;

import java.util.NoSuchElementException;

import org.junit.Test;

public class LinkedListTest
{
	@Test
	public void test0()
	{
		try {
			
		
		LinkedList<String> list = new LinkedList();
		list.reverse();
		assertEquals("Test", null, list.get(0));
		}
		catch(NoSuchElementException e) {
			assert(true);//IT Worked
		}
	}

	@Test
	public void test()
	{
		LinkedList<String> list = new LinkedList();
		list.add("R");
		list.add("A");
		list.add("C");
		list.add("~FIN~");
		assertEquals("Test", "~FIN~", list.get(3));
		assertEquals("Test", "C", list.get(2));
		assertEquals("Test", "A", list.get(1));
		assertEquals("Test", "R", list.get(0));
	}
	@Test
	public void test2()
	{
		LinkedList<String> list = new LinkedList();
		list.add("R");
		list.add("A");
		list.add("C");
		list.add("E");
		list.reverse();
		assertEquals("Test", "R", list.get(3));
		assertEquals("Test", "A", list.get(2));
		assertEquals("Test", "C", list.get(1));
		assertEquals("Test", "E", list.get(0));
		
		
	}

}
