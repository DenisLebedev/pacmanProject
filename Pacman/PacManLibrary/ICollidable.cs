using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    interface ICollidable
    {
        //public event Collision;

        int Points { get; set; }

        void Collide();
    }
}
