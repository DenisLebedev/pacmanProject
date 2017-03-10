using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;

namespace PacManTest
{
    [TestClass]
    public class PelletTesting
    {
        [TestMethod]
        public void testPelletCollide()
        {
            Pellet pellet = new Pellet();
            pellet.Collide();
        }
        [TestMethod]
        public void tesPelletConstructer()
        {
            Pellet pellet = new Pellet();

            Assert.AreEqual(pellet.Points, 100);

        }
        [TestMethod]
        public void TestCollidPellet()
        {
            

           // Pellet pellet = new Pellet();
           // pellet.Collide();
           
        }
    }
}
