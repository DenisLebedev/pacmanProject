using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    public delegate bool Game();
    public class ScoreAndLives
    {
        private GameState gameState;

        public ScoreAndLives (GameState state)
        {
            gameState = state;
            Lives = 3;
            Score = 0;

            //subscribing to event of pacmanwon if there are no more
            //ICollidable objects (pellets or energizers) on the maze
            gameState.Maze.PacmanWon += GameWon;  
        }
      
        public event Game GameOver;

        public int Lives
        {
            set;
            get;
        }
        public int Score
        {
            set;
            get;
        }
        public void DeadPacman()
        {
            Lives -= 1;
            gameState.GhostPack.ResetGhosts();
            if (Lives < 1)
            {
                Lives = 0;
                if (GameOver != null) GameOver(); 
            }
        }
        public void IncrementScore(ICollidable colide)
        {
            Score += colide.Points;
        }
        public bool GameWon()
        {
            
            return true;
        }
    }
}
