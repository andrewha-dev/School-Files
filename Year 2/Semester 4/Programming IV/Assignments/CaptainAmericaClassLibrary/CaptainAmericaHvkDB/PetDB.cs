using CaptainAmericaHvkDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using Oracle.ManagedDataAccess.Client;


namespace CaptainAmericaHvkDB
{
    public class PetDB
    {
        public DataSet listPetsDB(int _ownerNumber)
        {
            //List<Pet> pets = new List<Pet>();
            ////Owner (4) with only 1 pet
            //if (_scenario == 4)
            //{
            //    pets.Add(new Pet(7, "Charlie", 'M', 'T', 4, new List<Vaccination>(), new DateTime(), "Jack Russell Terrier", 0, 'S', ""));
            //}
            ////Owner (1) with two pets
            //if (_scenario == 1)
            //{
            //    pets.Add(new Pet(1, "Scrabble", 'F', 'T', 1, new List<Vaccination>(), new DateTime(), "Llassapoo", 0, 'S', "Scrabble is terrified of hot air balloons"));
            //    pets.Add(new Pet(2, "Archie", 'F', 'T', 1, new List<Vaccination>(), new DateTime(), "Standard Poodle", 0, 'M', "Archie is extremely shy and very timid around other dogs - she does not do well in an open playtime."));
            //}
            ////Owners (7) with three pets
            //if (_scenario == 7)
            //{
            //    pets.Add(new Pet(10, "Pete", 'M', 'T', 7, new List<Vaccination>(), new DateTime(), "Tibetan Spanial - Sheltie", 0, 'S', ""));
            //    pets.Add(new Pet(11, "Max", 'M', 'T', 7, new List<Vaccination>(), new DateTime(), "Samoyed", 0, 'L', ""));
            //    pets.Add(new Pet(12, "Kitoo", 'F', 'T', 7, new List<Vaccination>(), new DateTime(), "Jack Russell Terrier", 0, 'L', ""));
            //}

            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"select pet_number, pet_name, pet_gender, pet_fixed,pet_breed, pet_birthdate, special_notes, own_owner_number ,dog_size from hvk_pet where own_owner_number = :ownerNum order by PET_NUMBER";


            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("ownerNum", _ownerNumber);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("petsDS");
            da.Fill(ds, "HVK_PETS");
            return ds;

        }

        public DataSet getPetDB(int _petNum)
        {
            String constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(constring);

            String cmdstr = @"SELECT pet_number,
                            pet_name,
                            pet_gender,
                            pet_fixed,
                            pet_breed,
                            pet_birthdate,
                            special_notes,
                            own_owner_number ,
                            dog_size
                            FROM hvk_pet
                            WHERE pet_number = :petNum";


            OracleCommand cmd = new OracleCommand(cmdstr, con);
            cmd.Parameters.Add("petNum", _petNum);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("petsDS");
            da.Fill(ds, "HVK_PETS");
            return ds;
        }

    }
}
