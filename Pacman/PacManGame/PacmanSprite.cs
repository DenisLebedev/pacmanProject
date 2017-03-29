using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacManLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PacManGame
{
    /// <summary>
    /// PacmanSprite class is reponsible for drawing and handaling the 
    /// movement the pacman.
    /// </summary>
    class PacmanSprite : DrawableGameComponent
    {
        private Game1 game;
        private Pacman pacman;
        private GameState gs;
        private SpriteBatch spriteBatch;
          
        KeyboardState oldState;
        int counter;
        //used to change the imge dpending on the direction of pacman
        Direction dir;
        private Texture2D pacmanRight;
        private Texture2D pacmanLeft;
        private Texture2D pacmanDown;
        private Texture2D pacmanUp;

        private int frameR;
        private int framecounter;
        private int speedLimit;
        /// <summary>
        /// The cunstrocter will set a gamstate objec and the Game1.
        /// It will also set helper variables in order to set the speed the pacman
        /// moves (FPS).
        /// </summary>
        /// <param name="game"></param>
        /// <param name="gs"></param>
        public PacmanSprite(Game1 game, GameState gs) : base(game)
        {
            this.gs = gs;
            this.game = game;
            this.pacman = gs.Pacman;
            counter = 0;
            speedLimit = 10;

            framecounter = 1;
            frameR = 1;
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            oldState = Keyboard.GetState();
            base.Initialize();
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pacmanLeft = game.Content.Load<Texture2D>("pacmanLeft");
            pacmanUp = game.Content.Load<Texture2D>("pacmanUp");
            pacmanRight = game.Content.Load<Texture2D>("pacmanRight");
            pacmanDown = game.Content.Load<Texture2D>("pacmanDown");
            base.LoadContent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            counter++;
            if (counter >= speedLimit)
            {
                keyBoard();
                counter = 0;               
            }
            base.Update(gameTime);
            
        }
        /// <summary>
        /// The draw method will draw the pacman image onto the screen dpeending
        /// on the direction of the key pressed is.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            switch (dir)
            {
            case Direction.Right:
                    spriteBatch.Draw
                 (pacmanRight, new Rectangle((int)pacman.Position.X * 32, (int)pacman.Position.Y * 32, 32, 32),
                                                          new Rectangle(0, 32 * frameR, 32, 32), Color.White);
                break;
            case Direction.Left:
                spriteBatch.Draw
            (pacmanLeft, new Rectangle((int)pacman.Position.X * 32, (int)pacman.Position.Y * 32, 32, 32),
                                                     new Rectangle(0, 32 * frameR, 32, 32), Color.White); 
                break;
            case Direction.Down:
                spriteBatch.Draw
            (pacmanDown, new Rectangle((int)pacman.Position.X * 32, (int)pacman.Position.Y * 32, 32, 32),
                                                     new Rectangle(32 * frameR, 0, 32, 32), Color.White);
                    break;
            case Direction.Up:
                spriteBatch.Draw
            (pacmanUp, new Rectangle((int)pacman.Position.X * 32, (int)pacman.Position.Y * 32, 32, 32),
                                                   new Rectangle(32 * frameR, 0, 32, 32), Color.White);
                break;
            }

            
            if (framecounter > 5)
            {
                frameR++;
                framecounter = 0;
                if (frameR > 5) { frameR = 0; }
            }
            framecounter++;

            spriteBatch.End();
            base.Draw(gameTime);
        }
        /// <summary>
        /// The keyBoard method will handle key board in[ut from the user.
        /// </summary>
        private void keyBoard()
        {
                KeyboardState newState = Keyboard.GetState();
                //right
                if (newState.IsKeyDown(Keys.Right))
                {
                    dir = Direction.Right;
                    pacman.Move(Direction.Right);
                }
                //left
                else if (newState.IsKeyDown(Keys.Left))
                {
                    dir = Direction.Left;
                    pacman.Move(Direction.Left);
                }
                //up
                else if (newState.IsKeyDown(Keys.Up))
                {
                    dir = Direction.Up;
                    pacman.Move(Direction.Up);
                }
                //down
                else if (newState.IsKeyDown(Keys.Down))
                {
                    dir = Direction.Down;
                    pacman.Move(Direction.Down);
                }
                oldState = newState;
            

        }

    }
}
