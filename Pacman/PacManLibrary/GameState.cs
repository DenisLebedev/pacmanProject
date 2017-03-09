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
     class GameState
    {
       private Tile[,] board;

       public GameState()
        {
            GameState game;
            game = parse("..\\..\\..\\game_board.txt");
            Maze.SetTiles(board);
        }
   
        public static GameState parse (string file)
        {
            GameState game = new GameState();
            GhostPack ghost = new GhostPack();
            Pen pen = new Pen ();
            Maze maze = new Maze();
            Pellet pellet = new Pellet();
            Energizer energizer = new Energizer(ghost);
            Pacman pacman = new Pacman (game);
            ScoreAndLives scoreAndLives = new ScoreAndLives(game);
            char deleimeter = ' ';
            Tile[,] board = new Tile [23,23]; 
            string[] readText = null;
            try
            {
                readText = File.ReadAllLines(file);
                for (int i = 0; i < 23; i++)
                {

                    String[] substrings = readText[i].Split(deleimeter);

                    for (int j = 0; j < 23; j++)
                    {
                        try
                        {   //wall
                            if (substrings[j] == "w")
                            {
                                board[i, j] = new Wall(i, j);

                            }
                            //path
                            if (substrings[j] == "p")
                            {
                                // this.board[i, j] = new Pellet();
                                pellet.Collision += scoreAndLives.IncrementScore;
                            }
                            //pacman
                            if (substrings[j] == "P")
                            {
                                //this.board[i, j] = pacman;
                                pacman.Position = new Vector2(i, j);
                            }
                            //ghost
                            if (substrings[j] == "1" || substrings[j] == "2" ||
                                substrings[j] == "3" || substrings[j] == "4")
                            {
                                //this.board[i, j] = ghost.Add(new Ghost(this, i, j, new Vector2(), GhostState.Chase, new Color()));
                            }
                            //energizer
                            if (substrings[j] == "e")
                            {
                                //this.board = new Energizer();
                                energizer.Collision += scoreAndLives.IncrementScore;
                            }


                        }
                        catch (FormatException a)
                        {
                            Console.WriteLine(a.GetBaseException());
                        }
                        catch (OverflowException ai)
                        {
                            Console.WriteLine(ai.GetBaseException());
                        }
                    }//inner for

                }//outter for

            }
            catch (ArgumentException a)
            {
                Console.WriteLine("murphy's law" + a.Message);
            }
            return new GameState() { Board = board, Pacman = pacman, GhostPack = ghost,
                                     Pen = pen, Score = scoreAndLives, Maze = maze};
        }

        public Tile[,] Board
        {
            get;
            private set;
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
