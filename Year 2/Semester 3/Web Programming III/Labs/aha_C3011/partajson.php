<?php
/**
 * Created by PhpStorm.
 * User: 1435792
 * Date: 11/30/2016
 * Time: 12:28 PM
 */
$genre = $_GET['genre'];

$albumsJson = "./albums.json";

$myAlbumsJsonData = file_get_contents($albumsJson);

$jsonAssArr = json_decode($myAlbumsJsonData, true);
$numberOfAlbumsSize = 0;
$numberOfAlbums = 0;
$contentString = "";
foreach($jsonAssArr as $values)
{
    foreach($values as $moreValues)
    {
        if ($moreValues['genre'] == $genre)
        {
            print_r(json_encode($moreValues, JSON_PRETTY_PRINT));
            $numberOfAlbumsSize += strlen(json_encode($moreValues, JSON_PRETTY_PRINT));
            $numberOfAlbums++;
        }
    }
}
echo $numberOfAlbumsSize;

header("Content-Length: " . $numberOfAlbumsSize);
header("Content-type: " . "application/json");
header("Number-Of-Albums: " . $numberOfAlbums);
//var_dump($jsonAssArr['album']);






?>