/**
 * 
 */
package aha_A2;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.util.LinkedList;
import java.util.Queue;
import java.util.Random;

/**
 * @author Andrew
 *
 */
public class ListTester {
	public static final int[] N =  {10, 100, 1000, 10000, 100000, 1000000};
	public static final int N_ACCESS_TILL = 4;
	public static final String FILE_NAME = "testrun.txt";
	public static long before, after, timeElapsedBeg, timeElapsedEnd, timeElapsedRand;
	public static Queue<Long> myArrayListStart = new LinkedList<Long>();
	public static Queue<Long> myLinkedListStart = new LinkedList<Long>();
	public static Queue<Long> myArrayListEnd = new LinkedList<Long>();
	public static Queue<Long> myLinkedListEnd = new LinkedList<Long>();
	public static Queue<Long> myArrayListRandom = new LinkedList<Long>();
	public static Queue<Long> myLinkedListRandom = new LinkedList<Long>();
	public static Queue<Long> myArrayListObject = new LinkedList<Long>();
	public static Queue<Long> myLinkedListObject = new LinkedList<Long>();
	public static Queue<Integer> myNResults = new LinkedList<Integer>();

	
	
	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		//PART A
		MyArrayList al = new MyArrayList();
		MyLinkedList ll = new MyLinkedList();
		Random r = new Random();
		
		//My ArrayList insert beginning
		
		for(int i = 0; i < N_ACCESS_TILL; i++)
		{
			before = System.currentTimeMillis();
			for(int j = 0; j <= N[i]; j++)
			{
				int el = r.nextInt(N[i] * 2);;
				al.add(0, el);
			}
			after = System.currentTimeMillis();
			timeElapsedBeg = after - before;
			//writeResult("MyArrayList", "Insert", N[i], true, false, false, timeElapsedBeg);
			myArrayListStart.add(timeElapsedBeg);
			before = System.currentTimeMillis();
			for(int j = 0; j <= N[i]; j++)
			{
				int el = r.nextInt(N[i] * 2);;
				ll.add(0, el);
			}	 
			after = System.currentTimeMillis();
			timeElapsedBeg = after - before;
			//writeResult("MyLinkedList", "Insert", N[i], true, false, false, timeElapsedBeg);
			myLinkedListStart.add(timeElapsedBeg);
			al.clear();	
			ll.clear();
		}
		
		//My ArrayList insert at the end
		for(int i = 0; i < N_ACCESS_TILL; i++)
		{
			before = System.currentTimeMillis();
			for(int j = 0; j <= N[i]; j++)
			{
				int el = r.nextInt(N[i] * 2);;
				al.add(el);
			}
			after = System.currentTimeMillis();
			timeElapsedBeg = after - before;
			//writeResult("MyArrayList", "Insert", N[i], false, true, false, timeElapsedBeg);
			myArrayListEnd.add(timeElapsedBeg);

			before = System.currentTimeMillis();	
			for(int j = 0; j <= N[i]; j++)
			{
				int el = r.nextInt(N[i] * 2);;
				ll.add(el);
			}
			after = System.currentTimeMillis();
			timeElapsedBeg = after - before;
			myLinkedListEnd.add(timeElapsedBeg);

			//writeResult("MyLinkedList",  "Insert", N[i], false, true, false, timeElapsedBeg);
			al.clear();
			ll.clear();
			
		}
		
		
		//My ArrayList insert at random indexes
		for(int i = 0; i < N_ACCESS_TILL; i++)
		{
			before = System.currentTimeMillis();

			for(int j = 0; j <= N[i]; j++)
			{
				//Needs to put the index at 0 if the size is 1, otherwise r.nextInt() will throw an error
				if (j == 0)
				{
					int index = r.nextInt(N.length - 1);
					int el = r.nextInt(N[i] * 2);
					al.add(0, el);
				}
				else
				{
					int index = r.nextInt(N.length - 1);
					int el = r.nextInt(N[i] * 2);
					al.add(r.nextInt(al.size()), el);
				}
			}
			after = System.currentTimeMillis();
			timeElapsedBeg = after - before;
			//writeResult("MyArrayList", "Insert", N[i], false, false, true, timeElapsedBeg);	
			myArrayListRandom.add(timeElapsedBeg);

			before = System.currentTimeMillis();

			for(int j = 0; j <= N[i]; j++)
			{
				//Needs to put the index at 0 if the size is 1, otherwise r.nextInt() will throw an error
				if (j == 0)
				{
					int index = r.nextInt(N.length - 1);
					int el = r.nextInt(N[i] * 2);
					ll.add(0, el);
				}
				else
				{
					int index = r.nextInt(N.length - 1);
					int el = r.nextInt(N[i] * 2);
					ll.add(r.nextInt(ll.size()), el);
				}
			}
			after = System.currentTimeMillis();
			timeElapsedBeg = after - before;
			//writeResult("MyLinkedList", "Insert", N[i], false, false, true, timeElapsedBeg);	
			myLinkedListRandom.add(timeElapsedBeg);
			
			myNResults.add((int) N[i]);
			writeResult();
		}
		
		
		
		//PART B
		MyArrayList al_copy = al;
		MyLinkedList ll_copy = ll;
		MyArrayList al_copy_ran = al_copy;

		//My ArrayList remove beginning
		for(int i = 0; i < N_ACCESS_TILL; i++)
		{
			before = System.currentTimeMillis();

			for(int j = 0; j <= N[i]; j++)
			{
				if (al_copy.size() > 1)
				al_copy.remove(0);
			}			
			after = System.currentTimeMillis();
			timeElapsedBeg = after - before;
			//writeResult("MyArrayList", "Remove", N[i], true, false, false, timeElapsedBeg);
			myArrayListStart.add(timeElapsedBeg);

			before = System.currentTimeMillis();

			for(int j = 0; j <= N[i]; j++)
			{
				ll_copy.remove(0);
			}		
			after = System.currentTimeMillis();
			timeElapsedBeg = after - before;
			//writeResult("MyLinkedList", "Remove", N[i], true, false, false, timeElapsedBeg);	
			myLinkedListStart.add(timeElapsedBeg);

			al_copy = al;
			ll_copy = ll;
		}
		
		al.clear();
		for(int i = 0; i < N_ACCESS_TILL; i++)
		{
			before = System.currentTimeMillis();

			for(int j = 0; j <= N[i]; j++)
			{
				//Needs to put the index at 0 if the size is 1, otherwise r.nextInt() will throw an error
				if (j == 0)
				{
					int index = r.nextInt(N.length - 1);
					int el = r.nextInt(N[i] * 2);
					al.add(0, el);
				}
				else
				{
					int index = r.nextInt(N.length - 1);
					int el = r.nextInt(N[i] * 2);
					al.add(r.nextInt(al.size()), el);
				}
			}
			after = System.currentTimeMillis();
			timeElapsedBeg = after - before;
		}
		
		al_copy = al;
		//My ArrayList remove at the end
		for(int i = 0; i < N_ACCESS_TILL; i++)
		{
			before = System.currentTimeMillis();
			for(int j = 0; j <= N[i]; j++)
			{
				if (al_copy.size() > 0)
				al_copy.remove(al_copy.size() - 1);
			}			
			
			after = System.currentTimeMillis();
			timeElapsedBeg = after - before;
			myArrayListEnd.add(timeElapsedBeg);

			//writeResult("MyArrayList", "Remove", N[i], false, true, false, timeElapsedBeg);	
			before = System.currentTimeMillis();
			for(int j = 0; j <= N[i]; j++)
			{
				ll_copy.remove(ll_copy.size() - 1);
			}
			after = System.currentTimeMillis();
			timeElapsedBeg = after - before;
			//writeResult("MyLinkedList", "Remove", N[i], false, true, false, timeElapsedBeg);	
			myLinkedListEnd.add(timeElapsedBeg);

			al_copy = al;
			ll_copy = ll;
		}
		
		
		for(int i = 0; i < N_ACCESS_TILL; i++)
		{
			before = System.currentTimeMillis();

			for(int j = 0; j <= N[i]; j++)
			{
				//Needs to put the index at 0 if the size is 1, otherwise r.nextInt() will throw an error
				if (j == 0)
				{
					int index = r.nextInt(N.length - 1);
					int el = r.nextInt(N[i] * 2);
					al.add(0, el);
				}
				else
				{
					int index = r.nextInt(N.length - 1);
					int el = r.nextInt(N[i] * 2);
					al.add(r.nextInt(al.size()), el);
				}
			}
			after = System.currentTimeMillis();
			timeElapsedBeg = after - before;
		}
		al_copy = al;
		
		//My ArrayList remove at random indexes
		for(int i = 0; i < N_ACCESS_TILL; i++)
		{
			before = System.currentTimeMillis();
			for(int j = 0; j <= N[i]; j++)
			{
				//Needs to put the index at 0 if the size is 1, otherwise r.nextInt() will throw an error
				if (j == 0)
				{
					al_copy.remove(0);
				}
				else
				{
					//System.out.println(al_copy.size());
					int index = r.nextInt(N.length - 1);
					//if (al_copy.size() != 0)
					al_copy.remove(r.nextInt(al_copy.size()));
				}
			}
			after = System.currentTimeMillis();
			timeElapsedBeg = after - before;
			//writeResult("MyArrayList", "Remove", N[i], false, false, true, timeElapsedBeg);
			myArrayListRandom.add(timeElapsedBeg);

			before = System.currentTimeMillis();
			for(int j = 0; j <= N[i]; j++)
			{
				//Needs to put the index at 0 if the size is 1, otherwise r.nextInt() will throw an error
				if (j == 0)
				{
					int index = r.nextInt(N.length - 1);
					int el = r.nextInt(N[i] * 2);
					if (ll_copy.size() > 0)
					ll_copy.remove(0);
				}
				else
				{
					int index = r.nextInt(N.length - 1);
					int el = r.nextInt(N[i] * 2);
					if (ll_copy.size() > 0)
					ll_copy.remove(r.nextInt(ll_copy.size()));
				}
				
			}
			after = System.currentTimeMillis();
			timeElapsedBeg = after - before;
			//writeResult("MyLinkedList", "Remove", N[i], false, false, true, timeElapsedBeg);	
			myLinkedListRandom.add(timeElapsedBeg);
			
			al_copy = al;
			ll_copy = ll;
		}

		
		ll_copy = ll;
		
		//PART C
		for(int i = 0; i < N_ACCESS_TILL; i++)
		{
			for(int j = 0; j <= N[i]; j++)
			{
				int el = r.nextInt(N[i] * 2);;
				al.add(0, el);
			}
			before = System.currentTimeMillis();
			
			for(int j = 0; j <= N[i]; j++)
			{
				//Needs to put the index at 0 if the size is 1, otherwise r.nextInt() will throw an error
					int el = r.nextInt(N[i] * 2);
					al.remove((Object)el);
			}
			after = System.currentTimeMillis();
			timeElapsedBeg = after - before;
			//writeResult("MyArrayList", "Object Remove", N[i], true, false, false, timeElapsedBeg);	
			myArrayListObject.add(timeElapsedBeg);

			
			for(int j = 0; j <= N[i]; j++)
			{
				int el = r.nextInt(N[i] * 2);;
				ll.add(0, el);
			}
			
			before = System.currentTimeMillis();
			for(int j = 0; j <= N[i]; j++)
			{
				//Needs to put the index at 0 if the size is 1, otherwise r.nextInt() will throw an error
					int el = r.nextInt(N[i] * 2);
					ll.remove((Object)el);
			}
			
			after = System.currentTimeMillis();
			timeElapsedBeg = after - before;
			//writeResult("MyLinkedList", "Object Remove", N[i], true, false, false, timeElapsedBeg);	
			myLinkedListObject.add(timeElapsedBeg);

			al.clear();
			ll.clear();
			myNResults.add(N[i]);
		}
		writeResultDelete();


		
		
			
	}
	
	public static void writeResult(String typeOfList, String typeOfOperation, int n, boolean beg, boolean end, boolean rand, long timeElapsed)
	{
		try {
			//True to append to the text file
	        BufferedWriter out = new BufferedWriter(new FileWriter(FILE_NAME, true));
	        
	            out.write("Type of List: " + typeOfList + " at size: " + n +" \n");
	            if (beg)
	            out.write(typeOfOperation + " Beginning Speed: " + timeElapsed + "\n\n");	
	            if (end)
	            out.write(typeOfOperation + " End Speed: " + timeElapsed + "\n\n");
	            if (rand)
	            out.write(typeOfOperation + " Random Speed: " + timeElapsed + "\n\n");
	            
	            out.close();
	        } catch (IOException e) {}
	}
	
	public static void writeResult()
	{
		try {
			//True to append to the text file
	        BufferedWriter out = new BufferedWriter(new FileWriter(FILE_NAME, true));
    		out.write(String.format("%20s %20s", "\n", "Insert\n"));	


	        	while(!myNResults.isEmpty())
	        	{
	        		
	        		int n = myNResults.remove();
	        		out.write(String.format("%20s %20s %20s %20s\r\n", "N = " + n, "Insert Start", "Insert End", "Insert Random"));	
	        		while(!myLinkedListRandom.isEmpty())
	        		{
		        		out.write(String.format("%20s %20d %20d %20d\r\n", "ArrayList", myArrayListStart.remove(), myArrayListEnd.remove(), myArrayListRandom.remove()));
		        		out.write(String.format("%20s %20d %20d %20d\r\n", "LinkedList", myLinkedListStart.remove(), myLinkedListEnd.remove(), myLinkedListRandom.remove()));

	        		}
	        	}
	            
	            
	            out.close();
	        } catch (IOException e) {}
	}
	
	public static void writeResultDelete()
	{
		try {
			//True to append to the text file
	        BufferedWriter out = new BufferedWriter(new FileWriter(FILE_NAME, true));
    		out.write(String.format("%20s %20s", "\n", "Remove\n"));	

	        	while(!myNResults.isEmpty())
	        	{
	        		
	        		int n = myNResults.remove();
	        		out.write(String.format("%20s %20s %20s %20s %20s\r\n", "N = " + n, "Remove Start", "Remove End", "Remove Random", "Remove Object"));	
		        		out.write(String.format("%20s %20d %20d %20d %20s\r\n", "ArrayList", myArrayListStart.remove(), myArrayListEnd.remove(), myArrayListRandom.remove(), myArrayListObject.remove()));
		        		out.write(String.format("%20s %20d %20d %20d %20s\r\n\n", "LinkedList", myLinkedListStart.remove(), myLinkedListEnd.remove(), myLinkedListRandom.remove(), myLinkedListObject.remove()));

	        	}
	            
	            
	            out.close();
	        } catch (IOException e) {}
	}

}
