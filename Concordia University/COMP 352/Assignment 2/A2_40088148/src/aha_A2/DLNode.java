/**
 * 
 */
package aha_A2;

/**
 * @author Andrew
 *
 */
public class DLNode<E> {
	private E          element;       // the data field
    private DLNode<E>  predecessor;   // link to previous (predecessor) DLNode
    private DLNode<E>  successor;     // the link to next (successor) DLNode
    
    public DLNode()
    {
    	this.element = null;
    	this.predecessor = null;
    	this.successor = null;
    }
    
    public DLNode( E _listEl, DLNode<E> _pred, DLNode<E> _succ ) {
        this.element = _listEl;
        this.predecessor = _pred;
        this.successor = _succ;
    }
    public void setElement( E _listEl ){
        this.element = _listEl;
     }

     public E getElement( ){
        return this.element;
     }

     public DLNode<E> getPredecessor( ){
        return this.predecessor;
     }

     public void setPredecessor( DLNode<E> _newPred ){
        this.predecessor = _newPred;
     }

     public DLNode<E> getSuccessor( ){
        return this.successor;
     }

     public void setSuccessor( DLNode<E> _newSucc ){
        this.successor = _newSucc;
     }
}
