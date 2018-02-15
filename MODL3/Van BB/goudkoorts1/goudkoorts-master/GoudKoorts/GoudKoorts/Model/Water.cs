using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Water : Field
	{

        private char _toChar = 'a';

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
            if (this.Content != null)
                return this.Content.ToChar();
            
            if (_toChar != 'a')
                return _toChar;
            else
                return '█';
        }

        public char ToChar1
        {
            get
            {
                return _toChar;
            }
            set
            {
                _toChar = value;
            }

        }

        public override void Remove()
        {
            this.Content = null;
        }

	}
}

