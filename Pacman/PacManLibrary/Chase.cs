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

        }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }

}
