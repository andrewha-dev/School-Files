package aha_B31_A02_Linked_Lists;

import static org.junit.Assert.*;

import java.util.GregorianCalendar;

import org.junit.Test;

public class TaskTest {
	//Testing personal Tasks
	@Test
	public void compareToTest() {
		Task task1 = new PersonalTask(1, new GregorianCalendar(2016,11,02), "TaskType", "Name", "Location");
		Task task2 = new PersonalTask(1, new GregorianCalendar(2016,11,01), "TaskType", "Name", "Location");
		assertEquals(1, task1.compareTo(task2));
	}//If task1 > task2
	
	@Test
	public void compareToTest2() {
		Task task1 = new PersonalTask(1, new GregorianCalendar(2016,11,01), "TaskType", "Name", "Location");
		Task task2 = new PersonalTask(1, new GregorianCalendar(2016,11,02), "TaskType", "Name", "Location");
		assertEquals(-1, task1.compareTo(task2));
	}//If task1 < task2
	
	@Test
	public void compareToTest3() {
		Task task1 = new PersonalTask(1, new GregorianCalendar(2016,11,02), "TaskType", "Name", "Location");
		Task task2 = new PersonalTask(1, new GregorianCalendar(2016,11,02), "TaskType", "Name", "Location");
		assertEquals(0, task1.compareTo(task2));
	}//If task1 == task2
	
	//Testing homework Tasks
	@Test
	public void compareToTest4() {
		Task task1 = new HomeworkTask(1, new GregorianCalendar(2016,11,02),"Lab","420-B30", 1, "Totally Not Sandra Stark", "Task Descrip");
		Task task2 = new HomeworkTask(1, new GregorianCalendar(2016,11,01),"Lab","420-B30", 1, "Totally Not Sandra Stark", "Task Descrip");
		assertEquals(1, task1.compareTo(task2));
	}//if task1 > task2
	@Test
	public void compareToTest5()
	{
		Task task1 = new HomeworkTask(1, new GregorianCalendar(2016,11,01),"Lab","420-B30", 1, "Totally Not Sandra Stark", "Task Descrip");
		Task task2 = new HomeworkTask(1, new GregorianCalendar(2016,11,02),"Lab","420-B30", 1, "Totally Not Sandra Stark", "Task Descrip");
		assertEquals(-1, task1.compareTo(task2));
	}//If Task1 < task2
	@Test
	public void compareToTest6()
	{
		Task task1 = new HomeworkTask(1, new GregorianCalendar(2016,11,01),"Lab","420-B30", 1, "Totally Not Sandra Stark", "Task Descrip");
		Task task2 = new HomeworkTask(1, new GregorianCalendar(2016,11,01),"Lab","420-B30", 1, "Totally Not Sandra Stark", "Task Descrip");
		assertEquals(0, task1.compareTo(task2));
	}//If task1 == task2
	
	@Test
	public void compareToTest7()
	{
		Task task1 = new PersonalTask(1, new GregorianCalendar(2016,11,02), "TaskType", "Name", "Location");	
		Task task2 = new HomeworkTask(1, new GregorianCalendar(2016,11,01),"Lab","420-B30", 1, "Totally Not Sandra Stark", "Task Descrip");
		assertEquals(1, task1.compareTo(task2));
	}//If task1 > task2
	
	@Test
	public void compareToTest8()
	{
		Task task1 = new PersonalTask(1, new GregorianCalendar(2016,11,01), "TaskType", "Name", "Location");	
		Task task2 = new HomeworkTask(1, new GregorianCalendar(2016,11,02),"Lab","420-B30", 1, "Totally Not Sandra Stark", "Task Descrip");
		assertEquals(-1, task1.compareTo(task2));
	}//If task1 < task2
	
	@Test
	public void compareToTest9()
	{
		Task task1 = new PersonalTask(1, new GregorianCalendar(2016,11,01), "TaskType", "Name", "Location");	
		Task task2 = new HomeworkTask(1, new GregorianCalendar(2016,11,01),"Lab","420-B30", 1, "Totally Not Sandra Stark", "Task Descrip");
		assertEquals(0, task1.compareTo(task2));
	}//If task1 == task2
	
	@Test
	public void equals1()
	{
	//Testing homework tasks
	Task task1 = new HomeworkTask(1, new GregorianCalendar(2016,11,01), "Lab","420-B31", 1, "Sandra");
	Task task2 = new HomeworkTask(1, new GregorianCalendar(2016,11,01), "Lab","420-B31", 1, "Sandra");
	assertEquals(true, task1.equals(task2));
	}//Checking equivalence
	
	@Test
	public void equals2()
	{
		Task task1 = new HomeworkTask(1, new GregorianCalendar(2016,11,01), "Lab","420-B31", 1, "Sandra");
		Task task2 = new HomeworkTask(1, new GregorianCalendar(2016,11,01), "Lab","420-B30", 1, "Sandra");
		assertEquals(false, task1.equals(task2));
	}//Testing courseNumber
	
	@Test
	public void equals3()
	{
		Task task1 = new HomeworkTask(1, new GregorianCalendar(2016,11,01), "Lab","420-B31", 1, "Sandra");
		Task task2 = new HomeworkTask(1, new GregorianCalendar(2016,11,01), "Lab","420-B31", 1, "Allan");
		assertEquals(false, task1.equals(task2));
	
	}//Testing teacherName
	
	@Test
	public void equals4()
	{
		Task task1 = new HomeworkTask(1, new GregorianCalendar(2016,11,01), "Lab","420-B31", 1, "Sandra");
		Task task2 = new HomeworkTask(1, new GregorianCalendar(2016,11,01), "Meeting","420-B31", 1, "Sandra");
		assertEquals(false, task1.equals(task2));
	
	}//Testing TaskType
	
	@Test
	public void equals5()
	{
		Task task1 = new HomeworkTask(1, new GregorianCalendar(2016,11,01), "Lab","420-B31", 1, "Sandra");
		Task task2 = new HomeworkTask(1, new GregorianCalendar(2016,11,01), "Meeting","420-B30", 1, "Allan");
		assertEquals(false, task1.equals(task2));
	}//Testing if the CourseNumber and Teacher are equivalent
	
	@Test
	public void equals6()
	{
		Task task1 = new HomeworkTask(1, new GregorianCalendar(2016,11,01), "Lab","420-B31", 1, "Sandra");
		Task task2 = new HomeworkTask(1, new GregorianCalendar(2016,11,01), "Assignment","420-B30", 1, "Sandra");
		assertEquals(false, task1.equals(task2));
	}//Testing if the CourseNumber and TaskType are the same
	@Test
	public void equals7()
	{
		Task task1 = new HomeworkTask(1, new GregorianCalendar(2016,11,01), "Lab","420-B31", 1, "Sandra");
		Task task2 = new HomeworkTask(1, new GregorianCalendar(2016,11,01), "Meeting","420-B30", 1, "Allan");
		assertEquals(false, task1.equals(task2));
	}//Testing if the teacher and tasktype are the same
	
	@Test
	public void equals8()
	{
		Task task1 = new HomeworkTask(1, new GregorianCalendar(2016,11,01), "Lab","420-B30", 1, "Sandra");
		Task task2 = new HomeworkTask(1, new GregorianCalendar(2016,11,01), "Assignment","420-B31", 1, "Allan");
		assertEquals(false, task1.equals(task2));
	}//Testing if all properties are different
	
	@Test
	public void equals9()
	{
		Task task1 = new HomeworkTask(1, new GregorianCalendar(2016,11,01), "Lab","420-B31", 1, "Sandra");
		Task task2 = new PersonalTask(1, new GregorianCalendar(2016,11,01), "Appointment", "Doctors", "Location");
		assertEquals(false, task1.equals(task2));
	}//Verify that two different objects aren't equal
	
	@Test
	public void equals10()
	{
		Task task1 = new PersonalTask(1, new GregorianCalendar(2016,11,01), "Appointment", "Doctors", "Location");
		Task task2 = new PersonalTask(1, new GregorianCalendar(2016,11,01), "Appointment", "Doctors", "Location");
		assertEquals(true, task1.equals(task2));
	}//Verify that two tasks are equal
	
	@Test
	public void equals11()
	{
		Task task1 = new PersonalTask(1, new GregorianCalendar(2016,11,01), "Other", "Doctors", "Location");
		Task task2 = new PersonalTask(1, new GregorianCalendar(2016,11,01), "Appointment", "Doctors", "Location");
		assertEquals(false, task1.equals(task2));
	}//Verify that the tasktypes are different
	
	@Test
	public void equals12()
	{
		Task task1 = new PersonalTask(1, new GregorianCalendar(2016,11,01), "Other", "Doctors", "Location");
		Task task2 = new PersonalTask(1, new GregorianCalendar(2016,11,01), "Other", "Swag", "Location");
		assertEquals(false, task1.equals(task2));
	}//Verify that the taskname is different
	
	@Test
	public void equals13()
	{
		Task task1 = new PersonalTask(1, new GregorianCalendar(2016,11,01), "Bill", "Doctors", "Location");
		Task task2 = new PersonalTask(1, new GregorianCalendar(2016,11,01), "Other", "Swag", "Location");
		assertEquals(false, task1.equals(task2));
	}//Verify that the taskname and tasktype is different
	
	

}
