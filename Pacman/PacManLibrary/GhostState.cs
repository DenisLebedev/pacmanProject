using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacManLibrary
{
    /// <summary>
    /// Our ghost has 3 important state and this enum
    /// allow us to keep track of a ghost state.
    /// </summary>
    public enum GhostState
    {
        Scared, Chase, Released
    };
}
