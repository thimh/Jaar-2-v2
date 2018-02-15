using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sokoban.Domain;

namespace Sokoban.Presentation
{

    public class MazeViewController : Visitor
    {
        public Maze MazeViewed { get; set; }
        private char _fieldRepresentation;

        public char DrawFieldAt(int x, int y)
        {
            _fieldRepresentation = '?';

            // look-up requested field in maze
            var currentField = this.MazeViewed.Origin;
            for (int column = 0; column < x; column++)
            {
                currentField = currentField.NeighbourInDirection(Direction.Right);
            }
            for (int row = 0; row < y; row++)
            {
                currentField = currentField.NeighbourInDirection(Direction.Down);
            }

            // visit Field
            currentField.Accept(this);

            return _fieldRepresentation;
        }

        override public void Visit(FloorField floorField)
        {
            if (floorField.IsEmpty())
            {
                _fieldRepresentation = '.';
            }
            else if (floorField.Content is Truck)
            {
                _fieldRepresentation = '@';
            }
            else if (floorField.Content is Crate)
            {
                _fieldRepresentation = '#';
            }
        }

        override public void Visit(TargetField targetField)
        {
            if (targetField.IsEmpty())
            {
                _fieldRepresentation = 'x';
            }
            else if (targetField.Content is Crate)
            {
                _fieldRepresentation = '0';
            }
            else if (targetField.Content is Truck)
            {
                _fieldRepresentation = '@';
            }
        }

        override public void Visit(WallField wallField)
        {
            _fieldRepresentation = '█';
        }

        override public void Visit(EmptyField emptyField)
        {
            _fieldRepresentation = ' ';
        }

    }
}
