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
            Ghost ghost = new Ghost(g, new Vector2(4, 4), new Vector2(2, 3),
                GhostState.Chase, new Color(255, 0, 0));
            try
            {

                Console.WriteLine(g.Maze[0,0]);
                Console.WriteLine(g.Maze[0,1]);
                /*Console.WriteLine("Pacman posx: " + g.Pacman.Position.X + " Pacman posy: " + g.Pacman.Position.Y);

                for(int i =0; i < 20; i++)
                {
                    Console.WriteLine("X: " + ghost.Position.X + " Y:" + ghost.Position.Y);
                    ghost.Move();
                }

                /*ghost.Move();
                Console.WriteLine("X: " + ghost.Position.X + " Y:" + ghost.Position.Y);
                ghost.Move();
                Console.WriteLine("X: " + ghost.Position.X + " Y:" + ghost.Position.Y);
                ghost.Move();
                Console.WriteLine("X: " + ghost.Position.X + " Y:" + ghost.Position.Y);
                ghost.Move();
                Console.WriteLine("X: " + ghost.Position.X + " Y:" + ghost.Position.Y);
                ghost.Move();
                Console.WriteLine("X: " + ghost.Position.X + " Y:" + ghost.Position.Y);
                ghost.Move();
                Console.WriteLine("X: " + ghost.Position.X + " Y:" + ghost.Position.Y);
                ghost.Move();
                Console.WriteLine("X: " + ghost.Position.X + " Y:" + ghost.Position.Y*/
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Assert.AreNotEqual(ghost.Position, new Vector2(15, 15));
        }


        private GameState MyGameState()
        {//2 3
            return GameState.Parse
(@"w w w w w w
w w p 1 p w
w p p p p w
w p p P p w
w p p p p w
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
