using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
	public class Ship : MovableObject
	{
        private int _countOfLoads;

        public int CountOfLoads
        {
            get
            {
                return _countOfLoads;
            }
            set
            {
                _countOfLoads = value;
            }
        }
        
        public Ship(Field initialField)
        {
            this.Spot = initialField;
            _countOfLoads = 0;
        }

        public override Direction WayToMove()
        {
            if (Spot.FieldToLeft.FieldToLeft.FieldToLeft == null)
            {
                return Direction.Remove;
            }

            if (CountOfLoads.Equals(8))
            {
                return Direction.Left;
            }

            if (!Spot.FieldBelow.GetType().Equals(typeof(Dock)))
            {
                return Direction.Left;
            }

            return Direction.nulldirection;
        }

        public override void MakeMove(Direction richting)
        {
            Field targetField = Spot.NeighbourInDirection(richting);

            //right
            Field targetField2 = Spot.NeighbourInDirection(richting).FieldToRight;
            Field targetField3 = Spot.NeighbourInDirection(richting).FieldToRight.FieldToRight;

            //left
            Field targetField4 = Spot.NeighbourInDirection(richting).FieldToLeft;
            Field targetField5 = Spot.NeighbourInDirection(richting).FieldToLeft.FieldToLeft;

            var field = (Field)targetField;
            //right
            var field2 = (Water)targetField2;
            var field3 = (Water)targetField3;
            //left
            var field4 = (Water)targetField4;
            var field5 = (Water)targetField5;


            field.Place(this);
            if (field2 != null)
                field2.ToChar1 = TocharRight();
            if (field4 != null)
                field4.ToChar1 = ToCharLeft();

            //reset            
            Spot.Remove();
            if(Spot.FieldToRight != null)
                field3.ToChar1 = '█';
            
            Spot = field;
            Spot.FieldToRight = field2;
            Spot.FieldToLeft = field4;
        }

        public override char ToChar()
        {
            if (CountOfLoads >= 5)
            {
                return '=';
            }
            return '_';
        }

        public char TocharRight()
        {
            if (CountOfLoads >= 8)
            {
                return '=';
            }
            return '_';
        }

        public char ToCharLeft()
        {
            if (CountOfLoads >= 4)
            {
                return '=';
            }
            return '_';
        }
 
	}
}

