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
    public class NawArrayOrdered : INawArrayOrdered, IBinarySearch
    {
        protected Alg1NawArray _nawArray;
        protected int _size;
        protected int _used;

        //
        // Workshop methodes
        //

        public NawArrayOrdered(int initialSize)
        {
            if (initialSize > 1 && initialSize < 1000000)
            {
                _nawArray = new Alg1NawArray(initialSize);
                _used = 0;
                _size = initialSize;
            }
            else
            {
                throw new NawArrayOrderedInvalidSizeException();
            }
        }

        public virtual void Add(NAW item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_nawArray[i] == null)
                {
                    try
                    {
                        _nawArray[i] = item;
                    }
                    catch
                    {
                        throw new NawArrayOrderedOutOfBoundsException();
                    }
                }
            }
        }


        //
        // Huiswerk methodes
        //

        public void RemoveAtIndex(int index)
        {
            throw new NotImplementedException();
        }


        public int ItemCount()
        {
            int usedItems = 0;

            for (int i = 0; _nawArray.Size > i; i++)
            {
                if (_nawArray[i] != null)
                {
                    usedItems += 1;
                }
            }
            return usedItems;
        }

        public int Find(NAW item)
        {
            throw new NotImplementedException();
        }


        public bool Update(NAW oldValue, NAW newValue)
        {
            throw new NotImplementedException();
        }

        //
        // Hulp methodes, deze moet/mag je niet wijzigen of weggooien
        //

        public void Show()
        {
            // Gebruikt om mee te testen

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

        public Alg1NawArray Array
        {
            get { return _nawArray; }
            set { _nawArray = value; }
        }

        public int Count
        {
            // huiswerk 1.6
            get { return ItemCount(); }
            set { _used = value; }

        }


        public void AddBinary(NAW item)
        {
            int lowerBound = 0;
            int upperBound = _used - 1;
            int curIn;
            if (upperBound != -1)
            {
                while (true)
                {
                    curIn = (lowerBound + upperBound) / 2;
                    if (lowerBound == upperBound)
                    {
                        for (int i = curIn; i <= _used; i++)
                        {
                            NAW temp;
                            NAW curr = _nawArray[i];
                            NAW next = _nawArray[i + 1];
                            temp = next;
                            next = curr;
                            curr = temp;
                        }
                    }
                    else if (_nawArray[curIn].CompareTo(item) == -1)
                    {
                        lowerBound = curIn + 1;
                    }
                    else
                    {
                        upperBound = curIn - 1;
                    }
                }
            }
        }

        public int FindBinary(NAW item)
        {
            int lowerBound = 0;
            int upperBound = _used - 1;
            int curIn;
            if (upperBound != -1)
            {
                while (true)
                {
                    curIn = (lowerBound + upperBound)/2;
                    if (_nawArray[curIn] == item)
                    {
                        return curIn;
                    }
                    else
                    {
                        if (_nawArray[curIn].CompareTo(item) == -1)
                        {
                            lowerBound = curIn + 1;
                        }
                        else
                        {
                            upperBound = curIn - 1;
                        }
                    }
                }
            }
            else
            {
                return -1;
            }
        }
    }
}


