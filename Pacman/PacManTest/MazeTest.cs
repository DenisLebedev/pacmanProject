using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;

namespace PacManTest
{
    [TestClass]
    public class MazeTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Maze maze = new Maze();

            Tile w = new Wall(0,0);

            Assert.IsTrue(maze[0,0] is Wall);
          
        }
    }
}
