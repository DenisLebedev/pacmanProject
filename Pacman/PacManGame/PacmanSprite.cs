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

        private SpriteBatch spriteBatch;
        private Texture2D pacmanImage;

        KeyboardState oldState;
        int counter;
        int limit;

        public PacmanSprite(Game1 game, GameState gs) : base(game)
        {
            this.game = game;
            this.pacman = gs.Pacman;
            counter = 0;
            limit = 8;
        }
        public override void Initialize()
        {
            oldState = Keyboard.GetState();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pacmanImage = game.Content.Load<Texture2D>("pacman");
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            counter++;
            if (counter == limit)
            {
                keyBoard();
                counter = 0;
            }
            base.Update(gameTime);
            
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(pacmanImage, new Rectangle((int)pacman.Position.X * 32, (int)pacman.Position.Y * 32, 32, 32), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        private void keyBoard()
        {
            KeyboardState newState = Keyboard.GetState();
            //right
            if (newState.IsKeyDown(Keys.Right))
            {
                pacman.Move(Direction.Right);
              
            }
            //left
            else if (newState.IsKeyDown(Keys.Left))
            {
                pacman.Move(Direction.Left);

            }
            //up
            else if (newState.IsKeyDown(Keys.Up))
            {
                pacman.Move(Direction.Up);

            }
            //down
            else if (newState.IsKeyDown(Keys.Down))
            {
                pacman.Move(Direction.Down);

            }
             oldState = newState;

        }

    }
}
