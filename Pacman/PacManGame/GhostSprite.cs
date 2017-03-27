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
        private int speedLimit;

        public GhostSprite(Game1 game, GameState gs) : base(game)
        {
            this.gs = gs;
            this.game = game;
            counter = 0;
            speedLimit = 8;
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
            counter++;
            if (counter == speedLimit)
            {
                gs.GhostPack.Move();
                gs.GhostPack.CheckCollideGhosts(gs.Pacman.Position);
                counter = 0;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            

            foreach (Ghost g in gs.GhostPack)
            {
                if (g.CurrenState == GhostState.Scared)
                {
                    spriteBatch.Draw(imgGhost, new Rectangle((int)(g.Position.X) * 32,
                                           (int)(g.Position.Y) * 32, 32, 32), new Rectangle((int)(g.Position.X) * 32, (int)(g.Position.Y) * 32, 96,32)
                                              , new Color(new Vector3(0, 0, 255)));
                    speedLimit = 12;
                }
                else
                {
                    spriteBatch.Draw(imgGhost, new Rectangle((int)(g.Position.X) * 32,
                                           (int)(g.Position.Y) * 32, 32, 32), new Rectangle((int)(g.Position.X) * 32, (int)(g.Position.Y) * 32, 96, 32), g.Colour);
                    speedLimit = 8;
                }
            }
            

            spriteBatch.End();

            base.Draw(gameTime);

        }

    }
}
