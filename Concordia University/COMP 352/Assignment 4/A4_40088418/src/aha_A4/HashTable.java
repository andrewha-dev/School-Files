/**
 * 
 */
package aha_A4;

import java.util.ArrayList;

/**
 * @author Andrew
 *
 */
public abstract class HashTable {
	protected int collisions, size, keyCollisions;
	protected MapElement[] arr;
	protected ArrayList<ArrayList<MapElement>> arrChain = new ArrayList<ArrayList<MapElement>>();
	
	
	
	public HashTable(int n)
	{
		collisions = 0;
		arr = new MapElement[n];
		arrChain = new ArrayList<ArrayList<MapElement>>(n);
		for(int i = 0; i < n; i++)
		{
			arrChain.add(new ArrayList<MapElement>());
		}
	}
	
	public int size()
	{
		return arr.length;		
	}
	
	public boolean isEmpty()
	{
		if (size != arr.length - 1)
			return false;
		else 
			return true;
	}
	
	public abstract MapElement get(int k);
	
	public abstract MapElement put (int k, MapElement v) throws Exception;
	
	public abstract String remove(int k);
	
	
}
