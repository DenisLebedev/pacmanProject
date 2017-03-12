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
        /// class will throw an exception because the pacman cannot
        /// </summary>
        [TestMethod]
        public void PacmanMove2Test()
        {
            GameState game = GetGameState();
            game.Pacman.Move(Direction.Up);
            Console.WriteLine(game.Pacman.Position + "\t" + game.Maze[16,11].ToString());

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
