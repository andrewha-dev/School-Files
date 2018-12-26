<?php
/**
 * Created by PhpStorm.
 * User: 1435792
 * Date: 12/1/2016
 * Time: 12:03 PM
 */
 $which = $_GET['which'];
$returnString = "";

$listCharactersToChar = array("naughty" => "N", "nice" => "G", "unknown"=> "U", "limbo" => "L");
$whichList=$listCharactersToChar[$which];


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
        if ($moreValues['curList'] == $whichList)
        {
            $tempArray = $moreValues;
            //Removing the elements that we do not want
            unset($tempArray['curList']);
            unset($tempArray['age']);
            unset($tempArray['details']);

            $returnString .= (json_encode($tempArray, JSON_PRETTY_PRINT));
            $returnString .= ",";
            $numberOfChildrenSize += strlen(json_encode($tempArray, JSON_PRETTY_PRINT));
            $numberOfChildrenSize += strlen(",");
            $numberOfChildren++;
        }
    }
}


header("Content-Length: " . $numberOfChildrenSize - 1);
header("Content-type: " . "application/json");
header("Number-Of-Results: " . $numberOfChildren);
//Removing extra comma from string;
$returnString = substr_replace($returnString ,"",-1);
echo $returnString;

?>