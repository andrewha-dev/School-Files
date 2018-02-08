package inheritance;

public class Lion extends Animal
{
  public Lion()
  {
    super("Lion");
  } // Lion()

  public Lion(char sex)
  {
    super("Lion",sex);
  } // Lion(char sex)

  public String speak()
  {
    return "Roar";
  } // speak()

  public String move()
  {
    return "Leap";
  } // move()
} // Lion class
