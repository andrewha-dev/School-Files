using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyValleyKennels.App_Code.BLL
{
    [Serializable]
    public class Medication
    {
        public int number { get; set; }
        public String name { get; set; }
        public String dosage { get; set; }
        public String instructions { get; set; }
        public DateTime endDate { get; set; }

        public Medication()
        {
            number = -1;
            name = "";
            dosage = "";
            instructions = "";
            endDate = new DateTime(1000, 1, 1);
        }

        public Medication(int _medicationNumber, String _medicationName)
        {
            number = _medicationNumber;
            name = _medicationName;
            dosage = "";
            instructions = "";
            endDate = new DateTime(1000, 1, 1);
        }

        public Medication(int _medicationNumber, String _medicationName, String _medicationDosage, String _medicationInstructions, DateTime _medicationEndDate)
        {
            number = _medicationNumber;
            name = _medicationName;
            dosage = _medicationDosage;
            instructions = _medicationInstructions;
            endDate = _medicationEndDate;
        }


    }
}