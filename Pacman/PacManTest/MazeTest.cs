using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;
using Microsoft.Xna.Framework;

namespace PacManTest
{
    [TestClass]
    public class MazeTest
    {
        [TestMethod]
        public void TestGameStateParse_PacmanPosition()
        {
            GameState game1 = GetGameState();
            Pacman pacman = new Pacman(game1); //17, 11
            pacman.Position = new Vector2(17, 11);

            Assert.AreEqual(game1.Pacman.Position, pacman.Position);
        }
        [TestMethod]
        public void TestGameStateParse_PelletPosition()
        {
            GameState game1 = GetGameState();
            Pellet pellet = new Pellet();
            Tile path = new Path(1, 1, pellet);


            Assert.AreEqual(game1.Maze[1,1].Member().ToString(), path.Member().ToString());
        }
        [TestMethod]
        //[ExpectedException(typeof(NotImplementedException))]
        public void TestGameStateParse_WallPosition()
        {
            GameState game1 = GetGameState();
            Tile path = new Wall(0, 0);

            Console.WriteLine(" ======> " + game1.Maze[0,0].ToString());

            Assert.AreEqual(game1.Maze[0,0].ToString(), path.ToString());
        }
        [TestMethod]
        //[ExpectedException(typeof(NotImplementedException))]
        public void TestGameStateParse_EnergizerPosition()
        {
            GameState game1 = GetGameState();
            GhostPack ghosts = new GhostPack();
            Energizer energizer = new Energizer(ghosts);
            Tile path = new Path(3, 1, energizer);

            Console.WriteLine(" ======> " + game1.Maze[3, 1].Member().ToString());

            Assert.AreEqual(game1.Maze[3, 1].Member().ToString(), path.Member().ToString());
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
w p w w w p w m w m 2 3 4 m w m w p w w w p w
w p w w w p m m w m m m m m w m m p w w w p w
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
