package inheritance;

public class TestInheritance
{

	public static void main(String[] args)
	{
		Lion lion1 = new Lion();
		Lion lion2 = new Lion('M');

		Dog dog1 = new Dog();
		Dog dog2 = new Dog('M');
		Dog dog3 = new Dog('M', "Max");

		Cat cat1 = new Cat();
		Cat cat2 = new Cat('F');
		Cat cat3 = new Cat('F', "MewTOO");

		System.out.println("Object Name: Lion1 " + "Object Type: "
				+ lion1.getAnimalType() + " " + "Sex: " + lion1.getSex());

		System.out.println("Object Name: Lion2 " + "Object Type: "
				+ lion2.getAnimalType() + " Sex: " + lion2.getSex());

		System.out
				.println("Object Name: Dog1 " + "Object Type: " + dog1.getAnimalType()
						+ " Sex: " + dog1.getSex() + " Name: " + dog1.getPetName());

		System.out
				.println("Object Name: Dog2 " + "Object Type: " + dog2.getAnimalType()
						+ " Sex: " + dog2.getSex() + " Name: " + dog2.getPetName());

		System.out
				.println("Object Name: Dog3 " + "Object Type: " + dog3.getAnimalType()
						+ " Sex: " + dog3.getSex() + " Name: " + dog3.getPetName());

		System.out
				.println("Object Name: Cat1 " + "Object Type: " + cat1.getAnimalType()
						+ " Sex: " + cat1.getSex() + " Name: " + cat1.getPetName());

		System.out
				.println("Object Name: Cat2 " + "Object Type: " + cat2.getAnimalType()
						+ " Sex: " + cat2.getSex() + " Name: " + cat2.getPetName());
		System.out
				.println("Object Name: Cat3 " + "Object Type: " + cat3.getAnimalType()
						+ " Sex: " + cat3.getSex() + " Name: " + cat3.getPetName());

		System.out.println(lion2.toString());
		System.out.println(dog3.toString());
		System.out.println(cat3.toString());

		Dog dog4 = new Dog('M', "Mix");
		if (dog4.equals(dog3))
		{
			System.out.println("Dog4 equals Dog3");
		}
		else
			System.out.println("Dog4 does not equal to Dog3");

		Dog dog5 = new Dog('M', "Mix");
		if (!dog5.equals(dog4))
		{
			System.out.println("The Names Arent the same");
		}

		if (!lion1.equals(cat3))
		{
			System.out.println("Not equal");
		}

		Lion lion3 = new Lion('M');
		Lion lion4 = new Lion('F');

		if (!lion1.equals(lion4))
			;
		{
			System.out.println("Different Sex");
		}
		if (lion3.equals(lion2))
		{
			System.out.println("Same Sex");
		}

	}

}
