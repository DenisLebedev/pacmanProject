using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    class Path : Tile, ICollidable 
    {
        private int x;
        private int y;

        public Path(int x, int y) : base(x, y)
        {
            this.x = x;
            this.y = y;
            
        }

        public int Points
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool CanEnter()
        {
            return true;
        }

        public override void Collide()
        {
            throw new NotImplementedException();
        }

        public override bool isEmpty()
        {
            return true;
        }

        public override ICollidable Member()
        {
            throw new NotImplementedException();
        }
        public override Vector2 Position
        {
         get { return new Vector2(x, y); }   
        }
       
    }
}
