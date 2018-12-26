package b31_l10_recursion;

import junit.framework.TestCase;

public class TestQuickSort
  extends TestCase
{
  public TestQuickSort(String sTestName)
  {
    super(sTestName);
  }

  /**
   * @see IntArraySorts#quickSort(int[],int,int)
   */
  public void testQuickSort()
  {
    int[] sorted =
    { 5, 9, 14, 15, 18, 39, 45, 51 };
    int[] ascending =
    { 5, 9, 14, 15, 18, 39, 45, 51 };
    int[] random =
    { 9, 18, 51, 39, 15, 45, 14, 5 };
    int[] descending =
    { 51, 45, 39, 18, 15, 14, 9, 5 };
    // Test Case 1: Array in ascending order
    System.out.println("Test Case 1: Array in ascending order");
    IntArraySorts.quickSort(ascending, 0, ascending.length - 1);
    for (int i = 0; i < random.length; ++i)
      assertEquals("Ascending order array", sorted[i], ascending[i]);

    // Test Case 2: Array in random order
    System.out.println("\nTest Case 2: Array in random order");
    IntArraySorts.quickSort(random, 0, random.length - 1);
    for (int i = 0; i < random.length; ++i)
      assertEquals("Random order array", sorted[i], random[i]);

    // Test Case 3: Array in descending order
    System.out.println("\nTest Case 3: Array in descending order");
    IntArraySorts.quickSort(descending, 0, descending.length - 1);
    for (int i = 0; i < descending.length; ++i)
      assertEquals("Descending order array", sorted[i], descending[i]);
    System.out.println();
  }
}
