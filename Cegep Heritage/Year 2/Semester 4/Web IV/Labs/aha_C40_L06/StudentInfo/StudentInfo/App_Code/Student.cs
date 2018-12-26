using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentInfo.App_Code
{
    public class Student
    {
        public int studentId { get; set; }
        public String lastName { get; set; }
        public String firstName { get; set; }
        public String street { get; set; }
        public String city { get; set; }
        public String state { get; set; }
        public int zip { get; set; }
        public String startTerm { get; set; }
        public DateTime birthdate { get; set; }
        public int facultyId { get; set; }
        public int majorId { get; set; }
        public String phone { get; set; }

        public Student(int _studentId, String _lastName, String _firstName, String _street, String _city, String _state, int _zip, String _startTerm, DateTime _birthdate, int _facultyId, int _majorId, String _phone)
        {
            studentId = _studentId;
            lastName = _lastName;
            firstName = _firstName;
            street = _street;
            city = _city;
            state = _state;
            zip = _zip;
            startTerm = _startTerm;
            birthdate = _birthdate;
            facultyId = _facultyId;
            majorId = _majorId;
            phone = _phone;
        }
    }
}