/**
 * 
 */
package aha_B31_A02_Linked_Lists;

import java.io.Serializable;
import java.util.GregorianCalendar;

/**
 * @author 1435792
 *
 */
public abstract class Task implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 2324767360964363372L;
	protected int priority;
	protected GregorianCalendar date;	
	public Task()
	{
		priority = 0;
		date = new GregorianCalendar();
	}
	protected int getPriority()
	{
		return priority;
	}
	protected void setPriority(int priority)
	{
		this.priority = priority;
	}
	protected GregorianCalendar getDate()
	{
		return date;
	}
	protected void setDate(GregorianCalendar date)
	{
		this.date = date;
	}
	public Task(int _priority)
	{
		priority = _priority;
		date = new GregorianCalendar();
	}
	public Task(int _priority, GregorianCalendar _date)
	{
		priority = _priority;
		date = _date;
	}
	public int compareTo(Task obj)
	{
	GregorianCalendar thisDate = this.getDate();
	GregorianCalendar nextDate = obj.getDate();
	return  thisDate.compareTo(nextDate);
		
	
	}
	public abstract String returnFormattedForRemove();


}
