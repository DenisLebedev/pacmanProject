using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    /// <summary>
    /// IGhostState is important because the interface force
    /// to implement move method. In this case this interface
    /// allow us to determine the state of a ghost and how he
    /// is gonna move. The implementation is made individually.
    /// </summary>
    public interface IGhostState
    {
        void Move();
    }
}
