package gray.adts.list;



public class MyLinkedList extends LinkedList
{
	public MyLinkedList()
	{
		LinkedList<String>list = new LinkedList();
	}
	private boolean isEqual(Object target, int n)
	{
		if (n == -1)
			return false;
		else
			if (get(n).equals(target))
				return true;
			else		
				return isEqual(target, n-1);
		
	}
	
	public boolean contains(Object target)
	{
		return isEqual(target, size()-1);
	}
}
