package B31_L08_stacks;

import junit.framework.TestCase;

public class PalindromeTest
  extends TestCase
{
  public PalindromeTest(String sTestName)
  {
    super(sTestName);
  }

  /**
   * @see Palindrome#isPalindrome(String)
   */
  public void testIsPalindrome()
  {
    Palindrome pal = new Palindrome();
    assertTrue("Test case 1: Valid palindrome, no special characters", 
               pal.isPalindrome("pap"));
    assertTrue("Test case 2: Valid palindrome, no special characters - uppercase", 
               pal.isPalindrome("PAP"));
    assertFalse("Test case 3: Invalid palindrome, no special characters", 
                pal.isPalindrome("dog"));
    assertTrue("Test case 4: Valid palindrome, with spaces", 
               pal.isPalindrome("Able was I ere I saw Elba"));
    assertTrue("Test case 5: Valid palindrome, with special characters", 
               pal.isPalindrome("Madam I'm Adam"));
    assertFalse("Test case 6: Invalid palindrome, with spaces and special characters", 
                pal.isPalindrome("Java Java Java - you're the best!"));
  }

}
