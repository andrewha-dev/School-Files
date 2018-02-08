using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HappyValleyKennels.App_Code.DB;


namespace HappyValleyKennels.App_Code.BLL
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
            birthdate = new DateTime();
            ownerNumber = -1;
            picture = 1;
            size = 'Z';
            notes = "";
            vaccination = new List<Vaccination>();
            breed = "";
        }

        public Pet(int _number, string _name)
        {
            number = _number;
            name = _name;
            gender = 'M';
            fixedPet = 'F';
            birthdate = new DateTime();
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
            birthdate = new DateTime();
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

        public List<Pet> listPets(int _ownerNumber)
        {
            PetDB petDB = new PetDB();
            List<Pet> pets = new List<Pet>();
            DataSet petsDS = petDB.listPetsDB(_ownerNumber);

            DataTable dt = petsDS.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                Pet pet = new Pet();
                pet.number = Convert.ToInt16(row["PET_NUMBER"]);
                pet.name = row["PET_NAME"].ToString();
                pet.gender = Convert.ToChar(row["PET_GENDER"]);
                pet.fixedPet = Convert.ToChar(row["PET_FIXED"]);
                if (row["PET_BREED"] != null)
                    pet.breed = row["PET_BREED"].ToString();
                else
                    pet.breed = "";
                if (row["PET_BIRTHDATE"] !=  DBNull.Value)
                    pet.birthdate = Convert.ToDateTime(row["PET_BIRTHDATE"]);
                else
                    pet.birthdate = new DateTime();
                pet.ownerNumber = Convert.ToInt16(row["own_owner_number"]);
                pet.size = Convert.ToChar(row["dog_size"]);
                if (row["SPECIAL_NOTES"] != null)
                    pet.notes = row["SPECIAL_NOTES"].ToString();
                else
                    pet.notes = "";

                pets.Add(pet);
            }

            return pets;

        }

        public Pet getPet(int _petNum)
        {
            PetDB pDB = new PetDB();
            DataSet petsDS = pDB.getPetDB(_petNum);
            Pet pet = new Pet();
            DataTable dt = petsDS.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                pet.number = Convert.ToInt16(row["PET_NUMBER"]);
                pet.name = row["PET_NAME"].ToString();
                pet.gender = Convert.ToChar(row["PET_GENDER"]);
                pet.fixedPet = Convert.ToChar(row["PET_FIXED"]);
                if (row["PET_BREED"] != null)
                    pet.breed = row["PET_BREED"].ToString();
                else
                    pet.breed = "";
                if (row["PET_BIRTHDATE"] != DBNull.Value)
                    pet.birthdate = Convert.ToDateTime(row["PET_BIRTHDATE"]);
                else
                    pet.birthdate = new DateTime();
                pet.ownerNumber = Convert.ToInt16(row["own_owner_number"]);
                pet.size = Convert.ToChar(row["dog_size"]);
                if (row["SPECIAL_NOTES"] != null)
                    pet.notes = row["SPECIAL_NOTES"].ToString();
                else
                    pet.notes = "";
            }

            return pet;
        }

        public void updatePetByNumber(int petNum, string petName, string petGender, string petFixed, string petBreed, string petBirthdate, string petNotes, string petOwnerNumber, string petSize)
        {
            PetDB obj = new PetDB();
            obj.updatePetInfo(petNum, petName, petGender, petFixed, petBreed, petBirthdate, petNotes, petOwnerNumber, petSize);
           
        }

    }
}
