package linked_data_structures;

public class ListTraverser
{

	public static void main(String[] args)
	{
		DoublyLinkedList<String> dwarves = new DoublyLinkedList<String>();
		dwarves.addAtEnd("Sneezy");
		dwarves.addAtEnd("Sleepy");
		dwarves.addAtEnd("Dopey");
		dwarves.addAtEnd("Doc");
		dwarves.addAtEnd("Happy");
		dwarves.addAtEnd("Bashful");
		dwarves.addAtEnd("Grumpy");
		
		for (int i = 0; i < dwarves.getLength();i++)
		{
			System.out.println(dwarves.getElementAt(i));
		}
		System.out.println("\n");
		
		for (int i = dwarves.getLength()-1; i >= 0 ; i--)
		{
			System.out.println(dwarves.getElementAt(i));
		}
		
	}

}
