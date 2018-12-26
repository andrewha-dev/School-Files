package inheritance;

public class Cat extends Pet
{
  public Cat()
  {
    super("Cat");
  }

  public Cat(char sex)
  {
    super("Cat",sex);
  }

  public Cat(char sex, String name)
  {
    super("Cat",name,sex);
  }

  public String speak()
  {
    return "Meow";
  }

  public String move()
  {
    return "Pounce";
  }
}
