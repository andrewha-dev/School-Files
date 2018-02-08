using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aha_HVK;
namespace B42A02_HVKControl
{
    class HVKControlDB
    {
        public List<User>listOwnersDB()
        {
            List<User> listOfUsers = new List<User>();
            listOfUsers.Add(new User(20, "Anita", "Alibi", new List<Pet>(), new Veterinarian()));
            listOfUsers.Add(new User(16, "Moe", "Bilhome", new List<Pet>(), new Veterinarian()));
            listOfUsers.Add(new User(4, "Mahatma", "Coate", new List<Pet>(), new Veterinarian()));
            listOfUsers.Add(new User(19, "Chester", "Drawers", new List<Pet>(), new Veterinarian()));
            listOfUsers.Add(new User(8, "Amanda", "Linn", new List<Pet>(), new Veterinarian()));
            listOfUsers.Add(new User(14, "Carrie", "Mehome", new List<Pet>(), new Veterinarian()));
            listOfUsers.Add(new User(12, "Ella", "Mentary", new List<Pet>(), new Veterinarian()));
            listOfUsers.Add(new User(5, "Sue", "Metu", new List<Pet>(), new Veterinarian()));
            listOfUsers.Add(new User(17, "Polly", "Morfek", new List<Pet>(), new Veterinarian()));
            listOfUsers.Add(new User(2, "Mike", "O'Phone", new List<Pet>(), new Veterinarian()));
            listOfUsers.Add(new User(13, "Sam", "Ovar", new List<Pet>(), new Veterinarian()));
            listOfUsers.Add(new User(11, "Salton", "Pepper", new List<Pet>(), new Veterinarian()));
            listOfUsers.Add(new User(7, "Peter", "Piper", new List<Pet>(), new Veterinarian()));
            listOfUsers.Add(new User(18, "Barb B.", "Que", new List<Pet>(), new Veterinarian()));
            listOfUsers.Add(new User(10, "April", "Showers", new List<Pet>(), new Veterinarian()));
            listOfUsers.Add(new User(1, "Jane", "Smith", new List<Pet>(), new Veterinarian()));
            listOfUsers.Add(new User(6, "Jeff", "Summers", new List<Pet>(), new Veterinarian()));
            listOfUsers.Add(new User(15, "Bayo", "Wolfe", new List<Pet>(), new Veterinarian()));
            listOfUsers.Add(new User(3, "Dwight", "Wong", new List<Pet>(), new Veterinarian()));
            return listOfUsers;
        }

        public List<Pet>listPetsDB(int _scenario)
        {
            List<Pet> pets = new List<Pet>();
            //Owner (4) with only 1 pet
            if (_scenario == 4)
            {
                pets.Add(new Pet(7, "Charlie", 'M', 'T', 4, new List<Vaccination>(),new DateTime(),"Jack Russell Terrier",0,'S', ""));
            }
            //Owner (1) with two pets
            if (_scenario == 1)
            {
                pets.Add(new Pet(1, "Scrabble", 'F', 'T', 1, new List<Vaccination>(), new DateTime(), "Llassapoo", 0, 'S', "Scrabble is terrified of hot air balloons"));
                pets.Add(new Pet(2, "Archie", 'F', 'T', 1, new List<Vaccination>(), new DateTime(), "Standard Poodle", 0, 'M', "Archie is extremely shy and very timid around other dogs - she does not do well in an open playtime."));
            }
            //Owners (7) with three pets
            if (_scenario == 7)
            {
                pets.Add(new Pet(10, "Pete", 'M', 'T', 7, new List<Vaccination>(), new DateTime(), "Tibetan Spanial - Sheltie", 0, 'S', ""));
                pets.Add(new Pet(11, "Max", 'M', 'T', 7, new List<Vaccination>(), new DateTime(), "Samoyed", 0, 'L', ""));
                pets.Add(new Pet(12, "Kitoo", 'F', 'T', 7, new List<Vaccination>(), new DateTime(), "Jack Russell Terrier", 0, 'L', ""));
            }
            return pets;
        }

        public List<Reservation>listReservationsDB(int _scenario)
        {
            //One existing
            //One not existing
            //Non-existing user number
            //Has to be in the future
            List<Reservation> reservations = new List<Reservation>();
            //Owner number 6
            //Owner only for 1 reservation in the future
            if (_scenario == 6)
            {
                List<PetReservation> petRes = new List<PetReservation>();
                Pet pet = new Pet(9, "Parker", 'M', 'T', 6, new List<Vaccination>());
                petRes.Add(new PetReservation(pet, new Run(), new Food(), new KennelLog()));
                reservations.Add(new Reservation(708, 6, petRes, new DateTime(2017, 4, 15), new DateTime(2017, 4, 20),'C', new List<Discount>()));
            }
            //Owner number 2
            //Looking for multiple reservations
            if (_scenario == 2)
            {
                List<PetReservation> petRes1 = new List<PetReservation>();
                Pet pet1 = new Pet(3, "Jasper", 'M', 'T', 2, new List<Vaccination>(), new DateTime(2005, 4, 4),"Black Lab",0,'L',"");
                petRes1.Add(new PetReservation(pet1, new Run(), new Food(), new KennelLog()));
                reservations.Add(new Reservation(720,2,petRes1,new DateTime(2017, 4, 25), new DateTime(2017,4,30),'C', new List<Discount>()));

                List<PetReservation> petRes2 = new List<PetReservation>();
                Pet pet2 = new Pet(3, "Jasper", 'M', 'T', 2, new List<Vaccination>(), new DateTime(2005, 4, 4), "Black Lab", 0, 'L', "");
                petRes2.Add(new PetReservation(pet1, new Run(), new Food(), new KennelLog()));
                reservations.Add(new Reservation(721,2, petRes2, new DateTime(2017, 4, 5), new DateTime(2017, 4, 9), 'C', new List<Discount>()));
            }

            //Owner number 17
            //Looking for reservations with multple pets in them and varying sizes
            if (_scenario == 17)
            {
                List<PetReservation> petRes1 = new List<PetReservation>();
                Pet pet1 = new Pet(30, "Suki", 'F', 'F', 2, new List<Vaccination>(), new DateTime(), "", 0, 'L', "");
                Pet pet2 = new Pet(31, "Sam", 'M', 'F', 2, new List<Vaccination>(), new DateTime(), "", 0, 'L', "");
                Pet pet3 = new Pet(32, "Snoop Dogg", 'M', 'F', 2, new List<Vaccination>(), new DateTime(), "", 0, 'M', "");
                petRes1.Add(new PetReservation(pet1, new Run(), new Food(), new KennelLog()));
                petRes1.Add(new PetReservation(pet2, new Run(), new Food(), new KennelLog()));
                petRes1.Add(new PetReservation(pet3, new Run(), new Food(), new KennelLog()));

                reservations.Add(new Reservation(717,2, petRes1, new DateTime(2017, 4, 10), new DateTime(2017, 4, 30), 'C', new List<Discount>()));


                List<PetReservation> petRes2 = new List<PetReservation>();
                petRes2.Add(new PetReservation(pet2, new Run(), new Food(), new KennelLog()));
                petRes2.Add(new PetReservation(pet3, new Run(), new Food(), new KennelLog()));
                reservations.Add(new Reservation(900,2, petRes2, new DateTime(2017, 6, 20), new DateTime(2017, 6, 26), 'C', new List<Discount>()));
                
            }

            return reservations;
        }

        public List<Reservation> listActiveReservations()
        {
            //Assuming that the date being tested is September 17, 2015
            //100, 102
            List<Reservation> activeReservations = new List<Reservation>();
            List<PetReservation> petRes1 = new List<PetReservation>();
            Pet pet1 = (new Pet(1, "Scrabble", 'F', 'T', 1, new List<Vaccination>(), new DateTime(), "Llassapoo", 0, 'S', "Scrabble is terrified of hot air balloons"));
            Pet pet2 = (new Pet(2, "Archie", 'F', 'T', 1, new List<Vaccination>(), new DateTime(), "Standard Poodle", 0, 'M', "Archie is extremely shy and very timid around other dogs - she does not do well in an open playtime."));
            petRes1.Add(new PetReservation(pet1, new Run(29, 'R'),new Food(), new KennelLog()));
            petRes1.Add(new PetReservation(pet2, new Run(29, 'R'), new Food(), new KennelLog()));

            activeReservations.Add(new Reservation(100,1, petRes1, new DateTime(2015, 9, 12), new DateTime(2015, 9, 19),'A',new List<Discount>()));

            List<PetReservation> petRes2 = new List<PetReservation>();
            Pet pet3 = new Pet(13, "Logan", 'M', 'T', 3, new List<Vaccination>(), new DateTime(2001, 10, 20), "Bernese Mountain Dog", 0, 'L', "");
            petRes2.Add(new PetReservation(pet3, new Run(28, 'L'), new Food(), new KennelLog()));
            activeReservations.Add(new Reservation(102,3, petRes2, new DateTime(2015, 9, 16), new DateTime(2015, 9, 18), 'A', new List<Discount>()));
            return activeReservations;
        }

        public List<Reservation> listActiveReservations(int _scenario)
        {
            //Assuming that the date being tested is September 17, 2015
            //100, 102
            List<Reservation> activeReservations = new List<Reservation>();
            if (_scenario == 1)
            {
            List<PetReservation> petRes1 = new List<PetReservation>();
            Pet pet1 = (new Pet(1, "Scrabble", 'F', 'T', 1, new List<Vaccination>(), new DateTime(), "Llassapoo", 0, 'S', "Scrabble is terrified of hot air balloons"));
            Pet pet2 = (new Pet(2, "Archie", 'F', 'T', 1, new List<Vaccination>(), new DateTime(), "Standard Poodle", 0, 'M', "Archie is extremely shy and very timid around other dogs - she does not do well in an open playtime."));
            petRes1.Add(new PetReservation(pet1, new Run(29, 'R'), new Food(), new KennelLog()));
            petRes1.Add(new PetReservation(pet2, new Run(29, 'R'), new Food(), new KennelLog()));

            activeReservations.Add(new Reservation(100,1, petRes1, new DateTime(2015, 9, 12), new DateTime(2015, 9, 19), 'A', new List<Discount>()));
            }
            
            if (_scenario == 3)
            {
            List<PetReservation> petRes2 = new List<PetReservation>();
            Pet pet3 = new Pet(13, "Logan", 'M', 'T', 3, new List<Vaccination>(), new DateTime(2001, 10, 20), "Bernese Mountain Dog", 0, 'L', "");
            petRes2.Add(new PetReservation(pet3, new Run(28, 'L'), new Food(), new KennelLog()));
            activeReservations.Add(new Reservation(102,3, petRes2, new DateTime(2015, 9, 16), new DateTime(2015, 9, 18), 'A', new List<Discount>()));
            }
           
            return activeReservations;
        }

        public List<Vaccination> listVaccinations(int _scenario)
        {
            List<Vaccination> vaccines = new List<Vaccination>();
            //If all the pets vaccines exist
            if (_scenario == 1)
            {
                vaccines.Add(new Vaccination(new DateTime(2017, 3, 5), 1, "Bordetella",false));
                vaccines.Add(new Vaccination(new DateTime(2017, 3, 5), 2, "Distemper", false));
                vaccines.Add(new Vaccination(new DateTime(2017, 3, 5), 3, "Hepatitis", false));
                vaccines.Add(new Vaccination(new DateTime(2017, 3, 5), 4, "Parainfluenza", false));
                vaccines.Add(new Vaccination(new DateTime(2017, 3, 5), 5, "Paravirus", false));
                vaccines.Add(new Vaccination(new DateTime(2018, 3, 5), 6, "Rabies", false));
            }
            //Even if some vaccines are missing
            if (_scenario == 2)
            {
                vaccines.Add(new Vaccination(new DateTime(2018, 4, 2), 1, "Bordetella", false));
                vaccines.Add(new Vaccination(new DateTime(2018, 4, 2), 2, "Distemper", false));
                vaccines.Add(new Vaccination(new DateTime(2018, 3, 21), 5, "Paravirus", false));
                vaccines.Add(new Vaccination(new DateTime(2018, 6, 2), 6, "Rabies", false));
            }

            return vaccines;
        }

        public List<Vaccination> checkVaccinations(int _scenario)
        {
            List<Vaccination> vaccines = new List<Vaccination>();
            //Assuming that they enter pet number 6 for reservation 615
       
     
            //Even if some vaccines are missing
            //Assuming they enter pet number 20 for reservation 625
            if (_scenario == 2)
            {
                vaccines.Add(new Vaccination(new DateTime(), 3, "Hepatitis", false));
                vaccines.Add(new Vaccination(new DateTime(), 4, "Parainfluenza", false));
            }
            //All vaccines need to be verified
            //Assuming they enter pet number 1 for reservation 703
            if (_scenario == 3)
            {
                vaccines.Add(new Vaccination(new DateTime(2017, 3, 5), 1, "Bordetella", false));
                vaccines.Add(new Vaccination(new DateTime(2017, 3, 5), 2, "Distemper", false));
                vaccines.Add(new Vaccination(new DateTime(2017, 3, 5), 3, "Hepatitis", false));
                vaccines.Add(new Vaccination(new DateTime(2017, 3, 5), 4, "Parainfluenza", false));
                vaccines.Add(new Vaccination(new DateTime(2017, 3, 5), 5, "Paravirus", false));
                vaccines.Add(new Vaccination(new DateTime(2018, 3, 5), 6, "Rabies", false));
            }



            return vaccines;
        }

        public List<Reservation> upcomingReservations(int _scenario)
        {
            List<Reservation> upcomingReservation = new List<Reservation>();

            //Assuming date is June 20
            if (_scenario == 1)
            {
                List<PetReservation> petRes1 = new List<PetReservation>();
                Pet pet1 = (new Pet(31, "Sam", 'M', 'T', 17, new List<Vaccination>(), new DateTime(), "", 0, 'L', ""));
                Pet pet2 = (new Pet(32, "Snoop Dogg", 'M', 'T', 17, new List<Vaccination>(), new DateTime(), "", 0, 'M', ""));
                petRes1.Add(new PetReservation(pet1, new Run(), new Food(), new KennelLog()));
                petRes1.Add(new PetReservation(pet2, new Run(), new Food(), new KennelLog()));

                upcomingReservation.Add(new Reservation(800,17, petRes1,new DateTime(2017, 6, 20), new DateTime(2017, 6, 26),'C', new List<Discount>()));


                List<PetReservation> petRes2 = new List<PetReservation>();
                Pet pet3 = (new Pet(26, "Skarpa", 'F', 'F', 15, new List<Vaccination>(), new DateTime(), "", 0, 'S', ""));
                Pet pet4 = (new Pet(27, "Bothvar", 'M', 'F', 15, new List<Vaccination>(), new DateTime(), "", 0, 'S', ""));
                petRes2.Add(new PetReservation(pet3, new Run(), new Food(), new KennelLog()));
                petRes2.Add(new PetReservation(pet4, new Run(), new Food(), new KennelLog()));

                upcomingReservation.Add(new Reservation(801, 15, petRes2, new DateTime(2017, 6, 20), new DateTime(2017, 6, 26), 'C', new List<Discount>()));

                List<PetReservation> petRes3 = new List<PetReservation>();
                Pet pet5 = (new Pet(10, "Pete", 'M', 'T', 7, new List<Vaccination>(), new DateTime(), "Tibetan Spanial - Sheltie", 0, 'S', ""));
                Pet pet6 = (new Pet(11, "Max", 'M', 'T', 7, new List<Vaccination>(), new DateTime(), "Samoyed", 0, 'L', ""));
                petRes3.Add(new PetReservation(pet5, new Run(), new Food(), new KennelLog()));
                petRes3.Add(new PetReservation(pet6, new Run(), new Food(), new KennelLog()));

                upcomingReservation.Add(new Reservation(802,7, petRes3, new DateTime(2017, 6, 20), new DateTime(2017, 6, 26), 'C', new List<Discount>()));

                List<PetReservation> petRes4 = new List<PetReservation>();
                Pet pet7 = new Pet(13, "Logan", 'M', 'T', 3, new List<Vaccination>(), new DateTime(2001, 10, 20), "Bernese Mountain Dog", 0, 'L', "");
                petRes4.Add(new PetReservation(pet7, new Run(), new Food(), new KennelLog()));

                upcomingReservation.Add(new Reservation(811,3, petRes4, new DateTime(2017, 6, 20), new DateTime(2017, 7, 5),'C', new List<Discount>()));

                List<PetReservation> petRes5 = new List<PetReservation>();
                Pet pet8 = (new Pet(12, "Kitoo", 'F', 'T', 7, new List<Vaccination>(), new DateTime(), "Jack Russell Terrier", 0, 'L', ""));
                petRes5.Add(new PetReservation(pet6, new Run(), new Food(), new KennelLog()));
                petRes5.Add(new PetReservation(pet8, new Run(), new Food(), new KennelLog()));
                upcomingReservation.Add(new Reservation(809,7, petRes4, new DateTime(2017, 7, 2), new DateTime(2017, 7, 9), 'C', new List<Discount>()));

                List<PetReservation> petRes6 = new List<PetReservation>();
                petRes6.Add(new PetReservation(pet5, new Run(), new Food(), new KennelLog()));
                petRes6.Add(new PetReservation(pet6, new Run(), new Food(), new KennelLog()));
                petRes6.Add(new PetReservation(pet8, new Run(), new Food(), new KennelLog()));

                upcomingReservation.Add(new Reservation(804,7, petRes6, new DateTime(2017, 8, 20), new DateTime(2017, 8, 26), 'C', new List<Discount>()));
            }

            
            //Only 1
            if (_scenario == 2)
            {
                Pet pet5 = (new Pet(10, "Pete", 'M', 'T', 7, new List<Vaccination>(), new DateTime(), "Tibetan Spanial - Sheltie", 0, 'S', ""));
                Pet pet6 = (new Pet(11, "Max", 'M', 'T', 7, new List<Vaccination>(), new DateTime(), "Samoyed", 0, 'L', ""));
                Pet pet8 = (new Pet(12, "Kitoo", 'F', 'T', 7, new List<Vaccination>(), new DateTime(), "Jack Russell Terrier", 0, 'L', ""));
                List<PetReservation> petRes6 = new List<PetReservation>();
                petRes6.Add(new PetReservation(pet5, new Run(), new Food(), new KennelLog()));
                petRes6.Add(new PetReservation(pet6, new Run(), new Food(), new KennelLog()));
                petRes6.Add(new PetReservation(pet8, new Run(), new Food(), new KennelLog()));

                upcomingReservation.Add(new Reservation(804, 7, petRes6, new DateTime(2017, 8, 20), new DateTime(2017, 8, 26), 'C', new List<Discount>()));
            }
            return upcomingReservation;
        }




    }
}
