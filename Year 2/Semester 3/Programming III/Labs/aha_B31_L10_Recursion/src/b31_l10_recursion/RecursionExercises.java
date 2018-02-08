package b31_l10_recursion;

public class RecursionExercises
{
  public RecursionExercises()
  {
    super();
  }

  public static void printOdds(int n)
  {
   if (n < 0)
		throw new IllegalArgumentException();
   
   if (n==1)
   {
  	 System.out.println(n + " ");
   }
   else 
   {
  	 printOdds(n-1);
  	if (n%2 ==1)
   System.out.print(n + " ");
   }
   
  }

  public static int calcProduct(int m, int n)
  {
  int prod = 0;
 
   if (n <= 0)
   {
  	 throw new IllegalArgumentException();
   }
   if (n == 1)
   	return m;
   
   else {
  	 prod = m + calcProduct(m, n-1);
   }
  	 return prod;
  }
}
