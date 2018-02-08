package gray.adts.queue;

import java.util.List;

public class CompositionPriorityQueue<E> implements PriorityQueue<E>
{
	private ListQueue<E> queue;
	public CompositionPriorityQueue() {
		queue = new ListQueue<E>();
	}
	@Override
	public void enqueue(E Element)
	{
			queue.enqueue(Element);
	}

	@Override
	public void enqueue(int _priority, E Element)
	{
		ListQueue<E> _temp = new ListQueue<E>();
		int indexCounter = 0;
		
		while (queue.isEmpty() == false)
		{
			indexCounter++;
			if (indexCounter == _priority)
			{
				_temp.enqueue(Element);
			}
			else
			_temp.enqueue(queue.dequeue());
		}
		
		queue = _temp;
		
		
	}

	@Override
	public E dequeue()
	{
		return this.queue.dequeue();
	}

	@Override
	public E peek()
	{
		// TODO Auto-generated method stub
		return this.queue.peek();
	}

	@Override
	public int size()
	{
		// TODO Auto-generated method stub
		return this.queue.size();
	}

	@Override
	public boolean isEmpty()
	{
		// TODO Auto-generated method stub
		return this.queue.isEmpty();
	}

	@Override
	public void clear()
	{
		// TODO Auto-generated method stub
		this.queue.clear();
	}

}
