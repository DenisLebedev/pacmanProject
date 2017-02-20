using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    class GameState
    {
        private static GameState Parse;
  
        public Pacman Pacman
        {
            set;
            private get;
        }
        public GhostPack ghostPack
        {
            private set;
            get;
        }
        public Maze Maze
        {
            private set;
            get;
        }
        public Pen Pen
        {
            private set;
            get;
        }
        public ScoreAndLives Score
        {
            private set;
            get;
        }
    }
}
