using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    class Maze
    {
        private Tile[,] maze;

        public Maze()
        {

        }
        public void SetTuiles (Tile[,] tiles)
        {
            this.maze = tiles;
        }
        public delegate bool won();
        public event won PacmanWon;

        public Tile this[int x,int y]
        {
            get
            {
                return this.maze[x, y];
            }
            set
            {
                this[x, y] = value;
            }
        }
        public int Size
        {
            get{ return maze.GetLength(0); }
        }
        
    }
}
