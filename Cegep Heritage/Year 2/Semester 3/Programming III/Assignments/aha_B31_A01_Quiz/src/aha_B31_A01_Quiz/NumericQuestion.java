/**
 * 
 */
package aha_B31_A01_Quiz;

import java.util.StringTokenizer;

/**
 * @author Andrew
 *
 */
public class NumericQuestion extends Question
{

	/**
	 * 
	 */
	public NumericQuestion()
	{
		super();
	}

	public NumericQuestion(String _question)
	{
		super();
		question = _question;
	}

	public NumericQuestion(String _question, String _answer)
	{
		super();
		question = formatQuestion(_question);
		answer = formatAnswer(_answer);
	}

	@Override
	public boolean checkFormat(String _phrase)
	{
		String[] question = new String[1];
		boolean formatted = true;
		phrase = _phrase;
		int commaCountAllowed = 1;
		int commaCount = 0;
		StringTokenizer str = new StringTokenizer(phrase, ",");
		commaCount = str.countTokens() - 1;

		//Checks to make sure that there is only 1 comma allowed
		if (commaCount != commaCountAllowed)
		{
			formatted = false;
		}
		else
		{
			question = phrase.split(",");
			try
			{
				//Checks to see if the answer/number can be parsed
				Double.parseDouble(question[1]);
			}
			catch (Exception e)
			{
				formatted = false;
				System.err.println(question[1]);
			}
		}
		//Checking to see if the question is null
		if (question[0] == null)
		{
			formatted = false;
			System.out.println(question[0]);
		}
		//Checking to see if the question is just whitespace 
		if (question[0] != null)
		{
			question[0] = question[0].replace(" ", "");
			if (question[0].isEmpty())
			{
				formatted = false;
			}
		}
		return formatted;
	}

	public String formatQuestion(String _phrase)
	{
		String formattedQuestion = _phrase;
		StringTokenizer str = new StringTokenizer(formattedQuestion, ",");
		formattedQuestion = str.nextToken();
		formattedQuestion = formattedQuestion.concat("\n");

		return formattedQuestion;
	}

	public String formatAnswer(String _phrase)
	{
		String formattedAnswer = _phrase;
		StringTokenizer str = new StringTokenizer(formattedAnswer, ",");
		str.nextToken();
		formattedAnswer = str.nextToken().trim();
		return formattedAnswer;
	}

}
