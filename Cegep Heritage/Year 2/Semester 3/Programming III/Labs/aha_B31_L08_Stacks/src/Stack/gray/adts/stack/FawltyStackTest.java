package gray.adts.stack;

import static org.junit.Assert.*;

import org.junit.Test;

public class FawltyStackTest
{

	@Test
	public void test()
	{
	Stack <String> s = new FawltyStack<String>();
	assertEquals("Size is 0", 0, s.size());
	assertEquals("IsEmpty", true, s.isEmpty());
		try {
			String str = s.peek();
			fail("Fail");
		}
		catch (Exception e){
			assertTrue(true);
		}
		try {
			String str = s.pop();
			fail("Fail");
		}
		catch (Exception e){
			assertTrue(true);
		}
	
	}
	@Test
	public void Test2()
	{
		Stack <String> s = new FawltyStack<String>();
		s.push("Trudeau");
		assertEquals("Size", 1, s.size());
		assertEquals("IsEmpty", false, s.isEmpty());
		String str = s.peek();
		assertEquals("Trudeau", str);
		s.push("Harper");
		assertEquals("Size", 2, s.size());
		str = s.peek();
		assertEquals("Harper", str);		
		s.push("Mulcair");
		assertEquals("Size", 3, s.size());
		str = s.peek();
		assertEquals("Mulcair", str);
		
	}
	
	@Test
	public void Test3()
	{
		Stack <String> s = new FawltyStack<String>();
		assertEquals("Size is 0", 0, s.size());
		assertEquals("IsEmpty", true, s.isEmpty());
		s.push("Trudeau");
		s.push("Ambrose");
		s.push("Mulcair");
		
		String str = s.pop();
		assertEquals("Mulcair", str);
		str = s.peek();
		assertEquals("Ambrose", str);
		assertEquals("Size", 2, s.size());
		str = s.pop();
		assertEquals("Ambrose", str);
		str = s.peek();
		assertEquals("Trudeau", str);
		assertEquals("Size", 1, s.size());
		assertEquals("isEmpty", false, s.isEmpty());
		str = s.pop();
		assertEquals("Trudeau", str);
		assertEquals("Size", 0, s.size());
		assertEquals("isEmpty", true, s.isEmpty());
	}

}
