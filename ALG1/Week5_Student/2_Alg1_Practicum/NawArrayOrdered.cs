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
    public class NawArrayOrdered : INawArrayOrdered
    {
        protected Alg1NawArray _nawArray;
        protected int _size = 20;
        protected int _used = 0;

        public NawArrayOrdered(int initialSize)
        {
            if ((initialSize > 0) && (initialSize <= 1000000))
            {
                _size = initialSize;
            }
            else
            {
                throw new NawArrayOrderedInvalidSizeException();
            }

            _nawArray = new Alg1NawArray(_size);
        }

        public void Show()
        {
            // Niet gevraagd

            System.Console.WriteLine("Array contains {0} of {1} items.", _used, _size);
            for (int i = 0; i < _size; i++)
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

        public void RemoveAtIndex(int index)
        {
            if (index >= 0 && index < _used)
            {
                _used--;

                for (int i = index; i < _used; i++)
                {
                    _nawArray[i] = _nawArray[i + 1];
                }
            }
        }

        public int Count
        {
            // huiswerk 1.6
            get { return ItemCount(); }
            set { _used = value; }

        }

        public int ItemCount()
        {
            return _used;
        }

        public virtual void Add(NAW item)
        {

            if (_used == 0)
            {
                _nawArray[0] = item;
                _used++;
            }
            else if (_used < _size)
            {
                // zoek invoegpositie
                bool inserted = false;

                for (int i = 0; !inserted && (i < _used); i++)
                {
                    if (_nawArray[i].CompareTo(item) >= 0)
                    {
                        // maak ruimte
                        for (int j = _used; j > i; j--)
                        {
                            _nawArray[j] = _nawArray[j - 1];
                        }
                        // voeg nieuw element in
                        _nawArray[i] = item;
                        _used++;
                        inserted = true;
                    }
                }
                if (!inserted)
                {
                    // Geen groter item gevonden, invoegen aan einde
                    _nawArray[_used] = item;
                    _used++;
                }
            }
            else
            {
                throw new NawArrayOrderedOutOfBoundsException();
            }
        }


        public int Find(NAW item)
        {

            if (_used > 0)
            {
                // kan item in array voorkomen
                if ((_nawArray[0].CompareTo(item) > 0))
                {
                    return -1;
                }
                if ((_nawArray[_used - 1].CompareTo(item) < 0))
                {
                    return -1;
                }
                else
                { // doorzoek array
                    for (int i = 0; i < _used; i++)
                    {
                        if (_nawArray[i].CompareTo(item) == 0)
                        {
                            return i;
                        }
                        else if (_nawArray[i].CompareTo(item) >= 1)
                        {
                            return -1;
                        }
                    }
                }
            }

            return -1;
        }
        public virtual bool Remove(NAW item)
        {
            // Niet gevraagd
            // Test cases:

            int index = Find(item);
            if (index < _used && index >= 0)
            {
                // item is gevonden, verwijderen uit array
                RemoveAtIndex(index);
                return true;
            }
            else
            {
                // item is niet gevonden
                return false;
            }
        }
        public Alg1NawArray Array
        {
            get { return _nawArray; }
            set { _nawArray = value; }
        }
 

        public bool Update(NAW oldValue, NAW newValue)
        {
            throw new NotImplementedException();
        }
    }
   
}


