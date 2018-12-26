<?php
//Retrieve the genre sent in on the query string
//NOTE: The genre MUST be exactly as it was read from the file
//		genres.txt. That is, starts with an uppercase and the remaining
//		are lowercase.
$genre=$_GET["genre"];

//Open the file. Note that it is in the subfolder files
$getFile="./files/albums.xml";

//Load the entire XML file
$myXml = simplexml_load_file($getFile) or die("Error: Cannot get file");

//Create start of return String
$returnString = "<albums>";

//Loop through add display the album records only when the attribute of
//parent is the same as the genre sent in.
foreach($myXml->children() as $items) {
	if ($items->attributes() == $genre) {
		//echo $items->asXML();
		$returnString .= $items->asXML();
	}
}
//Add final closing tag to XML
$returnString .= "</albums>";

//Set the header so XML is returned
header("Content-Type: text/xml");
header("Cache-Control: no-cache");
header("Content-Length: " . strlen($returnString));
echo $returnString;

?>