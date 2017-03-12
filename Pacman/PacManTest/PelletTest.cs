using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;

namespace PacManTest
{
    /// <summary>
    /// This test class is to demonstrate you ae able to create
    /// Pellet objects and read the points a Pellet object is 
    /// worth. The Collide method is being tested elsewhere, it
    /// is being tested in the PacmanTest cases aswell as in the
    /// TileTest cases.
    /// </summary>
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
