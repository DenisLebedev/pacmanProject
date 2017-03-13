using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;
using Microsoft.Xna.Framework;

namespace PacManTest
{
    /// <summary>
    /// Most of all events are tested in PacmanTest.cs. 
    /// This class purpose is to test what is left. 
    /// We gonna test our properties and the only events
    /// left.
    /// </summary>
    [TestClass]
    public class ScoreAndLivesTest
    {

        /// <summary>
        /// The method will test if our property Life is working
        /// </summary>
        [TestMethod]
        public void TestLifeProp()
        {
            GameState game1 = GetGameState();


            game1.Score.Lives -= 1;
            game1.Pacman.Position = new Vector2(1, 1);

            Assert.AreEqual(game1.Score.Lives, 2);
        }

        /// <summary>
        /// The method will trigger and action and the points should be incremented
        /// </summary>
        [TestMethod]
        public void TestPointsProp()
        {
            GameState game1 = GetGameState();

            game1.Pacman.Move(Direction.Right);

            Assert.AreEqual(game1.Score.Score, 100);
        }

        [TestMethod]
        public void TestRemoveLive()
        { 
            GameState g = MyGameState();
            Ghost ghost = new Ghost(g, new Vector2(4, 1), new Vector2(4, 1),
                GhostState.Chase, new Color(255, 0, 0));
            ghost.Collision += g.Score.IncrementScore;
            ghost.DeadPacman += g.Score.DeadPacman;
            ghost.Collide();          
 
            Assert.AreEqual(g.Score.Lives, 2);
            
        }

        /// <summary>
        /// The method will test if the current pacman will loose all his health
        /// because we did not finishing to implement the game we cannot restart
        /// the entire game/maze. The method will only print a message that you can see
        /// from the ouput of this method. The implementation will be done in the second phase.
        /// When our health is at 0 we should trigger an event in our game to let it know,
        /// but we are implementing that in the second phase. So a message is enough for now.
        /// </summary>
        [TestMethod]
        public void TestGameOver()
        {
            GameState g = MyGameState();
            Ghost ghost = new Ghost(g, new Vector2(4, 1), new Vector2(4, 1),
                GhostState.Chase, new Color(255, 0, 0));
            ghost.Collision += g.Score.IncrementScore;
            ghost.DeadPacman += g.Score.DeadPacman;
            ghost.Collide();
            ghost.Collide();
            ghost.Collide();
            Assert.AreEqual(g.Score.Lives, 0);


        }

        /// <summary>
        /// When pacman won a message is printed, but a new way
        /// gonna be handled when we gonna do the second phase.
        /// </summary>
        [TestMethod]
        public void TestPacmanWon()
        {
            GameState g = EmptyGame();
            g.Maze.CheckMembersLeft();
        }

        private GameState EmptyGame()
        {
            return GameState.Parse
(@"w P m w
w x m w
w m m w
w m m w");
        }


        private GameState MyGameState()
        {
            return GameState.Parse
(@"w w w w w w
w p p p p w
w p p p p w
w e 1 p p w
w P p p p w
w w w w w w");
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
