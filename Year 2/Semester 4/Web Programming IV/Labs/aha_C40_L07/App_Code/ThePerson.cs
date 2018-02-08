using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ThePerson
/// </summary>
namespace aha_C40_L07
{

    [Serializable]
    public class ThePerson
    {

        public String name { get; set; }
        public String phone { get; set; }
        public String city { get; set; }
        public ThePerson()
        {

        }

        public ThePerson(String _name, String _phone, String _city)
        {
            name = _name;
            phone = _phone;
            city = _city;
        }
    }
}
