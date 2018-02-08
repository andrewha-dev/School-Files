<?php

$display = true;

if (isset($_POST['submit']))
{
    $consonants = 0;
    $vowels = 0;
    $other = 0;
    $originalFileName = $_FILES['theFile']['name'];

    $fileLocation = $_FILES['theFile']['tmp_name'];


    $fileName = ($_FILES['theFile']['tmp_name']);

    $file = fopen($fileName,"r");

    while (! feof ($file))
    {
        $charFromFile = fgetc($file);
        $vowelsRegex = "/[AEIOUY]/";
        $consonantsRegex = "/[BCDFGHJKLMNPQRSTVWXZ]/";



            if (preg_match($vowelsRegex, strtoupper($charFromFile)))
                $vowels++;
            else if (preg_match($consonantsRegex, strtoupper($charFromFile)))
                $consonants++;
            else if ($charFromFile != "")
                $other++;



    }

    fclose($file);

    $display = false;
    echo "Vowels From $originalFileName:  $vowels <br>";
    echo "Consonants From $originalFileName:  $consonants<br>";
    echo "Special Characters From $originalFileName:  $other<br>";

    $total = $consonants+$vowels+$other;
    echo "Total Characters from $originalFileName: $total";


}




if ($display) {
    ?>
    <!doctype html>

    <html lang="en">
    <head>
        <meta charset="utf-8">
        <title>Part A</title>
    </head>

    <body>
    <form action="partA.php" enctype="multipart/form-data" method="POST">
        <p>
            <input type="file" name="theFile">
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
