using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PacManLibrary
{
    class GhostPack : IEnumerable<Ghost>
    {
        private List<Ghost> ghosts;

        public GhostPack()
        {
            ghosts = new List<Ghost>();
            
        }

        public void CheckCollideGhosts(Vector2 target)
        {
            for(int i = 0; i < ghosts.Count; i++)
            {              
                ghosts.ElementAt(i).Collide();
                ghosts.ElementAt(i).Collision
            }

        }

        public void ResetGhosts()
        {
            for (int i = 0; i < ghosts.Count; i++)
                ghosts.ElementAt(i).Reset();
        }

        public void ScareGhosts()
        {
            for (int i = 0; i < ghosts.Count; i++)
            {
                ghosts.ElementAt(i).ChangeState(GhostState.Scared);
             
            }
        }

        public void Move()
        {
            for (int i = 0; i < ghosts.Count; i++)
                ghosts.ElementAt(i).Move();
        }

        public void Add (Ghost g)
        {
            ghosts.Add(g);
        }

        public IEnumerator<Ghost> GetEnumerator()
        {
            return ghosts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ghosts.GetEnumerator();
        }
    }
}
