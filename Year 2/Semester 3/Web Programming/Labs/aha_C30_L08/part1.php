<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Part1A</title>
</head>
<body>
<?php

$ReturnValue = 2 == 3;
echo "<p>The operation we are doing: 2 == 3 : Our value returned is :" . $ReturnValue . "</p>";
$ReturnValue = "2" + "3";
echo "<p>The operation we are doing '2' + '3' Our value returned is : " . $ReturnValue . "</p>";
$ReturnValue = 2>= 3;
echo "<p>The operation we are doing 2>=3 : Our value returned is :" . $ReturnValue . "</p>";
$ReturnValue = 2<= 3;
echo "<p>The operation we are doing 2<=3 : Our value returned is :" . $ReturnValue . "</p>";
$ReturnValue = 2 + 3;
echo "<p>The operation we are doing 2 + 3 : Our value returned is: " . $ReturnValue . "</p>";
$ReturnValue = (3>=2)&&(2>3);
echo "<p>The operation we are doing (3>=2)&&(2>3) : Our value returned is:" . $ReturnValue . "</p>";
$ReturnValue = (3>=2)||(2>3);
echo "<p>The operation we are doing (3>=2)||(2>3) : Our value returned is:" . $ReturnValue . "</p>";
?>

</body>
</html>
