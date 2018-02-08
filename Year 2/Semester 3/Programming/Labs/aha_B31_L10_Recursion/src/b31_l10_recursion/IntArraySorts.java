package b31_l10_recursion;

/**
 * A collection of methods to sort arrays of ints.
 */
public class IntArraySorts
{

	private static int partition(int[] array, int first, int last)
	{
		int left = first;
		int right = last;
		int middle = array[(left + right) / 2];

		while (left <= right)
		{
			while (array[left] < middle)
				left++;
			while (array[right] > middle)
				right--;
			if (left <= right)
			{
				swap(array, left, right);
				left++;
				right--;
			}
		}
		return left;
	}

	private static void swap(int[] array, int a, int b)
	{
		int temp = array[a];
		array[a] = array[b];
		array[b] = temp;
	}

	public static void quickSort(int[] array, int first, int last)
	{
		if (array.length <= 1)
			return;

		int pivotPosition = partition(array, first, last);
		if (first < pivotPosition - 1)
			quickSort(array, first, pivotPosition - 1);
		if (pivotPosition < last)
			quickSort(array, pivotPosition, last);

	}

}