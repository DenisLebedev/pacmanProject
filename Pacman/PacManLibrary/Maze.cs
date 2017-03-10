using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    public delegate bool Won();
    
    public class Maze
    {
        public event Won PacmanWon;
        private Tile[,] maze;

        public void SetTiles (Tile[,] tiles)
        {
            this.maze = tiles;
        }

        public Tile this[int y,int x]
        {
            get
            {
                if (x < 0 || y < 0 || Size < y || Size < x)
                {
                    throw new IndexOutOfRangeException("index out of bounds");
                }
                return this.maze[y, x];
            }
            set
            {
                if (x < 0 || y < 0 || Size < y || Size < x)
                {
                    throw new IndexOutOfRangeException("index out of bounds");
                }
                this[y, x] = value;
            }
        }
        public int Size
        {
            get{ return maze.GetLength(0); }
        }
        public List<Tile> GetAvailableNeighbours(Vector2 position, Direction dir)
        {
            List<Tile> available_tiles = new List<Tile>();
            int x = (int)position.X;
            int y = (int)position.Y;

            switch (dir)
            {
                case Direction.Down:
                    if (maze[x, y-1].IsEmpty())
                    {available_tiles.Add(maze[x, y-1]);}//up

                    if (maze[x-1, y].IsEmpty())
                    { available_tiles.Add(maze[x-1, y]); }//left

                    if (maze[x+1, y].IsEmpty())
                    { available_tiles.Add(maze[x+1, y]); }//right
                    break;
                case Direction.Up:
                    if (maze[x, y + 1].IsEmpty())
                    { available_tiles.Add(maze[x, y +1]); }//down

                    if (maze[x - 1, y].IsEmpty())
                    { available_tiles.Add(maze[x - 1, y]); }//left

                    if (maze[x + 1, y].IsEmpty())
                    { available_tiles.Add(maze[x+1, y]); }//right
                    break;
                case Direction.Left:
                    if (maze[x, y + 1].IsEmpty())
                    { available_tiles.Add(maze[x, y + 1]); }//down

                    if (maze[x, y-1].IsEmpty())
                    { available_tiles.Add(maze[x, y-1]); }//up

                    if (maze[x + 1, y].IsEmpty())
                    { available_tiles.Add(maze[x + 1, y]); }//right
                    break;
                case Direction.Right:
                    if (maze[x, y + 1].IsEmpty())
                    { available_tiles.Add(maze[x, y + 1]); }//down

                    if (maze[x - 1, y].IsEmpty())
                    { available_tiles.Add(maze[x - 1, y]); }//left

                    if (maze[x, y - 1].IsEmpty())
                    { available_tiles.Add(maze[x, y - 1]); }//up
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
                   if (!(maze[i,j].IsEmpty()))
                    {
                        chk = false;
                        break;
                    }
                }
                if (!chk) { break;}
            }//end of for loop
            if (chk)
            {
                PacmanWon?.Invoke();
            }

           
        }
        
    }
}
