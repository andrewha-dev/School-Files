/**
 * 
 */
package aha_B31_Final_Project;

import java.util.ArrayList;
import adts.stack.LinkedStack;

import adts.binarytree.BinaryTreeNode;
import adts.binarytree.LinkedBinaryTreeNode;
import adts.binarytree.Visitor;

/**
 * @author 1435792
 *
 */
public class CodeVisitor implements Visitor {
	public static String[] morseArray = new String[26];
	public static LinkedStack<String> morseStack = new LinkedStack<String>();

	public void visit(BinaryTreeNode node) {

		BinaryTreeNode morseNode = node;

		// Will skip the root
		if (!morseNode.element().toString().equals("")) {
			char ascii = node.element().toString().charAt(0);
			int asciiIndex = (int) ascii;
			asciiIndex -= 97;

			BinaryTreeNode parent = morseNode;
			while (!parent.element().toString().equals("")) {
				parent = morseNode.parent();
				if (parent.rightChild() != null)
					if (parent.rightChild().equals(morseNode))
						morseStack.push("-");

				if (parent.leftChild() != null)
					if (parent.leftChild().equals(morseNode))
						morseStack.push(".");

				morseNode = parent;
			}
			String path = "";
			while (morseStack.isEmpty() == false)
				path += (morseStack.pop());

			// Setting the array based off of the ascii value of the letters
			morseArray[asciiIndex] = path;

		}

	}

	public String[] getArray() {
		return morseArray;
	}

}
