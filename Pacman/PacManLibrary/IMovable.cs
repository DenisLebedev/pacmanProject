using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace PacManLibrary
{
    /// <summary>
    /// IMovable allow any class that implement this interface
    ///  to move, but they have to implement a Direction and 
    ///  a Position either.
    /// </summary>
    interface IMovable
    {
        /// <summary>
        /// The current Direction is saved by the property
        /// </summary>
        Direction Direction { get; set; }

        /// <summary>
        /// The position of our boject has to be saved either
        /// </summary>
        Vector2 Position { get; set; }

        /// <summary>
        /// The move method has to make the object move and update any 
        /// property if needed.
        /// </summary>
        void Move();
    }
}
