/**
 * 
 */
package aha_B31_A01_Quiz;

import java.util.ArrayList;
import java.util.StringTokenizer;

/**
 * @author Andrew
 *
 */
public class ChoiceQuestion extends Question
{

	/**
	 * 
	 */
	public ChoiceQuestion()
	{
		super();
	}

	public ChoiceQuestion(String _question)
	{
		super();
		question = formatQuestion(_question);
	}

	public ChoiceQuestion(String _question, String _answer)
	{
		super();
		question = formatQuestion(_question);
		answer = formatAnswer(_answer);
	}

	public boolean checkFormat(String _phrase)
	{
		boolean choiceQuestionFormat = true;
		int pairsOfQuestionsAnswers;
		phrase = _phrase;

		//Validating to make sure that there are an equal amount of questions and answers
		StringTokenizer str = new StringTokenizer(phrase, ",");
		str.nextToken(); //Skipping the phrase DO NOT UNCOMMENT

		//Making sure that the token after the phrase is an integer
		try
		{
			pairsOfQuestionsAnswers = Integer.parseInt(str.nextToken().trim());
			//Checking to see if the amount of pairs match the amount that was stated
			if (str.countTokens() % 2 != 0)
				return false; //Means that there are an uneven amount of pairs

			//Loop to check if there are proper answers in the file
			int answerCounter = 0;
			int correctAnswerCounter = 0;
			String answerSyntax;
			while (str.hasMoreTokens())
			{
				str.nextToken();
				answerSyntax = str.nextToken().trim();
				switch (answerSyntax)
				{
				case "incorrect":
					answerCounter++;
					break;
				case "correct":
					answerCounter++;
					correctAnswerCounter++;
					break;
				default:
					return false;
				}

			}
			//Checks to make sure that there is an equal amount of correct/incorrect
			if (answerCounter != pairsOfQuestionsAnswers)
				return false;
			//Makes sure that only one correct answer is allowed
			if (correctAnswerCounter != 1)
				return false;

		}
		//If any integer parsing errors were to happen
		catch (NumberFormatException e)
		{
			return false;
		}

		return choiceQuestionFormat;
	}

	public String formatQuestion(String _phrase)
	{
		String phrase = _phrase;
		String formattedQuestion = "";
		StringTokenizer str = new StringTokenizer(phrase, ",");
		formattedQuestion = formattedQuestion.concat(str.nextToken() + "\n");
		int counter = 0;
		int allowedPairs = Integer.parseInt(str.nextToken().trim());
		//Formats the questions
		for (int x = 0; x < allowedPairs; x++)
		{
			formattedQuestion = formattedQuestion
					.concat(x + 1 + "." + str.nextToken() + "\n");
			str.nextToken();
		}
		return formattedQuestion;
	}

	public String formatAnswer(String _phrase)
	{
		String phrase = _phrase;
		String formattedAnswer = "";
		StringTokenizer str = new StringTokenizer(phrase, ",");
		//Skipping to the answers
		str.nextToken();
		int allowedPairs = Integer.parseInt(str.nextToken().trim());
		int amountCorrect = 0;
		//Storing the answers into an ArrayList
		ArrayList<Integer> answers = new ArrayList<Integer>();
		for (int x = 1; str.hasMoreTokens(); x++)
		{
			//Skipping the possible choices
			str.nextToken();
			if (str.nextToken().trim().equals("correct"))
			{
				answers.add(x);
			}
		}
		
		
		for (int x = 0; x < answers.size(); x++)
		{
			//Skipping the possible choices
			{
				//Taking the ArrayList and turning it into a String
				if (amountCorrect > 0)
					formattedAnswer = formattedAnswer.concat(",");

				formattedAnswer = formattedAnswer.concat(Integer.toString(answers.get(x)));
				amountCorrect++;
			}
		}
		return formattedAnswer;
	}

}
