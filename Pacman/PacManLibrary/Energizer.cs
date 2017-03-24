using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    /// <summary>
    /// The Energizer class is an ICollidable member
    /// which means it must implament the Interface
    /// it is responsible for knowing how much it is worth
    /// the amount of points it grants. If it is colided
    /// with it will fire the Collision event inherited from
    /// the interface and at the same time will notify the ghosts
    /// to switch state to scared.
    /// </summary>
    public class Energizer : ICollidable
    {
        private int points;
        private GhostPack ghosts;

        public event CollisionEvent Collision;
        /// <summary>
        /// The Constructor will assign the the points and will take in
        /// a ghostpack object in order to later to fire the event when
        /// the energizer is collided upon
        /// </summary>
        /// <param name="ghosts"></param>
        public Energizer (GhostPack ghosts)
        {
            this.ghosts = ghosts;
            this.points = 500;
        }

        /// <summary>
        /// The Points prop is read only, this is done so no one
        /// outside of this class can set the points an Energizer 
        /// is worth.
        /// </summary>
        public int Points
        {
            get
            {
                return this.points;
            }
        }
        /// <summary>
        /// This method is responsible of raising the events
        /// when the Energizer is collided upon.
        /// </summary>
        public void Collide()
        {
            if (Collision != null) {
                Collision(this);
                ghosts.ScareGhosts();
                
            }        
        }
    }
}
