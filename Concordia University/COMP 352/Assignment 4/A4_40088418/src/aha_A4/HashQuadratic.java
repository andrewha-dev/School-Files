/**
 * 
 */
package aha_A4;

/**
 * @author Andrew
 *
 */
public class HashQuadratic extends HashTable {
	
	public HashQuadratic(int n) {
		super(n);		
	}

	
	public MapElement get(int k)
	{
		MapElement temp = new MapElement();
		temp.key = k;
		
		int pow = 0;
		int index = temp.hashCode() % arr.length;
		int originalIndex = index;
		boolean found = false;
		int pollingAttemptsRemaining = arr.length;
		while (pollingAttemptsRemaining > 0)
			{
				index = originalIndex + pow * pow;
				pow++;

				while (index >= arr.length)
				{
					if (index >= arr.length)
					index = index % arr.length;
					
				}
				
				if (index < 0)
					index = 0;
				
				
				if (arr[index] != null)
				if (arr[index].key != temp.key)
				{
					if (index >= arr.length)
						index = index % arr.length;
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
		collisions = 0;
		int index = v.hashCode() % arr.length;
		if (arr[index] == null)
		{
			arr[index] = v;
			size++;
		}
		else
		{
			keyCollisions++;
			collisions++;
			//Quadratic Probing
			MapElement currEl = arr[index];
			if (currEl.key == v.key)
			{				
				arr[index] = v;
				return currEl;
			}
			else
			{
				if (size <= arr.length - 1)
				{
				
					int i = index;
					boolean isFound = false;

					while (i >= arr.length)		
					{
						i = i - arr.length;
					}
					int rotation = 0;
					int pow = 0;
					while(!isFound)
					{
						
						if (arr[i] != null)
						{		
							collisions++;
							pow++;
							i = index + pow * pow;

							while (i >= arr.length)	
							{
								i = i % arr.length;
								

							}
							if (rotation == arr.length * 10)
							{
								throw new Exception("Probe Too Long");
							}
							rotation++;
								
						}							
						else
						{
							isFound = true;
							arr[i] = v;
							size++;
							System.out.println("Probing Attempts: " + collisions);
							System.out.println("Key Collisions: " + keyCollisions);

							return null;
						}
					}
				}
				else
				{
					keyCollisions++;
					int rotations = 0;
					int i = index;
					boolean isFound = false;
					if (i ==  arr.length - 1)
						i = 0;
					int pow = 0;
					while(!isFound)
					{
						
						if (arr[i] != null)
						{		
							collisions++;
							pow++;
							i = index + pow * pow;
							
							while (i >= arr.length)			
								i = i - arr.length;
								
						}							
						else
						{
							isFound = true;
							arr[i] = v;
							size++;
							
							System.out.println("Probing Attempts: " + collisions);
							System.out.println("Key Collisions: " + keyCollisions);
							return null;
						}
						rotations++;
						if (rotations == arr.length * 5)
						{
							throw new Exception("Probing Too Long");
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
		int quadKey = 0;
		int pow = 0;
		int index = temp.hashCode() % arr.length;
		int originalIndex = index;
		boolean found = false;
		int pollingAttemptsRemaining = 1000;
		while (pollingAttemptsRemaining > 0)
			{
				
				index = originalIndex + pow * pow;
				pow++;
				if (index >= arr.length)
					index = index - arr.length;
				if (arr[index] != null)
				if (arr[index].key != temp.key)
				{
					if (index >= arr.length)
						index = index - arr.length;
					pollingAttemptsRemaining--;
					
					if  (pollingAttemptsRemaining == 0)
					{
				
						return null;
					}
					
				}
				else
				{
					size--;
					String val = arr[index].value;
					arr[index] = null;
					return val;
				}
				
				
			}
		return null;
	}

	

}
