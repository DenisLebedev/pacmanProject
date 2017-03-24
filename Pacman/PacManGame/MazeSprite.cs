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
        private Maze maze;

        //to render
        private SpriteBatch spriteBatch;
        private Texture2D wallImage;
        private Texture2D pelletImage;
        private Texture2D energizerImage;
        private Texture2D emptyImage;
        private Game1 game;

        public MazeSprite(Game1 game, Maze maze) : base(game)
        {
            this.game = game;
            this.maze = maze;
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            wallImage = game.Content.Load<Texture2D>("wall");
            energizerImage = game.Content.Load<Texture2D>("energizer");
            pelletImage = game.Content.Load<Texture2D>("pellet");
            emptyImage = game.Content.Load<Texture2D>("empty");

            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {


            spriteBatch.Begin();

            for (int i = 0; i < maze.Size; i++)
            {
                for (int j = 0; j < maze.Size; j++)
                {
                    if (maze[i, j] is Wall)
                    {
                        spriteBatch.Draw(wallImage, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                    }
                    if (maze[i, j] is Path)
                    {
                        //there is a pellet
                        if (maze[i, j].Member() is Pellet && maze[i, j].IsEmpty() == false)
                        {
                            spriteBatch.Draw(pelletImage, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                        }
                       
                        //there is an energizer
                        if (maze[i, j].Member() is Energizer && maze[i, j].IsEmpty() == false)
                        {
                            spriteBatch.Draw(energizerImage, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                        }
                        //there is no member
                        if (maze[i, j].IsEmpty() == true)
                        {
                            spriteBatch.Draw(emptyImage, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                        }


                    }//end of path if

                }//end of j loop
            }//end of i loop

            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
