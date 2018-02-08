/**
 * 
 */
package aha_B31_Final_Project;

//importing the linked binarytree from the adts package
import adts.binarytree.*;
//importing the File library
import java.io.File;
import java.io.FileNotFoundException;
import java.util.List;
import java.util.Scanner;

/**
 * @author 1435792
 *
 */
public class MorseCodeTree {
	// Creating a static variable for the file
	public static final String FILENAME = "morseCodeTable.txt";
	// Constructor for creating the Tree
	// Creating the class variable for the tree
	public static LinkedBinaryTree<String> morseCodeTree;

	// Constructor
	public MorseCodeTree() {
		// Creating the morse tree where the root is blank
		morseCodeTree = new LinkedBinaryTree("");
		BinaryTreeNode morseNode = morseCodeTree.root();

		// Reading in the file
		try {
			File morseFile = new File(FILENAME);
			Scanner input = new Scanner(morseFile);

			// While the text file still has more data
			while (input.hasNextLine()) {
				// Resetting the morseNode to the root
				morseNode = morseCodeTree.root();
				String morseLine = input.nextLine();
				// Getting the letter from the file
				String morseLetter = String.valueOf(morseLine.charAt(0));
				// Getting the path from the file
				String morseCode = morseLine.substring(2).trim();

				// Creating the morse code based on the path
				for (int i = 0; i < morseCode.length(); i++) {
					String dashOrDot = String.valueOf(morseCode.charAt(i));
					// If the line is at the last character
					if (i == morseCode.length() - 1) {
						// If the last character of the line is a .
						if (dashOrDot.equals(".")) {
							// Create a left child
							morseCodeTree.makeLeftChild(morseNode, morseLetter);
						}
						// If the last character of the line is a -
						if (dashOrDot.equals("-")) {
							// Create a right child
							morseCodeTree.makeRightChild(morseNode, morseLetter);
						}

					}
					// If the line isnt at the last character
					else {
						// If the path is a left then go to the next left child
						if (dashOrDot.equals(".")) {
							morseNode = morseNode.leftChild();
						}
						// If the path is a right child then go to the next
						// right child
						if (dashOrDot.equals("-")) {
							morseNode = morseNode.rightChild();
						}
					}
				}

			}

		} catch (FileNotFoundException e) {
			e.printStackTrace();
		}
	}

	// Encode method
	public String encode(String _text) {
		String phrase = _text;
		CodeVisitor visit = new CodeVisitor();
		// Creating the array using the visit method
		morseCodeTree.levelOrderTraversal(visit);
		String morseResult = "";

		String[] wordToMorse = phrase.split(" ");

		for (String word : wordToMorse) {
			for (int i = 0; i < word.length(); i++) {
				morseResult += encodeChar(String.valueOf(word.charAt(i))) + " ";
			}
			morseResult += " ";
		}
		morseResult = (morseResult.trim());

		return morseResult;
	}// Encode()

	// Decode method
	public String decode(String _text) {
		String phrase = _text;
		String[] array = phrase.split("\\s{2,2}");
		String newPhrase = "";

		// Loop for each word
		for (String s : array) {
			String[] wordToMorse = s.split(" ");
			for (String t : wordToMorse) {
				newPhrase += decodeChar(t);
			}
			newPhrase += " ";
		}
		// Removing whitespace
		newPhrase = newPhrase.trim();
		return newPhrase;
	}// Decode()

	// Decoding the individual characters
	public String decodeChar(String _path) {
		BinaryTreeNode morseNode = morseCodeTree.root();
		// System.out.println(_path);
		String thePath = _path;
		for (int i = 0; i < thePath.length(); i++) {
			// If it is at the end of the path

			if (thePath.charAt(i) == '.') {
				morseNode = morseNode.leftChild();

			}
			if (thePath.charAt(i) == '-') {
				morseNode = morseNode.rightChild();
			}
			if (i == thePath.length() - 1) {
				return morseNode.element().toString();
			}

		}
		return "";
	}// DecodeChar()

	// Encoding the individual characters
	public String encodeChar(String _path) {
		CodeVisitor visit = new CodeVisitor();
		String[] morseArray = visit.getArray();
		// Getting the ascii value of the char

		char ascii = _path.charAt(0);
		int asciiIndex = (int) ascii;
		asciiIndex -= 97;
		if (Character.isLetter(ascii))
			return morseArray[asciiIndex];
		else
			return "";
	}// encodeChar()

}
