package b31_l10_recursion;

public class Search
{
	
	public int binSearch(int[] array, int first, int last, int key){
		int mid = (first + last )/2;
		if (first > last)
		{
			return -1;
		}		
		 
		if (array[mid] == key){
				return mid;
		}
		else 
			if (key < array[mid])	{
			return binSearch(array, first, mid-1, key);
		}
		else 
			if (key > array[mid])
			{
			return binSearch(array, mid+1, last, key);
		}
			else {
				return -1;
			}
		
		
		
	}
}
