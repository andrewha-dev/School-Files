package gray.adts.queue;

public interface PriorityQueue<E>
{

	public void enqueue( E Element);
	
	public void enqueue(int _priority, E Element);
	
	public E dequeue();
	
	public E peek();
	
	public int size();
	
	public boolean isEmpty();
	
	public void clear();
}
