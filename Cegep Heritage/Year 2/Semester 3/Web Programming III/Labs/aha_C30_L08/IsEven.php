<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Part2A</title>
</head>
<body>
<?php
$array = array(4, 5, "100", "101", "third", "22nd", 23.2, 25.8, "Fantastic4", 0);
$evenNumbers = 0;
$oddNumbers = 0;
$realNumbers = 0;
$nonNumbers = 0;

foreach ($array as $value)
{
    if (is_numeric($value) == false)
    {
        echo "<p>The value in the array: ".$value. " Is Not Numeric";
        $nonNumbers++;
    }
    else {
        $realNumbers++;
        $roundedValue = round($value);
        if ($roundedValue % 2 == 0)
        {
            $evenNumbers++;
            echo "<p>The value in the array: ".$value. " Is A Number And Is Even";
        }
        if ($roundedValue % 2 != 0)
        {
            $oddNumbers++;
            echo "<p>The value in the array:  ".$value. " Is A Number And Is Odd";
        }
    }
}

echo "<p>The amount of non numeric numbers ". $nonNumbers ."</p>";
echo "<p>The amount of real numbers ". $realNumbers ."</p>";
echo "<p>The amount of even numbers ". $evenNumbers ."</p>";
echo "<p>The amount of odd numbers ". $oddNumbers ."</p>";


?>

</body>
</html>