<?php
/**
 * Created by PhpStorm.
 * User: 1435792
 * Date: 11/16/2016
 * Time: 2:11 PM
 */
$display = true;
if (isset($_POST['submit']))
{
    $originalFileName = $_FILES['theFile']['name'];

    $fileLocationTemp = $_FILES['theFile']['tmp_name'];

    $fileNameTemp = ($_FILES['theFile']['tmp_name']);
    echo $originalFileName;

    $userName = $_POST['name'];
    $desc = $_POST['desc'];

    $textFileName = explode(".", $originalFileName);
    $imgText = "$userName~$desc";


    $textFileWithExtension = $textFileName[0] . ".txt";
    file_put_contents("./reunionimages/" .$textFileWithExtension, $imgText, FILE_APPEND);

    $dir = "./reunionimages/";
    $dest = $dir .  $originalFileName;

    move_uploaded_file($_FILES['theFile']['tmp_name'], $dest);
        echo "<h3>File Uploaded!</h3>";
        $display = false;




}




if ($display) {
    ?>
    <!doctype html>

    <html lang="en">
    <head>
        <meta charset="utf-8">

        <title>Part B</title>

    </head>

    <body>
    <form action="bReunion.php" enctype="multipart/form-data" method="POST">
        <p>
            <label for="name">Name:</label>
            <input type="text" name="name">
        </p>
        <p>
            <label for="desc">Description:</label>
            <input type="text" name="desc">
        </p>
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
