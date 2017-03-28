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

        private int frameGP;
        private int framecounter;

        public GhostSprite(Game1 game, GameState gs) : base(game)
        {
            this.gs = gs;
            this.game = game;
            counter = 0;
            speedLimit = 30;
            framecounter = 1;
            frameGP = 1;
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
            
            counter++;
            if (counter == speedLimit)
            {
                gs.GhostPack.Move();
                gs.GhostPack.CheckCollideGhosts(gs.Pacman.Position);
                counter = 0;
                base.Update(gameTime);
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
                                           (int)(g.Position.Y) * 32, 32, 32), new Rectangle(32 * frameGP, 0, 32, 32)
                                              , new Color(new Vector3(0, 0, 255)));
                    speedLimit = 12;
                }
                else
                {
                    spriteBatch.Draw(imgGhost, new Rectangle((int)(g.Position.X) * 32,
                                           (int)(g.Position.Y) * 32, 32, 32), new Rectangle(32 * frameGP, 0, 32, 32), Color.White);
                    speedLimit = 8;
                }
            }

            if (framecounter > 2000)
            {
                frameGP++;
                framecounter = 0;
                if (frameGP > 2) { frameGP = 0; }
            }
            framecounter++;


            spriteBatch.End();

            base.Draw(gameTime);

        }

    }
}
