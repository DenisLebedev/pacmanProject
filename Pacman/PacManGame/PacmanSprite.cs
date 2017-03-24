using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacManLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacManGame
{
    class PacmanSprite: DrawableGameComponent
    {
        private Game1 game;
        private Pacman pacman;

        private SpriteBatch spriteBatch;
        private Texture2D pacmanImage;


        public PacmanSprite(Game1 game, GameState gs) : base(game)
        {
            this.game = game;
            this.pacman = gs.Pacman;
        }
        public override void Initialize()
        {
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
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(pacmanImage, new Rectangle(10 * 32, 17 * 32, 32, 32), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        private void keyBoard()
        {

        }

    }
}
