using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    class Path : Tile 
    {
        private int x;
        private int y;
        ICollidable member;

        public event CollisionEvent Collision;

        public Path(int x, int y, ICollidable member) : base(x, y)
        {
            this.x = x;
            this.y = y;
            this.member = member;    
        }
        /// <summary>
        /// Since this class knows it's points (x,y), this means it is a single
        ///individual object that knows where it is in life so we are in the path
        ///class which contains only Icollidable objects so yes it can always enter 
        /// </summary>
        public override bool CanEnter()
        {
            return true;
        }
        /// <summary>
        /// The is empty method will check if a member
        /// </summary>
        public override bool IsEmpty()
        {
            if (member == null)
            {
                return true;
            }

            return true;
        }


        public override void Collide()
        {
            member.Collide();
        }

        public override ICollidable Member()
        {
            return member;  
        }
    }
}
