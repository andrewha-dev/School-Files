package aha_B31_Final_Project;

import static org.junit.Assert.*;

import org.junit.Test;

public class MorseCodeTreeTest {

	@Test
	public void testIndividualDecodeMorse() {
		MorseCodeTree tree = new MorseCodeTree();
		assertEquals("a", tree.decode(".-"));
		assertEquals("b", tree.decode("-..."));
		assertEquals("c", tree.decode("-.-."));
		assertEquals("d", tree.decode("-.."));
		assertEquals("e", tree.decode("."));
		assertEquals("f", tree.decode("..-."));
		assertEquals("g", tree.decode("--."));
		assertEquals("h", tree.decode("...."));
		assertEquals("i", tree.decode(".."));
		assertEquals("j", tree.decode(".---"));
		assertEquals("k", tree.decode("-.-"));
		assertEquals("l", tree.decode(".-.."));
		assertEquals("m", tree.decode("--"));
		assertEquals("n", tree.decode("-."));
		assertEquals("o", tree.decode("---"));
		assertEquals("p", tree.decode(".--."));
		assertEquals("q", tree.decode("--.-"));
		assertEquals("r", tree.decode(".-."));
		assertEquals("s", tree.decode("..."));
		assertEquals("t", tree.decode("-"));
		assertEquals("u", tree.decode("..-"));
		assertEquals("v", tree.decode("...-"));
		assertEquals("w", tree.decode(".--"));
		assertEquals("x", tree.decode("-..-"));
		assertEquals("y", tree.decode("-.--"));
		assertEquals("z", tree.decode("--.."));
	}

	@Test
	public void testIndividualEncodeMorse() {
		MorseCodeTree tree = new MorseCodeTree();
		assertEquals(".-", tree.encode("a"));
		assertEquals("-...", tree.encode("b"));
		assertEquals("-.-.", tree.encode("c"));
		assertEquals("-..", tree.encode("d"));
		assertEquals(".", tree.encode("e"));
		assertEquals("..-.", tree.encode("f"));
		assertEquals("--.", tree.encode("g"));
		assertEquals("....", tree.encode("h"));
		assertEquals("..", tree.encode("i"));
		assertEquals(".---", tree.encode("j"));
		assertEquals("-.-", tree.encode("k"));
		assertEquals(".-..", tree.encode("l"));
		assertEquals("--", tree.encode("m"));
		assertEquals("-.", tree.encode("n"));
		assertEquals("---", tree.encode("o"));
		assertEquals(".--.", tree.encode("p"));
		assertEquals("--.-", tree.encode("q"));
		assertEquals(".-.", tree.encode("r"));
		assertEquals("...", tree.encode("s"));
		assertEquals("-", tree.encode("t"));
		assertEquals("..-", tree.encode("u"));
		assertEquals("...-", tree.encode("v"));
		assertEquals(".--", tree.encode("w"));
		assertEquals("-..-", tree.encode("x"));
		assertEquals("-.--", tree.encode("y"));
		assertEquals("--..", tree.encode("z"));
	}

	@Test
	public void testQuickBrownFoxEncode() {
		MorseCodeTree tree = new MorseCodeTree();
		assertEquals(
				"- .... .  --.- ..- .. -.-. -.-  -... .-. --- .-- -.  ..-. --- -..-  .--- ..- -- .--. . -..  --- ...- . .-.  - .... .  .-.. .- --.. -.--  -.. --- --.",
				tree.encode("the quick brown fox jumped over the lazy dog"));
	}

	@Test
	public void testQuickBrownFoxDecode() {
		MorseCodeTree tree = new MorseCodeTree();
		assertEquals("the quick brown fox jumped over the lazy dog", tree.decode(
				"- .... .  --.- ..- .. -.-. -.-  -... .-. --- .-- -.  ..-. --- -..-  .--- ..- -- .--. . -..  --- ...- . .-.  - .... .  .-.. .- --.. -.--  -.. --- --."));
	}

}
