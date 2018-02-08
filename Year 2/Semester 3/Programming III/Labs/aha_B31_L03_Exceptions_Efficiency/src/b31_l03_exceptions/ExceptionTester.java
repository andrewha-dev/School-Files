package b31_l03_exceptions;

import java.util.Scanner;

public class ExceptionTester
{
  public static void main(String[] args)
  {
    Scanner input = new Scanner(System.in);
    MiscFunctions fn = new MiscFunctions();
    System.out.print("Enter a value for x> ");
    double x = input.nextDouble();
    System.out.println("The result of f(x) is " + fn.f(x));

  }
}
