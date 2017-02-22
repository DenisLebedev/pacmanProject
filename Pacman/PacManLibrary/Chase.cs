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

        public  Chase(Ghost ghost, Maze maze, Vector2 target, Pacman pacman)
        {
            this.ghost = ghost;
            this.maze = maze;
            this.target = new Vector2(target.X, target.Y);
            this.pacman = pacman;

        }

        public void Move()
        {
            Tile ghostPos = maze[(int)ghost.Position.X, (int)ghost.Position.Y];
            Tile pacPos = maze[(int)pacman.Position.X, (int)pacman.Position.Y];


        }
    }

}
