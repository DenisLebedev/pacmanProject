using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    class GameState
    {
        public static string[,] maze = new string[23, 23];

        public static GameState Parse(string file)
        {
            
            string[] readText = File.ReadAllLines(file);
            Char delimiter = ' ';
            

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                String[] substrings = readText[i].Split(delimiter);
                for (int j = 0; j < maze.GetLength(0); j++)
                {
                    try
                    {
                        maze[i, j] = substrings[j];

                    }
                    catch (FormatException a)
                    {
                        Console.WriteLine(a.GetBaseException());
                    }
                    catch (OverflowException ai)
                    {
                        Console.WriteLine(ai.GetBaseException());
                    }
                }//end of j loop
            }//end of i loop

            return new GameState();


        }
  
        public Pacman Pacman
        {
            private set {
                for (int i = 0; i < maze.Length; i++)
                {
                    for (int j = 0; j < maze.Length; j++)
                    {
                        if (maze[i,j] == "P")
                        {
                            new Tile.Position(i,j);
                        }
                    }
                }

            }
            get { return new Pacman(GameState()); }
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
