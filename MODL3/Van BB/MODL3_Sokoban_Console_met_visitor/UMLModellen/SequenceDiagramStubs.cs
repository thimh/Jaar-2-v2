using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sokoban.Domain;

namespace Sokoban
{
    public class SequenceDiagramStubs
    {

        FloorField currentField = new FloorField();
        FloorField targetField = new FloorField();

        public void polymorphMove()
        {

            Crate crate = new Crate(currentField);
            Truck truck = new Truck(currentField);
            Wall wall = new Wall();

            wall.Move(Direction.Right);
            crate.Move(Direction.Right);
            truck.Move(Direction.Right);

        }

        public void polymorphPlace()
        {
            Crate crate = new Crate(currentField);
            Truck truck = new Truck(currentField);
            Wall wall = new Wall();

            FloorField floorField = new FloorField();
            WallField wallField = new WallField();
            EmptyField emptyField = new EmptyField();

            floorField.Place(crate);
            wallField.Place(crate);
            emptyField.Place(crate);

        }

 

    }
}
