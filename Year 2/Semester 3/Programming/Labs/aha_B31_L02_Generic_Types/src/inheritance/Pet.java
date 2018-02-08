package inheritance;

public abstract class Pet extends Animal
{
  private String petName;

  public Pet()
  {
    super();
    petName = "Unknown";
  } // Pet()

  public Pet(String petType)
  {
    super(petType);
    petName = "Unknown";
  } // Pet(String petType)

  public Pet(String petType, char sex)
  {
    super(petType,sex);
    petName = "Unknown";
  } // Pet(String petType, char sex)

  public Pet(String petType, String name, char sex)
  {
    super(petType,sex);
    petName = name;
  } // Pet(String petType, String name, char sex)

  public void setPetName(String petName)
  {
    this.petName = petName;
  } // setPetName(String petName)

  public String getPetName()
  {
    return petName;
  } // getPetName()

  public String move()
  {
    return "Walk";
  } // move()
  
  public String toString()
  {
    return super.toString() + " called " + petName;
  } // toString()
  
  public boolean equals(Object o)
  {
  	if ((o == null) || (!(o instanceof Pet)))
		{
  		return (super.equals(o) && (((Animal) o).getAnimalType() == this.getAnimalType()));
		}
		else
			return (super.equals(o) && (((Pet) o).getPetName() == this.getPetName()));
  } // equals(Object o)
} // Pet class
