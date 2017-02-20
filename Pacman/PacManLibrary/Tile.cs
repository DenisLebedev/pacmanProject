using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    abstract class Tile {

        protected Vector2 tile;   
     
        public Tile (int x, int y)
        {
            tile = new Vector2(x, y);
        }

        public virtual Vector2 Position()
        {
            return new Vector2(tile.X, tile.Y);
        }
        public virtual ICollidable Member()
        {
            return null;
        }
        public virtual bool CanEnter()
        
            //if (Wall)


            return false;
        }

        public virtual void Collide()
        {
           // if (Wall.Position().ToPoint == tile.ToPoint)
           
        }
        public virtual bool isEmpty()
        {
            return false;
        }
        public virtual float GetDistance (Vector2 goal)
        {
            return Vector2.Distance(tile, goal);
        }




    }
}
