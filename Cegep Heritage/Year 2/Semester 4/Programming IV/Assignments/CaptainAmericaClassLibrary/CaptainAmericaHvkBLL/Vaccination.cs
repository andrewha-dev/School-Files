using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaptainAmericaHvkDB;
using System.Data;

namespace aha_HVK
{
    [Serializable]
    public class Vaccination
    {
        public char verified { get; set; }
        public DateTime expiryDate { get; set; }
        public int number { get; set; }
        public String name { get; set; }
        public Vaccination()
        {
            expiryDate = new DateTime();
            number = -1;
            name = "";
            verified = 'N';          
        }
        public Vaccination(DateTime _expiryDate, int _number, String _name, char _verified)
        {
            expiryDate = _expiryDate;
            number = _number;
            name = _name;
            verified = _verified;
        }
        public List<Vaccination> listVaccinations(int _petNumber)
        {
            //Make sure that the vaccines match for all, missing, all there, all expired
            //Looking for vaccination name, expiry date, validation flag
            List<Vaccination> vaccines = new List<Vaccination>();
            VaccinationDB vacDB = new VaccinationDB();
            DataSet vacDS = vacDB.listVaccinations(_petNumber);
            DataTable dt = vacDS.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Vaccination vac = new Vaccination();

                vac.name = row["VACCINATION_NAME"].ToString();
                if (row["VACCINATION_EXPIRY_DATE"] != DBNull.Value)
                    vac.expiryDate = Convert.ToDateTime(row["VACCINATION_EXPIRY_DATE"]);
                else
                    vac.expiryDate = new DateTime();

                vac.verified = Convert.ToChar(row["VACCINATION_CHECKED_STATUS"]);               

                vaccines.Add(vac);
            }

            return vaccines;
        }

        public List<Vaccination> checkVaccinations(int _reservationNumber, int _petNumber)
        {
            //Have one that is missing, have one that is expired, have one with the flag
            List<Vaccination> vaccinesToBeValidated = new List<Vaccination>();
            //List of vaccines for that reservation
            //if (_scenario == 2)
            //    vaccinesToBeValidated = db.checkVaccinations(2);

            //if (_scenario == 3)
            //    vaccinesToBeValidated = db.checkVaccinations(3);
            List<Vaccination> vaccines = new List<Vaccination>();
            VaccinationDB vacDB = new VaccinationDB();
            DataSet vacDS = vacDB.checkVaccinations(_reservationNumber, _petNumber);
            DataTable dt = vacDS.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Vaccination vac = new Vaccination();

                vac.name = row["VACCINATION_NAME"].ToString();
                

                vaccines.Add(vac);
            }

            return vaccines;

        }

    }
}
