using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
	public abstract class Field
	{
        public Field FieldToRight
        {
            get;
            set;
        }
        public Field FieldBelow
        {
            get;
            set;
        }
        public Field FieldToLeft
        {
            get;
            set;
        }
        public Field FieldAbove
        {
            get;
            set;
        }

		public virtual MovableObject Content
		{
			get;
			set;
		}

        public MovableObject MovableObject
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public abstract bool IsEmpty();
        public abstract char ToChar();
        public abstract bool Place(MovableObject objectToBePlaced);
        public abstract void Remove();

        public Field NeighbourInDirection(Direction direction)
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

