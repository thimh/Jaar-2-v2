using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
	public abstract class MovableObject
	{
        public Field Spot;
        public abstract Direction WayToMove();
        public abstract void MakeMove(Direction richting);
        public abstract char ToChar();

	}
}

