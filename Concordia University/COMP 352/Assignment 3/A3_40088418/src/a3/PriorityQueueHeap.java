/**
 * 
 */
package a3;


/**
 * @author Andrew
 *
 */
public class PriorityQueueHeap<E> {
	private Object[] list;
	private int size = 0;
	public long waitTime = 0;

	
	public PriorityQueueHeap()
	{
		list = new Object[2];
	}
	
	public PriorityQueueHeap(int n)
	{
		list = new Object[n];
	}
	
	public void add(Job job)
	{
		if (size >= list.length - 1)
			{
				resize();
			}
		
		size++;
		int temp = size;
		list[temp] = job;		
		upheap();
	}
	
	public void addAgain(Job job)
	{
		if (size >= list.length - 1)
			{
				resize();
			}
		
		size++;
		int temp = size;
		list[temp] = job;		
		upheapAgain();
	}
	
	public Job removeMin()
	{
		Job j = new Job();
		if (!isEmpty())
		{
			j = (Job) list[1];
			list[1] = list[size];
			list[size] = null;
			--size;
			j.setCurrentJobLength(j.getCurrentJobLength() - 1);

			if (j.getCurrentJobLength() >= 1)
			{
				
				j.setExecutedOn(j.getExecutedOn() + 1);
				addAgain(j);
			}
			else
			{

				j.setEndTime(PriorityQueueSimulatorTester.getCurrentTime());
				j.setWaitTime(j.getEndTime() - j.getEntryTime() - j.getJobLength());
				waitTime += j.getWaitTime();
			}		
			downheap();
			
			
		}	
		
		
		return j;
	}
	
	public boolean isEmpty()
	{
		if (size == 0 || (list[1] != null && ((Job)list[1]).getCurrentJobLength() == 0 && size == 1))
			return true;
		else
			return false;
	}
	
	public void resize()
	{
		Object[] temp = new Object[list.length * 2];
		for(int i = 0; i < list.length; i++) {
			Job j = (Job) list[i];
			temp[i] = list[i];
			//temp[i] = j;
		}
		list = temp;
	}
	
	public void upheap()
	{
		int index = size;
		while (hasParent(index) && 
				(getParent(index).getFinalPriority() > ((Job)list[index]).getFinalPriority())
				&& getParent(index).getEntryTime() > ((Job)list[index]).getEntryTime())
		{
			swap(index, getParentIndex(index));
			index = getParentIndex(index);
		}
	}
	
	public void upheapAgain()
	{
		int index = size;
		while (hasParent(index) && 
				(getParent(index).getFinalPriority() > ((Job)list[index]).getFinalPriority())
				&& getParent(index).getExecutedOn() > ((Job)list[index]).getExecutedOn())
		{
			swap(index, getParentIndex(index));
			index = getParentIndex(index);
		}

	}
	
	public void downheap()
	{
		int index = 1;
		while(hasLeftChild(index)) {
			int childIndex = leftChildIndex(index);
			
			if (hasRightChild(index) &&
					((Job)list[childIndex]).getFinalPriority() > ((Job)list[rightChildIndex(index)]).getFinalPriority()
					&& ((Job)list[childIndex]).getExecutedOn() > ((Job)list[rightChildIndex(index)]).getExecutedOn()) {
				childIndex = rightChildIndex(index);
			}
			
			if (((Job)list[index]).getFinalPriority() < (((Job)list[childIndex]).getFinalPriority())
					&& ((Job)list[index]).getExecutedOn() < ((Job)list[childIndex]).getExecutedOn()) {
				swap(index, childIndex);
			}
			else {
				break;
			}
			
			index = childIndex;
		}
	}
	
	public boolean hasParent(int index)
	{
		if (index > 1)
			return true;
		else
			return false;
	}
	
	public int getParentIndex(int index)
	{
		return index/2;
	}
	
	public Job getParent(int index)
	{
		return (Job)list[getParentIndex(index)];
	}
	
	public int leftChildIndex(int index)
	{
		return index * 2;
	}
	
	public int rightChildIndex(int index)
	{
		return index * 2;
	}	
	
	public boolean hasLeftChild(int index)
	{
		if (leftChildIndex(index) <= size)
			return true;
		else
			return false;
	}
	
	public boolean hasRightChild(int index)
	{
		if (rightChildIndex(index) <= size)
			return true;
		else
			return false;
	}	
	
	public void swap(int i, int j)
	{
		Job temp = ((Job) list[i]);
		list[i] = list[j];
		list[j] = temp;
	}
	
	public boolean moveStarvedProcess()
	{
		
		boolean isStarved = false;
		for(int i = 1; i < size; i++)
		{
			if (((Job)list[i]).getCurrentJobLength() == ((Job)list[i]).getJobLength())
			{
				isStarved = true;
				((Job)list[i]).setFinalPriority(1);
				swap(size, i);
				upheapAgain();
				return true;
			}
		}
		return isStarved;
	}
	
	@Override
	public String toString() {
		StringBuilder s = new StringBuilder("[ \n");
	
		for(int i = 1; i < size; i++) {
			s.append(list[i].toString() + ", ");
		}
		s.append("]");
		return s.toString();
	}
	

	
	
	


}
