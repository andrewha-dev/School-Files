<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Part 3A</title>
</head>
<body>
<?php
    $die1;
    $die2;

    $dieScore = array(0,0,0,0,0,0,0,0,0,0,0,0);


$dieNames = array("Null", "one", "two", "three", "four", "five", "six");

    for ($i = 1; $i <= 50; $i++) {

        $die1 = rand(1, 6);
        $die2 = rand(1, 6);

        $score = $die1 + $die2;
        $dieNames = "null";

        echo "</br><h2>The total score for the roll was $score</h2>";
        checkForDouble($die1, $die2, $dieNames);
        displayScoreText($score);
        displayCount($i);

        if ($score >= 1 && $score <= 12)
        {
            $scoreIndex = $score - 1;
            incrementRolls($dieScore, $scoreIndex);
        }

        if ($i == 50)
        {
            for ($j = 0; $j < sizeof($dieScore); $j++)
            {
                echo "<p>The count for each : $dieScore[$j]</p>";
            }
        }




    }
function checkForDouble($d1, $d2, &$dieNames)
{
    global $die1;
    global $die2;
    if ($d1 == $d2) {
        $dieNames = array("Null", "one", "two", "three", "four", "five", "six");
        echo "<p>The roll was double $dieNames[$d1]</p>";
    } else {
        echo "<p>The roll was a $die1 and a $die2</p>";
    }
}



function displayScoreText($score)
{
    switch ($score) {
        case 2:
            echo "<p>You rolled a snake eyes!</p>";
            break;
        case 3:
            echo "<p>You rolled a loose deuce!</p>";
            break;
        case 5:
            echo "<p>You rolled a fever five!</p>";
            break;
        case 7:
            echo "<p>You rolled a natural!</p>";
            break;
        case 9:
            echo "<p>You rolled a nina!</p>";
            break;
        case 11:
            echo "<p>You rolled a yo!</p>";
            break;
        case 12:
            echo "<p>You rolled boxcars!</p>";
    }
}
function displayCount($i)
{
    echo "<p>The roll number: $i</p>";
}

function incrementRolls (&$dieRoll, &$scoreIndex){
    $dieRollCurrentNum = $dieRoll[$scoreIndex];
    $dieRoll[$scoreIndex] = ++$dieRollCurrentNum;

}


?>

</body>