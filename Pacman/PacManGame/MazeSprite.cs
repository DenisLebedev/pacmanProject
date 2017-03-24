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
        private Texture2D pacmanImage;
        private Texture2D ghostImage;

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

            for (int y = 0; y < maze.Size; y++)
            {
                for (int x = 0; x < maze.Size; x++)
                {
                    if (maze[x, y] is Wall)
                    {
                        spriteBatch.Draw(wallImage, new Rectangle(x * 32, y * 32, 32, 32), Color.White);
                    }
                    if (maze[x, y] is Path)
                    {
                        //there is a pellet
                        if (maze[x, y].Member() is Pellet && maze[x, y].IsEmpty() == false)
                        {
                            spriteBatch.Draw(pelletImage, new Rectangle(x * 32, y * 32, 32, 32), Color.White);
                        }
                       
                        //there is an energizer
                        if (maze[x, y].Member() is Energizer && maze[x, y].IsEmpty() == false)
                        {
                            spriteBatch.Draw(energizerImage, new Rectangle(x * 32, y * 32, 32, 32), Color.White);
                        }
                        //there is no member
                        if (maze[x, y].IsEmpty() == true)
                        {
                            spriteBatch.Draw(emptyImage, new Rectangle(x * 32, y * 32, 32, 32), Color.White);
                        }


                    }//end of path if

                }//end of j loop
            }//end of i loop

            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
