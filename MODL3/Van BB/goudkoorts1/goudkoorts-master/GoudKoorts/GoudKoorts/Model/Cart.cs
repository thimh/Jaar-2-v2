using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
	public class Cart : MovableObject
	{
        private char _toChar;

        public Cart(Field initialField)
        {            
            this.Spot = initialField;
            _toChar = 'W';
        }

        public override Direction WayToMove()
        {
            if (Spot.GetType().Equals(typeof(StartPoint)))
            {
                return Direction.Right;
            }

            if (Spot.GetType().Equals(typeof(Storage)))
            {
                if(Spot.FieldToLeft.GetType().Equals(typeof(EmptyField)))
                    return Direction.nulldirection;

                if (Spot.FieldToLeft.IsEmpty())
                    return Direction.Left;
            }

            if (Spot.GetType().Equals(typeof(Rail)))
            {
                if (Spot.FieldToLeft == null)
                {
                    return Direction.Remove;
                }                              

                if (Spot.FieldToLeft.GetType().Equals(typeof(Storage)) && Spot.FieldToLeft.Content != null)
                    return Direction.nulldirection;

                if (Spot.FieldAbove.GetType().Equals(typeof(Water)) || Spot.FieldAbove.GetType().Equals(typeof(Dock)))
                    return Direction.Left;

                if (Spot.FieldAbove.GetType().Equals(typeof(Rail)) && Spot.FieldToLeft.FieldToLeft.FieldToLeft.GetType().Equals(typeof(Storage)))
                    return Direction.Left;

                if (Spot.FieldAbove.GetType().Equals(typeof(Rail)) && Spot.FieldBelow.GetType().Equals(typeof(Switch))
                    && Spot.FieldToRight.GetType().Equals(typeof(EmptyField)) && Spot.FieldToRight.FieldToRight.GetType().Equals(typeof(EmptyField)))
                    return Direction.Up;

                if(Spot.FieldToRight.GetType().Equals(typeof(Rail)))
                {
                    Field targetField = Spot.NeighbourInDirection(Direction.Right);
                    if (!targetField.IsEmpty())
                    {
                        return Direction.nulldirection;
                    }
                    if (targetField.IsEmpty() && !targetField.GetType().Equals(typeof(EmptyField)))
                    {                       
                        return Direction.Right;
                    }
                    else
                        return Direction.nulldirection; 
                }
                if(Spot.FieldAbove.GetType().Equals(typeof(Switch)))
                {
                    Field targetField = Spot.NeighbourInDirection(Direction.Up);

                    if (targetField.ToChar().Equals('\\'))
                        return Direction.nulldirection; ;
                    if (targetField.ToChar().Equals('/'))
                    {                     
                        return Direction.Up;
                    }                        
                    else
                        return Direction.nulldirection; 
                }
                if (Spot.FieldBelow.GetType().Equals(typeof(Switch)))
                {
                    Field targetField = Spot.NeighbourInDirection(Direction.Down);

                    if (targetField.ToChar().Equals('\\'))
                    {                        
                        return Direction.Down;
                    }                        
                    if (targetField.ToChar().Equals('/'))
                        return Direction.nulldirection;
                    else
                        return Direction.nulldirection;
                }
                if (Spot.FieldToRight.GetType().Equals(typeof(Switch)))
                {
                    Field targetField = Spot.NeighbourInDirection(Direction.Right);

                    if (targetField.ToChar().Equals('S'))
                    {
                        return Direction.nulldirection;
                    }
                    else
                        return Direction.Right;                   
                }               

                if (Spot.FieldToRight.GetType().Equals(typeof(EmptyField)) && Spot.FieldBelow.GetType().Equals(typeof(EmptyField))
                    && !Spot.FieldToLeft.FieldToLeft.FieldToLeft.GetType().Equals(typeof(Storage)))
                    return Direction.Up;

                if (Spot.FieldToRight.GetType().Equals(typeof(EmptyField)) && Spot.FieldToLeft.GetType().Equals(typeof(EmptyField)))
                    return Direction.Up;

                if (Spot.FieldBelow.GetType().Equals(typeof(Rail)) && Spot.FieldAbove.GetType().Equals(typeof(EmptyField)))
                    return Direction.Down;                
            }

            if (Spot.GetType().Equals(typeof(Switch)))
            {
                Field targetField = Spot.NeighbourInDirection(Direction.Down);
                if(Spot.FieldToRight.GetType().Equals(typeof(Rail)))
                {
                    return Direction.Right;
                }

                Switch field = (Switch)Spot;
                if (field.ToDirection().Equals(SwitchDirection.UP))
                    return Direction.Up;
                if (field.ToDirection().Equals(SwitchDirection.DOWN))
                    return Direction.Down;
            }
            return Direction.nulldirection;            
        }
        
        public bool checkGameOver()
        {            
            if (Spot.GetType().Equals(typeof(StartPoint)))
            {
                if (Spot.FieldToRight.Content != null)
                {   
                    if(Spot.FieldToRight.Content.ToChar().Equals('W'))
                        return true;
                }
            }
            else if (!Spot.GetType().Equals(typeof(Storage)))
            {
                if (Spot.FieldToLeft == null)
                    return false;
                if (Spot.FieldToRight.Content != null)
                {
                    if (Spot.FieldToRight.Content.ToChar().Equals('W'))
                        return true;
                }
                if (Spot.FieldToLeft.Content != null)
                {
                    if (Spot.FieldToLeft.Content.ToChar().Equals('W'))
                        return true;
                }
            }
            return false;
        }

        public override void MakeMove(Direction richting)
        {
            Field targetField = Spot.NeighbourInDirection(richting);
            var field = (Field)targetField;
            field.Place(this);
            Spot.Remove();
            Spot = field;
        }

        public bool checkScore()
        {
            if (Spot.FieldAbove.GetType().Equals(typeof(Dock)) && Spot.FieldAbove.FieldAbove.Content != null)
            {
                _toChar = 'E';
                return true;                
            }
            return false;
        }

        public override char ToChar()
        {
            return _toChar;
        }
	}
}

