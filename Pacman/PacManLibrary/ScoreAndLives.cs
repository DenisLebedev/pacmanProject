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
        }
        public event Game GameOver;
        public delegate void Game(int x);
        
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
        private void incrementScore(ICollidable colide)
        {
            
        }

        }
}
