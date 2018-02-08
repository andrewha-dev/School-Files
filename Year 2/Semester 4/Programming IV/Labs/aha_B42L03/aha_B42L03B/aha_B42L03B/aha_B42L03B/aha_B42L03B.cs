using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankLibrary;
namespace aha_B42L03B
{
    [TestClass]
    public class aha_B42L03B
    {
        [TestMethod]
        public void ConstructorTest()
        {
            BankAccount ba = new BankAccount("MyName", 123.12);
            //Testing the name
            Assert.AreEqual("MyName", ba.CustomerName, "Name isnt matching");
            //Testing the balance
            Assert.AreEqual(123.12, ba.Balance, "Balance isn't the same");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void testDebitExceptionsNegativeAmount()
        {
            //Testing if the balance is negative
            BankAccount ba = new BankAccount("MrHa", 100.00);
            ba.Debit(-10.00);
            Assert.AreEqual(100.00, ba.Balance, "Incorrect balance");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void testDebitExceptionsBiggerThenBalance()
        {
            //Testing if the balance is negative
            BankAccount ba = new BankAccount("MrHa", 100.00);
            ba.Debit(110.00);
            Assert.AreEqual(100.00, ba.Balance, "Incorrect balance");

        }

        [TestMethod]
        public void testDebitExceptionsFrozen()
        {
            //Testing if the balance is negative
            try
            {
            BankAccount ba = new BankAccount("MrHa", 100.00);
                    ba.FreezeAccount();
                    ba.Debit(10.00);
                
            }
            catch (Exception e)
            {
                StringAssert.Equals("amount", e);
            }
        }

        

        [TestMethod]
        public void testDebit()
        {
            //Testing if not frozen
            BankAccount ba = new BankAccount("MrHa", 100.00);
            ba.Debit(10.00);
            Assert.AreEqual(90.00, ba.Balance, "Incorrect balance");

        }

        [TestMethod]
        public void testUnfreeze()
        {
            //Testing if the balance is negative
            BankAccount ba = new BankAccount("MrHa", 100.00);
            ba.UnfreezeAccount();
            ba.Credit(1.00);
            Assert.AreEqual(101.00, ba.Balance, "Incorrect balance");

        }

        [TestMethod]
        public void testCredit()
        {
            //Testing if the balance is negative
            BankAccount ba = new BankAccount("MrHa", 100.00);
            ba.Credit(101.00);
            Assert.AreEqual(201.00, ba.Balance, "Incorrect balance");

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void testCreditExceptionsBiggerThenBalance()
        {
            //Testing if the account is frozen
            BankAccount ba = new BankAccount("MrHa", 100.00);
            ba.FreezeAccount();
            ba.Credit(100.0);
            Assert.AreEqual(100.00, ba.Balance, "Incorrect balance");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void testCreditNegativeAmount()
        {
            //Testing if the balance is negative
            BankAccount ba = new BankAccount("MrHa", 100.00);
            ba.Credit(-5.00);
            Assert.AreEqual(100.00, ba.Balance, "Incorrect balance");

        }


    }
}
