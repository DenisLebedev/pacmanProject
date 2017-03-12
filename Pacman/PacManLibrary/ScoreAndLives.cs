using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    public delegate void Game();
    public class ScoreAndLives
    {
        private GameState gameState;
        private int lives;
        private int score;
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
            set { lives = value; }
            get { return this.lives; }
        }
        public int Score
        {
            set { score = value; }
            get { return score; }
        }
        public void DeadPacman()
        {
            Lives -= 1;
            if (Lives == 0)
            {
                //GameOver?.Invoke();  
                Console.WriteLine("GAME OVER!!!"); 
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
