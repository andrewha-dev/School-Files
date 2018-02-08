package gray.adts.list;

import static org.junit.Assert.*;

import org.junit.Test;

public class MyLinkedListTest
{

	@Test
	public void test()
	{
		LinkedList<String>list = new MyLinkedList();
		list.add("Ambrose");
		list.add("Trudeau");
		list.add("Mulcair");
		list.add("May");
		assertEquals(true, list.contains("Ambrose"));
		assertEquals(true, list.contains("May"));
		assertEquals(true, list.contains("Mulcair"));
		assertEquals(false, list.contains("Harper"));
	}

}
