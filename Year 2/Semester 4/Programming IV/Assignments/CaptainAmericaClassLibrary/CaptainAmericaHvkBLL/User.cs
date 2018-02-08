using CaptainAmericaHvkDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace aha_HVK
{
    [Serializable]
    public class User 
    {
        public char typeOfUser { get; set; }
        public int number { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String street { get; set; }
        public String city { get; set; }
        public String province { get; set; }
        public String postalCode { get; set; }
        public String phone { get; set; }
        public String email { get; set; }
        public String emergencyFirstName { get; set; }
        public String  emergencyLastName { get; set; }
        public String emergencyPhone { get; set; }
        public List<Pet> pet { get; set; }
        public Veterinarian vet{ get; set; }        

    public User()
        {
            number = -1;
            firstName = "";
            lastName = "";
            street = "";
            city = "";
            province = "QC";
            postalCode = "";
            phone = "";
            email = "";
            emergencyFirstName = "";
            emergencyLastName = "";
            emergencyPhone = "";
            pet = new List<Pet>();
            vet = new Veterinarian();
            typeOfUser = 'O';
        }
        public User(int _number, String _firstName, String _lastName, List<Pet> _pet, Veterinarian _vet)
        {
            number = _number;
            firstName = _firstName;
            lastName = _lastName;
            pet = _pet;
            vet = _vet;
            street = "";
            city = "";
            province = "";
            postalCode = "";
            phone = "";
            email = "";
            emergencyFirstName = "";
            emergencyLastName = "";
            emergencyPhone = "";
            typeOfUser = 'O';

        }
        public User(int _number, String _firstName, String _lastName, List<Pet> _pet, Veterinarian _vet, String _street, String _city, String _province, String _postalCode, String _phone, String _email, String _emergencyContactFirstName, String _emergencyContactLastName, String _emergencyContactPhone, char _typeOfUser)
        {
            number = _number;
            firstName = _firstName;
            lastName = _lastName;
            pet = _pet;
            vet = _vet;
            street = _street;
            city = _city;
            province = _province;
            postalCode = _postalCode;
            phone = _phone;
            email = _email;
            emergencyFirstName = _emergencyContactFirstName;
            emergencyLastName = _emergencyContactLastName;
            emergencyPhone = _emergencyContactPhone;
            typeOfUser = _typeOfUser;
        }

        public List<User> listOwners()
        {
            UserDB db = new UserDB();
            List<User> owners = new List<User>();
            DataSet ownersDataSet = db.listOwnersDB();

            DataTable dt = ownersDataSet.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                User user = new User();
                user.firstName = row["OWNER_FIRST_NAME"].ToString();
                user.lastName = row["OWNER_LAST_NAME"].ToString();
                owners.Add(user);
            }




            return owners;
        }




    }

    

        
        
}
