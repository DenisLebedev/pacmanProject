using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    public delegate void CollisionEvent(ICollidable obj);
    public interface ICollidable
    {
        event CollisionEvent Collision;

        int Points { get; set; }

        void Collide();
    }
}
