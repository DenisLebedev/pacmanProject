using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PacManLibrary
{
    /// <summary>
    /// The GhostPack class is the only class that will have access
    /// to all our Ghost. all interaction to our Ghost will be made
    /// from this class.
    /// </summary>
    public class GhostPack : IEnumerable<Ghost>
    {
        private List<Ghost> ghosts;

        /// <summary>
        /// The constructor initialize a new List of type ghost
        /// </summary>
        public GhostPack()
        {
            ghosts = new List<Ghost>();

        }

        /// <summary>
        /// CheckCollideGhost will check if the ghost is
        /// colliding with the given target
        /// </summary>
        /// <param name="target"></param>
        public void CheckCollideGhosts(Vector2 target)
        {
            for (int i = 0; i < ghosts.Count; i++)
            {
                ghosts.ElementAt(i).Collide();
            }

        }

        /// <summary>
        /// ResetGhost will put all the ghosts to the
        /// pen
        /// </summary>
        public void ResetGhosts()
        {
            for (int i = 0; i < ghosts.Count; i++)
                ghosts.ElementAt(i).Reset();
        }

        /// <summary>
        /// ScareGhosts will put all ghosts in a scare
        /// mode
        /// </summary>
        public void ScareGhosts()
        {
            for (int i = 0; i < ghosts.Count; i++)
            {
                ghosts.ElementAt(i).ChangeState(GhostState.Scared);
            }
        }

        /// <summary>
        /// Move will call the Move method for all ghosts
        /// </summary>
        public void Move()
        {
            for (int i = 0; i < ghosts.Count; i++)
                ghosts.ElementAt(i).Move();
        }

        /// <summary>
        /// Add will add a new ghost to our ghostpack list
        /// </summary>
        /// <param name="g">g represent a ghost object</param>
        public void Add(Ghost g)
        {
            ghosts.Add(g);
        }

        /// <summary>
        /// Allow us tp iterate through the list
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Ghost> GetEnumerator()
        {
            return ghosts.GetEnumerator();
        }

        /// <summary>
        /// Allow us to iterate through the list
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ghosts.GetEnumerator();
        }
    }
}
