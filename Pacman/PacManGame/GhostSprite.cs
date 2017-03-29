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
        private List<Texture2D> imgGhost;
        private Texture2D imgScaredG;
        private Game1 game;
        private GameState gs;

        private int counter;
        private int speedLimit;

        private int frameGP;
        private int framecounter;

        public GhostSprite(Game1 game, GameState gs) : base(game)
        {
            imgGhost = new List<Texture2D>(4);
            this.gs = gs;
            this.game = game;
            counter = 0;
            speedLimit = 10;
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
            imgGhost.Add(game.Content.Load<Texture2D>("ghost1"));
            imgGhost.Add(game.Content.Load<Texture2D>("ghost2"));
            imgGhost.Add(game.Content.Load<Texture2D>("ghost3"));
            imgGhost.Add(game.Content.Load<Texture2D>("ghost4"));

            imgScaredG = game.Content.Load<Texture2D>("scaredG1");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            
   
            if (counter > speedLimit)
            {
                gs.GhostPack.Move();
                gs.GhostPack.CheckCollideGhosts(gs.Pacman.Position);
                counter = 0;
                base.Update(gameTime);
            }
            counter++;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            int tempC = 0;
            
            foreach (Ghost g in gs.GhostPack)
            {
                if (g.CurrenState == GhostState.Scared)
                {
                    spriteBatch.Draw(imgScaredG, new Rectangle((int)(g.Position.X) * 32,
                                           (int)(g.Position.Y) * 32, 32, 32), new Rectangle(32 * frameGP, 0, 32, 32)
                                              , Color.White);
                    speedLimit = 14;
                }
                else
                {
                    spriteBatch.Draw(imgGhost.ElementAt(tempC), new Rectangle((int)(g.Position.X) * 32,
                                           (int)(g.Position.Y) * 32, 32, 32), new Rectangle(32 * frameGP, 0, 32, 32), Color.White);
                    speedLimit = 10;
                }
                tempC++;
            }

            if (framecounter > 60)
            {
                frameGP++;
                framecounter = 0;
                if (frameGP > 1) { frameGP = 0; }
            }

            spriteBatch.End();

            base.Draw(gameTime);

        }

    }
}
