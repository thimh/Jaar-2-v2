using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Rail : Field
	{
        private char _tochar;

        override public bool IsEmpty()
        {
            return this.Content == null;
        }

        public Rail(char _tochar)
        {
            this._tochar = _tochar;
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
            if (!this.IsEmpty())
            {
                return Content.ToChar();
            }
            else
            {
                return this._tochar;
            }
        }

        public override void Remove()
        {
            this.Content = null;
        }
	}
}

