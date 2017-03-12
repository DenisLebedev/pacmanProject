using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace PacManTest
{
    [TestClass]
    public class MazeTest
    {
        /// <summary>
        /// this test case will try to create a maze object
        /// </summary>
        [TestMethod]
        public void CreatMazeObjectTest()
        {
            GameState game = GetGameState();
            
            Assert.AreEqual(game.Maze.Size, 23);
        }
        /// <summary>
        /// this test case will check to see if the Tile[,] in the 
        /// maze class is working properly. in order to test we will give it 
        /// the index of where a pellet should be and compare the type with another
        /// new pellet object
        /// </summary>
        [TestMethod]
        public void Indexer1Test()
        {
            GameState game = GetGameState();
            Pellet pellet = new Pellet();

            Assert.AreEqual(game.Maze[17,12].Member().GetType(), pellet.GetType());
        }
        /// <summary>
        /// this test case will test if the user inputs a index that out of the 
        /// range of the maze, the expected result will be an IndexOutOfRangeException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Indexer2Test()
        {
            GameState game = GetGameState();
            var a = game.Maze[23, 0];
        }
        /// <summary>
        /// In this test case in order to test the GetAvailableNeighbours method the index
        /// used for testing is [15,11] and the direction going down, the expected result will
        /// be two paths in theList returned [15,2] and [16,1] in other words the tiles that 
        /// are to the right and down of the current point.
        /// </summary>
        [TestMethod]
        public void GetAvailableNeighboursTest()
        {
            GameState game = GetGameState();
            List<Tile> available_tiles = new List<Tile>();

            available_tiles = game.Maze.GetAvailableNeighbours(new Vector2(15,1), Direction.Down);

            Tile[] available_paths = available_tiles.ToArray();
            //in order to verify the points returned i printed them onto the output.
            for (int i = 0; i < available_paths.Length; i++)
            {
                Console.WriteLine(available_paths[i].Position);
            }
            Assert.AreEqual(available_paths.Length, 2);

        }
        /// <summary>
        /// This test case will test if the Size proprety returns the
        /// correct size of the maze.The expected result is 23.
        /// </summary>
        [TestMethod]
        public void SizeTest()
        {
            GameState game = GetGameState();
            Assert.AreEqual(game.Maze.Size, 23);
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
