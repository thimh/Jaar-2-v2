using Alg1_Practicum;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Test.TestModels
{
    public class TestableLinkedList : LinkedList
    {

        public TestableLinkedList()
            : base()
        {

        }

        public Link First
        {
            get { return _first; }
            set { _first = value; }
        }
        public Link Last
        {
            get { return _last; }
            set { _last = value; }
        }

        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }
    }
}
