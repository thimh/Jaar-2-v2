using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class NawDoublyLinkedList : IBubbleSort
    {

        public DoubleLink First { get; set; }
        public DoubleLink Last { get; set; }

        //
        // Workshop methodes
        //

        public void InsertHead(NAW naw)
        {
            //throw new NotImplementedException();
            DoubleLink _current = First;
            DoubleLink _previous;

            First.Naw = naw;
            First.Next = _current;
            First.Previous = null;
            _previous = First;
            _current.Previous = _previous;


            if (_current.Next != null)
            {
                while (_current.Next != null)
                {
                    _previous = _current;
                    _current = _current.Next;
                    _current.Previous = _previous;
                }
            }
            else
            {
                Last = _current;
            }
        }

        public DoubleLink SwapLinkWithNext(DoubleLink link)
        {
            //throw new NotImplementedException();
            DoubleLink toSwap = link;
            DoubleLink toSwapWith;

            if (toSwap.Next != null)
            {
                toSwapWith = toSwap.Next;

                toSwap.Previous = toSwapWith;
                toSwap.Next = toSwapWith.Next;

                toSwapWith.Previous = link.Previous;
                toSwapWith.Next = toSwap;

                return toSwapWith;
            }
            else
            {
                return null;
            }

            return null;
        }


        //
        // Huiswerk methodes
        //

        public void BubbleSort()
        {
            throw new NotImplementedException();
        }

        public BigO OrderOfBubbleSort()
        {
            return BigO.One;
        }

        //
        //  Onderstaande methode hoef je niet te implementeren maar hoort wel bij de IBubbleSort interface
        //

        public void BubbleSortInverted()
        {
            throw new NotImplementedException();
        }
    }
}
