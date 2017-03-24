using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacManLibrary;

namespace PacManGame
{
    class PacmanSprite
    {
        private Game1 game1;
        private GameState gs;

        public PacmanSprite(Game1 game1, GameState gs)
        {
            this.game1 = game1;
            this.gs = gs;
        }
    }
}
