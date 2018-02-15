using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Domain
{
    public abstract class PlacableObject
    {
        public BaseField Spot;

        public abstract bool Move(Direction richting);

        public abstract char ToChar();
    }
}
