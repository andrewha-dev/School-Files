<?php
/**
 * Created by PhpStorm.
 * User: 1435792
 * Date: 11/7/2016
 * Time: 1:24 PM
 */
//Creating an array of the names
$errors = array('firstName' => "", 'lastName' => "", 'totalSales' => "");

$display = true;
$firstName = "";
$lastName = "";
$totalSales = "";
//If the request was a submit request then start the validation process
if (isset($_POST['submit'])) {

    $firstName = $_POST['firstName'];
    $lastName = $_POST['lastName'];
    $totalSales = $_POST['totalSales'];

    $commissionRate = findCommissionPercentage($totalSales);

    $totalSalesAndCommission = $totalSales * $commissionRate;



    //If the first name is missing
    if (checkEmptyFields($firstName) != 0){
        $errors['firstName'] .= "First Name must be filled in";
    }
    if (checkEmptyFields($lastName) != 0)
    {
        $errors['lastName'] .= "Last Name must be filled in";
    }
    if (checkEmptyFields($totalSales)!= 0)
    {
        $errors['totalSales'] .= " Sales must be filled in";
    }
    if (checkForNumbers($firstName) != 0)
    {
        $errors['firstName'] .= "No Numbers allowed";
    }
    if (checkForNumbers($lastName) != 0)
    {
        $errors['lastName'] .= "No Numbers allowed";
    }
    if (checkNumeric($totalSales) == 0)
    {
        $errors['totalSales'] .=  " Total sales are not numeric";
    }
    if ($totalSales <= 0)
    {
        $errors['totalSales'] .=  " You have not entered a number above 0";
    }

    if (empty($errors['firstName']) && empty($errors['lastName']) && empty($errors['totalSales']))
    {
        $display = false;
    }














    //Setting whether or not to display the form based on the validation
//    $display = false;
    if ($display == false) {
        echo "<h1>$firstName " . " " . "$lastName" . " has a total commission of $ $totalSalesAndCommission </h1>";
        echo "<a href='./commission.php'>Add another employee/commission</a>";
    }

}


if ($display) {
    ?>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Commission</title>
        <link href="styles/NewAccount.css" rel="stylesheet" type="text/css">
    </head>
    <body>
    <h1 class="header">Create A New Account</h1>
    <div id="formDiv">
        <form id="theForm" method="post" action="./commission.php">
            <p>
                <label for="firstName">First Name: </label>
                <input type="text" id="firstName" name="firstName" class="formInput" value="<?php echo $firstName ?>"/>
                <?php echo "<span class='error'>" . $errors['firstName'] .  "<span/>"?>

            </>
            <p>
                <label for="lastName">Last Name: </label>
                <input id="lastName" name="lastName" class="formInput" value="<?php echo $lastName ?>"/>
                <?php echo "<span class='error'>" . $errors['lastName'] .  "</span>"?>
            </p>
            <p>
                <label for="totalSales">Total Sales: </label>
                <input id="totalSales" name="totalSales" class="formInput" value="<?php echo $totalSales ?>"/>
                <?php echo "<span class='error'>" . $errors['totalSales'] .  "</span>"?>
            </p>

            <input type="submit" name="submit" value="Submit Now"/>

        </form>


    </div>
    </body>
    </html>
    <?php
}

function checkEmptyFields(String $value):bool{
    return empty($value);
}

function checkForNumbers(String $value):bool{
    return preg_match('/\d/', $value);
}

function findCommissionPercentage(String $value)
{
    if ($value < 200)
    {
        return 0;
    }
    if ($value >= 200 && $value <= 499)
    {
        return .02;
    }
    if ($value >= 500 && $value <= 749)
    {
        return .03;
    }
    if ($value >= 750 && $value <= 999)
    {
        return .05;
    }
    if ($value >= 1000 && $value <= 1499)
    {
        return .07;
    }
    else {
        return .11;
    }
}

function checkNumeric(String $value){
    return (is_numeric($value));
}








?>