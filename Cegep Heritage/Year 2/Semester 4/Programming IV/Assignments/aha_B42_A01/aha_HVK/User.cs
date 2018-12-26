using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //The following are unimplemented methods for future iterations of the project
        
        //Method for creating an account
        public void createCustomer()
        {
            Console.WriteLine("This is being printed from the Owner.cs createCustomer method - Line 88");
        }

        //Method for editing the account information
        public void editCustomer()
        {
            Console.WriteLine("This is being printed from the Owner.cs editCustomer method - Line 94");
        }

        //Method for removing the customer
        public void removeCustomer()
        {
            Console.WriteLine("This is being printed from the Owner.cs removeCustomer method - Line 100");
        }

        //Method for searching for a customer
        public void searchCustomer()
        {
            Console.WriteLine("This is being printed from the Owner.cs searchCustomer method - Line 106");
        }

    }

    

        
        
}
