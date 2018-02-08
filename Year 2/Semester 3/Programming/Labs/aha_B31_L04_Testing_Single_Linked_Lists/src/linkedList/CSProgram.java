package linkedList;

import com.sun.glass.ui.Cursor;

public class CSProgram
{
	private SinglyLinkedList<Course> CSCourses = new SinglyLinkedList<Course>();

	public CSProgram()
	{
		CSCourses.add(new Course("420-B31", "Programming III", 3, 2, 3));
		CSCourses.add(new Course("420-B10", "Programming I", 1, 3, 3));
		CSCourses.add(new Course("420-B20", "Programming II", 2, 3, 3));
		CSCourses.add(new Course("420-B40", "Programming IV", 4, 2, 2));
		CSCourses.add(new Course("420-B50", "Programming V", 5, 2, 2));
		CSCourses.add(new Course("420-A11", "Operating Systems", 1, 2, 2));
		CSCourses.add(new Course("420-A31", "Networks", 3, 3, 3));
		CSCourses.add(new Course("420-C10", "Web Programming I", 1, 2, 3));
		CSCourses.add(new Course("420-C20", "Web Programming II", 2, 2, 3));
		CSCourses.add(new Course("420-C30", "Web Programming III", 4, 2, 3));
		CSCourses.add(new Course("420-C40", "Web Programming IV", 5, 2, 3));
		CSCourses.add(new Course("420-D10", "Database I", 3, 3, 3));
		CSCourses.add(new Course("420-D20", "Database II", 4, 2, 2));
		CSCourses.add(new Course("420-E11", "Systems I", 3, 3, 3));
		CSCourses.add(new Course("420-E21", "Systems II", 4, 3, 3));
		CSCourses.add(new Course("420-E31", "Systems III", 5, 3, 2));
		CSCourses.add(new Course("420-E41", "Systems IV", 6, 1, 2));
		CSCourses.add(new Course("420-E50", "Development Project I", 5, 0, 6));
		CSCourses.add(new Course("420-E61", "Development Project II", 6, 0, 12));
		CSCourses.add(new Course("420-E71", "Maintenance Project", 6, 0, 6));
	} // CSProgram

	public SinglyLinkedList<Course> getCSCourses()
	{
		return CSCourses;
	} // getCSCourses()

	public void listCourses()
	{

		for (int i = 0; i < CSCourses.getLength(); ++i)
		{
			Course current = CSCourses.getElementAt(i);
			System.out.println("Semester: " + current.getSemester() + " Course: "
					+ current.getCourseNumber() + " - " + current.getCourseName());
		}
	} // listCourses()

	public int getHours(int _semester)
	{
		int hours = 0;

		if (_semester <= 0 || _semester > 6)
			throw new IllegalArgumentException();
		for (int x = 0; x < CSCourses.getLength(); x++)
		{
			if (CSCourses.getElementAt(x).getSemester() == _semester)
			{
				hours += CSCourses.getElementAt(x).getClassHours();
			}
		}
		return hours;
	}

	public boolean reviseProgram()
	{
		CSCourses.add(new Course("420-C50", "Web Programming V", 5, 2, 3));

		for (int i = 0; i < CSCourses.getLength(); i++)
		{
			if (CSCourses.getElementAt(i).getCourseNumber().equals("420-B50"))
			{
				CSCourses.remove(i);
				

				if (CSCourses.getElementAt(i).getCourseNumber().equals("420-B40"))
				{
					CSCourses.replace(CSCourses.getElementAt(i),
							new Course("420-B41", "Programming IV", 5, 2, 3));
					return true;
				}
			
			}
		} // for

		return false;
	}

} // CSProgram
