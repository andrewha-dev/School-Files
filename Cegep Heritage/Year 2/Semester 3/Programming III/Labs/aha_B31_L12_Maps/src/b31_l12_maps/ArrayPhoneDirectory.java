package b31_l12_maps;

import java.io.File;

import java.io.FileNotFoundException;

import java.io.FileWriter;

import java.io.IOException;
import java.io.Serializable;
import java.util.Scanner;

public class ArrayPhoneDirectory
  implements PhoneDirectory,Serializable
{
  private static final int MAX_DIRECTORY_SIZE = 20;
  private Name name[];
  private String phoneNumber[];
  private int directorySize;
  private String filename;

  public ArrayPhoneDirectory()
  {
    super();
    filename="phoneDirectory.txt";
    name = new Name[MAX_DIRECTORY_SIZE];
    phoneNumber = new String[MAX_DIRECTORY_SIZE];
    directorySize = 0;
    loadData();
  }

  public void loadData()
  {
    Scanner reader;
    try
    {
      reader = new Scanner(new File(filename));
      reader.useDelimiter("[\"~\",\"\n\"]");
      while (reader.hasNext())
      {
        String first = reader.next();
        String last = reader.next();
        String phone = reader.next();
        addEntry(first, last, phone);
      }
    }
    catch (FileNotFoundException e)
    {

    }
  }

  public String lookupEntry(String first, String last)
  {
  	Name toSearch = new Name(first, last);
  	String toReturn = "";
      toReturn = lookupEntry(toSearch);
      if (toReturn != null)
      	return toReturn;     
      	
    return null;
  }
  
  public String lookupEntry(Name _obj)
  {
    for (int i = 0; i < directorySize; ++i)
      if (name[i].equals(_obj))
        return phoneNumber[i];
    return null;
  }

  public boolean addEntry(String first, String last, String number)
  {
    if (lookupEntry(first, last) == null)
    {
      name[directorySize] = new Name(first, last);
      phoneNumber[directorySize] = number;
      ++directorySize;
      return true;
    }
    return false;
  }

  public String changeEntry(String first, String last, String number)
  {
    String oldPhone = lookupEntry(first, last);
    if (oldPhone != null)
    {
      for (int i = 0; i < directorySize; ++i)
        if (name[i].equals(new Name(first, last)))
          phoneNumber[i] = number;
    }
    return oldPhone;
  }

  public String removeEntry(String first, String last)
  {
    int deletedIndex = -1;
    String deletedPhone = null;
    for (int i = 0; i < directorySize; ++i)
      if (name[i].equals(new Name(first, last)))
      {
        deletedIndex = i;
        deletedPhone = phoneNumber[i];
        break;
      }
    if (deletedIndex != -1)
    {
      for (int i = deletedIndex; i < directorySize - 1; ++i)
      {
        name[i] = name[i + 1];
        phoneNumber[i] = phoneNumber[i + 1];
      }
      --directorySize;
    }
    return deletedPhone;
  }

  public void save()
  {
    FileWriter writer;

    try
    {
      writer = new FileWriter(filename);

      for (int i = 0; i < directorySize; ++i)
      {
        writer.write(name[i].getFirstName() + "~" + name[i].getLastName() +
                     "~" + phoneNumber[i] + "\n");
      }
      writer.close();
    }
    catch (IOException e)
    {

    }
  }
} // PhoneDirectory class
