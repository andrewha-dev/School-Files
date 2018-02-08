using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovingLibrary;

namespace aha_L03C
{
    [TestClass]
    public class aha_L03C
    {
        [TestMethod]
        public void TestConstructors()
        {
            Moving m = new Moving();
            Assert.AreEqual(0, m.Distance, "Parameter should be 0");
            Assert.AreEqual(0, m.Weight, "Parameter should be 0");
            Assert.AreEqual(0, m.Flights, "Parameter should be 0");
            Assert.AreEqual(0, m.Pianos, "Parameter should be 0");
            Assert.AreEqual(0, m.Appliances, "Parameter should be 0");

            Moving m1 = new Moving(1, 2);
            Assert.AreEqual(1, m1.Distance, "Parameter should be 1");
            Assert.AreEqual(2, m1.Weight, "Parameter should be 2");
            Assert.AreEqual(0, m1.Flights, "Parameter should be 0");
            Assert.AreEqual(0, m1.Pianos, "Parameter should be 0");
            Assert.AreEqual(0, m1.Appliances, "Parameter should be 0");

            Moving m2 = new Moving(1, 2, 3, 4, 5);
            Assert.AreEqual(1, m2.Distance, "Parameter should be 1");
            Assert.AreEqual(2, m2.Weight, "Parameter should be 2");
            Assert.AreEqual(3, m2.Flights, "Parameter should be 3");
            Assert.AreEqual(4, m2.Pianos, "Parameter should be 4");
            Assert.AreEqual(5, m2.Appliances, "Parameter should be 5");
            
        }

        [TestMethod]
        public void testTotalCost1()
        {
            Moving m = new Moving();
            Assert.AreEqual(0, m.TotalCost(), "Wrong Total");
        }

        [TestMethod]
        public void testTotalCost2()
        {
            Moving m = new Moving(100, 50);
            Assert.AreEqual(187.5, m.TotalCost(), "Wrong Total");
        }
        [TestMethod]
        public void testTotalCost3()
        {
            Moving m = new Moving(10, 20, 30, 40, 50);
            Assert.AreEqual(5680, m.TotalCost(), "Wrong Total");
        }
    }
}
