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
        Tile[,] board;
        GhostPack ghost;
        Pen pen;
        Maze maze;
        Pellet pellet;
        ScoreAndLives scoreAndLives;

       public GameState()
        {
            board = new Tile[23, 23];
            ghost = new GhostPack();
            pen = new Pen();
            maze = new Maze();
            pellet = new Pellet();
            scoreAndLives = new ScoreAndLives(this);
        }
        public void csvReader()
        {
            char deleimeter = ' ';
            string[,] board = new string[23, 26];
            string[] readText = null;
            try
            {
                readText = File.ReadAllLines("..\\..\\..\\game_board.txt");
                for (int i = 0; i < 23; i++)
                {

                    String[] substrings = readText[i].Split(deleimeter);

                    for (int j = 0; j < 23; j++)
                    {
                        try
                        {   //wall
                            if (substrings[j] == "w")
                            {
                                this.board[i, j] = new Wall(i,j);

                            }
                            //path
                            if (substrings[j] == "p")
                            {
                                this.board[i, j] = new Path(i, j);
                                pellet.PelletEvent += scoreAndLives.IncrementScore();
                            }
                            //pacman
                            if (substrings[j] == "P")
                            {
                                this.board[i, j] = Pacman;
                            }
                            //ghost
                            if (substrings[j] == "1" || substrings[j] == "2" ||
                                substrings[j] == "3" || substrings[j] == "4")
                            {
                                this.board[i, j] = ghost.Add(new Ghost(this, i, j, new Vector2(), GhostState.Chase, new Color()));
                            }
                            //energizer
                            if (substrings[j] == "e")
                            {
                                this.board[i, j] = new Energizer(i,j);
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

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {

                    }

                }

            }
            catch (ArgumentException a)
            {
                Console.WriteLine("fuck this sht" + a.Message);
            }

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    
                }
              
            }
        }
        public static GameState parse (string fale)
        {
            return null;
        }
  
        public Pacman Pacman
        {
            get;
            private set;
        }
        public GhostPack ghostPack
        {
            private set;
            get;
        }
        public Maze Maze
        {
            private set { }
            get { return Maze;}
        }
        public Pen Pen
        {
            private set;
            get;
        }
        public ScoreAndLives Score
        {
            private set;
            get;
        }
    }
}
