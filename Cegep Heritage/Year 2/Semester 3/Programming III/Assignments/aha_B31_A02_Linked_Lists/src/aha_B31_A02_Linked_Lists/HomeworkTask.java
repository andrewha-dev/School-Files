/**
 * 
 */
package aha_B31_A02_Linked_Lists;

import java.io.Serializable;
import java.text.SimpleDateFormat;
import java.util.GregorianCalendar;

/**
 * @author 1435792
 *
 */
public class HomeworkTask extends Task implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -7319264804234231826L;
	String taskType;
	int taskNumber;
	String teacherName;
	String taskDescription;
	String courseNumber;
	public HomeworkTask()
	{
		super();
		taskType = "No Task Type Selected";
		teacherName = "No teacher name was entered";
		taskDescription = "No Task Description Available";
	}
	public HomeworkTask(int _priority)
	{
		super();
		priority = _priority;
	}
	public HomeworkTask (int _priority, GregorianCalendar _date)
	{
		super();
		priority = _priority;
		date = _date;
	}
	public HomeworkTask (int _priority, GregorianCalendar _date, String _taskType)
	{
		super();
		priority = _priority;
		date = _date;
		taskType = _taskType;
		
	}
	public HomeworkTask(int _priority, GregorianCalendar _date, String _taskType, String _courseNumber)
	{
		super();
		priority = _priority;
		date = _date;
		taskType = _taskType;
		courseNumber = _courseNumber;
		teacherName = "No teacher name was entered";
		taskDescription = "No Task Description was Available";
	}
	public HomeworkTask(int _priority, GregorianCalendar _date, String _taskType, String _courseNumber, int _taskNumber)
	{
		super();
		priority = _priority;
		date = _date;
		taskType = _taskType;
		courseNumber = _courseNumber;
		taskNumber = _taskNumber;
		teacherName = "No Teacher name was entered";
		taskDescription = "No Task Description Was Available";
	}
	public HomeworkTask(int _priority, GregorianCalendar _date, String _taskType, String _courseNumber, int _taskNumber, String _teacherName)
	{
		super();
		priority = _priority;
		date = _date;
		taskType = _taskType;
		courseNumber = _courseNumber;
		taskNumber = _taskNumber;
		teacherName = _teacherName;
		taskDescription = "No Task Description Was Available";
	}
	public HomeworkTask(int _priority, GregorianCalendar _date, String _taskType, String _courseNumber, int _taskNumber, String _teacherName, String _taskDescription)
	{
		super();
		priority = _priority;
		date = _date;
		taskType = _taskType;
		courseNumber = _courseNumber;
		taskNumber = _taskNumber;
		teacherName = _teacherName;
		if (!_taskDescription.trim().equals(""))
		taskDescription = _taskDescription;
		else 
		taskDescription = "No Task Description Was Available";
	}

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((courseNumber == null) ? 0 : courseNumber.hashCode());
		result = prime * result + ((taskDescription == null) ? 0 : taskDescription.hashCode());
		result = prime * result + taskNumber;
		result = prime * result + ((taskType == null) ? 0 : taskType.hashCode());
		result = prime * result + ((teacherName == null) ? 0 : teacherName.hashCode());
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
		HomeworkTask other = (HomeworkTask) obj;
		if (courseNumber == null) {
			if (other.courseNumber != null)
				return false;
		} else if (!courseNumber.equals(other.courseNumber))
			return false;
		if (taskNumber != other.taskNumber)
			return false;
		if (taskType == null) {
			if (other.taskType != null)
				return false;
		} else if (!taskType.equals(other.taskType))
			return false;
		if (teacherName == null) {
			if (other.teacherName != null)
				return false;
		} else if (!teacherName.equals(other.teacherName))
			return false;
		return true;
	}
	
	public String toString()
	{
		//Must return courseNumber, Teacher, TaskType, taskNumber, priority, date due. Task description after TaskType
		SimpleDateFormat formatter = new SimpleDateFormat("MM/dd/yyyy");
		String date = formatter.format(this.getDate().getTime());
		return 
				"Homework Task: " + "\n" +
				"                Course Number:      " + this.courseNumber + "\n" +
				"                 Teacher Name:      " + this.teacherName + "\n" +
				"                    Task Type:      " + this.taskType + "\n"+ 
				"             Task Description:      " + this.taskDescription + "\n" + 
				"                  Task Number:      " + this.taskNumber + "\n" +
				"                     Priority:      " + this.priority + "\n" + 
				"                     Due Date:      "+ date;
	}
	public String returnFormattedForRemove()
	{
		return "Homework Task | Priority: "+ this.priority + " | CourseNum: " + this.courseNumber + " | " + "Task: " + this.taskType + " " + this.taskNumber;
	}
	public static long getSerialversionuid() {
		return serialVersionUID;
	}
	public String getTaskType() {
		return this.taskType;
	}
	public int getTaskNumber() {
		return this.taskNumber;
	}
	public String getTeacherName() {
		return this.teacherName;
	}
	public String getTaskDescription() {
		return this.taskDescription;
	}
	public String getCourseNumber() {
		return this.courseNumber;
	}


	
}
