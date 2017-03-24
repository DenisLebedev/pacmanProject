using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PacManLibrary;

namespace PacManLibrary
{
    public class GameState
    {

        /// <summary>
        /// The static Parse method will take in a string variable and
        /// will set the Tile[,] two dimentional array depending on how the
        /// file is set up and will create and add the objects needed acordingly.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static GameState Parse (string file)
        {
            if (file == "") throw new ArgumentException("Empty String.");

            //Initialization of variables by Properties
            GameState game = new GameState();
            game.GhostPack = new GhostPack();
            game.Pen = new Pen();
            game.Maze = new Maze();            
            game.Pacman = new Pacman(game);
            game.Score = new ScoreAndLives(game);

            string[,] strArr = game.GetFinalArray(file);

            Tile[,] board = new Tile[strArr.GetLength(1), strArr.GetLength(0)];

            for(int x = 0; x < board.GetLength(0); x++)
            {
                for(int y = 0; y < board.GetLength(1); y++)
                {
                    if (strArr[x, y] == "p")
                    {
                        Pellet temp = new Pellet();
                        temp.Collision += game.Score.IncrementScore;
                        board[x, y] = new Path(x, y, temp);
                    }
                    else if (strArr[x, y] == "w" || strArr[x, y].Replace("\r", "") == "w")
                    {
                        board[x, y] = new Wall(x, y);
                    }
                    else if (strArr[x, y] == "e")
                    {
                        Energizer temp = new Energizer(game.GhostPack);
                        temp.Collision += game.Score.IncrementScore;
                        board[x, y] = new Path(x, y, temp);
                    }
                    else if (strArr[x, y] == "P")
                    {
                        game.Pacman.Position = new Vector2(x, y);
                        Pacman.OrigPos = game.Pacman.Position;
                        board[x, y] = new Path(x, y, null);
                    }
                    else if (strArr[x, y] == "1" || strArr[x, y] == "2"
                       || strArr[x, y] == "3" || strArr[x, y] == "4")
                    {

                        Tile temp = new Path(x, y, null);
                        board[x, y] = temp;
                        if (strArr[x, y] != "1")
                            game.Pen.AddTile(temp);
                        game.GhostPack.Add(CreateGhost(strArr[x, y], x, y, game, game.Pacman, game.Score, game.Pen));
                        
                        
                    }
                    else if (strArr[x, y] == "x")
                    {
                        Tile temp = new Path(x, y, null);
                        game.Pen.AddTile(temp);
                        board[x, y] = temp;
                    }
                    else if (strArr[x, y] == "m" || strArr[x, y] == "1")
                    {
                        board[x, y] = new Path(x, y, null);
                    }
                    else
                        throw new ArgumentException("Illegal character to build the maze.");

                }
            }
            game.Score.GameOver += GameOver;
            game.Maze.PacmanWon += PacmanWon;
            game.Maze.SetTiles(board);
            return game;
        }

        /// <summary>
        /// The method return true when the event is trigger
        /// because pacman won.
        /// </summary>
        /// <returns></returns>
        private static bool PacmanWon()
        {
            Console.WriteLine("Lucky Man~");
            return true;
        }

        /// <summary>
        /// When pacman lose all his life the game should reset so
        /// take a new file input, but to do so the method should send
        /// a message to the current program to resend the file. The main
        /// game program is not given/done yet so a message is gonna be printed.
        /// </summary>
        private static bool GameOver()
        {
            
            Console.WriteLine("You loose looser.");
            return true;
        }

        /// <summary>
        /// This helper class is used to create a ghost objec inorder to
        /// add a ghost to the Tile[,] array being set up in the static Parse
        /// method.
        /// </summary>
        /// <param name="num"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="game"></param>
        /// <param name="pacman"></param>
        /// <param name="scoreAndLives"></param>
        /// <returns></returns>
        private static Ghost CreateGhost(string num, int x, int y, 
                           GameState game, Pacman pacman, ScoreAndLives scoreAndLives, Pen pen)
        {
            Ghost ghost = null;

            switch (num)
            {
                //red
                case "1":
                    
                    ghost = new Ghost(game, new Vector2(x, y), pacman.Position,
                            GhostState.Chase, new Color(255, 0, 0));
                    Ghost.ReleasedPos = ghost.Position;
                    break;
                //green
                case "2":
                    ghost = new Ghost(game, new Vector2(x, y), pacman.Position,
                     GhostState.Released, new Color(50, 205, 50));
                    pen.AddToPen(ghost);
                    break;
                //hot pink
                case "3":
                    ghost = new Ghost(game, new Vector2(x, y), pacman.Position,
                     GhostState.Released, new Color(255, 105, 180));
                    pen.AddToPen(ghost);
                    break;
                //orange
                case "4":
                    ghost = new Ghost(game, new Vector2(x, y), pacman.Position,
                     GhostState.Released, new Color(255, 165, 0));
                    pen.AddToPen(ghost);
                    break;
            }    

            if(ghost != null)
            {
                ghost.Collision += scoreAndLives.IncrementScore;
                ghost.DeadPacman += scoreAndLives.DeadPacman;
                ghost.DeadPacman += game.GhostPack.ResetGhosts;
            }
            else
            {
                throw new NullReferenceException("Cannot create a ghost object.");
            }

            return ghost;
        }

        /// <summary>
        /// The method gonna split our given string to an Multidimensional array
        /// with LINQ. 
        /// </summary>
        /// <param name="game">The string is the actual game board</param>
        /// <returns></returns>
        private string[,] GetFinalArray(string game)
        {
            //getting all the lines
            string[] full = game.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            //the actual size of your array
            string[,] board = new string[full.GetLength(0), full.GetLength(0)];
            //The LINQ return a Jagged array a conversion is needed
            string[][] Result = (from str in full
                                 where (str != " ")
                                 select str.Split(' ')).ToArray();

            //Conversion of the array
            string[,] finalArr = new string[full.GetLength(0), full.GetLength(0)];
            for (int i = 0; i < Result.Length; i++)
            {
                for (int j = 0; j < Result[i].Length; j++)
                {
                    //tranpose
                    finalArr[j, i] = Result[i][j];
                }
            }

            return finalArr;
        }
        /// <summary>
        /// The Pacman proprety is read only and will return the 
        /// GameStates Pacman object.
        /// </summary>
        public Pacman Pacman
        {
            get;
            private set;
        }
        /// <summary>
        /// The GhostPack proprety will return a GhostPack object
        /// that was initialized within the GameState class
        /// </summary>
        public GhostPack GhostPack
        {
            get;
            private set;
        }
        /// <summary>
        /// The Maze propprety containg the maze initialized in the 
        /// GameState class
        /// </summary>
        public Maze Maze
        {
            get;
            private set;
        }
        /// <summary>
        /// The Pen propprety containg the pen initialized in the 
        /// GameState class
        /// </summary>
        public Pen Pen
        {
            get;
            private set;
        }
        /// <summary>
        /// The Score propprety containg the ScoreLives class in the 
        /// GameState class
        /// </summary>
        public ScoreAndLives Score
        {
            get;
            private set;
        }
    }
}
