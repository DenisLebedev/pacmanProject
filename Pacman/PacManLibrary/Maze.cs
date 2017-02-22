using Microsoft.Xna.Framework;
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
        public void SetTiles (Tile[,] tiles)
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
        public List<Tile> GetAvailableNeighbours(Vector2 position, Direction dir)
        {
            List<Tile> available_tiles = new List<Tile>();

            switch (dir)
            {
                case Direction.Down:
                    /*if (maze[(int)(position.Y + 1), position.X] != maze[1, 1])
                    {
                        available_tiles.Add(maze[1, 1]);
                    }*/
                    break;
                case Direction.Up:
                    /* if (maze[(int)(position.Y + 1), position.X] != maze[1, 1])
                     {
                         available_tiles.Add(maze[1, 1]);
                     }*/
                    break;
                case Direction.Left:
                    /* if (maze[(int)(position.Y + 1), position.X] != maze[1, 1])
                     {
                         available_tiles.Add(maze[1, 1]);
                     } */
                    break;
                case Direction.Right:
                    /* if (maze[(int)(position.Y + 1), position.X] != maze[1, 1])
                     {
                         available_tiles.Add(maze[1, 1]);
                     } */
                    break;

            }
            return available_tiles;
        }

        public void CheckMembersLeft()
        {
            bool chk = true;
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(0); j++)
                {
                    if (maze[i,j] != null)
                    {
                        chk = false;
                    }
                }
            }
            if (chk)
            {
                //PacmanWon
                
            }

           
        }
        
    }
}
