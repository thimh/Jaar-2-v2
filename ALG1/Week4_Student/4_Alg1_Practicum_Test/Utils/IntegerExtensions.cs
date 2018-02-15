using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Test.Utils
{
    public static class IntegerExtensions
    {
        public static int SumAllSmallerIncSelf(this int number)
        {
            if (number == 1) { return 1; }

            return number + (number - 1).SumAllSmallerIncSelf();
        }
    }
}
