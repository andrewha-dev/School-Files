/**
 * 
 */
package a3;

/**
 * @author Andrew
 *
 */
public class PriorityQueueList <E>{
	private Object[] list;
	public int size = 0;
	public int test = 0;
	public long waitTime = 0;
	
	Job temp = new Job();

	public PriorityQueueList()
	{
		list =  new Object[3];
	}
	
	public PriorityQueueList(int n)
	{
		list = new Object[n];
	}
	
	
	public void enqueue(Job job)
	{		
		
		if (isEmpty())
		{
			list[0] = job;
			size++;
		}
		else
		{
			if (isFull())
				resize();
			list[size] = job;
			size++;
			sort();
			
		}	

	}
	
	public void sort()
	{
		for (int i = 0; i < size-1; i++) 
            for (int j = 0; j < size-i-1; j++) 
                if (((Job)list[j]).getFinalPriority() > ((Job)list[j+1]).getFinalPriority())
//                && ((Job)list[j]).getEntryTime() < ((Job)list[j + 1]).getEntryTime()) 
                { 
                    Job temp = (Job)list[j]; 
                    list[j] = list[j+1]; 
                    list[j+1] = temp; 
                } 
	}
	
	public void sortAgain()
	{
		for (int i = 0; i < size-1; i++) 
            for (int j = 0; j < size-i-1; j++) 
                if (((Job)list[j]).getFinalPriority() > ((Job)list[j+1]).getFinalPriority()
                && ((Job)list[j]).getExecutedOn() > ((Job)list[j + 1]).getExecutedOn()) 
                { 
                    Job temp = (Job)list[j]; 
                    list[j] = list[j+1]; 
                    list[j+1] = temp; 
                } 
	}
	
	public void enqueueAgain(Job job)
	{		

		if (isEmpty())
		{
			list[0] = job;
			size++;
		}
		else
		{
			if (isFull())
				resize();
			list[size] = job;
			size++;
			sortAgain();
			
		}
//		size++;
	}
	

	public Job dequeue()
	{
		Job j = (Job)list[0];		
		j.setExecutedOn(j.getExecutedOn() + 1);
		j.setProcessed(true);
		//System.out.println(j);
		j.setCurrentJobLength(j.getCurrentJobLength() - 1);

		if (j.getCurrentJobLength() > 0)
		{

			shiftArray();
			size--;			
			enqueueAgain(j);
		}
		else
		{
			j.setEndTime(PriorityQueueSimulatorTester.getCurrentTime());
			j.setWaitTime(j.getEndTime() - j.getEntryTime() - j.getJobLength());
			waitTime += j.getWaitTime();
			shiftArray();
			size--;


		}
		

		return j;
	}
	
	public void shiftArray()
	{
		Object[] temp = new Object[list.length];
		if (size >= 1)
			{
				for(int i = 1; i < size;i++)
				{
					temp[i - 1] = list[i];
				}
				list = temp;
				
			}
	}
	
	public boolean moveStarvedProcess()
	{
		boolean isStarvedFound = false;
		//Loop through and look for the the most starved process.
		for(int i = 0; i < size; i++)
		{
			if (!isStarvedFound)
				if (!((Job)list[i]).isProcessed())
				{
					//System.out.println("Starved Found: ");
					isStarvedFound = true;
					Job job = (Job) list[i];
					for(int j = i; j < size - 1; j++){
	                    list[j] = list[j+1];
	                }
					size--;
					job.setFinalPriority(1);
					job.setExecutedOn(job.getExecutedOn() + 1);
					enqueueAgain(job);
				}
		}
		return isStarvedFound;
	}
	
	public boolean isEmpty()
	{
		if (size == 0 || (list[0] != null && ((Job)list[0]).getCurrentJobLength() == 0 && size == 1))
			return true;
		else
			return false;
	}
	
	public boolean isFull()
	{
		if (size == list.length - 1)
			return true;
		else
			return false;
	}
	
	public void resize()
	{
		Object[] temp = new Object[list.length * 2];
		for(int i = 0; i < size; i++)
		{
			temp[i] = list[i];
		}
		list = temp;
	}
	
	@Override
	public String toString() {
		StringBuilder s = new StringBuilder("[ \n");
	
		for(int i = 0; i < size - 1; i++) {
			s.append(list[i].toString() + ", ");
		}
		s.append("]");
		return s.toString();
	}
	
	
}
