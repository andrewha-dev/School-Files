package inheritance;

public class Cat extends Pet
{
  public Cat()
  {
    super("Cat");
  } // Cat()

  public Cat(char sex)
  {
    super("Cat",sex);
  } // Cat(char sex)

  public Cat(char sex, String name)
  {
    super("Cat",name,sex);
  } // Cat(char sex, String name)

  public String speak()
  {
    return "Meow";
  } // speak()

  public String move()
  {
    return "Pounce";
  } // move()
} // Cat class
