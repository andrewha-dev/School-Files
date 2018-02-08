using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aha_HVK
{
    [Serializable]
    public class Discount
    {
        public int number { get; set; }
        public String description { get; set; }
        public double percentage { get; set; }
        public char type { get; set; }
        public Discount()
        {
            number = -1;
            description = "";
            percentage = -1.00;
            type = 'D';
        }
        public Discount(int _number, String _description, double _percentage, char _type)
        {
            number = _number;
            description = _description;
            percentage = _percentage;
            type = _type;
        }

        
    }
}
