using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    /// <summary>
    /// The Pacman class will hold The position of the object and a proprety that
    /// takes in a vector2 object that can be set and returned for use.It will also
    /// move the pacman and will checkcollison evry single time it moves inorder to
    /// determain if it collided with a pellet energizer or a ghost.
    /// </summary>
   public class Pacman
    {
        private GameState controller;
        private Maze maze;
        private Vector2 position;

        /// <summary>
        /// the pacman constructer will take in gamestate object that will
        /// contain the maze , how evything is spread out, and will assign
        /// it to a local private variable (conroller) and using the gamestate objec
        /// a maze private loval variable will also be asigned.
        /// </summary>
        /// <param name="gameState"></param>
        public Pacman (GameState gameState)
        {
            this.controller = gameState;
            this.maze = gameState.Maze;
 
        }
        /// <summary>
        /// The Position prop will set and return a vector2 containg
        /// the posiont of the pacman.
        /// </summary>
        public Vector2 Position
        {
            set { position = value; }
            get { return new Vector2(position.X, position.Y); }
        }
        /// <summary>
        /// The Move metohd will be taske dto move the pacman around the 
        /// board, if the index at that position the CanEnter() returns true.
        /// </summary>
        /// <param name="dir"></param>
        public void Move (Direction dir)
        {
            switch (dir)
            {
                case Direction.Down:
                    if (maze[(int)Position.X + 1, (int)Position.Y].CanEnter())
                    {
                        Position = new Vector2(Position.X + 1, Position.Y);
                        CheckCollisions();
                    }
                    break;
                case Direction.Left:
                    if (maze[(int)Position.X, (int)Position.Y - 1].CanEnter())
                    {
                        Position = new Vector2(Position.X, Position.Y - 1);
                        CheckCollisions();
                    }
                    break;
                case Direction.Up:
                    if (maze[(int)Position.X - 1, (int)Position.Y].CanEnter())
                    {
                        Position = new Vector2(Position.X - 1, Position.Y);
                        CheckCollisions();
                    }
                    break;
                case Direction.Right:
                    if (maze[(int)Position.X, (int)Position.Y + 1].CanEnter())
                    {
                        Position = new Vector2(Position.X, Position.Y + 1);
                        CheckCollisions();
                    }
                    break;
            }     
        } 
        /// <summary>
        /// The checkCollision will check if the pacman collided with something when
        /// he moved and if so it will call the Collide() method of that index and 
        /// then will fire the apropriate event.
        /// </summary>
        public void CheckCollisions()
        {
          if (!(maze[(int)Position.X, (int)Position.Y].IsEmpty())){
                //there is something here
                maze[(int)Position.X, (int)Position.Y].Collide();
            }
            //thre is nothing here

        } 
        
    }
}
