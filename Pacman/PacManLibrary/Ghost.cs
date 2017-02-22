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

        public delegate void PacmanDied();
        public event PacmanDied deadPacman;

        public delegate void Collision(ICollidable obj);
        public event Collision collide;

        static Ghost() { scared = new Timer(); }

        /*!!!!!*/
        public Ghost(GameState g, int x, int y, Vector2 target, IGhostState start, Color colour)
        {
            pacman = new Pacman(g);
            maze = new Maze();
            direction = new Direction();
            this.target = new Vector2(target.X, target.Y);
            currentState = start;
            this.colour = colour;
        }

        /*!!!!!!!! ref*/
        public IGhostState CurrenState
        {
            get { return currentState; }
        }

        public Color Colour
        {
            get { return colour; }
        }

        public Direction Direction
        {
            get { return direction; }

            set{ direction = value; }
        }

        public Vector2 Position
        {
            get { return new Vector2(target.X, target.Y); }

            set { target = new Vector2(value.X, value.Y); }
        }

        /*!!!!*/
        public int Points
        {
            get { return 100; }

            set { }
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
            if(state is Chase)
            {

            }else if(state is Scared)
            {
                //timer
            }
        }

    }
}
