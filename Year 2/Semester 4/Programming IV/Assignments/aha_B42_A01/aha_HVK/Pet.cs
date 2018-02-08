using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aha_HVK
{
    [Serializable]
    public class Pet
    {
        public int number { get; set; }
        public String name { get; set; }
        public char gender { get; set; }
        public char fixedPet{ get; set; }
        public DateTime birthdate { get; set; }
        public int ownerNumber { get; set; }
        public byte picture { get; set; }
        public char size { get; set; }
        public String notes { get; set; }
        public List<Vaccination> vaccination { get; set; }
        public String breed { get; set; }

        public Pet()
        {
            number = -1;
            name = "";
            gender = 'M';
            fixedPet = 'F';
            birthdate = new DateTime(1000, 1, 1);
            ownerNumber = -1;
            picture = 1;
            size = 'M';
            notes = "";
            vaccination = new List<Vaccination>();
            breed = "";
        }

        public Pet(int _number, String _name, char _gender, char _fixedPet, int _ownerNumber, List<Vaccination> _vaccination)
        {
            number = _number;
            name = _name;
            gender = _gender;
            fixedPet = _fixedPet;
            birthdate = new DateTime(1000, 1, 1);
            ownerNumber = _ownerNumber;
            picture = 1;
            size = 'M';
            notes = "";
            vaccination = _vaccination;
            breed = "";
            
        }
        public Pet(int _number, String _name, char _gender, char _fixedPet, int _ownerNumber, List<Vaccination> _vaccination, DateTime _birthdate, String _breed, byte _picture, char _size, String _notes)
        {
            number = _number;
            name = _name;
            gender = _gender;
            fixedPet = _fixedPet;
            vaccination = _vaccination;
            birthdate = _birthdate;
            ownerNumber = _ownerNumber;
            picture = _picture;
            size = _size;
            notes = _notes;
            breed = _breed;
        }      
       

    }
}
