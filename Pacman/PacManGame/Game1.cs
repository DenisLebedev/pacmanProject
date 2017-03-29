using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using PacManLibrary;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace PacManGame
{
    /// <summary>
    /// This is the main type for your game.
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

        SoundEffect mysong;
        SoundEffectInstance mysong2;

        SoundEffect mybackSong;
        SoundEffectInstance mybackSong2;

        private Texture2D gameoverImage;


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
            // TODO: Add your initialization logic here


            mazeSprite = new MazeSprite(this, gs.Maze);
            pacmanSprite = new PacmanSprite(this, gs);
            ghostSprite = new GhostSprite(this, gs);
            scoreSprite = new ScoreSprite(this, gs);
            Components.Add(mazeSprite);
            Components.Add(ghostSprite);
            Components.Add(pacmanSprite);
            Components.Add(scoreSprite);


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
            gameoverImage = this.Content.Load<Texture2D>("gameover");
            mysong = Content.Load<SoundEffect>("scaredGhostSong");
            mysong2 = mysong.CreateInstance();
            mysong2.IsLooped = true;
            

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
            int musicCounter = 0;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Ghost g in gs.GhostPack)
            {
            if (g.CurrenState == GhostState.Scared)
            {
                    musicCounter++;
                    if (musicCounter > 0)
                    {
                        mybackSong2.Stop();
                        mysong2.Play();
                    }
               

                /*
                MediaPlayer.Play(song);
                MediaPlayer.IsRepeating = true;
                MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
                */
            }
            else
            {  
                    if(musicCounter > 0)
                        musicCounter--;
                    if (musicCounter == 0)
                    {
                        mysong2.Stop();
                        mybackSong2.Play();
                    }
                   
                    /*
                    this.song = Content.Load<Song>("normalSong");
                    MediaPlayer.Play(song);
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
                    */
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
            if (scoreSprite.PacLost || scoreSprite.PacWinner)
            {
                Components.Remove(pacmanSprite);
                Components.Remove(ghostSprite);
            }

            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);
        }


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
