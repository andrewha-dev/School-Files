package linkedList;

public class Course
{
	private String courseNumber;
	private String courseName;
	private int semester;
	private int theoryHours;
	private int labHours;

	public Course()
	{
		courseNumber = "420xxx";
		courseName = "Unknown";
		semester = -1;
		theoryHours = -1;
		labHours = -1;
	} // Course

	public Course(String number, String name)
	{
		courseNumber = number;
		courseName = name;
		semester = -1;
		theoryHours = -1;
		labHours = -1;
	} // Course

	public Course(String number, String name, int sem)
	{
		courseNumber = number;
		courseName = name;
		semester = sem;
		theoryHours = -1;
		labHours = -1;
	} // Course

	public Course(String number, String name, int sem, int theory, int lab)
	{
		courseNumber = number;
		courseName = name;
		semester = sem;
		theoryHours = theory;
		labHours = lab;
	} // Course

	public void setCourseNumber(String courseNumber)
	{
		this.courseNumber = courseNumber;
	}

	public String getCourseNumber()
	{
		return courseNumber;
	}

	public void setCourseName(String courseName)
	{
		this.courseName = courseName;
	}

	public String getCourseName()
	{
		return courseName;
	}

	public void setSemester(int semester)
	{
		this.semester = semester;
	}

	public int getSemester()
	{
		return semester;
	}

	public void setTheoryHours(int theoryHours)
	{
		this.theoryHours = theoryHours;
	}

	public int getTheoryHours()
	{
		return theoryHours;
	}

	public void setLabHours(int labHours)
	{
		this.labHours = labHours;
	}

	public int getLabHours()
	{
		return labHours;
	}

	public int getClassHours()
	{
		return theoryHours + labHours;
	} // getClassHourse()
	
	public boolean equals(Object _course)
	{
		if (this.getCourseNumber().equals(((Course) _course).getCourseNumber()))
		return true;
		
		return false;
	}

}
