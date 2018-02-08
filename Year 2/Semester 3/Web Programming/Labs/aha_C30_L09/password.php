<?php
/**
 * Created by PhpStorm.
 * User: 1435792
 * Date: 11/9/2016
 * Time: 11:24 AM
 */
$pass = array("Abcdefg!", "ABCDEF9!", "abcdef9!", "Abcd e9", "Abcdefg9",
    "Abcdefgh98765432!", "Abcde9!", "Abcdef9!", "Abcdefg987654!!", "!9fedcbA");


?>
<html lang="en">
<head>
    <link rel="stylesheet" type="text/css" href="./styles/palindrome.css" ;
    <meta charset="UTF-8">
    <title>Testing Passwords</title>
</head>
<body>
<h1>Palindrome Test</h1>
<table>
    <tr>
        <th>Password</th>
        <th>Password Rating</th>
    </tr>
    <?php
    foreach ($pass as $value)
    {
        $errMessage = "";
        echo "<tr>";
        echo "<td>$value</td>";

        if (checkForANumber($value) == 0) {
            $errMessage .= 'The password is missing a number <br>';
        }
        if (checkForLowerCase($value) == 0) {
            $errMessage .= 'The password is missing a lowercase letter <br>';
        }
        if (checkForUpperCase($value) == 0) {
            $errMessage .= 'The password is missing an uppercase letter <br>';
        }
        if (checkForWhiteSpace($value) != 0) {
            $errMessage .= 'The password has a space in it <br>';
        }
        if (checkForSymbol($value) == 0) {
            $errMessage .= 'The password needs a non-alphanumeric character<br>';
        }
        if (checkForMinCharacters($value) < 8) {
            $errMessage .= 'The password needs to be 8 characters long<br>';
        }
        if (checkForMinCharacters($value) > 16) {
            $errMessage .= 'The password is too long<br>';
        }
        


        if (strlen($errMessage) == 0)
        {
            echo "<td>No issues with the password</td>";
        }
        else {
            echo "<td>$errMessage</td>";
        }

        echo "</tr>";
    }


    ?>



</table>

</body>
</html>

<?php
function checkForANumber(String $value){
    return preg_match('/\d/', $value);
}
function checkForLowerCase(String $value){
    return preg_match('/[a-z]/', $value);
}
function checkForUpperCase(String $value){
    return preg_match('/[A-Z]/', $value);
}
function checkForWhiteSpace(String $value){
    return preg_match('/\s/', $value);
}
function checkForSymbol(String $value){
    return preg_match('/[^A-Za-z0-9]/', $value);
}
function checkForMinCharacters(String $value){
    return strlen($value);
}


?>
