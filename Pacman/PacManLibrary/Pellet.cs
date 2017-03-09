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
        public Pellet()
        {
            this.points = 100;
        }
      
        public event CollisionEvent Collision;

        public int Points
        {
            get
            {
                return this.points;
            }
            
        }

        public void Collide()
        {
            Collision?.Invoke(this);
        }
    }
}
