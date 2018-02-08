package aha_B31_A01_Quiz;

import java.util.StringTokenizer;

/**
 * @author Andrew
 *
 */
public class MultiChoiceQuestion extends ChoiceQuestion
{

	public MultiChoiceQuestion()
	{
		super();
	}

	public MultiChoiceQuestion(String _question)
	{
		super();
		question = formatQuestion(_question);
	}

	public MultiChoiceQuestion(String _question, String _answer)
	{
		super();
		//Inherits from the formatQuestion method from choiceQuestion
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
					break;
				default:
					return false;
				}

			}
			//Checks to make sure that there is an equal amount of correct/incorrect
			if (answerCounter != pairsOfQuestionsAnswers)
				return false;
		}
		//If any integer parsing errors were to happen
		catch (NumberFormatException e)
		{
			return false;
		}

		return choiceQuestionFormat;
	}

}
