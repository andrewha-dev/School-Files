using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aha_HVK
{
    [Serializable]
    public class Vaccination
    {
        public bool verified { get; set; }
        public DateTime expiryDate { get; set; }
        public int number { get; set; }
        public String name { get; set; }
        public Vaccination()
        {
            expiryDate = new DateTime(1000, 1, 1);
            number = -1;
            name = "";
            verified = false;          
        }
        public Vaccination(DateTime _expiryDate, int _number, String _name, bool _verified)
        {
            expiryDate = _expiryDate;
            number = _number;
            name = _name;
            verified = _verified;
        }

    }
}
