<?php
/**
 * Created by PhpStorm.
 * User: 1435792
 * Date: 11/9/2016
 * Time: 11:24 AM
 */
$palindrome = array("racecar noon civic noon racecar",
    "Aerate pet area", "I, man, am regal: a German am I", "Mr. Owl ate my metal worm."
, "A man, a plan, a cat, a ham, a yak, a yam, a hat, a canal-Panama!", "Sh!, Tom sees moths"
, "driveway", "Web Programming III", "Palindrome")


?>
<html lang="en">
<head>
    <link rel="stylesheet" type="text/css" href="./styles/palindrome.css" ;
    <meta charset="UTF-8">
    <title>Palindrome</title>
</head>
<body>
<h1>Palindrome Test</h1>
<table>
    <tr>
        <th>Test Word/Phrase</th>
        <th>Standard</th>
        <th>Perfect</th>
    </tr>
    <?php
    foreach ($palindrome as $value)
    {
        echo "<tr>";
        echo "<td>" . $value ."</td>";
        echo "<td>" . (checkIfPalindromePerfect($value) == 0 ? "Yes" : "No"). "</td>";
        echo "<td>" . (checkIfPalindromeStandard($value) == 0 ? "Yes" : "No"). "</td>";
        echo "</tr>";
    }

    ?>


</table>

</body>
</html>

<?php
function checkIfPalindromePerfect(String $value):bool
{
 $toCompare = preg_replace('/\s/', '', $value);
    return strcasecmp($toCompare, strrev($toCompare));
}

function checkIfPalindromeStandard(String $value):bool
{
    $toCompare = preg_replace("/[^a-zA-Z]/", "", $value);
    return checkIfPalindromePerfect($toCompare);
}


?>
