﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PacManLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManGame
{
    class ScoreSprite : DrawableGameComponent
    {
        private SpriteFont font;
        private SpriteBatch spriteBatch;

        private Game1 game;
        private GameState gs;
        private Texture2D gameoverImage;
        private Texture2D winImage;
        private bool pacmanWon;

        public bool PacLost { get { return gs.Score.Lives < 1; } }
        public bool PacWinner { get; private set; }

        public ScoreSprite(Game1 game, GameState gs) : base(game)
        {
            this.game = game;
            this.gs = gs;
            gs.Maze.PacmanWon += PacWon;
            PacWinner = false;
        }

        private bool PacWon()
        {
            pacmanWon = true;
            PacWinner = true;
            return true;
        }

        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = game.Content.Load<SpriteFont>("score");

            gameoverImage = game.Content.Load<Texture2D>("gameover");
            winImage = game.Content.Load<Texture2D>("win");

            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            //game over
            if (gs.Score.Lives < 1)
            {
                spriteBatch.Draw
              (gameoverImage, new Rectangle(5 * 32, 10 * 32, 480, 110), Color.White);
            }
            if (pacmanWon)
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
