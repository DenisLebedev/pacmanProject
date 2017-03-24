using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacManLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PacManGame
{
    public class GhostSprite : DrawableGameComponent
    {
        //to render
        private SpriteBatch spriteBatch;
        private Texture2D imgGhost;
        private Game1 game;
        private GameState gs;

        private int counter;
        private int limit;

        public GhostSprite(Game1 game, GameState gs) : base(game)
        {
            this.gs = gs;
            this.game = game;
            counter = 0;
            limit = 10;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            imgGhost = game.Content.Load<Texture2D>("ghost");


            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            gs.GhostPack.Move();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            foreach(Ghost g in gs.GhostPack)
            {
                spriteBatch.Draw(imgGhost, new Rectangle((int)(g.Position.Y) * 32,
                                           (int)(g.Position.X) * 32, 32, 32), g.Colour);
            }

            spriteBatch.End();

            base.Draw(gameTime);

        }


    }
}
