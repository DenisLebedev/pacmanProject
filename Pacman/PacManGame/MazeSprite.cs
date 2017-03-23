using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using PacManLibrary;

namespace PacManGame
{

    public class MazeSprite : DrawableGameComponent
    {
        //the business logic
        Maze maze;
        Pellet pellet;
        Energizer energize;
        Wall wall;


        //to render
        private SpriteBatch spriteBatch;
        private Texture2D imagePaddle;
        private Game1 game;

        public MazeSprite(Game1 game) : base(game)
        {
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

    }
}
