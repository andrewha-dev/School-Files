package B31_L08_stacks;

import gray.adts.stack.LinkedStack;

public class ParenthesisBalancer
{
	public static void main(String args[])
	{
		System.out.println(isBalanced("(5-2)*6"));
		System.out.println(isBalanced("(5 – (a * 9) + 2 / (z – 6)) "));
		System.out.println(isBalanced("((5 – ((a * 9) + 2)) / (z – 6)) is balanced"));
		System.out.println(isBalanced("((((5-a) +2))) "));
		System.out.println(isBalanced("(((5-a) +2)))"));
		System.out.println(isBalanced("(5-a"));
		System.out.println(isBalanced("-	((5 – ((a * 9) + 2) / (z – 6)) "));
		
	}
	public static boolean isBalanced(String _str){
		String _temp = _str;
		LinkedStack<String> stack = new LinkedStack<String>();
		for (int i = 0; i < _temp.length(); i++)
		{
			if (String.valueOf(_temp.charAt(i)).equals("("))
			{
				stack.push("(");
			}
			
			if (String.valueOf(_temp.charAt(i)).equals(")"))
				if (stack.isEmpty() == false)
					stack.pop();
				else
				return false;
			
		}
		if (stack.size() == 0)
			return true;
		
		return false;
	}
}
