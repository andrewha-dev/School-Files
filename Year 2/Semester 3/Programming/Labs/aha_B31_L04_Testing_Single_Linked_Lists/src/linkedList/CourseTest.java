package linkedList;

import static org.junit.Assert.*;

import org.junit.Test;

public class CourseTest
{

	@Test
	public void test1()
	{
		Course course1 = new Course("420-A11", "Operating Systems");
		Course course2 = new Course("420-A11", "Operating Systems");
		assertEquals("Test case 1: for courses",true,course1.equals(course2));
	}
	
	@Test
	public void test2()
	{
		Course course1 = new Course("420-Cdwada11", "Operating Systems");
		Course course2 = new Course("420-A11", "Operating Systems");
		assertEquals("Test case 1: for courses",true,course1.equals(course2));
	}
	
	@Test
	public void test3()
	{
		Course course1 = new Course("420-A11", "Hardware Systems");
		Course course2 = new Course("420-A11", "Operating Systems");
		assertEquals("Test case 1: for courses",true,course1.equals(course2));
	}

}
