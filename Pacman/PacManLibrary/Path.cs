using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    public class Path : Tile 
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
            return false;
        }
        /// <summary>
        /// The Collide method is design to call the collide method
        /// of its child classes (pellet and energizer) depending on 
        /// the typ of memeber (local private variable of type ICollidoble).
        /// It will only invoke the Collide method if and only if IsEMpty() 
        /// return false, once that happens it will set that member to null
        /// that represents that the objects collide method was already called
        /// once before.
        /// </summary>
        public override void Collide()
        {
            if (!this.IsEmpty())
            {
                    member.Collide();
                    this.member = null;
            }      
        }
        /// <summary>
        /// The Member method will return the IColidable object, which
        /// represents either a pellet, an energizer or a ghost.
        /// </summary>
        /// <returns></returns>
        public override ICollidable Member()
        {
            return member;  
        }
    }
}