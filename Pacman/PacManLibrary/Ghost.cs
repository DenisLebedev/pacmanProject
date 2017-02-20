using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;using System.Drawing;
using System.Timers;
namespace PacManLibrary
{
    class Ghost
    {
        private Pacman pacman;
        private Vector2 target;
        private Pen pen;
        private Maze maze;
        private Direction direction;
        private Color colour;
        private IGhostState currentState;
        private static Timer scared;

        static Ghost() { }

        /*!!!!!*/
        public Ghost(GameState g, int x, int y, Vector2 target, IGhostState start, Color colour)
        {
            direction = new Direction(x, y);
            this.target = target;
            currentState = start;
            this.colour = colour;
            //scared
        }

        /*DEL*/

        /*!!!!!!!! ref*/
        public IGhostState CurrenState
        {
            get { return currentState; }
        }

        public Color Colour
        {
            get { return new Color(); }
        }

        public void Reset()
        {

        }

        public void ChangeState(IGhostState)
        {

        }

    }
}
