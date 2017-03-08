using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    public delegate void PelletDelegate(ICollidable obj);
    public class Pellet : ICollidable
    {
      

        private int points;

        public event PelletDelegate PelletEvent;


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
            throw new NotImplementedException();
        }
    }
}
