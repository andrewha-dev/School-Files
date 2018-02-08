/**
 * 
 */
package b31_l11_trees;
import gray.adts.*;
import gray.adts.binarytree.BinaryTreeNode;
import gray.adts.binarytree.Visitor;

/**
 * @author 1435792
 *
 */
public class FolderTreeVisitor implements Visitor
{

	@Override
	public void visit(BinaryTreeNode node)
	{
		System.out.println(node.element());
		
	}

}
