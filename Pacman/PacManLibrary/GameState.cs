using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    class GameState
    {
       public GameState()
        {

        }
        public static GameState parse (string fale)
        {
            return null;
        }
  
        public Pacman Pacman
        {
            get;
            private set;
        }
        public GhostPack ghostPack
        {
            private set;
            get;
        }
        public Maze Maze
        {
            private set { }
            get { return Maze;}
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
