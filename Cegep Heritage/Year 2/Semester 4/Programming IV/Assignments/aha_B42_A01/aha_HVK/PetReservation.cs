using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aha_HVK
{
    [Serializable]
    public class PetReservation
    {
        public Pet pet{ get; set; }
        public Run run { get; set; }
        public KennelLog  kennelLog { get; set; }
        public Food food { get; set; }
        public List<Medication> medication { get; set; }
        public List<Service> service { get; set; }

        public PetReservation()
        {
            pet = new Pet();
            run = new Run();
            kennelLog = new KennelLog();
            food = new Food();
            medication = new List<Medication>();
            service = new List<Service>();
        }
        public PetReservation(Pet _pet, Run _run, Food _food, KennelLog _kennelLog)
        {
            pet = _pet;
            run = _run;
            kennelLog = _kennelLog;
            food = _food;
            medication = new List<Medication>();
            service = new List<Service>();
        }
        public PetReservation(Pet _pet, Run _run, Food _food, KennelLog _kennelLog, List<Medication> _medication, List<Service> _service)
        {
            pet = _pet;
            run = _run;
            kennelLog = _kennelLog;
            food = _food;
            medication = _medication;
            service = _service;
        }




    }
}
