using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    public delegate void CollisionEvent(ICollidable obj);
    /// <summary>
    /// The ICollidable interface will represent objects 
    /// that can be collided with like a Pellete, Energizer and Ghost.
    /// it has an event Collided that will fire when a member is collided 
    /// upon. A read only Points proprety. And a Collide method.
    /// </summary>
    public interface ICollidable
    {
        event CollisionEvent Collision;

        int Points { get;}

        void Collide();
    }
}
