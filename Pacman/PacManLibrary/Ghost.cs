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

    public class Ghost : IMovable, ICollidable
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

        public event PacmanDied DeadPacman;       
        public event CollisionEvent Collision;

        static Ghost()
        {
            scared = new Timer();
        }

        public Ghost(GameState g, Vector2 pos, Vector2 target, GhostState start, Color colour)
        {
            this.pacman = g.Pacman;
            this.Position = new Vector2(pos.X, pos.Y);
            this.maze = g.Maze;
            this.pen = g.Pen;
            this.target = new Vector2(target.X, target.Y);
            this.colour = colour;
            this.Points = 300;

            this.Direction = Direction.Left;
            
            switch (start)
            {
                case GhostState.Chase:
                    currentState = new Chase(this, g.Maze, g.Pacman, target);
                    this.state = start;
                    break;
                case GhostState.Scared:
                    currentState = new Scared(this, g.Maze);
                    this.state = start;
                    scared.Interval = 9000;
                    scared.Enabled = true;
                    scared.Elapsed += UpdateState;
                    break;
            }
        }

        public GhostState CurrenState
        {
            get { return state; }
        }

        public Color Colour
        { get { return colour; } }

        public Direction Direction
        {
            get { return direction; }

            set{ direction = value; }
        }

        public Vector2 Position
        {
            get { return new Vector2(target.X, target.Y); }

            set { target = value; }
        }


        public int Points { get; }


        public void Move()
        {
            currentState.Move();
            this.Collide();
        }

        public void Collide()
        {
            if (pacman.Position.X == this.Position.X
                && pacman.Position.Y == this.Position.Y
                && state == GhostState.Chase
                && DeadPacman != null)
                DeadPacman();
            else if (pacman.Position.X == this.Position.X
                && pacman.Position.Y == this.Position.Y
                && state == GhostState.Scared
                && Collision != null)
            {
                Collision(this);
                this.Reset();
            }
        }

        public void Reset()
        {
            pen.AddToPen(this);
        }

        public void ChangeState(GhostState state)
        {
            switch (state)
            {
                case GhostState.Chase:
                    state = GhostState.Scared;
                    currentState = new Scared(this, maze);
                    scared.Interval = 9000;
                    scared.Enabled = true;
                    scared.Elapsed += UpdateState;
                    break;

                case GhostState.Scared:
                    state = GhostState.Chase;
                    currentState = new Chase(this, maze, pacman, target);  
                    break;

                case GhostState.Released:
                    state = GhostState.Chase;
                    currentState = new Chase(this, maze, pacman, target);
                    break;
            }
        }

        private void UpdateState(object sender, ElapsedEventArgs e)
        {
            Timer t = (Timer)sender;
            t.Enabled = false;
            this.ChangeState(GhostState.Chase);         
        }

    }
}
