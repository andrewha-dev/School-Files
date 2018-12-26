package inheritance;

public abstract class Pet extends Animal
{
  private String petName;

  public Pet()
  {
    super();
    petName = "Unknown";
  }

  public Pet(String petType)
  {
    super(petType);
    petName = "Unknown";
  }

  public Pet(String petType, char sex)
  {
    super(petType,sex);
    petName = "Unknown";
  }

  public Pet(String petType, String name, char sex)
  {
    super(petType,sex);
    petName = name;
  }

  public void setPetName(String petName)
  {
    this.petName = petName;
  }

  public String getPetName()
  {
    return petName;
  }

  public String move()
  {
    return "Walk";
  }
  
  public String toString()
  {
    return super.toString() + " called " + petName;
  }
  
  public boolean equals(Object o)
  {
    Pet p = (Pet)o;
    return p.petName.equals(this.petName) && super.equals(p);
  }
}
