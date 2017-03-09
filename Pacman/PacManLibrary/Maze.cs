using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    public delegate bool won();
    
    public class Maze
    {
        public event won PacmanWon;
        private Tile[,] maze;

        public Maze() {
            maze = new Tile[23,26];
            setArray();
        }
        private void setArray()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                if (i == 0 || i == maze.GetLength(0) - 1)
                { 
                    for (int j = 0; j < maze.GetLength(1); j++)
                    {
                        maze[i, j] = new Wall(i, j);
                    }
                }//end of if              
            }
            for (int i = 1; i < 2; i++)
            {
                if (i == 1) { i = maze.GetLength(1) - 1; }
                for (int j = 0; j < maze.GetLength(0) - 1; j++)
                {
                    maze[i, j] = new Wall(i, j);
                }
            }
        }
       

        public void SetTiles (Tile[,] tiles)
        {
            this.maze = tiles;
        }

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
            string positionx = ""+ position.X;
            int x = Int32.Parse(positionx);
            string positiony = "" + position.Y;
            int y = Int32.Parse(positiony);
            switch (dir)
            {
                case Direction.Down:
                    if (!(maze[x, y+1].Member() is Wall))
                    {
                        available_tiles.Add(maze[1, 1]);
                    }
                    break;
                case Direction.Up:
                     if (maze[x, y - 1].Member() is Wall )
                     {
                         available_tiles.Add(maze[1, 1]);
                     }
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
                    // i dont know what the indexes are ment to have
                    if (maze[i,j] )
                    {
                        chk = false;
                    }
                }
            }
            if (chk)
            {
                PacmanWon?.Invoke();
            }

           
        }
        
    }
}
