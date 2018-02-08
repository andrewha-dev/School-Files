<?php
/**
 * Created by PhpStorm.
 * User: 1435792
 * Date: 11/30/2016
 * Time: 1:45 PM
 */

    class Change {
        private $fifties;
        private $twenties;
        private $tens;
        private $fives;
        private $toonies;
        private $loonies;
        private $quarters;
        private $dimes;
        private $nickels;
        private $change;

        private $amount;
        private $tender;
        private $denom = array(50, 20, 10, 5, 2, 1, 0.25, 0.10, 0.05);

        public function numberBack($amount, $tender)
        {

                if ($this->change <= 0.05)
                    $this->change = 0;
                if ($this->change <= 0.09999 && $this->change >= 0.050001)
                    $this->change = 0.05;
            
            $count = floor($this->change/$tender);
            $this->change = fmod($this->change + 0.001, $tender);
            return $count;
        }


        public function __construct($amount, $tender)
        {
            $this->change = ($tender - $amount);
            $this->fifties = 0;
            $this->twenties = 0;
            $this->tens = 0;
            $this->fives = 0;
            $this->toonies = 0;
            $this->quarters = 0;
            $this->dimes = 0;
            $this->nickels = 0;
        }


        /**
         * @return mixed
         */
        public function getChange()
        {
            return $this->change;
        }

        /**
         * @param mixed $change
         */
        public function setChange($change)
        {
            $this->change = $change;
        }


        /**
         * @return mixed
         */


        public function getFifties()
        {
            return $this->fifties;
        }

        /**
         * @param mixed $fifties
         */
        public function setFifties($fifties)
        {
            $this->fifties = $fifties;
        }

        /**
         * @return mixed
         */
        public function getTwenties()
        {
            return $this->twenties;
        }

        /**
         * @param mixed $twenties
         */
        public function setTwenties($twenties)
        {
            $this->twenties = $twenties;
        }

        /**
         * @return mixed
         */
        public function getTens()
        {
            return $this->tens;
        }

        /**
         * @param mixed $tens
         */
        public function setTens($tens)
        {
            $this->tens = $tens;
        }

        /**
         * @return mixed
         */
        public function getFives()
        {
            return $this->fives;
        }

        /**
         * @param mixed $fives
         */
        public function setFives($fives)
        {
            $this->fives = $fives;
        }

        /**
         * @return mixed
         */
        public function getLoonies()
        {
            return $this->loonies;
        }

        /**
         * @param mixed $loonies
         */
        public function setLoonies($loonies)
        {
            $this->loonies = $loonies;
        }

        /**
         * @return mixed
         */
        public function getToonies()
        {
            return $this->toonies;
        }

        /**
         * @param mixed $toonies
         */
        public function setToonies($toonies)
        {
            $this->toonies = $toonies;
        }

        /**
         * @return mixed
         */
        public function getQuarters()
        {
            return $this->quarters;
        }

        /**
         * @param mixed $quarters
         */
        public function setQuarters($quarters)
        {
            $this->quarters = $quarters;
        }

        /**
         * @return mixed
         */
        public function getDimes()
        {
            return $this->dimes;
        }

        /**
         * @param mixed $dimes
         */
        public function setDimes($dimes)
        {
            $this->dimes = $dimes;
        }

        /**
         * @return mixed
         */
        public function getNickels()
        {
            return $this->nickels;
        }

        /**
         * @param mixed $nickels
         */
        public function setNickels($nickels)
        {
            $this->nickels = $nickels;
        }
    }
?>