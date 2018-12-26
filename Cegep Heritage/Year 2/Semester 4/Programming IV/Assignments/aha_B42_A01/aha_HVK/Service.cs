using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aha_HVK
{
    [Serializable]
    public class Service
    {
        public int number { get; set; }
        public int frequency { get; set; }
        public String description { get; set; }
        public double dailyRate { get; set; }

        public Service()
        {
            number = -1;
            frequency = -1;
            description = "";
            dailyRate = -1.0 ;
        }
        public Service(int _number, String _description, double _dailyRate)
        {
            number = _number;
            description = _description;
            dailyRate = _dailyRate;
            frequency = -1;
        }
        public Service(int _number, String _description, double _dailyRate, int _frequency)
        {
            number = _number;
            description = _description;
            dailyRate = _dailyRate;
            frequency = _frequency;
        }


    }
}
