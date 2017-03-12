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
    //Delegate used to create an event
    public delegate void PacmanDied();
    public delegate void Collision(ICollidable obj);

    /// <summary>
    /// The class Ghost is IMoveable and ICollidable.
    /// It implementing IMoveable because a Ghost as two
    /// different state and they affect how the ghost move.
    /// It implementing IColidable either because a ghost can
    /// hit pacman or pacman can hit a ghost depending the ghost
    /// state. A Ghost will provide some properties to accomplish
    /// the necessary task.
    /// </summary>
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

        /// <summary>
        /// The static constructor will instantiate the timer
        /// we need to use when the Ghost state is scared.
        /// </summary>
        static Ghost()
        {
            scared = new Timer();
        }

        /// <summary>
        /// The constructor will create a new Ghost object depending
        /// on the GameState and the given string. The Gamestate will
        /// instantiate a new Ghost object depending on the file and his
        /// position on the file either.
        /// </summary>
        /// <param name="g">g is a new GameState object that contain all the data necessary</param>
        /// <param name="pos">pos is the current Position of our Ghost</param>
        /// <param name="target">Target is the position of pacman that gonna be sent to any IMovable object</param>
        /// <param name="start">Start is the first GhostState that your ghost should be</param>
        /// <param name="colour">The colour is the literal colour of our ghost defined in GameState</param>
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
                    this.currentState = new Chase(this, g.Maze, g.Pacman, target);
                    this.state = start;
                    break;
                case GhostState.Scared:
                    this.currentState = new Scared(this, g.Maze);
                    this.state = start;
                    scared.Interval = 9000;
                    scared.Enabled = true;
                    scared.Elapsed += UpdateState;
                    break;
            }
        }

        /// <summary>
        /// The CurrentState return an Enum of type GhostState
        /// which symbolize the current state of our ghost.
        /// </summary>
        public GhostState CurrenState
        {
            get { return state; }
        }

        /// <summary>
        /// The Colour Property will return the colour
        /// object that the GameState defined for use.
        /// </summary>
        public Color Colour
        { get { return colour; } }

        public Direction Direction
        {
            get { return direction; }

            set { direction = value; }
        }

        /// <summary>
        /// The Position property returns a vector of the
        /// position of pacman
        /// </summary>
        public Vector2 Position
        {
            get { return new Vector2(target.X, target.Y); }

            set { target = value; }
        }

        /// <summary>
        /// The point property will return the points
        /// if pacman eat a ghost while scared.
        /// </summary>
        public int Points { get; }

        /// <summary>
        /// A Ghost can move depending his state because we
        /// use an interface the Move will be choosed at run-time
        /// </summary>
        public void Move()
        {
            currentState.Move();
            this.Collide();
        }

        /// <summary>
        /// Collide is imporant because it gonna call the
        /// right event depending the state of our Ghost.
        /// If the ghost is in chase mode and at the same position
        /// of pacman we raise the event DeadPacman. Else if
        /// the mode is scared and pacman in on the ghost the
        /// program will add the Ghost to the pen and launch the
        /// event Collision.
        /// </summary>
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

        /// <summary>
        /// The Reset method will add the Ghost to the Pen
        /// </summary>
        public void Reset()
        {
            pen.AddToPen(this);
        }

        /// <summary>
        /// The method ChangeState  take an Enum type GhostState and change
        /// the state of our current ghost depending the state given.
        /// </summary>
        /// <param name="state">state is an Enum that represent the new state that we gonna give to our ghost</param>
        public void ChangeState(GhostState state)
        {
            switch (state)
            {
                case GhostState.Chase:
                    this.state = GhostState.Chase;

                    currentState = new Chase(this, maze, pacman, target);
                    break;

                case GhostState.Scared:
                    this.state = GhostState.Scared;
                    currentState = new Scared(this, maze);
                    scared.Interval = 9000;
                    scared.Enabled = true;
                    scared.Elapsed += UpdateState;
                    break;

                case GhostState.Released:
                    this.state = GhostState.Chase;
                    currentState = new Chase(this, maze, pacman, target);
                    break;
            }
            Console.WriteLine(this.state + "<");
        }

        private void UpdateState(object sender, ElapsedEventArgs e)
        {
            Timer t = (Timer)sender;
            t.Enabled = false;
            this.ChangeState(GhostState.Chase);
        }

    }
}
