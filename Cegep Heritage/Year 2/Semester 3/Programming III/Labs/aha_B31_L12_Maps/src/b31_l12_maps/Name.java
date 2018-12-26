package b31_l12_maps;

import java.io.Serializable;

public class Name implements Serializable
{
  private String firstName;
  private String lastName;

  public Name()
  {
    super();
  }

  public Name(String f, String l)
  {
    super();
    firstName = f;
    lastName = l;
  }

  public void setFirstName(String firstName)
  {
    this.firstName = firstName;
  }

  public String getFirstName()
  {
    return firstName;
  }

  public void setLastName(String lastName)
  {
    this.lastName = lastName;
  }

  public String getLastName()
  {
    return lastName;
  }

	/* (non-Javadoc)
	 * @see java.lang.Object#hashCode()
	 */
	@Override
	public int hashCode()
	{
		final int prime = 31;
		int result = 1;
		result = firstName.toLowerCase().hashCode() + lastName.toLowerCase().hashCode();
		return result;
	}

	/* (non-Javadoc)
	 * @see java.lang.Object#equals(java.lang.Object)
	 */
	@Override
	public boolean equals(Object obj)
	{
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (!(obj instanceof Name))
			return false;
		Name other = (Name) obj;
		if (firstName == null)
		{
			if (other.firstName != null)
				return false;
		}
		else
			if (!firstName.equalsIgnoreCase(other.firstName))
				return false;
		if (lastName == null)
		{
			if (other.lastName != null)
				return false;
		}
		else
			if (!lastName.equalsIgnoreCase(other.lastName))
				return false;
		return true;
	}
  
}
