using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyValleyKennels.App_Code.BLL
{
    [Serializable]
    public class Veterinarian
    {
        public int number { get; set; }
        public String name { get; set; }
        public String phone { get; set; }
        public String street { get; set; }
        public String city { get; set; }
        public String province { get; set; }
        public String postalCode { get; set; }
        public Veterinarian()
        {
            number = -1;
            name = "";
            phone = "";
            street = "";
            city = "";
            province = "";
            postalCode = "";
        }
        public Veterinarian(int _number, String _name, String _phone)
        {
            number = _number;
            name = _name;
            phone = _phone;
            street = "";
            city = "";
            province = "";
            postalCode = "";
        }
        public Veterinarian(int _number, String _name, String _phone, String _street, String _city, String _province, String _postalCode)
        {
            number = _number;
            name = _name;
            phone = _phone;
            street = _street;
            city = _city;
            province = _province;
            postalCode = _postalCode;
        }
    }
}
