package b31_l04_testing;

import static org.junit.Assert.*;

import org.junit.Test;

public class TemperatureTest 
{

	@Test
//	public void test()
//	{
//		fail("Not yet implemented");
//	}
	
	public void testCase1()
  {
  // Test the instantiation of a Temperature object using default values 
  // for the attributes.
    Temperature t1 = new Temperature(); 
    // verify that the temperature has been correctly set
    assertEquals("Test Case 1: getTemperature()", 0.0,
                 t1.getTemperature(),0.000001);
    // verify that the units have been correctly set
    assertEquals("Test Case 1: getUnits ()", 'C', t1.getUnits());
  } // testCase1()
	
	@Test
	public void testCase2()
	{
		Temperature t2 = new Temperature(24.0, 'C'); 
    // verify that the temperature has been correctly set
    assertEquals("Test Case 2: getTemperature()", 24.0,
                 t2.getTemperature(),0.000001);
    // verify that the units have been correctly set
    assertEquals("Test Case 2: getUnits ()", 'C', t2.getUnits());
		
	}
	
	@Test
	public void testCase3()
  {
  // Test the instantiation of a Temperature object using default values 
  // for the attributes.
    Temperature t1 = new Temperature(84.0, 'F'); 
    // verify that the temperature has been correctly set
    assertEquals("Test Case 3: getTemperature()", 84.0,
                 t1.getTemperature(),0.000001);
    // verify that the units have been correctly set
    assertEquals("Test Case 3: getUnits ()", 'F', t1.getUnits());
  } // testCase1()
	
	@Test
	public void testCase4()
  {
  // Test the instantiation of a Temperature object using illegal values 
  // for the attributes.
    try
    {
      // Try to instantiate a Temperature object with an invalid unit type
      Temperature t4 = new Temperature(24.0, 'A');
      // If the program gets here, the exception wasn't thrown
      fail("Test case 4 - IllegalArgumentException was not thrown.");
    }
    catch (IllegalArgumentException e)
    {
      assertTrue(true); // It worked
    }
  } // testCase4()
	@Test
	public void testCase5()
  {
  // Test the instantiation of a Temperature object using default values 
  // for the attributes.
    Temperature t5 = new Temperature(24.0, 'C');
    // verify that the temperature has been correctly set
    t5.setTemperature(56.5);
    assertEquals("Test Case 5: g etTemperature()", 56.5,
                 t5.getTemperature(),0.000001);
    // verify that the units have been correctly set
    assertEquals("Test Case 5: getUnits ()", 'C', t5.getUnits());
  } // testCase5()
	
	@Test
	public void testCase6()
  {
  // Test the instantiation of a Temperature object using default values 
  // for the attributes.
    Temperature t6 = new Temperature(24.0, 'C');
    // verify that the temperature has been correctly set
    t6.setUnits('F');
    assertEquals("Test Case 6: getTemperature()", 24.0,
                 t6.getTemperature(),0.000001);
    // verify that the units have been correctly set
    assertEquals("Test Case 6: getUnits ()", 'F', t6.getUnits());
  } // testCase5()
	
	@Test
	public void testCase7()
	{

    // verify that the temperature has been correctly set
    try
    {
      // Try to instantiate a Temperature object with an invalid unit type
    	Temperature t7 = new Temperature(24.0, 'C');
    	t7.setUnits('X');
      // If the program gets here, the exception wasn't thrown
      fail("Test case 7 - IllegalArgumentException was not thrown.");
    }
    catch (IllegalArgumentException e)
    {
      assertTrue(true); // It worked
    }
	}
	
	@Test
	public void testCase8()
	{

    // verify that the temperature has been correctly set

      // Try to instantiate a Temperature object with an invalid unit type
    	Temperature t8 = new Temperature(100.0, 'C');

      // If the program gets here, the exception wasn't thrown
    	assertEquals("Test Case 8: getCelisus()", 100.0,
      t8.getCelsius(),0.000001);
    	t8.setUnits('F');
    	
    	assertEquals("Test Case 8: getCelisus()", 37.7777778,
          t8.getCelsius(),0.000001);
	}
	@Test
	public void testCase9()
	{

    // verify that the temperature has been correctly set

      // Try to instantiate a Temperature object with an invalid unit type
    	Temperature t9 = new Temperature(100.0, 'F');

      // If the program gets here, the exception wasn't thrown
    	assertEquals("Test Case 9: getCelisus()", 100.0,
      t9.getFahrenheit(),0.000001);
    	t9.setUnits('C');
    	
    	assertEquals("Test Case 9: getCelisus()", 212.0,
          t9.getFahrenheit(),0.000001);
    	

	}
	



}
