using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;
using Microsoft.Xna.Framework;

namespace PacManTest
{
    [TestClass]
    public class EnergizerTest
    {
        /// <summary>
        /// This first test is to see if it is possible to create
        /// an Energizer object. I use the tostring method in order
        /// to compare the object types.
        /// </summary>
        [TestMethod]
        public void CreatingEnergizer()
        {
            GhostPack gp = new GhostPack();
            Energizer e = new Energizer(gp); 
            Assert.AreEqual(e.ToString(), new Energizer(new GhostPack()).ToString());
        }
        /// <summary>
        /// This method will test the Points proprety to check
        /// if we are allowed to read from it (get).
        /// </summary>
        [TestMethod]
        public void EnerGizerPointsPropReadTest()
        {
            GhostPack gp = new GhostPack();
            Energizer e = new Energizer(gp);
            Assert.AreEqual(e.Points, 500);
        }
        /// <summary>
        /// This is a helper method in order to create a GameState
        /// object for use within this test class.
        /// </summary>
        /// <returns></returns>
        private GameState GetGameState()
        {
            return GameState.Parse
(@"w w w w w w w w w w w w w w w w w w w w w w w
w p p p p p p p p p p w p p p p p p p p p p w
w p w w w p w w w w p w p w w w w p w w w p w
w e w w w p w w w w p w p w w w w p w w w e w
w p p p p p p p p p p p p p p p p p p p p p w
w p w w w p w p w w w w w w w p w p w w w p w
w p p p p p w p p p p w p p p p w p p p p p w
w w w w w p w w w w m w m w w w w p w w w w w
w p p p p p w m m m m 1 m m m m w p p p p p w
w p w w w p w m w w w w w w w m w p w w w p w
w p w w w p w m w x 2 3 4 x w m w p w w w p w
w p w w w p m m w x x x x x w m m p w w w p w
w p w w w p w m w w w w w w w m w p w w w p w
w p p p p p w m m m m m m m m m w p p p p p w
w w w w w p w m w w w w w w w m w p w w w w w
w p p p p p p p p p p w p p p p p p p p p p w
w p w w w p w w w w p w p w w w w p w w w p w
w e p p w p p p p p p P p p p p p p w p p e w
w w w p w p w p w w w w w w w p w p w p w w w
w p p p p p w p p p p w p p p p w p p p p p w
w p w w w w w w w w p w p w w w w w w w w p w
w p p p p p p p p p p p p p p p p p p p p p w
w w w w w w w w w w w w w w w w w w w w w w w");
        }
    }
}
