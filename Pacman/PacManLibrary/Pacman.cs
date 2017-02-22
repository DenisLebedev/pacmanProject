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

        public Pacman (GameState gameState)
        {
            controller = gameState;
        }
        public void Move (Direction dir)
        {

        } 
        public bool CheckCollisions()
        {
            return false;
        } 
        
    }
}
