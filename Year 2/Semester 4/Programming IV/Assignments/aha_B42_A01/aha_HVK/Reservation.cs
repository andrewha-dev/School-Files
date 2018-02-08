using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aha_HVK
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
        public int ownerNumber { get; set; }


        public Reservation()
        {
            number = -1;
            ownerNumber = -1;
            startDate = new DateTime(1000, 1, 1);
            endDate = new DateTime(1000, 1, 1);
            petReservation = new List<PetReservation>();
            status = 'A';
            discount = new List<Discount>();
        }
        public Reservation(int _number, int _ownerNumber, List<PetReservation> _petReservation, DateTime _startDate, DateTime _endDate, char _status, List<Discount> _discount)
        {
            number = _number;
            ownerNumber = _ownerNumber;
            petReservation = _petReservation;
            startDate = _startDate;
            endDate = _endDate;
            status = _status;
            discount = _discount;
        }

        //The following code unimplemented methods are potential expansions in the class for future iterations

        //Method for creating a reservatation
        public bool createReservation()
        {
            return false;
        }

        //Method that will cancel a reservation
        public bool cancelReservation()
        {
            return false;
        }

        //Method to edit the reservation
        public void editReservation()
        {

        }

        //Method to confirm a reservation has been booked
        public void confirmReservation()
        {

        }

        //Start reservation is for when the clerk wants to start a reservation that has been confirmed
        public void startReservation()
        {

        }

        //Method for ending a reservation
        public void endReservation()
        {

        }

        //Generating the invoice
        public void generateInvoice()
        {

        }

        //Method for printing the kennel log
        public void printKennelLog()
        {

        }

        //Method for searching for a reservation
        public bool searchReservation()
        {
            return false;
        }

        //Method that checks to see whether the vaccinations are up to date
        public bool validateVaccine()
        {
            return false;
        }

        //Method that will automatically confirm all the vaccinations for a pet
        public bool confirmPetVaccine()
        {
            return false;
        }

        //Method that will check the availability of the runs
        public bool checkAvailability()
        {
            return false;
        }

        
    }
}
