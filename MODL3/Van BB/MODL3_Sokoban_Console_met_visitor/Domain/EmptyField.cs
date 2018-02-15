using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public class EmptyField : BaseField
    {
        public override bool IsEmpty()
        {
            return false;
        }

        public override PlacableObject Content
        {
            get
            {
                return null;
            }
            set
            {
            }
        }
 
        public override bool Place(PlacableObject objectToBePlaced)
        {
            return false;
        }

        public override void Remove() { }

        override public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
