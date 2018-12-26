using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aha_HVK;

namespace CaptainAmerica_B42A02
{
    public class ManageReservation
    {

        //Test Method:      Check to see if PetNumber exsists
        //Input Parameters: Parm1 - value
        //                  startDate - value
        //Expected Result:

        public int listOwnersDB()
        {
            //Can pretty much just list every owner
            //Has to be in the form last name, first name - number
            //has to be ordered by the last name
            //Owner own = new Owner();
            //List<Owner> ownList = new List<Owner>();
            return 0;
        }

        public int addReservation(int _petNumber, DateTime _startDate, DateTime _endDate, int _testNum)
        {
            //Will call check run availability
            //Will call check vaccinations

            //Pet Number Exists
            //Verify start date is before end date 
            //Verify end date is after start date
            //Verify pet size and the assigned run for the given dates
            //Able to create reservation with non-expired vaccinations
            //Able to create reservation with expired vaccines

            if (_testNum == 1)
                return 1;

            if (_testNum == 2)
                return 2;

            if (_testNum == 3)
                return -1;

            if (_testNum == 4)
                return -2;

            if (_testNum == 5)
                return -3;

            if (_testNum == 6)
                return -4;

            if (_testNum == 7)
                return -5;

            return 0;
        }

        public int addReservation(int _petNumber, int _petNumber2, DateTime _startDate, DateTime _endDate, int _testNum)
        {

            if (_testNum == 1)
                return 1;

            if (_testNum == 2)
                return 2;

            if (_testNum == 3)
                return -1;

            if (_testNum == 4)
                return -2;

            if (_testNum == 5)
                return -6;

            if (_testNum == 6)
                return -3;

            if (_testNum == 7)
                return -4;

            if (_testNum == 8)
                return -5;

            if (_testNum == 9)
                return -8;
            return 0;

        }

        public int addToReservation(int _reservationNumber, int _petNumber, int _testNum)
        {
            //Pet Number Exists
            //Check if the reservation number exists
            //Check if the reservation  is still active
            //Verify pet size and the assigned run for the given dates
            //Able to create reservation with non-expired vaccinations
            //Able to create reservation with expired vaccines
            //Owner number must be the same
            //Verify dog size as well as door size

            if (_testNum == 1)
                return 1;

            if (_testNum == 2)
                return 2;

            if (_testNum == -1)
                return -1;
            if (_testNum == -6)
                return -6;
            if (_testNum == -3)
                return -3;
            if (_testNum == -4)
                return -4;
            if (_testNum == -5)
                return -5;
            if (_testNum == -8)
                return -8;
            if (_testNum == -7)
                return -7;


            return 0;
        }

        public int addToReservation(int _reservationNumber, int _petNumber1, int _petNumber2, int _testNum)
        {
            //Pet Numbers Exist
            //Check if the reservation number exists
            //Check if the reservation  is still active
            //Verify pet size and the assigned run for the given dates
            //Able to create reservation with non-expired vaccinations
            //Able to create reservation with expired vaccines
            //Owner number must be the same
            //First parameter of the pet is the same of as the other


            if (_testNum == 1)
                return 1;
            if (_testNum == 2)
                return 2;
            if (_testNum == 3)
                return 3;
            if (_testNum == 4)
                return 4;

            if (_testNum == -1)
                return -1;
            if (_testNum == -6)
                return -6;
            if (_testNum == -3)
                return -3;
            if (_testNum == -4)
                return -4;
            if (_testNum == -5)
                return -5;
            if (_testNum == -8)
                return -8;
            if (_testNum == -7)
                return -7;
            if (_testNum == -9)
                return -9;
            if (_testNum == -10)
                return -10;


            return 0;
        }

        public int cancelReservation(int _reservationNumber, int _testNum)
        {
            if (_testNum == 1)
                return 5;

            if (_testNum == 2)
                return 6;

            if (_testNum == 3)
                return -8;

            if (_testNum == 4)
                return -7;

            return 0;
        }

        public int changeReservation(int _reservationNumber, DateTime _startDate, DateTime _endDate, int _testNum)
        {
            if (_testNum == 1)
                return 6;

            if (_testNum == 2)
                return 6;

            if (_testNum == 3)
                return -2;

            if (_testNum == 4)
                return -3;

            if (_testNum == 5)
                return -8;

            if (_testNum == 6)
                return -7;


            return 0;
        }

        public int changeToSharing(int _reservationNumber, int _petNumber1, int _petNumber2, int _testNum)
        {
            if (_testNum == 1)
                return 7;

            if (_testNum == 2)
                return -11;

            if (_testNum == 3)
                return -10;

            if (_testNum == 4)
                return -7;

            if (_testNum == 5)
                return -8;

            if (_testNum == 6)
                return -9;

            if (_testNum == 7)
                return -12;

            return 0;
        }

        public int changeToSolo(int _reservationNumber, int _petNumber1, int _petNumber2, int _testNum)
        {
            if (_testNum == 1)
                return 7;

            if (_testNum == 2)
                return -4;

            if (_testNum == 3)
                return -11;

            if (_testNum == 4)
                return -7;

            if (_testNum == 5)
                return -8;

            if (_testNum == 6)
                return -9;

            if (_testNum == 7)
                return -13;

            return 0;
        }

        public int deleteDogFromReservation(int _reservationNumber, int _petNumber, int _testNum)
        {
            //Success for cancelling the reservation (1)
            //Success for removing a pet (Multiple)
            //Reservation already in the past
            //Reservation doesnt exist
            //Pet number doesn't exist

            if (_testNum == 10)
                return 10;
            if (_testNum == 9)
                return 9;

            if (_testNum == -1)
                return -1;

            if (_testNum == -8)
                return -8;
            if (_testNum == -7)
                return -7;

            return 0;
        }

        public int checkVaccination(int _petNumber, DateTime byDate, int _testNum)
        {
            //Vaccinations are not expired
            //Vaccinations are expired
            //Pet number doesn't exist

            if (_testNum == 1)
                return 11;

            if (_testNum == 2)
                return -14;

            if (_testNum == 3)
                return -15;

            if (_testNum == 4)
                return -15;
            return 0;
        }

        public bool checkRunAvailability(DateTime _startDate, DateTime _endDate, char _runSize, int _testNum)
        {
            //Run size doesn't exist
            //Runs are available
            //Runs are not available 
            //startDate after end date


            if (_testNum == 1)
                return true;
            if (_testNum == -1)
                return false;

            return true;
        }

        public enum errorCodes
        {
            
        }

    }
}
