package B31_L08_stacks;

import java.util.Scanner;

import gray.adts.stack.*;

public class StackExample
{
  public static void main(String[] args)
  {
    Scanner input = new Scanner(System.in);
    Stack<String> whatISaid = new LinkedStack<String>();
    System.out.println("Type any 5 words and hit enter.");
    for (int i = 0; i < 5; ++i)
    {
      String word = input.next();
      whatISaid.push(word);
    }
    System.out.println("\nThe top of the stack is "+whatISaid.peek());
    System.out.println("There are "+whatISaid.size()+" words on the stack.");
    System.out.println("\nThe last thing you said was " + whatISaid.pop());
    System.out.println("The top of the stack is now "+whatISaid.peek());
    System.out.println("There are "+whatISaid.size()+" words left on the stack.");
    
  	while (whatISaid.size() != 1)
  	{
  		System.out.println(whatISaid.pop());
  		System.out.println(whatISaid.peek());
  		System.out.println(whatISaid.size());
  	}
  	System.out.println("The last thing is" + whatISaid.pop());
}
  }
  
