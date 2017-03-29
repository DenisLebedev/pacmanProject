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
    /// <summary>
    /// The MazeSprite class is responsible for drawing all the wall, path (plus members) 
    /// on to the board.
    /// </summary>
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

        private int frameP;
        private int frameE;
        private int framecounter;
        /// <summary>
        /// The constructor will take in the current game build as well as a maze objec
        /// in order to have the same reffrance as the one being used in the Game1 class
        /// </summary>
        /// <param name="game"></param>
        /// <param name="maze"></param>
        public MazeSprite(Game1 game, Maze maze) : base(game)
        {
            this.game = game;
            this.maze = maze;
            frameP = 1;
            frameE = 1;
            framecounter = 0;

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
                        spriteBatch.Draw(wallImage, new Rectangle(x * 32, y * 32, 32, 32), Color.HotPink);
                    }
                    if (maze[x, y] is Path)
                    {
                        //there is a pellet
                        if (maze[x, y].Member() is Pellet && maze[x, y].IsEmpty() == false)
                        {
                            spriteBatch.Draw(pelletImage, new Rectangle(x * 32, y * 32, 32, 32), new Rectangle(0, 32 * frameP, 32, 32), Color.White);

                        }
                       
                        //there is an energizer
                        if (maze[x, y].Member() is Energizer && maze[x, y].IsEmpty() == false)
                        {
                            spriteBatch.Draw(energizerImage, new Rectangle(x * 32, y * 32, 32, 32), new Rectangle(0, 32 * frameE, 32, 32), Color.White);
                        }
                        //there is no member
                        if (maze[x, y].IsEmpty() == true)
                        {
                            spriteBatch.Draw(emptyImage, new Rectangle(x * 32, y * 32, 32, 32), Color.Black);
                        }
                        if (framecounter > 2000) {
                            frameP++;
                            frameE++;
                            framecounter = 0;
                            if (frameP > 6){ frameP = 0; }
                            if (frameE > 4) { frameE = 0; }
                        }
                        framecounter++;

                    }//end of path if

                }//end of j loop
            }//end of i loop

            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
