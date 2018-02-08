package b31_l10_recursion;

import java.util.Collections;

import org.junit.Test;

import junit.framework.TestCase;

public class SearchTest extends TestCase
{
	@Test
	public void testBinarySearch(){
		int[] numArray = {1,3,5,9,10,12,22,33,44,55,100};
				
	Search s = new Search();
	assertEquals(0, s.binSearch(numArray, 0, numArray.length-1, 1));
	assertEquals(1, s.binSearch(numArray, 0, numArray.length-1, 3));
	assertEquals(2, s.binSearch(numArray, 0, numArray.length-1, 5));
	assertEquals(3, s.binSearch(numArray, 0, numArray.length-1, 9));
	assertEquals(4, s.binSearch(numArray, 0, numArray.length-1, 10));
	assertEquals(5, s.binSearch(numArray, 0, numArray.length-1, 12));
	assertEquals(6, s.binSearch(numArray, 0, numArray.length-1, 22));
	assertEquals(7, s.binSearch(numArray, 0, numArray.length-1, 33));
	assertEquals(8, s.binSearch(numArray, 0, numArray.length-1, 44));
	assertEquals(9, s.binSearch(numArray, 0, numArray.length-1, 55));
	assertEquals(10, s.binSearch(numArray, 0, numArray.length-1,100));
	assertEquals(-1, s.binSearch(numArray, 0, numArray.length-1,132323200));

	}
}
   
	