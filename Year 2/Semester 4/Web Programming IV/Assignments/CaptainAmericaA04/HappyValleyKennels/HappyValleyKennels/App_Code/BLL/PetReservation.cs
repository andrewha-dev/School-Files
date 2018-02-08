using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyValleyKennels.App_Code.DB;
using System.Data;
using System.ComponentModel;

namespace HappyValleyKennels.App_Code.BLL
{
    [Serializable]
    public class PetReservation
    {
        public int number { get; set; }
        public int resNum { get; set; }
        public String petres { get; set; }
        public Pet pet { get; set; }
        public Run run { get; set; }
        public KennelLog kennelLog { get; set; }
        public Food food { get; set; }
        public List<Medication> medication { get; set; }
        public List<Service> service { get; set; }
        public String resStart { get; set; }
        public String resEnd { get; set; }
        public String petService { get; set; }
        public PetReservation()
        {
            pet = new Pet();
            run = new Run();
            kennelLog = new KennelLog();
            food = new Food();
            medication = new List<Medication>();
            service = new List<Service>();
            number = -1;
        }
        public PetReservation(Pet _pet, Run _run, Food _food, KennelLog _kennelLog, int _number)
        {
            pet = _pet;
            run = _run;
            kennelLog = _kennelLog;
            food = _food;
            medication = new List<Medication>();
            service = new List<Service>();
            number = _number;
        }
        public PetReservation(Pet _pet, Run _run, Food _food, KennelLog _kennelLog, List<Medication> _medication, List<Service> _service, int _number)
        {
            pet = _pet;
            run = _run;
            kennelLog = _kennelLog;
            food = _food;
            medication = _medication;
            service = _service;
            number = _number;
        }




        public List<PetReservation> listPetReservation(int _reservationNumber)
        {
            List<PetReservation> petResList = new List<PetReservation>();
            PetReservationDB presDB = new PetReservationDB();
            DataSet presDS = presDB.listPetReservations(_reservationNumber);
            DataTable dt = presDS.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                PetReservationDB prDB = new PetReservationDB();

                PetReservation petRes = new PetReservation();
                Pet pet = new Pet();
                number = Convert.ToInt16(row["PET_RES_NUMBER"]);
                pet.number = Convert.ToInt16(row["PET_NUMBER"]);
                pet.name = row["PET_NAME"].ToString();
                pet.ownerNumber = Convert.ToInt16(row["OWN_OWNER_NUMBER"]);
                service = new Service().getServiceForRes(number);


                petRes.pet = pet;
                petResList.Add(petRes);


            }

            return petResList;


        }
        public List<PetReservation> listActivePetReservations(int _reservationNumber)
        {
            List<PetReservation> petResList = new List<PetReservation>();
            PetReservationDB presDB = new PetReservationDB();
            DataSet presDS = presDB.listActivePetReservations(_reservationNumber);
            DataTable dt = presDS.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                PetReservationDB prDB = new PetReservationDB();

                PetReservation petRes = new PetReservation();
                Pet pet = new Pet();

                pet.number = Convert.ToInt16(row["PET_NUMBER"]);
                pet.name = row["PET_NAME"].ToString();

                Run run = new Run();
                if (row["RUN_RUN_NUMBER"] != DBNull.Value)
                    run.number = Convert.ToInt16(row["RUN_RUN_NUMBER"]);
                else
                    run.number = -1;
                petRes.run = run;
                pet.size = Convert.ToChar((row["DOG_SIZE"].ToString()));
                number = Convert.ToInt16(row["PET_RES_NUMBER"]);
                petRes.pet = pet;
                service = new Service().getServiceForRes(number);

                petResList.Add(petRes);


            }

            return petResList;


        }
        public List<PetReservation> listUpcomingReservations(int Ownernum) // upcoming reservations for an owner
        {
            List<PetReservation> petResList = new List<PetReservation>();
            PetReservationDB presDB = new PetReservationDB();
            DataSet upcomResDS = presDB.listUpcomingRes(Ownernum);
            DataTable dt = upcomResDS.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Reservation res = new Reservation();
                PetReservation pr = new PetReservation();

                pr.resNum = Convert.ToInt16(row["RES_RESERVATION_NUMBER"]);
                pr.resStart = Convert.ToString(row["RESERVATION_START_DATE"]);
                pr.petres = row["PETRES"].ToString();
                petResList.Add(pr);

            }

            return petResList;

        }

        public List<PetReservation> listAllUpcomingReservations()
        {
            List<PetReservation> petResList = new List<PetReservation>();
            PetReservationDB presDB = new PetReservationDB();
            DataSet allUpcomResDS = presDB.listAllUpcomingRes();
            DataTable dt = allUpcomResDS.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Reservation res = new Reservation();
                PetReservation pr = new PetReservation();

                pr.resNum = Convert.ToInt16(row["RES_RESERVATION_NUMBER"]);
                pr.resStart = Convert.ToDateTime((row["RESERVATION_START_DATE"])).ToShortDateString();
                pr.resEnd = Convert.ToDateTime((row["RESERVATION_END_DATE"])).ToShortDateString();
                pr.petres = row["PETRES"].ToString();
                petResList.Add(pr);
            }

            return petResList;

        }

        public List<PetReservation> listPetResInfo(int resnum)
        {
            List<PetReservation> petResList = new List<PetReservation>();
            PetReservationDB presDB = new PetReservationDB();
            DataSet petResDS = presDB.listPetRes(resnum);
            DataTable dt = petResDS.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                PetReservation pr = new PetReservation();

                pr.petres = Convert.ToString(row["PET_NAME"]);
                pr.resStart = Convert.ToDateTime((row["RESERVATION_START_DATE"])).ToShortDateString();
                pr.resEnd = Convert.ToDateTime((row["RESERVATION_END_DATE"])).ToShortDateString();
                pr.resNum = Convert.ToInt16(row["PET_RES_NUMBER"].ToString());

                petResList.Add(pr);

            }

            return petResList;
        }

        public List<Service> listPetReservationServices(int petRes)
        {
            List<Service> petServList = new List<Service>();
            PetReservationDB presDB = new PetReservationDB();
            DataSet petResServDS = presDB.listPetResService(petRes);

            DataTable dt = petResServDS.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Service service = new Service();
                service.description = Convert.ToString(row["SERVICE_DESCRIPTION"]);
                service.frequency = Convert.ToInt16(row["FREQUENCY"].ToString());
                petServList.Add(service);
            }

            return petServList;

        }




    }
}