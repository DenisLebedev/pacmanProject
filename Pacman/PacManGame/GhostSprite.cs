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
    /// <summary>
    /// GhostSprite is responsable to draw the ghost depending his state.
    /// A scared ghost look different from a normal ghost.
    /// Also, the class take care to load all the ghosts.
    /// </summary>
    public class GhostSprite : DrawableGameComponent
    {
        //to render
        private SpriteBatch spriteBatch;
        private List<Texture2D> imgGhost;
        private Texture2D imgScaredG;
        private Game1 game;
        private GameState gs;

        private int counterSpeed;
        private int speedLimit;

        private int frameGP;
        private int framecounter;

        /// <summary>
        /// Initialisation of all variables needed.
        /// </summary>
        /// <param name="game"> game is necessary to use special properties from this class.</param>
        /// <param name="gs">gs help us to keep track of the game.</param>
        public GhostSprite(Game1 game, GameState gs) : base(game)
        {
            imgGhost = new List<Texture2D>(4);
            this.gs = gs;
            this.game = game;

            counterSpeed = 0;
            //A ghost canot go faster than seedLimit which is the same as PacMan
            speedLimit = 10;
            framecounter = 1;
            frameGP = 1;
        }

        /// <summary>
        /// The method does load all your texture and external needed
        /// resources.
        /// </summary>
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

        /// <summary>
        /// Update will update the screen view from a user persective
        /// .
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            
   
            if (counterSpeed > speedLimit)
            {
                gs.GhostPack.Move();
                gs.GhostPack.CheckCollideGhosts(gs.Pacman.Position);
                counterSpeed = 0;
                base.Update(gameTime);
            }
            counterSpeed++;
        }

        /// <summary>
        /// Draw will draw all the necessary items for a ghost and change
        /// pictures when a ghost state is changed.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            int tempC = 0;
            
            foreach (Ghost g in gs.GhostPack)
            {
                if (g.CurrenState == GhostState.Scared)
                {
                    //New picture for a scared ghost
                    spriteBatch.Draw(imgScaredG, new Rectangle((int)(g.Position.X) * 32,
                                           (int)(g.Position.Y) * 32, 32, 32), new Rectangle(32 * frameGP, 0, 32, 32)
                                              , Color.White);
                    speedLimit = 14;
                }
                else
                {
                    //Using 4 different pictures for the ghost
                    spriteBatch.Draw(imgGhost[tempC], new Rectangle((int)(g.Position.X) * 32,
                                           (int)(g.Position.Y) * 32, 32, 32), new Rectangle(32 * frameGP, 0, 32, 32), Color.White);
                    speedLimit = 10;
                }
                tempC++;
            }

            //Updating the sprite of a ghost
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
