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
            GameState game = new GameState();
            GhostPack ghost = new GhostPack();
            Pen pen = new Pen ();
            Maze maze = new Maze();
            Pellet pellet = new Pellet();
            Energizer energizer = new Energizer(ghost);
            Pacman pacman = new Pacman (game);
            ScoreAndLives scoreAndLives = new ScoreAndLives(game);


            
            //helper variables for reading from file
            string currentLine;
            int i = 0;
            int j = 0;
            int lineCount = File.ReadLines(file).Count();
            Tile[,] board = new Tile[lineCount, lineCount];

            using (StreamReader sr = new StreamReader(file))
            {
                // currentLine will be null when the StreamReader reaches the end of file
                while ((currentLine = sr.ReadLine()) != null)
                {
                    IEnumerable<string> line = currentLine.Split(',');
                    foreach (string str in line)
                    {
                    //wall
                            if (str == "w")
                            {
                               // board[i, j] = new Wall(i, j);

                            }
                            //path
                            if (str == "p")
                            {
                                //board[i, j] = new Pellet();
                                pellet.Collision += scoreAndLives.IncrementScore;
                            }
                            //pacman
                            if (str == "P")
                            {
                                //this.board[i, j] = pacman;
                                pacman.Position = new Vector2(i, j);
                            }
                            //ghost
                            if (str == "1" || str == "2" ||
                                str == "3" || str == "4")
                            {
                                Ghost temp = CreateGhost(str, i, j, game, pacman);
                                ghost.Add(temp);
                                temp.Collision += scoreAndLives.IncrementScore;
                                temp.DeadPacman += scoreAndLives.deadPacman;

                            }
                            //energizer
                            if (str == "e")
                            {
                                //this.board = new Energizer();
                                energizer.Collision += scoreAndLives.IncrementScore;
                            }
                        //board[i, j] = str;
                        j++;
                    }
                    j = 0;
                    i++;
                } 

                
            }

            maze.SetTiles(board);
            return new GameState()
            {
                Pacman = pacman,
                GhostPack = ghost,
                Pen = pen,
                Score = scoreAndLives,
                Maze = maze
            };
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
