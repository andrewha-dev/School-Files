/**
 * 
 */
package aha_A4;

import java.lang.reflect.Array;

/**
 * @author Andrew
 *
 */
public class HashLinear extends HashTable {
	
	public HashLinear(int n) {
		super(n);		
	}

	
	public MapElement get(int k)
	{
		MapElement temp = new MapElement();
		temp.key = k;
		int index = temp.hashCode() % arr.length;
		boolean found = false;
		int pollingAttemptsRemaining = arr.length;
		
		
		while (pollingAttemptsRemaining > 0)
			{
				
				index++;
				if (index == arr.length)
					index = 0;
				if (arr[index] != null)
				if (arr[index].key != temp.key)
				{
					if (index == arr.length)
						index = 0;
					pollingAttemptsRemaining--;
					
					if  (pollingAttemptsRemaining == 0)
					{
				
						return null;
					}
					
				}
				else
				{
					
					return arr[index];
				}
				
				
			}
		return null;
		
	}
	
	public MapElement put (int k, MapElement v) throws Exception 
	{
		
//		if (size >= arr.length / 2)
//		{
//			MapElement[] temp = new MapElement[arr.length * 2];
//			for(int i = 0; i < arr.length; i++)
//			{
//				if (arr[i] != null)
//					temp[i] = arr[i];
//			}
//			
//			arr = temp;
//		}
		int index = v.hashCode() % arr.length;
		if (arr[index] == null)
		{
			arr[index] = v;
			size++;
			System.out.println("Size: " + size);
			return null;
		}
		else
		{
			keyCollisions++;
			//Linear probing
			int probingAttempts = 0;
			MapElement currEl = arr[index];
			if (currEl.key == v.key)
			{				
				arr[index] = v;
				return currEl;
			}
			else
			{
				collisions++;
				if (size <= arr.length - 1)
				{
					int i = index + 1;
					
					boolean isFound = false;
					if (i ==  arr.length - 1)
						i = 0;
					while(!isFound)
					{
						probingAttempts++;

						if (i ==  arr.length)
							i = 0;
						if (arr[i] != null)
						{
							i++;
							collisions++;
							if (i ==  arr.length)
								i = 0;

						}							
						else
						{
							isFound = true;
							arr[i] = v;
							size++;
							System.out.println("Probing Attempts: " + probingAttempts);
							System.out.println("Keys causing collisions: " + keyCollisions);
							return null;
						}
					}
				}
				else
				{
					int rotation = 0;
					int i = index + 1;
					
					boolean isFound = false;
					if (i ==  arr.length - 1)
						i = 0;
					while(!isFound)
					{
						probingAttempts++;
						if (i ==  arr.length)
							i = 0;
						if (arr[i] != null)
						{
							i++;
							collisions++;
							if (i ==  arr.length)
								i = 0;

						}							
						else
						{
							isFound = true;
							arr[i] = v;
							size++;
							System.out.println("Probing Attempts: " + probingAttempts);
							System.out.println("Keys causing collisions: " + keyCollisions);

							return null;
						}
						rotation++;
						if (rotation == arr.length * 5)
						{
							throw new Exception("Probing too long");
						}
					}
				
				}
				
			}
		}
		return null;
	}
	
	public String remove(int k)
	{
		MapElement temp = new MapElement();
		temp.key = k;
		int index = temp.hashCode() % arr.length;
		boolean found = false;
		int pollingAttemptsRemaining = arr.length;
		//System.out.println("First Index: " + index);
			while (pollingAttemptsRemaining > 0)
			{
				
				index++;
				if (index == arr.length)
					index = 0;
				
				if (arr[index] != null)
				if (arr[index].key != temp.key)
				{
					if (index == arr.length)
						index = 0;
					pollingAttemptsRemaining--;
					
					if  (pollingAttemptsRemaining == 0)
					{
						System.out.println("No more polls left");
						return null;
					}
					
				}
				else
				{
					size--;
					//System.out.println("Found");
					String returnValue = arr[index].value;
					arr[index] = null;
					return returnValue;
					
					
					//return arr[index];
				}
				
				
			}
		

		
		return null;
	}

	

}
