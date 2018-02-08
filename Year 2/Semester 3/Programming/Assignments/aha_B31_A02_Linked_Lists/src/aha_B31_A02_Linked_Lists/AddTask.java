package aha_B31_A02_Linked_Lists;

import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JComboBox;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.DefaultComboBoxModel;
import javax.swing.JTextField;
import javax.swing.JRadioButton;
import javax.swing.SwingConstants;
import javax.swing.ButtonGroup;
import javax.swing.ButtonModel;
import javax.swing.JTextPane;
import javax.swing.JTextArea;
import javax.swing.JScrollPane;
import java.awt.Label;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.GregorianCalendar;
import java.util.LinkedList;

public class AddTask extends JFrame {

	/**
	 * 
	 */
	private static final long serialVersionUID = 240764783251006169L;
	private JPanel contentPane;
	private JTextField txtDate;
	private final ButtonGroup buttonGroup = new ButtonGroup();
	private JTextField taskNumber;
	private JTextField teacherName;
	private JTextField taskName;
	private JTextField location;
	public TaskList taskList = new TaskList();
	private JTextField courseNumber;
	public ToDoListFrame updateListObject = new ToDoListFrame();
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					AddTask frame = new AddTask();
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
	public AddTask() {
		setTitle("Add A Task");
		setDefaultCloseOperation(DISPOSE_ON_CLOSE);
		setBounds(100, 100, 620, 574);
		contentPane = new JPanel();
		contentPane.setToolTipText("");
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		JComboBox<String> taskType = new JComboBox();
		JComboBox prioritySelect = new JComboBox();
		prioritySelect.setModel(new DefaultComboBoxModel(new String[] {"", "Priority - 1", "Priority - 2", "Priority - 3", "Priority - 4"}));
		prioritySelect.setBounds(249, 11, 192, 20);
		contentPane.add(prioritySelect);
		JTextArea taskDescription = new JTextArea();
		JLabel lblPriorityLabel = new JLabel("Task Priority:");
		lblPriorityLabel.setBounds(106, 14, 101, 14);
		contentPane.add(lblPriorityLabel);
		
		JLabel lblTaskDueDate = new JLabel("Task Due Date (MM/DD/YYYY):");
		lblTaskDueDate.setBounds(26, 45, 213, 14);
		contentPane.add(lblTaskDueDate);
		
		txtDate = new JTextField();
		txtDate.setToolTipText("Day");
		txtDate.setBounds(249, 42, 192, 20);
		contentPane.add(txtDate);
		txtDate.setColumns(10);
		
		JRadioButton rdbtnPersonalTask = new JRadioButton("Personal Task");
		rdbtnPersonalTask.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				//Setting the task types
				
				//Removing All the homework tasks
				taskType.removeAllItems();
				//Adding the personal tasks
				taskType.addItem("");
				taskType.addItem("Appointment");
				taskType.addItem("Bill");
				taskType.addItem("Payment");
				taskType.addItem("Errand");
				taskType.addItem("Other");
				//Enabling the fields for a homework task
				taskNumber.setEditable(false);
				teacherName.setEditable(false);
				taskDescription.setEditable(false);
				courseNumber.setEditable(false);
				
				//Enabling the fields for a personal task
				taskName.setEditable(true);
				location.setEditable(true);
			}
		});
		buttonGroup.add(rdbtnPersonalTask);
		rdbtnPersonalTask.setBounds(409, 80, 140, 23);
		contentPane.add(rdbtnPersonalTask);
		
		
		JRadioButton rdbtnHomeworkTask = new JRadioButton("Homework Task");
		rdbtnHomeworkTask.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				//Setting the task type
				
				//Removing The Personal Task Options
				taskType.removeAllItems();
				//Adding a Blank Entry
				taskType.addItem("");
				taskType.addItem("Lab");
				taskType.addItem("Assignment");
				taskType.addItem("Test");
				taskType.addItem("Reading");
				taskType.addItem("Essay");
				taskType.addItem("Other");
				
				//Enabling the fields for a homework task
				taskNumber.setEditable(true);
				teacherName.setEditable(true);
				taskDescription.setEditable(true);
				courseNumber.setEditable(true);
				
				//Disabling the fields for a personal task
				taskName.setEditable(false);
				location.setEditable(false);
				
			}
		});
		buttonGroup.add(rdbtnHomeworkTask);
		rdbtnHomeworkTask.setBounds(26, 80, 130, 23);
		contentPane.add(rdbtnHomeworkTask);
		
		JLabel lblTaskType = new JLabel("Task Type:");
		lblTaskType.setBounds(106, 129, 61, 14);
		contentPane.add(lblTaskType);
		
		
		taskType.setBounds(249, 126, 192, 20);
		contentPane.add(taskType);
		
		JLabel lblTaskNumber = new JLabel("Task Number:");
		lblTaskNumber.setBounds(26, 219, 79, 14);
		contentPane.add(lblTaskNumber);
		
		taskNumber = new JTextField();
		taskNumber.setEditable(false);
		taskNumber.setBounds(121, 216, 150, 20);
		contentPane.add(taskNumber);
		taskNumber.setColumns(10);
		
		JLabel lblTeacherName = new JLabel("   Teacher Name:");
		lblTeacherName.setBounds(12, 256, 107, 14);
		contentPane.add(lblTeacherName);
		
		teacherName = new JTextField();
		teacherName.setEditable(false);
		teacherName.setBounds(121, 253, 150, 20);
		contentPane.add(teacherName);
		teacherName.setColumns(10);
		
		JLabel lblTaskDescription = new JLabel("Task Description:");
		lblTaskDescription.setBounds(12, 298, 107, 14);
		contentPane.add(lblTaskDescription);
		
		JScrollPane scrollPane = new JScrollPane();
		scrollPane.setBounds(121, 298, 150, 84);
		contentPane.add(scrollPane);
		scrollPane.setViewportView(taskDescription);
		
		
		taskDescription.setEditable(false);
		taskDescription.setLineWrap(true);
		
		JLabel lblNewLabel = new JLabel("Task Name:");
		lblNewLabel.setBounds(320, 179, 79, 14);
		contentPane.add(lblNewLabel);
		
		taskName = new JTextField();
		taskName.setEditable(false);
		taskName.setBounds(409, 176, 150, 20);
		contentPane.add(taskName);
		taskName.setColumns(10);
		
		JLabel lblNewLabel_1 = new JLabel("    Location:");
		lblNewLabel_1.setBounds(320, 219, 79, 14);
		contentPane.add(lblNewLabel_1);
		
		location = new JTextField();
		location.setEditable(false);
		location.setBounds(409, 216, 150, 20);
		contentPane.add(location);
		location.setColumns(10);
		
		JButton btnAddTask = new JButton("Add Task");
		btnAddTask.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
			boolean isValid = true;
			//Validating field parameters
			if (prioritySelect.getSelectedIndex() == 0)
				isValid = false;
			//Validating the date
			String enteredDate = txtDate.getText();
			//Using the SimpleDateFormatter to validate the date
			SimpleDateFormat formatter = new SimpleDateFormat("MM/dd/yyyy");
			formatter.setLenient(false);
			//Validating the date
			try {
				formatter.parse(enteredDate);
			}
			catch (ParseException er) {
				isValid = false;
			}
			
			if (rdbtnHomeworkTask.isSelected() == false && rdbtnPersonalTask.isSelected() == false)
				isValid = false;
			
			//If a homework task is selected
			if (rdbtnHomeworkTask.isSelected())
			{
				if (taskType.getSelectedIndex() == 0)
					isValid = false;
				//Parsing the task number to see if it is actually a number
				try {
					Integer.parseInt(taskNumber.getText());
				}
				catch (NumberFormatException err)
				{
					isValid = false;
				}
				if (teacherName.getText().equals(""))
				{
					isValid = false;
				}
				if (courseNumber.getText().equals(""))
					isValid = false;
				
			}
			//If a personal task is selected
			if (rdbtnPersonalTask.isSelected())
			{
				if (taskType.getSelectedIndex() == 0)
					isValid = false;
				if (taskName.getText().equals(""))
					isValid = false;		
			}
			//If there the fields are successfully validated
			if (isValid == true)
			{
				//Getting the priority of the task
				int priority = prioritySelect.getSelectedIndex();
				
				//Getting the date
				String dateFromField = txtDate.getText();
				String[] date = dateFromField.split("/");
				//Turning the String into an array and make a date object
				GregorianCalendar dateForTask = new GregorianCalendar(Integer.parseInt(date[2]), Integer.parseInt(date[0])-1, Integer.parseInt(date[1]));
				
				//Getting the taskType
				String taskTypeSelected = (String) taskType.getSelectedItem();
				
				if (rdbtnHomeworkTask.isSelected())
				{
					//Generate a new Homework task
										
					//Getting the course number
					String courseNumberEntered = courseNumber.getText();
					
					//Getting the taskNumber
					int taskNumberEntered = Integer.parseInt(taskNumber.getText());
					
					//Getting the teacher name
					String teacherNameEntered = teacherName.getText();
					
					//Getting the taskDescription
					String taskDescriptionEntered = taskDescription.getText();
					
					HomeworkTask homeworkTask = new HomeworkTask(priority, dateForTask, taskTypeSelected,courseNumberEntered,taskNumberEntered,teacherNameEntered,taskDescriptionEntered);
					
					taskList.addTask(homeworkTask);
					JOptionPane.showMessageDialog(null, "Your Homework Task Has Been Added");

					
				}
				if (rdbtnPersonalTask.isSelected())
				{
					//Generating a new personalTask object
					//Getting the taskName entered
					String taskNameEntered = taskName.getText();
					//Getting the optional location entered
					String locationEntered = location.getText();
					
					PersonalTask personalTask = new PersonalTask(priority, dateForTask, taskTypeSelected, taskNameEntered, locationEntered);
					taskList.addTask(personalTask);
					JOptionPane.showMessageDialog(null, "Your Personal Task Has Been Added");
				}
			}
			}
			
		});
		btnAddTask.setBounds(150, 453, 121, 23);
		contentPane.add(btnAddTask);
		
		JButton btnClear = new JButton("Clear ");
		btnClear.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				//Clearing all the fields
				prioritySelect.getModel().setSelectedItem("");
				
				txtDate.setText("");
				//Setting the radio buttons to unselected
				buttonGroup.clearSelection();
				//Removing the task type
				taskType.removeAllItems();
				taskType.addItem("");
				courseNumber.setText("");
				courseNumber.setEditable(false);
				taskNumber.setText("");
				taskNumber.setEditable(false);
				teacherName.setText("");
				teacherName.setEditable(false);				
				taskDescription.setText("");
				taskDescription.setEditable(false);
				taskName.setText("");
				taskName.setEditable(false);
				location.setText("");
				location.setEditable(false);
				
				
				
			}
		});
		btnClear.setBounds(320, 453, 121, 23);
		contentPane.add(btnClear);
		
		JLabel lblcourseNumber = new JLabel("Course Number:");
		lblcourseNumber.setBounds(12, 179, 93, 14);
		contentPane.add(lblcourseNumber);
		
		courseNumber = new JTextField();
		courseNumber.setEditable(false);
		courseNumber.setBounds(121, 176, 150, 20);
		contentPane.add(courseNumber);
		courseNumber.setColumns(10);
	}
}
