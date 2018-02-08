package aha_B31_A01_Quiz;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.StringTokenizer;

public abstract class Question
{
	//The File Name That The Game Will Try To Run Off Of
	public static final String FILENAME = "quizQuestions.txt";
	//Creating the File object
	File quizQuestions = new File(FILENAME);
	//Creating ArrayList to Store Question/Answer
	public static ArrayList<Question> questions = new ArrayList<Question>();
	//Grabs the question/answer in the text file immediately after the char
	protected String phrase;
	protected String question;
	protected String answer;

	//Constructers
	public Question()
	{
		question = "noQuestionWasSet";
		answer = "noAnswerWasSet";
	}

	public Question(String _question)
	{
		question = _question;
	}

	public Question(String _question, String _answer)
	{
		question = _question;
		answer = _answer;
	}

	//Method checks to see if the file is present or not, if the file is present and not a directory
	//it should return true
	public boolean checkFileExists()
	{
		boolean fileIsPresent = false;
		if (quizQuestions.exists() && !quizQuestions.isDirectory())
			fileIsPresent = true;

		return fileIsPresent;
	}

	/* Validates the questions in order to see if they are formatted correctly or not
	 * 
	 */
	public boolean checkFileQuestions()
	{
		boolean fileQuestionsFormatted = true;
		String inputPhrase = "";
		String blankLineCheck;
		String inputPhraseFirstLetterAndComma;
		String questionAndAnswerPhrase;

		FIBQuestion fibQuestionCheck = new FIBQuestion();
		ChoiceQuestion choiceQuestionCheck = new ChoiceQuestion();
		MultiChoiceQuestion multiChoiceQuestionCheck = new MultiChoiceQuestion();
		NumericQuestion numberQuestionCheck = new NumericQuestion();

		try
		{
			Scanner input = new Scanner(quizQuestions);
			//Checking for correct file chars
			while (input.hasNextLine())
			{
				blankLineCheck = input.nextLine();
				if (!blankLineCheck.equals(""))
				{
					inputPhrase = blankLineCheck;
					//					System.out.println(inputPhrase);
					inputPhraseFirstLetterAndComma = inputPhrase.substring(0, 2);
					if (inputPhraseFirstLetterAndComma.equals("F,")
							|| inputPhraseFirstLetterAndComma.equals("N,")
							|| inputPhraseFirstLetterAndComma.equals("S,")
							|| inputPhraseFirstLetterAndComma.equals("M,"))
					{
						//							System.out.println(inputPhrase);
						//Checking the format of each question
						questionAndAnswerPhrase = inputPhrase.substring(3,
								inputPhrase.length());
								//							System.out.println(questionAndAnswerPhrase);

						//Checking the phrase line integrity based off of the question type
						switch (inputPhraseFirstLetterAndComma)
						{
						case "F,":
							//								System.out.println("Fill in the blank");
							fileQuestionsFormatted = fibQuestionCheck
									.checkFormat(questionAndAnswerPhrase);
							if (fileQuestionsFormatted == false)
							{
								System.out.println("False returning file");
								return false;
							}
							break;
						case "N,":
							//								System.out.println("Numeric");
							fileQuestionsFormatted = numberQuestionCheck
									.checkFormat(questionAndAnswerPhrase);
							if (fileQuestionsFormatted == false)
							{
								return false;
							}
							break;
						case "S,":
							//								System.out.println("Single Choice");
							fileQuestionsFormatted = choiceQuestionCheck
									.checkFormat(questionAndAnswerPhrase);
							if (fileQuestionsFormatted == false)
							{
								return false;
							}
							break;
						case "M,":
							//								System.out.println("Multi Choice");
							fileQuestionsFormatted = multiChoiceQuestionCheck
									.checkFormat(questionAndAnswerPhrase);
							if (fileQuestionsFormatted == false)
							{
								return false;
							}
							break;
						default:
							fileQuestionsFormatted = false;

						}

					}
					else
					{
						System.err.println(inputPhrase);
						fileQuestionsFormatted = false;
					}

				}

			}

		}
		catch (FileNotFoundException e)
		{
			return false;
		}
		return fileQuestionsFormatted;
	}

	public boolean checkAnswer(int _index, String _answer)
	{
		boolean isCorrect = false;
		//Answer checking for the Fill In The Blank Questions
		if (questions.get(_index) instanceof FIBQuestion)
		{
			if (_answer.toLowerCase()
					.equals(questions.get(_index).returnAnswer().toLowerCase()))
				isCorrect = true;
		}
		//Answer checking for the Numeric Question 
		if (questions.get(_index) instanceof NumericQuestion)
		{
			try
			{
				double questionNumericAnswer = Double.parseDouble(questions.get(_index).returnAnswer());
				double userNumericAnswer = Double.parseDouble(_answer);
				double max, min;
				max = questionNumericAnswer + 0.01;
				min = questionNumericAnswer - 0.01;
				
				if (min <= userNumericAnswer && userNumericAnswer <= max)
				{
					isCorrect = true;
				}

			}
			
			
			
			
			catch (NumberFormatException e)
			{
				isCorrect = false;
			}
		}
		//Answer checking for the Choice Question
		if (questions.get(_index) instanceof ChoiceQuestion
				&& !(questions.get(_index) instanceof MultiChoiceQuestion))
		{
			String userAnswer = _answer;
			if (userAnswer.trim().equals(questions.get(_index).returnAnswer()))
			{
				isCorrect = true;
			}

		}
		//Answer checking for the MultiChoice Question
		if (questions.get(_index) instanceof MultiChoiceQuestion)
		{
			String userAnswer = _answer;
			String questionAnswer = questions.get(_index).returnAnswer();
			ArrayList<Integer> userAnswerSort = new ArrayList<Integer>();
			String userAnswerReorganized = "";
			StringTokenizer userAnswerQuery = new StringTokenizer(userAnswer, ",");

			//Reorganizing the Question's Answers to make comparing easier
			try
			{
				//Parsing all the user's numbers and the answer's numbers using a StringTokenizer
				//And putting them all into their own ArrayLists to be sorted.
				for (int x = 0; userAnswerQuery.hasMoreTokens(); x++)
				{
					if (userAnswerQuery.hasMoreElements())
					{
						userAnswerSort
								.add(Integer.parseInt(userAnswerQuery.nextToken().trim()));
					}
				}
				//Sorting the userAnswerSortArray
				for (int x = 0; x < userAnswerSort.size() - 1; x++)
					for (int y = 1; y < userAnswerSort.size(); y++)
					{
						//Sorting by lowest values to highest
						if (userAnswerSort.get(y - 1) > userAnswerSort.get(y))
						{

							int _temp = userAnswerSort.get(y - 1);
							userAnswerSort.set(y - 1, userAnswerSort.get(y));
							userAnswerSort.set(y, _temp);
						}
					}

				//Taking the sorted numbers and turning it into a string to compare the answer
				int commaAdder = 0;
				for (int x = 0; x < userAnswerSort.size(); x++)
				{
					if (commaAdder > 0)
						userAnswerReorganized = userAnswerReorganized.concat(",");

					userAnswerReorganized = userAnswerReorganized
							.concat(userAnswerSort.get(x).toString());
					commaAdder++;
				}
				System.out.println(userAnswerReorganized);
				//Comparing the final string values
				if (userAnswerReorganized.equals(questionAnswer))
					isCorrect = true;
			}

			catch (NumberFormatException e)
			{
				isCorrect = false;
			}
		}
		return isCorrect;
	}

	public ArrayList<Question> makeArrayList()
	{
		try
		{
			Scanner input = new Scanner(quizQuestions);
			while (input.hasNextLine())
			{
				phrase = input.nextLine();
				if (!phrase.equals(""))
				{

					String letterAndComma = phrase.substring(0, 2);
					phrase = phrase.substring(3, phrase.length());
					//Based off the letter, we will create different objects 
					switch (letterAndComma)
					{
					case "F,":
						questions.add(new FIBQuestion(phrase, phrase));
						break;
					case "N,":
						questions.add(new NumericQuestion(phrase, phrase));
						break;
					case "S,":
						questions.add(new ChoiceQuestion(phrase, phrase));
						break;
					case "M,":
						questions.add(new MultiChoiceQuestion(phrase, phrase));
						break;
					default:
						System.err.println("File validation failed");
					}

				}
			}
		}
		catch (FileNotFoundException e)
		{
			e.printStackTrace();
			System.out.println("Error loading file");
		}
		catch (StringIndexOutOfBoundsException e)
		{
			e.printStackTrace();
		}

		return questions;
	}

	public abstract boolean checkFormat(String _phrase);

	public abstract String formatQuestion(String _phrase);

	public abstract String formatAnswer(String _phrase);

	public String returnQuestion()
	{
		return question;
	}

	public String returnAnswer()
	{
		return answer;
	}

}
