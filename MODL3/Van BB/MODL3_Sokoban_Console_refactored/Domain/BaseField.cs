using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    public abstract class BaseField
    {
        public BaseField FieldToRight
        {
            get;
            set;
        }
        public BaseField FieldBelow
        {
            get;
            set;
        }
        public BaseField FieldToLeft
        {
            get;
            set;
        }
        public BaseField FieldAbove
        {
            get;
            set;
        }

        public abstract PlacableObject Content
        {
            get;
            set;
        }

        public abstract bool IsEmpty();

        public abstract char ToChar();

        public abstract bool Place(PlacableObject objectToBePlaced);

        public abstract void Remove();

        public BaseField NeighbourInDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    return FieldToLeft;
                case Direction.Right:
                    return FieldToRight;
                case Direction.Up:
                    return FieldAbove;
                case Direction.Down:
                    return FieldBelow;
                default:
                    return null;
            }
        }

    }
}
