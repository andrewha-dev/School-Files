using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aha_HVKTestCase
{
    using aha_HVK;
    public class aha_HVKTestCase
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(500, 1000);
            Console.WriteLine("\n");
            Console.WriteLine("The Following Are Test Cases For The aha_HVK library:");
            //Testing the medication object
            Console.WriteLine("\n------------------Test Medication----------------\n");
            testMedication();
            //Testing the kennel log object
            Console.WriteLine("\n------------------Test Kennel Log----------------\n");
            testKennelLog();
            //Testing the daily rate object
            Console.WriteLine("\n------------------Test DailyRate----------------\n");
            testDailyRate();
            //Testing the service object
            Console.WriteLine("\n------------------Test Service----------------\n");
            testService();
            //Method for testing Veterinarian
            Console.WriteLine("\n------------------Test Vet---------------\n");
            testVeterinarian();
            //Testing the vaccination object
            Console.WriteLine("\n------------------Test Vaccination----------------\n");
            testVaccination();
            //Testing food object
            Console.WriteLine("\n------------------Test Food----------------\n");
            testFood();
            //Testing the discount object
            Console.WriteLine("\n------------------Test Discount----------------\n");
            testDiscount();
            //Testing the run object
            Console.WriteLine("\n------------------Test Run----------------\n");
            testRun();
            //Testing the pet object
            Console.WriteLine("\n------------------Test Pet----------------\n");
            testPet();
            //Testing the owner object
            Console.WriteLine("\n------------------Test Owner----------------\n");
            testOwner();
            //Testing the pet reservation object
            Console.WriteLine("\n------------------Test Pet Reservation----------------\n");
            testPetReservation();
            Console.WriteLine("\n------------------Test Reservation----------------------\n");
            testReservation();
           
            Console.ReadLine();


        }

        //Testing the medication object
        public static void testMedication()
        {
            //Testing the medication contructor default values
            Medication medication = new Medication();
            Console.WriteLine("\nTesting the medication object:\n");
            Console.WriteLine("\nTesting the default medication object:");
            if (medication.number == -1)//Expected -1 from the constructor
                Console.WriteLine("Testing the default value of medication number:  " + medication.number);
            else
                Console.WriteLine("Expected -1: Got" + medication.number);
            if (medication.name == "No medication name was selected")//Expected from default constructor
                Console.WriteLine("Testing the default value of medication name:  " + medication.name);
            else
                Console.WriteLine("Expected 'No medication name was selected': Got " + medication.name);
            if (medication.dosage == "No dosage was selected")//Expected from default constructor
                Console.WriteLine("Testing the default value of medication dosage:  " + medication.dosage);
            else
                Console.WriteLine("Expected: 'No dosage was selected': got " + medication.dosage);
            if (medication.instructions == "No medication instructions were given") 
            Console.WriteLine("Testing the default value of medication special instructions: " + medication.instructions);
            else 
                Console.WriteLine("Expected 'No medication instructions were given': Got " +  medication.instructions);
            if (medication.endDate == new DateTime(1000, 1, 1))
                Console.WriteLine("Testing the default value of medication end date: " + medication.endDate);
            else
                Console.WriteLine("End date expected was 1000, 1, 1 : Received " + medication.endDate);

            //Testing the medication constructor usig the required constructions
            Medication medication1 = new Medication(123, "This dog vaccine");
            

            if (medication1.number == 123)
                Console.WriteLine("Testing the default value of medication number:  " + medication1.number);
            else
                Console.WriteLine("Expected 123: Got" + medication.number);
            if (medication1.name == "This dog vaccine")
                Console.WriteLine("Testing the default value of medication name:  " + medication1.name);
            else
                Console.WriteLine("Expected 'This dog vaccine': Got " + medication1.name);
            if (medication1.dosage == "No dosage was selected")
                Console.WriteLine("Testing the default value of medication dosage:  " + medication1.dosage);
            else
                Console.WriteLine("Expected: 'No dosage was selected': got " + medication1.dosage);
            if (medication1.instructions == "No medication instructions were given")
                Console.WriteLine("Testing the default value of medication special instructions: " + medication1.instructions);
            else
                Console.WriteLine("Expected 'No medication instructions were given': Got " + medication1.instructions);
            if (medication1.endDate == new DateTime(1000, 1, 1))
                Console.WriteLine("Testing the default value of medication end date: " + medication1.endDate);
            else
                Console.WriteLine("End date expected was 1000, 1, 1 : Received " + medication1.endDate);

            //Testing the medication constructor using the all the fields
            Medication medication2 = new Medication(123, "This dog vaccine", "100mg", "All of it", new DateTime(1997, 10, 31));
            Console.WriteLine("\nTesting all values: Which are 123 and 'This dog vaccine', 100mg, All Of It, 1997-31-10");

            if (medication2.number == 123)
                Console.WriteLine("Testing the default value of medication number:  " + medication2.number);
            else
                Console.WriteLine("Expected 123: Got" + medication2.number);
            if (medication2.name == "This dog vaccine")
                Console.WriteLine("Testing the default value of medication name:  " + medication2.name);
            else
                Console.WriteLine("Expected 'This dog vaccine': Got " + medication2.name);
            if (medication2.dosage == "100mg")
                Console.WriteLine("Testing the default value of medication dosage:  " + medication2.dosage);
            else
                Console.WriteLine("Expected: '100mg': got " + medication2.dosage);
            if (medication2.instructions == "All of it")
                Console.WriteLine("Testing the default value of medication special instructions: " + medication2.instructions);
            else
                Console.WriteLine("Expected 'All of it': Got " + medication2.instructions);
            if (medication2.endDate == new DateTime(1997, 10, 31))
                Console.WriteLine("Testing the default value of medication end date: " + medication2.endDate);
            else
                Console.WriteLine("End date expected was 1997, 10, 31 : Received " + medication2.endDate);


            //Testing the setters of the medication object
            Console.WriteLine("\nTesting the medication object setters:");
            Console.WriteLine("Setting medication number to 100");
            medication.number = 100;
            
            Console.WriteLine("Setting medication medication name to Rabies Medication");
            medication.name = "Rabies Medication";

            Console.WriteLine("Setting medication dosage to 50mg");
            medication.dosage = "50mg";

            Console.WriteLine("Setting medication instruction to: Please apply generously and calmly");
            medication.instructions = "Please apply generously and calmly";
           
            Console.WriteLine("Setting medication end date to: 2012-12-21");
            medication.endDate = new DateTime(2012, 12, 21);
            
            //Setters
            if (medication.number == 100)
                Console.WriteLine("Testing the default value of medication number:  " + medication.number);
            else
                Console.WriteLine("Expected 100: Got" + medication.number);
            if (medication.name == "Rabies Medication")
                Console.WriteLine("Testing the default value of medication name:  " + medication.name);
            else
                Console.WriteLine("Expected 'Rabies Medication': Got " + medication.name);
            if (medication.dosage == "50mg")
                Console.WriteLine("Testing the default value of medication dosage:  " + medication.dosage);
            else
                Console.WriteLine("Expected: '50mg': got " + medication.dosage);
            if (medication.instructions == "Please apply generously and calmly")
                Console.WriteLine("Testing the default value of medication special instructions: " + medication.instructions);
            else
                Console.WriteLine("Expected 'Please apply generously and calmly': Got " + medication.instructions);
            if (medication.endDate == new DateTime(2012, 12, 21))
                Console.WriteLine("Testing the default value of medication end date: " + medication.endDate);
            else
                Console.WriteLine("End date expected was 2012, 12, 21 : Received " + medication.endDate);


        }

        public static void testKennelLog()
        {
            //Testing the default constructors of the kennel log
            KennelLog kennelLog = new KennelLog();
            Console.WriteLine("\nTesting the kennel log object:\n");
            Console.WriteLine("\nTesting the default kennel log object:");
            if (kennelLog.date == new DateTime(1000, 1, 1))
                Console.WriteLine("Testing the default value of kennel date:  " + kennelLog.date);
            else
                Console.WriteLine("Expected 1000-1-1: Got " + kennelLog.date);
            if (kennelLog.number == -1)
                Console.WriteLine("Testing the default value of kennel number:  " + kennelLog.number);
            else
                Console.WriteLine("Expected -1 got: " + kennelLog.number);
            if (kennelLog.notes == "No notes were entered")
                Console.WriteLine("Testing the default value of kennel notes:  " + kennelLog.notes);
            else
                Console.WriteLine("Expected No notes were entered : got " + kennelLog.notes);
            if (kennelLog.video == 0)
                Console.WriteLine("Testing the default value of kennel video: " + kennelLog.video);
            else
                Console.WriteLine("Expected 0 got " + kennelLog.video);

            //Testing all the required values of the kennel log
            Console.WriteLine("\nTesting the required values of kennel log object: 2016-12-12, 150, Here are some notes");
            KennelLog kennelLog1 = new KennelLog(new DateTime(2016, 12, 12), 150, "Here are some notes");
            
           
            if (kennelLog1.date == new DateTime(2016, 12, 12))
                Console.WriteLine("Testing the default value of kennel date:  " + kennelLog1.date);
            else
                Console.WriteLine("Expected 2016-12-12: Got " + kennelLog1.date);
            if (kennelLog1.number == 150)
                Console.WriteLine("Testing the default value of kennel number:  " + kennelLog1.number);
            else
                Console.WriteLine("Expected 150 got: " + kennelLog1.number);
            if (kennelLog1.notes == "Here are some notes")
                Console.WriteLine("Testing the default value of kennel notes:  " + kennelLog1.notes);
            else
                Console.WriteLine("Expected Here are some notes : got " + kennelLog1.notes);
            if (kennelLog1.video == 0)
                Console.WriteLine("Testing the default value of kennel video: " + kennelLog1.video);
            else
                Console.WriteLine("Expected 0 got " + kennelLog1.video);

            //Testing all the values of the kennel object
            Console.WriteLine("\nTesting the all values of kennel log object: 2016-12-12, 150, Here are some notes");
            KennelLog kennelLog2 = new KennelLog(new DateTime(2016, 12, 12), 150, "Here are some notes", 99);

            Console.WriteLine("Testing the required value of kennel date:  " + kennelLog2.date);
            Console.WriteLine("Testing the required value of kennel number:  " + kennelLog2.number);
            Console.WriteLine("Testing the requried value of kennel notes:  " + kennelLog2.notes);
            Console.WriteLine("Testing the required value of kennel video: " + kennelLog2.video);

            if (kennelLog2.date == new DateTime(2016, 12, 12))
                Console.WriteLine("Testing the default value of kennel date:  " + kennelLog2.date);
            else
                Console.WriteLine("Expected 2016-12-12: Got " + kennelLog2.date);
            if (kennelLog2.number == 150)
                Console.WriteLine("Testing the default value of kennel number:  " + kennelLog2.number);
            else
                Console.WriteLine("Expected 150 got: " + kennelLog2.number);
            if (kennelLog2.notes == "Here are some notes")
                Console.WriteLine("Testing the default value of kennel notes:  " + kennelLog2.notes);
            else
                Console.WriteLine("Expected Here are some notes : got " + kennelLog2.notes);
            if (kennelLog2.video == 99)
                Console.WriteLine("Testing the default value of kennel video: " + kennelLog2.video);
            else
                Console.WriteLine("Expected 99 got " + kennelLog2.video);

            //Testing the setters of the kennel object
            Console.WriteLine("\nTesting the required setters of the default kennel object:");
            Console.WriteLine("Setting the kennel date to 1999-12-12");
            kennelLog.date = new DateTime(1999, 12, 12);

            Console.WriteLine("Setting the kennel number to 999");
            kennelLog.number = 999;

            Console.WriteLine("Setting the kennel note to Setting the kennel notes :D");
            kennelLog.notes = "Setting the kennel notes :D";

            Console.WriteLine("Setting the kennel video to 123");
            kennelLog.video = 123;

            //Testing setters
            if (kennelLog.date == new DateTime(1999, 12, 12))
                Console.WriteLine("Testing the default value of kennel date:  " + kennelLog.date);
            else
                Console.WriteLine("Expected 1999-12-12: Got " + kennelLog.date);
            if (kennelLog.number == 999)
                Console.WriteLine("Testing the default value of kennel number:  " + kennelLog.number);
            else
                Console.WriteLine("ken log num: Expected 123 got: " + kennelLog.number);
            if (kennelLog.notes == "Setting the kennel notes :D")
                Console.WriteLine("Testing the default value of kennel notes:  " + kennelLog.notes);
            else
                Console.WriteLine("Expected Setting the kennel notes :D : got " + kennelLog.notes);
            if (kennelLog.video == 123)
                Console.WriteLine("Testing the default value of kennel video: " + kennelLog.video);
            else
                Console.WriteLine("Expected 123 got " + kennelLog.video);



        }
        //Method for testing the daily rate object
        public static void testDailyRate()
        {
            //Testing the daily rate object
            DailyRate dr = new DailyRate();
            Console.WriteLine("\nTesting the daily rate object:\n");
            Console.WriteLine("Testing the daily rate object with its default constructor: ");
            if (dr.number == -1)
                Console.WriteLine("Testing the default value of number:  " + dr.number);
            else
                Console.WriteLine("Number expected -1: Got " + dr.number);
            if (dr.rate == -1)
                Console.WriteLine("Testing the default value of rate:  " + dr.rate);
            else
                Console.WriteLine("Rate expected -1: Got " + dr.rate);
            if (dr.size == 'U')
                Console.WriteLine("Testing the default value of size:  " + dr.size);
            else
                Console.WriteLine("Size expected was U: Got " + dr.size);

            //Testing the required values of the daily rate object
            Console.WriteLine("\nTesting the required values of daily rate: 123, 0.8");
            DailyRate dr1 = new DailyRate(123, 0.8);

            if (dr1.number == 123)
                Console.WriteLine("Testing the default value of number:  " + dr1.number);
            else
                Console.WriteLine("Number expected 123: Got " + dr1.number);
            if (dr1.rate == 0.8)
                Console.WriteLine("Testing the default value of rate:  " + dr1.rate);
            else
                Console.WriteLine("Rate expected 0.8: Got " + dr1.rate);
            if (dr1.size == 'U')
                Console.WriteLine("Testing the default value of size:  " + dr1.size);
            else
                Console.WriteLine("Size expected was U: Got " + dr1.size);

            //Testing all values of the daily rate object 
            Console.WriteLine("\nTesting the all values of daily rate: 221, 4.20, G");
            DailyRate dr2 = new DailyRate(221, 4.20, 'G');
            if (dr2.number == 221)
                Console.WriteLine("Testing the default value of number:  " + dr2.number);
            else
                Console.WriteLine("Number expected 221: Got " + dr2.number);
            if (dr2.rate == 4.20)
                Console.WriteLine("Testing the default value of rate:  " + dr2.rate);
            else
                Console.WriteLine("Rate expected 0.8: Got " + dr2.rate);
            if (dr2.size == 'G')
                Console.WriteLine("Testing the default value of size:  " + dr2.size);
            else
                Console.WriteLine("Size expected was U: Got " + dr2.size);

            //Testing the setters of the DailyRate object using a constructor
            Console.WriteLine("\nTesting the setters of the default kennel object:");
            Console.WriteLine("Setting the daily rate number to 999");
            dr.number = 999;
            Console.WriteLine("Setting the daily rate to 0.999");
            dr.rate = 0.999;
            Console.WriteLine("Setting the size to S");
            dr.size = 'S';

            if (dr.number == 999)
                Console.WriteLine("Testing the value of number:  " + dr.number);
            else
                Console.WriteLine("Number expected 999: Got " + dr.number);
            if (dr.rate == 0.999)
                Console.WriteLine("Testing the default value of rate:  " + dr.rate);
            else
                Console.WriteLine("Rate expected 0.999: Got " + dr.rate);
            if (dr.size == 'S')
                Console.WriteLine("Testing the value of size:  " + dr.size);
            else
                Console.WriteLine("Size expected was S: Got " + dr.size);

        }
        
        //Method for testing services
        public static void testService()
        {
            Service s = new Service();
            Console.WriteLine("\nTesting the service object:\n");
            Console.WriteLine("Testing the service object with its default constructor: ");
            if (s.number == -1)
                Console.WriteLine("Testing the default value of number:  " + s.number);
            else
                Console.WriteLine("Expected -1 got " + s.number);
            if (s.frequency == -1)
                Console.WriteLine("Testing the default value of frequency:  " + s.frequency);
            else
                Console.WriteLine("Expected -1 got : " + s.frequency);
            if (s.description == "No description available")
                Console.WriteLine("Testing the default value of description:  " + s.description);
            else
                Console.WriteLine("Expected No description available got : " + s.description);
            if (s.dailyRate == new DailyRate())
            Console.WriteLine("Testing the required size/value of dailyRate :  " + s.dailyRate.number + " " + s.dailyRate.rate + " " + s.dailyRate.size);


            DailyRate dr = new DailyRate();
            Service s1 = new Service(123, "Here is a description", dr);
            //Testing the required values of the service object
            Console.WriteLine("Testing deafault values");
            if (s1.number == 123)
                Console.WriteLine("Testing the default value of number:  " + s1.number);
            else
                Console.WriteLine("Expected 123 got " + s1.number);
            if (s1.frequency == -1)
                Console.WriteLine("Testing the default value of frequency:  " + s1.frequency);
            else
                Console.WriteLine("Expected -1 got : " + s1.frequency);
            if (s1.description == "Here is a description")
                Console.WriteLine("Testing the default value of description:  " + s1.description);
            else
                Console.WriteLine("Expected Another desc got : " + s1.description);
            if (s1.dailyRate == dr)
                Console.WriteLine("Testing the required size/value of dailyRate :  " + s1.dailyRate.number + " " + s1.dailyRate.rate + " " + s1.dailyRate.size);

            //Testing all the values of the service object
            Service s2 = new Service(123, "Another desc", dr, 5);
            Console.WriteLine("\nTesting all values of the service object: 123, Here is a description and a list with a default daily rate and 5\n");
            Console.WriteLine("Testing the required value of number:  " + s2.number);
            Console.WriteLine("Testing the default value of frequency:  " + s2.frequency);
            Console.WriteLine("Testing the required value of description:  " + s2.description);
            Console.WriteLine("Testing the required size/value of dailyRate list:  " + s2.dailyRate.number + " " + s2.dailyRate.rate + " " + s2.dailyRate.size);

            if (s2.number == 123)
                Console.WriteLine("Testing the default value of number:  " + s2.number);
            else
                Console.WriteLine("Expected 123 got " + s2.number);
            if (s2.frequency == 5)
                Console.WriteLine("Testing the default value of frequency:  " + s2.frequency);
            else
                Console.WriteLine("Expected 5 got : " + s2.frequency);
            if (s2.description == "Another desc")
                Console.WriteLine("Testing the default value of description:  " + s2.description);
            else
                Console.WriteLine("Expected Another desc got : " + s2.description);
            if (s2.dailyRate == dr)
                Console.WriteLine("Testing the required size/value of dailyRate :  " + s2.dailyRate.number + " " + s1.dailyRate.rate + " " + s1.dailyRate.size);


            //Testing all the setters of the service object
            Console.WriteLine("\nTesting setters of the default service object: \n");
            Console.WriteLine("Setting the number to 100:  ");
            s.number = 100;

            Console.WriteLine("Setting the  to 100:  ");
            Console.WriteLine("Setting the frequency to 9:  ");
            s.frequency = 9;

            Console.WriteLine("Setting the description to THIS IS A DESCRIPTION!!!:  ");
            s.description = "THIS IS A DESCRIPTION!!!";

            Console.WriteLine("Setting the constructor object with a new one with 999 0.999 Z:  ");
            s.dailyRate = dr;
            

            if (s.number == 100)
                Console.WriteLine("Testing the default value of number:  " + s.number);
            else
                Console.WriteLine("Expected 100 got " + s.number);
            if (s.frequency == 9)
                Console.WriteLine("Testing the default value of frequency:  " + s.frequency);
            else
                Console.WriteLine("Expected 9 got : " + s.frequency);
            if (s.description == "THIS IS A DESCRIPTION!!!")
                Console.WriteLine("Testing the default value of description:  " + s.description);
            else
                Console.WriteLine("Expected THIS IS A DESCRIPTION!!! : " + s.description);
            if (s.dailyRate == dr)
                Console.WriteLine("Testing the required size/value of dailyRate :  " + s.dailyRate.number + " " + s1.dailyRate.rate + " " + s1.dailyRate.size);
        }
        //Testing the Veterinarian of each object
        public static void testVeterinarian()
        {
            Veterinarian v = new Veterinarian();
            Console.WriteLine("\nTesting the vet object:\n");
            Console.WriteLine("Testing the vet object with its default constructor: ");
            if (v.number == -1)
                Console.WriteLine("Testing the default value of number:  " + v.number);
            else
                Console.WriteLine("Expected -1: Got " + v.number);
            if (v.name == "No name was entered")
                Console.WriteLine("Testing the default value of name:  " + v.name);
            else
                Console.WriteLine("Expected name was entered");
            if (v.phone == "No phone number was entered")
                Console.WriteLine("Testing the default value of phone:  " + v.phone);
            else
                Console.WriteLine("Expected No phone was entered");
            if (v.street == "No street was entered")
                Console.WriteLine("Testing the default value of street :  " + v.street);
            else
                Console.WriteLine("Expected No street was entered : got " + v.street);
            if (v.city == "No city was entered")
                Console.WriteLine("Testing the default value of city :  " + v.city);
            else
                Console.WriteLine("No city entered was expected got : " + v.city);
            if (v.province == "No province was entered")
                Console.WriteLine("Testing the default value of province :  " + v.province);
            else
                Console.WriteLine("No province was entered was expeceted : " + v.province);
            if (v.postalCode == "No postal code was entered")
                Console.WriteLine("Testing the default value of postal code :  " + v.postalCode);
            else
                Console.WriteLine("No postal was entered was expected : " + v.postalCode);

            //Testing the required values of constructor
            Veterinarian v1 = new Veterinarian(111, "NAME", "123-123-1234");
            Console.WriteLine("\nTesting the vet object with its required values: 111 - NAME - 123-123-1234");
            Console.WriteLine("Testing the value of number:  " + v1.number);
            Console.WriteLine("Testing the value of name:  " + v1.name);
            Console.WriteLine("Testing the value of phone:  " + v1.phone);
            Console.WriteLine("Testing the value of street :  " + v1.street);
            Console.WriteLine("Testing the value of city :  " + v1.city);
            Console.WriteLine("Testing the value of province :  " + v1.province);
            Console.WriteLine("Testing the value of postal code :  " + v1.postalCode);

            if (v1.number == 111)
                Console.WriteLine("Testing the default value of number:  " + v1.number);
            else
                Console.WriteLine("Expected 111: Got " + v1.number);
            if (v1.name == "NAME")
                Console.WriteLine("Testing the default value of name:  " + v1.name);
            else
                Console.WriteLine("Expected NAME : " + v1.name);
            if (v1.phone == "123-123-1234")
                Console.WriteLine("Testing the default value of phone:  " + v1.phone);
            else
                Console.WriteLine("Expected 123-123-1234 : " + v1.phone);
            if (v1.street == "No street was entered")
                Console.WriteLine("Testing the default value of street :  " + v1.street);
            else
                Console.WriteLine("Expected No street was entered : got " + v1.street);
            if (v1.city == "No city was entered")
                Console.WriteLine("Testing the default value of city :  " + v1.city);
            else
                Console.WriteLine("No city entered was expected got : " + v1.city);
            if (v1.province == "No province was entered")
                Console.WriteLine("Testing the default value of province :  " + v1.province);
            else
                Console.WriteLine("No province was entered was expeceted : " + v1.province);
            if (v1.postalCode == "No postal code was entered")
                Console.WriteLine("Testing the default value of postal code :  " + v1.postalCode);
            else
                Console.WriteLine("No postal was entered was expected : " + v1.postalCode);

            //Testing all the values of the constructor
            Veterinarian v2 = new Veterinarian(111, "NAME", "123-123-1234","Street here", "Gatineau", "Quebec", "a1a1a1");
            Console.WriteLine("\nTesting the vet object with its required values: 111 - NAME - 123-123-1234, Street Here, Gatineau, Quebec, a1a1a1");
            Console.WriteLine("Testing the value of number:  " + v2.number);
            Console.WriteLine("Testing the value of name:  " + v2.name);
            Console.WriteLine("Testing the value of phone:  " + v2.phone);
            Console.WriteLine("Testing the value of street :  " + v2.street);
            Console.WriteLine("Testing the value of city :  " + v2.city);
            Console.WriteLine("Testing the value of province :  " + v2.province);
            Console.WriteLine("Testing the value of postal code :  " + v2.postalCode);


            if (v2.number == 111)
                Console.WriteLine("Testing the default value of number:  " + v2.number);
            else
                Console.WriteLine("Expected 111: Got " + v2.number);
            if (v2.name == "NAME")
                Console.WriteLine("Testing the default value of name:  " + v2.name);
            else
                Console.WriteLine("Expected NAME : " + v2.name);
            if (v2.phone == "123-123-1234")
                Console.WriteLine("Testing the default value of phone:  " + v2.phone);
            else
                Console.WriteLine("Expected 123-123-1234 : " + v2.phone);
            if (v2.street == "Street here")
                Console.WriteLine("Testing the default value of street :  " + v2.street);
            else
                Console.WriteLine("Expected Street here : got " + v2.street);
            if (v2.city == "Gatineau")
                Console.WriteLine("Testing the default value of city :  " + v2.city);
            else
                Console.WriteLine("Expected Gatineau got : " + v2.city);
            if (v2.province == "Quebec")
                Console.WriteLine("Testing the default value of province :  " + v2.province);
            else
                Console.WriteLine("Quebec expeceted : " + v2.province);
            if (v2.postalCode == "a1a1a1")
                Console.WriteLine("Testing the default value of postal code :  " + v2.postalCode);
            else
                Console.WriteLine("a1a1a1 was expected : " + v2.postalCode);


            //Testing the setters of the veterinarian objects
            Console.WriteLine("\nTesting setters of the vet object using its default as a base");
            Console.WriteLine("Setting the value of number to 123:  ");
            v.number = 123;
            
            Console.WriteLine("Setting the value name to Mr Vet:  ");
            v.name = "Mr Vet";
            
            Console.WriteLine("Setting the value of phone to 111-111-1111:  ");
            v.phone = "111-111-1111";
            
            Console.WriteLine("Setting the value of street to Downtown St:  ");
            v.street = "Downtown St";
            
            Console.WriteLine("Setting the value of city to Ottawa:  ");
            v.city = "Ottawa";
            
            Console.WriteLine("Setting the value of province to Quebec:  ");
            v.province = "Quebec";
            
            Console.WriteLine("Setting the value postal code to Z9Z9Z9:  ");
            v.postalCode = "Z9Z9Z9";
            

            if (v.number == 123)
                Console.WriteLine("Testing the default value of number:  " + v.number);
            else
                Console.WriteLine("Expected 123: Got " + v.number);
            if (v.name == "Mr Vet")
                Console.WriteLine("Testing the default value of name:  " + v.name);
            else
                Console.WriteLine("Mr Vet : " + v.name);
            if (v.phone == "111-111-1111")
                Console.WriteLine("Testing the default value of phone:  " + v.phone);
            else
                Console.WriteLine("Expected 111-111-1111 : " + v.phone);
            if (v.street == "Downtown St")
                Console.WriteLine("Testing the default value of street :  " + v.street);
            else
                Console.WriteLine("Expected Downtown St : got " + v.street);
            if (v.city == "Ottawa")
                Console.WriteLine("Testing the default value of city :  " + v.city);
            else
                Console.WriteLine("Expected Ottawa got : " + v.city);
            if (v.province == "Quebec")
                Console.WriteLine("Testing the default value of province :  " + v.province);
            else
                Console.WriteLine("Quebec expeceted : " + v.province);
            if (v.postalCode == "Z9Z9Z9")
                Console.WriteLine("Testing the default value of postal code :  " + v.postalCode);
            else
                Console.WriteLine("Z9Z9Z9 was expected : " + v.postalCode);
        }

        //Testing the vaccination object
        public static void testVaccination()
        {
            //Creating a vaccination object with its default values
            Vaccination v = new Vaccination();
            Console.WriteLine("\nTesting the vaccination object:\n");
            Console.WriteLine("Testing the vet object with its default constructor: ");
            if (v.number == -1)
                Console.WriteLine("Testing the default value of number:  " + v.number);
            else
                Console.WriteLine("Expected -1 : Got " + v.number);
            if (v.name == "No vaccination name was entered")
                Console.WriteLine("Testing the default value of name:  " + v.name);
            else
                Console.WriteLine("Expected No vaccination name was entered : Got " +  v.name);

            if (v.expiryDate == new DateTime(1000, 1, 1))
                Console.WriteLine("Testing the default value of expiry date:  " + v.expiryDate);
            else
                Console.WriteLine("Expected value is 1000-1-1 : Got " + v.expiryDate);

            //Testing required values which in this case is all of the values of the vaccination constructor
            Console.WriteLine("\nTesting the required (in this case is all) values of the vaccination object: 2016-1-29, 1234, Ebola Saver");
            Vaccination v1 = new Vaccination(new DateTime(2016, 1, 29), 1234, "Ebola Saver");
            Console.WriteLine("Testing the default value of number:  " + v1.number);
            Console.WriteLine("Testing the default value of name:  " + v1.name);
            Console.WriteLine("Testing the default value of expiry date:  " + v1.expiryDate);

            if (v1.number == 1234)
                Console.WriteLine("Testing the default value of number:  " + v1.number);
            else
                Console.WriteLine("Expected 1234 : Got " + v1.number);
            if (v1.name == "Ebola Saver")
                Console.WriteLine("Testing the default value of name:  " + v1.name);
            else
                Console.WriteLine("Expected Ebola Saver : Got " + v1.name);

            if (v1.expiryDate == new DateTime(2016, 1, 29))
                Console.WriteLine("Testing the default value of expiry date:  " + v1.expiryDate);
            else
                Console.WriteLine("Expected value is 2016-1-29 : Got " + v1.expiryDate);

            //Testing the setters of the vaccine object using the defaults as a base
            Console.WriteLine("\nTesting setters of the vaccine object.");
            Console.WriteLine("Setting the number to:  5");
            v.number = 5;
            
            Console.WriteLine("Setting the name to:  This name is being set using the setter");
            v.name = "This name is being set using the setter";
            
            Console.WriteLine("Setting the expiry date to:  1999-12-31");
            v.expiryDate = new DateTime(1999, 12, 31);
            

            if (v.number == 5)
                Console.WriteLine("Testing the default value of number:  " + v.number);
            else
                Console.WriteLine("Expected 5: Got " + v.number);
            if (v.name == "This name is being set using the setter")
                Console.WriteLine("Testing the default value of name:  " + v.name);
            else
                Console.WriteLine("Expected This name is being set using the setter : Got " + v.name);

            if (v.expiryDate == new DateTime(1999, 12, 31))
                Console.WriteLine("Testing the default value of expiry date:  " + v.expiryDate);
            else
                Console.WriteLine("Expected value is 1999-12-31 : Got " + v.expiryDate);
        }
            
        //Testing the food object
        public static void testFood()
        {
            Food f = new Food();
            Console.WriteLine("\nTesting the food object:\n");
            //Testing default constructors
            Console.WriteLine("Testing the food object with its default constructor: ");
            if (f.number == -1)
                Console.WriteLine("Testing the default value of number:  " + f.number);
            else
                Console.WriteLine("Expected value was -1: Got " + f.number);
            if (f.brand == "No brand was listed")
                Console.WriteLine("Testing the default value of brand:  " + f.brand);
            else
                Console.WriteLine("Expected No brand was listed : Got " + f.brand);
            if (f.frequency == -1)
                Console.WriteLine("Testing the default value of variety:  " + f.frequency);
            else
                Console.WriteLine("Expected -1 : Got " + f.frequency);
            if (f.variety == "No variety entered")
                Console.WriteLine("Testing the default value of frequency:  " + f.frequency);
            else
                Console.WriteLine("Expected No variety entered : Got" + f.frequency);
            if (f.quantity == "No quantity was entered")
                Console.WriteLine("Testing the default value of quantity:  " + f.quantity);
            else
                Console.WriteLine("Expected No quantity was entered : Got " + f.quantity);

            Console.WriteLine("\nTesting the food object with its required values: 666 Iams 8");
            Food f1 = new Food(666, "Iams", 8);
           
            //Testing required attributes
            if (f1.number == 666)
                Console.WriteLine("Testing the default value of number:  " + f1.number);
            else
                Console.WriteLine("Expected value was 666: Got " + f1.number);
            if (f1.brand == "Iams")
                Console.WriteLine("Testing the default value of brand:  " + f1.brand);
            else
                Console.WriteLine("Expected Iams : Got " + f1.brand);
            if (f1.frequency == 5)
                Console.WriteLine("Testing the default value of variety:  " + f1.frequency);
            else
                Console.WriteLine("Expected 5 : Got " + f1.frequency);
            if (f1.variety == "No variety entered")
                Console.WriteLine("Testing the default value of frequency:  " + f1.frequency);
            else
                Console.WriteLine("Expected No variety entered : Got" + f1.frequency);
            if (f1.quantity == "No quantity was entered")
                Console.WriteLine("Testing the default value of quantity:  " + f1.quantity);
            else
                Console.WriteLine("Expected No quantity was entered : Got " + f1.quantity);

            Console.WriteLine("\nTesting the food object with its all values: 666 Iams Flavored 8 10 cups");
            Food f2 = new Food(666, "Iams", 8, "Flavored", "10 cups");

            //Testing all values

            if (f2.number == 666)
                Console.WriteLine("Testing the default value of number:  " + f2.number);
            else
                Console.WriteLine("Expected value was 666: Got " + f2.number);
            if (f2.brand == "Iams")
                Console.WriteLine("Testing the default value of brand:  " + f2.brand);
            else
                Console.WriteLine("Expected Iams : Got " + f2.brand);
            if (f2.frequency == 8)
                Console.WriteLine("Testing the default value of variety:  " + f2.variety);
            else
                Console.WriteLine("Expected 8 : Got " + f2.frequency);
            if (f2.variety == "Flavored")
                Console.WriteLine("Testing the default value of frequency:  " + f2.frequency);
            else
                Console.WriteLine("Expected Flavored : Got" + f2.frequency);
            if (f2.quantity == "10 cups")
                Console.WriteLine("Testing the default value of quantity:  " + f2.quantity);
            else
                Console.WriteLine("Expected 10 cups : Got " + f2.quantity);

            Console.WriteLine("\nTesting the setters of the food object using its default values as a base");
            Console.WriteLine("Setting the value of number to 123: ");
            f.number = 123;
            Console.WriteLine("Setting the value of brand to Iams: ");
            f.brand = "Iams";
            Console.WriteLine("Setting the value of variety to TheLegend27: ");
            f.variety = "TheLegend27";
            Console.WriteLine("Setting the value of frequency to 20: ");
            f.frequency = 20;
            Console.WriteLine("Setting the value of quantity to 123 BIG CUPS: ");
            f.quantity = "123 BIG CUPS";

            if (f.number == 123)
                Console.WriteLine("Testing the default value of number:  " + f.number);
            else
                Console.WriteLine("Expected value was 123: Got " + f.number);
            if (f.brand == "Iams")
                Console.WriteLine("Testing the default value of brand:  " + f.brand);
            else
                Console.WriteLine("Expected Iams : Got " + f.brand);
            if (f.frequency == 20)
                Console.WriteLine("Testing the default value of variety:  " + f.frequency);
            else
                Console.WriteLine("Expected 20 : Got " + f.frequency);
            if (f.variety == "TheLegend27")
                Console.WriteLine("Testing the default value of frequency:  " + f.frequency);
            else
                Console.WriteLine("Expected TheLegend27 : Got" + f.frequency);
            if (f.quantity == "123 BIG CUPS")
                Console.WriteLine("Testing the default value of quantity:  " + f.quantity);
            else
                Console.WriteLine("Expected 123 BIG CUPS : Got " + f.quantity);
        }

        //Method for testing the discount object
        public static void testDiscount()
        {
            Discount d = new Discount();
            Console.WriteLine("\nTesting the discount object:\n");
            Console.WriteLine("Testing the discount object with its default constructor: ");
            if (d.number == -1)
                Console.WriteLine("Testing the default value of number:  " + d.number);
            else
                Console.WriteLine("Expected -1 : Got " + d.number);
            if (d.description == "No description entered")
                Console.WriteLine("Testing the default value of description:  " + d.description);
            else
                Console.WriteLine("Expected No description entered : Got " + d.description);
            if (d.percentage == -1.00)
                Console.WriteLine("Testing the default value of percentage:  " + d.percentage);
            else
                Console.WriteLine("Expected -1.00 Got: " + d.percentage);
            if (d.type == 'U')
                Console.WriteLine("Testing the default value of type:  " + d.type);
            else
                Console.WriteLine("Expected U :  Got " + d.type);

            Console.WriteLine("\nTesting the discount object with its required /all values: 123, here is a description, 80.12, G");
            Discount d1 = new Discount(1337, "Here is a description", 80.12, 'G');


            if (d1.number == 1337)
                Console.WriteLine("Testing the default value of number:  " + d1.number);
            else
                Console.WriteLine("Expected 1337 : Got " + d1.number);
            if (d1.description == "Here is a description")
                Console.WriteLine("Testing the default value of description:  " + d1.description);
            else
                Console.WriteLine("Expected Here is a description : Got " + d1.description);
            if (d1.percentage == 80.12)
                Console.WriteLine("Testing the default value of percentage:  " + d1.percentage);
            else
                Console.WriteLine("Expected 80.12 Got: " + d1.percentage);
            if (d1.type == 'G')
                Console.WriteLine("Testing the default value of type:  " + d1.type);
            else
                Console.WriteLine("Expected G :  Got " + d1.type);

            Console.WriteLine("\nTesting the setters of the Discount object using its default values as a base");
            Console.WriteLine("Setting the value of number to 999: ");
            d.number = 999; ;
            Console.WriteLine("Setting the value of description to Friend of mine: ");
            d.description = "Friend of mine";
            Console.WriteLine("Setting the value of percentage to 100 ");
            d.percentage = 100.00;
            Console.WriteLine("Setting the value of type to Z: ");
            d.type = 'Z';
 

            if (d.number == 999)
                Console.WriteLine("Testing the default value of number:  " + d.number);
            else
                Console.WriteLine("Expected 999 : Got " + d.number);
            if (d.description == "Friend of mine")
                Console.WriteLine("Testing the value of description:  " + d.description);
            else
                Console.WriteLine("Expected Friend of mine : Got " + d.description);
            if (d.percentage == 100.00)
                Console.WriteLine("Testing the  value of percentage:  " + d.percentage);
            else
                Console.WriteLine("Expected 100.00 Got: " + d.percentage);
            if (d.type == 'Z')
                Console.WriteLine("Testing the value of type:  " + d.type);
            else
                Console.WriteLine("Expected Z :  Got " + d.type);

            Console.WriteLine("\nTesting unimplemented methods of the Discount object");
            Console.WriteLine("Calling the checkDiscount Method");
            Console.WriteLine("The checkDiscount will print a message in its method");
            d.checkDiscount();
        }
        public static void testRun()
        {
            Run r = new Run();
            Console.WriteLine("\nTesting the run object:\n");
            Console.WriteLine("Testing the run object with its default constructor: ");
            if (r.number == -1)
                Console.WriteLine("Testing the default value of number:  " + r.number);
            else
                Console.WriteLine("Expected -1 got : " + r.number);
            if (r.size == 'U')
                Console.WriteLine("Testing the default value of size:  " + r.size);
            else
                Console.WriteLine("Expected U got : " +  r.size);
            if (r.covered == 'U')
                Console.WriteLine("Testing the default value of covered:  " + r.covered);
            else
                Console.WriteLine("Expected U got " + r.covered);
            if (r.location == 'U')
                Console.WriteLine("Testing the default value of location:  " + r.location);
            else
                Console.WriteLine("Expected U : Got " + r.location);
            if (r.status == -1)
                Console.WriteLine("Testing the default value of status:  " + r.status);
            else
                Console.WriteLine("Expected - 1 : Got " + r.status);

            Console.WriteLine("\nTesting the food object with its required values: 20 and L");
            Run r1 = new Run(20, 'L');
 

            if (r1.number == 20)
                Console.WriteLine("Testing the default value of number:  " + r1.number);
            else
                Console.WriteLine("Expected 20 got : " + r1.number);
            if (r1.size == 'L')
                Console.WriteLine("Testing the default value of size:  " + r1.size);
            else
                Console.WriteLine("Expected L got : " + r1.size);
            if (r1.covered == 'U')
                Console.WriteLine("Testing the default value of covered:  " + r1.covered);
            else
                Console.WriteLine("Expected U got " + r1.covered);
            if (r1.location == 'U')
                Console.WriteLine("Testing the default value of location:  " + r1.location);
            else
                Console.WriteLine("Expected U : Got " + r1.location);
            if (r1.status == -1)
                Console.WriteLine("Testing the default value of status:  " + r1.status);
            else
                Console.WriteLine("Expected - 1 : Got " + r1.status);

            Console.WriteLine("\nTesting the food object with its all values: 19, L, U, O, 1");
            Run r2 = new Run(19, 'L', 'U', 'O', 1);
            Console.WriteLine("Testing the value of number:  " + r2.number);
            Console.WriteLine("Testing the value of size:  " + r2.size);
            Console.WriteLine("Testing the value of covered:  " + r2.covered);
            Console.WriteLine("Testing the value of location:  " + r2.location);
            Console.WriteLine("Testing the value of status:  " + r2.status);

            if (r2.number == 19)
                Console.WriteLine("Testing the default value of number:  " + r2.number);
            else
                Console.WriteLine("Expected 19 got : " + r2.number);
            if (r2.size == 'L')
                Console.WriteLine("Testing the default value of size:  " + r2.size);
            else
                Console.WriteLine("Expected L got : " + r2.size);
            if (r2.covered == 'U')
                Console.WriteLine("Testing the default value of covered:  " + r2.covered);
            else
                Console.WriteLine("Expected U got " + r2.covered);
            if (r2.location == 'O')
                Console.WriteLine("Testing the default value of location:  " + r2.location);
            else
                Console.WriteLine("Expected O : Got " + r2.location);
            if (r2.status == 1)
                Console.WriteLine("Testing the default value of status:  " + r2.status);
            else
                Console.WriteLine("Expected 1 : Got " + r2.status);

            Console.WriteLine("\nTesting the setters of the food object using its default values as a base");
            Console.WriteLine("Setting the value of number to 321: ");
            r.number = 321;

            Console.WriteLine("Setting the value of size to 'S': ");
            r.size = 'S';

            Console.WriteLine("Setting the value of covered to C: ");
            r.covered = 'C';

            Console.WriteLine("Setting the value of location to I: ");
            r.location = 'I';

            Console.WriteLine("Setting the value of status to 1 ");
            r.status = 1;

            if (r.number == 321)
                Console.WriteLine("Testing the default value of number:  " + r.number);
            else
                Console.WriteLine("Expected 321 got : " + r.number);
            if (r.size == 'S')
                Console.WriteLine("Testing the default value of size:  " + r.size);
            else
                Console.WriteLine("Expected S got : " + r.size);
            if (r.covered == 'C')
                Console.WriteLine("Testing the default value of covered:  " + r.covered);
            else
                Console.WriteLine("Expected C got " + r.covered);
            if (r.location == 'I')
                Console.WriteLine("Testing the default value of location:  " + r.location);
            else
                Console.WriteLine("Expected I : Got " + r.location);
            if (r.status == 1)
                Console.WriteLine("Testing the default value of status:  " + r.status);
            else
                Console.WriteLine("Expected  1 : Got " + r.status);
        }
        public static void testPet()
        {
            Pet p = new Pet();
            Console.WriteLine("\nTesting the Pet object:\n");
            Console.WriteLine("Testing the values of the default constructor for the pet class: ");
            if (p.number == -1)
                Console.WriteLine("Testing the default value of number:  " + p.number);
            else
                Console.WriteLine("Expected -1 : Got " + p.number);
            Console.WriteLine("Testing the default value of name:  " + p.name);
            if (p.gender == 'U')
            Console.WriteLine("Testing the default value of gender:  " + p.gender);
            else
                Console.WriteLine("Expected U : Got " + p.gender);
            if (p.fixedPet == 'U')
            Console.WriteLine("Testing the default value of fixed:  " + p.fixedPet);
            else
                Console.WriteLine("Expected U : Got " + p.fixedPet);
            if (p.birthdate == new DateTime(1000,1,1))
            Console.WriteLine("Testing the default value of birthdate:  " + p.birthdate);
            else
                Console.WriteLine("Expected 1000-1-1 : Got " + p.birthdate);
            if (p.ownerNumber == -1)
            Console.WriteLine("Testing the default value of owner number:  " + p.ownerNumber);
            else
                Console.WriteLine("Expected -1 : Got " + p.ownerNumber);
            if (p.picture == 1)
            Console.WriteLine("Testing the default value of picture:  " + p.picture);
            else
                Console.WriteLine("Expected 1 : Got " + p.picture);
            if (p.size == 'U')
            Console.WriteLine("Testing the default value of size:  " + p.size);
            else
                Console.WriteLine("Expected U : Got " + p.size);
            if (p.notes == "No notes were entered")
            Console.WriteLine("Testing the default value of notes:  " + p.notes);
            else
                Console.WriteLine("Expected no notes were entered");
            if (p.vaccination.Count() == 0)
            Console.WriteLine("Testing the default value of vaccinations: (Should be empty size is 0) Size:" + p.vaccination.Count());
            else
                Console.WriteLine("Size should be 0 : Got " + p.size);


            Console.WriteLine("\nTesting the required values of the constructor for the pet class: 10000, Sparly, M, F, 123, List of size 6");
            List<Vaccination> list = new List<Vaccination>();
            list.Add(new Vaccination());
            list.Add(new Vaccination());
            list.Add(new Vaccination());
            list.Add(new Vaccination());
            list.Add(new Vaccination());
            list.Add(new Vaccination());
            Pet p1 = new Pet(10000, "Sparly", 'M', 'F', 123, list);
            
            Console.WriteLine("Testing the value of number:  " + p1.number);
            Console.WriteLine("Testing the value of name:  " + p1.name);
            Console.WriteLine("Testing the value of gender:  " + p1.gender);
            Console.WriteLine("Testing the value of fixed:  " + p1.fixedPet);
            Console.WriteLine("Testing the value of birthdate:  " + p1.birthdate);
            Console.WriteLine("Testing the value of owner number:  " + p1.ownerNumber);
            Console.WriteLine("Testing the value of picture:  " + p1.picture);
            Console.WriteLine("Testing the value of size:  " + p1.size);
            Console.WriteLine("Testing the value of notes:  " + p1.notes);
            Console.WriteLine("Testing the value of vaccinations: Should be Size 6 | Size:" + p1.vaccination.Count);

            if (p1.number == 10000)
                Console.WriteLine("Testing the default value of number:  " + p1.number);
            else
                Console.WriteLine("Expected 10000 : Got " + p1.number);
            Console.WriteLine("Testing the default value of name:  " + p1.name);
            if (p1.gender == 'M')
                Console.WriteLine("Testing the default value of gender:  " + p1.gender);
            else
                Console.WriteLine("Expected M : Got " + p1.gender);
            if (p1.fixedPet == 'F')
                Console.WriteLine("Testing the default value of fixed:  " + p1.fixedPet);
            else
                Console.WriteLine("Expected F : Got " + p1.fixedPet);
            if (p1.birthdate == new DateTime(1000, 1, 1))
                Console.WriteLine("Testing the default value of birthdate:  " + p1.birthdate);
            else
                Console.WriteLine("Expected 1000-1-1 : Got " + p.birthdate);
            if (p1.ownerNumber == 123)
                Console.WriteLine("Testing the default value of owner number:  " + p1.ownerNumber);
            else
                Console.WriteLine("Expected 123 : Got " + p1.ownerNumber);
            if (p1.picture == 1)
                Console.WriteLine("Testing the default value of picture:  " + p1.picture);
            else
                Console.WriteLine("Expected 1 : Got " + p1.picture);
            if (p1.size == 'U')
                Console.WriteLine("Testing the default value of size:  " + p1.size);
            else
                Console.WriteLine("Expected U : Got " + p1.size);
            if (p1.notes == "No notes were entered")
                Console.WriteLine("Testing the default value of notes:  " + p1.notes);
            else
                Console.WriteLine("Expected no notes were entered: got " + p1.notes);
            if (p1.vaccination.Count() == 0)
                Console.WriteLine("Testing the default value of vaccinations: (Should be empty size is 0) Size:" + p1.vaccination.Count());
            else
                Console.WriteLine("Size should be 0 : Got " + p1.size);

            Console.WriteLine("\nTesting the all values of the constructor for the pet class: 10000, Sparly, M, F, 123, List of size 6");
            Pet p2 = new Pet(10000, "Sparly", 'M', 'F', 123, list, new DateTime(2016, 12, 12), 1, 'M',"Cries alot");
            

            if (p2.number == 10000)
                Console.WriteLine("Testing the value of number:  " + p2.number);
            else
                Console.WriteLine("Expected 10000 : Got " + p2.number);
            Console.WriteLine("Testing the default value of name:  " + p2.name);
            if (p2.gender == 'M')
                Console.WriteLine("Testing the default value of gender:  " + p2.gender);
            else
                Console.WriteLine("Expected M : Got " + p2.gender);
            if (p2.fixedPet == 'F')
                Console.WriteLine("Testing the default value of fixed:  " + p2.fixedPet);
            else
                Console.WriteLine("Expected F : Got " + p2.fixedPet);
            if (p2.birthdate == new DateTime(2016, 12, 12))
                Console.WriteLine("Testing the default value of birthdate:  " + p2.birthdate);
            else
                Console.WriteLine("Expected 1000-1-1 : Got " + p.birthdate);
            if (p2.ownerNumber == 123)
                Console.WriteLine("Testing the default value of owner number:  " + p2.ownerNumber);
            else
                Console.WriteLine("Expected 123 : Got " + p2.ownerNumber);
            if (p2.picture == 1)
                Console.WriteLine("Testing the default value of picture:  " + p2.picture);
            else
                Console.WriteLine("Expected 1 : Got " + p2.picture);
            if (p2.size == 'M')
                Console.WriteLine("Testing the value of size:  " + p2.size);
            else
                Console.WriteLine("Expected M : Got " + p2.size);
            if (p2.notes == "Cries alot")
                Console.WriteLine("Testing the default value of notes:  " + p2.notes);
            else
                Console.WriteLine("Expected Cries alot : Got " + p2.notes);
            if (p2.vaccination.Count() == 6)
                Console.WriteLine("Testing the default value of vaccinations: Should be size 6 Size:" + p2.vaccination.Count());
            else
                Console.WriteLine("Size should be 6 : Got " + p2.size);

            //Testing the setters of the pet class
            Console.WriteLine("\nTesting the setters of the pet object using its default values as a base");
            Console.WriteLine("Setting the value of number to 321: ");
            p.number = 321;
            Console.WriteLine("Setting the value of name to Clifford: ");
            p.name = "Clifford";
            Console.WriteLine("Setting the value of gender to F: ");
            p.gender = 'F';
            Console.WriteLine("Setting the value of fixed to F:");
            p.fixedPet = 'F';
            Console.WriteLine("Setting the value of birthdate to 1997-10-31: ");
            p.birthdate = new DateTime(1997, 10, 31);
            Console.WriteLine("Setting the value of owner number to 111222333 ");
            p.ownerNumber = 111222333;
            Console.WriteLine("Setting the value of picture to : 1");
            
            p.picture = 1;
            Console.WriteLine("Setting the size to G");
            p.size = 'G';
            Console.WriteLine("Setting the value of notes to He is a good dog ");
            p.notes = "He is a good dog";
            Console.WriteLine("Testing the value of notes: " + p.notes);
            Console.WriteLine("Setting value of the list to a list of size 1: ");
            List<Vaccination> list1 = new List<Vaccination>();
            list1.Add(new Vaccination(new DateTime(2016, 1, 1), 999, "THIS IS A NAME"));
            p.vaccination = list1;
            Console.WriteLine("Testing the value of the vaccine object inside the list: " + p.vaccination.ElementAt(0).name + " " + p.vaccination.ElementAt(0).expiryDate + " " + p.vaccination.ElementAt(0).number);

            if (p.number == 321)
                Console.WriteLine("Testing the value of number:  " + p.number);
            else
                Console.WriteLine("Expected 321 : Got " + p.number);
            Console.WriteLine("Testing the default value of name:  " + p2.name);
            if (p.gender == 'F')
                Console.WriteLine("Testing the value of gender:  " + p.gender);
            else
                Console.WriteLine("Expected F : Got " + p.gender);
            if (p.fixedPet == 'F')
                Console.WriteLine("Testing the default value of fixed:  " + p.fixedPet);
            else
                Console.WriteLine("Expected F : Got " + p.fixedPet);
            if (p.birthdate == new DateTime(1997, 10, 31))
                Console.WriteLine("Testing the default value of birthdate:  " + p.birthdate);
            else
                Console.WriteLine("Expected 1997-10-31 : Got " + p.birthdate);
            if (p.ownerNumber == 111222333)
                Console.WriteLine("Testing the  value of owner number:  " + p.ownerNumber);
            else
                Console.WriteLine("Expected 111222333 : Got " + p.ownerNumber);
            if (p.picture == 1)
                Console.WriteLine("Testing the default value of picture:  " + p.picture);
            else
                Console.WriteLine("Expected 1 : Got " + p.picture);
            if (p.size == 'G')
                Console.WriteLine("Testing the value of size:  " + p.size);
            else
                Console.WriteLine("Expected G : Got " + p.size);
            if (p.notes == "He is a good dog")
                Console.WriteLine("Testing the default value of notes:  " + p.notes);
            else
                Console.WriteLine("He is a good dog : Got " + p.notes);
            if (p.vaccination.Count() == 1)
                Console.WriteLine("Testing the default value of vaccinations: Should be size 6 Size:" + p.vaccination.Count());
            else
                Console.WriteLine("Expected: Size should be 1 : Got " + p.vaccination.Count());


        }

        //The method to test all of the person object
        public static void testOwner()
        {
            //Testing the person object
            Owner o = new Owner();
            Console.WriteLine("\nTesting the Person object:\n");
            Console.WriteLine("Testing the values of the default constructor for the person class: ");
            if (o.number == -1)
                Console.WriteLine("Testing the default value of number:  " + o.number);
            else
                Console.WriteLine("Expected value is -1 : Got " + o.number);
            if (o.firstName == "No first name was entered")
                Console.WriteLine("Testing the default value of first name: " + o.firstName);
            else
                Console.WriteLine("Expected No first name was entered : Got " + o.firstName);
            if (o.lastName == "No last name was entered")
                Console.WriteLine("Testing the default value of last name: " + o.lastName);
            else
                Console.WriteLine("Expected No last name was entered : Got " + o.firstName);
            if (o.street == "No street was entered")
                Console.WriteLine("Testing the default value of street: " + o.street);
            else
                Console.WriteLine("Expected 'No street was entered'  : " + o.street);
            if (o.city == "No city was entered")
                Console.WriteLine("Testing the default value of city: " + o.city);
            else
                Console.WriteLine("Expected No city was entered : Got" + o.city);
            if (o.province == "No province was entered")
                Console.WriteLine("Testing the default value of province: " + o.province);
            else
                Console.WriteLine("Expected No province was entered : Got " + o.province);
            if (o.postalCode == "No postal code was entered")
                Console.WriteLine("Testing the default value of postal code: " + o.postalCode);
            else
                Console.WriteLine("Expected No postal code was entered : Got " + o.postalCode);
            if (o.phone == "No phone was entered")
                Console.WriteLine("Testing the default value of phone: " + o.phone);
            else
                Console.WriteLine("Expected No phone was entered : " + o.phone);
            if (o.email == "No email was entered")
                Console.WriteLine("Testing the default value of email: " + o.email);
            else
                Console.WriteLine("Expected value was No email was entered : Got : " + o.email);
            if (o.emergencyFirstName == "No emergency first name was entered")
                Console.WriteLine("Testing the default value of emergency first name: " + o.emergencyFirstName);
            else
                Console.WriteLine("Expected No emergency first name was entered : Got : " + o.emergencyFirstName);
            if (o.emergencyLastName == "No emergency last name was entered")
                Console.WriteLine("Testing the default value of emergency last name: " + o.emergencyLastName);
            else
                Console.WriteLine("Expected No emergency last name was entered");
            if (o.emergencyPhone == "No emergency phone was entered")
                Console.WriteLine("Testing the default value of emergency phone: " + o.emergencyPhone);
            else
                Console.WriteLine("Expected No emergency phone was entered : Got : ");
            if (o.pet.Count() == 0)
                Console.WriteLine("Testing the size of the pet object: " + o.pet.Count());
            else
                Console.WriteLine("Expected size 0 : Got " + o.pet.Count());
            if (o.vet.Count() == 0)
                Console.WriteLine("Testing the size of the vet object: " + o.vet.Count());
            else
                Console.WriteLine("Expected size 0 : got : " + o.vet.Count());
            if (o.typeOfUser == 'U')
                Console.WriteLine("Testing the default value of the type of user: " + o.typeOfUser);
            else
                Console.WriteLine("Expected U Got : " + o.typeOfUser);

            Console.WriteLine("Testing the required values of the owner object:"
                 + "Values are 123, Here is a first name, Here is a last name, "
                 + " a default pet object in a list, a default vet in a list");
            //Adding a pet object and Vet object just to test the list
            Pet pet = new Pet();
            List<Pet> p = new List<Pet>();
            p.Add(pet);
            List<Veterinarian> v = new List<Veterinarian>();
            Veterinarian vet = new Veterinarian();
            v.Add(vet);            
            Owner o1 = new Owner(123, "Here is a first name", "Here is a last name", p, v);
            

            if (o1.number == 123)
                Console.WriteLine("Testing the default value of number:  " + o1.number);
            else
                Console.WriteLine("Expected value is 123 : Got " + o1.number);
            if (o1.firstName == "Here is a first name")
                Console.WriteLine("Testing the default value of first name: " + o1.firstName);
            else
                Console.WriteLine("Expected value was Here is a first name : Got " + o1.firstName);
            if (o1.lastName == "Here is a last name")
                Console.WriteLine("Testing the default value of last name: " + o1.lastName);
            else
                Console.WriteLine("Expected Here is a last name : Got " + o1.firstName);
            if (o1.street == "No street was entered")
                Console.WriteLine("Testing the default value of street: " + o1.street);
            else
                Console.WriteLine("Expected 'No street was entered'  : " + o1.street);
            if (o1.city == "No city was entered")
                Console.WriteLine("Testing the default value of city: " + o1.city);
            else
                Console.WriteLine("Expected No city was entered : Got" + o1.city);
            if (o1.province == "No province was entered")
                Console.WriteLine("Testing the default value of province: " + o1.province);
            else
                Console.WriteLine("Expected No province was entered : Got " + o1.province);
            if (o1.postalCode == "No postal code was entered")
                Console.WriteLine("Testing the default value of postal code: " + o1.postalCode);
            else
                Console.WriteLine("Expected No postal code was entered : Got " + o1.postalCode);
            if (o1.phone == "No phone was entered")
                Console.WriteLine("Testing the default value of phone: " + o1.phone);
            else
                Console.WriteLine("Expected No phone was entered : " + o1.phone);
            if (o1.email == "No email was entered")
                Console.WriteLine("Testing the default value of email: " + o1.email);
            else
                Console.WriteLine("Expected value was No email was entered : Got : " + o1.email);
            if (o1.emergencyFirstName == "No emergency first name was entered")
                Console.WriteLine("Testing the default value of emergency first name: " + o1.emergencyFirstName);
            else
                Console.WriteLine("Expected No emergency first name was entered : Got : " + o1.emergencyFirstName);
            if (o1.emergencyLastName == "No emergency last name was entered")
                Console.WriteLine("Testing the default value of emergency last name: " + o1.emergencyLastName);
            else
                Console.WriteLine("Expected No emergency last name was entered");
            if (o1.emergencyPhone == "No emergency phone was entered")
                Console.WriteLine("Testing the default value of emergency phone: " + o1.emergencyPhone);
            else
                Console.WriteLine("Expected No emergency phone was entered : Got : ");
            if (o1.pet.Count() == 1)
                Console.WriteLine("Testing the size of the pet object: " + o1.pet.Count());
            else
                Console.WriteLine("Expected size 1 : Got " + o1.pet.Count());
            if (o1.vet.Count() == 1)
                Console.WriteLine("Testing the size of the vet object: " + o1.vet.Count());
            else
                Console.WriteLine("Expected size 1 : got : " + o1.vet.Count());
            if (o1.typeOfUser == 'U')
                Console.WriteLine("Testing the default value of the type of user: " + o1.typeOfUser);
            else
                Console.WriteLine("Expected U Got : " + o1.typeOfUser);

            Owner o2 = new Owner(567, "Andrew", "Ha", p, v, "Cite Des Jeunes", "Chelsea", "The YUKON", "1a1a1a", "123-123-1234", "123@email.com", "hero", "here last", "123-123-3211", 'E');

            if (o2.number == 567)
                Console.WriteLine("Testing the default value of number:  " + o2.number);
            else
                Console.WriteLine("Expected value is 567 : Got " + o2.number);
            if (o2.firstName == "Andrew")
                Console.WriteLine("Testing the default value of first name: " + o2.firstName);
            else
                Console.WriteLine("Expected value was Andrew : Got " + o2.firstName);
            if (o2.lastName == "Ha")
                Console.WriteLine("Testing the default value of last name: " + o2.lastName);
            else
                Console.WriteLine("Expected Ha : Got " + o2.firstName);
            if (o2.street == "Cite Des Jeunes")
                Console.WriteLine("Testing the default value of street: " + o2.street);
            else
                Console.WriteLine("Expected 'Cite Des Jeunes'  : " + o2.street);
            if (o2.city == "Chelsea")
                Console.WriteLine("Testing the default value of city: " + o2.city);
            else
                Console.WriteLine("Expected Chelsea : Got" + o2.city);
            if (o2.province == "The YUKON")
                Console.WriteLine("Testing the default value of province: " + o2.province);
            else
                Console.WriteLine("Expected The YUKON : Got " + o2.province);
            if (o2.postalCode == "1a1a1a")
                Console.WriteLine("Testing the default value of postal code: " + o2.postalCode);
            else
                Console.WriteLine("Expected 1a1a1a : Got " + o2.postalCode);
            if (o2.phone == "123-123-1234")
                Console.WriteLine("Testing the default value of phone: " + o2.phone);
            else
                Console.WriteLine("Expected 123-123-1234 : " + o2.phone);
            if (o2.email == "123@email.com")
                Console.WriteLine("Testing the default value of email: " + o2.email);
            else
                Console.WriteLine("Expected value was 123@email.com : Got : " + o2.email);
            if (o2.emergencyFirstName == "hero")
                Console.WriteLine("Testing the default value of emergency first name: " + o2.emergencyFirstName);
            else
                Console.WriteLine("Expected hero : Got : " + o2.emergencyFirstName);
            if (o2.emergencyLastName == "here last")
                Console.WriteLine("Testing the default value of emergency last name: " + o2.emergencyLastName);
            else
                Console.WriteLine("Expected here last");
            if (o2.emergencyPhone == "123-123-3211")
                Console.WriteLine("Testing the default value of emergency phone: " + o2.emergencyPhone);
            else
                Console.WriteLine("Expected 123-123-3211 : Got : ");
            if (o2.pet.Count() == 1)
                Console.WriteLine("Testing the size of the pet object: " + o2.pet.Count());
            else
                Console.WriteLine("Expected size 1 : Got " + o2.pet.Count());
            if (o2.vet.Count() == 1)
                Console.WriteLine("Testing the size of the vet object: " + o2.vet.Count());
            else
                Console.WriteLine("Expected size 1 : got : " + o2.vet.Count());
            if (o2.typeOfUser == 'E')
                Console.WriteLine("Testing the default value of the type of user: " + o2.typeOfUser);
            else
                Console.WriteLine("Expected E Got : " + o2.typeOfUser);

            //Testing the setters for the owner class
            Console.WriteLine("Testing the setters of the constructor for the person class using its defaults as a base: ");
            Console.WriteLine("Setting the value of number to 999: ");
            o.number = 999;
            Console.WriteLine("Setting the value of first name to MyNameIsAndrewHa: ");
            o.firstName = "MyNameIsAndrewHa";
            Console.WriteLine("Setting the value of last name to MyLastNameHaHa: ");
            o.lastName = "MyLastNameHaHa";
            Console.WriteLine("Setting the value of street to Joke Street: ");
            o.street = "Joke Street";
            Console.WriteLine("Setting the value of city to Vancouver: ");
            o.city = "Vancouver";
            Console.WriteLine("Setting the value of province to British Columbia: ");
            o.province = "British Columbia";
            Console.WriteLine("Setting the value of postal code: ");
            o.postalCode = "J9J3Y7";
            Console.WriteLine("Setting the value of phone to 123-123-3214: ");
            o.phone = "123-123-3214";
            Console.WriteLine("Setting the value of email to Ha.Andrew@email.com: ");
            o.email = "Ha.Andrew@email.com";        
            Console.WriteLine("Setting the emergency first name to EmergencyAndrewFirst: ");
            o.emergencyFirstName = "EmergencyAndrewFirst";
            Console.WriteLine("Setting the value of emergency last name to EmergencyHaLast: ");
            o.emergencyLastName = "EmergencyHaLast";
            Console.WriteLine("Setting the value of emergency phone to 911: ");
            o.emergencyPhone = "911";
            Console.WriteLine("Setting the value of pet list to contain 1 pet: ");
            o.pet = p;
            Console.WriteLine("Setting the value of pet list to contain 1 pet: ");
            o.vet = v;
            Console.WriteLine("Setting the value of user to A: ");
            o.typeOfUser = 'A';
 

            if (o.number == 999)
                Console.WriteLine("Testing the default value of number:  " + o.number);
            else
                Console.WriteLine("Expected value is 999 : Got " + o.number);
            if (o.firstName == "MyNameIsAndrewHa")
                Console.WriteLine("Testing the default value of first name: " + o.firstName);
            else
                Console.WriteLine("Expected value was MyNameIsAndrewHa : Got " + o.firstName);
            if (o.lastName == "MyLastNameHaHa")
                Console.WriteLine("Testing the default value of last name: " + o.lastName);
            else
                Console.WriteLine("Expected Ha : Got " + o.firstName);
            if (o.street == "Joke Street")
                Console.WriteLine("Testing the default value of street: " + o.street);
            else
                Console.WriteLine("Expected 'Joke Street'  : " + o.street);
            if (o.city == "Vancouver")
                Console.WriteLine("Testing the default value of city: " + o.city);
            else
                Console.WriteLine("Expected Vancouver : Got" + o.city);
            if (o.province == "British Columbia")
                Console.WriteLine("Testing the default value of province: " + o.province);
            else
                Console.WriteLine("Expected British Columbia : Got " + o.province);
            if (o.postalCode == "J9J3Y7")
                Console.WriteLine("Testing the default value of postal code: " + o.postalCode);
            else
                Console.WriteLine("Expected J9J3Y7 : Got " + o.postalCode);
            if (o.phone == "123-123-3214")
                Console.WriteLine("Testing the default value of phone: " + o.phone);
            else
                Console.WriteLine("Expected 123-123-3214 : " + o.phone);
            if (o.email == "Ha.Andrew@email.com")
                Console.WriteLine("Testing the default value of email: " + o.email);
            else
                Console.WriteLine("Expected value was Ha.Andrew@email.com : Got : " + o.email);
            if (o.emergencyFirstName == "EmergencyAndrewFirst")
                Console.WriteLine("Testing the default value of emergency first name: " + o.emergencyFirstName);
            else
                Console.WriteLine("Expected EmergencyAndrewFirst : Got : " + o.emergencyFirstName);
            if (o.emergencyLastName == "EmergencyHaLast")
                Console.WriteLine("Testing the default value of emergency last name: " + o.emergencyLastName);
            else
                Console.WriteLine("Expected EmergencyHaLast : Got " + o.emergencyLastName);
            if (o.emergencyPhone == "911")
                Console.WriteLine("Testing the default value of emergency phone: " + o.emergencyPhone);
            else
                Console.WriteLine("Expected 911 : Got : " + o.emergencyPhone);
            if (o.pet.Count() == 1)
                Console.WriteLine("Testing the size of the pet object: " + o.pet.Count());
            else
                Console.WriteLine("Expected size 1 : Got " + o.pet.Count());
            if (o.vet.Count() == 1)
                Console.WriteLine("Testing the size of the vet object: " + o.vet.Count());
            else
                Console.WriteLine("Expected size 1 : got : " + o.vet.Count());
            if (o.typeOfUser == 'A')
                Console.WriteLine("Testing the default value of the type of user: " + o.typeOfUser);
            else
                Console.WriteLine("Expected A Got : " + o.typeOfUser);
            if (o.pet.ElementAt(0) == pet)
                Console.WriteLine("Pet object matches");
            else
                Console.WriteLine("Pet object does not match");
            if (o.vet.ElementAt(0) == vet)
                Console.WriteLine("Vet object matches");
            else
                Console.WriteLine("Vet object does not match");

        }

        public static void testPetReservation()
        {
            PetReservation pr = new PetReservation();
            
            Console.WriteLine("\nTesting the PetReservationObject:\n");
            Console.WriteLine("Testing the default values of the pet reservation constructors/lists");
            if (pr.pet.number == new Pet().number)
                Console.WriteLine("Testing the values of pet: " + "\nPet Number: " + pr.pet.number + "\nName: " + pr.pet.name + "\nGender: " + pr.pet.gender + "\nFixed: " + pr.pet.fixedPet + "\nBirthdate: " + pr.pet.birthdate + "\nOwner Number: " + pr.pet.ownerNumber + "\nPicture:" + pr.pet.picture + "\nSize: " + pr.pet.size + "\nNotes: " + pr.pet.notes + "\nVaccination: " + pr.pet.vaccination);
            else
                Console.WriteLine("Pet object not matching");
            if (pr.run.number == new Run().number)
                Console.WriteLine("Testing the values of run: " + "\nRun Number: " + pr.run.number + "\nRun size:" + pr.run.size + "\nCovered: " + pr.run.covered + "\nRun location: " + pr.run.location + "\nStatus: " + pr.run.status);
            else
                Console.WriteLine("Run object not matching");
            if (pr.kennelLog.number == new KennelLog().number)
                Console.WriteLine("Testing the values of the kennel log object: " + "\nKennel Log number: " + pr.kennelLog.number + "\nDate: " + pr.kennelLog.date + "\nNotes: " + pr.kennelLog.notes + "\nVideo: " + pr.kennelLog.video);
            else
                Console.WriteLine("Kennel Log not matching");
            if (pr.food.number == new Food().number)
                Console.WriteLine("Testing the values of the food object: " + "\nFood Number: " + pr.food.number + "\nBrand: " + pr.food.brand + "\nFrequency: " + pr.food.frequency + "\nVariety: " + pr.food.variety + "\nQuantity: " + pr.food.quantity);
            else
                Console.WriteLine("Food not matching");
            if (pr.medication.Count() == 0)
                Console.WriteLine("Testing the medication list should be empty: " + pr.medication.Count());
            else
                Console.WriteLine("Expected Empty Medication List got " + pr.medication.Count());
            if (pr.service.Count() == 0)
                Console.WriteLine("Testing service list should be empty: " + pr.service.Count());
            else
                Console.WriteLine("Expected Empty Service list, got : " +  pr.service.Count());

            Console.WriteLine("\nTesting the constructor with all it's required values:");
            //Creating a Pet Object, Run Object, Kennel Log Object, Food Object
            Console.WriteLine("Creating Pet, Run, Kennel , Food Object");
            Pet pet = new Pet(999, "Sparky", 'M', 'Y', 111, new List<Vaccination>(), new DateTime(2016-1-1), 1, 'S', "He is a good dog");
            Vaccination vacc = new Vaccination();
            pet.vaccination.Add(vacc);
            Run run = new Run(123, 'S', 'C', 'O', 1);
            KennelLog kennelLog = new KennelLog(new DateTime(2000 - 12 - 12), 21, "Log Notes", 12);
            Food food = new Food(52, "Iams", 2, "Veggie", "50cups");


            PetReservation pr2 = new PetReservation(pet, run, food, kennelLog);
            

            if (pr2.pet.number == pet.number)
                Console.WriteLine("Testing the values of pet: " + "\nPet Number: " + pr2.pet.number + "\nName: " + pr2.pet.name + "\nGender: " + pr2.pet.gender + "\nFixed: " + pr2.pet.fixedPet + "\nBirthdate: " + pr2.pet.birthdate + "\nOwner Number: " + pr2.pet.ownerNumber + "\nPicture:" + pr2.pet.picture + "\nSize: " + pr2.pet.size + "\nNotes: " + pr2.pet.notes + "\nVaccination: " + pr2.pet.vaccination);
            else
                Console.WriteLine("Pet object not matching");
            if (pr2.run.number == run.number)
                Console.WriteLine("Testing the values of run: " + "\nRun Number: " + pr2.run.number + "\nRun size:" + pr2.run.size + "\nCovered: " + pr2.run.covered + "\nRun location: " + pr2.run.location + "\nStatus: " + pr2.run.status);
            else
                Console.WriteLine("Run object not matching");
            if (pr2.kennelLog.number == kennelLog.number)
                Console.WriteLine("Testing the values of the kennel log object: " + "\nKennel Log number: " + pr2.kennelLog.number + "\nDate: " + pr2.kennelLog.date + "\nNotes: " + pr2.kennelLog.notes + "\nVideo: " + pr2.kennelLog.video);
            else
                Console.WriteLine("Kennel Log not matching");
            if (pr2.food.number == food.number)
                Console.WriteLine("Testing the values of the food object: " + "\nFood Number: " + pr2.food.number + "\nBrand: " + pr2.food.brand + "\nFrequency: " + pr2.food.frequency + "\nVariety: " + pr2.food.variety + "\nQuantity: " + pr2.food.quantity);
            else
                Console.WriteLine("Food not matching");
            if (pr2.medication.Count() == 0)
                Console.WriteLine("Testing the medication list should be 0: " + pr2.medication.Count());
            else
                Console.WriteLine("Expected 0 Medication List got " + pr2.medication.Count());
            if (pr2.service.Count() == 0)
                Console.WriteLine("Testing service list should be 0: " + pr2.service.Count());
            else
                Console.WriteLine("Expected 0 Service list, got : " + pr2.service.Count());

            Medication med = new Medication(100, "Vaccine Name Here", "50mm", "Inject", new DateTime(2017, 1, 1));
            List<Medication> medList = new List<Medication>();
            medList.Add(med);
            Service serv = new Service(1337, "Walking Dog", new DailyRate(), 3);
            List<Service> servList = new List<Service>();
            servList.Add(serv);

            PetReservation pr1 = new PetReservation(pet, run, food, kennelLog, medList, servList);
           

            

            Console.WriteLine("\nTesting the setters of the PetReservationClass using the defaults as values: ");
            Console.WriteLine("Setting pet to a non-default");
            pr.pet = pet;
           
            Console.WriteLine("Setting Run to a non-default version");
            pr.run = run;
           
            Console.WriteLine("Setting kennel log object to non-default");
            pr.kennelLog = kennelLog;
           
            Console.WriteLine("Testing the values of food object with non-default: ");
            pr.food = food;
            
            Console.WriteLine("Setting value of list to a non-default");
            pr.medication = medList;
           
           
            Console.WriteLine("Setting service list to non-default");
            pr.service = servList;            

            if (pr.pet.number == pet.number)
                Console.WriteLine("Testing the values of pet: " + "\nPet Number: " + pr.pet.number + "\nName: " + pr.pet.name + "\nGender: " + pr.pet.gender + "\nFixed: " + pr.pet.fixedPet + "\nBirthdate: " + pr.pet.birthdate + "\nOwner Number: " + pr.pet.ownerNumber + "\nPicture:" + pr.pet.picture + "\nSize: " + pr.pet.size + "\nNotes: " + pr.pet.notes + "\nVaccination: " + pr.pet.vaccination);
            else
                Console.WriteLine("Pet object not matching");
            if (pr.run.number == run.number)
                Console.WriteLine("Testing the values of run: " + "\nRun Number: " + pr.run.number + "\nRun size:" + pr.run.size + "\nCovered: " + pr.run.covered + "\nRun location: " + pr.run.location + "\nStatus: " + pr.run.status);
            else
                Console.WriteLine("Run object not matching");
            if (pr.kennelLog.number == kennelLog.number)
                Console.WriteLine("Testing the values of the kennel log object: " + "\nKennel Log number: " + pr.kennelLog.number + "\nDate: " + pr.kennelLog.date + "\nNotes: " + pr.kennelLog.notes + "\nVideo: " + pr.kennelLog.video);
            else
                Console.WriteLine("Kennel Log not matching");
            if (pr.food.number == food.number)
                Console.WriteLine("Testing the values of the food object: " + "\nFood Number: " + pr.food.number + "\nBrand: " + pr.food.brand + "\nFrequency: " + pr.food.frequency + "\nVariety: " + pr.food.variety + "\nQuantity: " + pr.food.quantity);
            else
                Console.WriteLine("Food not matching");
            if (pr.medication.Count() == 1)
            {
                Console.WriteLine("Testing the medication list should be 1: " + pr.medication.Count());
                Console.WriteLine("Testing the value of medication number:  " + pr.medication.ElementAt(0).number);
                Console.WriteLine("Testing the value of medication name:  " + pr.medication.ElementAt(0).name);
                Console.WriteLine("Testing the value of medication dosage:  " + pr.medication.ElementAt(0).dosage);
                Console.WriteLine("Testing the value of medication special instructions: " + pr.medication.ElementAt(0).instructions);
                Console.WriteLine("Testing the value of medication end date: " + pr.medication.ElementAt(0).endDate);
            }
                
            else
                Console.WriteLine("Expected 1 Medication List got " + pr.medication.Count());
            if (pr.service.Count() == 1)
            {
                Console.WriteLine("Testing service list should be 1: " + pr.service.Count());
                Console.WriteLine("Testing service list should be empty: " + pr.service.Count());
                Console.WriteLine("Testing the default value of number:  " + pr.service.ElementAt(0).number);
                Console.WriteLine("Testing the default value of frequency:  " + pr.service.ElementAt(0).frequency);
                Console.WriteLine("Testing the default value of description:  " + pr.service.ElementAt(0).description);
                Console.WriteLine("Testing the required size/value of dailyRate :  " + pr.service.ElementAt(0).dailyRate.number + " " + pr.service.ElementAt(0).dailyRate.rate + " " + pr.service.ElementAt(0).dailyRate.size);
            }
               
            else
                Console.WriteLine("Expected 1 Service list, got : " + pr.service.Count());
        }
        public static void testReservation()
        {
            Reservation r = new Reservation();
            Console.WriteLine("\nTesting the test reservation object:\n");
            Console.WriteLine("Testing the default reservation object: ");
            if (r.number == -1)
                Console.WriteLine("Testing the reservation number: " + r.number);
            else
                Console.WriteLine("Expected -1 : Got " + r.number);
            if (r.startDate == new DateTime(1000, 1, 1))
                Console.WriteLine("Testing the start date: " + r.startDate);
            else
                Console.WriteLine("Expected 1000-1-1 : Got " + r.startDate);
            if (r.endDate == new DateTime(1000, 1, 1))
                Console.WriteLine("Testing the end date: " + r.endDate);
            else
                Console.WriteLine("Expected 1000-1-1");
            if (r.petReservation.Count() == 0)
                Console.WriteLine("Testing the pet reservation list, should be size 0: " + r.petReservation.Count());
            else
                Console.WriteLine("Expected Size 0 : Got " + r.petReservation.Count());
            if (r.discount.Count() == 0)
                Console.WriteLine("Testing the discount object: " + r.discount.Count());
            else
                Console.WriteLine("Expected Size 0 : Got " + r.discount.Count());

            Console.WriteLine("\nTesting the reservation with required values");
            PetReservation pr = new PetReservation();
            List<PetReservation> prList = new List<PetReservation>();
            prList.Add(pr);
            DateTime startDate = new DateTime(2016, 1, 1);
            DateTime endDate = new DateTime(2017, 1, 1);
            Discount d = new Discount();
            List<Discount> dList = new List<Discount>();
            dList.Add(d);
            Reservation r1 = new Reservation(666, prList, startDate, endDate,'A', dList);
           

            if (r1.number == 666)
                Console.WriteLine("Testing the reservation number: " + r1.number);
            else
                Console.WriteLine("Expected 666 : Got " + r1.number);
            if (r1.startDate.Equals(startDate))
                Console.WriteLine("Testing the start date: " + r1.startDate);
            else
                Console.WriteLine("Expected 2016-1-1 : Got " + r1.startDate);
            if (r1.endDate.Equals(endDate))
                Console.WriteLine("Testing the end date: " + r1.endDate);
            else
                Console.WriteLine("Expected 2017-1-1");
            if (r1.petReservation.Count() == 1)
                Console.WriteLine("Testing the pet reservation list, should be size 1: " + r1.petReservation.Count());
            else
                Console.WriteLine("Expected Size 1 : Got " + r1.petReservation.Count());
            if (r1.discount.Count() == 1)
                Console.WriteLine("Testing the discount object: " + r1.discount.Count());
            else
                Console.WriteLine("Expected Size 1 : Got " + r1.discount.Count());

            Console.WriteLine("\nTesting the setters of the reservation object - using default constructor as value: ");
            Console.WriteLine("Setting the number to 1234567");
            r.number = 1234567;
            Console.WriteLine("Setting the date to January 31 1997");
            r.startDate = new DateTime(1997, 1, 31); ;
            Console.WriteLine("Setting the date to February 1 1998");
            r.endDate = new DateTime(1998, 2, 1); ;
            Console.WriteLine("Setting the pet reservation list to a list of size 1");
            r.petReservation = prList;            
            Console.WriteLine("Setting the discount list of size 1");
            r.discount = dList;

            if (r.number == 1234567)
                Console.WriteLine("Testing the reservation number: " + r.number);
            else
                Console.WriteLine("Expected 1234567 : Got " + r.number);
            if (r.startDate.Equals(new DateTime(1997, 1, 31)))
                Console.WriteLine("Testing the start date: " + r.startDate);
            else
                Console.WriteLine("Expected 1997-1-31 : Got " + r.startDate);
            if (r.endDate.Equals(new DateTime(1998, 2, 1)))
                Console.WriteLine("Testing the end date: " + r.endDate);
            else
                Console.WriteLine("Expected 2017-1-1 Got : " + r.endDate);
            if (r.petReservation.Count() == 1)
                Console.WriteLine("Testing the pet reservation list, should be size 1: " + r.petReservation.Count());
            else
                Console.WriteLine("Expected Size 1 : Got " + r.petReservation.Count());
            if (r.discount.Count() == 1)
                Console.WriteLine("Testing the discount object: " + r.discount.Count());
            else
                Console.WriteLine("Expected Size 1 : Got " + r.discount.Count());



        }
        
    }
}
