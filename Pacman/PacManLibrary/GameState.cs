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
        Energizer energizer;
        Pacman pacman;
        ScoreAndLives scoreAndLives;

       public GameState()
        {
            board = new Tile[23, 23];
            ghost = new GhostPack();
            pen = new Pen();
            maze = new Maze();
            pellet = new Pellet();
            energizer = new Energizer(ghost);
            pacman = new Pacman(this);
            scoreAndLives = new ScoreAndLives(this);
        }
   
        public  GameState parse (string fale)
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
                                this.board[i, j] = new Wall(i, j);

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
            return this;
        }
  
        public Pacman Pacman
        {
            get { return this.pacman; }
            private set { this.pacman = value; }
        }
        public GhostPack ghostPack
        {
            get { return this.ghost; }
            private set { this.ghost = value; }
        }
        public Maze Maze
        {
            get { return this.maze; }
            private set { this.maze = value; }
        }
        public Pen Pen
        {
            get { return this.pen; }
            private set { this.pen = value; }
        }
        public ScoreAndLives Score
        {
            get { return this.scoreAndLives; }
            private set { this.scoreAndLives = value; }
        }
    }
}
