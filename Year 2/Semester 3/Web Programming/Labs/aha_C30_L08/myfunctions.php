<?php
    function evenlyDivded(int $Number,int $Divisor):bool
    {
        $isEven = false;
        if ($Divisor != 0)
        {
            if ($Number % $Divisor == 0)
            $isEven = true;
        }
        else {
            $isEven = false;
        }
        return $isEven;

    }

    function checkRange($lowerBound,$upperBound,$Divisor)
    {
       $arrayOfNums = array();
        for ($i = $lowerBound; $lowerBound <= $upperBound; $lowerBound++)
        {
            if (evenlyDivded($lowerBound,$Divisor))
            {
                $newBound = $lowerBound;
                $arrayOfNums[] = $newBound;

            }
        }
        return $arrayOfNums;
    }


?>
