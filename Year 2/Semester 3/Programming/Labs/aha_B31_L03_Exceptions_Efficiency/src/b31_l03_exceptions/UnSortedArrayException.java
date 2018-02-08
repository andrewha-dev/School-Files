package b31_l03_exceptions;

public class UnSortedArrayException extends RuntimeException {

	public UnSortedArrayException() {
	super();
	}
	
	public UnSortedArrayException (String errMsg)
	{
		super("" + errMsg);
	}
	

}
