using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapesLibrary;

namespace aha_PartAShapes
{
    [TestClass]
    public class partAShapes
    {
        [TestMethod]
        public void TestConstructors()
        {
            //Testing the circle
            Shapes s = new Shapes();
            Assert.AreEqual(1, s.side1, "Should be a circle and size 1");
            Assert.AreEqual(0, s.side2, "Should be 0");
            Assert.AreEqual(0, s.side3, "Should be 0");
            Assert.AreEqual(0, s.shape, "Should be a circle");

            Shapes s5 = new Shapes(5, 0);
            Assert.AreEqual(5, s5.side1, "Should be a circle and size 1");
            Assert.AreEqual(0, s5.side2, "Should be 0");
            Assert.AreEqual(0, s5.side3, "Should be 0");
            Assert.AreEqual(0, s5.shape, "Should be a circle");

            //Testing with 4 parameters
            Shapes s1 = new Shapes(1, 2, 3, 1);
            Assert.AreEqual(1, s1.side1, "Should be 1");
            Assert.AreEqual(2, s1.side2, "Should be 2");
            Assert.AreEqual(3, s1.side3, "Should be 3");
            Assert.AreEqual(1, s1.shape, "Should be a 1");

            //Testing with 3 parameters
            Shapes s2 = new Shapes(3, 1, 2);
            Assert.AreEqual(3, s2.side1, "Should be 3");
            Assert.AreEqual(1, s2.side2, "Should be 1");
            Assert.AreEqual(0, s2.side3, "Should be 0");
            Assert.AreEqual(2, s2.shape, "Should be a 2");

            //Testing with 3 parameters
            Shapes s3 = new Shapes(3, 1);
            Assert.AreEqual(3, s3.side1, "Should be 3");
            Assert.AreEqual(0, s3.side2, "Should be 0");
            Assert.AreEqual(0, s3.side3, "Should be 0");
            Assert.AreEqual(1, s3.shape, "Should be a 1");

            



        }

        [TestMethod]
        public void TestArea()
        {
            //Testing the area of square
            Shapes square = new Shapes(5, 1);
            Assert.AreEqual(25, square.Area(), "Error: Expected 25 for area");

            //Testing area of rectangle
            Shapes rectangle = new Shapes(3, 5, 1);
            Assert.AreEqual(15, rectangle.Area(), "Area should be 15");

            Shapes circle = new Shapes();
            //Testing the area of empty circle
            Assert.AreEqual(Math.PI, circle.Area(), "Error, area is wrong");

            //Testing the area of triangle
            Shapes tri = new Shapes(4,5,2);
            Assert.AreEqual(10, tri.Area(), "Area is incorrect should be 20");

                   
        }

        [TestMethod]
        public void testPerimeter()
        {
            //Testing the square
            Shapes sq = new Shapes(4, 1);
            Assert.AreEqual(16, sq.Perimeter(), "Error: Expected 16 for perimeter");

            //Testing the rectangle
            Shapes rec = new Shapes(3, 2, 1);
            Assert.AreEqual(10, rec.Perimeter(), "Should be 10 incorrect perimeter");

            //Testing the perimeter of circle
            Shapes circle = new Shapes();
            Assert.AreEqual(Math.PI * 2, circle.Perimeter(), "Wrong perimter being returned");

            //Testing the perimeter of triangle all valid
            Shapes tri = new Shapes(3, 5, 4, 2);
            Assert.AreEqual(12, tri.Perimeter(), "Improper perimeter");

            //Testing the perimeter of triangle invalid
            Shapes tri1 = new Shapes(3, 5, 20, 2);
            Assert.AreEqual(-1, tri1.Perimeter(), "Improper perimeter");

        }

        [TestMethod]
        public void testVolume()
        {
            Shapes sq = new Shapes(3, 1);
            //Testing the volume
            Assert.AreEqual(27, sq.Volume(), "Improper volume");

            //Testing the volume of rectangular cube
            Shapes rec = new Shapes(3, 4, 2, 1);
            Assert.AreEqual(24, rec.Volume(), "Improper volume");

            //Testing volume of sphere
            Shapes sphere = new Shapes(2, 0);
            Assert.AreEqual(33.51, sphere.Volume(), 0.01, "Improper volume");

        }   //There is a typo in the documentation
    }
}
