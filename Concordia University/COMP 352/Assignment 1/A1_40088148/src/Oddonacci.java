import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

/**
 * 
 */

/**
 * @author Andrew
 *
 */
public class Oddonacci {

	/**
	 * @param args
	 */
	public static final String FILE_NAME = "Text Files/out.txt";
	public static int[] tailLinearOddonacciArray = {1, 1, 1};
	public static long before, after, timeElapsed;
	public static void main(String[] args) {	
	
		//Looping through multiples of 5 to 100
		for (int i = 5; i <= 101; i+= 5)
		{
			before = System.currentTimeMillis();
			int res = binaryOddonacci(i);
			after  = System.currentTimeMillis();
			timeElapsed = after - before;
			writeResult("binaryOddonacci()", i, res, timeElapsed);
		}
		
	}
	
	//Exponential Oddonacci
	/*
	 * @params n - Number to perform Oddonacci calculation up to
	 * @return result of the calculation
	 */
	public static int binaryOddonacci(int n)
	{
		if (n <= 3)
		{
			return 1;
		}
		
		return binaryOddonacci(n-1) + binaryOddonacci(n-2) + binaryOddonacci(n-3);
				
	}
	
	//Shared method to write the result to the text file
	/*
	 * @param n the amount to calculate Oddonacci up till
	 * @return array with the last 3 digits of the Oddonacci sequence being stored
	 */
	public static void writeResult(String oddonaciMethod,int oddonaciNumber, int result, long timeElapsed)
	{
		try {
			//True to append to the text file
	        BufferedWriter out = new BufferedWriter(new FileWriter(FILE_NAME, true));	            
	            out.write("Method Called: " + oddonaciMethod + "\n");
	            out.write("Oddonacci To Calculate To: " + oddonaciNumber + "\n");	
	            if (result < 0)
	            out.write("Oddonacci Result: " + result + " - Buffer Overflow, result is higher then maximum value Int can hold \n");
	            else
	            out.write("Oddonacci Result: " + result + "\n");
	            out.write("Time to compute: " + timeElapsed + "\n\n");
	            out.close();
	        } catch (IOException e) {}
	}
	
	

}
