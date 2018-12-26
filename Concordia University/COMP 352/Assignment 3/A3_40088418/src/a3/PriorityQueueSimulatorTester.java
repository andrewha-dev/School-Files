/**
 * 
 */
package a3;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Random;

/**
 * @author Andrew
 *
 */

//
//REMEMBER TO ANSWER QUESTIONS IN THE TXT FILE
//
public class PriorityQueueSimulatorTester {
	static int currentTimeStatic = 0;
	public static final String FILE_NAME = "SimulatorPerformanceResults.txt";


	/**
	 * @param args
	 */
	public static void main(String[] args) {
		int[] maxNumberOfJobs = {100, 1000, 10000, 100000, 1000000};
		int maxNumberOfJobsIndex = 0;

		for(int a = 0; a <= maxNumberOfJobsIndex; a++)
		{
			int currentTime = 0;
			int priorityChange = 0;

			long startTime;
			long endTime;
			long elapsedTime;
			PriorityQueueList<?> pqList = new PriorityQueueList();
			PriorityQueueHeap<?> pqHeap = new PriorityQueueHeap();
			Job[] jobsInputArray = new Job[maxNumberOfJobs[a] + 1];

			// TODO Auto-generated method stub
			System.out.println("Starting Simulator: Priority Queue List");
			int priority, jobLength;
			//Creating Objects
			for(int i = 0; i <= maxNumberOfJobs[a]; i++)
			{
				Random r = new Random();
				//Creating our random values now
				priority = r.nextInt(41 - 1) + 1;
				jobLength = r.nextInt(71 - 1) + 1;
				Job j = new Job();
				j.setEntryTime(currentTime);
				j.setJobName("JOB_" + (i + 1));
				j.setJobPriority(priority);
				j.setJobLength(jobLength);
				
				j.setCurrentJobLength(jobLength);
				j.setFinalPriority(priority);
				//System.out.println("Current Time: " + currentTime);
				jobsInputArray[i] = j;
				

			}
			
			
			for(int i = 0; i < jobsInputArray.length; i++)
			{
				Job j = new Job();
				j = (Job)jobsInputArray[i];
				pqList.enqueue(j.clone());
				++currentTime;
				++currentTimeStatic;
			}
			
			//System.out.println(pqList.toString());
			startTime = System.currentTimeMillis();
			while (!pqList.isEmpty())
			{
				
				Job j = pqList.dequeue();
				System.out.println(j.toString());
				//System.out.println("Size: " + jobsInputArray.size);
				

				if (currentTime%30 == 0 && currentTime > 1)
				{
					boolean isStarvedFound = false;
					isStarvedFound = pqList.moveStarvedProcess();
					if (isStarvedFound)
					{
						isStarvedFound = false;
						++priorityChange;

					}
				}
				++currentTime;
				++currentTimeStatic;

			}
			endTime = System.currentTimeMillis();
			elapsedTime = endTime - startTime;
			System.out.println("Simulation Complete!");
			
			writeResult("Sorted List Priority Queue", currentTime, maxNumberOfJobs[a], (double) pqList.waitTime / (double) maxNumberOfJobs[a], priorityChange, elapsedTime);

			
			
			
			System.out.println("\n\nStarting Simulator: Priority Queue Heap");
			currentTime = 0;
			currentTimeStatic = 0;
			priorityChange = 0;
			for(int i = 0; i < jobsInputArray.length; i++)
			{
				Job j = new Job();
				j = jobsInputArray[i];
				pqHeap.add(j.clone());
				++currentTime;
				++currentTimeStatic;
				
			}
			
			//System.out.println(pqHeap.toString());
			startTime = System.currentTimeMillis();
			//System.out.println(pqHeap.toString());
			while (!pqHeap.isEmpty())
			{
				
				Job j = pqHeap.removeMin();
				//System.out.println(j.toString());
				//System.out.println("Size: " + jobsInputArray.size);
				

				if (currentTime%30 == 0 && currentTime > 1)
				{
					boolean isStarvedFound = false;
					isStarvedFound = pqHeap.moveStarvedProcess();
					if (isStarvedFound)
					{
						isStarvedFound = false;
						++priorityChange;

					}
				}
				++currentTime;
				++currentTimeStatic;
			}
			endTime = System.currentTimeMillis();
			elapsedTime = endTime - startTime;
			System.out.println("Simulation Complete!");
			writeResult("ArrayList-based Heap Priority Queue", currentTime, maxNumberOfJobs[a], (double) pqHeap.waitTime / (double) maxNumberOfJobs[a], priorityChange, elapsedTime);
			
		}
		

		
	}
	
	public static int getCurrentTime()
	{
		return currentTimeStatic;
	}
	
	public static void writeResult(String typeOfQueue, int currentTime, int numberOfJobs, 
			double averageProcessWaitingTime, int priorityChange, long elapsedTime)
	{
		try {
			//True to append to the text file
	        BufferedWriter out = new BufferedWriter(new FileWriter(FILE_NAME, true));	            
	        out.write("" + typeOfQueue + " :" );
			out.write("\nCurrent System Time (Cycles): " + currentTime);
			out.write("\nTotal Number Of Jobs Executed: " + numberOfJobs);
			out.write("\nAverage Process Waiting Time: " + averageProcessWaitingTime);
			out.write("\nTotal Number Of Priority Changes: " + priorityChange);
			out.write("\nActual System Time Needed To Execute All Jobs: "  + elapsedTime + " ms\n\n");
	            out.close();
	        } catch (IOException e) {}
	}
	

}
