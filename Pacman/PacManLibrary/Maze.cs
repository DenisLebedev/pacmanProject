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
    /// <summary>
    /// The Maze class will be responsible of the logic behind an actual
    /// maze, moreover it will contain a two dimentional array of tiles
    /// and will contain an indexr. Also it will contain a getAvailableNieghbours
    /// method that returns available a list of possible paths to enter.
    /// </summary>
    public class Maze
    {
        public event Won PacmanWon;
        private Tile[,] maze;

        /// <summary>
        /// The setTiles method will assing the private variable maze
        /// to the contain the state of the game. Moreover, this method will
        /// be assing in order for it to contain the objects from the csv file
        /// </summary>
        /// <param name="tiles"></param>
        public void SetTiles (Tile[,] tiles)
        {
            this.maze = tiles;
        }
        /// <summary>
        /// The inder will take ina normal index for an array but
        /// it will flip the variables when assigning them in order
        /// for the two dimentional array not to be fliped and instead
        /// of an array of [x,y] it will be an array of [y,x] in other words
        /// an array of [rows, columns].
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Tile this[int y,int x]
        {
            get
            {
                if (x < 0 || y < 0 || y >= Size || x >= Size)
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
        /// <summary>
        /// The get available neighbours method will be reponsible for returning
        /// a list of potential paths to enter. It uses the position given to it
        /// as well the direction it is going to inorder to determain the available
        /// neighbours.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public List<Tile> GetAvailableNeighbours(Vector2 position, Direction dir)
        {
            List<Tile> available_tiles = new List<Tile>();
            int x = (int)position.X;
            int y = (int)position.Y;

            switch (dir)
            {
                case Direction.Down:

                    if (maze[x, y + 1] is Path)
                    { available_tiles.Add(maze[x, y + 1]); }//down

                    if (maze[x-1, y] is Path)
                    { available_tiles.Add(maze[x-1, y]); }//left

                    if (maze[x+1, y] is Path)
                    { available_tiles.Add(maze[x+1, y]); }//right
                    break;
                case Direction.Up:

                    if (maze[x, y - 1] is Path)
                    { available_tiles.Add(maze[x, y - 1]); }//up

                    if (maze[x - 1, y] is Path)
                    { available_tiles.Add(maze[x - 1, y]); }//left

                    if (maze[x + 1, y] is Path)
                    { available_tiles.Add(maze[x+1, y]); }//right
                    break;
                case Direction.Left:
                    if (maze[x, y + 1] is Path)
                    { available_tiles.Add(maze[x, y + 1]); }//down

                    if (maze[x, y-1] is Path)
                    { available_tiles.Add(maze[x, y-1]); }//up

                    if (maze[x - 1, y] is Path)
                    { available_tiles.Add(maze[x - 1, y]); }//left
                    break;
                case Direction.Right:
                    if (maze[x, y + 1] is Path)
                    { available_tiles.Add(maze[x, y + 1]); }//down

                    if (maze[x + 1, y] is Path)
                    { available_tiles.Add(maze[x + 1, y]); }//right

                    if (maze[x, y - 1] is Path)
                    { available_tiles.Add(maze[x, y - 1]); }//up
                    break;

            }
            return available_tiles;
        }
        /// <summary>
        /// This method is tasked to go through all the tiles in the
        /// maze two dimential array and check if there are nopellets
        /// and energizers left on the field, if so it will fire the
        /// PacmanWon event.
        /// </summary>
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
