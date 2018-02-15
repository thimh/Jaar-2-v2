using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public class TargetField : FloorField
    {
        override public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
