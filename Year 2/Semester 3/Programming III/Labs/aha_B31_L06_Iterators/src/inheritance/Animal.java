package inheritance;

public abstract class Animal
{
  private String animalType;
  private char sex;

  public Animal()
  {
    animalType = "Unknown";
    sex = 'U';
  }

  public Animal(String animalType)
  {
    this.animalType = animalType;
    sex = 'U';
  }

  public Animal(String animalType, char s)
  {
    this.animalType = animalType;
    sex = s;
  }

  public abstract String speak();

  public abstract String move();

  public String getAnimalType()
  {
    return animalType;
  }

  public void setSex(char sex)
  {
    this.sex = sex;
  }

  public String getSex()
  {
    if (sex == 'M')
      return "Male";
    else if (sex == 'F')
      return "Female";
    else
      return "Unknown";
  }

  public String toString()
  {
    return getSex() + " " + getAnimalType();
  }

  public boolean equals(Object o)
  {
    return animalType.equals(((Animal) o).animalType) &&
      sex == ((Animal) o).sex;
  }
}
