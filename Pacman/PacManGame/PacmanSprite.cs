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
    class PacmanSprite: DrawableGameComponent
    {
        private Game1 game;
        private Pacman pacman;
        private GameState gs;
        private SpriteBatch spriteBatch;
        private Texture2D pacmanImage;

        KeyboardState oldState;
        int counter;

        Direction dir;
        private Texture2D rImage;
        private Texture2D lImage;
        private Texture2D dImage;
        private Texture2D uImage;

        private int frameR;
        private int framecounter;

        public PacmanSprite(Game1 game, GameState gs) : base(game)
        {
            this.gs = gs;
            this.game = game;
            this.pacman = gs.Pacman;
            counter = 0;
            framecounter = 1;
            frameR = 1;
        }
        public override void Initialize()
        {
            oldState = Keyboard.GetState();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            lImage = game.Content.Load<Texture2D>("left");
            uImage = game.Content.Load<Texture2D>("up");
            rImage = game.Content.Load<Texture2D>("right");
            dImage = game.Content.Load<Texture2D>("down");
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            counter++;
            if (counter == Game1.speedLimit)
            {
                keyBoard();
                counter = 0;               
            }
            base.Update(gameTime);
            
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
                switch (dir)
                {
                case Direction.Right:
                    spriteBatch.Draw
                (rImage, new Rectangle((int)pacman.Position.X * 32, (int)pacman.Position.Y * 32, 32, 32), new Rectangle(0, 32 * frameR, 32, 32), Color.White);
                    break;
                case Direction.Left:
                    spriteBatch.Draw
                (lImage, new Rectangle((int)pacman.Position.X * 32, (int)pacman.Position.Y * 32, 32, 32), Color.White);
                    break;
                case Direction.Down:
                    spriteBatch.Draw
                (dImage, new Rectangle((int)pacman.Position.X * 32, (int)pacman.Position.Y * 32, 32, 32), Color.White);
                    break;
                case Direction.Up:
                    spriteBatch.Draw
                (uImage, new Rectangle((int)pacman.Position.X * 32, (int)pacman.Position.Y * 32, 32, 32), Color.White);
                    break;
                }

            if (framecounter > 2000)
            {
                frameR++;
                framecounter = 0;
                if (frameR > 5) { frameR = 0; }
            }
            framecounter++;

            spriteBatch.End();
            base.Draw(gameTime);
        }
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
