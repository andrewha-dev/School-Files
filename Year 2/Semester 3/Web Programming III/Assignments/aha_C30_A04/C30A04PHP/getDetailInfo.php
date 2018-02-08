<?php
/**
 * Created by PhpStorm.
 * User: 1435792
 * Date: 12/1/2016
 * Time: 12:03 PM
 */
$whichList = $_GET['id'];
$returnString = "";





$listJson = "./List/SantaList.json";

$myListJsonData = file_get_contents($listJson) or die("Error: Cannot get files.");

$jsonAssArr = json_decode($myListJsonData, true);
$numberOfChildrenSize = 0;
$numberOfChildren = 0;
$contentString = "";
foreach($jsonAssArr as $values)
{
    foreach($values as $moreValues)
    {
        if ($moreValues['-id'] == $whichList)
        {
            $returnString .= (json_encode($moreValues, JSON_PRETTY_PRINT));
            $numberOfChildrenSize += strlen(json_encode($moreValues, JSON_PRETTY_PRINT));
            $numberOfChildren++;
        }
    }
}


header("Content-Length: " . $numberOfChildrenSize);
header("Content-type: " . "application/json");
header("Number-Of-Results: " . $numberOfChildren);
echo $returnString;

?>