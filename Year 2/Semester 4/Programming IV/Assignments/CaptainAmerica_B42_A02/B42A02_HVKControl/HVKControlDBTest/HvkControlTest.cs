using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using B42A02_HVKControl;
using aha_HVK;
using System.Collections.Generic;

namespace HVKControlDBTest
{
    [TestClass]
    public class HvkControlTest
    {
        HvkControl hc = new HvkControl();
        [TestMethod]
        public void listOwners()
        {
            List<User> owners = hc.listOwners(); 
            //Testing the size
            Assert.AreEqual(19, owners.Count, "Owner size should be 20");

            //Testing the order - Top entry
            Assert.AreEqual("Alibi", owners[0].lastName, "Last name should be Alibi");
            Assert.AreEqual("Anita", owners[0].firstName, "First name should be Anita");
            Assert.AreEqual(20, owners[0].number, "Number should be 20");

            //Testing the middle of the list
            Assert.AreEqual("O'Phone", owners[9].lastName, "Last name should be O'Phone");
            Assert.AreEqual("Mike", owners[9].firstName, "First name should be Mike");
            Assert.AreEqual(2, owners[9].number, "Number should be 2");

            //Testing the bottom of the list
            Assert.AreEqual("Wong", owners[18].lastName, "Last name should be Wong");
            Assert.AreEqual("Dwight", owners[18].firstName, "First name should be Dwight");
            Assert.AreEqual(3, owners[18].number, "Number should be 3");

        }

        [TestMethod]
        public void listPets()
        {
            //Testing 1 pet
            List<Pet> pets = new List<Pet>();
            pets = hc.listPets(new User(), 4);
            Assert.AreEqual(1, pets.Count, "Pet size should be 1");
            Assert.AreEqual(7, pets[0].number, "Number should be 7");

            //Testing 2 pets
            pets = hc.listPets(new User(), 1);
            Assert.AreEqual(2, pets.Count, "Pet size should be 2");
            Assert.AreEqual(1, pets[0].number, "Number should be 1");
            Assert.AreEqual(2, pets[1].number, "Number should be 2");

            //Testing 3 pets
            pets = hc.listPets(new User(), 7);
            Assert.AreEqual(3, pets.Count, "Pet size should be 3");
            Assert.AreEqual(10, pets[0].number, "Number should be 10");
            Assert.AreEqual(11, pets[1].number, "Number should be 11");
            Assert.AreEqual(12, pets[2].number, "Number should be 12");
        }

        [TestMethod]
        public void listReservationsTest()
        {
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
            Assert.AreEqual(new DateTime(2017, 4, 30), reservations[0].endDate, "End Date should be 2017-4-30");

            Assert.AreEqual(900, reservations[1].number, "Number should be 900");
            Assert.AreEqual(31, reservations[1].petReservation[0].pet.number, "Number should be 31");
            Assert.AreEqual("Sam", reservations[1].petReservation[0].pet.name, "Name should be Sam");
            Assert.AreEqual(32, reservations[1].petReservation[1].pet.number, "Number should be 32");
            Assert.AreEqual("Snoop Dogg", reservations[1].petReservation[1].pet.name, "Name should be Snoop Dogg");
            Assert.AreEqual(new DateTime(2017, 6, 20), reservations[1].startDate, "Start Date should be 2017-6-20");
            Assert.AreEqual(new DateTime(2017, 6, 26), reservations[1].endDate, "End Date should be 2017-6-26");
        }
        public void listActiveReservations()
        {
            List<Reservation> activeReservations = new List<Reservation>();


            //Testing for all active reservations using September 17 as a reference date
            activeReservations = hc.listActiveReservations();
            Assert.AreEqual(100, activeReservations[0].number, "Number should be 100");

        }

    }
}
