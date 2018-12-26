using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaptainAmerica_B42A02;

namespace CaptainAmericaMethodsTest.cs
{
    [TestClass]
    public class CaptainAmericaTest
    {
        /*<Summary>
         * We are testing the following methods using hardcoded data from the database to use a reference
         * Each method has been slightyly modified in order to accept in an int parameter in order to return our desired condition 
         * which in this situation is what we are testing for. Our conditions are assigned integer values:
         * 
         * -----------------------Code Values------------------
         * Default Codes:
         * 0 - Default return code
         * 
         * Success Codes:
         * 1 - Successful reservation addition
         * 2 - Successful reservation addition but one or more pets has a missing or expired vaccine
         * 3 - Two dogs sharing a run has been successfully added
         * 4 - A dog that has been added to a reservation sharing a run with an existing pet in the reservation
         * 5 - Reservation is successfully cancelled
         * 6 - Reservation has been successfully changed
         * 7 - Two solo dogs are now sharing their runs
         * 8 - Twp dogs sharing are now solo
         * 9 - Pet has been successfully removed and reservation has been cancelled (1 pet in reservation)
         * 10 - Pet has been successfully removed (Multiple pets in reservation)
         * 11 - All pet vaccination are up to date
         * 
         * Error Codes:
         * -1 - Pet number not found
         * -2 - End date before start date
         * -3 - Start date is in the past
         * -4 - No runs are available
         * -5 - Pet has a conflicting reservation
         * -6 - Pets don't belong to the same owner
         * -7 - Reservation has already been completed
         * -8 - Reservation doesn't exist
         * -9 - First parameter of pet number is the same as the other
         * -10 - Pet size / run mismatch when trying to share runs
         * -11 - Pet isn't in the reservation
         * -12 - Pets are already sharing runs
         * -13 - Pets are already solo
         * -14 - Pet has missing vaccines
         * -15 - Pet has expired vaccines
         * 
         * </Summary>
         */
        ManageReservation m = new ManageReservation();
        [TestMethod]
        public void AddReservation1Pet()
        {
            //----------- Success Tests
            //
            //Test Method:      Get a successful addition
            //Input Parameters: petNumber - 2
            //                  startDate - 12-Sept-15
            //                  endDate - 19-Sept-15
            //Expected Result:  1     
            Assert.AreEqual(1, m.addReservation(2, new DateTime(2015, 9, 12), new DateTime(2015, 9, 19), 1), "This should be a successful addition returning status code 1");

            //Test Method:      Get a succesful addition but missing vaccinations
            //Input Parameters: petNumber - 20
            //                  startDate - 7-January-17
            //                  endDate - 9-January-17
            //Expected Result:  2 
            Assert.AreEqual(2, m.addReservation(20, new DateTime(2015, 9, 12), new DateTime(2015, 9, 19), 2), "This should be a successful addition but missing vaccines returning status code 2");

            //Failed Tests
            //
            //Test Method:      Get error pet not found
            //Input Parameters: prtNumber - -50
            //                  startDate - 7-January-17
            //                  endDate - 9-January-17
            //Expected Result:  -1
            Assert.AreEqual(-1, m.addReservation(-50, new DateTime(2017, 1, 7), new DateTime(2017, 1, 9), 3), "Pet should be missing with status of -1");

            
            //Test Method:      Get error end date before start date
            //Input Parameters: prtNumber - 20
            //                  startDate - 9-January-17
            //                  endDate - 7-January-17
            //Expected Result:  -2
            Assert.AreEqual(-2, m.addReservation(20, new DateTime(2017, 1, 9), new DateTime(2017, 1, 7), 4), "End date before start date -2");

            //Test Method:      Error: Start date is in the past
            //Input Parameters: petNumber - 20
            //                  start - 7-January-16
            //                  endDate - 9-January-16
            //Expected Result:  -3
            Assert.AreEqual(-3, m.addReservation(20, new DateTime(2016, 1, 7), new DateTime(2016, 1, 9), 5), "Start date is in the past -3");

            //Test Method:      Error: No runs are available
            //Input Parameters: petNumber - 20
            //                  startDate - 7-January-17
            //                  endDate - 9-January-17
            //                  CheckRunAvailability - false
            //Expected Result:  -4
            Assert.AreEqual(-4, m.addReservation(20, new DateTime(2017, 1, 7), new DateTime(2017, 1, 9), 6), "No runs available -4");

            //Test Method:      Error: Pet has a conflicting reservation
            //Input Parameters: petNumber - 1
            //                  startDate - 13-Septemer-15
            //                  Parm3 - 18-Septemer-15
            //Expected Result:  -5
            Assert.AreEqual(-5, m.addReservation(1, new DateTime(2015, 9, 13), new DateTime(2015, 9, 18), 7), "Pet has a conflicting reservation -5");
        }
        
        [TestMethod]
        public void AddReservation2Pets()
        {
            //-------------------Success Tests
            //
            //Test Method:      Get a succesful addition
            //Input Parameters: petNumber1 : 12
            //                  petNumber2 : 11
            //                  startDate : 15-Apr-17
            //                  endDate : 20-Apr-17
            //Expected Result:  1     
            Assert.AreEqual(1, m.addReservation(12, 11, new DateTime(2017, 4, 15), new DateTime(2017, 4, 20), 1), "Successful addition for two pets 1");

            //Test Method:      Get a succesful addition but missing vaccinations
            //Input Parameters: prtNumber1 : 3
            //                  petNumber2 : 6
            //                  startDate : 10-Apr-16
            //                  endDate : 17-Apr-16
            //Expected Result:  2  
            Assert.AreEqual(2, m.addReservation(3, 6, new DateTime(2016, 4, 10), new DateTime(2016, 4, 17), 2), "Successful addition for two pets but one or both are missing vaccines");

            //-----------------------Tests Fail
            //Test Method:      Get error pet not found (can be either one)
            //Input Parameters: petNumber1 - -50
            //                  petnumber2 - 3
            //                  startDate - 7-January-17
            //                  endDate - 9-January-17
            //Expected Result:  -1
            Assert.AreEqual(-1, m.addReservation(-50, 3, new DateTime(2017, 1, 7), new DateTime(2017, 1, 9), 3), "One of the pets number not found -1");

            //Test Method:      Get error end date before start date
            //Input Parameters: petNumber1 - 20
            //                  petNumber2 - 3
            //                  startDate - 9-January-17
            //                  endDate - 7-January-17
            //Expected Result:  -2
            Assert.AreEqual(-2, m.addReservation(20, 3, new DateTime(2017, 1, 9), new DateTime(2017, 1, 7), 4), "End date before the start date -2");

            //Test Method:      Pets don't belong to the same owner
            //Input Parameters: petNumber1 - 1
            //                  petNumber2 - 13
            //                  startDate - 7-January-17
            //                  endDate - 9-January-17
            //Expected Result:  -6
            Assert.AreEqual(-6, m.addReservation(1, 13, new DateTime(2017, 1, 7), new DateTime(2017, 1, 9), 5), "Pets don't belong to the same owner -6");

            //Test Method:      Error: Start date is in the past
            //Input Parameters: petNumber1 - 20
            //                  petNumber2 - 3
            //                  start - 7-January-16
            //                  endDate - 9-January-16
            //Expected Result:  -3
            Assert.AreEqual(-3, m.addReservation(20, 3, new DateTime(2016, 1, 7), new DateTime(2016, 1, 9), 6), "Start date is in the past -6");

            //Test Method:      Error: No runs are available
            //Input Parameters: petNumber1 - 20
            //                  petNumber2 - 13
            //                  startDate - 7-January-17
            //                  endDate - 9-January-17
            //                  CheckRunAvailability - false
            //Expected Result:  -4
            Assert.AreEqual(-4, m.addReservation(20, 13, new DateTime(2017, 1, 7), new DateTime(2017, 1, 9), 7), "No runs available -4");

            //Test Method:      Error: Pet has a conflicting reservation
            //Input Parameters: petNumber2 - 1
            //                  petNumber2 - 3
            //                  startDate - 13-Septemer-15
            //                  Parm3 - 18-Septemer-15
            //Expected Result:  -5
            Assert.AreEqual(-5, m.addReservation(1, 3, new DateTime(2015, 9, 13), new DateTime(2015, 9, 18), 8), "Pet has a conflicting reservation -5");

            //Test Method:      Error: Duplicate pet number
            //Input Parameters: petNumber2 - 1
            //                  petNumber2 - 1
            //                  startDate - 13-Septemer-15
            //                  endDate - 18-Septemer-15
            //Expected Result:  -8
            Assert.AreEqual(-8, m.addReservation(1, 1, new DateTime(2015, 9, 13), new DateTime(2015, 9, 18), 9), "Duplicate pet number listed -8");


        }

        [TestMethod]
        public void AddToReservation1Pet()
        {
            //----------------------------------------------- Success Tests
            //
            //Test Method:      Get a succesful addition
            //Input Parameters: petNumber : 30
            //                  resNumber : 146
            //Expected Result:  1      

            Assert.AreEqual(1, m.addToReservation(30, 146, 1), "Successful Addition || Status = 1");

            //Test Method:      Get a succesful addition but missing vaccinations -> Creating our own object, pet will have a missing vaccination
            //Input Parameters: petNumber : 989
            //                  resNumber : 615
            //Expected Result:  2  

            Assert.AreEqual(2, m.addToReservation(989, 615, 2), "Successful Addition - Missing/Expired Vaccinations || Status = 2");

            //------------------------------------------------ Failed Tests
            //
            //Test Method:      Reservation has already ended
            //Input Parameters: petNumber - 32
            //                  resNumber - 701
            //Expected Result:  -7

            Assert.AreEqual(-7, m.addToReservation(32, 701, -7), "");


            //Test Method:      Pets don't belong to the same owner
            //Input Parameters: petNumber - 32
            //                  resNumber - 703
            //Expected Result:  -6

            Assert.AreEqual(-6, m.addToReservation(32, 703, -6), "Pets don't belong to the same owner || Status = -6");



            //Test Method:      Pet number is invalid
            //Input Parameters: petNumber - -10
            //                  resNumber - 137
            //Expected Result:  -1
            Assert.AreEqual(-1, m.addToReservation(-10, 137, -1), "Pet does not exist || Status = -1");


            //Test Method:      Reservation number invalid
            //Input Parameters: petNumber - 32
            //                  resNumber - 666
            //Expected Result:  -8

            Assert.AreEqual(-8, m.addToReservation(32, 666, -8), "Reservation does not exist || Status = -8");

            //Test Method:      Error: No runs are available
            //Input Parameters: petNumber - 32
            //                  resNumber - 701
            //                  CheckRunAvailability - false
            //Expected Result:  -4

            Assert.AreEqual(-4, m.addToReservation(32, 701, -4), "No Runs Available || Status = -4");


            //Test Method:      Error: Pet has a conflicting reservation -> Create custom reservation object with conflicting reservation dates
            //Input Parameters: petNumber - 1
            //                  resNumber - 777(Custom Reservation with conflicting dates)
            //Expected Result:  -5

            Assert.AreEqual(-5, m.addToReservation(32, 701, -5), "Pet has Conflicting Reservation || Status = -5");


        }
        [TestMethod]
        public void AddToReservation2Pets()
        {
            //----------------------------------------------- Success Tests
            //Test Method:      Get a succesful addition
            //Input Parameters: petNumber : 30 
            //                : petNumber: 31 
            //                  resNumber : 633
            //Expected Result:  3   


            Assert.AreEqual(3, m.addToReservation(30, 31, 633, 3), "Successful Addition || Status = 3");

            //Test Method:      Get a successful addition but missing vaccinations -> Creating our own object, pet will have a missing vaccination
            //Input Parameters: petNumber : 30
            //                : petNumber : 31
            //                  resNumber : 633
            //Expected Result:  2  

            Assert.AreEqual(2, m.addToReservation(30, 31, 633, 2), "Successful Addition - Missing/Expired Vaccinations || Status = 2");

            //Test Method:      Get a successful addition if one of petNumber is already there
            //Input Parameters: petNumber : 31
            //                : petNumber : 30
            //                  resNumber : 800
            //Expected Result:  4  

            Assert.AreEqual(4, m.addToReservation(31, 30, 800, 4), "Successful Addition, Two pets are sharing a run in reservation || Status = 4");

            //------------------------------------------------ Failed Tests

            //Test Method:      Reservation has already ended
            //Input Parameters: petNumber - 30
            //                : petNumber - 31
            //                  resNumber - 701
            //Expected Result:  -7

            Assert.AreEqual(-7, m.addToReservation(30, 31, 701, -7), "Reservation has already ended || Status = -7");

            //Test Method:      Pets don't belong to the same owner
            //Input Parameters: petNumber - 32
            //                : petNumber2 - 7
            //                  resNumber - 633
            //Expected Result:  -6

            Assert.AreEqual(-6, m.addToReservation(32, 7, 633, -6), "Pets don't belong to same owner || Status = -6");

            //Test Method:      Pet number is invalid
            //Input Parameters: petNumber - -10
            //                  petNumber2 - -11
            //                  resNumber - 137
            //Expected Result:  -1

            Assert.AreEqual(-1, m.addToReservation(-10, -11, 137, -1), "Pets don't belong to same owner || Status = -1");

            //Test Method:      Reservation number invalid
            //Input Parameters: petNumber - 1
            //                  petNumber - 2
            //                  resNumber - 666
            //Expected Result:  -8

            Assert.AreEqual(-8, m.addToReservation(1, 2, 666, -8), "Reservation number does not exist || Status = -8");

            //Test Method:      Error: No runs are available
            //Input Parameters: petNumber - 32
            //                  resNumber - 701
            //                  CheckRunAvailability - false
            //Expected Result:  -4

            Assert.AreEqual(-4, m.addToReservation(32, 30, 701, -4), "No Runs available || Status = -4");

            //Test Method:      Error: Pet has a conflicting reservation -> Create custom reservation object with conflicting reservation dates
            //Input Parameters: petNumber - 1
            //                  resNumber - 777(Custom Reservation with conflicting dates)
            //Expected Result:  -5

            Assert.AreEqual(-5, m.addToReservation(1, 2, 777, -5), "Pet has a conflicting reservation || Status = -5");

            //Test Method:      Error: Parameter are the same pet number
            //Input Parameters: petNumber: 32
            //                : petNumber: 32
            //                  resNumber: 633
            //Expected Result:  -9

            Assert.AreEqual(-9, m.addToReservation(32, 32, 633, -9), "Pet has a conflicting reservation || Status = -9");

            //Test Method:      Error: Pet size mismatch
            //Input Parameters: petNumber : 32
            //                : petNumber : 31
            //                  resNumber : 633
            //Expected Result:  -10 

            Assert.AreEqual(-10, m.addToReservation(32, 31, 633, -10), "Pet size mismatch || Status = -10");
        }


        [TestMethod]
        public void checkVaccination()
        {
            //--------------Success
            //Test Method:      Check vaccinations for a pet with all valid vaccinations
            //Input Parameters: petNumber: 13
            //                : byDate: 18-Sep-15
            //Expected Result:  11
            Assert.AreEqual(11, m.checkVaccination(13, new DateTime(2015, 9, 18), 1), "Should return 11 for pet number 13 at September 18, 2015");

            //------------------------------------------------------------------Failure
            //Test Method:      Check vaccinations for a pet with missing vaccination(s)
            //Input Parameters: petNumber: 3
            //                : byDate: 17-Sep-16
            //Expected Result:  -14
            Assert.AreEqual(-14, m.checkVaccination(3, new DateTime(2016, 9, 17), 2), "Should return -14 for pet number 3 at September 17, 2015");

            //Test Method:      Check vaccinations for a pet with vaccination(s) that will expire before the due date
            //Input Parameters: petNumber: 6
            //                : byDate: 17-Apr-16
            //Expected Result:  -15
            Assert.AreEqual(-15, m.checkVaccination(6, new DateTime(2016, 4, 17), 3), "Should -15 false for pet number 3 at April 17, 2016");

            //Test Method:      Check vaccinations for a pet with vaccination(s) that will expire ON the due date
            //Input Parameters: petNumber: 6
            //                : byDate: 5-Sep-17
            //Expected Result:  -15
            Assert.AreEqual(-15, m.checkVaccination(6, new DateTime(2017, 4, 17), 4), "Should -15 false for pet number 6 at September 5, 2017");
        }


        [TestMethod]
        public void DeleteDogFromReservation()
        {
            //----------------------------------------------- Success Tests

            //Test Method:      Success for removing a reservation with 1 pet
            //Input Parameters: resNumber: 102
            //                : petNumber: 13
            //Expected Result:  9


            Assert.AreEqual(9, m.deleteDogFromReservation(102, 13, 9), "Successful Removal - Reservation is Cancelled || Status = 9");

            //Test Method:      Success for removing a reservation with multiple pets
            //Input Parameters: resNumber: 106
            //                : petNumber: 3
            //Expected Result:  10
            Assert.AreEqual(10, m.deleteDogFromReservation(106, 3, 10), "Successful Removal || Status = 10");


            //------------------------------------------------ Failed Tests

            //Test Method: Reservation already in the past
            //Input Parameters: resNumber: 106
            //                : petNumber: 3
            //Expected Result:  -7

            Assert.AreEqual(-7, m.deleteDogFromReservation(106, 3, -7), "Reservation has already ended || Status = -7");

            //Test Method: Reservation doesn't exist
            //Input Parameters: resNumber: 666
            //                : petNumber: 3
            //Expected Result:  -8

            Assert.AreEqual(-8, m.deleteDogFromReservation(666, 3, -8), "Reservation does not exist || Status = -8");

            //Test Method: Pet number doesn't exist
            //Input Parameters: resNumber: 106
            //                : petNumber: 10
            //Expected Result:  -1

            Assert.AreEqual(-1, m.deleteDogFromReservation(106, 10, -1), "Pet number doesn't exist || Status = -1");
        }

        [TestMethod]
        public void checkRunAvailability()
        {
            //----------------------------------------------- Success Tests

            //Test Method:     Runs are available
            //Input Parameters: startDate 1-Jan-16
            //                : endDate  20-Jan-16
            //                : runSize M
            //Expected Result:  true
            Assert.AreEqual(true, m.checkRunAvailability(new DateTime(2016, 01, 01), new DateTime(2016, 01, 20), 'M', 1), "Pet number doesn't exist || True");


            //------------------------------------------------ Failed Tests

            //Test Method:     Runs are not available
            //Input Parameters: startDate - 1-Apr-16
            //                : endDate - 20-Apr-16
            //                : runSize - L
            //Expected Result:  false

            Assert.AreEqual(false, m.checkRunAvailability(new DateTime(2016, 04, 01), new DateTime(2016, 04, 20), 'L', -1), "Runs are not available || False");


            //Test Method:     Runs size not availabless
            //Input Parameters: startDate - 1-Jan-16
            //                : endDate - 20-Jan-16
            //                : runSize - X
            //Expected Result:  false

            Assert.AreEqual(false, m.checkRunAvailability(new DateTime(2016, 01, 01), new DateTime(2016, 01, 20), 'X', -1), "Runs size not available || False");

            //Test Method:    Start Date after end Date
            //Input Parameters: startDate - 20-Jan-16
            //                : endDate - 1-Jan-16
            //                : runSize  - L
            //Expected Result:  false

            Assert.AreEqual(false, m.checkRunAvailability(new DateTime(2016, 01, 20), new DateTime(2016, 01, 01), 'L', -1), "Start Date after end date || False");

        }

        [TestMethod]
        public void AddReservation()
        {
            //----------- Success Tests
            //
            //Test Method:      Get a successful addition
            //Input Parameters: petNumber - 2
            //                  startDate - 12-Sept-15
            //                  endDate - 19-Sept-15
            //Expected Result:  1     
            Assert.AreEqual(1, m.addReservation(2, new DateTime(2015, 9, 12), new DateTime(2015, 9, 19), 1), "This should be a successful addition returning status code 1");

            //Test Method:      Get a succesful addition but missing vaccinations
            //Input Parameters: petNumber - 20
            //                  startDate - 7-January-17
            //                  endDate - 9-January-17
            //Expected Result:  2 
            Assert.AreEqual(2, m.addReservation(20, new DateTime(2015, 9, 12), new DateTime(2015, 9, 19), 2), "This should be a successful addition but missing vaccines returning status code 2");

            //Failed Tests
            //
            //Test Method:      Get error pet not found
            //Input Parameters: petNumber - -50
            //                  startDate - 7-January-17
            //                  endDate - 9-January-17
            //Expected Result:  -1
            Assert.AreEqual(-1, m.addReservation(-50, new DateTime(2017, 1, 7), new DateTime(2017, 1, 9), 3), "Pet should be missing with status of -1");
        }

        [TestMethod]
        public void CancelReservation()
        {
            //-----------------------------------------------------------Tests successful
            //Test Method:      Successful Cancellation before it has begun
            //Input Parameters: resNumber: 632
            //Expected Result:  5
            Assert.AreEqual(5, m.cancelReservation(632, 1), "This should remove the reservation successfully and return the success code 5");

            //Test Method:      Successful Cancellation while it is in progess
            //Input Parameters: resNumber: 701
            //Please note: It has been decided upon the team that if a reservation is in progress,
            //And a owner wishes to 'cancel' then technically we are changing the end date to today
            //Expected Result:  6
            Assert.AreEqual(6, m.cancelReservation(701, 2), "This should still cancel the reservation and return the success code 6");

            //------------------------------------------------------------------Tests fail
            //
            //Test Method:      Reservation doesn't exist
            //Input Parameters: resNumber: 1337
            //Expected Result:  -8
            Assert.AreEqual(-8, m.cancelReservation(1337, 3), "This should return the error code -8 since the reservation doesn't exist");

            //Test Method:      Reservation has already ended
            //Input Parameters: resNumber: 100
            //Expected Result:  -7
            Assert.AreEqual(-7, m.cancelReservation(100, 4), "This should return the error code -7 since the reservation is already ended");

        }

        [TestMethod]
        public void ChangeReservation()
        {
            //------------------------------------------------------------------Tests success

            //Test Method:      Date is successfully changed (End date hasn't expired yet in progress)
            //Input Parameters: resNumber: 631
            //                : startDate: 1-Jan-2017
            //                : endDate  : 01-Mar-2017
            //Expected Result:  6
            Assert.AreEqual(6, m.changeReservation(631, new DateTime(2017, 1, 1), new DateTime(2017, 3, 1), 1), "This should return the success code indicating it was successful");


            //Test Method:      Date is succesfully changed (Reservation has already began)
            //Input Parameters: resNumber: 707
            //                : startDate: 15-Mar-17
            //                : endDate  : 23-Mar-17
            //Expected Result:  6
            Assert.AreEqual(6, m.changeReservation(707, new DateTime(2017, 3, 15), new DateTime(2017, 3, 23), 2), "This should return the success code indicating it was successful (even if the reservation is in progress)");

            //------------------------------------------------------------------Tests fail

            //Test Method:      Start date after end date
            //Input Parameters: resNumber: 102
            //                : startDate: 31-Mar-2017
            //                : endDate  : 01-Mar-2017
            //Expected Result:  -2
            Assert.AreEqual(-2, m.changeReservation(102, new DateTime(2017, 3, 31), new DateTime(2017, 3, 1), 3), "This should return the error code -2 indicating the reservation start date is after the end date.");

            //Test Method:      Start date in the past
            //Input Parameters: resNumber: 102
            //                : startDate: 31-Mar-2016
            //                : endDate  : 01-Mar-2016
            //Expected Result:  -3
            Assert.AreEqual(-3, m.changeReservation(102, new DateTime(2016, 3, 31), new DateTime(2016, 3, 1), 4), "This should return the error code -3 indicating the reservation start date is in the past");

            //Test Method:      Reservation doesn't exist
            //Input Parameters: resNumber: 100000
            //                : startDate: 31-Mar-2017
            //                : endDate  : 01-Mar-2017
            //Expected Result:  -8
            Assert.AreEqual(-8, m.changeReservation(100000, new DateTime(2017, 3, 31), new DateTime(2017, 3, 1), 5), "This should return the error code -8 indicating a reservation number that doesn't exist");

            //Test Method:      Reservation has already ended
            //Input Parameters: resNumber: 100
            //                : startDate: 12-Sep-15
            //                : endDate  : 19-Sep-15
            //Expected Result:  -7
            Assert.AreEqual(-7, m.changeReservation(100, new DateTime(2015, 9, 12), new DateTime(2015, 9, 19), 6), "This should return the error code -7 indicating the reservation is already ended");

        }

        [TestMethod]
        public void ChangeToSharing()
        {
            //------------------------------------------------------------------Tests success

            //Test Method:      Succesfully changed to sharing
            //Input Parameters: resNumber: 115
            //                : petNumber: 3
            //                : petNumber: 6
            //Expected Result:  7
            Assert.AreEqual(7, m.changeToSharing(115, 3, 6, 1), "This should return the success code 7 indicating the two pets have been successfully changed to sharing");

            //------------------------------------------------------------------Tests fail
            //Test Method:      Pet isn't in the reservation
            //Input Parameters: resNumber: 115
            //                : petNumber: 6
            //                : petNumber: 10 //Add own custom pet
            //Expected Result:  -11
            Assert.AreEqual(-11, m.changeToSharing(115, 6, 10, 2), "This should return the error code -11 indicating the pet with that pet number does not exist");

            //Test Method:      Pet size mismatch
            //Input Parameters: resNumber: 106
            //                : petNumber: 3
            //                : petNumber: 6
            //Expected Result:  -10
            Assert.AreEqual(-10, m.changeToSharing(106, 3, 6, 3), "This should return the error code -10 indicating the two pets are of different sizes and cannot be put into a same run");


            //Test Method:      Reservation has already ended
            //Input Parameters: resNumber: 100
            //                : petNumber: 2
            //                : petNumber: 1
            //Expected Result: -7
            Assert.AreEqual(-7, m.changeToSharing(100, 2, 1, 4), "This should return the error code -7 indicating the reservation has already ended");


            //Test Method:      Reservation number invalid
            //Input Parameters: petNumber - 1
            //                  petNumber - 2
            //                  resNumber - 666
            //Expected Result:  -8
            Assert.AreEqual(-8, m.changeToSharing(666, 1, 2, 5), "This should return the error code -8 indicating the reservation number is invalid");


            //Test Method:      Parameter is same as the first
            //Input Parameters: petNumber - 1
            //                  petNumber - 1
            //                  resNumber - 100
            //Expected Result:  -9
            Assert.AreEqual(-9, m.changeToSharing(100, 1, 1, 6), "This should return the error code -9 indicating the two pet numbers are the same");


            //Test Method:      Pets are already sharing runs
            //Input Parameters: resNumber: 106
            //                : petNumber: 6
            //                : petNumber: 3
            //Expected Result:  -12
            Assert.AreEqual(-12, m.changeToSharing(106, 6, 3, 7), "This should return the error code -12 indicating the pets are already sharing a run");

        }

        [TestMethod]
        public void ChangeToSolo()
        {
            //------------------------------------------------------------------Tests success

            //Test Method:      Successfully changed to solo
            //Input Parameters: resNumber: 115
            //                : petNumber: 3
            //                : petNumber: 6
            //Expected Result:  7
            Assert.AreEqual(7, m.changeToSolo(115, 3, 6, 1), "This should return the success code 7 indicating the pets are now in solo runs");


            //------------------------------------------------------------------Tests fail
            //Test Method:      Runs are full
            //Input Parameters: resNumber: 115
            //                : petNumber: 3
            //                : petNumber: 6
            //Expected Result:  -4
            Assert.AreEqual(-4, m.changeToSolo(115, 3, 6, 2), "This should return the error code -4 indicating all the runs are full");

            //Test Method:      Pet isn't in the reservation
            //Input Parameters: resNumber: 115
            //                : petNumber: 6
            //                : petNumber: 10 //Add own custom pet
            //Expected Result:  -11
            Assert.AreEqual(-11, m.changeToSolo(115, 6, 10, 3), "This should return the error code -11 indicating one of the pets isn't in the reservation");

            //Test Method:      Reservation has already ended
            //Input Parameters: resNumber: 100
            //                : petNumber: 2
            //                : petNumber: 1
            //Expected Result: -7
            Assert.AreEqual(-7, m.changeToSolo(100, 2, 1, 4), "This should return the error code -7 indicating the reservation has already ended");


            //Test Method:      Reservation number invalid
            //Input Parameters: petNumber - 1
            //                  petNumber - 2
            //                  resNumber - 666
            //Expected Result:  -8
            Assert.AreEqual(-8, m.changeToSolo(666, 1, 2, 5), "This should return the error code -8 indicating the reservation number is invalid");

            //Test Method:      Parameter is same as the first
            //Input Parameters: petNumber - 1
            //                  petNumber - 1
            //                  resNumber - 100
            //Expected Result:  -9
            Assert.AreEqual(-9, m.changeToSolo(100, 1, 1, 6), "This should return the error code -9 indicating both pet numbers are identical");

            //Test Method:      Pets are already solo
            //Input Parameters: resNumber: 703
            //                : petNumber: 1
            //                : petNumber: 2
            //Expected Result:  -13
            Assert.AreEqual(-13, m.changeToSolo(703, 1, 2, 7), "This should return the error code -13 indicating both pets are already solo");

        }
    }

}
