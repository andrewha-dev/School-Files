package aha_A4;

import java.util.ArrayList;

public class HashChaining extends HashTable {
	public HashChaining(int n) {
		super(n);		
	}

	
	public MapElement get(int k)
	{
		MapElement temp = new MapElement();
		temp.key = k;
		
		int index = temp.hashCode() % arrChain.size();
		
		if (arrChain.get(index).size() > 0)
		{
			if (arrChain.get(index).get(0).key == k)
			{
				return arrChain.get(index).get(0);
			}
			else
			{
				for(int i = 1; i < arrChain.get(index).size(); i++)
				{
					if (arrChain.get(index).get(i).key == k)
					{
						return arrChain.get(index).get(i);
					}	
				}
				
				return null;
			}
		}
		else
		{
			return null;
		}
				
		
		
	}
	
	public MapElement put (int k, MapElement v) throws Exception 
	{
		int index = v.hashCode() % arrChain.size();
		if (arrChain.get(index).size() == 0)
		{
			arrChain.get(index).add(v);
			size++;
			System.out.println("Bucket Size: " + arrChain.get(index).size());
			return null;
		}
		else
		{
			keyCollisions++;
			collisions = 0;
			for(int i = 0; i < arrChain.get(index).size(); i++)
			{
				if (arrChain.get(index).get(i).key == k)
				{
					MapElement temp = arrChain.get(index).get(i);
					arrChain.get(index).set(i, v);
					return temp;
				}
				collisions++;
			}
			arrChain.get(index).add(v);	
			System.out.println("Bucket Size: " + arrChain.get(index).size());
			System.out.println("Probing: " + collisions);

			size++;
			
		}
		
		return null;
	}
	
	public String remove(int k)
	{
		MapElement temp = new MapElement();
		temp.key = k;
		
		int index = temp.hashCode() % arrChain.size();
		
		if (arrChain.get(index).size() > 0)
		{
			if (arrChain.get(index).get(0).key == k)
			{
				String value = arrChain.get(index).get(0).value;
				arrChain.get(index).remove(0);
				size--;
				return value;
			}
			else
			{
				for(int i = 1; i < arrChain.get(index).size(); i++)
				{
					if (arrChain.get(index).get(i).key == k)
					{
						String value = arrChain.get(index).get(i).value;
						arrChain.get(index).remove(i);
						size--;
						return value;
					}	
				}
				
				return null;
			}
		}
		else
		{
			return null;
		}
	}
}
