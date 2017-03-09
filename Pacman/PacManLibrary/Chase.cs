using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    class Chase : IGhostState
    {
        private Ghost ghost;
        private Maze maze;
        private Vector2 target;
        private Pacman pacman;

        public  Chase(Ghost ghost, Maze maze, Pacman pacman, Vector2 target)
        {
            this.ghost = ghost;
            this.maze = maze;
            this.target = new Vector2(target.X, target.Y);
            this.pacman = pacman;

        }

        public void Move()
        {

            /*List<Tile> places;
            Tile ghostPos = maze[(int)ghost.Position.X, (int)ghost.Position.Y];
            Tile targetPos = maze[(int)target.X, (int)target.Y];

            if (target.X - ghost.Position.X > 0)
            {
                ghost.Direction = Direction.Left;
                places = maze.GetAvailableNeighbours(ghost.Position, ghost.Direction);

                if (target.Y - ghost.Position.Y > 0 && places.Count == 0)
                {
                    ghost.Direction = Direction.Down;
                    places = maze.GetAvailableNeighbours(ghost.Position, ghost.Direction);


                    if (target.Y - ghost.Position.Y < 0 && places.Count == 0)
                    {
                        ghost.Direction = Direction.Up;
                        places = maze.GetAvailableNeighbours(ghost.Position, ghost.Direction);
                    }
                }
            }
            else if(target.X - ghost.Position.X < 0)
            {
                ghost.Direction = Direction.Right;
                places = maze.GetAvailableNeighbours(ghost.Position, ghost.Direction);
            }*/

            Tile current = maze[(int)ghost.Position.X, (int)ghost.Position.Y];
            List<Tile> places = maze.GetAvailableNeighbours(ghost.Position, ghost.Direction);

            if (places.Count == 0)
                throw new Exception("I cannot go further.");

            Random rand = new Random();
            int choice = rand.Next(places.Count);
            //determine direction
            if (places[choice].Position.X == ghost.Position.X + 1)
                ghost.Direction = Direction.Right;
            else if (places[choice].Position.X == ghost.Position.X - 1)
                ghost.Direction = Direction.Left;
            else if (places[choice].Position.Y == ghost.Position.Y - 1)
                ghost.Direction = Direction.Up;
            else
                ghost.Direction = Direction.Down;
            ghost.Position = places[choice].Position;


            target.X = pacman.Position.X;
            target.Y = pacman.Position.Y;

        }
    }

}
