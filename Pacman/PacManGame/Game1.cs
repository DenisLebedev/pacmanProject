﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using PacManLibrary;

namespace PacManGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public static readonly int speedLimit = 8;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameState gs;
        ScoreSprite scoreSprite;

        MazeSprite mazeSprite;
        GhostSprite ghostSprite;
        PacmanSprite pacmanSprite;

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


            graphics.PreferredBackBufferHeight = 1000;
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

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
