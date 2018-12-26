/**
 * 
 */
package a3;

/**
 * @author Andrew
 *
 */
public class Job {
	private String jobName;
	private int jobLength, currentJobLength;
	private int jobPriority, finalPriority, executedOn;
	private long entryTime, waitTime, endTime;
	private boolean isProcessed, finished;
	
	public Job()
	{
		jobName = null;
		jobLength = 0;
		currentJobLength = 0;
		jobPriority = 0;
		finalPriority = 0;
		entryTime = 0;
		waitTime =  0;
		endTime = 0;
		isProcessed = false;
		executedOn = 0;
		finished = false;
	}
	
	public Job(String _jobName, int _jobLength, int _currentJobLength, int _jobPriority, int _finalPriority, long _entryTime, long _waitTime, long _endTime)
	{
		jobName = _jobName;
		jobLength = _jobLength;
		currentJobLength = _currentJobLength;
		jobPriority = _jobPriority;
		finalPriority = _finalPriority;
		entryTime = _entryTime;
		waitTime = _waitTime;
		endTime = _endTime;
		isProcessed = false;
		executedOn = 0;
		finished = false;
	}
	
	
	public Job(String jobName, int jobLength, int currentJobLength, int jobPriority, int finalPriority, int executedOn,
			long entryTime, long waitTime, long endTime, boolean isProcessed, boolean finished) {
		super();
		this.jobName = jobName;
		this.jobLength = jobLength;
		this.currentJobLength = currentJobLength;
		this.jobPriority = jobPriority;
		this.finalPriority = finalPriority;
		this.executedOn = executedOn;
		this.entryTime = entryTime;
		this.waitTime = waitTime;
		this.endTime = endTime;
		this.isProcessed = isProcessed;
		this.finished = finished;
	}

	public boolean isFinished() {
		return finished;
	}

	public void setFinished(boolean finished) {
		this.finished = finished;
	}

	public int getExecutedOn() {
		return executedOn;
	}

	public void setExecutedOn(int executedOn) {
		this.executedOn = executedOn;
	}

	@Override
	public String toString()
	{
		return "Now Executing " + jobName + ". Job Length: " + jobLength + " cycles; " 
	+ "Current remaining length: " + currentJobLength + " cycles\n" +
				"Initial Priority: " + jobPriority + "; Current Priority: " + finalPriority + 
				"\n";
		
	}

	public String getJobName() {
		return jobName;
	}

	public void setJobName(String jobName) {
		this.jobName = jobName;
	}

	public int getJobLength() {
		return jobLength;
	}

	public void setJobLength(int jobLength) {
		this.jobLength = jobLength;
	}

	public boolean isProcessed() {
		return isProcessed;
	}

	public void setProcessed(boolean isProcessed) {
		this.isProcessed = isProcessed;
	}

	public int getCurrentJobLength() {
		return currentJobLength;
	}

	public void setCurrentJobLength(int currentJobLength) {
		this.currentJobLength = currentJobLength;
	}

	public int getJobPriority() {
		return jobPriority;
	}

	public void setJobPriority(int jobPriority) {
		this.jobPriority = jobPriority;
	}

	public int getFinalPriority() {
		return finalPriority;
	}

	public void setFinalPriority(int finalPriority) {
		this.finalPriority = finalPriority;
	}

	public long getEntryTime() {
		return entryTime;
	}

	public void setEntryTime(long entryTime) {
		this.entryTime = entryTime;
	}

	public long getWaitTime() {
		return waitTime;
	}

	public void setWaitTime(long waitTime) {
		this.waitTime = waitTime;
	}

	public long getEndTime() {
		return endTime;
	}

	public void setEndTime(long endTime) {
		this.endTime = endTime;
	}
	
	@Override
	public Job clone(){
	  try {
	        return (Job) super.clone();
	      }catch (CloneNotSupportedException e) {
	         return new Job(this.jobName, this.jobLength, this.currentJobLength, this.jobPriority, 
	        		 this.finalPriority, this.executedOn,
	     			this.entryTime, this.waitTime, this.endTime, 
	     			this.isProcessed, this.finished);
	      }
	     }
}
