using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Utils
{
    public interface INawArray
    {
        void Add(NAW item);

        int Count { get; set; }

        int ItemCount();

        Alg1NawArray Array { get; set; }
    }
}
