<?php
//Retrieve the records sent in on the query string
//Get request is expected. Two parameters are sr (for starting record) and c (for count)
//if sr not sent then default to 1. If c not sent, default to 25, 
//if c negative, send records from -c to sr. That is sr will be the last record retrieved.

$startRecord = isset($_GET['sr']) ? (int) ($_GET['sr']): 1;
$numRecords = isset($_GET['c']) ? (int)($_GET['c']) : 25;
if (($numRecords == 0) or ($numRecords > 50))  $numRecords = 25 ;

$endRecord = $startRecord + abs($numRecords) - 1;

if ($numRecords < 0) {
	$endRecord = $startRecord;
	$startRecord = $endRecord + $numRecords + 1;
	$numRecords *= -1;
}

// echo $startRecord + '<br/>';
// echo $numRecords + '<br/>';
// echo $endRecord + '<br/>';


//Open the file. Note that it is in the subfolder files
$getFile="./files/users.xml";

//Load the entire XML file
$myXml = simplexml_load_file($getFile) or die("Error: Cannot get file");

//Create start of return String
$returnString = "<users>";
$count = 0;
//Loop through add display the records only when the id is in the range
foreach($myXml->children() as $items) {
	$count++;
	if (($count >= $startRecord) and ($count <= $endRecord) ) {
		// //echo $items->asXML();
		$returnString .= $items->asXML();
	}
}
//Add final closing tag to XML
$returnString .= "</users>";

//Set the header so XML is returned
header("Content-Type: text/xml");
header("Cache-Control: no-cache");
header("Content-Length: " . strlen($returnString));
echo $returnString;

?>