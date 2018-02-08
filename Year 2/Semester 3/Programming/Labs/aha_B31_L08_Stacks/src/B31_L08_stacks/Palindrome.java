package B31_L08_stacks;

import gray.adts.stack.*;

public class Palindrome
{
  public Palindrome()
  {
  }

  public boolean isPalindrome(String str)
  {
  	String _temp = str.toLowerCase();
  	_temp = _temp.trim();
  	_temp = _temp.replaceAll("\\W", "");
  	LinkedStack<Character> stack = new LinkedStack<Character>();
  	for (int i = 0; i < +_temp.length(); i++)
  	{
  		stack.push(_temp.charAt(i));  		
  	}
  	String reverse = "";
  	while (!stack.isEmpty()){
  		reverse = reverse.concat(String.valueOf(stack.pop()));
  	}
  	System.out.println(reverse);
  	System.out.println(_temp);
    if (reverse.equals(_temp))
    {
    	return true;
    }
    return false;
  }
}
