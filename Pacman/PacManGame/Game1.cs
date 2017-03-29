using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using PacManLibrary;
using Microsoft.Xna.Framework.Audio;

namespace PacManGame
{
    /// <summary>
    /// Game1 class will control most of all our componnents in the game.
    /// The class control all our component that creates the game and the audio.
    /// Everything depend on Game1 class because it containing everything.
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameState gs;
        ScoreSprite scoreSprite;

        //sprites
        MazeSprite mazeSprite;
        GhostSprite ghostSprite;
        PacmanSprite pacmanSprite;

        //scared music
        SoundEffect mysong;
        SoundEffectInstance mysong2;
        //background music
        SoundEffect mybackSong;
        SoundEffectInstance mybackSong2;

        /// <summary>
        /// The constructor load the level and initialize variables
        /// </summary>
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gs = this.LoadLevel("levelsPen.csv");
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            //Adding all the components needed for the game to work properly
            mazeSprite = new MazeSprite(this, gs.Maze);
            pacmanSprite = new PacmanSprite(this, gs);
            ghostSprite = new GhostSprite(this, gs);
            scoreSprite = new ScoreSprite(this, gs);
            Components.Add(mazeSprite);
            Components.Add(ghostSprite);
            Components.Add(pacmanSprite);
            Components.Add(scoreSprite);

            //window size
            graphics.PreferredBackBufferHeight = 736;
            graphics.PreferredBackBufferWidth = 1000;
            graphics.ApplyChanges();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //music for scared ghost
            mysong = Content.Load<SoundEffect>("scaredGhostSong");
            mysong2 = mysong.CreateInstance();
            mysong2.IsLooped = true;
            
            //backgrund music
            mybackSong = Content.Load<SoundEffect>("normalSong");
            mybackSong2 = mybackSong.CreateInstance();
            
            
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
           
                
            // TODO: use this.Content to load your game content here
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //musicCounter is used to ensure that all ghost are not scared before changing music
            int musicCounter = 0;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            foreach (Ghost g in gs.GhostPack)
            {
                if (g.CurrenState == GhostState.Scared)
                {
                        //add to the counter if a ghost is scared
                        musicCounter++;
                        //until you have a scared ghost play
                        if (musicCounter > 0)
                        {
                            mybackSong2.Stop();
                            mysong2.Play();
                        }
                }
                else
                {       
                        //remove only if you have a scared ghost
                        if(musicCounter > 0)
                            musicCounter--;

                        //No scared ghost so you can play the right music
                        if (musicCounter == 0)
                        {
                            mysong2.Stop();
                            mybackSong2.Play();
                        }
                }
        }

                base.Update(gameTime);
          
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //If pacman lost OR win remove the ghost and pacman
            if (scoreSprite.PacLost || scoreSprite.PacWinner)
            {
                Components.Remove(pacmanSprite);
                Components.Remove(ghostSprite);
            }

            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);
        }

        /// <summary>
        /// The method gonna read from a file to create the maze.
        /// When the method is done it returning a GameState loaded.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private GameState LoadLevel(string file)
        {
            string temp = "";
            using (StreamReader sr = new StreamReader(file))
            {
                temp = sr.ReadToEnd();
                temp = temp.Replace(',', ' ');
            }

            return GameState.Parse(temp);
        }


    }
}
