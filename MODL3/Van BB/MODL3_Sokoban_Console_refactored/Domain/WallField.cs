using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    class WallField : BaseField
    {
        Wall _wall = new Wall();

        public override bool IsEmpty()
        {
            return false;
        }

        public override PlacableObject Content
        {
            get
            {
                return _wall;
            }
            set
            {
            }
        }

        public override char ToChar()
        {
            return '█';
        }

        public override bool Place(PlacableObject objectToBePlaced)
        {
            return false;
        }

        public override void Remove() { }

    }
}
