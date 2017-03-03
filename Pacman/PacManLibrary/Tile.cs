using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    public abstract class Tile {

        protected Vector2 tile;

        public Tile (int x, int y)
        {
            tile = new Vector2(x, y);
        }

        public virtual Vector2 Position
        {
            get { return new Vector2(tile.X, tile.Y); }
        }
        public abstract ICollidable Member();
        
        public abstract bool CanEnter();

        public abstract void Collide();
    
        public abstract bool isEmpty();

        public virtual float GetDistance (Vector2 goal)
        {
            return Vector2.Distance(tile, goal);
        }

    }
}
