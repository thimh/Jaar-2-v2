
namespace Sokoban.Domain
{
    public class Truck : PlacableObject
    {

        public Truck(BaseField initialField)
        {
            this.Spot = initialField;
        }

   
        override public bool Move(Direction direction)
        {
            BaseField targetField = Spot.NeighbourInDirection(direction);
    
            if (!targetField.IsEmpty())
            {
                targetField.Content.Move(direction);
            }
            if (targetField.IsEmpty())
            {
                var floorField = (FloorField)targetField;
                floorField.Place(this);
                Spot.Remove();
                Spot = floorField;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
