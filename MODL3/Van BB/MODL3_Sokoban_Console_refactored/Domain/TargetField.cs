using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Domain
{
    class TargetField : FloorField
    {
        public override char ToChar()
        {
            if (!IsEmpty() && !(Content is Crate))
            {
                return Content.ToChar();
            }
            else if (Content is Crate)
            {
                return '0';
            }
            else
            {
                return 'x';
            }
        }

    }
}
