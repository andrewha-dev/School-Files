package b31_l03_exceptions;

public class MiscFunctions
{
  public MiscFunctions()
  {
  }

  /**
   * Calculate the square root of x cubed - 1
   * Pre-conditions: x must be >= 1
   * @param x - a double precision number >= 1
   * @return the result of the square root of x cubed - 1
   */
  public double f(double x)
  {
  	try 
  	{
  	if (x < 1)
  		throw new ArithmeticException("Error");
  	}
  	catch (ArithmeticException e)
  	{
  		e.printStackTrace();
  		System.out.println("Error: The value x must not be less then 1");
  	}
  	return Math.sqrt(Math.pow(x, 3) - 1);
  } // f()

  /**
   * Displays a message if an array is sorted
   * Pre-conditions:  testArray is non-null
   *                  0 < numElements  <= testArray.length 
   * @param testArray - a non-null array of Strings
   * @param numElements - the number of elements in testArray
   */
  public void checkSorted(String[] testArray, int numElements)
  {
    String previous = testArray[0];
    int i = 1;
    boolean sorted = true;
 
    if (numElements < 0)
    {
    	throw new IllegalArgumentException("Your number elements is less then 0, it is " + numElements);
    }
    else 
    	if 
    	(numElements == 0)
    	{
    		throw new IllegalArgumentException("Your number element is 0");
    	}
    	else 
    		if
    		(numElements > testArray.length)
    		{
    			throw new IllegalArgumentException("Your number cannot be greater then "
    					+ "the length of the array, your number is " + numElements);
    		}
    
    

   try 
   {
    while (i < numElements && sorted)
    {

      if (testArray[i].compareTo(previous) < 0)
      {
        throw new UnSortedArrayException("Array is not sorted");
//        sorted = false;
        
      }
      previous = testArray[i];
      ++i;
    }
   }
    
    catch (IllegalArgumentException e)
    {
    	e.printStackTrace();
    	e.getMessage();
    }
    catch (NullPointerException e)
    {
    	System.err.println("Array hasnt been initialized");
    }

  } // checkSorted()
}
