<?php
/**
 * Created by PhpStorm.
 * User: 1435792
 * Date: 11/30/2016
 * Time: 1:46 PM
 */
require("./Change.php");


$display = true;

if (isset($_POST['submit']))
{
    $cost = $_POST['cost'];
    $tender = $_POST['tender'];
     $change = new Change($cost, $tender);

    $theAmount = $change->getChange();

    //    echo $change->getFifties();
    echo "<h1>Change Due: $ " . Round(20 * $theAmount, 0) / 20 . "</h1>";

    $change->setFifties($change->numberBack($theAmount, 50));


    $theAmount = $change->getChange();
    $change->setTwenties($change->numberBack($theAmount, 20));

    $theAmount = $change->getChange();
    $change->setTens($change->numberBack($theAmount, 10));


    $theAmount = $change->getChange();
    $change->setFives($change->numberBack($theAmount, 5));

    $theAmount = $change->getChange();
    $change->setToonies($change->numberBack($theAmount, 2));

    $theAmount = $change->getChange();
    $change->setLoonies($change->numberBack($theAmount, 1));

    $theAmount = $change->getChange();
    $change->setQuarters($change->numberBack($theAmount, 0.25));

    $theAmount = $change->getChange();
    $change->setDimes(($change->numberBack($theAmount, 0.10)));

    $theAmount = $change->getChange();
    $change->setNickels(($change->numberBack($theAmount, 0000.0500)));
    
    










    echo "<p>$50s: " . $change->getFifties() . "</p>";
    echo "<p>$20s: " . $change->getTwenties() . "</p>";
    echo "<p>$10s: " . $change->getTens() . "</p>";
    echo "<p>$5s: " . $change->getFives() . "</p>";
    echo "<p>$2s: " . $change->getToonies() . "</p>";
    echo "<p>$1s: " . $change->getLoonies() . "</p>";
    echo "<p>$0.25s: " . $change->getQuarters() . "</p>";
    echo "<p>$0.10s: " . $change->getDimes() . "</p>";
    echo "<p>$0.05s: " . $change->getNickels() . "</p>";




}



if ($display)
{
    ?>
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <title>Change</title>
    </head>
    <body>
    <form action="./partb.php" method="post" id="form">
        <p>
            <label for="cost">Cost $:</label>
            <input name="cost">
        </p>
        <p>
            <label for="tender">Tender $:</label>
            <input name="tender">
        </p>
        <input type="submit" name="submit">
    </form>

    </body>
    </html>




    <?php
}//If()
?>
