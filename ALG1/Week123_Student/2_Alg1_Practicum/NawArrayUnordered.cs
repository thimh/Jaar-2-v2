using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Exceptions;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class NawArrayUnordered : INawArrayUnordered, INawArrayUnordered_wk2, IBubbleSort, ISelectionSort, IInsertionSort
    {
        protected Alg1NawArray _nawArray;
        protected int _size;
        protected int _used;

        //
        // Workshop methodes
        //

        public NawArrayUnordered(int initialSize)
        {
            if (initialSize > 1 && initialSize < 1000000)
            {
                _nawArray = new Alg1NawArray(initialSize);
                _used = 0;
                _size = initialSize;
            }
            else
            {
                throw new NawArrayUnorderedInvalidSizeException();
            }
        }

        public int ItemCount()
        {
            return _used;
        }

        public void Add(NAW item)
        {
            if (!(_used >= _size))
            {
                _nawArray[_used] = new NAW(item.Naam, item.Adres, item.Woonplaats);
                _used += 1;
            }
            else
            {
                throw new NawArrayUnorderedOutOfBoundsException();
            }
        }

        public int FindNaam(string gezochteNaam)
        {
            int index = 0;

            for (int i = 0; _used > i; i++)
            {
                if (_nawArray[i].Naam.Equals(gezochteNaam))
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        //
        // Huiswerk methodes
        //

        public void RemoveAtIndex(int index)
        {
            throw new NotImplementedException();
        }

        public void RemoveFirstNaam(string gezochteNaam)
        {
            throw new NotImplementedException();
        }

        public void RemoveLastNaam(string gezochteNaam)
        {
            throw new NotImplementedException();
        }

        public int RemoveAllNaam(string gezochteNaam)
        {
            throw new NotImplementedException();
        }

        //
        // Hulp methodes, deze moet/mag je niet wijzigen of weggooien
        //

        public void Show()
        {
            System.Console.WriteLine("Array contains {0} of {1} items.",_used,_size);
            for (int i=0; i<_size; i++)
            {
                if (i == _used)
                {
                    System.Console.WriteLine("------------------------------------------------------");
                }
                System.Console.Write("Item {0} contains: ", i);
                if (_nawArray[i] != null)
                {
                    _nawArray[i].Show();
                }
                else
                {
                    System.Console.WriteLine("nothing");
                }
            }
        }


        public Alg1NawArray Array
        {
            get { return _nawArray; }
            set { _nawArray = value; }
        }

        public int Count
        {
            get { return ItemCount(); }
            set { _used = value; }
        }

        public int FindNaw(NAW item)
        {
            throw new NotImplementedException();
        }

        public void BubbleSort()
        {
            int outer, inner;
            for (outer = (_used - 1); outer > 0; outer--)
            {
                for (inner = 0; inner < outer; inner++)
                {
                    if (_nawArray[inner].CompareTo(_nawArray[(inner + 1)]) > 0)
                    {
                        _nawArray.Swap(inner, (inner + 1));
                    }
                }
            }
        }

        public void BubbleSortAlternative()
        {
            int outer, inner;
            for (outer = (_used - 1); outer > 0; outer--)
            {
                for (inner = 0; inner < outer; inner++)
                {
                    if (_nawArray[inner].CompareTo(_nawArray[(inner + 1)]) == 1 || _nawArray[inner].CompareTo(_nawArray[inner + 1]) == 0)
                    {
                        _nawArray.Swap(inner, (inner + 1));
                    }
                }
            }
        }

        public void BubbleSortInverted()
        {
            int outer, inner;
            for (outer = 0; outer <= _used; outer++)
            {
                for (inner = _used - 1; inner > outer; inner--)
                {
                    if (_nawArray[inner].CompareTo(_nawArray[(inner - 1)]) == -1)
                    {
                        _nawArray.Swap(inner, (inner - 1));
                    }
                }
            }
        }

        public INawArrayOrdered ToNawArrayOrdered()
        {
            NawArrayOrdered _nawArrayOrdered = new NawArrayOrdered(_used);

            for (int i = 0; i < _used; i++)
            {
                _nawArrayOrdered.Add(_nawArray[i]);
            }
            return _nawArrayOrdered;
        }

        public void SelectionSort()
        {
            int outer, inner, min;

            for (outer = 0; outer < (_used - 1); outer++)
            {
                min = outer;
                for (inner = (outer + 1); inner < _used; inner++)
                {
                    if (_nawArray[inner].CompareTo(_nawArray[min]) == -1)
                    {
                        min = inner;
                    }
                    _nawArray.Swap(outer, min);
                    Show();
                }
            }
        }

        public void SelectionSortInverted()
        {
            int outer, inner, min;
            for (outer = _used - 1; outer > 0; outer--)
            {
                min = outer;
                for (inner = outer - 1; inner > _used; inner--)
                {
                    if (_nawArray[inner].CompareTo(_nawArray[min]) == -1)
                    {
                        min = inner;
                        _nawArray.Swap(outer, min);
                    }

                }
            }
        }

        public void InsertionSort()
        {
            int innner, outer;
            for (outer = 1; outer < _used; outer++)
            {
                NAW temp = _nawArray[outer];
                innner = outer;
                while (innner > 0 && ((_nawArray[innner - 1].CompareTo(temp) == 1 || _nawArray[innner - 1].CompareTo(temp) == 0)))
                {
                    _nawArray[innner] = _nawArray[innner - 1];
                    innner--;
                }
                _nawArray[innner] = temp;
            }
        }

        public void InsertionSortInverted()
        {
            int innner, outer;
            for (outer = _used; outer > 0; outer--)
            {
                NAW temp = _nawArray[outer];
                innner = outer;
                while (innner > 0 && ((_nawArray[innner - 1].CompareTo(temp) == 1 || _nawArray[innner - 1].CompareTo(temp) == 0)))
                {
                    _nawArray[innner] = _nawArray[innner - 1];
                    innner--;
                }
                _nawArray[innner] = temp;
            }
        }
    }

}
