using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;

namespace PacManTest
{
    [TestClass]
    public class PelletTesting
    {
        /// <summary>
        /// Testing the pellet class if it creates it properly by assigning
        /// the points in the constructer.
        /// </summary>
        [TestMethod]
        public void tesPelletConstructer()
        {
            Pellet pellet = new Pellet();

            Assert.AreEqual(pellet.Points, 100);

        }
    }
}
