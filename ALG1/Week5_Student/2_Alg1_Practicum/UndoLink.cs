using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public enum Operation
    {
        DUMMY, ADD, REMOVE
    }

    public class UndoLink
    {
        public Operation Operation { get; set; }
        public NAW Naw { get; set; }

        public UndoLink Previous { get; set; }

        public UndoLink Next { get; set; }
    }
}
