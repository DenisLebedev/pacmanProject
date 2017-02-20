using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace PacManLibrary
{
    class Wall : Tile
    {
        public Wall(int x, int y) : base(x, y)
        {
        }
        public override Vector2 Position()
        {
            return new Vector2 (base.tile.X, base.tile.Y);
        }
    }
}