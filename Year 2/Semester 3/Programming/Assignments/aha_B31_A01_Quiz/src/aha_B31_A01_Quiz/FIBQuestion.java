/**
 * 
 */
package aha_B31_A01_Quiz;

/**
 * @author Andrew
 *
 */
public class FIBQuestion extends Question
{

	/**
	 * 
	 */
	public FIBQuestion()
	{
		super();
	}

	public FIBQuestion(String _question)
	{
		super();
		question = formatQuestion(_question);
	}

	public FIBQuestion(String _question, String _answer)
	{
		super();
		question = formatQuestion(_question);
		answer = formatAnswer(_answer);
	}

	@Override
	public boolean checkFormat(String _phrase)
	{
		//Checks To See If There Are Only 2 Underscores
		boolean fillInBlankFormat = true;
		phrase = _phrase;
		int underscoreAllowed = 2;
		int underScoreCount = 0;
		for (int x = 0; x < phrase.length(); x++)
		{
			if (phrase.charAt(x) == '_')
				underScoreCount++;
		}
		if (underScoreCount != underscoreAllowed)
		{
			fillInBlankFormat = false;
		}

		//Checking to see if there is a question actually being asked
		String answer = phrase.substring(phrase.indexOf("_"),
				phrase.lastIndexOf("_") + 1);
		String question = phrase.replace(answer, "");
		question = question.replace(" ", "");
		if (question.isEmpty() || question.equals(""))
		{
			fillInBlankFormat = false;
		}
		return fillInBlankFormat;
	}

	//Formats the question for the fill in the blank
	public String formatQuestion(String _phrase)
	{
		String formattedQuestion = _phrase;
		String answerSubstring;
		int firstUnderscore = _phrase.indexOf("_");
		int secondUnderscore = _phrase.lastIndexOf("_");
		answerSubstring = _phrase.substring(firstUnderscore, secondUnderscore);
		formattedQuestion = _phrase.replace(answerSubstring, "___");
		formattedQuestion = formattedQuestion.concat("\n");
		return formattedQuestion;
	}

	//Formats the fill in the blank answer
	public String formatAnswer(String _phrase)
	{
		String answerSubstring;
		int firstUnderScore = _phrase.indexOf("_") + 1;
		int secondUnderScore = _phrase.lastIndexOf("_");
		answerSubstring = _phrase.substring(firstUnderScore, secondUnderScore);
		return answerSubstring;
	}
}
