/**
 * 
 */
package aha_B31_A01_Quiz;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

/**
 * @author Andrew
 *The purpose of this program is to create a console based quiz game. The game will run from questions based off a file is named quizQuestions.txt. There 
 *are Fill-In-The-Blank, single choice, multiple choice, and numeric type questions. The user will be offered to enter a name, when they complete the game their score
 *will be recorded onto a file called quizScores.txt
 */
public class QuizRunner
{

	/**
	 * @param args
	 */
	public static void main(String[] args)
	{
		//Creating an object to check for file validation
		FIBQuestion checkFileObject = new FIBQuestion();
		FileNotFoundException e = new FileNotFoundException();

		//Attempting to open quizQuestions.txt
		System.out.print("Attempting to open quizQuestions.txt ");
		try
		{
			//Verifies the file integrity
			if (checkFileObject.checkFileExists() == true)
			{
				//Will now begin to check the file question integrity
				for (int i = 0; i < 5; i++)
				{
					System.out.print(".");	//Allan said adding dots help.
//					Thread.sleep(1000);
				}
				if (checkFileObject.checkFileQuestions() != false)
				{
					System.out.println("\nAll questions validated! Starting the game.");
					//Creating an ArrayList in order to store all the objects					
					ArrayList<Question> questionObjects = new ArrayList<Question>();
					//Storing the objects
					questionObjects = checkFileObject.makeArrayList();
					System.out.println("Please enter your name: ");
					int userScore = 0;
					String userName;
					String answer;
					Scanner keyboard = new Scanner(System.in);
					userName = keyboard.nextLine();
					boolean isCorrect;
					System.out.println("\nWelcome " + userName + "!");

					for (int i = 0; i < questionObjects.size(); i++)
					{
						System.out.println("Question " + (i + 1) + ":");
						System.out.println(questionObjects.get(i).returnQuestion());
						System.out.print("Your answer: ");
						answer = keyboard.nextLine();

						isCorrect = questionObjects.get(i).checkAnswer(i, answer);
						if (isCorrect == true)
						{
							System.out.println("Correct!\n");
							userScore++;
						}
						else
							System.out.println("Incorrect!\n");
						//Uncomment if you would like to print the answers if the user got it wrong.
						//System.out.println("The correct answer was: " + questionObjects.get(i).returnAnswer());

					}
					//Calculating the average
					int average = (userScore * 100)/questionObjects.size();
					System.out.println(userName + ", your score was "+ userScore + " out of " + questionObjects.size() +
							" or " + average + "%\nGoodbye.");
					
					File scores = new File("Scores.txt");
					

				}
			}
			else
				throw e;
		}
		catch (FileNotFoundException f)
		{
			System.err.println("Attention!\nquizQuestions.txt is missing.");

		}
//		catch (InterruptedException e1)
//		{
//			System.err.println("Pause has been interrupted");
//			e1.printStackTrace();
//		}
	}
}
