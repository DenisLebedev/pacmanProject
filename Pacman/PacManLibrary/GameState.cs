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
      
   
        public static GameState Parse (string file)
        {
            if (file == "") throw new ArgumentException("Empty String.");

            GameState game = new GameState();
            game.GhostPack = new GhostPack();
            game.Pen = new Pen();
            game.Maze = new Maze();            
            game.Pacman = new Pacman(game);
            game.Score = new ScoreAndLives(game);

            string[,] strArr = game.GetFinalArray(file);

            Tile[,] board = new Tile[strArr.GetLength(0), strArr.GetLength(1)];

            for(int y = 0; y < board.GetLength(0); y++)
            {
                for(int x = 0; x < board.GetLength(1); x++)
                {
                    if (strArr[x, y] == "p")
                    {
                        Pellet temp = new Pellet();
                        temp.Collision += game.Score.IncrementScore;
                        board[x, y] = new Path(x, y, temp);
                    } else if (strArr[x, y] == "w")
                    {
                        board[x, y] = new Wall(x, y);
                    } else if (strArr[x, y] == "e" )
                    {
                        Energizer temp = new Energizer(game.GhostPack);
                        temp.Collision += game.Score.IncrementScore;
                        board[x, y] = new Path(x, y, temp);
                    } else if (strArr[x, y] == "P")
                    {
                        game.Pacman.Position = new Vector2(x,y);
                    } else if (strArr[x, y] == "1" || strArr[x, y] == "2"
                         || strArr[x, y] == "3" || strArr[x, y] == "4")
                    {
                        game.GhostPack.Add(CreateGhost(strArr[x, y], x, y, game, game.Pacman, game.Score));
                        Tile temp = new Path(x, y, null);
                        board[x, y] = temp;
                    }
                    else if (strArr[x, y] == "x")
                    {
                        Tile temp = new Path(x, y, null);
                        game.Pen.AddTile(temp);
                        board[x, y] = temp;
                    } else if (strArr[x, y] == "m")
                    {
                        board[x, y] = new Path(x, y, null);
                    }
                }
            }
            game.Maze.SetTiles(board);
            return game;
        }

        private static Ghost CreateGhost(string num, int x, int y, 
                           GameState game, Pacman pacman, ScoreAndLives scoreAndLives)
        {
            Ghost ghost = null;

            switch (num)
            {
                //red
                case "1":
                    ghost = new Ghost(game, new Vector2(x, y), pacman.Position,
                            GhostState.Chase, new Color(255, 0, 0));              
                    break;
                //green
                case "2":
                    ghost = new Ghost(game, new Vector2(x, y), pacman.Position,
                     GhostState.Chase, new Color(50, 205, 50));
                    break;
                //hot pink
                case "3":
                    ghost = new Ghost(game, new Vector2(x, y), pacman.Position,
                     GhostState.Chase, new Color(255, 105, 180));
                    break;
                //orange
                case "4":
                    ghost = new Ghost(game, new Vector2(x, y), pacman.Position,
                     GhostState.Chase, new Color(255, 165, 0));
                    break;
            }    

            if(ghost != null)
            {
                ghost.Collision += scoreAndLives.IncrementScore;
                ghost.DeadPacman += scoreAndLives.deadPacman;
            }
            else
            {
                throw new NullReferenceException("Cannot create a ghost object.");
            }

            return ghost;
        }

        private string[,] GetFinalArray(string game)
        {
            string[] full = game.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[,] board = new string[full.GetLength(0), full.GetLength(0)];
            string[][] Result = (from str in full
                                 where (str != " ")
                                 select str.Split(' ')).ToArray();

            string[,] finalArr = new string[full.GetLength(0), full.GetLength(0)];
            for (int i = 0; i < Result.Length; i++)
            {
                for (int j = 0; j < Result[i].Length; j++)
                {
                    finalArr[i, j] = Result[i][j];
                }
            }

            return finalArr;
        }            
  
        public Pacman Pacman
        {
            get;
            private set;
        }
        public GhostPack GhostPack
        {
            get;
            private set;
        }
        public Maze Maze
        {
            get;
            private set;
        }

        public Pen Pen
        {
            get;
            private set;
        }
        public ScoreAndLives Score
        {
            get;
            private set;
        }
    }
}
