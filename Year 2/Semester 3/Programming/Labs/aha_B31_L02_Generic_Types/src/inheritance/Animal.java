package inheritance;

public abstract class Animal
{
  private String animalType;
  private char sex;

  public Animal()
  {
    animalType = "Unknown";
    sex = 'U';
  } // Animal()

  public Animal(String animalType)
  {
    this.animalType = animalType;
    sex = 'U';
  } // Animal(String animalType)

  public Animal(String animalType, char s)
  {
    this.animalType = animalType;
    sex = s;
  } // Animal(String animalType, char s)

  public abstract String speak();

  public abstract String move();

  public String getAnimalType()
  {
    return animalType;
  } // getAnimalType()

  public void setSex(char sex)
  {
    this.sex = sex;
  } // setSex(char sex)

  public String getSex()
  {
    if (sex == 'M')
      return "Male";
    else if (sex == 'F')
      return "Female";
    else
      return "Unknown";
  } // String getSex()

  public String toString()
  {
    return getSex() + " " + getAnimalType();
  } // toString()

  public boolean equals(Object o)
  {
    return animalType.equals(((Animal) o).animalType) &&
      sex == ((Animal) o).sex;
  } // boolean equals(Object o)
} // Animal class
