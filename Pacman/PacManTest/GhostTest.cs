using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;
using Microsoft.Xna.Framework;

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
            Ghost ghost = new Ghost(GetGameState(), new Vector2(10, 10), new Vector2(15, 15),
                GhostState.Scared, new Color(255, 0, 0));

            Assert.AreEqual(ghost.Position.X + ghost.Position.Y, 30);
        }

        [TestMethod]
        public void TestMoveToPen()
        {
            Ghost ghost = new Ghost(GetGameState(), new Vector2(10, 10), new Vector2(15, 15),
                GhostState.Scared, new Color(255, 0, 0));

            ghost.Reset();
            Assert.AreEqual(ghost.Position.X + ghost.Position.Y, 30);
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
