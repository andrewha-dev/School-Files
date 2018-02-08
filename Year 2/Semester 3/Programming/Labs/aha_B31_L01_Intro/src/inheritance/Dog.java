package inheritance;

public class Dog extends Pet
{
	public Dog()
	{
		super("Dog");
	}

	public Dog(char sex)
	{
		super("Dog", sex);
	}

	public Dog(char sex, String name)
	{
		super("Dog", name, sex);
	}

	public String speak()
	{
		return "Woof";
	}

	public String move()
	{
		return "Walk";
	}
}
