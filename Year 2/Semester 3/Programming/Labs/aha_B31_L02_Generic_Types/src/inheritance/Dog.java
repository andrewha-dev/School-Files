package inheritance;

public class Dog
  extends Pet
{
  public Dog()
  {
    super("Dog");
  } // Dog()

  public Dog(char sex)
  {
    super("Dog", sex);
  } // Dog(char sex)

  public Dog(char sex, String name)
  {
    super("Dog", name, sex);
  } // Dog(char sex, String name)

  public String speak()
  {
    return "Woof";
  } // speak()
} // Dog
