using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    class Wall : PlacableObject
    {
        public override bool Move(Direction richting)
        {
            return false;
        }

    }
}
