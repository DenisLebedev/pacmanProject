using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{   
    /// <summary>
    /// Tile class will contain all possible object that gonna
    /// be on the final maze.
    /// </summary>
    public abstract class Tile {
        protected Vector2 tile;

        /// <summary>
        ///  The constructor initalize the position
        ///  of our object in the tile
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Tile (int x, int y)
        {
            tile = new Vector2(x, y);
        }

        /// <summary>
        /// The Property return the position of this object
        /// </summary>
        public virtual Vector2 Position
        {
            get { return new Vector2(tile.X, tile.Y); }
        }

        /// <summary>
        /// Member is returning the actual object on the tile
        /// </summary>
        /// <returns>Memeber returns the actual object on the path</returns>
        public abstract ICollidable Member();
        
        /// <summary>
        /// A Tile can be a wall or a Path depending
        /// which one is implemented you can or cannot enter
        /// for example you cannot enter in a wall.
        /// </summary>
        /// <returns></returns>
        public abstract bool CanEnter();

        /// <summary>
        /// Collide look if the object inside can collide
        /// </summary>
        public abstract void Collide();
    
        /// <summary>
        /// IsEmpty look if the actual object is empty
        /// or not.
        /// </summary>
        /// <returns>If the object inside the tile is none existant then return false</returns>
        public abstract bool IsEmpty();

        /// <summary>
        /// GetDistance will tell you how much is left to reach your position
        /// depending on the given vector.
        /// </summary>
        /// <param name="goal">Goal is generally where you are</param>
        /// <returns>returns the distance from the goal to this tile.</returns>
        public virtual float GetDistance (Vector2 goal)
        {
            return Vector2.Distance(tile, goal);
        }

    }
}
