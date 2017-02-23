using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    class Path : Tile, ICollidable 
    {
        private Tile tile;

        public Path(int x, int y) : base(x, y)
        {
            tile = new Tile();
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
    }
}
