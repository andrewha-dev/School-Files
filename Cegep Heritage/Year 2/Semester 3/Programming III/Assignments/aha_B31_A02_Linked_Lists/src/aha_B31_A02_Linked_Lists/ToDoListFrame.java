package aha_B31_A02_Linked_Lists;

import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.border.EmptyBorder;
import javax.swing.JMenuBar;
import javax.swing.JMenu;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;

import java.awt.event.ActionListener;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InvalidClassException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.util.Iterator;
import java.util.LinkedList;
import java.awt.event.ActionEvent;
import java.awt.ScrollPane;
import javax.swing.JTextPane;
import javax.swing.JTextArea;
import javax.swing.ScrollPaneConstants;
import java.awt.Font;
import java.awt.Color;

public class ToDoListFrame extends JFrame implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -7656815815785541438L;
	TaskList taskListObject = new TaskList();
	LinkedList<Task>taskList = new LinkedList();
	JTextArea display = new JTextArea();
	
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					ToDoListFrame frame = new ToDoListFrame();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public ToDoListFrame() {
		setTitle("Heritage College Task Manager");
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		setBounds(100, 100, 850, 540);
		
		

		
		JMenuBar menuBar = new JMenuBar();
		setJMenuBar(menuBar);
		
		JMenu fileMenuItem = new JMenu("File");
		menuBar.add(fileMenuItem);
		
		JMenuItem mntmNewMenuItem = new JMenuItem("Open File");
		mntmNewMenuItem.addActionListener(new ActionListener() {
			/*
			 * Method for loading a serialized file
			 */
			public void actionPerformed(ActionEvent arg0) {
				try {
					 String fileNameLoad = "";
					 //Prompting for the filename - the .ser extension is automatically attached
					 fileNameLoad = JOptionPane.showInputDialog("Please Enter The Serialized File Name (.ser extension is automatically added): ");
					 if (fileNameLoad != null)
						//If the user enters a file name 
					 if (!fileNameLoad.equals(""))
					 {
						 //Will try to load the file and return true or false if its able to load the file
						 if (taskListObject.readFromFile(fileNameLoad) == true);
						 {
						 JOptionPane.showMessageDialog(null, "File Loaded");
						 }
						 
						if (taskListObject.readFromFile(fileNameLoad) == false)	 
						JOptionPane.showMessageDialog(null, "Error loading file");
			         
					 }
			         
				}
				catch (NullPointerException i){
					JOptionPane.showMessageDialog(null, "Please enter a file name");
				}

				

				
			}
		});
		
		fileMenuItem.add(mntmNewMenuItem);
		/*
		 * Method for Creating a serialized file
		 */
		JMenuItem mntmWriteFile = new JMenuItem("Save File");
		mntmWriteFile.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
			try {
				//Promting the user for their filename
				String fileNameSave = null;
				fileNameSave = JOptionPane.showInputDialog("Please Enter The File Name Of Your Save (.ser is added automatically): ");
				//Running checks to see if the user has added to .ser extension
				if (fileNameSave != null)
				{
					//Will execute the saveToFile method and gets true or false as a status
				if (taskListObject.saveToFile(fileNameSave))
		         JOptionPane.showMessageDialog(null, "Data has been saved.");
				}
				else{
					JOptionPane.showMessageDialog(null, "Error saving file");
				}
			}

			catch (NullPointerException i){
				JOptionPane.showMessageDialog(null, "Please enter a file name");
			}
		}
		});
		fileMenuItem.add(mntmWriteFile);
		
		JMenu displayMenuItem = new JMenu("Display Tasks");
		menuBar.add(displayMenuItem);
		/*
		 * Method for displaying all tasks by their due date
		 */
		JMenuItem mntmDisplayAllTasks = new JMenuItem("Display All Tasks");
		mntmDisplayAllTasks.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				//Retrieves the most recent copy of all the tasks
				taskList = taskListObject.returnAllTasks();
				//Only if the tasklist has an element the method will execute
				if (taskList.size() != 0)
				{
					//Retrieving the taskList sorted by their due date
					taskList = taskListObject.getTasksByDueDate();
					display.setText("");
					display.append(String.format("%65s", "Display All Tasks By Due Date\n\n"));
					//Using a for each loop and an iterator to pring the results onto the screen
					for (Task iterer: taskList)
					{
						display.append(String.format(iterer + "\n"));
						display.append(String.format("\n\n"));
					}
					display.setCaretPosition(0);
				}
				else {
					JOptionPane.showMessageDialog(null, "There are no tasks to display.");
				}
			}
		});
		displayMenuItem.add(mntmDisplayAllTasks);
		
		JMenuItem displayByMenuItem = new JMenuItem("Display Earliest Tasks");
		/*
		 * Method for displaying all earliest tasks
		 */
		displayByMenuItem.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				//Checking to see if there are actually tasks to be displayed
				taskList = taskListObject.returnAllTasks();
				if (taskList.size() != 0)
				{
				display.setText("");
				display.append(String.format("%65s", "Display Earliest Task\n\n"));
				//Retrieving the object and displaying it using a for each loop
				taskList = taskListObject.findNextDueTasks();
				for (Task iter: taskList)
				{
					display.append(String.format(iter + "\n"));
					display.append("\n\n");
				}
				display.setCaretPosition(0);
				}
				else {
					JOptionPane.showMessageDialog(null, "There are no tasks to be displayed");
				}
				
			}
		});
		displayMenuItem.add(displayByMenuItem);
		
		/*
		 * Method for displaying all tasks by their highest priorities
		 */
		JMenuItem mntmNewMenuItem_1 = new JMenuItem("Display By Highest Priority");
		mntmNewMenuItem_1.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				taskList = taskListObject.returnAllTasks();
				//Checking to make sure that there are tasks with priority 1
				if (taskList.size() != 0 && taskListObject.getHighPriorityTasksByDueDate().size() != 0)
				{
					//Getting the taskList and displaying it by highest priorities using a for each loop
					taskList = taskListObject.getHighPriorityTasksByDueDate();
					display.setText("");
					display.append(String.format("%65s", "Sorting By Earliest Tasks\n\n"));
					for (Task iter: taskList)
					{
						
						display.append(String.format((iter.toString())));
						display.append(String.format("\n\n"));
					}
					display.setCaretPosition(0);
				}
				else {
					JOptionPane.showMessageDialog(null, "There are no tasks to display.");
				}
			}
		});
		displayMenuItem.add(mntmNewMenuItem_1);
		
		JMenu mnManageTasks = new JMenu("Manage Tasks");
		menuBar.add(mnManageTasks);
		
		JMenuItem mntmAddANewTask = new JMenuItem("Add A New Task");
		mntmAddANewTask.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				AddTask addTask = new AddTask();
				addTask.setVisible(true);
				
			}
		});
		mnManageTasks.add(mntmAddANewTask);
		/*
		 * Method for removing a task
		 */
		
		JMenuItem mntmRemoveATask = new JMenuItem("Remove A Task");
		mntmRemoveATask.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				//Getting the latest taskList
				taskList = taskListObject.returnAllTasks();
				//Checking to see if the list is empty
				if (taskList.size() != 0)
				{
					//Creating the possible options that the user can choose to remove from their list
					String tasksToRemove[] = new String[taskList.size()+1];
					Iterator<Task> iter = taskList.iterator();
					Task nextTask;
					tasksToRemove[0] = "Please select a task to remove";
					int i = 1;
					while (iter.hasNext())
					{
						
						nextTask = (Task) iter.next();
						tasksToRemove[i] = i + ". " + nextTask.returnFormattedForRemove();			
						i++;
					}
					Object selectedValue = null;
					selectedValue = JOptionPane.showInputDialog(null,    
				            "Choose one", "Input",   
				            JOptionPane.INFORMATION_MESSAGE, null,
				            tasksToRemove, tasksToRemove[0]);
					//Allowing the user to select their string value to remove and it will remove it from the taskList itself
					if (selectedValue != null)
					if (!selectedValue.equals("Please select a task to remove"))
					{
						boolean found = false;
						for (i = 0; i < tasksToRemove.length; i++)
						{
							//Finding the index of the selected task
							if (selectedValue.equals(tasksToRemove[i]))
							{
								taskList.remove(i-1);
								JOptionPane.showMessageDialog(null, "Task has been successfully removed");
							}
							
						}
					}					
					else
						JOptionPane.showMessageDialog(null, "There are no tasks to remove");
					
				}//If
				if (taskList.size() == 0)
				JOptionPane.showMessageDialog(null, "There are no tasks to remove");
			}
		});
		mnManageTasks.add(mntmRemoveATask);
		getContentPane().setLayout(null);
		display.setForeground(new Color(255, 255, 255));
		display.setBackground(new Color(0, 128, 0));
		display.setLineWrap(true);
		display.setFont(new Font("Monospaced", Font.BOLD, 13));
		display.setEditable(false);
		
		JScrollPane scrollPane = new JScrollPane(display);
		scrollPane.setHorizontalScrollBarPolicy(ScrollPaneConstants.HORIZONTAL_SCROLLBAR_NEVER);
		scrollPane.setAutoscrolls(true);
		
		scrollPane.setBounds(0, 0, 834, 481);
		getContentPane().add(scrollPane);
		
		
		
	}
}

