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
        public static Vector2 ReleasedPos { get; set; }
        private Pacman pacman;
        private Vector2 pos;
        private Pen pen;
        private Maze maze;
        private Direction direction;
        private Color colour;
        private IGhostState currentState;
        private GhostState state;
        private static Timer scared;

        /// <summary>
        /// If pacman is hitted by a Ghost while in Chase mode he loses a life.
        /// </summary>
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
            this.pos = new Vector2(pos.X, pos.Y);
            this.maze = g.Maze;
            this.pen = g.Pen;
            this.colour = colour;
            this.Points = 300;

            this.direction = Direction.Left;

            this.ChangeState(start);
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
            get { return pos; }

            set { pos = value; }
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
            this.Collide(pacman.Position);
        }

        public void Collide(Vector2 targetPos)
        {
            if (targetPos.X == this.Position.X
                && targetPos.Y == this.Position.Y)
            {
                if (CurrenState == GhostState.Chase
                    && DeadPacman != null)
                    DeadPacman();
                else if (CurrenState == GhostState.Scared
                    && Collision != null)
                {
                    Collision(this);
                    this.Reset();
                }
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
        /// Also, if we switch to scare mode a timer is activated and the ghosts are feared
        /// for 9 seconds.
        /// </summary>
        /// <param name="state">state is an Enum that represent the new state that we gonna give to our ghost</param>
        public void ChangeState(GhostState state)
        {
            switch (state)
            {
                case GhostState.Chase:
                    this.state = GhostState.Chase;
                    currentState = new Chase(this, maze, pacman, pacman.Position);
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
                    currentState = new Chase(this, maze, pacman, pacman.Position);
                    this.Position = ReleasedPos;
                    break;
            }
        }

        /// <summary>
        /// This method should be trigger in 9 seconds if the Ghost is in
        /// Scare mode. If the ghost is scared after 9 seconds he sould switch
        /// mode to Chase mode.
        /// </summary>
        /// <param name="sender">Sendder event object in this case the timer object trigger the event.</param>
        /// <param name="e">ElapsedEventArgs represent the data and all the manipulation possible with the given event.</param>
        private void UpdateState(object sender, ElapsedEventArgs e)
        {
            Timer t = (Timer)sender;
            t.Enabled = false;
            this.ChangeState(GhostState.Chase);        
        }

    }
}
