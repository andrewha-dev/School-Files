using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using aha_HVK;
using CaptainAmericaHvkDB;
using System.Collections.Generic;

namespace CaptainAmericaUnitTests
{
    [TestClass]
    public class UnitTest
    {
        User user = new User();
        [TestMethod]
        public void listOwners()
        {
            List<User> owners = new List<User>();
            owners = user.listOwners();
                Assert.AreEqual(19, owners.Count, "Expected Count ");
        

                Assert.AreEqual(19, owners.Count, "Owner size should be 20");


                Assert.AreEqual("Alibi", owners[0].lastName, "Last name should be Alibi");
                Assert.AreEqual("Anita", owners[0].firstName, "First name should be Anita");

                Assert.AreEqual("Bilhome", owners[1].lastName, "Last name should be Bilhome");
                Assert.AreEqual("Moe", owners[1].firstName, "First name should be Moe");
                Assert.AreEqual("Coate", owners[2].lastName, "Last name should be Coate");
                Assert.AreEqual("Mahatma", owners[2].firstName, "First name should be Mahatma");
                Assert.AreEqual("Drawers", owners[3].lastName, "Last name should be Drawers");
                Assert.AreEqual("Chester", owners[3].firstName, "First name should be Chester");
                Assert.AreEqual("Linn", owners[4].lastName, "Last name should be Linn");
                Assert.AreEqual("Amanda", owners[4].firstName, "First name should be Amanda");
                Assert.AreEqual("Mehome", owners[5].lastName, "Last name should be Mehome");
                Assert.AreEqual("Carrie", owners[5].firstName, "First name should be Carrie");
                Assert.AreEqual("Mentary", owners[6].lastName, "Last name should be Mentary");
                Assert.AreEqual("Ella", owners[6].firstName, "First name should be Ella");
                Assert.AreEqual("Metu", owners[7].lastName, "Last name should be Metu");
                Assert.AreEqual("Sue", owners[7].firstName, "First name should be Sue");
                Assert.AreEqual("Morfek", owners[8].lastName, "Last name should be Morfek");
                Assert.AreEqual("Polly", owners[8].firstName, "First name should be Polly");
                Assert.AreEqual("O'Phone", owners[9].lastName, "Last name should be O'Phone");
                Assert.AreEqual("Mike", owners[9].firstName, "First name should be Mike");
                Assert.AreEqual("Ovar", owners[10].lastName, "Last name should be Ovar");
                Assert.AreEqual("Sam", owners[10].firstName, "First name should be Sam");
                Assert.AreEqual("Pepper", owners[11].lastName, "Last name should be Pepper");
                Assert.AreEqual("Salton", owners[11].firstName, "First name should be Salton");
                Assert.AreEqual("Piper", owners[12].lastName, "Last name should be Piper");
                Assert.AreEqual("Peter", owners[12].firstName, "First name should be Peter");
                Assert.AreEqual("Que", owners[13].lastName, "Last name should be Que");
                Assert.AreEqual("Barb B.", owners[13].firstName, "First name should be Barb B.");
                Assert.AreEqual("Showers", owners[14].lastName, "Last name should be Showers");
                Assert.AreEqual("April", owners[14].firstName, "First name should be April");
                Assert.AreEqual("Smith", owners[15].lastName, "Last name should be Smith");
                Assert.AreEqual("Jane", owners[15].firstName, "First name should be Jane");
                Assert.AreEqual("Summers", owners[16].lastName, "Last name should be Summers");
                Assert.AreEqual("Jeff", owners[16].firstName, "First name should be Jeff");
                Assert.AreEqual("Wolfe", owners[17].lastName, "Last name should be Wolfe");
                Assert.AreEqual("Bayo", owners[17].firstName, "First name should be Bayo");
                Assert.AreEqual("Wong", owners[18].lastName, "Last name should be Wong");
                Assert.AreEqual("Dwight", owners[18].firstName, "First name should be Dwight");

        }

        [TestMethod]
        public void listPets()
        {
            Pet hc = new Pet();
            //Testing 1 pet
            List<Pet> pets = new List<Pet>();
            pets = hc.listPets(4);
            Assert.AreEqual(1, pets.Count, "Pet size should be 1");
            Assert.AreEqual(7, pets[0].number, "Number should be 7");
            Assert.AreEqual("Charlie", pets[0].name, "Name should be Charlie");
            Assert.AreEqual(4, pets[0].ownerNumber, "Owner Number should be 4");
            Assert.AreEqual('M', pets[0].gender, "Gender should be M");
            Assert.AreEqual("Jack Russell Terrier", pets[0].breed, "Expected breed is Jack Russell Terrier");
            Assert.AreEqual('T', pets[0].fixedPet, "Fixed should be T");
            Assert.AreEqual('S', pets[0].size, "Size should be S");
            Assert.AreEqual("", pets[0].notes, "Notes should be null");
            Assert.AreEqual(new DateTime(), pets[0].birthdate, "Birthdate should be Default DateTime - 1/1/0001");

            //Testing 2 pets
            pets = hc.listPets(1);
            Assert.AreEqual(2, pets.Count, "Pet size should be 2");
            Assert.AreEqual(1, pets[0].number, "Number should be 1");
            Assert.AreEqual(2, pets[1].number, "Number should be 2");


            Assert.AreEqual(1, pets[0].number, "Number should be 1");
            Assert.AreEqual("Scrabble", pets[0].name, "Name should be Scrabble");
            Assert.AreEqual(1, pets[0].ownerNumber, "Owner Number should be 1");
            Assert.AreEqual('F', pets[0].gender, "Gender should be F");
            Assert.AreEqual('T', pets[0].fixedPet, "Fixed should be T");
            Assert.AreEqual('S', pets[0].size, "Size should be S");
            Assert.AreEqual("Llassapoo", pets[0].breed, "Expected breed is Llassapoo");
            Assert.AreEqual("Scrabble is terrified of hot air balloons", pets[0].notes, "Notes should be Scrabble is terrified of hot air balloons");
            Assert.AreEqual(new DateTime(), pets[0].birthdate, "Birthdate should be Default DateTime - 1/1/0001");

            Assert.AreEqual(2, pets[1].number, "Number should be 2");
            Assert.AreEqual("Archie", pets[1].name, "Name should be Archie");
            Assert.AreEqual(1, pets[1].ownerNumber, "Owner Number should be 1");
            Assert.AreEqual('F', pets[1].gender, "Gender should be F");
            Assert.AreEqual('T', pets[1].fixedPet, "Fixed should be T");
            Assert.AreEqual('M', pets[1].size, "Size should be M");
            Assert.AreEqual("Standard Poodle", pets[1].breed, "Expected breed is Standard Poodle");
            Assert.AreEqual("Archie is extremely shy and very timid around other dogs - she does not do well in an open playtime.", pets[1].notes, "Notes should be Archie is extremely shy and very timid around other dogs - she does not do well in an open playtime.");
            Assert.AreEqual(new DateTime(), pets[0].birthdate, "Birthdate should be Default DateTime - 1/1/0001");

            //Testing 3 pets
            pets = hc.listPets(7);

            Assert.AreEqual(3, pets.Count, "Pet size should be 3");

            Assert.AreEqual(10, pets[0].number, "Number should be 10");
            Assert.AreEqual("Pete", pets[0].name, "Name should be Pete");
            Assert.AreEqual(7, pets[0].ownerNumber, "Owner Number should be 7");
            Assert.AreEqual('M', pets[0].gender, "Gender should be M");
            Assert.AreEqual('T', pets[0].fixedPet, "Fixed should be T");
            Assert.AreEqual('S', pets[0].size, "Size should be S");
            Assert.AreEqual("Tibetan Spanial - Sheltie", pets[0].breed, "Expected breed is Tibetan Spanial - Sheltie");
            Assert.AreEqual("", pets[0].notes, "Notes should be blank");
            Assert.AreEqual(new DateTime(), pets[0].birthdate, "Birthdate should be Default DateTime - 1/1/0001");

            Assert.AreEqual(11, pets[1].number, "Number should be 11");
            Assert.AreEqual("Max", pets[1].name, "Name should be Max");
            Assert.AreEqual(7, pets[1].ownerNumber, "Owner Number should be 7");
            Assert.AreEqual('M', pets[1].gender, "Gender should be M");
            Assert.AreEqual('T', pets[1].fixedPet, "Fixed should be T");
            Assert.AreEqual('L', pets[1].size, "Size should be L");
            Assert.AreEqual("Samoyed", pets[1].breed, "Expected breed is Samoyed");
            Assert.AreEqual("", pets[1].notes, "Notes should be blank");
            Assert.AreEqual(new DateTime(), pets[1].birthdate, "Birthdate should be Default DateTime - 1/1/0001");

            Assert.AreEqual(12, pets[2].number, "Number should be 12");
            Assert.AreEqual("Kitoo", pets[2].name, "Name should be Kitoo");
            Assert.AreEqual(7, pets[2].ownerNumber, "Owner Number should be 7");
            Assert.AreEqual('F', pets[2].gender, "Gender should be F");
            Assert.AreEqual('T', pets[2].fixedPet, "Fixed should be T");
            Assert.AreEqual('L', pets[2].size, "Size should be L");
            Assert.AreEqual("Samoyed", pets[2].breed, "Expected breed is Samoyed");
            Assert.AreEqual("", pets[2].notes, "");
            Assert.AreEqual(new DateTime(), pets[2].birthdate, "Birthdate should be Default DateTime - 1/1/0001");
        }

        [TestMethod]
        public void listReservationsTest()
        {
            Reservation hc = new Reservation();
            List<Reservation> reservations = new List<Reservation>();
            reservations = hc.listReservations(6);
            //Testing for 1 reservation in the future
            Assert.AreEqual(1, reservations.Count, "Reservation should be size 1");
            Assert.AreEqual(708, reservations[0].number, "Number should be 708");
            Assert.AreEqual(9, reservations[0].petReservation[0].pet.number, "Number should be 9");
            Assert.AreEqual("Parker", reservations[0].petReservation[0].pet.name, "Name should be parker");
            Assert.AreEqual(new DateTime(2017, 4, 15), reservations[0].startDate);
            Assert.AreEqual(new DateTime(2017, 4, 20), reservations[0].endDate);

            //Testing for 2 reservations 
            reservations = hc.listReservations(2);
            Assert.AreEqual(2, reservations.Count, "Reservation should be size 2");
            Assert.AreEqual(720, reservations[0].number, "Number should be 720");
            Assert.AreEqual(3, reservations[0].petReservation[0].pet.number, "Number should be 3");
            Assert.AreEqual("Jasper", reservations[0].petReservation[0].pet.name, "Name should be Jasper");

            Assert.AreEqual(721, reservations[1].number, "Number should be 721");
            Assert.AreEqual(3, reservations[1].petReservation[0].pet.number, "Number should be 3");
            Assert.AreEqual("Jasper", reservations[1].petReservation[0].pet.name, "Name should be Jasper");

            Assert.AreEqual(new DateTime(2017, 4, 25), reservations[0].startDate, "Start date is April 25,2017");
            Assert.AreEqual(new DateTime(2017, 4, 30), reservations[0].endDate, "End Date is April 30,2017");

            Assert.AreEqual(new DateTime(2017, 4, 5), reservations[1].startDate, "Start date is April 5,2017");
            Assert.AreEqual(new DateTime(2017, 4, 9), reservations[1].endDate, "End Date is April 9,2017");



            //Testing for 2 reservations with multiple pets in them
            reservations = hc.listReservations(17);
            Assert.AreEqual(2, reservations.Count, "Reservation should be size 2");
            Assert.AreEqual(717, reservations[0].number, "Number should be 717");
            Assert.AreEqual(30, reservations[0].petReservation[0].pet.number, "Number should be 30");
            Assert.AreEqual("Suki", reservations[0].petReservation[0].pet.name, "Name should be Suki");
            Assert.AreEqual(31, reservations[0].petReservation[1].pet.number, "Number should be 31");
            Assert.AreEqual("Sam", reservations[0].petReservation[1].pet.name, "Name should be Sam");
            Assert.AreEqual(32, reservations[0].petReservation[2].pet.number, "Number should be 32");
            Assert.AreEqual("Snoop Dogg", reservations[0].petReservation[2].pet.name, "Name should be Snoop Dogg");
            Assert.AreEqual(new DateTime(2017, 4, 10), reservations[0].startDate, "Start Date should be 2017-4-10");
            Assert.AreEqual(new DateTime(2017, 4, 25), reservations[0].endDate, "End Date should be 2017-4-25");

            Assert.AreEqual(800, reservations[1].number, "Number should be 800");
            Assert.AreEqual(31, reservations[1].petReservation[0].pet.number, "Number should be 31");
            Assert.AreEqual("Sam", reservations[1].petReservation[0].pet.name, "Name should be Sam");
            Assert.AreEqual(32, reservations[1].petReservation[1].pet.number, "Number should be 32");
            Assert.AreEqual("Snoop Dogg", reservations[1].petReservation[1].pet.name, "Name should be Snoop Dogg");
            Assert.AreEqual(new DateTime(2017, 6, 20), reservations[1].startDate, "Start Date should be 2017-6-20");
            Assert.AreEqual(new DateTime(2017, 6, 26), reservations[1].endDate, "End Date should be 2017-6-26");
        }
        [TestMethod]
        public void listActiveReservations()
        {
            List<Reservation> activeReservations = new List<Reservation>();

            Reservation hc = new Reservation();

            //Testing for all active reservations using September 17 as a reference date
            activeReservations = hc.listActiveReservations();
            Assert.AreEqual(3, activeReservations.Count, "Should only be size 3");
            Assert.AreEqual(1000, activeReservations[0].number, "Number should be 1000");
            Assert.AreEqual("Jane", activeReservations[0].owner.firstName, "First name should be Jane");
            Assert.AreEqual("Smith", activeReservations[0].owner.lastName, "Last name should be Smith");
            Assert.AreEqual(1, activeReservations[0].petReservation[0].pet.number, "Pet number should be 1");
            Assert.AreEqual("Scrabble", activeReservations[0].petReservation[0].pet.name, "Pet name should be Scrabble");
            Assert.AreEqual(2, activeReservations[0].petReservation[1].pet.number, "Pet number should be 2");
            Assert.AreEqual("Archie", activeReservations[0].petReservation[1].pet.name, "Pet name should be Archie");
            Assert.AreEqual('M', activeReservations[0].petReservation[1].pet.size, "Pet size should be M");
            Assert.AreEqual('S', activeReservations[0].petReservation[0].pet.size, "Pet size should be S");
            Assert.AreEqual(22, activeReservations[0].petReservation[0].run.number, "Run number should be 22");
            Assert.AreEqual(22, activeReservations[0].petReservation[1].run.number, "Run number should be 22");
            Assert.AreEqual(new DateTime(2017, 3, 25), activeReservations[0].startDate, "Start date should be 2017-3-25");
            Assert.AreEqual(new DateTime(2017, 4, 20), activeReservations[0].endDate, "End date should be 2017-4-20");

            Assert.AreEqual(1001, activeReservations[1].number, "Number should be 102");
            Assert.AreEqual("Dwight", activeReservations[1].owner.firstName, "First name should be Dwight");
            Assert.AreEqual("Wong", activeReservations[1].owner.lastName, "Last name should be Wong");
            Assert.AreEqual(13, activeReservations[1].petReservation[0].pet.number, "Pet number should be 13");
            Assert.AreEqual("Logan", activeReservations[1].petReservation[0].pet.name, "Pet name should be Logan");
            Assert.AreEqual(-1, activeReservations[1].petReservation[0].run.number, "Run number should be 28");
            Assert.AreEqual(new DateTime(2017, 3, 26), activeReservations[1].startDate, "Start date should be 2017-3-26");
            Assert.AreEqual(new DateTime(2017, 4, 20), activeReservations[1].endDate, "End date should be 2017-4-20");

            //Testing active reservations with an owner number being specified
            //Testing owner number 1
            activeReservations = hc.listActiveReservations(1);
            Assert.AreEqual(1000, activeReservations[0].number, "Number should be 100");
            Assert.AreEqual("Jane", activeReservations[0].owner.firstName, "First name should be Jane");
            Assert.AreEqual("Smith", activeReservations[0].owner.lastName, "Last name should be Smith");
            Assert.AreEqual(1, activeReservations[0].petReservation[0].pet.number, "Pet number should be 1");
            Assert.AreEqual("Scrabble", activeReservations[0].petReservation[0].pet.name, "Pet name should be Scrabble");
            Assert.AreEqual(2, activeReservations[0].petReservation[1].pet.number, "Pet number should be 2");
            Assert.AreEqual("Archie", activeReservations[0].petReservation[1].pet.name, "Pet name should be Archie");
            Assert.AreEqual(22, activeReservations[0].petReservation[0].run.number, "Run number should be 29");
            Assert.AreEqual(22, activeReservations[0].petReservation[1].run.number, "Run number should be 29");
            Assert.AreEqual(new DateTime(2017, 3, 25), activeReservations[0].startDate, "Start date should be 2017-3-25");
            Assert.AreEqual(new DateTime(2017, 4, 20), activeReservations[0].endDate, "End date should be 2017-4-20");

            //Testing owner number 3
            activeReservations = hc.listActiveReservations(3);
            Assert.AreEqual(1001, activeReservations[0].number, "Number should be 1001");
            Assert.AreEqual("Dwight", activeReservations[0].owner.firstName, "First name should be Dwight");
            Assert.AreEqual("Wong", activeReservations[0].owner.lastName, "Last name should be Wong");
            Assert.AreEqual(13, activeReservations[0].petReservation[0].pet.number, "Pet number should be 13");
            Assert.AreEqual("Logan", activeReservations[0].petReservation[0].pet.name, "Pet name should be Logan");
            Assert.AreEqual(-1, activeReservations[0].petReservation[0].run.number, "Run number should be 28");
            Assert.AreEqual(new DateTime(2017, 3, 26), activeReservations[0].startDate, "Start date should be 2015-9-6");
            Assert.AreEqual(new DateTime(2017, 4, 20), activeReservations[0].endDate, "End date should be 2015-9-18");

            //Testing the size
            activeReservations = hc.listActiveReservations();
            Assert.AreEqual(3, activeReservations.Count, "Should only be size 3");

            //Testing none
            activeReservations = hc.listActiveReservations(10);
            Assert.AreEqual(0, activeReservations.Count, "Should be empty");
        }

        [TestMethod]
        public void listVaccinations()
        {
            Vaccination hc = new Vaccination();
            List<Vaccination> vaccineList = new List<Vaccination>();
            vaccineList = hc.listVaccinations(0);
            //Testing for non-existing pet
            Assert.AreEqual(0, vaccineList.Count, "List should be empty");

            //Testing pet 1 with all of its vaccines
            vaccineList = hc.listVaccinations(1);
            Assert.AreEqual("Bordetella", vaccineList[0].name, "Name should be Bordetella");
            Assert.AreEqual("Distemper", vaccineList[1].name, "Name should be Distemper");
            Assert.AreEqual("Hepatitis", vaccineList[2].name, "Name should be Hepatitis");
            Assert.AreEqual("Parainfluenza", vaccineList[3].name, "Name should be Parainfluenza");
            Assert.AreEqual("Parovirus", vaccineList[4].name, "Name should be Paravirus");
            Assert.AreEqual("Rabies", vaccineList[5].name, "Name should be Rabies");

            //Testing expiry dates
            Assert.AreEqual(new DateTime(2017, 3, 5), vaccineList[0].expiryDate, "Expiry date should be 2017-3-5");
            Assert.AreEqual(new DateTime(2017, 3, 5), vaccineList[1].expiryDate, "Expiry date should be 2017-3-5");
            Assert.AreEqual(new DateTime(2017, 3, 5), vaccineList[2].expiryDate, "Expiry date should be 2017-3-5");
            Assert.AreEqual(new DateTime(2017, 3, 5), vaccineList[3].expiryDate, "Expiry date should be 2017-3-5");
            Assert.AreEqual(new DateTime(2017, 3, 5), vaccineList[4].expiryDate, "Expiry date should be 2017-3-5");
            Assert.AreEqual(new DateTime(2018, 3, 5), vaccineList[5].expiryDate, "Expiry date should be 2017-3-5");

            //Testing for validation flags
            Assert.AreEqual('N', vaccineList[0].verified, "Should be verified (N)");
            Assert.AreEqual('N', vaccineList[1].verified, "Should be verified (N)");
            Assert.AreEqual('N', vaccineList[2].verified, "Should be verified (N)");
            Assert.AreEqual('N', vaccineList[3].verified, "Should be verified (N)");
            Assert.AreEqual('N', vaccineList[4].verified, "Should be verified (N)");
            Assert.AreEqual('N', vaccineList[5].verified, "Should be verified (N)");

            //Testing with some missing vaccinations - names
            vaccineList = hc.listVaccinations(7);
            Assert.AreEqual(4, vaccineList.Count, "List should be 4");
            Assert.AreEqual("Bordetella", vaccineList[0].name, "Name should be Bordetella");
            Assert.AreEqual("Distemper", vaccineList[1].name, "Name should be Distemper");
            Assert.AreEqual("Parainfluenza", vaccineList[2].name, "Name should be Parainfluenza");
            Assert.AreEqual("Rabies", vaccineList[3].name, "Name should be Rabies");

            //Testing the expiry date
            Assert.AreEqual(new DateTime(2017, 3, 7), vaccineList[0].expiryDate, "Expiry date should be 2017-3-7");
            Assert.AreEqual(new DateTime(2017, 3, 7), vaccineList[1].expiryDate, "Expiry date should be 2017-3-7");
            Assert.AreEqual(new DateTime(2016, 7, 7), vaccineList[2].expiryDate, "Expiry date should be 2016-7-7");
            Assert.AreEqual(new DateTime(2017, 11, 17), vaccineList[3].expiryDate, "Expiry date should be 2016-7-7");

            //Testing for validation flags
            Assert.AreEqual('Y', vaccineList[0].verified, "Should be verified (Y)");
            Assert.AreEqual('Y', vaccineList[1].verified, "Should be verified (Y)");
            Assert.AreEqual('Y', vaccineList[2].verified, "Should be verified (Y)");
            Assert.AreEqual('Y', vaccineList[3].verified, "Should be verified (Y)");

            //Testing with with verified flags
            vaccineList = hc.listVaccinations(6);
            Assert.AreEqual(6, vaccineList.Count, "List should be 6");
            Assert.AreEqual("Bordetella", vaccineList[0].name, "Name should be Bordetella");
            Assert.AreEqual("Distemper", vaccineList[1].name, "Name should be Distemper");
            Assert.AreEqual("Hepatitis", vaccineList[2].name, "Name should be Hepatitis");
            Assert.AreEqual("Parainfluenza", vaccineList[3].name, "Name should be Parainfluenza");
            Assert.AreEqual("Parovirus", vaccineList[4].name, "Name should be Parovirus");
            Assert.AreEqual("Rabies", vaccineList[5].name, "Name should be Rabies");

            //Testing the expiry date
            Assert.AreEqual(new DateTime(2016, 3, 7), vaccineList[0].expiryDate, "Expiry date should be 2016-3-7");
            Assert.AreEqual(new DateTime(2016, 10, 3), vaccineList[1].expiryDate, "Expiry date should be 2016-10-3");
            Assert.AreEqual(new DateTime(2016, 3, 7), vaccineList[2].expiryDate, "Expiry date should be 2016-3-7");
            Assert.AreEqual(new DateTime(2016, 3, 7), vaccineList[3].expiryDate, "Expiry date should be 2016-3-7");
            Assert.AreEqual(new DateTime(2016, 3, 7), vaccineList[4].expiryDate, "Expiry date should be 2016-3-7");
            Assert.AreEqual(new DateTime(2017, 8, 7), vaccineList[5].expiryDate, "Expiry date should be 2016-8-7");

            //Testing for validation flags
            Assert.AreEqual('Y', vaccineList[0].verified, "Should be verified (Y)");
            Assert.AreEqual('Y', vaccineList[1].verified, "Should be verified (Y)");
            Assert.AreEqual('Y', vaccineList[2].verified, "Should be verified (Y)");
            Assert.AreEqual('Y', vaccineList[3].verified, "Should be verified (Y)");
            Assert.AreEqual('Y', vaccineList[4].verified, "Should be verified (Y)");
            Assert.AreEqual('Y', vaccineList[5].verified, "Should be verified (Y)");

            //Testing for validatated flags

        }

        [TestMethod]
        public void checkVaccinations()
        {
            List<Vaccination> vaccineList = new List<Vaccination>();
            Vaccination hc = new Vaccination();
            //Testing all valid
            vaccineList = hc.checkVaccinations(108, 3);
            Assert.AreEqual(0, vaccineList.Count, "Vaccine list should be empty");

            //Testing partial valid/some vaccines are missing
            vaccineList = hc.checkVaccinations(620, 7);
            Assert.AreEqual(2, vaccineList.Count, "Size should be 2");
            //Testing expiry date
            Assert.AreEqual(new DateTime(), vaccineList[0].expiryDate, "Expiry date should be default/min value");
            Assert.AreEqual(new DateTime(), vaccineList[1].expiryDate, "Expiry date should be default/min value");
            //Testing vaccination name
            Assert.AreEqual("Hepatitis", vaccineList[0].name, "Name should be Hepatitis");
            Assert.AreEqual("Parovirus", vaccineList[1].name, "Name should be Parovirus");
            //Testing validation flags
            Assert.AreEqual('N', vaccineList[0].verified, "Validation should be N");
            Assert.AreEqual('N', vaccineList[0].verified, "Validation should be N");

            //Testing All invalid
            vaccineList = hc.checkVaccinations(703, 1);
            Assert.AreEqual(6, vaccineList.Count, "Size should be 6");

            //Testing expiry dates
            Assert.AreEqual(new DateTime(), vaccineList[0].expiryDate, "Expiry date should be default");
            Assert.AreEqual(new DateTime(), vaccineList[1].expiryDate, "Expiry date should be default");
            Assert.AreEqual(new DateTime(), vaccineList[2].expiryDate, "Expiry date should be default");
            Assert.AreEqual(new DateTime(), vaccineList[3].expiryDate, "Expiry date should be default");
            Assert.AreEqual(new DateTime(), vaccineList[4].expiryDate, "Expiry date should be default");
            Assert.AreEqual(new DateTime(), vaccineList[5].expiryDate, "Expiry date should be default");

            //Testing names
            Assert.AreEqual("Bordetella", vaccineList[0].name, "Bordetella");
            Assert.AreEqual("Distemper", vaccineList[1].name, "Name should be Distemper");
            Assert.AreEqual("Hepatitis", vaccineList[2].name, "Name should be Hepatitis");
            Assert.AreEqual("Parainfluenza", vaccineList[3].name, "Name should be Parainfluenza");
            Assert.AreEqual("Parovirus", vaccineList[4].name, "Name should be Paravirus");
            Assert.AreEqual("Rabies", vaccineList[5].name, "Name should be Rabies");

            //Testing validation flags
            Assert.AreEqual('N', vaccineList[0].verified, "Validation should be false");
            Assert.AreEqual('N', vaccineList[1].verified, "Validation should be false");
            Assert.AreEqual('N', vaccineList[2].verified, "Validation should be false");
            Assert.AreEqual('N', vaccineList[3].verified, "Validation should be false");
            Assert.AreEqual('N', vaccineList[4].verified, "Validation should be false");
            Assert.AreEqual('N', vaccineList[5].verified, "Validation should be false");
        }

        [TestMethod]
        public void upcomingReservations()
        {
            Reservation hc = new Reservation();
            List<Reservation> upcomingReservations = new List<Reservation>();
            //No upcoming reservations
            upcomingReservations = hc.listUpcomingReservations(new DateTime(2017, 8, 21));
            Assert.AreEqual(0, upcomingReservations.Count, "Size should be 0");

            //Testing multiple reservations on the same day and in the future
            //Assuming that the date being tested is June 20, 2017
            upcomingReservations = hc.listUpcomingReservations(new DateTime(2017, 6, 19));
            Assert.AreEqual(6, upcomingReservations.Count, "Size should be 6");

            //Testing the reservation numbers
            Assert.AreEqual(800, upcomingReservations[0].number, "Number should be 800");
            Assert.AreEqual(801, upcomingReservations[1].number, "Number should be 801");
            Assert.AreEqual(802, upcomingReservations[2].number, "Number should be 802");
            Assert.AreEqual(811, upcomingReservations[3].number, "Number should be 811");
            Assert.AreEqual(809, upcomingReservations[4].number, "Number should be 809");
            Assert.AreEqual(804, upcomingReservations[5].number, "Number should be 804");

            //Testing the owner number
            Assert.AreEqual(17, upcomingReservations[0].owner.number, "Number should be 17");
            Assert.AreEqual(15, upcomingReservations[1].owner.number, "Number should be 15");
            Assert.AreEqual(7, upcomingReservations[2].owner.number, "Number should be 7");
            Assert.AreEqual(3, upcomingReservations[3].owner.number, "Number should be 3");
            Assert.AreEqual(7, upcomingReservations[4].owner.number, "Number should be 7");
            Assert.AreEqual(7, upcomingReservations[5].owner.number, "Number should be 7");

            //Testing the pet number
            Assert.AreEqual(31, upcomingReservations[0].petReservation[0].pet.number, "Pet number should be 31");
            Assert.AreEqual(32, upcomingReservations[0].petReservation[1].pet.number, "Pet number should be 32");

            Assert.AreEqual(26, upcomingReservations[1].petReservation[0].pet.number, "Pet number should be 26");
            Assert.AreEqual(27, upcomingReservations[1].petReservation[1].pet.number, "Pet number should be 27");

            Assert.AreEqual(10, upcomingReservations[2].petReservation[0].pet.number, "Pet number should be 10");
            Assert.AreEqual(11, upcomingReservations[2].petReservation[1].pet.number, "Pet number should be 11");

            Assert.AreEqual(13, upcomingReservations[3].petReservation[0].pet.number, "Pet number should be 13");

            Assert.AreEqual(11, upcomingReservations[4].petReservation[0].pet.number, "Pet number should be 11");
            Assert.AreEqual(12, upcomingReservations[4].petReservation[1].pet.number, "Pet number should be 12");

            Assert.AreEqual(10, upcomingReservations[5].petReservation[0].pet.number, "Pet number should be 10");
            Assert.AreEqual(11, upcomingReservations[5].petReservation[1].pet.number, "Pet number should be 11");
            Assert.AreEqual(12, upcomingReservations[5].petReservation[2].pet.number, "Pet number should be 12");

            //Testing the start date of the reservations
            Assert.AreEqual(new DateTime(2017, 6, 20), upcomingReservations[0].startDate, "Start date should be 2017-6-20");
            Assert.AreEqual(new DateTime(2017, 6, 20), upcomingReservations[1].startDate, "Start date should be 2017-6-20");
            Assert.AreEqual(new DateTime(2017, 6, 20), upcomingReservations[2].startDate, "Start date should be 2017-6-20");
            Assert.AreEqual(new DateTime(2017, 6, 26), upcomingReservations[3].startDate, "Start date should be 2017-6-20");
            Assert.AreEqual(new DateTime(2017, 7, 2), upcomingReservations[4].startDate, "Start date should be 2017-7-2");
            Assert.AreEqual(new DateTime(2017, 8, 20), upcomingReservations[5].startDate, "Start date should be 2017-8-20");

            //Testing the end date of the reservations
            Assert.AreEqual(new DateTime(2017, 6, 26), upcomingReservations[0].endDate, "End date should be 2017-6-26");
            Assert.AreEqual(new DateTime(2017, 6, 26), upcomingReservations[1].endDate, "End date should be 2017-6-26");
            Assert.AreEqual(new DateTime(2017, 6, 26), upcomingReservations[2].endDate, "End date should be 2017-6-26");
            Assert.AreEqual(new DateTime(2017, 7, 5), upcomingReservations[3].endDate, "End date should be 2017-6-26");
            Assert.AreEqual(new DateTime(2017, 7, 9), upcomingReservations[4].endDate, "End date should be 2017-6-26");
            Assert.AreEqual(new DateTime(2017, 8, 26), upcomingReservations[5].endDate, "End date should be 2017-6-26");


            //Testing a single reservation
            //Testing the count of a single reservation
            upcomingReservations = hc.listUpcomingReservations(new DateTime(2017, 8, 1));
            Assert.AreEqual(1, upcomingReservations.Count, "Size should only be 1");

            //Testing reservation number
            Assert.AreEqual(804, upcomingReservations[0].number, "Number should be 804");

            //Testing owner number
            Assert.AreEqual(7, upcomingReservations[0].owner.number, "Number should be 7");

            //Testing pet number
            Assert.AreEqual(10, upcomingReservations[0].petReservation[0].pet.number, "Pet number should be 10");
            Assert.AreEqual(11, upcomingReservations[0].petReservation[1].pet.number, "Pet number should be 11");
            Assert.AreEqual(12, upcomingReservations[0].petReservation[2].pet.number, "Pet number should be 12");

            //Testing start date of the reservation
            Assert.AreEqual(new DateTime(2017, 8, 20), upcomingReservations[0].startDate, "Start date should be 2017-8-20");

            //Testing the end date of the reservation
            Assert.AreEqual(new DateTime(2017, 8, 26), upcomingReservations[0].endDate, "End date should be 2017-6-26");
        }

        ///*<Summary>
        //* We are testing the following methods using hardcoded data from the database to use a reference
        //* Each method has been slightyly modified in order to accept in an int parameter in order to return our desired condition 
        //* which in this situation is what we are testing for. Our conditions are assigned integer values:
        //* 
        //* -----------------------Code Values------------------
        //* Default Codes:
        //* 0 - Default return code
        //* 
        //* Success Codes:
        //* 1 - Successful reservation addition
        //* 2 - Successful reservation addition but one or more pets has a missing or expired vaccine
        //* 3 - Two dogs sharing a run has been successfully added
        //* 4 - A dog that has been added to a reservation sharing a run with an existing pet in the reservation
        //* 5 - Reservation is successfully cancelled
        //* 6 - Reservation has been successfully changed
        //* 7 - Two solo dogs are now sharing their runs
        //* 8 - Twp dogs sharing are now solo
        //* 9 - Pet has been successfully removed and reservation has been cancelled (1 pet in reservation)
        //* 10 - Pet has been successfully removed (Multiple pets in reservation)
        //* 11 - All pet vaccination are up to date
        //* 
        //* Error Codes:
        //* -1 - Pet number not found
        //* -2 - End date before start date
        //* -3 - Start date is in the past
        //* -4 - No runs are available
        //* -5 - Pet has a conflicting reservation
        //* -6 - Pets don't belong to the same owner
        //* -7 - Reservation has already been completed
        //* -8 - Reservation doesn't exist
        //* -9 - First parameter of pet number is the same as the other
        //* -10 - Pet size / run mismatch when trying to share runs
        //* -11 - Pet isn't in the reservation
        //* -12 - Pets are already sharing runs
        //* -13 - Pets are already solo
        //* -14 - Pet has missing vaccines
        //* -15 - Pet has expired vaccines
        //* -16 - Pet already in reservation
        //* -17 - Pet 2 doesn't exist
        //* -18 - Pet 2 has conflicting reservation
        //* 
        //* </Summary>
        //*/

        //ManageReservation m = new ManageReservation();
        [TestMethod]
        public void AddReservation1Pet()
        {
            Reservation res = new Reservation();
            //    //----------- Success Tests
            //    //
            //    //Test Method:      Get a successful addition
            //    //Input Parameters: petNumber - 2
            //    //                  startDate - 12-Sept-15
            //    //                  endDate - 19-Sept-15
            //    //Expected Result:  1     
            Assert.AreEqual(1, res.addReservation(2, new DateTime(2017, 4, 20), new DateTime(2017, 4, 25)), "This should be a successful addition returning status code 1");

            //    //Test Method:      Get a succesful addition but missing vaccinations
            //    //Input Parameters: petNumber - 20
            //    //                  startDate - 7-January-17
            //    //                  endDate - 9-January-17
            //    //Expected Result:  2 
            //    Assert.AreEqual(2, m.addReservation(20, new DateTime(2015, 9, 12), new DateTime(2015, 9, 19), 2), "This should be a successful addition but missing vaccines returning status code 2");

            //    //Failed Tests
            //    //
            //    //Test Method:      Get error pet not found
            //    //Input Parameters: prtNumber - -50
            //    //                  startDate - 7-January-17
            //    //                  endDate - 9-January-17
            //    //Expected Result:  -1
            //
            Assert.AreEqual(-1, res.addReservation(-50, new DateTime(2017, 1, 7), new DateTime(2017, 1, 9)), "Pet should be missing with status of -1");


            //    //Test Method:      Get error end date before start date
            //    //Input Parameters: prtNumber - 20
            //    //                  startDate - 9-January-17
            //    //                  endDate - 7-January-17
            //    //Expected Result:  -2
             Assert.AreEqual(-2, res.addReservation(20, new DateTime(2017, 1, 9), new DateTime(2017, 1, 7)), "End date before start date -2");

            //    //Test Method:      Error: Start date is in the past
            //    //Input Parameters: petNumber - 20
            //    //                  start - 7-January-16
            //    //                  endDate - 9-January-16
            //    //Expected Result:  -3
                Assert.AreEqual(-3, res.addReservation(20, new DateTime(2016, 1, 7), new DateTime(2016, 1, 9)), "Start date is in the past -3");

            //    //Test Method:      Error: No runs are available
            //    //Input Parameters: petNumber - 20
            //    //                  startDate - 7-January-17
            //    //                  endDate - 9-January-17
            //    //                  CheckRunAvailability - false
            //    //Expected Result:  -4
            //    Assert.AreEqual(-4, m.addReservation(20, new DateTime(2017, 1, 7), new DateTime(2017, 1, 9), 6), "No runs available -4");

            //    //Test Method:      Error: Pet has a conflicting reservation
            //    //Input Parameters: petNumber - 1
            //    //                  startDate - 13-Septemer-15
            //    //                  Parm3 - 18-Septemer-15
            //    //Expected Result:  -5
            //    Assert.AreEqual(-5, m.addReservation(1, new DateTime(2015, 9, 13), new DateTime(2015, 9, 18), 7), "Pet has a conflicting reservation -5");
        }

        [TestMethod]
        public void AddReservation2Pets()
        {
            Reservation res = new Reservation();
            //-------------------Success Tests
            //
            //Test Method:      Get a succesful addition
            //Input Parameters: petNumber1 : 12
            //                  petNumber2 : 11
            //                  startDate : 15-Apr-17
            //                  endDate : 20-Apr-17
            //Expected Result:  1     
            Assert.AreEqual(1, res.addReservation(12, 11, new DateTime(2017, 4, 15), new DateTime(2017, 4, 20)), "Successful addition for two pets 1");

            //Test Method:      Get a succesful addition but missing vaccinations
            //Input Parameters: prtNumber1 : 3
            //                  petNumber2 : 6
            //                  startDate : 10-Apr-16
            //                  endDate : 17-Apr-16
            //Expected Result:  2  
            Assert.AreEqual(2, res.addReservation(3, 6, new DateTime(2017, 4, 20), new DateTime(2017, 4, 30)), "Successful addition for two pets but one or both are missing vaccines");

            //-----------------------Tests Fail
            //Test Method:      Get error pet not found (can be either one)
            //Input Parameters: petNumber1 - -50
            //                  petnumber2 - 3
            //                  startDate - 7-January-17
            //                  endDate - 9-January-17
            //Expected Result:  -1
            Assert.AreEqual(-1, res.addReservation(-50, 3, new DateTime(2017, 1, 7), new DateTime(2017, 1, 9)), "One of the pets number not found -1");

            //-----------------------Tests Fail
            //Test Method:      Get error second pet not found ()
            //Input Parameters: petNumber1 - 10
            //                  petnumber2 - 50
            //                  startDate - 7-January-17
            //                  endDate - 9-January-17
            //Expected Result:  -17
            Assert.AreEqual(-17, res.addReservation(10, 50, new DateTime(2017, 1, 7), new DateTime(2017, 1, 9)), "One of the pets number not found -1");

            //Test Method:      Get error end date before start date
            //Input Parameters: petNumber1 - 20
            //                  petNumber2 - 3
            //                  startDate - 9-January-17
            //                  endDate - 7-January-17
            //Expected Result:  -2
            Assert.AreEqual(-2, res.addReservation(20, 3, new DateTime(2017, 1, 9), new DateTime(2017, 1, 7)), "End date before the start date -2");

            //Test Method:      Pets don't belong to the same owner
            //Input Parameters: petNumber1 - 1
            //                  petNumber2 - 13
            //                  startDate - 7-January-17
            //                  endDate - 9-January-17
            //Expected Result:  -6
            Assert.AreEqual(-6, res.addReservation(1, 13, new DateTime(2017, 1, 7), new DateTime(2017, 1, 9)), "Pets don't belong to the same owner -6");

            //Test Method:      Error: Start date is in the past
            //Input Parameters: petNumber1 - 20
            //                  petNumber2 - 3
            //                  start - 7-January-16
            //                  endDate - 9-January-16
            //Expected Result:  -3
            Assert.AreEqual(-3, res.addReservation(10, 11, new DateTime(2016, 1, 7), new DateTime(2016, 1, 9)), "Start date is in the past -6");

            //Test Method:      Error: No runs are available
            //Input Parameters: petNumber1 - 20
            //                  petNumber2 - 13
            //                  startDate - 7-January-17
            //                  endDate - 9-January-17
            //                  CheckRunAvailability - false
            //Expected Result:  -4
            //Assert.AreEqual(-4, res.addReservation(10, 11, new DateTime(2017, 4, 7), new DateTime(2017, 5, 9)), "No runs available -4");

            //Test Method:      Error: Pet has a conflicting reservation
            //Input Parameters: petNumber2 - 1
            //                  petNumber2 - 3
            //                  startDate - 13-Septemer-15
            //                  Parm3 - 18-Septemer-15
            //Expected Result:  -5
            //Assert.AreEqual(-5, res.addReservation(1, 2, new DateTime(2015, 9, 13), new DateTime(2015, 9, 18)), "Pet has a conflicting reservation -5");

            //Test Method:      Error: Duplicate pet number
            //Input Parameters: petNumber2 - 1
            //                  petNumber2 - 1
            //                  startDate - 13-Septemer-15
            //                  endDate - 18-Septemer-15
            //Expected Result:  -8
            Assert.AreEqual(-8, res.addReservation(1, 1, new DateTime(2015, 9, 13), new DateTime(2015, 9, 18)), "Duplicate pet number listed -8");


        }


        [TestMethod]
        public void AddToReservation1Pet()
        {
            Reservation res = new Reservation();


            //----------------------------------------------- Success Tests
            //
            //Test Method:      Get a succesful addition
            //Input Parameters: petNumber : 30
            //                  resNumber : 146
            //Expected Result:  1      
            //Need methods from teammate in order for this method to properly work
            //Assert.AreEqual(1, res.addToReservation(1002, 12), "Successful Addition || Status = 1");

            //Test Method:      Get a succesful addition but missing vaccinations -> Creating our own object, pet will have a missing vaccination
            //Input Parameters: petNumber : 989
            //                  resNumber : 615
            //Expected Result:  2  

            //Assert.AreEqual(2, res.addToReservation(1002,11), "Successful Addition - Missing/Expired Vaccinations || Status = 2");

            //------------------------------------------------ Failed Tests
            //
            //Test Method:      Reservation has already ended
            //Input Parameters: petNumber - 32
            //                  resNumber - 701
            //Expected Result:  -7

            Assert.AreEqual(-7, res.addToReservation(701, 32), "Reservation should have been ended");


            //Test Method:      Pets don't belong to the same owner
            //Input Parameters: petNumber - 32
            //                  resNumber - 703
            //Expected Result:  -6

            //Need to fix logic error for this test case
            //Assert.AreEqual(-6, res.addToReservation(1002, 14), "Pets don't belong to the same owner || Status = -6");



            //Test Method:      Pet number is invalid
            //Input Parameters: petNumber - -10
            //                  resNumber - 137
            //Expected Result:  -1
            Assert.AreEqual(-1, res.addToReservation(137, -10), "Pet does not exist || Status = -1");


            //Test Method:      Reservation number invalid
            //Input Parameters: petNumber - 32
            //                  resNumber - 666
            //Expected Result:  -8
            Assert.AreEqual(-8, res.addToReservation(666, 32), "Reservation should not exist");

            //Test Method:      Error: No runs are available
            //Input Parameters: petNumber - 32
            //                  resNumber - 701
            //                  CheckRunAvailability - false
            //Expected Result:  -4

            //Assert.AreEqual(-4, m.addToReservation(32, 701, -4), "No Runs Available || Status = -4");


            //Test Method:      Error: Pet has a conflicting reservation -> Create custom reservation object with conflicting reservation dates
            //Input Parameters: petNumber - 1
            //                  resNumber - 777(Custom Reservation with conflicting dates)
            //Expected Result:  -5

            
            //Assert.AreEqual(-5, res.addToReservation(1000, 10), "Pet has Conflicting Reservation || Status = -5");


        }
       


        //[TestMethod]
        //public void checkVaccination()
        //{
        //    //--------------Success
        //    //Test Method:      Check vaccinations for a pet with all valid vaccinations
        //    //Input Parameters: petNumber: 13
        //    //                : byDate: 18-Sep-15
        //    //Expected Result:  11
        //    Assert.AreEqual(11, m.checkVaccination(13, new DateTime(2015, 9, 18), 1), "Should return 11 for pet number 13 at September 18, 2015");

        //    //------------------------------------------------------------------Failure
        //    //Test Method:      Check vaccinations for a pet with missing vaccination(s)
        //    //Input Parameters: petNumber: 3
        //    //                : byDate: 17-Sep-16
        //    //Expected Result:  -14
        //    Assert.AreEqual(-14, m.checkVaccination(3, new DateTime(2016, 9, 17), 2), "Should return -14 for pet number 3 at September 17, 2015");

        //    //Test Method:      Check vaccinations for a pet with vaccination(s) that will expire before the due date
        //    //Input Parameters: petNumber: 6
        //    //                : byDate: 17-Apr-16
        //    //Expected Result:  -15
        //    Assert.AreEqual(-15, m.checkVaccination(6, new DateTime(2016, 4, 17), 3), "Should -15 false for pet number 3 at April 17, 2016");

        //    //Test Method:      Check vaccinations for a pet with vaccination(s) that will expire ON the due date
        //    //Input Parameters: petNumber: 6
        //    //                : byDate: 5-Sep-17
        //    //Expected Result:  -15
        //    Assert.AreEqual(-15, m.checkVaccination(6, new DateTime(2017, 4, 17), 4), "Should -15 false for pet number 6 at September 5, 2017");
        //}


        //[TestMethod]
        //public void DeleteDogFromReservation()
        //{
        //    //----------------------------------------------- Success Tests

        //    //Test Method:      Success for removing a reservation with 1 pet
        //    //Input Parameters: resNumber: 102
        //    //                : petNumber: 13
        //    //Expected Result:  9


        //    Assert.AreEqual(9, m.deleteDogFromReservation(102, 13, 9), "Successful Removal - Reservation is Cancelled || Status = 9");

        //    //Test Method:      Success for removing a reservation with multiple pets
        //    //Input Parameters: resNumber: 106
        //    //                : petNumber: 3
        //    //Expected Result:  10
        //    Assert.AreEqual(10, m.deleteDogFromReservation(106, 3, 10), "Successful Removal || Status = 10");


        //    //------------------------------------------------ Failed Tests

        //    //Test Method: Reservation already in the past
        //    //Input Parameters: resNumber: 106
        //    //                : petNumber: 3
        //    //Expected Result:  -7

        //    Assert.AreEqual(-7, m.deleteDogFromReservation(106, 3, -7), "Reservation has already ended || Status = -7");

        //    //Test Method: Reservation doesn't exist
        //    //Input Parameters: resNumber: 666
        //    //                : petNumber: 3
        //    //Expected Result:  -8

        //    Assert.AreEqual(-8, m.deleteDogFromReservation(666, 3, -8), "Reservation does not exist || Status = -8");

        //    //Test Method: Pet number doesn't exist
        //    //Input Parameters: resNumber: 106
        //    //                : petNumber: 10
        //    //Expected Result:  -1

        //    Assert.AreEqual(-1, m.deleteDogFromReservation(106, 10, -1), "Pet number doesn't exist || Status = -1");
        //}

        //[TestMethod]
        //public void checkRunAvailability()
        //{
        //    //----------------------------------------------- Success Tests

        //    //Test Method:     Runs are available
        //    //Input Parameters: startDate 1-Jan-16
        //    //                : endDate  20-Jan-16
        //    //                : runSize M
        //    //Expected Result:  true
        //    Assert.AreEqual(true, m.checkRunAvailability(new DateTime(2016, 01, 01), new DateTime(2016, 01, 20), 'M', 1), "Pet number doesn't exist || True");


        //    //------------------------------------------------ Failed Tests

        //    //Test Method:     Runs are not available
        //    //Input Parameters: startDate - 1-Apr-16
        //    //                : endDate - 20-Apr-16
        //    //                : runSize - L
        //    //Expected Result:  false

        //    Assert.AreEqual(false, m.checkRunAvailability(new DateTime(2016, 04, 01), new DateTime(2016, 04, 20), 'L', -1), "Runs are not available || False");


        //    //Test Method:     Runs size not availabless
        //    //Input Parameters: startDate - 1-Jan-16
        //    //                : endDate - 20-Jan-16
        //    //                : runSize - X
        //    //Expected Result:  false

        //    Assert.AreEqual(false, m.checkRunAvailability(new DateTime(2016, 01, 01), new DateTime(2016, 01, 20), 'X', -1), "Runs size not available || False");

        //    //Test Method:    Start Date after end Date
        //    //Input Parameters: startDate - 20-Jan-16
        //    //                : endDate - 1-Jan-16
        //    //                : runSize  - L
        //    //Expected Result:  false

        //    Assert.AreEqual(false, m.checkRunAvailability(new DateTime(2016, 01, 20), new DateTime(2016, 01, 01), 'L', -1), "Start Date after end date || False");

        //}

        //[TestMethod]
        //public void AddReservation()
        //{
        //    //----------- Success Tests
        //    //
        //    //Test Method:      Get a successful addition
        //    //Input Parameters: petNumber - 2
        //    //                  startDate - 12-Sept-15
        //    //                  endDate - 19-Sept-15
        //    //Expected Result:  1     
        //    Assert.AreEqual(1, m.addReservation(2, new DateTime(2015, 9, 12), new DateTime(2015, 9, 19), 1), "This should be a successful addition returning status code 1");

        //    //Test Method:      Get a succesful addition but missing vaccinations
        //    //Input Parameters: petNumber - 20
        //    //                  startDate - 7-January-17
        //    //                  endDate - 9-January-17
        //    //Expected Result:  2 
        //    Assert.AreEqual(2, m.addReservation(20, new DateTime(2015, 9, 12), new DateTime(2015, 9, 19), 2), "This should be a successful addition but missing vaccines returning status code 2");

        //    //Failed Tests
        //    //
        //    //Test Method:      Get error pet not found
        //    //Input Parameters: petNumber - -50
        //    //                  startDate - 7-January-17
        //    //                  endDate - 9-January-17
        //    //Expected Result:  -1
        //    Assert.AreEqual(-1, m.addReservation(-50, new DateTime(2017, 1, 7), new DateTime(2017, 1, 9), 3), "Pet should be missing with status of -1");
        //}

        //[TestMethod]
        //public void CancelReservation()
        //{
        //    //-----------------------------------------------------------Tests successful
        //    //Test Method:      Successful Cancellation before it has begun
        //    //Input Parameters: resNumber: 632
        //    //Expected Result:  5
        //    Assert.AreEqual(5, m.cancelReservation(632, 1), "This should remove the reservation successfully and return the success code 5");

        //    //Test Method:      Successful Cancellation while it is in progess
        //    //Input Parameters: resNumber: 701
        //    //Please note: It has been decided upon the team that if a reservation is in progress,
        //    //And a owner wishes to 'cancel' then technically we are changing the end date to today
        //    //Expected Result:  6
        //    Assert.AreEqual(6, m.cancelReservation(701, 2), "This should still cancel the reservation and return the success code 6");

        //    //------------------------------------------------------------------Tests fail
        //    //
        //    //Test Method:      Reservation doesn't exist
        //    //Input Parameters: resNumber: 1337
        //    //Expected Result:  -8
        //    Assert.AreEqual(-8, m.cancelReservation(1337, 3), "This should return the error code -8 since the reservation doesn't exist");

        //    //Test Method:      Reservation has already ended
        //    //Input Parameters: resNumber: 100
        //    //Expected Result:  -7
        //    Assert.AreEqual(-7, m.cancelReservation(100, 4), "This should return the error code -7 since the reservation is already ended");

        //}

        //[TestMethod]
        //public void ChangeReservation()
        //{
        //    //------------------------------------------------------------------Tests success

        //    //Test Method:      Date is successfully changed (End date hasn't expired yet in progress)
        //    //Input Parameters: resNumber: 631
        //    //                : startDate: 1-Jan-2017
        //    //                : endDate  : 01-Mar-2017
        //    //Expected Result:  6
        //    Assert.AreEqual(6, m.changeReservation(631, new DateTime(2017, 1, 1), new DateTime(2017, 3, 1), 1), "This should return the success code indicating it was successful");


        //    //Test Method:      Date is succesfully changed (Reservation has already began)
        //    //Input Parameters: resNumber: 707
        //    //                : startDate: 15-Mar-17
        //    //                : endDate  : 23-Mar-17
        //    //Expected Result:  6
        //    Assert.AreEqual(6, m.changeReservation(707, new DateTime(2017, 3, 15), new DateTime(2017, 3, 23), 2), "This should return the success code indicating it was successful (even if the reservation is in progress)");

        //    //------------------------------------------------------------------Tests fail

        //    //Test Method:      Start date after end date
        //    //Input Parameters: resNumber: 102
        //    //                : startDate: 31-Mar-2017
        //    //                : endDate  : 01-Mar-2017
        //    //Expected Result:  -2
        //    Assert.AreEqual(-2, m.changeReservation(102, new DateTime(2017, 3, 31), new DateTime(2017, 3, 1), 3), "This should return the error code -2 indicating the reservation start date is after the end date.");

        //    //Test Method:      Start date in the past
        //    //Input Parameters: resNumber: 102
        //    //                : startDate: 31-Mar-2016
        //    //                : endDate  : 01-Mar-2016
        //    //Expected Result:  -3
        //    Assert.AreEqual(-3, m.changeReservation(102, new DateTime(2016, 3, 31), new DateTime(2016, 3, 1), 4), "This should return the error code -3 indicating the reservation start date is in the past");

        //    //Test Method:      Reservation doesn't exist
        //    //Input Parameters: resNumber: 100000
        //    //                : startDate: 31-Mar-2017
        //    //                : endDate  : 01-Mar-2017
        //    //Expected Result:  -8
        //    Assert.AreEqual(-8, m.changeReservation(100000, new DateTime(2017, 3, 31), new DateTime(2017, 3, 1), 5), "This should return the error code -8 indicating a reservation number that doesn't exist");

        //    //Test Method:      Reservation has already ended
        //    //Input Parameters: resNumber: 100
        //    //                : startDate: 12-Sep-15
        //    //                : endDate  : 19-Sep-15
        //    //Expected Result:  -7
        //    Assert.AreEqual(-7, m.changeReservation(100, new DateTime(2015, 9, 12), new DateTime(2015, 9, 19), 6), "This should return the error code -7 indicating the reservation is already ended");

        //}

        //[TestMethod]
        //public void ChangeToSharing()
        //{
        //    //------------------------------------------------------------------Tests success

        //    //Test Method:      Succesfully changed to sharing
        //    //Input Parameters: resNumber: 115
        //    //                : petNumber: 3
        //    //                : petNumber: 6
        //    //Expected Result:  7
        //    Assert.AreEqual(7, m.changeToSharing(115, 3, 6, 1), "This should return the success code 7 indicating the two pets have been successfully changed to sharing");

        //    //------------------------------------------------------------------Tests fail
        //    //Test Method:      Pet isn't in the reservation
        //    //Input Parameters: resNumber: 115
        //    //                : petNumber: 6
        //    //                : petNumber: 10 //Add own custom pet
        //    //Expected Result:  -11
        //    Assert.AreEqual(-11, m.changeToSharing(115, 6, 10, 2), "This should return the error code -11 indicating the pet with that pet number does not exist");

        //    //Test Method:      Pet size mismatch
        //    //Input Parameters: resNumber: 106
        //    //                : petNumber: 3
        //    //                : petNumber: 6
        //    //Expected Result:  -10
        //    Assert.AreEqual(-10, m.changeToSharing(106, 3, 6, 3), "This should return the error code -10 indicating the two pets are of different sizes and cannot be put into a same run");


        //    //Test Method:      Reservation has already ended
        //    //Input Parameters: resNumber: 100
        //    //                : petNumber: 2
        //    //                : petNumber: 1
        //    //Expected Result: -7
        //    Assert.AreEqual(-7, m.changeToSharing(100, 2, 1, 4), "This should return the error code -7 indicating the reservation has already ended");


        //    //Test Method:      Reservation number invalid
        //    //Input Parameters: petNumber - 1
        //    //                  petNumber - 2
        //    //                  resNumber - 666
        //    //Expected Result:  -8
        //    Assert.AreEqual(-8, m.changeToSharing(666, 1, 2, 5), "This should return the error code -8 indicating the reservation number is invalid");


        //    //Test Method:      Parameter is same as the first
        //    //Input Parameters: petNumber - 1
        //    //                  petNumber - 1
        //    //                  resNumber - 100
        //    //Expected Result:  -9
        //    Assert.AreEqual(-9, m.changeToSharing(100, 1, 1, 6), "This should return the error code -9 indicating the two pet numbers are the same");


        //    //Test Method:      Pets are already sharing runs
        //    //Input Parameters: resNumber: 106
        //    //                : petNumber: 6
        //    //                : petNumber: 3
        //    //Expected Result:  -12
        //    Assert.AreEqual(-12, m.changeToSharing(106, 6, 3, 7), "This should return the error code -12 indicating the pets are already sharing a run");

        //}

        //[TestMethod]
        //public void ChangeToSolo()
        //{
        //    //------------------------------------------------------------------Tests success

        //    //Test Method:      Successfully changed to solo
        //    //Input Parameters: resNumber: 115
        //    //                : petNumber: 3
        //    //                : petNumber: 6
        //    //Expected Result:  7
        //    Assert.AreEqual(7, m.changeToSolo(115, 3, 6, 1), "This should return the success code 7 indicating the pets are now in solo runs");


        //    //------------------------------------------------------------------Tests fail
        //    //Test Method:      Runs are full
        //    //Input Parameters: resNumber: 115
        //    //                : petNumber: 3
        //    //                : petNumber: 6
        //    //Expected Result:  -4
        //    Assert.AreEqual(-4, m.changeToSolo(115, 3, 6, 2), "This should return the error code -4 indicating all the runs are full");

        //    //Test Method:      Pet isn't in the reservation
        //    //Input Parameters: resNumber: 115
        //    //                : petNumber: 6
        //    //                : petNumber: 10 //Add own custom pet
        //    //Expected Result:  -11
        //    Assert.AreEqual(-11, m.changeToSolo(115, 6, 10, 3), "This should return the error code -11 indicating one of the pets isn't in the reservation");

        //    //Test Method:      Reservation has already ended
        //    //Input Parameters: resNumber: 100
        //    //                : petNumber: 2
        //    //                : petNumber: 1
        //    //Expected Result: -7
        //    Assert.AreEqual(-7, m.changeToSolo(100, 2, 1, 4), "This should return the error code -7 indicating the reservation has already ended");


        //    //Test Method:      Reservation number invalid
        //    //Input Parameters: petNumber - 1
        //    //                  petNumber - 2
        //    //                  resNumber - 666
        //    //Expected Result:  -8
        //    Assert.AreEqual(-8, m.changeToSolo(666, 1, 2, 5), "This should return the error code -8 indicating the reservation number is invalid");

        //    //Test Method:      Parameter is same as the first
        //    //Input Parameters: petNumber - 1
        //    //                  petNumber - 1
        //    //                  resNumber - 100
        //    //Expected Result:  -9
        //    Assert.AreEqual(-9, m.changeToSolo(100, 1, 1, 6), "This should return the error code -9 indicating both pet numbers are identical");

        //    //Test Method:      Pets are already solo
        //    //Input Parameters: resNumber: 703
        //    //                : petNumber: 1
        //    //                : petNumber: 2
        //    //Expected Result:  -13
        //    Assert.AreEqual(-13, m.changeToSolo(703, 1, 2, 7), "This should return the error code -13 indicating both pets are already solo");

        //}
    }
}
