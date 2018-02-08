package b31_l12_maps;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.util.HashMap;
import java.util.Scanner;

public class MapPhoneDirectory implements PhoneDirectory, Serializable
{
	private HashMap<Name, String> myMap = new HashMap<Name, String>();
	String filename = "";
	
	public MapPhoneDirectory()
  {
    super();
    filename="phoneDirectory.txt";
    myMap = new HashMap<Name, String>();
    loadData();
  }
	
	@Override
	public void loadData()
	{
		try {
      FileInputStream fileIn = new FileInputStream("phoneDirectory.ser");
      ObjectInputStream in = new ObjectInputStream(fileIn);
      MapPhoneDirectory e = (MapPhoneDirectory) in.readObject();
      this.myMap = e.myMap;
      in.close();
      fileIn.close();
   }catch(IOException i) {
      i.printStackTrace();
      return;
   }catch(ClassNotFoundException c) {
      System.out.println("Employee class not found");
      c.printStackTrace();
      return;
   }

	}

	@Override
	public String lookupEntry(String first, String last)
	{
		String phone = null;
		Name theName = new Name(first, last);
		phone = myMap.get(theName);
		if (phone != null)
			return phone;
		return null;
	}

	@Override
	public boolean addEntry(String first, String last, String number)
	{
		// TODO Auto-generated method stub
		Name theName = new Name(first, last);
		if(!myMap.containsKey(theName))
		myMap.put(theName, number);
		return false;
	}

	@Override
	public String changeEntry(String first, String last, String number)
	{
		String oldPhone = lookupEntry(first, last);
    if (oldPhone != null)
    {
      if (myMap.containsKey(new Name(first, last)))
      	myMap.put(new Name(first, last), number);
    }
    return oldPhone;
	}

	@Override
	public String removeEntry(String first, String last)
	{
		String deletePhone = myMap.get(new Name(first, last)); 
		if (myMap.containsKey(new Name(first, last)))
			myMap.remove(new Name(first, last));
		return deletePhone;
	}

	@Override
	public void save()
	{
		try {			
      FileOutputStream fileOut =
      new FileOutputStream("phoneDirectory.ser");
      ObjectOutputStream out = new ObjectOutputStream(fileOut);
      out.writeObject(this);
      out.close();
      fileOut.close();
      System.out.printf("Serialized data is saved in phoneDirectory.ser");
   }catch(IOException i) {
      i.printStackTrace();
   }

	}

}
