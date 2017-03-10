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
            GameState.Parse();
            w.IsEmpty();

            //Console.WriteLine(" " + w.Position);
           
          
        }
    }
}
