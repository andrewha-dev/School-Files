using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aha_HVK;
using B42A02_HVKControl;
namespace B42A02_HVKControl
{
    public class HvkControl
    {
        HVKControlDB db = new HVKControlDB();
        public List<User> listOwners()
        {
            List<User> owners = new List<User>();
            owners = db.listOwnersDB();            
            return owners;
        }

        public List<Pet> listPets(User _owner, int _scenario)
        { 
            List<Pet> pets = new List<Pet>();
            //For only 1 pet
            if (_scenario == 4)
                pets = db.listPetsDB(4);
            //Two Pets
            if (_scenario == 1)
                pets = db.listPetsDB(1);
            //Three pets
            if (_scenario == 7)
                pets = db.listPetsDB(7);
            return pets;
        }

        public List<Reservation> listReservations(int _ownerNumber)
        {
            //Should be testing for one in the future
            //Testing multiple owner numbers
            //Need Reservation Number, pet number, pet name, start date, end date in the future for the owner
            List<Reservation> reservations = new List<Reservation>();
            //1 reservation
            if (_ownerNumber == 6)
                reservations = db.listReservationsDB(6);
            //2 reservations
            if (_ownerNumber == 2)
                reservations = db.listReservationsDB(2);
            //Multple reservations in the future
            if (_ownerNumber == 17)
                reservations = db.listReservationsDB(17);

            return reservations;
        }

        public List<Reservation> listActiveReservations()
        {
            //Test for the an owner that has an active reservation
            //Test for one that doesn't have an active reservation
            List<Reservation> activeReservations = new List<Reservation>();
            activeReservations = db.listActiveReservations();
            //Looking for reservation number, owner name, pet number, pet name, run number, start and end date
            return activeReservations;
        }
        public List<Reservation> listActiveReservations(int _ownerNumber)
        {
            //Test for the an owner that has an active reservation
            //Test for one that doesn't have an active reservation
            List<Reservation> activeReservations = new List<Reservation>();
            if (_ownerNumber == 1)
            activeReservations = db.listActiveReservations(1);
          
            if (_ownerNumber == 3)
                activeReservations = db.listActiveReservations(3);
            //Looking for reservation number, owner name, pet number, pet name, run number, start and end date for that specific owner.
            return activeReservations;
        }

        public List<Vaccination> listVaccinations(int _petNumber)
        {
            //Make sure that the vaccines match for all, missing, all there, all expired
            //Looking for vaccination name, expiry date, validation flag
            List<Vaccination> vaccines = new List<Vaccination>();
            if (_petNumber == 1)
                vaccines = db.listVaccinations(1);
            if (_petNumber == 2)
                vaccines = db.listVaccinations(2);
            return vaccines;
        }

        public List<Vaccination> checkVaccinations(int _reservationNumber, int _petNumber, int _scenario)
        {
            //Have one that is missing, have one that is expired, have one with the flag
            List<Vaccination> vaccinesToBeValidated = new List<Vaccination>();
            //List of vaccines for that reservation
            if (_scenario == 2)
                vaccinesToBeValidated = db.checkVaccinations(2);

            if (_scenario == 3)
                vaccinesToBeValidated = db.checkVaccinations(3);

            return vaccinesToBeValidated;
        }

        public List<Reservation> upcomingReservations(DateTime _date, int _scenario)
        {
            //Just check the date
            List<Reservation> upcomingReservations = new List<Reservation>();

            if (_scenario == 1)
                upcomingReservations = db.upcomingReservations(1);

            if (_scenario == 2)
                upcomingReservations = db.upcomingReservations(2);
            //Reservation number, owner number, pet number, start date, end date
            return upcomingReservations;
        }
    }
}
