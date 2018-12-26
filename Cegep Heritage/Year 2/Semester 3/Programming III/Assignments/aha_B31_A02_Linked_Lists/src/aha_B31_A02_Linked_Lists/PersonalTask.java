package aha_B31_A02_Linked_Lists;

import java.io.Serializable;
import java.text.SimpleDateFormat;
import java.util.GregorianCalendar;

public class PersonalTask extends Task implements Serializable
{

	/**
	 * 
	 */
	private static final long serialVersionUID = 7282484134573721729L;
	String taskType;
	String taskName;
	String taskLocation;
	public PersonalTask()
	{
		super();
		taskType = "No Task Type Was Selected";
		taskName = "No task name was entered";
		taskLocation = "No task location was entered";
	}
	public PersonalTask(int _priority)
	{
		super();
		priority = _priority;
		taskType = "No Task Type Was Selected";
		taskName = "No task name was entered";
		taskLocation = "No task location was entered";
	}
	public PersonalTask(int _priority, GregorianCalendar _date)
	{
		super();
		priority = _priority;
		date = _date;
	}

	public PersonalTask(int _priority, GregorianCalendar _date, String _taskType)
	{
		super();
		priority = _priority;
		date = _date;
		taskType = _taskType;
		taskName = "No task name was entered";
		taskLocation = "No task location was entered";
	}
	public PersonalTask(int _priority, GregorianCalendar _date, String _taskType, String _taskName)
	{
		super();
		priority = _priority;
		date = _date;
		taskType = _taskType;
		taskName = _taskName;
		taskLocation = "No task location was entered";
	}
	public PersonalTask(int _priority, GregorianCalendar _date, String _taskType, String _taskName, String _taskLocation)
	{
		super();
		priority = _priority;
		date = _date;
		taskType = _taskType;
		taskName = _taskName;
		if (_taskLocation.trim().equals(""))
			taskLocation = "No Task Location Available";
		else
		taskLocation = _taskLocation;
	}

	public String toString()
	{
		//Should be returning taskType, taskName, priority, date due. If task location is not null then it should be included after taskname
		SimpleDateFormat formatter = new SimpleDateFormat("MM/dd/yyyy");
		String date = formatter.format(this.getDate().getTime());
		return 
				"Personal Task:" + "\n" +
				"                    Task Name:      " + this.taskName + "\n" +
				"                Task Location:      " + this.taskLocation + "\n" +
				"                    Task Type:      " + this.taskType + "\n"+ 
				"                     Priority:      " + this.priority + "\n" + 
				"                     Due Date:      "+ date;
	}
	
	public String returnFormattedForRemove() {
		// TODO Auto-generated method stub
		return "Personal Task | Priority: "+ this.priority + " | Task Name: " + this.taskName + " | " + "Task: " + this.taskType;
	}
	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((taskLocation == null) ? 0 : taskLocation.hashCode());
		result = prime * result + ((taskName == null) ? 0 : taskName.hashCode());
		result = prime * result + ((taskType == null) ? 0 : taskType.hashCode());
		return result;
	}
	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		PersonalTask other = (PersonalTask) obj;
		if (taskName == null) {
			if (other.taskName != null)
				return false;
		} else if (!taskName.equals(other.taskName))
			return false;
		if (taskType == null) {
			if (other.taskType != null)
				return false;
		} else if (!taskType.equals(other.taskType))
			return false;
		return true;
	}

}
