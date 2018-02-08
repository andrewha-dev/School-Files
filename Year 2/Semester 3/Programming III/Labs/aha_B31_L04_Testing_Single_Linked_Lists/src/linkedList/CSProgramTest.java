package linkedList;

import static org.junit.Assert.*;

import org.junit.Test;

public class CSProgramTest
{
	@Test
	public void test1()
	{
		CSProgram prod1 = new CSProgram();
		assertEquals("Test case 1: for semester 4",20, prod1.getHours(5));
	}
	
	@Test
	public void test2()
	{
		CSProgram prod = new CSProgram();
		assertEquals("Test case 1: for semester 4",19, prod.getHours(4));
	}
	
	@Test
	public void test3()
	{
		try
		{
		CSProgram prod = new CSProgram();
		prod.getHours(0);
		fail("Should throw illegal argument exception");
		}
		catch (IllegalArgumentException e)
		{
			assertTrue(true);
		}

	}
	@Test
	public void test5()
	{
		CSProgram prod10 = new CSProgram();
		prod10.reviseProgram();
		assertEquals("Test case 1: for semester 4", 15, prod10.getHours(4));
	}
	@Test
	public void test6()
	{
		CSProgram prod12 = new CSProgram();
		prod12.reviseProgram();
		assertEquals("Test case 1: for semester 4",26, prod12.getHours(5));
	}


}
