using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    class ScoreAndLives
    {
        private GameState gameState;
        public ScoreAndLives (GameState state)
        {
            gameState = state;
            gameState.Board.Collision += 

            gameState.Maze.PacmanWon += GameWon;
        }
        public delegate void Game(int x);
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
        private void deadPacman()
        {
            if (GameOver != null)
            {
                GameOver(Lives - 1); 
            }
        }
        public void IncrementScore(ICollidable colide)
        {
            Score += colide.Points;
        }
        public bool GameWon()
        {
            return false;
        }


    }
}
