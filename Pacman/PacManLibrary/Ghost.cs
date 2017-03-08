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
    public delegate void PacmanDied();
    public delegate void Collision(ICollidable obj);

    class Ghost : IMovable, ICollidable
    {
        private Pacman pacman;
        private Vector2 target;
        private Pen pen;
        private Maze maze;
        private Direction direction;
        private Color colour;
        private IGhostState currentState;
        private GhostState state;
        private static Timer scared;
        //!
        private Vector2 pos;

        public event PacmanDied deadPacman;       
        public event Collision collide;

        static Ghost() { scared = new Timer(); }

        /*!!!!!*/
        public Ghost(GameState g, Vector2 pos, Vector2 target, GhostState start, Color colour)
        {
            pacman = new Pacman(g);
            this.pos = new Vector2(pos.X, pos.Y);
            maze = new Maze();
            direction = new Direction();
            this.target = new Vector2(target.X, target.Y);
            //currentState = start;
            this.colour = colour;

            switch (start)
            {
                case GhostState.Chase:
                    currentState = new Chase(this, g.Maze, g.Pacman, g.Pacman.Position);
                    state = GhostState.Chase;
                    break;
                case GhostState.Scared:
                    currentState = new Scared(this, g.Maze);
                    state = GhostState.Scared;
                    break;
            }
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
            currentState.Move();
        }

        public void Collide()
        {
            
        }

        public void Reset()
        {

        }

        public void ChangeState(GhostState state)
        {
            switch (state)
            {
                case GhostState.Chase:
                    state = GhostState.Scared;
                    currentState = new Scared(this, maze);
                    break;

                case GhostState.Scared:
                    state = GhostState.Chase;
                    currentState = new Chase(this, maze, pacman, target);
                    break;
            }

        }

    }
}
