using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Dock : Field
	{
        override public bool IsEmpty()
        {
            return this.Content == null;
        }

        public override bool Place(MovableObject objectToBePlaced)
        {
            if (this.IsEmpty())
            {
                this.Content = objectToBePlaced;
                return true;
            }
            else
            {
                return false;
            }
        }


        public override char ToChar()
        {
            return 'D';
        }

        public override void Remove()
        {
            this.Content = null;
        }

	}
}

