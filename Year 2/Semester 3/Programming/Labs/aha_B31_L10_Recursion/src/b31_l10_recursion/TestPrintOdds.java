package b31_l10_recursion;

public class TestPrintOdds
{
  public static void main(String[] args)
  {
    System.out.println("printOdds(1)");
    RecursionExercises.printOdds(1);
    System.out.println("\nprintOdds(2)");
    RecursionExercises.printOdds(2);
    System.out.println("\nprintOdds(3)");
    RecursionExercises.printOdds(3);
    System.out.println("\nprintOdds(10)");
    RecursionExercises.printOdds(10);
    System.out.println("\nprintOdds(11)");
    RecursionExercises.printOdds(11);
    try
    {
      RecursionExercises.printOdds(-2);
      System.out.println("printOdds(-2) test failed - no exception thrown");
    }
    catch (IllegalArgumentException e)
    {
      System.out.println("printOdds(-2) passed - exception thrown");
    }
    try
    {
      RecursionExercises.printOdds(0);
      System.out.println("printOdds(0) test failed - no exception thrown");
    }
    catch (IllegalArgumentException e)
    {
      System.out.println("printOdds(0) passed - exception thrown");
    }
  }
}
