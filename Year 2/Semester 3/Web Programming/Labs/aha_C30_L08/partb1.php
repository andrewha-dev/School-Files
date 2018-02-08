<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Part 3A</title>
</head>
<body>
<?php
require('./myfunctions.php');
checkValues(13,3);
checkValues(12,3);
checkValues("12",3);
checkValues(12,"3");
checkValues("cat","dog");
checkValues(12,0);

theRange(3, 10, 2);
theRange(1, 100, 7);
theRange(1, 5, 1);
theRange("dog", "cat", "horse");




function checkValues($val1, $val2)
{
    if (is_numeric($val1) == true && is_numeric($val2) == true)
    {
        if (evenlyDivded($val1, $val2))
        {
            echo "<p>$val1 can be divided by $val2</p>";
        }
        else {
            echo "<p>$val1 cannot be divided by $val2</p>";
        }
    }
    else {
        echo "<p>One of the values isnt numeric</p>";
    }

}

function theRange($val1, $val2, $divide)
{
    echo "<h1>Checking the values of $val1, $val2 $divide</h1>";
   $theArrFromFunction = checkRange($val1, $val2, $divide);
    for ($j = 0; $j < sizeOf($theArrFromFunction); $j++)
    {
        echo "<p>$theArrFromFunction[$j]</p>";
    }

}



?>

</body>