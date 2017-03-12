using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;
using Microsoft.Xna.Framework;

namespace PacManTest
{
    [TestClass]
    public class PacmanTest
    {
        /// <summary>
        /// This test case is tasked to test the move method, here pacman 
        /// will use its starting position [17,11] given to him by the csv file
        /// and will be moved right, the expected position will be [17,12] and a 
        /// new vector2 with that postion will be used to compare pacmans 
        /// position with.
        /// </summary>
        [TestMethod]
        public void PacmanMove1Test()
        {
            GameState game = GetGameState();
            game.Pacman.Move(Direction.Right);

            Assert.AreEqual(game.Pacman.Position, new Vector2(17,12));
        }
        /// <summary>
        /// This test case will truy to move the pacman up, however since
        /// the tile above pacmans starting position [17,11] is a wall, the Wall
        /// class will not allow the pacman to move so he's position will not change
        /// </summary>
        [TestMethod]
        public void PacmanMove2Test()
        {
            GameState game = GetGameState();
            game.Pacman.Move(Direction.Up);

            Assert.AreEqual(game.Pacman.Position, new Vector2(17, 11));
        }
        /// <summary>
        /// This test case will test if the score in ScoreLives
        /// class is incremnted when pacman moves ontop of a pellet, the
        /// expected result is the scoe will be 100.
        /// </summary>
        [TestMethod]
        public void CheckCollisionTest()
        {
            GameState game = GetGameState();
            game.Pacman.Move(Direction.Right);

            Console.WriteLine(game.Score.Score);

            Assert.AreEqual(game.Score.Score, 100);
        }
        /// <summary>
        /// This test case will move pacman twice right and once left
        /// in order to verify if when he collides with a pellet they are
        /// removed and no loner fire an event to increment the score.
        /// The expected result is 200 since he moved over only two pellets.
        /// </summary>
        [TestMethod]
        public void CheckCollision2Test()
        {
            GameState game = GetGameState();
            //move R,R,L,R
            game.Pacman.Move(Direction.Right);
            game.Pacman.Move(Direction.Right);
            game.Pacman.Move(Direction.Left);
            game.Pacman.Move(Direction.Right);

            Assert.AreEqual(game.Score.Score, 200);
        }
        /// <summary>
        /// Here we will test when pacman moves over an energizer
        /// if the the Collide method is called depending the type of 
        /// the object. To get the expected result the score will be incremented.
        /// </summary>
        [TestMethod]
        public void CheckCollision3Test()
        {
            GameState game = GetGameState();
            game.Pacman.Position = new Vector2(2,1);

            game.Pacman.Move(Direction.Down);


            Assert.AreEqual(game.Score.Score, 500);
        }
        /// <summary>
        /// In this test case we will test if pacman eats an energizer and then is
        /// able to eat a ghost. To test this if the score is 800 at the end it worked 
        /// beacause all the events were trigered properly to increase the score in scorelives
        /// an energizer is worth 500 and a ghost is worth 300.
        /// </summary>
        [TestMethod]
        public void CheckCollision4Test()
        {
            GameState game = GetGameState();
            game.Pacman.Position = new Vector2(2, 1);

            game.Pacman.Move(Direction.Down);

            game.Pacman.Position = new Vector2(9, 11);
            game.GhostPack.CheckCollideGhosts(new Vector2(9, 11));

            Console.WriteLine(game.Score.Score);


            Assert.AreEqual(game.Score.Score, 800);
        }
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
