using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public abstract class Visitor
    {
        public abstract void Visit(EmptyField visitee);
        public abstract void Visit(FloorField visitee);
        public abstract void Visit(TargetField visitee);
        public abstract void Visit(WallField visitee);
    }
}
