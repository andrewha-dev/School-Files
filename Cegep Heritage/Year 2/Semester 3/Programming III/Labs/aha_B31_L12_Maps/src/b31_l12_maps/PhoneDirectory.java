package b31_l12_maps;

public interface PhoneDirectory
{

  /**Load the data file containing the directory
    * pre-condition:  None.
    * post-condition: If a file containing the directory entries exists, the 
    * 								directory is loaded with the data from the file. If the 
    * 								file does not exist, nothing changes.
    */
  void loadData();

  /** Look up an entry
   * @param first The first name of the person to look up
   * @param last The last name of the person to look up
   * @return The phone number or null if the person is not in the directory
   */
  String lookupEntry(String first, String last);

  /** Add an entry 
   * @param first The first name of the person to add 
   * @param last The last name of the person to add
   * @param number The phone number of the person to add 
   * @return  true if the add was successful
   *          false if the person is already in the phone directory
   */
  boolean addEntry(String first, String last, String number);

  /** Change the phone number for an entry
   * @param first The first name of the person to change 
   * @param last The last name of the person to change
   * @param number The new phone number of the person to change
   * @return The old number
   */
  String changeEntry(String first, String last, String number);
  
  /**
   * @param first The first name of the person to remove
   * @param last The last name of the person to remove
    * @return The current number or null if the the person is not in the directory
   */
  String removeEntry(String first, String last);

  /** Method to save the directory
   * pre-condition:   The directory has been loaded with data.
   * post-condition:  Contents of the directory are written back to the file in 
   *                  the form of firstname~lastname~number
   */
  void save();
}
