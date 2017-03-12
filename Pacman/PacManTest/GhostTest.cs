using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;
using Microsoft.Xna.Framework;
using System.Timers;

namespace PacManTest
{
    /// <summary>
    /// The class will test all the methods of a ghost in 
    /// Scare and Chase mode either. All the events are tested
    /// somwhere else like Pacman.
    /// </summary>
    [TestClass]
    public class GhostTest
    {
        /// <summary>
        /// The method will test if our property Colour is working
        /// </summary>
        [TestMethod]
        public void TestPropColour()
        {
            Ghost ghost = new Ghost(GetGameState(), new Vector2(10, 10), new Vector2(15, 15),
                GhostState.Chase, new Color(255, 0, 0));

            Assert.AreEqual(ghost.Colour.R, 255);
        }

        /// <summary>
        /// The method will test if our property current state is working
        /// </summary>
        [TestMethod]
        public void TestPropCurrentState()
        {
            Ghost ghost = new Ghost(GetGameState(), new Vector2(10, 10), new Vector2(15, 15),
                GhostState.Scared, new Color(255, 0, 0));

            Assert.AreEqual(ghost.CurrenState, GhostState.Scared);
        }

        /// <summary>
        /// The method will test if our property Direction is working
        /// </summary>
        [TestMethod]
        public void TestPropDirection()
        {
            Ghost ghost = new Ghost(GetGameState(), new Vector2(10, 10), new Vector2(15, 15),
                GhostState.Scared, new Color(255, 0, 0));

            ghost.Direction = Direction.Up;
            Assert.AreEqual(ghost.Direction, Direction.Up);
        }

        /// <summary>
        /// The method will test if our property Point is working
        /// </summary>
        [TestMethod]
        public void TestPropPoint()
        {
            Ghost ghost = new Ghost(GetGameState(), new Vector2(10, 10), new Vector2(15, 15),
                GhostState.Scared, new Color(255, 0, 0));

            Assert.AreEqual(ghost.Points, 300);
        }

        /// <summary>
        /// The method will test if our property Position is working
        /// </summary>
        [TestMethod]
        public void TestPropPosition()
        {
            GameState game = GetGameState();
            Ghost ghost = new Ghost(game, new Vector2(11, 10), new Vector2(15, 15),
                GhostState.Scared, new Color(255, 0, 0));
         
            Assert.AreEqual(ghost.Position, new Vector2(11, 10));
        }


        /// <summary>
        /// The method will test if our ghost actually go to our pen
        /// </summary>
        [TestMethod]
        public void TestMoveToPen()
        {
            Ghost ghost = new Ghost(GetGameState(), new Vector2(10, 10), new Vector2(15, 15),
                GhostState.Scared, new Color(255, 0, 0));

            ghost.Reset();
            Assert.AreNotEqual(ghost.Position.X + ghost.Position.Y, 30);
        }

        /// <summary>
        /// The method will test if ChangeState is wroking 
        /// as it should be.
        /// </summary>
        [TestMethod]
        public void TestChangeState()
        {
            Ghost ghost = new Ghost(GetGameState(), new Vector2(10, 10), new Vector2(15, 15),
                GhostState.Scared, new Color(255, 0, 0));

            //Ghost is scared and gonna be Chased now.
            ghost.ChangeState(GhostState.Chase);
            Assert.AreEqual(ghost.CurrenState, GhostState.Chase);
        }

        /// <summary>
        /// The method will test if the Ghost really run 
        /// to our pacmam, but the event it tested somewhere else
        /// </summary>
        [TestMethod]
        public void TestMoveChase()
        {
            GameState g = MyGameState();
            Ghost ghost = new Ghost(g, new Vector2(1, 1), new Vector2(1, 2),
                GhostState.Chase, new Color(255, 0, 0));

            //The target is close to our Ghost so one move is enough
            ghost.Move();
            Assert.AreEqual(ghost.Position, new Vector2(1, 2));
        }

        /// <summary>
        /// The method will test if the Ghost really run 
        /// away but do not chase our pacmam
        /// </summary>
        [TestMethod]
        public void TestMoveScare()
        {
            GameState g = MyGameState();
            g.Pacman.Position = new Vector2(3,2);
            Ghost ghost = new Ghost(g, new Vector2(2, 2), new Vector2(3, 2),
                GhostState.Scared, new Color(255, 0, 0));

            //The target is at the Pacman position so he should not chase him bu run away
            ghost.Move();
            Console.WriteLine(ghost.Position);
            Assert.AreNotEqual(ghost.Position, new Vector2(3, 2));
        }


        private GameState MyGameState()
        {
            return GameState.Parse
(@"w w w w w w
w p p p p w
w p p p p w
w p p p p w
w P 1 p p w
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
