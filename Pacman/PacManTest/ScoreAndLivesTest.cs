using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacManLibrary;
using Microsoft.Xna.Framework;

namespace PacManTest
{
    [TestClass]
    public class ScoreAndLivesTest
    {

        [TestMethod]
        public void TestScoreProp()
        {
            GameState game1 = GetGameState();


            game1.Score.Lives -= 1;
            game1.Pacman.Position = new Vector2(1, 1);

            Console.WriteLine(game1.GhostPack);


            //Console.WriteLine(game1.Score.Lives);

            Assert.AreEqual(game1.Score.Lives, 2);
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

        [TestMethod]
        public void TestEnergizerAndGhostEating()
        {
            GameState g = MyGameState();
            Ghost ghost = new Ghost(g, new Vector2(3, 2), new Vector2(4, 1),
                GhostState.Chase, new Color(255, 0, 0));
            ghost.Collision += g.Score.IncrementScore;
            ghost.DeadPacman += g.Score.DeadPacman;
            try
            {
                g.Pacman.Move(Direction.Up);
                //g.Pacman.Move(Direction.Left);
                Console.WriteLine(g.Pacman.Position);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Assert.AreEqual(g.Score.Lives, 2);

        }


        private GameState MyGameState()
        {
            return GameState.Parse
(@"w w w w w w
w p p p p w
w p 1 p p w
w E p p p w
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
