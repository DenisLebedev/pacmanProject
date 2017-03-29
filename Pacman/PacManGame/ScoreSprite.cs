using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PacManLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManGame
{
    /// <summary>
    /// ScoreSprite class is reponsible for the score table being diplayed
    /// and will also handle the events if pacman wins and or loses.
    /// </summary>
    class ScoreSprite : DrawableGameComponent
    {
        private SpriteFont font;
        private SpriteBatch spriteBatch;

        private Game1 game;
        private GameState gs;
        private Texture2D gameoverImage;
        private Texture2D winImage;

        /// <summary>
        ///  This prop will return a bool that determines 
        /// </summary>
        public bool PacLost { get { return gs.Score.Lives < 1; } }
        /// <summary>
        /// 
        /// </summary>
        public bool PacWinner { get; private set; }
        /// <summary>
        /// The constructor will take a Game1 object (the current game being run) and a GameState
        /// and will assign them appropriately amd will register the pacmanwon event.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="gs"></param>
        public ScoreSprite(Game1 game, GameState gs) : base(game)
        {
            this.game = game;
            this.gs = gs;
            gs.Maze.PacmanWon += PacWon;
            PacWinner = false;
        }
        /// <summary>
        /// This method is the event handler for when the pacman
        /// wins.
        /// </summary>
        /// <returns></returns>
        private bool PacWon()
        {
            PacWinner = true;
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = game.Content.Load<SpriteFont>("score");

            gameoverImage = game.Content.Load<Texture2D>("gameover");
            winImage = game.Content.Load<Texture2D>("win");

            base.LoadContent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        /// <summary>
        /// The draw method will create the string to be displayed and will represent 
        /// the score board and it will also display the game over as well as the game won sprites.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            //game over
            if (gs.Score.Lives < 1)
            {
                spriteBatch.Draw
              (gameoverImage, new Rectangle(5 * 32, 10 * 32, 480, 110), Color.White);
            }
            if (PacWinner)
            {
                spriteBatch.Draw
              (winImage, new Rectangle(5 * 32, 10 * 32, 480, 110), Color.White);
            }
            //points
            spriteBatch.DrawString
                (font, "Your score is: " + gs.Score.Score, new Vector2(25 * 32, 0 * 32), Color.White);
            //lives
            spriteBatch.DrawString
                (font, "Lives Left: " + gs.Score.Lives, new Vector2(25 * 32, 1 * 32), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
