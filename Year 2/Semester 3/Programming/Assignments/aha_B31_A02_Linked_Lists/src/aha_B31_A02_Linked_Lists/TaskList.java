package aha_B31_A02_Linked_Lists;
import java.util.LinkedList;
import java.util.ListIterator;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.util.AbstractSequentialList;
import java.util.Collections;
import java.util.Comparator;
import java.util.GregorianCalendar;
import java.util.Iterator;
public class TaskList implements Serializable
{

	/**
	 * 
	 */
	private static final long serialVersionUID = -1502564627550825502L;

	protected static LinkedList<Task> taskList = new LinkedList<Task>();

	public LinkedList<Task> taskListTemp = new LinkedList<Task>();

	
	public TaskList()
	{
		
	}
	public void addTask(Task _task)
	{
	taskList.addLast(_task);	
	}
	public void removeTask(int _index)
	{
		taskList.remove(_index);
	}
	//Finding the earliest date and then using that date as a reference and compares it to the list
	public LinkedList<Task> findNextDueTasks()
	{
		LinkedList<Task> earliestTasks = new LinkedList<Task>();
		LinkedList<Task> sorted = returnSortedByDate(taskList);
		//Sorting the list by the earliest dates
		ListIterator<Task> sorter = sorted.listIterator();
		boolean sameDate = true;
		int index = 0;
		GregorianCalendar earliestDate = sorter.next().getDate();
		for (Task iter: sorted)
		{
			if (iter.getDate().compareTo(earliestDate) == 0)
			{
				earliestTasks.add(iter);
			}
		}
		return earliestTasks;
	}
	public LinkedList<Task> getTasksByDueDate()
	{	
		return returnSortedByDate(taskList);
	}
	//Getting all the tasks by their highest priority dates
	public LinkedList<Task> getHighPriorityTasksByDueDate()
	{
		LinkedList<Task> _temp = taskList;
		//Sorts the list by date before looking for the highest priorities
		_temp = returnSortedByDate(_temp);
		LinkedList<Task> highPriorityTasks = new LinkedList<>();
		//Going through the task list and looking for any tasks that have priority 1
		for (Task iter: _temp)
		{
			if (iter.getPriority() == 1)
			highPriorityTasks.addLast(iter);
		}
		return highPriorityTasks;
	}

	public LinkedList<Task> returnAllTasks()
	{
		return taskList;
	}
	public void updateList(LinkedList<Task> _updatedList)
	{
		taskList = _updatedList;
	}
	public void setInstanceOfTask()
	{
		taskListTemp = taskList;
	}
	public LinkedList<Task> returnInstanceOfTask()
	{
		return taskListTemp;
	}
	public LinkedList<Task> returnSortedByDate(LinkedList<Task> _toSort)
	{	
		//Uses the comparator to sort the list
		LinkedList<Task> _tempList = _toSort;	
		Collections.sort(_tempList, new Comparator<Task>(){

			@Override
			public int compare(Task o1, Task o2) {
				return o1.compareTo(o2);
			}
			
		});
		//Returns the sorted list by the date
		return _tempList;
	}
	public boolean readFromFile(String fileNameLoad)
	{
		//Automatically adding the .ser extension to the file name
		fileNameLoad = fileNameLoad.concat(".ser");
		 FileInputStream fileIn;
		try {
			fileIn = new FileInputStream(fileNameLoad);
			 ObjectInputStream in = new ObjectInputStream(fileIn);
			 TaskList taskObject = (TaskList) in.readObject();
			 taskList = taskObject.returnInstanceOfTask();
		     in.close();
		     fileIn.close();
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			return false;
		}
		catch (IOException e)
		{
			return false;
		}
		catch (ClassNotFoundException e)
		{
			return false;
		}

		return true;
	}
	public boolean saveToFile(String fileNameSave)
	{
		//Automatically adding .ser to the end of the file name
		fileNameSave = fileNameSave.concat(".ser");
		FileOutputStream fileOut;
		try {
			fileOut = new FileOutputStream(fileNameSave);
			ObjectOutputStream out = new ObjectOutputStream(fileOut);
			TaskList taskListObj = new TaskList();
			taskListObj.setInstanceOfTask();
	         out.writeObject(taskListObj);
	         out.close();
	         fileOut.close();
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			return false;
		}		
		catch (IOException e)
		{
			return false;
		}
	
		return true;
	}


}
