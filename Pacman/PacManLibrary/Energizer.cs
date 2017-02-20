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

        public Energizer (GhostPack ghosts)
        {
            this.ghosts = ghosts;
            this.points = 100;
        }


        public int Points
        {
            get
            {
                return points;
            }

            set
            {
                this.points = value;
            }
        }

        public void Collide()
        {
            throw new NotImplementedException();
        }
    }
}
