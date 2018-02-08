using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aha_HVK
{
    [Serializable]
    public class Food
    {
        public int number { get; set; }
        public String brand { get; set; }
        public String variety { get; set; }
        public int frequency { get; set; }
        public String quantity { get; set; }
        public Food()
        {
            number = -1;
            brand = "";            
            frequency = -1;
            variety = "";
            quantity = "";
        }
        public Food(int _number, String _brand, int _frequency)
        {
            number = _number;
            brand = _brand;
            frequency = _frequency;
            variety = "";
            quantity = "";
        }
        public Food(int _number, String _brand, int _frequency, String _variety, String _quantity)
        {
            number = _number;
            brand = _brand;
            frequency = _frequency;
            variety = _variety;
            quantity = _quantity;
        }
    }
}
