using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;
using Microsoft.Xna.Framework;

namespace PacManTest
{
    [TestClass]
    public class GameStateTest
    {
        /// <summary>
        /// In order to test if the static method Parse was
        /// able to properly place all the objects in the correct place
        /// when reading from the file I tested if pacman was placed in the
        /// correct spot on the board by creating a new pacman object giving
        /// it the position in which the GameStates' pacman is ment to be
        /// </summary>
        [TestMethod]
        public void TestGameStateParse_PacmanPosition()
        {
            GameState game1 = GetGameState();
            Pacman pacman = new Pacman(game1); //17, 11
            pacman.Position = new Vector2(11, 17);

            Assert.AreEqual(game1.Pacman.Position, pacman.Position);
        }
        /// <summary>
        /// Similarly like the test above I test if particuallar point
        /// on the board holds a pellet object.
        /// </summary>
        [TestMethod]
        public void TestGameStateParse_PelletPosition()
        {
            GameState game1 = GetGameState();
            Pellet pellet = new Pellet();
            Tile path = new Path(1, 1, pellet);


            Assert.AreEqual(game1.Maze[1, 1].Member().ToString(), path.Member().ToString());
        }
        /// <summary>
        /// This method will see if the parse method placed a wall object
        /// in the correct place, using a point that is not on the borders.
        /// </summary>
        [TestMethod]
        public void TestGameStateParse_WallPosition()
        {
            GameState game1 = GetGameState();
            Tile path = new Wall(3, 3);

            Assert.AreEqual(game1.Maze[3, 3].ToString(), path.ToString());
        }
        /// <summary>
        /// This method will tes if the 
        /// </summary>
        [TestMethod]
        public void TestGameStateParse_EnergizerPosition()
        {
            GameState game1 = GetGameState();
            GhostPack ghosts = new GhostPack();
            Energizer energizer = new Energizer(ghosts);
            Tile path = new Path(1, 3, energizer);        

            Assert.AreEqual(game1.Maze[1, 3].Member().ToString(), path.Member().ToString());
        }
        /// <summary>
        /// This test method is reponsible for testing 
        /// the Pacman prop in GameState. In order to test it
        /// the position of pacman is set through the GameState
        /// using the prop and it will be compared to a vector with 
        /// the same position.
        /// </summary>
        [TestMethod]
        public void TestPacManProp()
        {
            GameState game1 = GetGameState();
            game1.Pacman.Position = new Vector2(1, 1);

            Assert.AreEqual(game1.Pacman.Position, new Vector2(1, 1));
        }
        [TestMethod]
        public void TestMazeProp()
        {
            GameState game1 = GetGameState();
            game1.Maze[1, 1].Member().ToString();

            Console.WriteLine(game1.Maze[1, 1].Member().ToString());

            Assert.AreEqual(game1.Maze[1, 1].Member().ToString(), new Pellet().ToString());
        }

        [TestMethod]
        public void TestPenProp()
        {
            GameState game1 = GetGameState();

            Assert.AreEqual(game1.Pen.ToString(), new Pen().ToString());
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
