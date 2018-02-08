   <!doctype html>

    <html lang="en">
    <head>
        <meta charset="utf-8">

        <title>Part B-2</title>

    </head>

    <body>
    <h1>The following files and their names and descriptions</h1>
    <?php
    $theArray = scandir("./reunionimages");


    foreach($theArray as $value)
    {
       $extensionArray = explode(".", $value);
        $extension = $extensionArray[1];
        if ($extension == "png")
            echo "<img src=./reunionimages/$value </img>";
        if ($extension == "txt"){
            $theString = file_get_contents("./reunionimages/$value");
            $nameAndDesc = explode("~", $theString);
            $theName = $nameAndDesc[0];
            $theDesc = $nameAndDesc[1];
            echo "<p>The name is: $theName <br> The description is: $theDesc</p>";
        }



    }



    ?>
    </body>
    </html>


    <?php


?>
