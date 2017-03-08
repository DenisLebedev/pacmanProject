using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{

    public class Pellet : ICollidable
    {
      

        private int points;

      
        public event CollisionEvent Collision;

        public int Points
        {
            get
            {
                return this.points;
            }

            set
            {
                this.points = value;
            }
        }

        public void Collide()
        {
            Collision?.Invoke(this);
        }
    }
}
