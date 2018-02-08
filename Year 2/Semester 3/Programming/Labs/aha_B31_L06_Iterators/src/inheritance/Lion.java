package inheritance;

public class Lion extends Animal
{
  public Lion()
  {
    super("Lion");
  }

  public Lion(char sex)
  {
    super("Lion",sex);
  }

  public String speak()
  {
    return "Roar";
  }

  public String move()
  {
    return "Leap";
  }

}
