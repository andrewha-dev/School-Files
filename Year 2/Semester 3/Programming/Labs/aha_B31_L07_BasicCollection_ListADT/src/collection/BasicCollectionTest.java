package collection;

import java.util.Collection;

import static org.junit.Assert.*;
import org.junit.Test;

public class BasicCollectionTest
{
	public BasicCollectionTest()
	{
	}

	@Test
	public void testAddAll()
	{
		Collection<String> c = new BasicCollection<String>();
		c.add("one");
		c.add("two");
		c.add("three");
		assertEquals("c size before addall", 3, c.size());
		Collection<String> c1 = new BasicCollection<String>();
		c1.add("dog");
		c1.add("Bird");
		c1.add("cat");
		c1.add("two");
		assertTrue("addAll successful", c.addAll(c1));
		assertEquals("addAll size", 7, c.size());
		for (String d : c1)
			assertTrue("addAll: c contains c1"+d, c.contains(d));

	}
	@Test
	public void testRemoveAll()
	{
		Collection<String> c = new BasicCollection<String>();
		c.add("one");
		c.add("two");
		c.add("three");
		c.add("dog");
		c.add("Bird");
		c.add("cat");
		c.add("two");
		assertEquals("c size before removeall", 7, c.size());
		Collection<String> c1 = new BasicCollection<String>();
		c1.add("dog");
		c1.add("Bird");
		c1.add("cat");
		c1.add("two");
		assertTrue("removeAll successful", c.removeAll(c1));
		assertEquals("c size after removeall", 2, c.size());
		for (String d : c1)
			assertFalse("removeAll c does not contain c1"+d, c.contains(d));
	}
	
	
	@Test
	public void testClear()
	{
		Collection<String> c = new BasicCollection<String>();
		c.add("one");
		c.add("two");
		c.add("three");
		c.add("dog");
		c.add("Bird");
		c.add("cat");
		c.add("two");
		assertEquals("c size before clear", 7, c.size());
		c.clear();
		assertEquals("c size after clear", 0, c.size());
		assertTrue("c isEmpty() after clear",c.isEmpty());
	}
}
