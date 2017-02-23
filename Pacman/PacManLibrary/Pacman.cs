using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    class Pacman
    {
        private GameState controller;
        private Maze maze;
        private Vector2 position;

        public Pacman (GameState gameState)
        {
            controller = gameState;
 
        }
        public Vector2 Position
        {
            set { position = new Vector2(value.X, value.Y); }
            get { return new Vector2(position.X, position.Y); }
        }
        public void Move (Direction dir)
        {
            if (dir.Equals(Direction.Down))
            {

            }
        } 
        public bool CheckCollisions()
        {
            return false;
        } 
        
    }
}
