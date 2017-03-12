using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;
using Microsoft.Xna.Framework;
using System.Timers;

namespace PacManTest
{
    [TestClass]
    public class GhostTest
    {
        [TestMethod]
        public void TestPropColour()
        {
            Ghost ghost = new Ghost(GetGameState(), new Vector2(10, 10), new Vector2(15, 15),
                GhostState.Chase, new Color(255, 0, 0));

            Assert.AreEqual(ghost.Colour.R, 255);
        }

        [TestMethod]
        public void TestPropCurrentState()
        {
            Ghost ghost = new Ghost(GetGameState(), new Vector2(10, 10), new Vector2(15, 15),
                GhostState.Scared, new Color(255, 0, 0));

            Assert.AreEqual(ghost.CurrenState, GhostState.Scared);
        }

        [TestMethod]
        public void TestPropDirection()
        {
            Ghost ghost = new Ghost(GetGameState(), new Vector2(10, 10), new Vector2(15, 15),
                GhostState.Scared, new Color(255, 0, 0));

            ghost.Direction = Direction.Up;
            Assert.AreEqual(ghost.Direction, Direction.Up);
        }

        [TestMethod]
        public void TestPropPoint()
        {
            Ghost ghost = new Ghost(GetGameState(), new Vector2(10, 10), new Vector2(15, 15),
                GhostState.Scared, new Color(255, 0, 0));

            Assert.AreEqual(ghost.Points, 300);
        }

        [TestMethod]
        public void TestPropPosition()
        {
            GameState game = GetGameState();
            Ghost ghost = new Ghost(game, new Vector2(11, 10), new Vector2(15, 15),
                GhostState.Scared, new Color(255, 0, 0));

            

            Console.WriteLine(game.Maze[5,5].Member());



            Assert.AreEqual(ghost.Position, new Vector2(11, 10));
        }

        [TestMethod]
        public void TestMoveToPen()
        {
            Ghost ghost = new Ghost(GetGameState(), new Vector2(10, 10), new Vector2(15, 15),
                GhostState.Scared, new Color(255, 0, 0));

            ghost.Reset();
            Assert.AreNotEqual(ghost.Position.X + ghost.Position.Y, 30);
        }

        [TestMethod]
        public void TestChangeState()
        {
            Ghost ghost = new Ghost(GetGameState(), new Vector2(10, 10), new Vector2(15, 15),
                GhostState.Scared, new Color(255, 0, 0));

            ghost.ChangeState(GhostState.Chase);
            Console.WriteLine(ghost.CurrenState + "<=== | ===> " +  GhostState.Chase);
            Assert.AreEqual(ghost.CurrenState, GhostState.Chase);
        }

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
