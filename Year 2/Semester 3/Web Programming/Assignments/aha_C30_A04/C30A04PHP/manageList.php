<?php
/**
 * Created by PhpStorm.
 * User: 1435792
 * Date: 11/29/2016
 * Time: 10:28 AM
 */
//Variable to display the form or not
$display = true;
$displayErrors = false;
//Variables what is sent from the POST
$newEntry = "";
$personID = "";
$firstName = "";
$lastName = "";
$age = "";
$curList = "";
$city = "";
$details = "";
$nextBugNumber = -1;
$updateOrNew = "";
$jsonDataForSelectedInner = "";
$jsonDataForUpdateInner = "";
$arrayCounter = 0;
$lastModified = "";

//Associative Array
$myErrors = array('First Name' => "", 'Last Name' => "",
    'Last Name' => "", 'Age' => "", 'Current List' => "",'City'=> "", 'Details' => "");

$myErrorsString = "";

//If a post method was called by the update button
if (isset($_POST['update']))
{
    $idToDisplay =  $_POST['personID'];
    $updateOrNew = "updated.";
    $jsonDataSelected = file_get_contents("./List/SantaList.json");
    $jsonDataSelected = json_decode($jsonDataSelected, true);
    $jsonDataForSelectedInner = $jsonDataSelected['person'];

    //Going through the person first
    foreach($jsonDataForSelectedInner as $values)
    {
        //Traversing through each individual person
        if ($values['-id'] == $idToDisplay)
        {
//            var_dump($values);
//            echo "Match";
            $personID = $values['-id'];
            $firstName = $values['firstName'];
            $lastName = $values['lastName'];
            $age = $values['age'];
            $curList = $values['curList'];
            $city = $values['city'];
            $details = $values['details'];
        }
        $arrayCounter++;
    }


    //Going to the form and filling in the fields
    $display = true;
}



//If a post method was called by the submit button
if (isset($_POST['submit'])) {
    $display = false;
    $newEntry = $_POST['personID'];
    $firstName = $_POST['firstName'];
    $lastName = $_POST['lastName'];
    $age = $_POST['age'];
    $curList = $_POST['curList'];
    $city = $_POST['city'];
    $details = $_POST['details'];


    //Verifying if the fields are all correct
    $myErrors = checkEmptyFields($myErrors, $_POST);
    //Verifying that the age entered is numeric
    if (!is_numeric($age) && $age != "")
        $myErrors['Age'] = "<ul>The age must be numeric</ul>";

    //Running a foreach loop to check if there are errors

    foreach ($myErrors as $theValues => $data) {
        if (!empty($data)) {
            $display = true;
            $displayErrors = true;
        }
    }

    if ($newEntry == "New") {

        //If its a new entry assign a new number
        if ($newEntry == "New" && $displayErrors == false) {
            $updateOrNew = "added.";
            $nextBugNumber = file_get_contents("./personIDNumber/personIDNumber.txt");
            $personID = $nextBugNumber;

            //Incrementing the next number from the personIDNumber.txt
            file_put_contents("./personIDNumber/personIDNumber.txt", ++$nextBugNumber);

            //Getting the time to set the last modified
            $lastModified = date('F j, Y, g:i a');


            //Writing to the JSON file
            $jsondata = file_get_contents("./List/SantaList.json");
            $jsondata = json_decode($jsondata, true);
            $newJSONEntry = array("-id" => $personID, "lastName" => $lastName,
                "firstName" => $firstName, "age" => $age, "curList" => $curList,"city" => $city, "details" => $details, "dateUpdated" => $lastModified);
            array_push($jsondata['person'], $newJSONEntry);
            $jsondata = json_encode($jsondata, JSON_PRETTY_PRINT);
            file_put_contents("./List/SantaList.json", $jsondata);
            $display = false;


        }
    }
    $myErrorsString = implode($myErrors);




    if ($newEntry != "New" && $displayErrors == false)
    {
        //Needs to update the JSON file
        $updateOrNew = "updated.";
        $jsonDataForUpdate = file_get_contents("./List/SantaList.json");
        $jsonDataForUpdate = json_decode($jsonDataForUpdate, true);

        $personID = $_POST['personID'];
        $firstName = $_POST['firstName'];
        $idToDisplay = $_POST['personID'];


        foreach($jsonDataForUpdate['person'] as $values)
        {
            //Traversing through each individual person
            if ($values['-id'] == $idToDisplay)
            {
                $lastModified = date('F j, Y, g:i a');
                $updatedEntry = array("-id" => $personID, "lastName" => $lastName,
                    "firstName" => $firstName, "age" => $age, "curList" => $curList,
                    "city" => $city,
                    "details" => $details, "dateUpdated" => $lastModified);

                $jsonDataForUpdate['person'][$arrayCounter] = $updatedEntry;

                $jsonDataForUpdate = json_encode($jsonDataForUpdate, JSON_PRETTY_PRINT);
                file_put_contents("./List/SantaList.json", $jsonDataForUpdate);
            }
            $arrayCounter++;
        }



    }

}


if ($display) {
    ?>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Manage List</title>
        <link href="styles/manageList.css" rel="stylesheet" type="text/css">
    </head>
    <body>
    <h1 class="header">Manage List</h1>
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
        <form id="theForm" method="post" action="./manageList.php">
            <p>
                <label for="personID">Add or Update an Entry:</label>
                <select name="personID" id="personID" class="">
                    <option value="New">Add A New Entry</option>
                    <?php
                    $jsonDataForUpdate = file_get_contents("./List/SantaList.json");
                    $jsonDataForUpdate = json_decode($jsonDataForUpdate, true);
                    $jsonDataForUpdateInner = $jsonDataForUpdate['person'];

                    //Going through the person first
                    foreach($jsonDataForUpdate as $values)
                    {
                        //Traversing through each individual person
                        foreach($values as $moreValues)
                        {
                            $updateID = $moreValues['-id'];
                            $updateFirstName = $moreValues['firstName'];
                            $updateLastName = $moreValues['lastName'];

                            echo "<option " ;
                            if ($personID == $updateID){
                            echo "selected";
                        }
                          echo  " value='$updateID'> ID #".$updateID ." ~ Name: ".$updateFirstName ." " .
                                $updateLastName ."</option>";
                        }
                    }



                    ?>
                </select>
                <br>
                <br>
                <input id="update" type="submit" name="update" value="Update">
            </p>


            <p>
                <label for="firstName">First Name: </label>
                <input id="firstName" name="firstName" class="formInput  <?php
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
                <label for="age">Age: </label>
                <input id="age" name="age" class="formInput <?php
                echo (strlen($myErrors['Age'])) == 0 ? "" : "inputError";
                ?>" value="<?php
                echo $age;
                ?>">
            </p>
            <p>
                <label for="curList">Current List: </label>
                <select id="curList" name="curList" class="<?php
                echo (strlen($myErrors['Current List'])) == 0 ? "" : "inputError";
                ?>">
                    <option value=""> -- Select An Option --</option>
                    <option <?php
                    if ($curList == "G")
                        echo "selected";
                    ?> value="G">Good</option>
                    <option <?php
                    if ($curList == "N")
                        echo "selected";
                    ?>  value="N">Naughty</option>
                    <option <?php
                    if ($curList == "L")
                        echo "selected";
                    ?>  value="L">Limbo</option>
                    <option <?php
                    if ($curList == "U")
                        echo "selected";
                    ?>  value="U">Unknown</option>
                </select>
            </p>
            <!--Add For Date and also add for City -->
            <p>
                <label for="city">City</label>
                <input id="city" name="city" class="formInput  <?php
                echo (strlen($myErrors['City'])) == 0 ? "" : "inputError";
                ?>" value="<?php
                echo $city;
                ?>">
            </p>

            <p>
                <label for="details">Details: </label>
                <input id="details" name="details" class="formInput <?php
                echo (strlen($myErrors['Details'])) == 0 ? "" : "inputError";
                ?>" value="<?php
                echo $details;
                ?>">
            </p>
            <input type="submit" name="submit" value="Add/Update">
            <input type="submit" name="cancel" value="Cancel">

        </form>
    </div>
    </body>
    </html>


    <?php
}
else {
    ?>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Manage List</title>
        <link href="styles/manageList.css" rel="stylesheet" type="text/css">
    </head>
    <body>
    <h1 class="header">Account <?php echo $updateOrNew?></h1>
    <div class="postPOSTDiv">
        <?php
    echo " ID# $personID $firstName $lastName,";
?> your list entry has been succesfully <?php echo $updateOrNew ?><br><br>
    <a class="continue" href="./manageList.php">Continue</a>
    </div>
    </body>
    </html>



    <?php
}
?>


<?php
//PHP Functions
function checkEmptyFields($myErrors, $_thePOST)
{
    //Checking if certain fields are empty
    if (empty($_thePOST['firstName']))
        $myErrors['First Name'] = "<ul>First Name Field is Empty</ul>";
    if (empty($_thePOST['lastName']))
        $myErrors['Last Name'] = "<ul>Last Name Field is Empty</ul>";
    if (empty($_thePOST['age']))
        $myErrors['Age'] = "<ul>Age Field is Empty</ul>";
    if (empty($_thePOST['curList']))
        $myErrors['Current List'] = "<ul>A List Has Not Been Selected</ul>";
    if (empty($_thePOST['city']))
        $myErrors['City'] = "<ul>City Field is Empty</ul>";
    if (empty($_thePOST['details']))
        $myErrors['Details'] = "<ul>Details Field is Empty</ul>";

    return $myErrors;
}
?>
 