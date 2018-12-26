import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
/**
 * @author Andrew
 *
 */
public class OddonacciLinear {
	public static final String FILE_NAME = "Text Files/out.txt";
	public static int[] tailLinearOddonacciArray = {1, 1, 1};
	public static long before, after, timeElapsed;
	/**
	 * @param args
	 */
	public static void main(String[] args) {		
		
		for (int i = 5; i <= 101; i+= 5)
		{
			before = System.currentTimeMillis();
			int[] res = linearOddonacci(i);
			after  = System.currentTimeMillis();
			timeElapsed = after - before;
			writeResult("linearOddonnaci()", i, res[2], timeElapsed);
		}
		
		//Looping through multiples of 5
		for (int j = 5; j <= 101; j+= 5)
		{
			//Resetting the global array
			tailLinearOddonacciArray = new int[]{1, 1, 1};
			before = System.currentTimeMillis();
			int[] result = tailLinearOddonacci(j);
			after  = System.currentTimeMillis();
			timeElapsed = after - before;
			writeResult("tailLinearOddonacci()", j, result[2], timeElapsed);

		}

	}
	
	//Linear Oddonacci Method
	/*
	 * @param n the amount to calculate Oddonacci up till
	 * @return array with the last 3 digits of the Oddonacci sequence being stored
	 */
	public static int[] linearOddonacci(int n)
	{
		int tempValue = 0;
		int[] arr;
		
		if (n <= 3)
		{
			return new int[]{1, 1, 1};
		}
		
		arr = linearOddonacci(n-1);
		
		tempValue = arr[0];
		arr[0] = arr[1];
		arr[1] = arr[2];
		arr[2] = arr[1] + arr[0] + tempValue;
		
		return arr;
	}
	
	//Tail recursive method for Linear Oddonacci
	//Uses a global array called tailLinearOddonnaciArray
	/*
	 * @param n the amount to calculate Oddonacci up till
	 * @return array with the last 3 digits of the Oddonacci sequence being stored
	 */
	public static int[] tailLinearOddonacci(int n)
	{	
		if (n <= 3)
		{
			return tailLinearOddonacciArray;
		}
		
		int otherTempValue = tailLinearOddonacciArray[0];
		tailLinearOddonacciArray[0] = tailLinearOddonacciArray[1];
		tailLinearOddonacciArray[1] = tailLinearOddonacciArray[2];
		tailLinearOddonacciArray[2] = tailLinearOddonacciArray[1] + tailLinearOddonacciArray[0] + otherTempValue;
		return tailLinearOddonacci(n - 1);
	}
	/*
	 * @params oddonaciMethod - String that describes the method being called
	 * 		   oddonacciNumber - Number to perform the calculation till
	 * 		   result - Last number of the oddonacci calculation
	 * 		   timeElapsed - The amount of time that was taken to perform the algorithm
	 */
	//Write the result to the text file
		public static void writeResult(String oddonacciMethod,int oddonacciNumber, int result, long timeElapsed)
		{
			try {
				//Second parameter is true in order to append to the second file
		        BufferedWriter out = new BufferedWriter(new FileWriter(FILE_NAME, true));
		            
		            out.write("Method Called: " + oddonacciMethod + "\n");
		            out.write("Oddonacci To Calculate To: " + oddonacciNumber + "\n");	
		            if (result < 0)
		            out.write("Oddonacci Result: " + result + " - Buffer Overflow, result is higher then maximum value Int can hold \n");
		            else
		            out.write("Oddonacci Result: " + result + "\n");
		            out.write("Time to compute: " + timeElapsed + "\n\n");
		            out.close();
		        } catch (IOException e) {}
		}
}
