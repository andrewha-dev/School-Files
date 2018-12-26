/**
 * 
 */
package aha_A4;

import java.util.ArrayList;

/**
 * @author Andrew
 *
 */
public class Test {
	public static final int hashMapSize = 128;
	public static final int amountOfElements = 10000;
	public static final int amountToRemove = 25;


	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		System.out.println("Starting Simulator: ");
		HashTable t = new HashLinear(hashMapSize);
		ArrayList <MapElement> els = new ArrayList<>();
		long startTime = System.nanoTime(), endTime = System.nanoTime(), elapsedTime = System.nanoTime();
		System.out.println("=========STARTING LINEAR PROBING================");

		System.out.println("\n=========LINEAR PUT " + amountOfElements + " ELEMENTS ================");

			for(int i = 1; i <= amountOfElements; i++)
			{
			MapElement test1 = new MapElement();
			els.add(test1);
			
			try {				
				startTime = System.nanoTime();
				t.put(test1.hashCode(), test1);
				endTime = System.nanoTime();
				elapsedTime = endTime - startTime;
				System.out.println("Put Time (Linear Probe): " + elapsedTime);
			} catch (Exception e) {
				// TODO Auto-generated catch block
				System.out.println("Exception: " + e.getMessage());
			}
			
			}
			int foundAmount = 0;
			System.out.println("\n=========LINEAR GET " + amountOfElements + " ELEMENTS ================");

			for(int i = 0; i < els.size(); i++)
			{
				//Running gets on keys
				MapElement compared = new MapElement();
				
				
				startTime = System.nanoTime();
//				t.put(test1.hashCode(), test1);
				compared = t.get(els.get(i).key);
				endTime = System.nanoTime();
				elapsedTime = endTime - startTime;
				
				System.out.println("Get Time (Linear Before Removal): " + elapsedTime);
				
				if (compared == null)
				{
//					System.out.println("Null");
				}
				else
				{
					foundAmount++;

//					System.out.println("Found: " + foundAmount);
				}
			}
			

			foundAmount = 0;

			System.out.println("\n=========LINEAR REMOVE " + amountToRemove + " ELEMENTS ================");

			for(int i = 0; i < amountToRemove; i++)
			{
				
				
				startTime = System.nanoTime();
//				t.put(test1.hashCode(), test1);
				String value = t.remove(els.get(i).key);
				endTime = System.nanoTime();
				elapsedTime = endTime - startTime;
				
				System.out.println("Remove (Linear Probe): " + elapsedTime);
				if (value == null)
				{
					//System.out.println("Not Found");
				}
				else					
				{
//					System.out.println(value);
//					foundAmount++;
//					System.out.println("Found: " + foundAmount);
					
				}
			}
			
			foundAmount = 0;
			System.out.println("\n=========LINEAR GET AFTER REMOVAL OF " + amountToRemove + " ELEMENTS ================");

			for(int i = 0; i < els.size(); i++)
			{
				//Running gets on keys
				MapElement compared = new MapElement();
				
				
				startTime = System.nanoTime();
//				t.put(test1.hashCode(), test1);
				compared = t.get(els.get(i).key);
				endTime = System.nanoTime();
				elapsedTime = endTime - startTime;
				System.out.println("Get Time (Linear After Removal): " + elapsedTime);
				if (compared == null)
				{
					//System.out.println("Not Found");
				}
				else
				{
					foundAmount++;

					//System.out.println("Found: " + foundAmount);
				}
			}
			System.out.println("\n========= DONE LINEAR PROBE ================");
			System.out.println("========= FINAL REPORT LINEAR PROBE ================");
			System.out.println("Size: " + t.arr.length);
			System.out.println("Collisions: " + t.collisions);
			
			
			System.out.println("\nStarting: Quadratic Probe");
			t = new HashQuadratic(hashMapSize);			
			
			
			System.out.println("\n=========QUADRATIC PROBE OF " + amountOfElements + " ELEMENTS ================");

			for(int i = 0; i < els.size(); i ++)
			{
				try {
					startTime = System.nanoTime();
//					t.put(test1.hashCode(), test1);
					t.put(els.get(i).key, els.get(i));
					endTime = System.nanoTime();
					elapsedTime = endTime - startTime;
					System.out.println("Put Time (Quadratic Probe): " + elapsedTime);
				} catch (Exception e) {
					// TODO Auto-generated catch block
					System.out.println("Exception: " + e.getMessage());
				}
			}
			foundAmount = 0;
			System.out.println("\n=========QUADRATIC GET " + amountOfElements + " ELEMENTS ================");

			for(int i = 0; i < els.size(); i++)
			{
				//Running gets on keys
				MapElement compared = new MapElement();
				
				
				startTime = System.nanoTime();
//				t.put(test1.hashCode(), test1);
				compared = t.get(els.get(i).key);
				endTime = System.nanoTime();
				elapsedTime = endTime - startTime;
				System.out.println("Get Time (Quadratic Probe): " + elapsedTime);
				
				
				if (compared == null)
				{
					//System.out.println("Null");
				}
				else
				{
					foundAmount++;

					//System.out.println("Found: " + foundAmount);
				}
			}
			

			foundAmount = 0;
			for(int i = 0; i < amountToRemove; i++)
			{
				
				startTime = System.nanoTime();
//				t.put(test1.hashCode(), test1);
				String value = t.remove(els.get(i).key);
				endTime = System.nanoTime();
				elapsedTime = endTime - startTime;
				System.out.println("Remove: " + elapsedTime);
				if (value == null)
				{
					//System.out.println("Not Found");
				}
				else					
				{
					//System.out.println(value);
//					foundAmount++;
//					System.out.println("Found: " + foundAmount);
					
				}
			}
			
			foundAmount = 0;
			for(int i = 0; i < els.size(); i++)
			{
				//Running gets on keys
				MapElement compared = new MapElement();
				
				
				startTime = System.nanoTime();
//				t.put(test1.hashCode(), test1);
				compared = t.get(els.get(i).key);
				endTime = System.nanoTime();
				elapsedTime = endTime - startTime;
				System.out.println("Get Time(Quadratic Probe After Removal): " + elapsedTime);
				
				
				if (compared == null)
				{
//					System.out.println("Not Found");
				}
				else
				{
//					foundAmount++;
//					System.out.println("Found: " + foundAmount);
				}
			}
			System.out.println("Collisions: " + t.collisions);
			System.out.println("Done: Quadratic Probe");
			System.out.println("\n=========STARTING CHAINING================");
			
			System.out.println("Starting: Chaining");
			t = new HashChaining(hashMapSize);			
			
			
			
			for(int i = 0; i < els.size(); i ++)
			{
				try {
					startTime = System.nanoTime();
//					t.put(test1.hashCode(), test1);
					t.put(els.get(i).key, els.get(i));
					endTime = System.nanoTime();
					elapsedTime = endTime - startTime;
					System.out.println("Put Time (Chaining): " + elapsedTime);
				} catch (Exception e) {
					// TODO Auto-generated catch block
					System.out.println(e.getMessage());
					e.printStackTrace();
				}
			}
			foundAmount = 0;
			
			for(int i = 0; i < els.size(); i++)
			{
				//Running gets on keys
				MapElement compared = new MapElement();
				
				
				
				compared = t.get(els.get(i).key);
				
				if (compared == null)
				{
					//System.out.println("Null");
				}
				else
				{
					foundAmount++;

					//System.out.println("Found: " + foundAmount);
				}
			}
			

			foundAmount = 0;
			for(int i = 0; i < amountToRemove; i++)
			{
				
				startTime = System.nanoTime();
//				t.put(test1.hashCode(), test1);
				String value = t.remove(els.get(i).key);
				endTime = System.nanoTime();
				elapsedTime = endTime - startTime;
				System.out.println("Remove Time (Chaining): " + elapsedTime);
				if (value == null)
				{
					//System.out.println("Not Found");
				}
				else					
				{
					//System.out.println(value);
//					foundAmount++;
//					System.out.println("Found: " + foundAmount);
					
				}
			}
			
			foundAmount = 0;
			for(int i = 0; i < els.size(); i++)
			{
				//Running gets on keys
				MapElement compared = new MapElement();
				
				
				startTime = System.nanoTime();
//				t.put(test1.hashCode(), test1);
				compared = t.get(els.get(i).key);
				endTime = System.nanoTime();
				elapsedTime = endTime - startTime;
				System.out.println("Get Time (Chaining After Removal): " + elapsedTime);
				
				
				if (compared == null)
				{
//					System.out.println("Not Found");
				}
				else
				{
//					foundAmount++;
//					System.out.println("Found: " + foundAmount);
				}
			}
			System.out.println("Collisions: " + t.keyCollisions);
			System.out.println("Done: Hash Chaining\n\n");

			
			
		

		
	}

}
