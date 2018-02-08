<?php
//Open the file. Note that it is in the subfolder files
$getFile="./files/albums.xml";

//Get the values posted from the page
$genre=$_POST["genre"];
$albumName = $_POST["albumName"];
$artist = $_POST["artist"];
$company = $_POST["company"];
$condition = $_POST["condition"];
$year = $_POST["year"];
$price = $_POST["price"];

if ( ($genre=="") || ($albumName=="") || ($artist == "") || 
   ($company == "") || ($condition == "") || ($year == "") ||
   ($price == "") ) {
	   echo "Error in data sent";
   } else {
		//Load the entire XML file
		$myXml = simplexml_load_file($getFile) or die("Error: Cannot get file");

		$newAlbum = $myXml->addChild('album');
		$newAlbum->addAttribute("genre", $genre);

		$newAlbum->addChild('albumName', $albumName);
		$newAlbum->addChild('artist', $artist);
		$newAlbum->addChild('company', $company);
		$newAlbum->addChild('condition', $condition);
		$newAlbum->addChild('year', $year);
		$newAlbum->addChild('price', $price);

		$myXml->asXML($getFile);
		echo "Successful add";
   }
?>