package aha_B31_A02_Linked_Lists;

import static org.junit.Assert.*;

import java.util.GregorianCalendar;

import org.junit.Test;

public class TaskListTest {

	@Test
	public void addTaskTest1() {
		//Priority, date, taskType,courseNumber, taskNumber, teacherName, Description
		TaskList list = new TaskList();
		GregorianCalendar date = new GregorianCalendar();
		Task h1 = new HomeworkTask(1,date , "Lab","420-B31",1 ,"TeacherName", "Description");
		Task h2 = new HomeworkTask(2, date, "Assignment","420-C30",2, "MrSecond","description");
		Task h3 = new HomeworkTask(3, date, "Lab", "420-B31", 1, "TeacherName", "Description");
		
		Task p1 = new PersonalTask(1, date, "Other", "This Task", "Location");
		Task p2 = new PersonalTask(2, date, "Bill", "2nd Personal", "Location");
		Task p3 = new PersonalTask(3, date, "Appointment", "3rd Task", "Location");
		
		clearAllTasks();
		
		list.addTask(h1);
		list.addTask(p1);
		list.addTask(h2);
		list.addTask(p2);
		list.addTask(h3);
		list.addTask(p3);
		
		assertEquals(true, h1.equals(list.returnAllTasks().get(0)));
		assertEquals(true, p1.equals(list.returnAllTasks().get(1)));
		assertEquals(true, h2.equals(list.returnAllTasks().get(2)));
		assertEquals(true, p2.equals(list.returnAllTasks().get(3)));
		assertEquals(true, h3.equals(list.returnAllTasks().get(4)));
		assertEquals(true, p3.equals(list.returnAllTasks().get(5)));
		assertEquals(false, h3.equals(list.returnAllTasks().get(5)));
	}
	@Test
	public void removeTaskTest1()
	{
		TaskList list = new TaskList();
		GregorianCalendar date = new GregorianCalendar();
		Task h1 = new HomeworkTask(1,date , "Lab","420-B31",1 ,"TeacherName", "Description");
		Task h2 = new HomeworkTask(2, date, "Assignment","420-C30",2, "MrSecond","description");
		Task h3 = new HomeworkTask(3, date, "Lab", "420-B31", 1, "TeacherName", "Description");
		
		Task p1 = new PersonalTask(1, date, "Other", "This Task", "Location");
		Task p2 = new PersonalTask(2, date, "Bill", "2nd Personal", "Location");
		Task p3 = new PersonalTask(3, date, "Appointment", "3rd Task", "Location");
		
		//Removing all previous tasks first
		clearAllTasks();
		list.addTask(h1);
		list.addTask(p1);
		list.addTask(h2);
		list.addTask(p2);
		list.addTask(h3);
		list.addTask(p3);
		
		list.removeTask(0);
		assertEquals(true, p1.equals(list.returnAllTasks().get(0)));
		assertEquals(true, h2.equals(list.returnAllTasks().get(1)));
		assertEquals(true, p2.equals(list.returnAllTasks().get(2)));
		assertEquals(true, h3.equals(list.returnAllTasks().get(3)));
		assertEquals(true, p3.equals(list.returnAllTasks().get(4)));
		assertEquals(false, h3.equals(list.returnAllTasks().get(4)));
	}
	
	@Test
	public void removeTaskTest2()
	{
		TaskList list = new TaskList();
		GregorianCalendar date = new GregorianCalendar();
		Task h1 = new HomeworkTask(1,date , "Lab","420-B31",1 ,"TeacherName", "Description");
		Task h2 = new HomeworkTask(2, date, "Assignment","420-C30",2, "MrSecond","description");
		Task h3 = new HomeworkTask(3, date, "Lab", "420-B31", 1, "TeacherName", "Description");
		
		Task p1 = new PersonalTask(1, date, "Other", "This Task", "Location");
		Task p2 = new PersonalTask(2, date, "Bill", "2nd Personal", "Location");
		Task p3 = new PersonalTask(3, date, "Appointment", "3rd Task", "Location");
		
		clearAllTasks();
		list.addTask(h1);
		list.addTask(p1);
		list.addTask(h2);
		list.addTask(p2);
		list.addTask(h3);
		list.addTask(p3);
		
		list.removeTask(list.returnAllTasks().size()-1);
		assertEquals(true, h1.equals(list.returnAllTasks().get(0)));
		assertEquals(true, p1.equals(list.returnAllTasks().get(1)));
		assertEquals(true, h2.equals(list.returnAllTasks().get(2)));
		assertEquals(true, p2.equals(list.returnAllTasks().get(3)));
		assertEquals(true, h3.equals(list.returnAllTasks().get(4)));
		assertEquals(5, list.returnAllTasks().size());
		try {
			assertEquals(true, p3.equals(list.returnAllTasks().get(5)));
			fail("The task list should be missing the index");
		}
		catch (IndexOutOfBoundsException e) {
			assertTrue(true);
		}
		
		
	}//Testing when removing from the back of the list
	
	@Test
	public void removeTaskTest3()
	{
		TaskList list = new TaskList();
		GregorianCalendar date = new GregorianCalendar();
		Task h1 = new HomeworkTask(1,date , "Lab","420-B31",1 ,"TeacherName", "Description");
		Task h2 = new HomeworkTask(2, date, "Assignment","420-C30",2, "MrSecond","description");
		Task h3 = new HomeworkTask(3, date, "Lab", "420-B31", 1, "TeacherName", "Description");
		
		Task p1 = new PersonalTask(1, date, "Other", "This Task", "Location");
		Task p2 = new PersonalTask(2, date, "Bill", "2nd Personal", "Location");
		Task p3 = new PersonalTask(3, date, "Appointment", "3rd Task", "Location");
		
		clearAllTasks();
		list.addTask(h1);
		list.addTask(p1);
		list.addTask(h2);
		list.addTask(p2);
		list.addTask(h3);
		list.addTask(p3);
		
		list.removeTask(3);
		assertEquals(true, h1.equals(list.returnAllTasks().get(0)));
		assertEquals(true, p1.equals(list.returnAllTasks().get(1)));
		assertEquals(true, h2.equals(list.returnAllTasks().get(2)));
		assertEquals(true, h3.equals(list.returnAllTasks().get(3)));
		assertEquals(true, p3.equals(list.returnAllTasks().get(4)));
		assertEquals(5, list.returnAllTasks().size());
	}//Testing removing a task from the middle of the list
	
	//Finding nextDueTasks
	@Test
	public void findNextDueTask()
	{
		TaskList list = new TaskList();
		clearAllTasks();
		try{
		assertEquals(true, list.returnAllTasks().get(0));	
		fail("Should've thrown an exception");	
		}
		catch (IndexOutOfBoundsException e)
		{
			assertTrue(true);
		}
	}//No tasks
	
	@Test
	public void findNextDueTask1()
	{
		TaskList list = new TaskList();
		GregorianCalendar date = new GregorianCalendar();
		clearAllTasks();
		Task p1 = new PersonalTask(1, date, "Other", "This Task", "Location");
		list.addTask(p1);
		assertEquals(1, list.getHighPriorityTasksByDueDate().size());
		assertEquals(true, p1.equals(list.getHighPriorityTasksByDueDate().get(0)));		
	}//Testing a single personal task
	
	@Test
	public void findNextDueTask2()
	{
		TaskList list = new TaskList();
		GregorianCalendar date = new GregorianCalendar();
		clearAllTasks();
		Task h1 = new HomeworkTask(1,date , "Lab","420-B31",1 ,"TeacherName", "Description");
		list.addTask(h1);
		assertEquals(1, list.getHighPriorityTasksByDueDate().size());
		assertEquals(true, h1.equals(list.getHighPriorityTasksByDueDate().get(0)));		
	}//Testing a single homework task
	
	@Test
	public void findNextDueTask3()
	{
		TaskList list = new TaskList();
		
		clearAllTasks();
		Task h1 = new HomeworkTask(1,new GregorianCalendar(2016,11,01) , "Lab","420-B31",1 ,"TeacherName", "Description");
		Task h2 = new HomeworkTask(1, new GregorianCalendar(2016,11,01), "Assignment","420-C30",2, "MrSecond","description");
		Task h3 = new HomeworkTask(2, new GregorianCalendar(2016,12,01), "Assignment","420-C30",2, "MrSecond","description");
		list.addTask(h1);
		list.addTask(h2);
		list.addTask(h3);

		assertEquals(true, h1.equals(list.findNextDueTasks().get(0)));
		assertEquals(true, h2.equals(list.findNextDueTasks().get(1)));
		
	}//Multiple homework tasks
	
	@Test
	public void findNextDueTask4()
	{
		TaskList list = new TaskList();
		
		clearAllTasks();
		Task p1 = new PersonalTask(1, new GregorianCalendar(2016,11,01), "Other", "This Task", "Location");
		Task p2 = new PersonalTask(2, new GregorianCalendar(2016,11,01), "Bill", "2nd Personal", "Location");
		Task p3 = new PersonalTask(3, new GregorianCalendar(2016,12,01), "Appointment", "3rd Task", "Location");
		list.addTask(p1);
		list.addTask(p2);
		list.addTask(p3);

		assertEquals(true, p1.equals(list.findNextDueTasks().get(0)));
		assertEquals(true, p2.equals(list.findNextDueTasks().get(1)));
		
	}//Multiple personal tasks
	
	@Test
	public void findNextDueTask5()
	{
		TaskList list = new TaskList();
		
		clearAllTasks();
		Task h1 = new HomeworkTask(1, new GregorianCalendar(2016,11,02) , "Lab","420-B31",1 ,"TeacherName", "Description");
		Task h2 = new HomeworkTask(1, new GregorianCalendar(2016,12,01), "Assignment","420-C30",2, "MrSecond","description");
		Task h3 = new HomeworkTask(2, new GregorianCalendar(2016,11,01), "Assignment","420-C30",2, "MrSecond","description");
		
		Task p1 = new PersonalTask(1, new GregorianCalendar(2016,11,01), "Other", "This Task", "Location");
		Task p2 = new PersonalTask(2, new GregorianCalendar(2016,11,01), "Bill", "2nd Personal", "Location");
		Task p3 = new PersonalTask(3, new GregorianCalendar(2016,11,02), "Appointment", "3rd Task", "Location");
		list.addTask(h1);
		list.addTask(h2);
		list.addTask(h3);
		list.addTask(p1);
		list.addTask(p2);
		list.addTask(p3);

		assertEquals(true, h3.equals(list.findNextDueTasks().get(0)));
		assertEquals(true, p1.equals(list.findNextDueTasks().get(1)));
		assertEquals(true, p2.equals(list.findNextDueTasks().get(2)));
		
	}
	
	@Test
	public void getHighPriorityTasksByDueDate()
	{
		clearAllTasks();
		TaskList list = new TaskList();
		assertEquals(0, list.getHighPriorityTasksByDueDate().size());		
	}//Testing an empty list
	
	@Test
	public void getHighPriorityTasksByDueDate1()
	{
		clearAllTasks();
		TaskList list = new TaskList();
		Task p1 = new PersonalTask(1, new GregorianCalendar(2016,11,01), "Other", "This Task", "Location");
		list.addTask(p1);
		assertEquals(true, p1.equals(list.getHighPriorityTasksByDueDate().get(0)));
	}//Testing a homework task that has a priority
	
	@Test
	public void getHighPriorityTasksByDueDate2()
	{
		clearAllTasks();
		TaskList list = new TaskList();
		Task h1 = new HomeworkTask(1, new GregorianCalendar(2016,11,02) , "Lab","420-B31",1 ,"TeacherName", "Description");
		list.addTask(h1);
		assertEquals(true, h1.equals(list.getHighPriorityTasksByDueDate().get(0)));
	}//Testing a personal task that has a priority
	
	@Test
	public void getHighPriorityTasksByDueDate3()
	{
		clearAllTasks();
		TaskList list = new TaskList();
		Task h1 = new HomeworkTask(2, new GregorianCalendar(2016,11,02) , "Lab","420-B31",1 ,"TeacherName", "Description");
		list.addTask(h1);
		assertEquals(0,list.getHighPriorityTasksByDueDate().size());
	}//Testing a homework task that has no priority
	
	@Test
	public void getHighPriorityTasksByDueDate4()
	{
		clearAllTasks();
		TaskList list = new TaskList();
		Task p1 = new PersonalTask(2, new GregorianCalendar(2016,11,01), "Other", "This Task", "Location");
		list.addTask(p1);
		assertEquals(0,list.getHighPriorityTasksByDueDate().size());
	}//Testing a homework task that has no priority
	
	@Test
	public void getHighPriorityTasksByDueDate5()
	{
		TaskList list = new TaskList();
		clearAllTasks();
		Task h1 = new HomeworkTask(1, new GregorianCalendar(2016,11,03) , "Lab","420-B31",1 ,"TeacherName", "Description");
		Task h2 = new HomeworkTask(1, new GregorianCalendar(2016,11,05) , "Lab","420-B31",1 ,"TeacherName", "Description");
		Task p1 = new PersonalTask(1, new GregorianCalendar(2016,11,02), "Other", "This Task", "Location");
		list.addTask(h1);
		list.addTask(h2);
		list.addTask(p1);
		assertEquals(true,h1.equals(list.getHighPriorityTasksByDueDate().get(1)));
		assertEquals(true,p1.equals(list.getHighPriorityTasksByDueDate().get(0)));
		assertEquals(true, h2.equals(list.getHighPriorityTasksByDueDate().get(2)));
	}//Two tasks with high priority and mixed dates
	
	@Test
	public void getHighPriorityTasksByDueDate6()
	{
		TaskList list = new TaskList();
		clearAllTasks();
		Task h1 = new HomeworkTask(1, new GregorianCalendar(2016,11,01) , "Lab","420-B31",1 ,"TeacherName", "Description");
		Task h2 = new HomeworkTask(1, new GregorianCalendar(2016,11,01) , "Lab","420-B31",1 ,"TeacherName", "Description");
		Task p1 = new PersonalTask(1, new GregorianCalendar(2016,11,01), "Other", "This Task", "Location");
		list.addTask(h1);
		list.addTask(h2);
		list.addTask(p1);
		assertEquals(true,h1.equals(list.getHighPriorityTasksByDueDate().get(0)));
		assertEquals(true,p1.equals(list.getHighPriorityTasksByDueDate().get(2)));
		assertEquals(true, h2.equals(list.getHighPriorityTasksByDueDate().get(1)));
	}//Multiple tasks with same dates
	
	@Test
	public void getHighPriorityTasksByDueDate7()
	{
		TaskList list = new TaskList();
		clearAllTasks();
		Task h1 = new HomeworkTask(1, new GregorianCalendar(2016,11,01) , "Lab","420-B31",1 ,"TeacherName", "Description");
		Task h2 = new HomeworkTask(1, new GregorianCalendar(2017,11,01) , "Lab","420-B31",1 ,"TeacherName", "Description");
		Task p1 = new PersonalTask(1, new GregorianCalendar(2018,11,01), "Other", "This Task", "Location");
		list.addTask(h1);
		list.addTask(h2);
		list.addTask(p1);
		assertEquals(true,h1.equals(list.getHighPriorityTasksByDueDate().get(0)));
		assertEquals(true,p1.equals(list.getHighPriorityTasksByDueDate().get(2)));
		assertEquals(true, h2.equals(list.getHighPriorityTasksByDueDate().get(1)));
	}//Multiple tasks with same dates but different years
	
	@Test
	public void getHighPriorityTasksByDueDate8()
	{
		TaskList list = new TaskList();
		clearAllTasks();
		Task h1 = new HomeworkTask(1, new GregorianCalendar(2016,10,01) , "Lab","420-B31",1 ,"TeacherName", "Description");
		Task h2 = new HomeworkTask(2, new GregorianCalendar(2017,1,01) , "Lab","420-B31",1 ,"TeacherName", "Description");
		Task p1 = new PersonalTask(1, new GregorianCalendar(2018,5,01), "Other", "This Task", "Location");
		list.addTask(h1);
		list.addTask(h2);
		list.addTask(p1);
		assertEquals(true,h1.equals(list.getHighPriorityTasksByDueDate().get(0)));
		assertEquals(true,p1.equals(list.getHighPriorityTasksByDueDate().get(1)));
	}//Multiple tasks with mixed months and days and one is missing a priority
	
	@Test
	public void getHighPriorityTasksByDueDate9()
	{
		TaskList list = new TaskList();
		clearAllTasks();
		Task h1 = new HomeworkTask(1, new GregorianCalendar(2016,11,01) , "Lab","420-B31",1 ,"TeacherName", "Description");
		Task p1 = new PersonalTask(1, new GregorianCalendar(2016,11,01), "Other", "This Task", "Location");
		list.addTask(p1);
		list.addTask(h1);
		assertEquals(true,h1.equals(list.getHighPriorityTasksByDueDate().get(1)));
		assertEquals(true,p1.equals(list.getHighPriorityTasksByDueDate().get(0)));
	}//Multiple tasks same dates
	
	@Test
	public void getTasksByDueDate()
	{
		TaskList list = new TaskList();
		clearAllTasks();
		assertEquals(0, list.getTasksByDueDate().size());
	}//Empty list
	
	@Test
	public void getTasksByDueDate1()
	{
		TaskList list = new TaskList();
		clearAllTasks();
		Task h1 = new HomeworkTask(1, new GregorianCalendar(2017,1,1) , "Lab","420-B31",1 ,"TeacherName", "Description");
		list.addTask(h1);
		assertEquals(true, h1.equals(list.getTasksByDueDate().get(0)));
	}//Adding a homework task
	
	@Test
	public void getTasksByDueDate2()
	{
		TaskList list = new TaskList();
		clearAllTasks();
		Task p1 = new PersonalTask(1, new GregorianCalendar(2016,11,01), "Other", "This Task", "Location");
		list.addTask(p1);
		assertEquals(true, p1.equals(list.getTasksByDueDate().get(0)));
	}//Adding a personal task
	
	@Test
	public void getTasksByDueDate3()
	{
		TaskList list = new TaskList();
		clearAllTasks();
		Task h1 = new HomeworkTask(1, new GregorianCalendar(2017,1,1) , "Lab","420-B31",1 ,"TeacherName", "Description");
		Task h2 = new HomeworkTask(1, new GregorianCalendar(2018,2,2) , "Lab","420-B31",1 ,"TeacherName", "Description");
		list.addTask(h1);
		list.addTask(h2);
		assertEquals(true, h1.equals(list.getTasksByDueDate().get(0)));
		assertEquals(true, h2.equals(list.getTasksByDueDate().get(1)));
	}//More than 1 homework task all different
	
	@Test
	public void getTasksByDueDate4()
	{
		TaskList list = new TaskList();
		clearAllTasks();
		Task p1 = new PersonalTask(1, new GregorianCalendar(2016,11,02), "Other", "This Task", "Location");
		Task p2 = new PersonalTask(1, new GregorianCalendar(2018,11,01), "Other", "This Task", "Location");
		list.addTask(p1);
		list.addTask(p2);
		assertEquals(true, p1.equals(list.getTasksByDueDate().get(1)));
		assertEquals(true, p2.equals(list.getTasksByDueDate().get(0)));
	}//More than 1 personal task, same day different year
	
	@Test
	public void getTasksByDueDate5()
	{
		TaskList list = new TaskList();
		clearAllTasks();
		Task p1 = new PersonalTask(1, new GregorianCalendar(2018,11,02), "Other", "This Task", "Location");
		Task h1 = new HomeworkTask(1, new GregorianCalendar(2017,1,1) , "Lab","420-B31",1 ,"TeacherName", "Description");
		list.addTask(p1);
		list.addTask(h1);
		assertEquals(true, p1.equals(list.getTasksByDueDate().get(1)));
		assertEquals(true, h1.equals(list.getTasksByDueDate().get(0)));
	}//More than 1 tasks. At least 1 of each tasks
	
	@Test
	public void getTasksByDueDate6()
	{
		TaskList list = new TaskList();
		clearAllTasks();
		Task p1 = new PersonalTask(1, new GregorianCalendar(2017,1,1), "Other", "This Task", "Location");
		Task h1 = new HomeworkTask(1, new GregorianCalendar(2017,1,1) , "Lab","420-B31",1 ,"TeacherName", "Description");
		list.addTask(p1);
		list.addTask(h1);
		assertEquals(true, p1.equals(list.getTasksByDueDate().get(0)));
		assertEquals(true, h1.equals(list.getTasksByDueDate().get(1)));
	}//More than 1 tasks. All same date
	
	@Test
	public void getTasksByDueDate7()
	{
		TaskList list = new TaskList();
		clearAllTasks();
		Task p1 = new PersonalTask(1, new GregorianCalendar(2015,10,28), "Other", "This Task", "Location");
		Task h1 = new HomeworkTask(1, new GregorianCalendar(2001,11,12) , "Lab","420-B31",1 ,"TeacherName", "Description");
		Task p2 = new PersonalTask(1, new GregorianCalendar(1997,10,31), "Other", "This Task", "Location");
		Task h2 = new HomeworkTask(1, new GregorianCalendar(2004,11,24) , "Lab","420-B31",1 ,"TeacherName", "Description");
		list.addTask(p1);
		list.addTask(h1);
		list.addTask(p2);
		list.addTask(h2);
		assertEquals(true, p2.equals(list.getTasksByDueDate().get(0)));
		assertEquals(true, h1.equals(list.getTasksByDueDate().get(1)));
		assertEquals(true, h2.equals(list.getTasksByDueDate().get(2)));
		assertEquals(true, p1.equals(list.getTasksByDueDate().get(3)));
	}
	
	@Test
	public void saveAndReadFromFile()
	{
		TaskList list = new TaskList();
		//Clearing any previous tasklists
		clearAllTasks();
		Task p1 = new PersonalTask(1, new GregorianCalendar(2015,10,28), "Other", "This Task", "Location");
		Task h1 = new HomeworkTask(1, new GregorianCalendar(2001,11,12) , "Lab","420-B31",1 ,"TeacherName", "Description");
		
		list.addTask(h1);
		list.addTask(p1);
		
		list.saveToFile("testFile");
		//Clearing all tasks
		clearAllTasks();
		//Testing if the list is now null
		assertEquals(0, list.returnAllTasks().size());
		list.readFromFile("testFile");
		assertEquals(true, h1.equals(list.returnAllTasks().get(0)));
		assertEquals(true, p1.equals(list.returnAllTasks().get(1)));
		//Trying to add an updated list to the file
		Task p2 = new PersonalTask(1, new GregorianCalendar(1997,10,31), "Other", "This Task", "Location");
		Task h2 = new HomeworkTask(1, new GregorianCalendar(2004,11,24) , "Lab","420-B31",1 ,"TeacherName", "Description");
		list.addTask(h2);
		list.addTask(p2);
		
		list.saveToFile("testFile");
		clearAllTasks();
		list.readFromFile("testFile");
		
		assertEquals(true, h1.equals(list.returnAllTasks().get(0)));
		assertEquals(true, p1.equals(list.returnAllTasks().get(1)));
		assertEquals(true, h2.equals(list.returnAllTasks().get(2)));
		assertEquals(true, p2.equals(list.returnAllTasks().get(3)));		
	}
	
	
	public void clearAllTasks()
	{
		TaskList list = new TaskList();
		for (int i = list.returnAllTasks().size() - 1; i >= 0; i--)
		{
			list.removeTask(i);
		}
	}
	

}
