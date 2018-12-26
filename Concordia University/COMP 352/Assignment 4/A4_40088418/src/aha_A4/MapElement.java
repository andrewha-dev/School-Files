/**
 * 
 */
package aha_A4;

/**
 * @author Andrew
 *
 */
import java.util.Random;
public class MapElement {
	public int key;
	public String value;
	public MapElement()
	{
		Random r = new Random();
		key = (int)r.nextInt((int)System.currentTimeMillis());
		value  = "Hi! My value is my key. Which is: " + key;
	}
	
	@Override
	public int hashCode()
	{	
		int x = 31;
		//Convert key to an array
		 int[]intToArray = Integer.toString(key).chars().map(c -> c-'0').toArray();  
		 long res = 0;
	        for (int i = intToArray.length - 1; i >= 0; i--)
	        	
	        res = intToArray[i] + (x * res);
		return (int)res & 0xfffffff;
	}
	
	
}
