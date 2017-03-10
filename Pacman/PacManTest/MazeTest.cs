using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;

namespace PacManTest
{
    [TestClass]
    public class MazeTest
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestMethod1()
        {
            Maze maze = new Maze();

            Tile w = new Wall(0,0);
            w.IsEmpty();

            //Console.WriteLine(" " + w.Position);
           
          
        }
    }
}
