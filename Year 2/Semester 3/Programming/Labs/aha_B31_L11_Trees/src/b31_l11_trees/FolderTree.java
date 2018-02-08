/**
 * 
 */
package b31_l11_trees;

import gray.adts.binarytree.BinaryTree;
import gray.adts.binarytree.BinaryTreeNode;
import gray.adts.binarytree.LinkedBinaryTree;
import gray.adts.binarytree.Visitor;

/**
 * @author 1435792
 *
 */
public class FolderTree
{
	static BinaryTree<String> t;
	/**
	 * @param args
	 */
	public static void main(String[] args)
	{
		FolderTree folder = new FolderTree();
		folder.createTree();
		folder.listDirectories();
		// TODO Auto-generated method stub

	}
	public static void createTree()
	{
		t = new LinkedBinaryTree("Home");
		BinaryTreeNode<String> a = t.makeLeftChild(t.root(), "420-B31");
		BinaryTreeNode<String> b = t.makeRightChild(t.root(), "420-D10");
		t.makeLeftChild(a, "Assignments");
		BinaryTreeNode<String> c = t.makeRightChild(a, "Labs");
		t.makeLeftChild(c, "aha_B31_L11");
		
		t.makeLeftChild(b, "Assignments");
		t.makeRightChild(b, "Labs");
		
		
	}
	public static <E> void listDirectories()
	{
		FolderTreeVisitor visit = new FolderTreeVisitor();
		t.preOrderTraversal(visit);
		
	}

}
