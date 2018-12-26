package b31_l10_recursion;


import java.util.List;

import junit.framework.TestCase;

public class RecursionExercisesTest extends TestCase
{
  public RecursionExercisesTest()
  {
  }


  /**
   * @see RecursionExamples#calcProduct(int,int)
   */
  public void testCalcProduct()
  {
    assertEquals("calcProduct(5,1)", 5,
                 RecursionExercises.calcProduct(5, 1));
    assertEquals("calcProduct(5,2)", 10,
                 RecursionExercises.calcProduct(5, 2));
    assertEquals("calcProduct(5,6)", 30,
                 RecursionExercises.calcProduct(5, 6));
    assertEquals("calcProduct(-5,6)", -30,
                 RecursionExercises.calcProduct(-5, 6));
    try
    {
      assertEquals("calcProduct(5,-1)", -5,
                   RecursionExercises.calcProduct(5, -1));
      fail("calcProduct(5,-1)");
    }
    catch (IllegalArgumentException e)
    {
      assertTrue("calcProduct(5,-1)", true);
    }
  }
}
