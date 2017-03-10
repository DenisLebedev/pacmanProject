using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    class Energizer : ICollidable
    {
        private int points;
        private GhostPack ghosts;

        public event CollisionEvent Collision;

        public Energizer (GhostPack ghosts)
        {
            this.ghosts = ghosts;
            this.points = 500;
        }


        public int Points
        {
            get
            {
                return this.points;
            }
        }

        public void Collide()
        {
            if (Collision != null) {
                Collision(this);
                ghosts.ScareGhosts();
            }        
        }
    }
}
