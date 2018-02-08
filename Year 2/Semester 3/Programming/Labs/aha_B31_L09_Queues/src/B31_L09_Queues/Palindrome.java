package B31_L09_Queues;

import gray.adts.queue.ListQueue;
import gray.adts.stack.ListStack;
import gray.adts.stack.Stack;


public class Palindrome
{
  public Palindrome()
  {
  }

  public boolean isPalindrome(String str)
  {
    Stack<Character> palindromeStack = new ListStack<Character>();
    ListQueue<Character> queue = new ListQueue<Character>();
    str = str.toUpperCase();
    for (int i = 0; i < str.length(); ++i)
    {
      if (Character.isLetter(str.charAt(i)))
        palindromeStack.push(str.charAt(i));
      if (Character.isLetter(str.charAt(i)))
      	queue.enqueue(str.charAt(i));
    }
    
    
    for (int i = 0; i < str.length(); ++i)
      if (Character.isLetter(str.charAt(i)))
        if ((char) palindromeStack.pop() !=
            queue.dequeue())
          return false;
    return true;
  }
}
