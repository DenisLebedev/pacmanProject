using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    /// <summary>
    /// The Chase class represent a state where the Ghost will chase the
    /// last position of Pacman. If they reach this position their target gonna
    /// be refreshed. This make the game more easier for the user.
    /// </summary>
    class Chase : IGhostState
    {
        private Ghost ghost; //ghost object that gonna move to the target
        private Maze maze; //the ghost gonna move through the Maze object
        private Vector2 target; //the target object will contain the position that the ghost should go
        private Pacman pacman; // The ghost object will chase Pacman

        /// <summary>
        /// The construtor will initialize all the variables that we need
        /// to accomplish the task given to this class.
        /// </summary>
        /// <param name="ghost">The ghost that will chase Pacman</param>
        /// <param name="maze">The ghost wil move inside the maze</param>
        /// <param name="pacman">The Pacman is the target that the ghost has to follow</param>
        /// <param name="target">The target is the last position of Pacman</param>
        public Chase(Ghost ghost, Maze maze, Pacman pacman, Vector2 target)
        {
            this.ghost = ghost;
            this.maze = maze;
            this.target = new Vector2(target.X, target.Y);
            this.pacman = pacman;

        }

        /// <summary>
        /// The move method implement the logic of a ghost moving by using
        /// the last position of pacman. Also, the path available will be choosed
        /// randomly by the given maze object. If a ghost reach the target
        /// it gonna be refreshed by the last position of pacman.
        /// </summary>
        public void Move()
        {

            List<Tile> places = maze.GetAvailableNeighbours(ghost.Position, ghost.Direction);
            Tile current = maze[(int)ghost.Position.X, (int)ghost.Position.Y];

            //A ghost should not be stuck somewhere
            if (places.Count == 0)
                throw new Exception("I cannot go further.");

            Random rand = new Random();
            int choice = rand.Next(places.Count);
            //determine direction
            if (target.X - ghost.Position.X > 0)
                ghost.Direction = Direction.Right;
            else if (target.Y - ghost.Position.Y > 0)
                ghost.Direction = Direction.Left;
            else if (target.Y - ghost.Position.Y < 0)
                ghost.Direction = Direction.Up;
            else
                ghost.Direction = Direction.Down;
            ghost.Position = places[choice].Position;



            if (target.X == ghost.Position.X && target.Y == ghost.Position.Y)
            {
                Console.WriteLine("Hit The Target");
                Console.WriteLine(target.X + " " + ghost.Position.X + "--"+ target.Y + ghost.Position.Y);
                target.X = pacman.Position.X;
                target.Y = pacman.Position.Y;
            }

        }
    }

}
