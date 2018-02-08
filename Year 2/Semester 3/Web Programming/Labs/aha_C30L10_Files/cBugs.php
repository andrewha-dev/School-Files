<?php

$display = true;
$product = "";
$version = "";
$typeOfHardware = "";
$operatingSystem = "";
$description = "";
$selectedBug = "";
if (isset($_POST['update']))
{
    if ($_POST['bugNum'] != "") {
        $theBugNumber = $_POST['bugNum'];
        $theString = file_get_contents("./bugData/$theBugNumber.txt");
        $selectedBug = $theBugNumber;

        $updateValuesArray = explode("~", $theString);

        $product = $updateValuesArray[0];
        $version = $updateValuesArray[1];
        $typeOfHardware = $updateValuesArray[2];
        $operatingSystem = $updateValuesArray[3];
        $description = $updateValuesArray[4];


    }


}

if (isset($_POST['submit']))
{
    //Getting the value of the selected text file
    $bugNum = $_POST['bugNum'];

    $bugString = $_POST['prodname'] . "~" . $_POST['version'] . "~" . $_POST['typeOfHardware']
    . "~" . $_POST['os'] . "~" . $_POST['desc'] . "\r\n";

    $display = false;
    //Checking to see if a bug report already exists
    if (file_exists("./bugData/".$bugNum.".txt")){
     file_put_contents("./bugData./$bugNum.txt", $bugString);
        echo "<h1>$bugNum.txt has been updated</h1>";
    }
    else {
        //Getting the next bug number
        $nextBugNumber = file_get_contents("./bugNumber/bugNumber.txt");



        $newNumber = $nextBugNumber + 1;
        file_put_contents("./bugNumber/bugNumber.txt", $newNumber);

        //Creating new text file
        file_put_contents("./bugData./$nextBugNumber.txt", $bugString);

        echo "<h1>$nextBugNumber.txt has been successfully created</h1>";
    }

}




if ($display) {
    ?>
    <!doctype html>

    <html lang="en">
    <head>
        <meta charset="utf-8">
        <title>Part C</title>
    </head>

    <body>
    <form action="cBugs.php"  method="POST">
        <p>
            <label for="prodname">Product Name:</label>
            <input type="text" name="prodname" value="<?php echo $product?>">
        </p>
        <p>
            <label for="version">Version:</label>
            <input type="text" name="version" value="<?php echo $version?>">
        </p>
        <p>
            <label for="typeOfHardware">Type Of Hardware:</label>
            <input type="text" name="typeOfHardware" value="<?php echo $typeOfHardware?>">
        </p>
        <p>
            <label for="os">Operating System:</label>
            <input type="text" name="os" value="<?php echo $operatingSystem?>">
        </p>
        <p>
            <label for="desc">Description:</label>
            <input type="text" name="desc" value="<?php echo $description?>">
        </p>
        <p>
            <label for="bugNum">Create a new report or update a bug</label>
            <select name ='bugNum'>
                <option value ="">New Bug Report</option>
                <?php
                $theBugFiles = scandir("./bugData");
                $theNumber = "";
                foreach($theBugFiles as $theValue)
                {
                   $isANumber = ((explode(".", $theValue)));
                    if (is_numeric($isANumber[0]))
                    {
                        if ($selectedBug == $isANumber[0])
                            echo "<option selected value='$isANumber[0]'>$isANumber[0].txt</option>";
                        else
                        echo "<option value='$isANumber[0]'>$isANumber[0].txt</option>";
                    }
                }
                ?>
            </select>
            <input type="submit" name="update" value="Update">
        </p>
        <p>
            <input type="submit" name="submit" value="Submit">
        </p>
    </form>


    </body>
    </html>
    <?php
}
?>
