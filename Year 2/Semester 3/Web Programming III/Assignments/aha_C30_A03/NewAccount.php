<?php
/**
 * Created by PhpStorm.
 * User: 1435792
 * Date: 11/7/2016
 * Time: 1:24 PM
 */
//Requiring the external functions
require('./AccountFunctions.inc');
$displayErrors = false;
$display     = true;
//Creating variables to store the information that the user has entered into the form
$firstName   = "";
$lastName    = "";
$street      = "";
$city        = "";
$province    = "";
$postalCode  = "";
$email       = "";
$telephone   = "";
$password    = "";
$confirmPass = "";
//Creating an array for names of my fields
$names       = array(
    'First Name',
    'Last Name',
    'Street',
    'City',
    'Province',
    'Postal Code',
    'Email',
    'Telephone',
    'Password',
    'Confirm Password'
);
//Creating an array in order to store any potential errors
$myErrors    = array(
    'First Name' => "",
    'Last Name' => "",
    'Street' => "",
    'City' => "",
    'Province' => "",
    'Postal Code' => "",
    'Email' => "",
    'Telephone' => "",
    'Password' => "",
    'Confirm Password' => ""
);
//If the request was a submit request then start the validation process
if (isset($_POST['submit'])) {
    //Checking each field to see if they are empty first
    $myErrors      = checkIfFieldsAreEmpty($names, $myErrors, $_POST);
    //Validating specific fields
    $myErrors      = checkIfPassWordsAreTheSame($myErrors, $_POST);
    //Validating the email field
    $myErrors      = checkEmailFormat($myErrors, $_POST);
    //Validating phone number, must be in the format of xxx-xxx-xxxx
    $myErrors      = checkPhoneNumberFormat($myErrors, $_POST);
    //Validating the postal code
    $myErrors      = checkPostalCodeFormat($myErrors, $_POST);
    $display       = false;
    $displayErrors = false;
    //Writing a loop to check to see if there is any errors
    foreach ($myErrors as $key => $value) {
        //If there is an error detected then it will redisplay the form
        if (strlen($value) != 0) {
            $display       = true;
            $displayErrors = true;
        }
    }
    //Setting the variables to what the user has entered
    $firstName      = $_POST['firstName'];
    $lastName       = $_POST['lastName'];
    $street         = $_POST['street'];
    $city           = $_POST['city'];
    $province       = $_POST['province'];
    $postalCode     = strtoupper($_POST['postalCode']);
    $email          = $_POST['email'];
    $telephone      = $_POST['telephone'];
    $password       = $_POST['password'];
    $confirmPass    = $_POST['confirmPass'];
    //Using the implode function to turn $myErrors into a string to display the errors
    $myErrorsString = implode($myErrors);
}
if ($display) {
?>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Create A New Account</title>
        <link href="styles/NewAccount.css" rel="stylesheet" type="text/css">
    </head>
    <body>
    <h1 class="header">Create A New Account</h1>
    <div class="<?php
    echo $displayErrors == true ? "errorsDiv" : "noErrors";
?>">The form cannot be submitted
    <p class="errorsDivP">
        There were some issues with the following fields:
    </p>
    <ul>
        <?php
    echo $myErrorsString;
?>
    </ul>
    </div>
    <div id="formDiv">
        <form id="theForm" method="post" action="./NewAccount.php">
            <p>
                <label for="firstName">First Name: </label>
                <input id="firstName" name="firstName" class="formInput <?php
    echo (strlen($myErrors['First Name'])) == 0 ? "" : "inputError";
?>" value="<?php
    echo $firstName;
?>">
            </p>
            <p>
                <label for="lastName">Last Name: </label>
                <input id="lastName" name="lastName" class="formInput <?php
    echo (strlen($myErrors['Last Name'])) == 0 ? "" : "inputError";
?>" value="<?php
    echo $lastName;
?>">
            </p>
            <p>
                <label for="street">Street: </label>
                <input id="street" name="street" class="formInput <?php
    echo (strlen($myErrors['Street'])) == 0 ? "" : "inputError";
?>" value="<?php
    echo $street;
?>">
            </p>
            <p>
                <label for="city">City: </label>
                <input id="city" name="city" class="formInput <?php
    echo (strlen($myErrors['City'])) == 0 ? "" : "inputError";
?>" value="<?php
    echo $city;
?>">
            </p>
            <p>
                <label for="province">Province: </label>
                <select id="province" name="province" class="<?php
    echo (strlen($myErrors['Province'])) == 0 ? "" : "inputError";
?>">
                    <option <?php
    if ($province == "")
        echo "selected";
?> value = ""> -- Select An Option --</option>
                    <option <?php
    if ($province == "AB")
        echo "selected";
?> value="AB">Alberta</option>
                    <option <?php
    if ($province == "BC")
        echo "selected";
?> value="BC">British Columbia</option>
                    <option <?php
    if ($province == "MB")
        echo "selected";
?> value="MB">Manitoba</option>
                    <option <?php
    if ($province == "NB")
        echo "selected";
?> value="NB">New Brunswick</option>
                    <option <?php
    if ($province == "NL")
        echo "selected";
?> value="NL">Newfoundland and Labrador</option>
                    <option <?php
    if ($province == "NS")
        echo "selected";
?> value="NS">Nova Scotia</option>
                    <option <?php
    if ($province == "ON")
        echo "selected";
?> value="ON">Ontario</option>
                    <option <?php
    if ($province == "PE")
        echo "selected";
?> value="PE">Prince Edward Island</option>
                    <option <?php
    if ($province == "QC")
        echo "selected";
?> value="QC">Quebec</option>
                    <option <?php
    if ($province == "SK")
        echo "selected";
?> value="SK">Saskatchewan</option>
                    <option <?php
    if ($province == "NT")
        echo "selected";
?> value="NT">Northwest Territories</option>
                    <option <?php
    if ($province == "NU")
        echo "selected";
?> value="NU">Nunavut</option>
                    <option <?php
    if ($province == "YT")
        echo "selected";
?> value="YT">Yukon</option>
                </select>
            </p>
            <p>
                <label for="postalCode">Postal Code: </label>
                <input id="postalCode" name="postalCode" class="formInput <?php
    echo (strlen($myErrors['Postal Code'])) == 0 ? "" : "inputError";
?>" value="<?php
    echo $postalCode;
?>">
            </p>
            <p>
                <label for="email">Email: </label>
                <input id="email" name="email" class="formInput <?php
    echo (strlen($myErrors['Email'])) == 0 ? "" : "inputError";
?>" value="<?php
    echo $email;
?>">
            </p>
            <p>
                <label for="telephone">Telephone: </label>
                <input id="telephone" name="telephone" class="formInput <?php
    echo (strlen($myErrors['Telephone'])) == 0 ? "" : "inputError";
?>" value="<?php
    echo $telephone;
?>">
            </p>
            <p>
                <label for="password">Password: </label>
                <input id="password" name="password" class="formInput <?php
    echo (strlen($myErrors['Password'])) == 0 ? "" : "inputError";
?>" type="password" value="<?php
    echo $password;
?>">
            </p>
            <p>
                <label for="confirmPass">Confirm Password: </label>
                <input id="confirmPass" name="confirmPass" class="formInput <?php
    echo (strlen($myErrors['Password'])) == 0 ? "" : "inputError";
?>" type="password" value="<?php
    echo $confirmPass;
?>">
            </p>
            <input class='formInput' type="submit" name="submit" value="Create Account">
            <input class='formInput' type="submit" name="cancel" value="Cancel">
        </form>


    </div>
    </body>
    </html>
    <?php
} //if
//If there are no errors then display the post-POST page
if (!$displayErrors && !$display) {
?>
<html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Create A New Account</title>
        <link href="styles/NewAccount.css" rel="stylesheet" type="text/css">
    </head>
    <body>
    <h1 class="header">Account Created</h1>
    <div class="postPOSTDiv">
        <?php
    echo "$firstName $lastName,";
?> your account has been succesfully created. You are now logged in as a Happy Valley Kennels customer. <br><br>
        <a class="continue" href="./NewAccount.php">Continue</a>
    </div>
    </body>
    </html>

<?php
//Writing the user information to the output file if everything has been validated successfully
//For organization purposes we will be putting the text file in a directory called data
$dirExist = (file_exists("./userOutput"));
if ($dirExist != true) {
    mkdir("userOutput");
}
if ($dirExist) {
    file_put_contents("./userOutput/userData.txt", "$email~$password~$firstName~$lastName~$street~$city~$province~$postalCode~$telephone\r\n", FILE_APPEND);
}
} //If()
?>