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
            this.controller = gameState;
            this.maze = gameState.Maze;
 
        }
        public Vector2 Position
        {
            set { position = new Vector2(value.X, value.Y); }
            get { return new Vector2(position.X, position.Y); }
        }
        public void Move (Direction dir)
        {
            List<Tile> allowed_moves = maze.GetAvailableNeighbours(position, dir);
            directionChosen(dir)
            for (int i = 0; i < allowed_moves.Count; i++)
            {
                if (dir)
                {

                }
            }

        } 
        private Direction directionChosen (Direction dir)
        {
            switch (dir)
            {
                case Direction.Down:
                    return dir;
                    break;
                case Direction.Left:
                    return dir;
                    break;
                case Direction.Up:
                    return dir;
                    break;
                case Direction.Right:
                    return dir;
                    break;
            }
            return new Direction();
        }
        public bool CheckCollisions()
        {
            if (maze[(int)position.X, (int)position.Y] is Wall)
            {
                return true;
            }

            return false;
        } 
        
    }
}
