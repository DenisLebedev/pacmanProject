using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Drawing;
using System.Timers;

namespace PacManLibrary
{
    class Ghost : IMovable, ICollidable
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
            direction = new Direction();
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

        public Direction Direction
        {
            get { return direction; }

            set{ direction = value; }
        }

        public Vector2 Position
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Points
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }


        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Collide()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {

        }

        public void ChangeState(IGhostState state)
        {

        }
    }
}
