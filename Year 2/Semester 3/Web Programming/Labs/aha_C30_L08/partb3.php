<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Part 3A</title>
</head>
<body>
<?php

sumProdHighLow("+",1,2,3,4,5,6);
sumProdHighLow("*",1,2,3,4);
sumProdHighLow(">",-10, 19,23,14,35,0,10,4);
sumProdHighLow("<", -10, 19, 23, -14, 35, 0, 10, 4, 8, 12);
sumProdHighLow("*", 10, 2, -5, "2", 11);

    function sumProdHighLow($operator, ...$numbers){
        echo ("<h1>The list of numbers </h1>");
        for ($j = 0; $j < count($numbers); $j++)
        {
            echo "<span>".$numbers[$j].", </span>";
        }
        if ($operator == "+") {

            $total = 0;
            echo "<h2>The + Operator is being used</h2>";
            for ($j = 0; $j < count($numbers); $j++)
            {
                $total += $numbers[$j];
            }
            echo "The array sum is $total";
            }
        if ($operator == "*") {
            $total = 1;
            echo "<h2>The * Operator is being used</h2>";
            for ($j = 0; $j < count($numbers); $j++)
            {
                $total *= $numbers[$j];
            }
            echo "The array product is $total";
        }
        if ($operator == ">") {

            echo "<h2>The > Operator is being used</h2>";
            $biggest = $numbers[0];
            for ($j = 0; $j < count($numbers); $j++)
            {
                if ($biggest < $numbers[$j])
                {
                    $biggest = $numbers[$j];
                }
            }
            echo "The array max number is $biggest";
        }
        if ($operator == "<") {

            echo "<h2>The < Operator is being used</h2>";
            $smallest = $numbers[0];
            for ($j = 0; $j < count($numbers); $j++)
            {
                if ($smallest > $numbers[$j])
                {
                    $smallest = $numbers[$j];
                }
            }
            echo "The array smallest number is $smallest";

        }

    }
 ?>


</body>


