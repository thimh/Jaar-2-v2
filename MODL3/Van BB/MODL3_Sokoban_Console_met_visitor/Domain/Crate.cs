
namespace Sokoban.Domain
{
    public class Crate : PlacableObject
    {
        public Crate(BaseField initialField)
        {
            this.Spot = initialField;
        }

  
        override public bool Move(Direction direction)
        {
            var destinationField = Spot.NeighbourInDirection(direction);
            if (destinationField.IsEmpty())
            {
                destinationField.Place(this);
                Spot.Remove();
                    Spot = destinationField;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsOnTarget()
        {
            return (Spot is TargetField);
        }

    }
}

