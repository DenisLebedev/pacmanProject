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
            Maze.SetTiles(Board);
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
            Tile[,] board = new Tile[23, 23];

            char deleimeter = ' ';
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
                        {  
                            //wall
                            if (substrings[j] == "w")
                            {
                                board[i, j] = new Wall(i, j);

                            }
                            //path
                            if (substrings[j] == "p")
                            {
                                //board[i, j] = new Pellet();
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
                                Ghost temp = CreateGhost(substrings[j], i, j, game, pacman);
                                ghost.Add(temp);
                                temp.Collision += scoreAndLives.IncrementScore;
                                temp.deadPacman += scoreAndLives.deadPacman;

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


            /*string path = "..\\..\\..\\levels.csv";
            string currentLine;
            StreamReader sr = new StreamReader(path);
            string[] line = null;          
            int counter = 0;
            int innerC = 0;
            int lineCount = File.ReadLines(path).Count();
            string[,] board = new string[lineCount, lineCount];
            // currentLine will be null when the StreamReader reaches the end of file
            while ((currentLine = sr.ReadLine()) != null)
            {
                line = currentLine.Split(',');
                foreach (string str in line)
                {
                    board[counter, innerC] = str;
                    innerC++;
                }
                innerC = 0;
                counter++;
            }

              */
        }

        private static Ghost CreateGhost(string str, int x, int y,GameState game, Pacman pacman)
        {
            switch (str)
            {
                //red
                case "1":
                    return new Ghost(game, new Vector2(x,y),pacman.Position, 
                            GhostState.Chase, new Color(255,0,0));
                //green
                case "2":
                    return new Ghost(game, new Vector2(x, y), pacman.Position,
                     GhostState.Chase, new Color(50, 205, 50)); ;
                //hot pink
                case "3":
                    return new Ghost(game, new Vector2(x, y), pacman.Position,
                     GhostState.Chase, new Color(255, 105, 180)); ;
                //orange
                case "4":
                    return new Ghost(game, new Vector2(x, y), pacman.Position,
                     GhostState.Chase, new Color(255, 165, 0)); ;
            }
            return null;
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
