using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HappyValleyKennels.App_Code.DB;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace HappyValleyKennels.App_Code.BLL
{
    [Serializable]
    public class User
    {
        public enum UserValues
        {
            Employee,
            Customer
        }
        public UserValues typeOfUser { get; set; }
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
        public String emergencyLastName { get; set; }
        public String emergencyPhone { get; set; }
        public List<Pet> pet { get; set; }
        
        public String fullName { get; set; }

        public User()
        {
            number = -1;
            firstName = "";
            lastName = "";
            street = "";
            city = "";
            province = "";
            postalCode = "";
            phone = "";
            email = "";
            emergencyFirstName = "";
            emergencyLastName = "";
            emergencyPhone = "";
            pet = new List<Pet>();
            typeOfUser = UserValues.Customer;
            fullName = "";
        }
        public User(int _number, String _firstName, String _lastName, List<Pet> _pet)
        {
            number = _number;
            firstName = _firstName;
            lastName = _lastName;
            pet = _pet;
            street = "";
            city = "";
            province = "";
            postalCode = "";
            phone = "";
            email = "";
            emergencyFirstName = "";
            emergencyLastName = "";
            emergencyPhone = "";
            typeOfUser = UserValues.Customer;
            fullName = lastName + " ," + firstName;

        }
        public User(int _number, String _firstName, String _lastName, List<Pet> _pet, String _street, String _city, String _province, String _postalCode, String _phone, String _email, String _emergencyContactFirstName, String _emergencyContactLastName, String _emergencyContactPhone, UserValues _typeOfUser)
        {
            number = _number;
            firstName = _firstName;
            lastName = _lastName;
            pet = _pet;
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
            fullName = _firstName + ", " + _lastName;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<User> listOwners()
        {
            UserDB db = new UserDB();
            List<User> owners = new List<User>();
            DataSet ownersDataSet = db.listOwnersDB();

            DataTable dt = ownersDataSet.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                User user = new User();
                user.number = Convert.ToInt16(row["OWNER_NUMBER"]);
                user.firstName = row["OWNER_FIRST_NAME"].ToString();
                user.lastName = row["OWNER_LAST_NAME"].ToString();
                user.fullName = user.lastName + ", " + user.firstName;
                owners.Add(user);
            }




            return owners;
        }

        public User getOwner(string _email, string _password)
        {
            User user = new User();

            if (_email == "reed@hvk.ca" && _password == "1234")
            {
                user = new User();
                user.typeOfUser = UserValues.Employee;
                user.number = 0;
            }
            else
            {
                UserDB uDB = new UserDB();
                DataSet userDS = uDB.getOwnerByEmail(_email);
                DataTable dt = userDS.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    user.number = Convert.ToInt16(dt.Rows[0]["OWNER_NUMBER"]);
                    user.firstName = dt.Rows[0]["OWNER_FIRST_NAME"].ToString();
                    user.lastName = dt.Rows[0]["OWNER_LAST_NAME"].ToString();
                    user.street = dt.Rows[0]["OWNER_STREET"].ToString();
                    user.city = dt.Rows[0]["OWNER_CITY"].ToString();
                    string phoneFormatted = dt.Rows[0]["OWNER_PHONE"].ToString();
                    user.phone = formatPhoneNumber(phoneFormatted);

                    user.postalCode = formatPostalCode(dt.Rows[0]["OWNER_POSTAL_CODE"].ToString());
                    user.province = dt.Rows[0]["OWNER_PROVINCE"].ToString();
                    user.email = dt.Rows[0]["OWNER_EMAIL"].ToString();
                    user.emergencyFirstName = dt.Rows[0]["EMERGENCY_CONTACT_FIRST_NAME"].ToString();
                    user.emergencyLastName = dt.Rows[0]["EMERGENCY_CONTACT_LAST_NAME"].ToString();
                    string emerPhoneFormatted = dt.Rows[0]["EMERGENCY_CONTACT_PHONE"].ToString();
                    user.emergencyPhone = formatPhoneNumber(emerPhoneFormatted);
                }
            }



            return user;
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public User getOwnerByNumber(int _ownerNumber)
        {
            UserDB uDB = new UserDB();
            User user = new User();
            DataSet userDS = uDB.getOwnerByNumber(_ownerNumber);
            DataTable dt = userDS.Tables[0];
            if (dt.Rows.Count > 0)
            {
                user.number = Convert.ToInt16(dt.Rows[0]["OWNER_NUMBER"]);
                user.firstName = dt.Rows[0]["OWNER_FIRST_NAME"].ToString();
                user.lastName = dt.Rows[0]["OWNER_LAST_NAME"].ToString();
                user.street = dt.Rows[0]["OWNER_STREET"].ToString();
                user.city = dt.Rows[0]["OWNER_CITY"].ToString();
                string phoneFormatted = dt.Rows[0]["OWNER_PHONE"].ToString();
                user.phone = formatPhoneNumber(phoneFormatted);
                
                user.postalCode = formatPostalCode(dt.Rows[0]["OWNER_POSTAL_CODE"].ToString());
                user.province = dt.Rows[0]["OWNER_PROVINCE"].ToString();
                user.email = dt.Rows[0]["OWNER_EMAIL"].ToString();
                user.emergencyFirstName = dt.Rows[0]["EMERGENCY_CONTACT_FIRST_NAME"].ToString();
                user.emergencyLastName = dt.Rows[0]["EMERGENCY_CONTACT_LAST_NAME"].ToString();
                string emerPhoneFormatted = dt.Rows[0]["EMERGENCY_CONTACT_PHONE"].ToString();
                user.emergencyPhone = formatPhoneNumber(emerPhoneFormatted);
            }

            return user;
        }

        private string formatPhoneNumber(string _phone)
        {
            string phone = _phone;
            if (_phone.Length == 10)
            {
                phone = "(" + phone;
                phone = phone.Insert(4, ") ");
                phone = phone.Insert(9, "-");
            }            

            return phone;
        }

        private string unformatPhoneNumber(string _phone)
        {
            string phone = _phone;
            phone = Regex.Replace(phone, "[^0-9]", "");
            return phone;
        }

        private string formatPostalCode(string _postalCode)
        {
            string formattedPostalCode = "";
            if (_postalCode != "")
            {
                formattedPostalCode = _postalCode.ToUpper();
                formattedPostalCode = formattedPostalCode.Insert(3, " ");
            }
            
            return formattedPostalCode;
        }

        private string unformatPostalCode(string _postalCode)
        {
            string postalCode = "";
            postalCode = _postalCode;
            postalCode = Regex.Replace(_postalCode, "[^0-9A-z]", "");
            postalCode = postalCode.ToUpper();
            return postalCode;
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public int updateOwnerByNumber(int number, string firstName, string lastName, string street, string city, string province, string postalCode, string phone, string email, string emergencyFirstName, string emergencyLastName, string emergencyPhone)
        {
            UserDB uDB = new UserDB();
            return(uDB.updateCustomerInfo(number, firstName, lastName, street, city, province,unformatPostalCode(postalCode), unformatPhoneNumber(phone), email, emergencyFirstName, emergencyLastName, unformatPhoneNumber(emergencyPhone)));
        }

        public int createCustomer(string _firstName, string _lastName, string _street, string _city, string _province, string _postalCode, string _phone, string _email, string _emergencyFirstName, string _emergencyLastName, string _emergencyPhone)
        {
            UserDB uDB = new UserDB();
            return(uDB.createCustomerDB(_firstName, _lastName, _street, _city, _province, unformatPostalCode(_postalCode), unformatPhoneNumber(_phone), _email, _emergencyFirstName, _emergencyLastName, _emergencyPhone));
            
        }





    }





}
