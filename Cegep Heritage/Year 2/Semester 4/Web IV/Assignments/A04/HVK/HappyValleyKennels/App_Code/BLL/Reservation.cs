using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HappyValleyKennels.App_Code.DB;
using HappyValleyKennels.App_Code.BLL;

namespace HappyValleyKennels.App_Code
{
    [Serializable]
    public class Reservation
    {
        public char status { get; set; }
        public int number { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<PetReservation> petReservation { get; set; }
        public List<Discount> discount { get; set; }
        public User owner { get; set; }


        public Reservation()
        {
            number = -1;
            owner = new User();
            startDate = new DateTime();
            endDate = new DateTime();
            petReservation = new List<PetReservation>();
            status = 'A';
            discount = new List<Discount>();
        }
        public Reservation(int _number, User _owner, List<PetReservation> _petReservation, DateTime _startDate, DateTime _endDate, char _status, List<Discount> _discount)
        {
            number = _number;
            owner = _owner;
            petReservation = _petReservation;
            startDate = _startDate;
            endDate = _endDate;
            status = _status;
            discount = _discount;
        }




        //Method for creating a reservatation
        public int addReservation(int _petNumber, DateTime _startDate, DateTime _endDate)
        {

            Pet pet = new Pet();

            Pet petToAdd = new Pet();
            petToAdd = pet.getPet(_petNumber);

            //If pet number doesn't exist
            if (petToAdd.number == -1)
                return -1;

            if (_endDate < _startDate)
            {
                return -2;
            }

            //Checking to see if start date is end date
            if (_startDate < DateTime.Now)
                return -3;


            //Checking to see if the run exists
            if (checkRunAvailability(_startDate, _endDate, pet.size) == false)
            {
                return -4;
            }



            //Checking to see if there is a conflicting reservation date
            //List<Reservation> resList = new List<Reservation>();
            //resList = res.listUpcomingReservations(res.endDate);
            //for (int i = 0; i < resList.Count; i++)
            //{
            //    for (int k = 0; k < resList[i].petReservation.Count; i++)
            //    {
            //        if (resList[i].petReservation[k].pet.number == petToAdd.number)
            //        {

            //            return -5;
            //        }
            //    }
            //}

            //Need completion of check vaccinations in order to check vaccinations
            if (checkVaccination(_petNumber, _endDate) != (-14) && checkVaccination(_petNumber, _endDate) != (15))
            {
                ReservationDB rDB = new ReservationDB();
                PetReservationDB prDB = new PetReservationDB();
                ServiceDB sDB = new ServiceDB();
                rDB.addNewReservation(_startDate, _endDate);
                prDB.addNewPetReservation(_petNumber);
                sDB.addToService();
                return 1;
            }

            if ((checkVaccination(_petNumber, _endDate) == (-14)) || checkVaccination(_petNumber, _endDate) == (-15))
            {
                ReservationDB rDB = new ReservationDB();
                PetReservationDB prDB = new PetReservationDB();
                ServiceDB sDB = new ServiceDB();
                rDB.addNewReservation(_startDate, _endDate);
                prDB.addNewPetReservation(_petNumber);
                sDB.addToService();
                return 2;
            }

            return 0;
        }



        public int addReservation(int _petNumber, int _petNumber2, DateTime _startDate, DateTime _endDate)
        {
            Pet pet = new Pet();
            Pet pet1 = new Pet();
            Pet pet2 = new Pet();

            pet1 = pet.getPet(_petNumber);
            pet2 = pet.getPet(_petNumber2);

            if (_petNumber == _petNumber2)
                return -8;

            if (pet1.number == -1)
                return -1;

            if (pet2.number == -1)
                return -17;


            if (_endDate < _startDate)
            {
                return -2;
            }
            if (pet1.ownerNumber != pet2.ownerNumber)
                return -6;

            //Checking to see if start date is end date
            if (_startDate < DateTime.Now)
                return -3;


            //Checking to see if the run exists
            if (checkRunAvailability(_startDate, _endDate, pet1.size) == false)
            {
                return -4;
            }
            if (checkRunAvailability(_startDate, _endDate, pet2.size) == false)
            {
                return -18;
            }
            if (_endDate < _startDate)
            {
                return -2;
            }



            //Checking to see if start date is end date
            if (_startDate < DateTime.Now)
                return -3;


            //Checking to see if the run exists
            if (checkRunAvailability(_startDate, _endDate, pet.size) == false)
            {
                return -4;
            }

            if (checkVaccination(_petNumber, _endDate) != (-14) && checkVaccination(_petNumber, _endDate) != (15) && (checkVaccination(_petNumber2, _endDate) != (-14) && checkVaccination(_petNumber2, _endDate) != (15)))
            {
                ReservationDB rDB = new ReservationDB();
                PetReservationDB prDB = new PetReservationDB();
                ServiceDB sDB = new ServiceDB();
                rDB.addNewReservation(_startDate, _endDate);
                prDB.addNewPetReservation(_petNumber);
                sDB.addToService();
                prDB.addNewPetReservation(_petNumber2);
                sDB.addToService();
                return 1;
            }

            if ((checkVaccination(_petNumber, _endDate) == (-14)) || checkVaccination(_petNumber, _endDate) == (-15) || (checkVaccination(_petNumber2, _endDate) == (-14)) || checkVaccination(_petNumber2, _endDate) == (-15))
            {
                ReservationDB rDB = new ReservationDB();
                PetReservationDB prDB = new PetReservationDB();
                ServiceDB sDB = new ServiceDB();
                rDB.addNewReservation(_startDate, _endDate);
                prDB.addNewPetReservation(_petNumber);
                sDB.addToService();
                prDB.addNewPetReservation(_petNumber2);
                sDB.addToService();
                return 2;
            }

            return 0;

        }

        public int addToReservation(int _reservationNumber, int _petNumber)
        {
            //Pet Number Exists - Done
            //Check if the reservation number exists - Done
            //Check if the reservation  is still active - Done
            //Verify pet size and the assigned run for the given dates - Done
            //Able to create reservation with non-expired vaccinations
            //Able to create reservation with expired vaccines
            //Owner number must be the same - Done
            //Making sure pet isn't already in the reservation - Done

            //Steps to complete this method:
            //Get the reservation, make sure that reservation isn't over
            //Create the pet object, make sure that the pet owner number matches owner
            //number of the reservation
            //Check the vaccination of the pet, check the run availability

            Reservation res = new Reservation();
            res = getReservation(_reservationNumber);

            //Checking to see if the pet exists
            Pet pet = new Pet();

            Pet petToAdd = new Pet();
            petToAdd = pet.getPet(_petNumber);

            //If pet number doesn't exist
            if (petToAdd.number == -1)
                return -1;

            //Checking to see if res number exists
            if (res.number == -1)
            {
                return -8;
            }
            //Checking to see if the reservation has already ended
            if (res.endDate < DateTime.Now)
            {
                return -7;
            }

            ////Checking to see if the pet number matches the owner number
            //if (petToAdd.ownerNumber != res.petReservation[0].pet.ownerNumber)
            //{
            //    return -6;
            //}

            //Checking to see if the run exists
            if (checkRunAvailability(res.startDate, res.endDate, pet.size) == false)
            {
                return -4;
            }
            //if pet is already in the reservation
            if (pet.number == res.petReservation[0].pet.number)
            {
                return -16;
            }

            //Checking to see if there is a conflicting reservation date
            List<Reservation> resList = new List<Reservation>();
            resList = res.listUpcomingReservations(res.endDate);
            if (resList.Count > 0)
                for (int i = 0; i < resList.Count; i++)
                {
                    for (int k = 0; k < resList[i].petReservation.Count; k++)
                    {
                        if (resList[i].petReservation[k].pet.number == petToAdd.number)
                        {

                            if ((resList[i].startDate > res.startDate && resList[i].endDate < res.endDate) || (resList[i].startDate < res.startDate && resList[i].endDate > res.endDate))
                            {
                                return -5;
                            }
                        }
                    }
                }


            //Finding out if the pet has a conflicting reservation


            //Checking the vaccinations
            Vaccination vaccine = new Vaccination();
            List<Vaccination> petVaccineList = new List<Vaccination>();
            //Relying on method from teammates to be completed
            petVaccineList = vaccine.checkVaccinations(res.number, petToAdd.number);
            //if the pet has all valid vaccinations
            if (petVaccineList.Count == 0)
            {

                PetReservationDB prDB = new PetReservationDB();
                ServiceDB sDB = new ServiceDB();
                int insertStatus = prDB.addToPetReservation(res.number, petToAdd.number);

                insertStatus = sDB.addToService();
                return 1;

            }
            //If the pet has missing or expired vaccinations
            if (petVaccineList.Count > 0)
            {
                PetReservationDB prDB = new PetReservationDB();
                ServiceDB sDB = new ServiceDB();
                int insertStatus = prDB.addToPetReservation(res.number, petToAdd.number);

                insertStatus = sDB.addToService();

                return 2;

            }

            //Need an insert for the petres and service.














            return -999;
        }

        public int addToReservation(int _reservationNumber, int _petNumber1, int _petNumber2)
        {
            //Pet Numbers Exist
            //Check if the reservation number exists
            //Check if the reservation  is still active
            //Verify pet size and the assigned run for the given dates
            //Able to create reservation with non-expired vaccinations
            //Able to create reservation with expired vaccines
            //Owner number must be the same
            //First parameter of the pet is the same of as the other



            return 0;
        }

        public int cancelReservation(int _reservationNumber)
        {
            //Big Reservation, To Be Deleted Last
            ReservationDB resObj = new ReservationDB();
            //Second Biggest, To Be Deleted 2nd To Last
            PetReservationDB presObj = new PetReservationDB();

            //Delete These In Any Order but must be deleted before the bigger reservations
            ServiceDB servObj = new ServiceDB();
            DiscountDB discObj = new DiscountDB();
            FoodDB foodObj = new FoodDB();
            MedicationDB medObj = new MedicationDB();
            KennelLogDB kenlogObj = new KennelLogDB();

            //Get pet res number(s) associated with reservation
            DataSet presDS = presObj.getAllPetResNumber(_reservationNumber);
            DataSet resDS = resObj.getSpecificReservation(_reservationNumber);
            //Get Reservation to check if it's already been completed(End Date In Past)
            if (resDS != null)
            {
                if (resDS.Tables["HVK_SPEC_RES"].Rows.Count <= 0)
                {
                    return -8;
                }
                else
                {
                    DateTime resEnd = Convert.ToDateTime((resDS.Tables["HVK_SPEC_RES"].Rows[0]["RESERVATION_END_DATE"]));
                    if (resEnd < DateTime.Now)
                    {
                        return -7;
                    }
                }
            }
            if (presDS != null)
            {
                int petResNumber;
                if (presDS.Tables["HVK_PET_RESERVATION"].Rows.Count <= 0)
                {
                    return -8;
                }

                for (int i = 0; i < presDS.Tables["HVK_PET_RESERVATION"].Rows.Count; i++)
                {


                    try
                    {
                        //The Deletes Here Don't actually work

                        //Debugging Attempts:
                        //The petResNumber is getting passed in the right value (3333 if Reservation Number is 4333)
                        //The Queries Work in SQL Developer AND in Visual Studio
                        //Tried to format the queries differently with an @ sign at the front and
                        //changing The SQL Query to use the parameters directly as opposed to using cmd.Parameters.Add
                        //I tried fiddling around with the con.Open, try & catch
                        //Tried various solutions on stack overflow, I didn't find the right one.
                        //Asked teammates and other people, most of them said it should work but don't know why it doesn't work...
                        //Looked into "Lec07 LayeredDataWithInserts File"(Prog IV) example, did not contain a delete example I could reference to
                        //Looked into  "Examples for Data Access with Layers and the Object Data Source File" (Web IV), followed the examples for delete in
                        //the employeeDB class, didn't work either.
                        //Tried using da.DeleteCommand.ExecuteNonQuery(); to execute the query, still doesn't work...


                        petResNumber = Convert.ToInt16(presDS.Tables["HVK_PET_RESERVATION"].Rows[i]["PET_RES_NUMBER"]);
                        Console.WriteLine(petResNumber);
                        //Deletes all rows where Pet Reservation Number is matching
                        servObj.deletePetResServRow(petResNumber);
                        discObj.deletePetDiscountRow(petResNumber);
                        foodObj.deletePetFoodRow(petResNumber);
                        medObj.deleteMedicationRow(petResNumber);
                        kenlogObj.deleteKenLogRow(petResNumber);
                        presObj.deletePetResRow(petResNumber);
                    }
                    catch
                    {
                        Console.Write("Error");
                        return -8;
                    }
                }
                resObj.deleteReservation(_reservationNumber);
                return 5;
            }
            else
            {
                return -8;
            }



        }

        public int changeReservation(int _reservationNumber, DateTime _startDate, DateTime _endDate)
        {
            Reservation res = new Reservation();
            res = getReservation(_reservationNumber);

            PetReservation petRes = new PetReservation();

            //Check if Reservation number exists
            if (res.number == -1)
            {
                return -8;
            }

            //see if input dates make sense
            if (_startDate < DateTime.Now)
            {
                return -3;
            }

            if (_endDate < _startDate)
            {
                return -2;
            }

            //Check if reservation is in past(Completed)
            if (res.endDate < DateTime.Now)
            {
                return -7;
            }

            //Figure out how many pets are in this reservation
            //For each pet
            //Is their a run of their size available
            //That each pet dosen't have other reservations in those dates
            List<PetReservation> petResList = new List<PetReservation>();
            petResList = petRes.listActivePetReservations(_reservationNumber);

            foreach (PetReservation pr in petResList)
            {
                Pet pet = pr.pet;
                if (checkRunAvailability(_startDate, _endDate, pet.size) == false)
                {
                    return -4;
                }

                if (checkReservationConflict(_startDate, _endDate, pr) == false)
                {
                    return -5;
                }

            }
            return 6;
        }

        public bool checkReservationConflict(DateTime _startDate, DateTime _endDate, PetReservation pr)
        {
            //Checking to see if there is a conflicting reservation date
            Reservation res = new Reservation();
            List<Reservation> resList = new List<Reservation>();

            resList = res.listUpcomingReservations(res.endDate);


            foreach (Reservation r in resList)
            {
                foreach (PetReservation peer in r.petReservation)
                {
                    if (peer.pet.number == pr.pet.number)
                    {
                        if (peer.number != pr.number)
                        {
                            return false;
                        }
                    }
                }

            }
            return true;
        }

        public int changeToSharing(int _reservationNumber, int _petNumber1, int _petNumber2)
        {

            return 0;
        }

        public int changeToSolo(int _reservationNumber, int _petNumber1, int _petNumber2)
        {

            return 0;
        }

        public int deleteDogFromReservation(int _reservationNumber, int _petNumber)
        {
            //Success for cancelling the reservation (1)
            //Success for removing a pet (Multiple)
            //Reservation already in the past
            //Reservation doesnt exist
            //Pet number doesn't exist

            //Big Reservation, To Be Deleted Last
            ReservationDB resObj = new ReservationDB();
            //Second Biggest, To Be Deleted 2nd To Last
            PetReservationDB presObj = new PetReservationDB();

            //Delete These In Any Order but must be deleted before the bigger reservations
            ServiceDB servObj = new ServiceDB();
            DiscountDB discObj = new DiscountDB();
            FoodDB foodObj = new FoodDB();
            MedicationDB medObj = new MedicationDB();
            KennelLogDB kenlogObj = new KennelLogDB();

            //Get pet res number(s) associated with reservation
            DataSet presDS = presObj.getAllPetResNumber(_reservationNumber);
            //Get specific pet Reservation
            DataSet resDS = resObj.getSpecificReservation(_reservationNumber);
            //Get specific Pet within a reservation
            DataSet presnumDS = presObj.listPetRes(_reservationNumber, _petNumber);


            PetDB petObj = new PetDB();
            DataSet petDS = petObj.listSpecificPet(_petNumber);
            if (petDS != null)
            {
                if (petDS.Tables["HVK_PETS"].Rows.Count <= 0)
                {
                    //Pet not found
                    return -1;
                }
            }
            //Get Reservation to check if it's already been completed(End Date In Past)
            if (resDS != null)
            {
                if (resDS.Tables["HVK_SPEC_RES"].Rows.Count <= 0)
                {
                    //Reservation Not Found
                    return -8;
                }
                else
                {
                    DateTime resEnd = Convert.ToDateTime((resDS.Tables["HVK_SPEC_RES"].Rows[0]["RESERVATION_END_DATE"]));
                    if (resEnd < DateTime.Now)
                    {
                        //Reservation already completed
                        return -7;
                    }
                }
            }

            if (presnumDS != null)
            {
                int petResNumber;

                for (int i = 0; i < presnumDS.Tables[0].Rows.Count; i++)
                {

                    //The Deletes Here Don't actually work

                    //Debugging Attempts:
                    //The petResNumber is getting passed in the right value (3333 if Reservation Number is 4333)
                    //The Queries Work in SQL Developer AND in Visual Studio
                    //Tried to format the queries differently with an @ sign at the front and
                    //changing The SQL Query to use the parameters directly as opposed to using cmd.Parameters.Add
                    //I tried fiddling around with the con.Open, try & catch
                    //Tried various solutions on stack overflow, I didn't find the right one.
                    //Asked teammates and other people, most of them said it should work but don't know why it doesn't work...
                    //Looked into "Lec07 LayeredDataWithInserts File"(Prog IV) example, did not contain a delete example I could reference to
                    //Looked into  "Examples for Data Access with Layers and the Object Data Source File" (Web IV), followed the examples for delete in
                    //the employeeDB class, didn't work either.
                    //Tried using da.DeleteCommand.ExecuteNonQuery(); to execute the query, still doesn't work...


                    petResNumber = Convert.ToInt16(presDS.Tables["HVK_PET_RESERVATION"].Rows[i]["PET_RES_NUMBER"]);
                    servObj.deletePetResServRow(petResNumber);
                    discObj.deletePetDiscountRow(petResNumber);
                    foodObj.deletePetFoodRow(petResNumber);
                    medObj.deleteMedicationRow(petResNumber);
                    kenlogObj.deleteKenLogRow(petResNumber);
                    presObj.deletePetResRow(petResNumber);

                }
                //It's very important to check if the pet Res Dataset returned more than 1 row
                //If it returned two rows, there are pets in the reservation
                //If there's one row, there is 1 pet in the reservation
                if (presDS.Tables[0].Rows.Count == 1)
                {
                    resObj.deleteReservation(_reservationNumber);
                }
                return 5;
            }
            else
            {
                return -8;
            }

        }

        //Method that checks to see whether the vaccinations are up to date
        public int checkVaccination(int _petNumber, DateTime byDate)
        {
            //Vaccinations are not expired
            //Vaccinations are expired
            //Pet number doesn't exist


            return 0;
        }

        public bool checkRunAvailability(DateTime _startDate, DateTime _endDate, char _runSize)
        {
            //Run size doesn't exist
            //Runs are available
            //Runs are not available 
            //startDate after end date
            ReservationDB resdb = new ReservationDB();
            return resdb.checkRunAvailabilityDB(_startDate, _endDate, _runSize);
        }

        public enum errorCodes
        {

        }

        public List<Reservation> listReservations(int _ownerNumber)
        {
            List<Reservation> reservations = new List<Reservation>();
            ReservationDB resDB = new ReservationDB();
            DataSet resDS = resDB.listReservationsDB(_ownerNumber);
            DataTable dt = resDS.Tables[0];
            PetReservation pr = new PetReservation();
            int resNumber = -1;

            foreach (DataRow row in dt.Rows)
            {
                Reservation res = new Reservation();
                PetReservation petRes = new PetReservation();

                List<PetReservation> petResList = new List<PetReservation>();
                resNumber = Convert.ToInt16(row["RESERVATION_NUMBER"]);
                res.number = Convert.ToInt16(row["RESERVATION_NUMBER"]);

                if (row["RESERVATION_START_DATE"] != DBNull.Value)
                    res.startDate = Convert.ToDateTime(row["RESERVATION_START_DATE"]);
                else
                    res.startDate = new DateTime();

                if (row["RESERVATION_END_DATE"] != DBNull.Value)
                    res.endDate = Convert.ToDateTime(row["RESERVATION_END_DATE"]);
                else
                    res.endDate = new DateTime();

                petResList = petRes.listPetReservation(resNumber);
                res.petReservation = petResList;

                reservations.Add(res);
            }

            return reservations;
        }
        public List<Reservation> listReservationsEnding()
        {
            List<Reservation> reservations = new List<Reservation>();
            ReservationDB resDB = new ReservationDB();
            DataSet resDS = resDB.listReservationsEndByDB();
            DataTable dt = resDS.Tables[0];
            PetReservation pr = new PetReservation();
            int resNumber = -1;

            foreach (DataRow row in dt.Rows)
            {
                Reservation res = new Reservation();
                PetReservation petRes = new PetReservation();
                res.number = Convert.ToInt16(row["RESERVATION_NUMBER"]);
                res.owner.firstName = row["OWNER_FIRST_NAME"].ToString();
                res.owner.lastName = row["OWNER_LAST_NAME"].ToString();
                List<PetReservation> petResList = new List<PetReservation>();
                resNumber = Convert.ToInt16(row["RESERVATION_NUMBER"]);
                res.number = Convert.ToInt16(row["RESERVATION_NUMBER"]);

                if (row["RESERVATION_START_DATE"] != DBNull.Value)
                    res.startDate = Convert.ToDateTime(row["RESERVATION_START_DATE"]);
                else
                    res.startDate = new DateTime();

                if (row["RESERVATION_END_DATE"] != DBNull.Value)
                    res.endDate = Convert.ToDateTime(row["RESERVATION_END_DATE"]);
                else
                    res.endDate = new DateTime();

                petResList = petRes.listActivePetReservations(resNumber);
                res.petReservation = petResList;

                reservations.Add(res);
            }

            return reservations;
        }

        public List<Reservation> listActiveReservations()
        {
            List<Reservation> reservations = new List<Reservation>();
            ReservationDB resDB = new ReservationDB();
            DataSet resDS = resDB.listActiveReservationsDB();
            DataTable dt = resDS.Tables[0];
            PetReservation pr = new PetReservation();
            int resNumber = -1;

            foreach (DataRow row in dt.Rows)
            {
                Reservation res = new Reservation();
                PetReservation petRes = new PetReservation();
                res.number = Convert.ToInt16(row["RESERVATION_NUMBER"]);
                res.owner.firstName = row["OWNER_FIRST_NAME"].ToString();
                res.owner.lastName = row["OWNER_LAST_NAME"].ToString();
                List<PetReservation> petResList = new List<PetReservation>();
                resNumber = Convert.ToInt16(row["RESERVATION_NUMBER"]);
                res.number = Convert.ToInt16(row["RESERVATION_NUMBER"]);

                if (row["RESERVATION_START_DATE"] != DBNull.Value)
                    res.startDate = Convert.ToDateTime(row["RESERVATION_START_DATE"]);
                else
                    res.startDate = new DateTime();

                if (row["RESERVATION_END_DATE"] != DBNull.Value)
                    res.endDate = Convert.ToDateTime(row["RESERVATION_END_DATE"]);
                else
                    res.endDate = new DateTime();

                petResList = petRes.listActivePetReservations(resNumber);
                res.petReservation = petResList;

                reservations.Add(res);
            }

            return reservations;
        }



        public List<Reservation> listActiveReservations(int _ownerNumber)
        {
            //Test for the an owner that has an active reservation
            //Test for one that doesn't have an active reservation
            List<Reservation> activeReservations = new List<Reservation>();
            List<Reservation> reservations = new List<Reservation>();
            ReservationDB resDB = new ReservationDB();
            DataSet resDS = resDB.listActiveReservationsDB(_ownerNumber);
            DataTable dt = resDS.Tables[0];
            PetReservation pr = new PetReservation();
            int resNumber = -1;

            foreach (DataRow row in dt.Rows)
            {
                Reservation res = new Reservation();
                PetReservation petRes = new PetReservation();
                res.number = Convert.ToInt16(row["RESERVATION_NUMBER"]);
                res.owner.firstName = row["OWNER_FIRST_NAME"].ToString();
                res.owner.lastName = row["OWNER_LAST_NAME"].ToString();
                List<PetReservation> petResList = new List<PetReservation>();
                resNumber = Convert.ToInt16(row["RESERVATION_NUMBER"]);
                res.number = Convert.ToInt16(row["RESERVATION_NUMBER"]);

                if (row["RESERVATION_START_DATE"] != DBNull.Value)
                    res.startDate = Convert.ToDateTime(row["RESERVATION_START_DATE"]);
                else
                    res.startDate = new DateTime();

                if (row["RESERVATION_END_DATE"] != DBNull.Value)
                    res.endDate = Convert.ToDateTime(row["RESERVATION_END_DATE"]);
                else
                    res.endDate = new DateTime();

                petResList = petRes.listActivePetReservations(resNumber);
                res.petReservation = petResList;

                reservations.Add(res);
            }

            return reservations;
            //Looking for reservation number, owner name, pet number, pet name, run number, start and end date for that specific owner.

        }

        public List<Reservation> listUpcomingReservations(DateTime _date)
        {
            ////Just check the date
            //List<Reservation> upcomingReservations = new List<Reservation>();

            //if (_scenario == 1)
            //    upcomingReservations = db.upcomingReservations(1);

            //if (_scenario == 2)
            //    upcomingReservations = db.upcomingReservations(2);
            ////Reservation number, owner number, pet number, start date, end date
            //return upcomingReservations;

            List<Reservation> reservations = new List<Reservation>();
            ReservationDB resDB = new ReservationDB();
            DataSet resDS = resDB.listUpcomingReservationsDB(_date);
            DataTable dt = resDS.Tables[0];
            PetReservation pr = new PetReservation();
            int resNumber = -1;

            foreach (DataRow row in dt.Rows)
            {
                Reservation res = new Reservation();
                PetReservation petRes = new PetReservation();
                res.number = Convert.ToInt16(row["RESERVATION_NUMBER"]);
                List<PetReservation> petResList = new List<PetReservation>();
                resNumber = Convert.ToInt16(row["RESERVATION_NUMBER"]);
                res.number = Convert.ToInt16(row["RESERVATION_NUMBER"]);
                res.owner.number = Convert.ToInt16(row["OWNER_NUMBER"]);
                if (row["RESERVATION_START_DATE"] != DBNull.Value)
                    res.startDate = Convert.ToDateTime(row["RESERVATION_START_DATE"]);
                else
                    res.startDate = new DateTime();

                if (row["RESERVATION_END_DATE"] != DBNull.Value)
                    res.endDate = Convert.ToDateTime(row["RESERVATION_END_DATE"]);
                else
                    res.endDate = new DateTime();

                petResList = petRes.listActivePetReservations(resNumber);
                res.petReservation = petResList;

                reservations.Add(res);
            }

            return reservations;
        }

        public Reservation getReservation(int _reservationNum)
        {
            Reservation res = new Reservation();

            List<Reservation> reservations = new List<Reservation>();
            ReservationDB resDB = new ReservationDB();
            DataSet resDS = resDB.getReservationDB(_reservationNum);
            DataTable dt = resDS.Tables[0];
            PetReservation pr = new PetReservation();
            int resNumber = -1;

            foreach (DataRow row in dt.Rows)
            {
                PetReservation petRes = new PetReservation();
                res.number = Convert.ToInt16(row["RESERVATION_NUMBER"]);
                List<PetReservation> petResList = new List<PetReservation>();
                resNumber = Convert.ToInt16(row["RESERVATION_NUMBER"]);
                res.number = Convert.ToInt16(row["RESERVATION_NUMBER"]);
                res.owner.number = Convert.ToInt16(row["OWNER_NUMBER"]);
                if (row["RESERVATION_START_DATE"] != DBNull.Value)
                    res.startDate = Convert.ToDateTime(row["RESERVATION_START_DATE"]);
                else
                    res.startDate = new DateTime();

                if (row["RESERVATION_END_DATE"] != DBNull.Value)
                    res.endDate = Convert.ToDateTime(row["RESERVATION_END_DATE"]);
                else
                    res.endDate = new DateTime();

                petResList = petRes.listActivePetReservations(resNumber);
                res.petReservation = petResList;

            }

            return res;
        }

        public int updateReservation(int resNum, DateTime resStart, DateTime resEnd)
        {
            ReservationDB resDB = new App_Code.DB.ReservationDB();

            return resDB.changeReservationDB(resNum, resStart, resEnd);
        }


    }
}