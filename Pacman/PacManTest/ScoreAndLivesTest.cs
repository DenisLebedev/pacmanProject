using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PacManTest
{
    [TestClass]
    public class ScoreAndLivesTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void TestScoreProp()
        {
            GameState game1 = GetGameState();


            game1.Score.Lives -= 1;
            game1.Pacman.Position = new Vector2(1, 1);

            Console.WriteLine(game1.GhostPack);


            //Console.WriteLine(game1.Score.Lives);

            Assert.AreEqual(game1.Score.Lives, 2);
        }
    }
}
